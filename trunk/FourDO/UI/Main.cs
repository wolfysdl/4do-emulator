﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FourDO.Emulation;
using FourDO.Utilities;
using FourDO.Utilities.MouseHook;

namespace FourDO.UI
{
    public partial class Main : Form
    {
        private const int BASE_WIDTH = 320;
        private const int BASE_HEIGHT = 240;

        private SizeGuard sizeGuard = new SizeGuard();

        private Point pointBeforeFullScreen;
        private bool maximizedBeforeFullScreen = false;
        private bool isWindowFullScreen = false;

        private MouseHook mouseHook = new MouseHook();

        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            // Some basic form setup.
            this.sizeBox.BaseWidth = BASE_WIDTH;
            this.sizeBox.BaseHeight = BASE_HEIGHT;
            
            this.sizeGuard.BaseWidth = BASE_WIDTH;
            this.sizeGuard.BaseHeight = BASE_HEIGHT;
            this.sizeGuard.WindowExtraWidth = this.Width - this.ClientSize.Width;
            this.sizeGuard.WindowExtraHeight = (this.Height - this.ClientSize.Height) + this.MainMenuBar.Height + this.MainStatusStrip.Height;

            this.mouseHook.Install();
            this.mouseHook.MouseMove += new MouseHookEventHandler(mouseHook_MouseMove);
            this.mouseHook.MouseDown += new MouseHookEventHandler(mouseHook_MouseDown);

            this.quickDisplayDropDownButton.DropDownDirection = ToolStripDropDownDirection.AboveLeft;
            
            this.VersionStripItem.Text = "4DO " + Application.ProductVersion;

            GameConsole.Instance.ConsoleStateChange += new ConsoleStateChangeHandler(Instance_ConsoleStateChange);

            ////////////////////
            // Form size and position.

            // Initial form size.
            int savedWidth = Properties.Settings.Default.WindowWidth;
            int savedHeight = Properties.Settings.Default.WindowHeight;
            this.Width = (savedWidth > 0) ? savedWidth : this.sizeGuard.BaseWidth * 2 + this.sizeGuard.WindowExtraWidth;
            this.Height = (savedHeight > 0) ? savedHeight : this.sizeGuard.BaseHeight * 2 + this.sizeGuard.WindowExtraHeight;
            
            // Initial form position.
            if (Properties.Settings.Default.WindowFullScreen)
            {
                // If they were in full screen when they exited, set ourselves at the top+left in the correct screen.
                int screenNum = 0;
                Screen screenToUse = null;
                foreach (Screen screen in Screen.AllScreens)
                {
                    if (screenNum == Properties.Settings.Default.WindowFullScreenDevice)
                    {
                        screenToUse = screen;
                        break;
                    }
                    screenNum++;
                }

                if (screenToUse != null)
                    screenToUse = Screen.PrimaryScreen;

                this.Left = screenToUse.WorkingArea.Left;
                this.Top = screenToUse.WorkingArea.Top;
            }
            
            // Let's ensure we don't go off the bounds of the screen.
            Screen currentScreen = Utilities.DisplayHelper.GetCurrentScreen(this);
            if (this.Bottom > currentScreen.WorkingArea.Bottom)
            {
                this.Top -= (this.Bottom - currentScreen.WorkingArea.Bottom);
                this.Top = Math.Max(this.Top, currentScreen.WorkingArea.Top);
            }
            if (this.Right > currentScreen.WorkingArea.Right)
            {
                this.Left -= (this.Right - currentScreen.WorkingArea.Right);
                this.Left = Math.Max(this.Left, currentScreen.WorkingArea.Left);
            }
            
            // If we updated the size ourselves (we had no valid default) save it now.
            if (savedWidth <= 0 || savedHeight <= 0)
                this.DoSaveWindowSize();
            this.sizeBox.Visible = false; // and shut that damn thing up!
            
            ////////////////
            // Copy some menu items to the quick display settings menu.
            foreach (ToolStripItem item in this.displayMenuItem.DropDownItems)
            {
                ToolStripItem newItem = null;
                if (item is ToolStripSeparator)
                    newItem = new ToolStripSeparator();
                else if (item is ToolStripMenuItem)
                {
                    newItem = new ToolStripMenuItem();
                    newItem.Text = item.Text;
                    newItem.Font = item.Font;

                    if (item == fullScreenMenuItem)
                        newItem.Click += new EventHandler(this.fullScreenMenuItem_Click);

                    if (item == smoothResizingMenuItem)
                        newItem.Click += new EventHandler(this.smoothResizingMenuItem_Click);

                    if (item == snapWindowMenuItem)
                        newItem.Click += new EventHandler(this.snapWindowMenuItem_Click);

                    if (item == preserveRatioMenuItem)
                        newItem.Click += new EventHandler(this.preserveRatioMenuItem_Click);
                }
                newItem.Tag = item;

                this.quickDisplayDropDownButton.DropDownItems.Add(newItem);
            }

            /////////////
            // Handle ROM file nag box
            if (!File.Exists(Properties.Settings.Default.BiosRomFile))
            {
                Properties.Settings.Default.BiosRomFile = "";
                Properties.Settings.Default.Save();
                this.DoShowRomNag();
            }

            //////////////
            // Add save slot menu items.
            if (Properties.Settings.Default.SaveStateSlot < 0 || Properties.Settings.Default.SaveStateSlot > 9)
            {
                Properties.Settings.Default.SaveStateSlot = 0;
                Properties.Settings.Default.Save();
            }

            for (int x = 0; x < 10; x++)
            {
                ToolStripMenuItem newItem = new ToolStripMenuItem("Slot " + x.ToString());
                newItem.Name = "saveSlotMenuItem" + x.ToString();
                newItem.Tag = x;
                newItem.Click += new EventHandler(saveSlotMenuItem_Click);
                saveStateSlotMenuItem.DropDownItems.Add(newItem);
            }

            // Clear the last loaded game if they don't want us to automatically loading games.
            if (Properties.Settings.Default.AutoLoadGameFile == false)
            {
                Properties.Settings.Default.GameRomFile = null;
                Properties.Settings.Default.Save();
            }

            // Clear pause status if we aren't remembering pause
            if (Properties.Settings.Default.AutoRememberPause == false 
                && Properties.Settings.Default.LastPauseStatus == true)
            {
                Properties.Settings.Default.LastPauseStatus = false;
                Properties.Settings.Default.Save();
            }
            // Remember this now, because we can't count it after the console's been started.
            bool lastPauseStatus = Properties.Settings.Default.LastPauseStatus;

            ///////////
            // Now that settings have been mucked with, subscribe to their change event.
            Properties.Settings.Default.PropertyChanged += new PropertyChangedEventHandler(Settings_PropertyChanged);

            //////////////
            // Fire her up!
            this.DoConsoleStart();

            if (Properties.Settings.Default.AutoLoadLastSave == true)
                this.DoLoadState();

            if (Properties.Settings.Default.AutoRememberPause == true && lastPauseStatus == true)
                this.DoConsoleTogglePause();
                
            this.UpdateUI();
        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Ignore console state changes from now on. The console will be shutting itself down.
            GameConsole.Instance.ConsoleStateChange -= new ConsoleStateChangeHandler(Instance_ConsoleStateChange);
            
            this.mouseHook.Uninstall();
            GameConsole.Instance.Stop();
            GameConsole.Instance.Destroy();
        }

        #region Event Handlers

        private void Settings_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            // This is here in case some option box in the future updates the setting for us.
            // We hide ourselves here in order to keep ourselves from looking like a liar.
            //
            // It would be a bad idea to add something like a prompt to restart here, since
            // this setting could presumably be changed anywhere. We'll leave prompting the
            // user to the event handlers.
            string RomFileProperty = Utilities.Reflection.GetPropertyName(() => Properties.Settings.Default.BiosRomFile);
            if (e.PropertyName == RomFileProperty)
            {
                if (string.IsNullOrEmpty(Properties.Settings.Default.BiosRomFile) == false)
                    this.DoHideRomNag();
            }

            if (e.PropertyName == Utilities.Reflection.GetPropertyName(() => Properties.Settings.Default.BiosRomFile)
                    || e.PropertyName == Utilities.Reflection.GetPropertyName(() => Properties.Settings.Default.GameRomFile)
                    || e.PropertyName == Utilities.Reflection.GetPropertyName(() => Properties.Settings.Default.AutoLoadGameFile)
                    || e.PropertyName == Utilities.Reflection.GetPropertyName(() => Properties.Settings.Default.AutoLoadLastSave)
                    || e.PropertyName == Utilities.Reflection.GetPropertyName(() => Properties.Settings.Default.AutoRememberPause)
                    || e.PropertyName == Utilities.Reflection.GetPropertyName(() => Properties.Settings.Default.SaveStateSlot)
                    || e.PropertyName == Utilities.Reflection.GetPropertyName(() => Properties.Settings.Default.WindowFullScreen)
                    || e.PropertyName == Utilities.Reflection.GetPropertyName(() => Properties.Settings.Default.WindowPreseveRatio)
                    || e.PropertyName == Utilities.Reflection.GetPropertyName(() => Properties.Settings.Default.WindowSnapSize)
                    || e.PropertyName == Utilities.Reflection.GetPropertyName(() => Properties.Settings.Default.WindowImageSmoothing))
            {
                this.UpdateUI();
            }
        }

        private void Main_Resize(object sender, EventArgs e)
        {
            if (this.isWindowFullScreen == true
                || this.WindowState == FormWindowState.Maximized
                || this.WindowState == FormWindowState.Minimized
                || Utilities.DisplayHelper.IsFormDocked(this))
            {
                this.sizeBox.Visible = false;
                return;
            }

            this.SuspendLayout();
            sizeBox.UpdateSizeText(gameCanvas.Width, gameCanvas.Height);
            sizeBox.SetBounds(
                    this.ClientSize.Width - 6 - this.sizeBox.PreferredSize.Width,
                    this.ClientSize.Height - this.MainStatusStrip.Height - 6 - this.sizeBox.PreferredSize.Height,
                    this.sizeBox.PreferredSize.Width,
                    this.sizeBox.PreferredSize.Height);
            sizeBox.Visible = true;
            this.ResumeLayout();
            
            this.DoSaveWindowSize();
        }

        protected override void WndProc(ref Message m)
        {
            this.sizeGuard.WatchForResize(ref m);
            base.WndProc(ref m);
        }

        private void MainMenuStrip_MenuActivate(object sender, EventArgs e)
        {
            this.UpdateUI();
        }

        private void RomNagBox_CloseClicked(object sender, EventArgs e)
        {
            this.DoHideRomNag();
        }

        private void RomNagBox_LinkClicked(object sender, EventArgs e)
        {
            this.DoChooseBiosRom();
        }

        private void chooseBiosRomMenuItem_Click(object sender, EventArgs e)
        {
            this.DoChooseBiosRom();
        }

        private void openCDImageMenuItem_Click(object sender, EventArgs e)
        {
            this.DoChooseGameRom();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RefreshFpsTimer_Tick(object sender, EventArgs e)
        {
            this.DoUpdateFPS();
        }

        private void saveStateMenuItem_Click(object sender, EventArgs e)
        {
            this.DoSaveState();
        }

        private void loadStateMenuItem_Click(object sender, EventArgs e)
        {
            this.DoLoadState();
        }

        private void previousSlotMenuItem_Click(object sender, EventArgs e)
        {
            this.DoAdvanceSaveSlot(false);
        }

        private void nextSlotMenuItem_Click(object sender, EventArgs e)
        {
            this.DoAdvanceSaveSlot(true);
        }

        void saveSlotMenuItem_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.SaveStateSlot = (int)((ToolStripMenuItem)sender).Tag;
            Properties.Settings.Default.Save();
        }

        private void loadLastGameMenuItem_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.AutoLoadGameFile = !Properties.Settings.Default.AutoLoadGameFile;
            Properties.Settings.Default.Save();
        }

        private void loadLastSaveMenuItem_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.AutoLoadLastSave = !Properties.Settings.Default.AutoLoadLastSave;
            Properties.Settings.Default.Save();
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.DoShowSettings();
        }

        private void fullScreenMenuItem_Click(object sender, EventArgs e)
        {
            this.DoToggleFullScreen();
        }

        private void snapWindowMenuItem_Click(object sender, EventArgs e)
        {
            this.DoToggleSnapWindow();
        }

        private void preserveRatioMenuItem_Click(object sender, EventArgs e)
        {
            this.DoTogglePreserveRatio();
        }

        private void smoothResizingMenuItem_Click(object sender, EventArgs e)
        {
            this.DoToggleImageSmoothing();
        }

        private void Main_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape && this.isWindowFullScreen)
            {
                this.DoToggleFullScreen();
            }
        }

        void mouseHook_MouseMove(object sender, MouseHookEventArgs e)
        {
            if (this.isWindowFullScreen == false)
                return;

            Screen currentScreen = DisplayHelper.GetCurrentScreen(this);
            if ((e.Y - currentScreen.WorkingArea.Top) < (this.MainMenuBar.Height))
            {
                this.MainMenuBar.Visible = true;
                this.hideMenuTimer.Enabled = false;
                this.hideMenuTimer.Enabled = true;
            }
        }

        void mouseHook_MouseDown(object sender, MouseHookEventArgs e)
        {
            if (this.isWindowFullScreen == false)
                return;

            Screen currentScreen = DisplayHelper.GetCurrentScreen(this);
            if ((e.Y - currentScreen.WorkingArea.Top) >= (this.MainMenuBar.Height))
                this.MainMenuBar.Visible = (this.isWindowFullScreen == false);
        }

        private void hideMenuTimer_Tick(object sender, EventArgs e)
        {
            // Delay hiding the menu if the user is using the menus.
            if (this.MainMenuBar.Focused || this.MainMenuBar.Capture || this.MainMenuBar.ContainsFocus)
                return; 
            
            this.MainMenuBar.Visible = (this.isWindowFullScreen == false);
            this.hideMenuTimer.Enabled = false;
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About aboutForm = new About();
            aboutForm.ShowDialog(this);
        }

        private void resetMenuItem_Click(object sender, EventArgs e)
        {
            this.DoConsoleReset();
        }

        private void pauseMenuItem_Click(object sender, EventArgs e)
        {
            this.DoConsoleTogglePause();
        }

        private void advanceFrameMenuItem_Click(object sender, EventArgs e)
        {
            this.DoConsoleAdvanceFrame();
        }

        private void rememberPauseMenuItem_Click(object sender, EventArgs e)
        {
            this.DoToggleRememberPause();
        }

        private void Instance_ConsoleStateChange(ConsoleStateChangeEventArgs e)
        {
            // Should we remember the status?
            if (Properties.Settings.Default.AutoRememberPause)
            {
                if (e.NewState == ConsoleState.Paused)
                {
                    Properties.Settings.Default.LastPauseStatus = true;
                    Properties.Settings.Default.Save();
                }
                else if (e.NewState == ConsoleState.Running)
                {
                    Properties.Settings.Default.LastPauseStatus = false;
                    Properties.Settings.Default.Save();
                }
            }

            // Some menu items depend on console status.
            this.UpdateUI();
        }

        #endregion // Event Handlers

        #region Private Methods

        private void UpdateUI()
        {
            bool isValidBiosRomSelected = (string.IsNullOrEmpty(Properties.Settings.Default.BiosRomFile) == false);
            bool consoleActive = (GameConsole.Instance.State != ConsoleState.Stopped);

            ////////////////////////
            // File menu

            this.openCDImageMenuItem.Enabled = isValidBiosRomSelected;
            this.loadLastGameMenuItem.Enabled = true;
            this.chooseBiosRomMenuItem.Enabled = true;
            this.exitMenuItem.Enabled = true;

            this.loadLastGameMenuItem.Checked = Properties.Settings.Default.AutoLoadGameFile;

            ////////////////////////
            // Console menu

            this.saveStateMenuItem.Enabled = isValidBiosRomSelected && consoleActive;
            this.loadStateMenuItem.Enabled = isValidBiosRomSelected && consoleActive;
            this.loadLastSaveMenuItem.Enabled = true;
            this.saveStateSlotMenuItem.Enabled = true;
            foreach (ToolStripItem menuItem in this.saveStateSlotMenuItem.DropDownItems)
                menuItem.Enabled = true;
            this.pauseMenuItem.Enabled = consoleActive;
            this.advanceFrameMenuItem.Enabled = consoleActive;
            this.resetMenuItem.Enabled = consoleActive;

            this.pauseMenuItem.Checked = (GameConsole.Instance.State == ConsoleState.Paused);
            this.rememberPauseMenuItem.Checked = Properties.Settings.Default.AutoRememberPause;
            this.loadLastSaveMenuItem.Checked = Properties.Settings.Default.AutoLoadLastSave;

            // Save slot
            foreach (ToolStripItem menuItem in saveStateSlotMenuItem.DropDownItems)
            {
                if (!(menuItem is ToolStripMenuItem))
                    continue;

                if (menuItem.Tag != null)
                    ((ToolStripMenuItem)menuItem).Checked = (Properties.Settings.Default.SaveStateSlot == (int)menuItem.Tag);
            }

            ////////////////////////
            // Display menus. (always enabled)

            this.fullScreenMenuItem.Checked = Properties.Settings.Default.WindowFullScreen;
            this.GetQuickDisplayMenuItem(fullScreenMenuItem).Checked = fullScreenMenuItem.Checked;

            this.smoothResizingMenuItem.Checked = Properties.Settings.Default.WindowImageSmoothing;
            this.GetQuickDisplayMenuItem(smoothResizingMenuItem).Checked = smoothResizingMenuItem.Checked;
            this.gameCanvas.ImageSmoothing = this.smoothResizingMenuItem.Checked;

            this.snapWindowMenuItem.Checked = Properties.Settings.Default.WindowSnapSize;
            this.GetQuickDisplayMenuItem(snapWindowMenuItem).Checked = snapWindowMenuItem.Checked;
            this.sizeGuard.Enabled = this.snapWindowMenuItem.Checked && (Properties.Settings.Default.WindowFullScreen == false);

            this.preserveRatioMenuItem.Checked = Properties.Settings.Default.WindowPreseveRatio;
            this.GetQuickDisplayMenuItem(preserveRatioMenuItem).Checked = preserveRatioMenuItem.Checked;
            this.gameCanvas.PreserveAspectRatio = this.preserveRatioMenuItem.Checked;

            ////////////////////////
            // Other non-menu stuff.


            // If we need to switch full screen status, do it now.
            if (this.isWindowFullScreen != Properties.Settings.Default.WindowFullScreen)
                this.SetFullScreen(Properties.Settings.Default.WindowFullScreen);

            // Misc form stuff.
            this.sizeGuard.Enabled = Properties.Settings.Default.WindowSnapSize;
            
            // Hide, but never show the rom nag box in this function. 
            // The rom nag box only makes itself visible on when emulation fails to start due to an invalid bios.
            if (isValidBiosRomSelected == true)
                this.DoHideRomNag();
        }

        private void DoConsoleStart()
        {
            if (string.IsNullOrEmpty(Properties.Settings.Default.BiosRomFile) == true)
                return;

            ////////////////
            try
            {
                GameConsole.Instance.Start(Properties.Settings.Default.BiosRomFile, Properties.Settings.Default.GameRomFile);
            }
            catch (GameConsole.BadBiosRomException)
            {
                Utilities.Error.ShowError(string.Format("The selected bios file ({0}) was either missing or corrupt. Please choose another.", Properties.Settings.Default.BiosRomFile));
                Properties.Settings.Default.BiosRomFile = ""; // Changing this value will update the UI.
                Properties.Settings.Default.Save();
                this.DoShowRomNag();
            }
            catch (GameConsole.BadGameRomException)
            {
                Utilities.Error.ShowError(string.Format("The selected game file ({0}) was either missing or corrupt. Please choose another.", Properties.Settings.Default.GameRomFile));
                Properties.Settings.Default.GameRomFile = ""; // Changing this value will update the UI.
                Properties.Settings.Default.Save();
                this.DoShowRomNag();
            }

            this.UpdateUI();
        }

        private void DoConsoleReset()
        {
            GameConsole.Instance.Stop();
            this.DoConsoleStart();
        }

        private void DoConsoleTogglePause()
        {
            if (GameConsole.Instance.State == ConsoleState.Running)
                GameConsole.Instance.Pause();
            else if (GameConsole.Instance.State == ConsoleState.Paused)
                GameConsole.Instance.Resume();
        }

        private void DoConsoleAdvanceFrame()
        {
            if (GameConsole.Instance.State == ConsoleState.Stopped)
                return;
            
            // Pause it if we need to.
            if (GameConsole.Instance.State == ConsoleState.Running)
                GameConsole.Instance.Pause();

            if (GameConsole.Instance.State == ConsoleState.Paused)
                GameConsole.Instance.AdvanceSingleFrame();
        }
        
        private void DoShowRomNag()
        {
            RomNagBox.Visible = true;
        }

        private void DoHideRomNag()
        {
            RomNagBox.Visible = false;
        }

        private void DoChooseBiosRom()
        {
            OpenFileDialog openDialog = new OpenFileDialog();

            openDialog.InitialDirectory = Environment.CurrentDirectory;
            openDialog.Filter = "rom files (*.rom)|*.rom|All files (*.*)|*.*";
            openDialog.RestoreDirectory = true;

            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                Properties.Settings.Default.BiosRomFile = openDialog.FileName;
                Properties.Settings.Default.Save();

                this.DoConsoleStart();
            }
        }

        private void DoChooseGameRom()
        {
            OpenFileDialog openDialog = new OpenFileDialog();

            openDialog.InitialDirectory = Environment.CurrentDirectory;
            openDialog.Filter = "iso files (*.iso)|*.iso|All files (*.*)|*.*";
            openDialog.RestoreDirectory = true;

            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                Properties.Settings.Default.GameRomFile = openDialog.FileName;
                Properties.Settings.Default.Save();

                // Start it for them.
                // TODO: Some people may want a prompt. However, I never like this. It's a toss up.
                this.DoConsoleReset();
            }
        }

        private void DoSaveState()
        {
            if (GameConsole.Instance.State != ConsoleState.Stopped)
            {
                string saveStateFileName = this.GetSaveStateFileName(GameConsole.Instance.GameRomFileName, Properties.Settings.Default.SaveStateSlot);
                GameConsole.Instance.SaveState(saveStateFileName);
            }
        }

        private void DoLoadState()
        {
            if (GameConsole.Instance.State != ConsoleState.Stopped)
            {
                string saveStateFileName = this.GetSaveStateFileName(GameConsole.Instance.GameRomFileName, Properties.Settings.Default.SaveStateSlot);
                if (System.IO.File.Exists(saveStateFileName))
                    GameConsole.Instance.LoadState(saveStateFileName);
            }
        }

        private void DoAdvanceSaveSlot(bool up)
        {
            int saveSlot = Properties.Settings.Default.SaveStateSlot;
            if (up == true)
                saveSlot++;
            else
                saveSlot--;

            if (saveSlot == -1)
                saveSlot = 9;

            if (saveSlot == 10)
                saveSlot = 0;

            Properties.Settings.Default.SaveStateSlot = saveSlot;
            Properties.Settings.Default.Save();
        }

        private string GetSaveStateFileName(string gameRomFileName, int saveStateSlot)
        {
            const string SAVE_STATE_EXTENSION = ".4dosav";
            return (gameRomFileName + "." + saveStateSlot.ToString() + SAVE_STATE_EXTENSION);
        }

        private void DoUpdateFPS()
        {
            if (GameConsole.Instance.State == ConsoleState.Running)
            {
                double fps = GameConsole.Instance.CurrentFrameSpeed;
                if (fps != 0)
                {
                    fps = 1 / (fps);
                }
                fps = Math.Min(fps, 99.99);
                FPSStripItem.Text = string.Format("Core FPS: {0:00.00}", fps);
            }
            else
            {
                FPSStripItem.Text = "Core FPS: --.--";
            }
        }

        private void DoShowSettings()
        {
            Settings settingsForm = new Settings();
            settingsForm.ShowDialog(this);
        }

        private void DoToggleFullScreen()
        {
            Properties.Settings.Default.WindowFullScreen = !Properties.Settings.Default.WindowFullScreen;
            Properties.Settings.Default.Save();
        }

        private void DoToggleSnapWindow()
        {
            Properties.Settings.Default.WindowSnapSize = !Properties.Settings.Default.WindowSnapSize;
            Properties.Settings.Default.Save();
        }

        private void DoTogglePreserveRatio()
        {
            Properties.Settings.Default.WindowPreseveRatio = !Properties.Settings.Default.WindowPreseveRatio;
            Properties.Settings.Default.Save();
        }

        private void DoToggleImageSmoothing()
        {
            Properties.Settings.Default.WindowImageSmoothing = !Properties.Settings.Default.WindowImageSmoothing;
            Properties.Settings.Default.Save();
        }

        private void DoToggleRememberPause()
        {
            Properties.Settings.Default.AutoRememberPause = !Properties.Settings.Default.AutoRememberPause;
            Properties.Settings.Default.Save();
        }

        private void DoSaveWindowSize()
        {
            Properties.Settings.Default.WindowWidth = this.Width;
            Properties.Settings.Default.WindowHeight = this.Height;
            Properties.Settings.Default.Save();
        }

        private ToolStripMenuItem GetQuickDisplayMenuItem(ToolStripMenuItem displayMenuItem)
        {
            foreach (ToolStripItem item in quickDisplayDropDownButton.DropDownItems)
            {
                if (item.Tag == displayMenuItem)
                    return (ToolStripMenuItem)item;
            }
            return null;
        }

        private void SetFullScreen(bool enableFullScreen)
        {
            // Keep the window from redrawing
            this.SuspendLayout();

            // Change border style (this causes a resize)
            // and set the full screen enabled flag.
            if (enableFullScreen)
            {
                this.isWindowFullScreen = enableFullScreen;
                this.FormBorderStyle = enableFullScreen ? FormBorderStyle.None : FormBorderStyle.Sizable;
            }
            else
            {
                this.FormBorderStyle = enableFullScreen ? FormBorderStyle.None : FormBorderStyle.Sizable;
                this.isWindowFullScreen = enableFullScreen;
            }

            //////////////////
            // Enable full screen
            if (enableFullScreen == true)
            {
                this.maximizedBeforeFullScreen = (this.WindowState == FormWindowState.Maximized);
                if (this.maximizedBeforeFullScreen)
                    this.WindowState = FormWindowState.Normal;
                else
                    this.pointBeforeFullScreen = new Point(this.Left, this.Top);

                // Find, use, and save the current screen.
                int screenNum;
                Screen currentScreen = Utilities.DisplayHelper.GetCurrentScreen(this, out screenNum);
                Properties.Settings.Default.WindowFullScreenDevice = screenNum;

                // Set form bounds.
                this.Bounds = currentScreen.Bounds;

                // Undock the main menu so it doesn't steal real estate from the game window. 
                this.MainMenuBar.Dock = DockStyle.None;
                this.MainMenuBar.SetBounds(
                    this.ClientRectangle.Left,
                    this.ClientRectangle.Top,
                    this.ClientRectangle.Width,
                    this.MainMenuBar.Height);
                this.MainMenuBar.BringToFront();
            }
            
            //////////////////
            // Otherwise, disable full screen.
            else
            {
                int savedWidth = Properties.Settings.Default.WindowWidth;
                int savedHeight = Properties.Settings.Default.WindowHeight;

                if (this.maximizedBeforeFullScreen)
                {
                    // Restore size but not position.
                    // Windows will remember this size for us when the user returns from maximized state
                    this.Width = savedWidth;
                    this.Height = savedHeight;
                    this.WindowState = FormWindowState.Maximized;
                }
                else
                {
                    this.SetBounds(
                        this.pointBeforeFullScreen.X,
                        this.pointBeforeFullScreen.Y,
                        savedWidth,
                        savedHeight);
                }

                this.MainMenuBar.Dock = DockStyle.Top;
                this.MainMenuBar.SendToBack();
            }

            this.MainMenuBar.Visible = (enableFullScreen == false);
            this.MainStatusStrip.Visible = (enableFullScreen == false);
            this.sizeBox.Visible = false;
            this.TopMost = enableFullScreen;

            this.Refresh();
            this.ResumeLayout();
        }

        #endregion // Private Methods
    }
}