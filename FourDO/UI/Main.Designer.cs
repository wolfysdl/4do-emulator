using FourDO.UI.Controls;

namespace FourDO.UI
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.MainStatusStrip = new System.Windows.Forms.StatusStrip();
            this.VersionStripItem = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.HealthLabelStripItem = new System.Windows.Forms.ToolStripStatusLabel();
            this.HealthStripItem = new System.Windows.Forms.ToolStripStatusLabel();
            this.FPSStripItem = new System.Windows.Forms.ToolStripStatusLabel();
            this.MainMenuBar = new System.Windows.Forms.MenuStrip();
            this.fileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeGameMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.openCDImageMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadLastGameMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.chooseBiosRom1MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chooseBiosRom2MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consoleMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveStateMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadStateMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadLastSaveMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.saveStateSlotMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.previousSlotMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nextSlotMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.screenshotMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator15 = new System.Windows.Forms.ToolStripSeparator();
            this.pauseMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.advanceFrameMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.displayMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fullScreenMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.VoidAreaMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DrawBorderMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
            this.Pattern4DOMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PatternBumpsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PatternMetalMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PatternNoneMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.smoothResizingMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.preserveRatioMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.autoCropMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ScaleMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.snapWindowMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator16 = new System.Windows.Forms.ToolStripSeparator();
            this.scalingModeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scalingModeNoneMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scalingModeDoubleResMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scalingModeHq2xMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scalingModeHq3xMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scalingModeHq4xMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.audioMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.configureInputMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator13 = new System.Windows.Forms.ToolStripSeparator();
            this.languageMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.languageDefaultMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator14 = new System.Windows.Forms.ToolStripSeparator();
            this.toolsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DiscBrowserMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gameInfoMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator12 = new System.Windows.Forms.ToolStripSeparator();
            this.aboutMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshFpsTimer = new System.Windows.Forms.Timer(this.components);
            this.hideMenuTimer = new System.Windows.Forms.Timer(this.components);
            this.checkInputTimer = new System.Windows.Forms.Timer(this.components);
            this.sizeBox = new FourDO.UI.Controls.SizeBox();
            this.RomNagBox = new FourDO.UI.Controls.NagBox();
            this.gameCanvas = new FourDO.UI.GameCanvas();
            this.MainStatusStrip.SuspendLayout();
            this.MainMenuBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainStatusStrip
            // 
            this.MainStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.VersionStripItem,
            this.toolStripStatusLabel1,
            this.HealthLabelStripItem,
            this.HealthStripItem,
            this.FPSStripItem});
            this.MainStatusStrip.Location = new System.Drawing.Point(0, 581);
            this.MainStatusStrip.Name = "MainStatusStrip";
            this.MainStatusStrip.Size = new System.Drawing.Size(744, 22);
            this.MainStatusStrip.TabIndex = 0;
            // 
            // VersionStripItem
            // 
            this.VersionStripItem.Name = "VersionStripItem";
            this.VersionStripItem.Size = new System.Drawing.Size(62, 17);
            this.VersionStripItem.Text = "4DO x.x.x.x";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(603, 17);
            this.toolStripStatusLabel1.Spring = true;
            // 
            // HealthLabelStripItem
            // 
            this.HealthLabelStripItem.Name = "HealthLabelStripItem";
            this.HealthLabelStripItem.Size = new System.Drawing.Size(48, 17);
            this.HealthLabelStripItem.Text = "Health: ";
            // 
            // HealthStripItem
            // 
            this.HealthStripItem.Image = ((System.Drawing.Image)(resources.GetObject("HealthStripItem.Image")));
            this.HealthStripItem.Name = "HealthStripItem";
            this.HealthStripItem.Size = new System.Drawing.Size(16, 17);
            // 
            // FPSStripItem
            // 
            this.FPSStripItem.Name = "FPSStripItem";
            this.FPSStripItem.Size = new System.Drawing.Size(0, 17);
            // 
            // MainMenuBar
            // 
            this.MainMenuBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenuItem,
            this.consoleMenuItem,
            this.displayMenuItem,
            this.audioMenuItem,
            this.optionsMenuItem,
            this.toolsMenuItem,
            this.helpToolStripMenuItem});
            this.MainMenuBar.Location = new System.Drawing.Point(0, 0);
            this.MainMenuBar.Name = "MainMenuBar";
            this.MainMenuBar.Size = new System.Drawing.Size(744, 24);
            this.MainMenuBar.TabIndex = 2;
            this.MainMenuBar.Text = "menuStrip1";
            this.MainMenuBar.MenuActivate += new System.EventHandler(this.MainMenuStrip_MenuActivate);
            // 
            // fileMenuItem
            // 
            this.fileMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.closeGameMenuItem,
            this.toolStripSeparator8,
            this.openCDImageMenuItem,
            this.loadLastGameMenuItem,
            this.toolStripSeparator1,
            this.chooseBiosRom1MenuItem,
            this.chooseBiosRom2MenuItem,
            this.toolStripSeparator2,
            this.exitMenuItem});
            this.fileMenuItem.Name = "fileMenuItem";
            this.fileMenuItem.Size = new System.Drawing.Size(62, 20);
            this.fileMenuItem.Text = "&CoreFile";
            // 
            // closeGameMenuItem
            // 
            this.closeGameMenuItem.Name = "closeGameMenuItem";
            this.closeGameMenuItem.Size = new System.Drawing.Size(250, 22);
            this.closeGameMenuItem.Text = "&Close Game";
            this.closeGameMenuItem.Click += new System.EventHandler(this.closeGameMenuItem_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(247, 6);
            // 
            // openCDImageMenuItem
            // 
            this.openCDImageMenuItem.Name = "openCDImageMenuItem";
            this.openCDImageMenuItem.Size = new System.Drawing.Size(250, 22);
            this.openCDImageMenuItem.Text = "Open CD &Image CoreFile...";
            this.openCDImageMenuItem.Click += new System.EventHandler(this.openCDImageMenuItem_Click);
            // 
            // loadLastGameMenuItem
            // 
            this.loadLastGameMenuItem.Checked = true;
            this.loadLastGameMenuItem.CheckOnClick = true;
            this.loadLastGameMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.loadLastGameMenuItem.Font = new System.Drawing.Font("Arial", 7.5F, System.Drawing.FontStyle.Bold);
            this.loadLastGameMenuItem.Name = "loadLastGameMenuItem";
            this.loadLastGameMenuItem.Size = new System.Drawing.Size(250, 22);
            this.loadLastGameMenuItem.Text = "    After Startup, Open Last Game";
            this.loadLastGameMenuItem.Click += new System.EventHandler(this.loadLastGameMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(247, 6);
            // 
            // chooseBiosRom1MenuItem
            // 
            this.chooseBiosRom1MenuItem.Name = "chooseBiosRom1MenuItem";
            this.chooseBiosRom1MenuItem.Size = new System.Drawing.Size(250, 22);
            this.chooseBiosRom1MenuItem.Text = "Choose &BIOS Rom CoreFile...";
            this.chooseBiosRom1MenuItem.Click += new System.EventHandler(this.chooseBiosRom1MenuItem_Click);
            // 
            // chooseBiosRom2MenuItem
            // 
            this.chooseBiosRom2MenuItem.Name = "chooseBiosRom2MenuItem";
            this.chooseBiosRom2MenuItem.Size = new System.Drawing.Size(250, 22);
            this.chooseBiosRom2MenuItem.Text = "Choose BIOS Rom 2 : Kanji Font...";
            this.chooseBiosRom2MenuItem.Click += new System.EventHandler(this.chooseBiosRom2MenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(247, 6);
            // 
            // exitMenuItem
            // 
            this.exitMenuItem.Name = "exitMenuItem";
            this.exitMenuItem.Size = new System.Drawing.Size(250, 22);
            this.exitMenuItem.Text = "E&xit";
            this.exitMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // consoleMenuItem
            // 
            this.consoleMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveStateMenuItem,
            this.loadStateMenuItem,
            this.loadLastSaveMenuItem,
            this.toolStripSeparator7,
            this.saveStateSlotMenuItem,
            this.toolStripSeparator3,
            this.screenshotMenuItem,
            this.toolStripSeparator15,
            this.pauseMenuItem,
            this.advanceFrameMenuItem,
            this.resetMenuItem});
            this.consoleMenuItem.Name = "consoleMenuItem";
            this.consoleMenuItem.Size = new System.Drawing.Size(62, 20);
            this.consoleMenuItem.Text = "&Console";
            // 
            // saveStateMenuItem
            // 
            this.saveStateMenuItem.Name = "saveStateMenuItem";
            this.saveStateMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.saveStateMenuItem.Size = new System.Drawing.Size(315, 22);
            this.saveStateMenuItem.Text = "&Save State";
            this.saveStateMenuItem.Click += new System.EventHandler(this.saveStateMenuItem_Click);
            // 
            // loadStateMenuItem
            // 
            this.loadStateMenuItem.Name = "loadStateMenuItem";
            this.loadStateMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F8;
            this.loadStateMenuItem.Size = new System.Drawing.Size(315, 22);
            this.loadStateMenuItem.Text = "&Load State";
            this.loadStateMenuItem.Click += new System.EventHandler(this.loadStateMenuItem_Click);
            // 
            // loadLastSaveMenuItem
            // 
            this.loadLastSaveMenuItem.Checked = true;
            this.loadLastSaveMenuItem.CheckOnClick = true;
            this.loadLastSaveMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.loadLastSaveMenuItem.Font = new System.Drawing.Font("Arial", 7.25F, System.Drawing.FontStyle.Bold);
            this.loadLastSaveMenuItem.Name = "loadLastSaveMenuItem";
            this.loadLastSaveMenuItem.Size = new System.Drawing.Size(315, 22);
            this.loadLastSaveMenuItem.Text = "    After Game is Opened, L&oad Last Save (of Slot)";
            this.loadLastSaveMenuItem.Click += new System.EventHandler(this.loadLastSaveMenuItem_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(312, 6);
            // 
            // saveStateSlotMenuItem
            // 
            this.saveStateSlotMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.previousSlotMenuItem,
            this.nextSlotMenuItem,
            this.toolStripSeparator4});
            this.saveStateSlotMenuItem.Name = "saveStateSlotMenuItem";
            this.saveStateSlotMenuItem.Size = new System.Drawing.Size(315, 22);
            this.saveStateSlotMenuItem.Text = "Save State Slo&t";
            // 
            // previousSlotMenuItem
            // 
            this.previousSlotMenuItem.Name = "previousSlotMenuItem";
            this.previousSlotMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F6;
            this.previousSlotMenuItem.Size = new System.Drawing.Size(195, 22);
            this.previousSlotMenuItem.Text = "Select &Previous Slot";
            this.previousSlotMenuItem.Click += new System.EventHandler(this.previousSlotMenuItem_Click);
            // 
            // nextSlotMenuItem
            // 
            this.nextSlotMenuItem.Name = "nextSlotMenuItem";
            this.nextSlotMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F7;
            this.nextSlotMenuItem.Size = new System.Drawing.Size(195, 22);
            this.nextSlotMenuItem.Text = "Select &Next Slot";
            this.nextSlotMenuItem.Click += new System.EventHandler(this.nextSlotMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(192, 6);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(312, 6);
            // 
            // screenshotMenuItem
            // 
            this.screenshotMenuItem.Name = "screenshotMenuItem";
            this.screenshotMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F3;
            this.screenshotMenuItem.Size = new System.Drawing.Size(315, 22);
            this.screenshotMenuItem.Text = "Screens&hot";
            this.screenshotMenuItem.Click += new System.EventHandler(this.screenshotMenuItem_Click);
            // 
            // toolStripSeparator15
            // 
            this.toolStripSeparator15.Name = "toolStripSeparator15";
            this.toolStripSeparator15.Size = new System.Drawing.Size(312, 6);
            // 
            // pauseMenuItem
            // 
            this.pauseMenuItem.Name = "pauseMenuItem";
            this.pauseMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F9;
            this.pauseMenuItem.Size = new System.Drawing.Size(315, 22);
            this.pauseMenuItem.Text = "&Pause";
            this.pauseMenuItem.Click += new System.EventHandler(this.pauseMenuItem_Click);
            // 
            // advanceFrameMenuItem
            // 
            this.advanceFrameMenuItem.Name = "advanceFrameMenuItem";
            this.advanceFrameMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F10;
            this.advanceFrameMenuItem.Size = new System.Drawing.Size(315, 22);
            this.advanceFrameMenuItem.Text = "&Advance by a Single Frame";
            this.advanceFrameMenuItem.Click += new System.EventHandler(this.advanceFrameMenuItem_Click);
            // 
            // resetMenuItem
            // 
            this.resetMenuItem.Name = "resetMenuItem";
            this.resetMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F12;
            this.resetMenuItem.Size = new System.Drawing.Size(315, 22);
            this.resetMenuItem.Text = "&Reset";
            this.resetMenuItem.Click += new System.EventHandler(this.resetMenuItem_Click);
            // 
            // displayMenuItem
            // 
            this.displayMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fullScreenMenuItem,
            this.toolStripSeparator5,
            this.VoidAreaMenuItem,
            this.toolStripSeparator10,
            this.smoothResizingMenuItem,
            this.preserveRatioMenuItem,
            this.autoCropMenuItem,
            this.ScaleMenuItem1,
            this.toolStripSeparator6,
            this.snapWindowMenuItem,
            this.toolStripSeparator16,
            this.scalingModeMenuItem});
            this.displayMenuItem.Name = "displayMenuItem";
            this.displayMenuItem.Size = new System.Drawing.Size(57, 20);
            this.displayMenuItem.Text = "&Display";
            // 
            // fullScreenMenuItem
            // 
            this.fullScreenMenuItem.Font = new System.Drawing.Font("Arial", 7.5F, System.Drawing.FontStyle.Bold);
            this.fullScreenMenuItem.Name = "fullScreenMenuItem";
            this.fullScreenMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F4;
            this.fullScreenMenuItem.Size = new System.Drawing.Size(240, 22);
            this.fullScreenMenuItem.Text = "&Full Screen";
            this.fullScreenMenuItem.Click += new System.EventHandler(this.fullScreenMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(237, 6);
            // 
            // VoidAreaMenuItem
            // 
            this.VoidAreaMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DrawBorderMenuItem,
            this.toolStripSeparator11,
            this.Pattern4DOMenuItem,
            this.PatternBumpsMenuItem,
            this.PatternMetalMenuItem,
            this.PatternNoneMenuItem});
            this.VoidAreaMenuItem.Name = "VoidAreaMenuItem";
            this.VoidAreaMenuItem.Size = new System.Drawing.Size(240, 22);
            this.VoidAreaMenuItem.Text = "Blank (Void) Area";
            // 
            // DrawBorderMenuItem
            // 
            this.DrawBorderMenuItem.Font = new System.Drawing.Font("Arial", 7.5F, System.Drawing.FontStyle.Bold);
            this.DrawBorderMenuItem.Name = "DrawBorderMenuItem";
            this.DrawBorderMenuItem.Size = new System.Drawing.Size(160, 22);
            this.DrawBorderMenuItem.Text = "Draw Gray Border";
            this.DrawBorderMenuItem.Click += new System.EventHandler(this.DrawBorderMenuItem_Click);
            // 
            // toolStripSeparator11
            // 
            this.toolStripSeparator11.Name = "toolStripSeparator11";
            this.toolStripSeparator11.Size = new System.Drawing.Size(157, 6);
            // 
            // Pattern4DOMenuItem
            // 
            this.Pattern4DOMenuItem.Image = global::FourDO.Properties.Images.VoidImage4DO;
            this.Pattern4DOMenuItem.Name = "Pattern4DOMenuItem";
            this.Pattern4DOMenuItem.Size = new System.Drawing.Size(160, 22);
            this.Pattern4DOMenuItem.Text = "Pattern : 4DO";
            this.Pattern4DOMenuItem.Click += new System.EventHandler(this.Pattern4DOMenuItem_Click);
            // 
            // PatternBumpsMenuItem
            // 
            this.PatternBumpsMenuItem.Image = global::FourDO.Properties.Images.VoidImageBumps;
            this.PatternBumpsMenuItem.Name = "PatternBumpsMenuItem";
            this.PatternBumpsMenuItem.Size = new System.Drawing.Size(160, 22);
            this.PatternBumpsMenuItem.Text = "Pattern : Bumps";
            this.PatternBumpsMenuItem.Click += new System.EventHandler(this.PatternBumpsMenuItem_Click);
            // 
            // PatternMetalMenuItem
            // 
            this.PatternMetalMenuItem.Image = global::FourDO.Properties.Images.VoidImageMetal;
            this.PatternMetalMenuItem.Name = "PatternMetalMenuItem";
            this.PatternMetalMenuItem.Size = new System.Drawing.Size(160, 22);
            this.PatternMetalMenuItem.Text = "Pattern : Metal";
            this.PatternMetalMenuItem.Click += new System.EventHandler(this.PatternMetalMenuItem_Click);
            // 
            // PatternNoneMenuItem
            // 
            this.PatternNoneMenuItem.Image = global::FourDO.Properties.Images.VoidImageNone;
            this.PatternNoneMenuItem.Name = "PatternNoneMenuItem";
            this.PatternNoneMenuItem.Size = new System.Drawing.Size(160, 22);
            this.PatternNoneMenuItem.Text = "No Pattern";
            this.PatternNoneMenuItem.Click += new System.EventHandler(this.PatternNoneMenuItem_Click);
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            this.toolStripSeparator10.Size = new System.Drawing.Size(237, 6);
            // 
            // smoothResizingMenuItem
            // 
            this.smoothResizingMenuItem.Checked = true;
            this.smoothResizingMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.smoothResizingMenuItem.Font = new System.Drawing.Font("Arial", 7.5F, System.Drawing.FontStyle.Bold);
            this.smoothResizingMenuItem.Name = "smoothResizingMenuItem";
            this.smoothResizingMenuItem.Size = new System.Drawing.Size(240, 22);
            this.smoothResizingMenuItem.Text = "&Smooth Image Resizing";
            this.smoothResizingMenuItem.Click += new System.EventHandler(this.smoothResizingMenuItem_Click);
            // 
            // preserveRatioMenuItem
            // 
            this.preserveRatioMenuItem.Checked = true;
            this.preserveRatioMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.preserveRatioMenuItem.Font = new System.Drawing.Font("Arial", 7.5F, System.Drawing.FontStyle.Bold);
            this.preserveRatioMenuItem.Name = "preserveRatioMenuItem";
            this.preserveRatioMenuItem.Size = new System.Drawing.Size(240, 22);
            this.preserveRatioMenuItem.Text = "Preserve Aspect &Ratio";
            this.preserveRatioMenuItem.Click += new System.EventHandler(this.preserveRatioMenuItem_Click);
            // 
            // autoCropMenuItem
            // 
            this.autoCropMenuItem.Checked = true;
            this.autoCropMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.autoCropMenuItem.Font = new System.Drawing.Font("Arial", 7.5F, System.Drawing.FontStyle.Bold);
            this.autoCropMenuItem.Name = "autoCropMenuItem";
            this.autoCropMenuItem.Size = new System.Drawing.Size(240, 22);
            this.autoCropMenuItem.Text = "Auto-&Crop Blank Borders";
            this.autoCropMenuItem.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
            this.autoCropMenuItem.Click += new System.EventHandler(this.autoCropMenuItem_Click);
            // 
            // ScaleMenuItem1
            // 
            this.ScaleMenuItem1.Checked = true;
            this.ScaleMenuItem1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ScaleMenuItem1.Font = new System.Drawing.Font("Arial", 7.5F, System.Drawing.FontStyle.Bold);
            this.ScaleMenuItem1.Name = "ScaleMenuItem1";
            this.ScaleMenuItem1.Size = new System.Drawing.Size(240, 22);
            this.ScaleMenuItem1.Text = "Scale Mode";
            this.ScaleMenuItem1.Click += new System.EventHandler(this.ScaleMenuItem1_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(237, 6);
            // 
            // snapWindowMenuItem
            // 
            this.snapWindowMenuItem.Checked = true;
            this.snapWindowMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.snapWindowMenuItem.Font = new System.Drawing.Font("Arial", 7.5F, System.Drawing.FontStyle.Bold);
            this.snapWindowMenuItem.Name = "snapWindowMenuItem";
            this.snapWindowMenuItem.Size = new System.Drawing.Size(240, 22);
            this.snapWindowMenuItem.Text = "Snap &Window to Clean Increments";
            this.snapWindowMenuItem.Click += new System.EventHandler(this.snapWindowMenuItem_Click);
            // 
            // toolStripSeparator16
            // 
            this.toolStripSeparator16.Name = "toolStripSeparator16";
            this.toolStripSeparator16.Size = new System.Drawing.Size(237, 6);
            // 
            // scalingModeMenuItem
            // 
            this.scalingModeMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.scalingModeNoneMenuItem,
            this.scalingModeDoubleResMenuItem,
            this.scalingModeHq2xMenuItem,
            this.scalingModeHq3xMenuItem,
            this.scalingModeHq4xMenuItem});
            this.scalingModeMenuItem.Name = "scalingModeMenuItem";
            this.scalingModeMenuItem.Size = new System.Drawing.Size(240, 22);
            this.scalingModeMenuItem.Text = "Sca&ling Mode";
            // 
            // scalingModeNoneMenuItem
            // 
            this.scalingModeNoneMenuItem.Name = "scalingModeNoneMenuItem";
            this.scalingModeNoneMenuItem.Size = new System.Drawing.Size(228, 22);
            this.scalingModeNoneMenuItem.Text = "None";
            this.scalingModeNoneMenuItem.Click += new System.EventHandler(this.scalingModeNoneMenuItem_Click);
            // 
            // scalingModeDoubleResMenuItem
            // 
            this.scalingModeDoubleResMenuItem.Name = "scalingModeDoubleResMenuItem";
            this.scalingModeDoubleResMenuItem.Size = new System.Drawing.Size(228, 22);
            this.scalingModeDoubleResMenuItem.Text = "Double Resolution Rendering";
            this.scalingModeDoubleResMenuItem.Click += new System.EventHandler(this.scalingModeDoubleResMenuItem_Click);
            // 
            // scalingModeHq2xMenuItem
            // 
            this.scalingModeHq2xMenuItem.Name = "scalingModeHq2xMenuItem";
            this.scalingModeHq2xMenuItem.Size = new System.Drawing.Size(228, 22);
            this.scalingModeHq2xMenuItem.Text = "HQ2X";
            this.scalingModeHq2xMenuItem.Click += new System.EventHandler(this.scalingModeHq2xMenuItem_Click);
            // 
            // scalingModeHq3xMenuItem
            // 
            this.scalingModeHq3xMenuItem.Name = "scalingModeHq3xMenuItem";
            this.scalingModeHq3xMenuItem.Size = new System.Drawing.Size(228, 22);
            this.scalingModeHq3xMenuItem.Text = "HQ3X";
            this.scalingModeHq3xMenuItem.Click += new System.EventHandler(this.scalingModeHq3xMenuItem_Click);
            // 
            // scalingModeHq4xMenuItem
            // 
            this.scalingModeHq4xMenuItem.Name = "scalingModeHq4xMenuItem";
            this.scalingModeHq4xMenuItem.Size = new System.Drawing.Size(228, 22);
            this.scalingModeHq4xMenuItem.Text = "HQ4X";
            this.scalingModeHq4xMenuItem.Click += new System.EventHandler(this.scalingModeHq4xMenuItem_Click);
            // 
            // audioMenuItem
            // 
            this.audioMenuItem.Name = "audioMenuItem";
            this.audioMenuItem.Size = new System.Drawing.Size(51, 20);
            this.audioMenuItem.Text = "&Audio";
            // 
            // optionsMenuItem
            // 
            this.optionsMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsMenuItem,
            this.toolStripSeparator9,
            this.configureInputMenuItem,
            this.toolStripSeparator13,
            this.languageMenuItem});
            this.optionsMenuItem.Name = "optionsMenuItem";
            this.optionsMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionsMenuItem.Text = "&Options";
            // 
            // settingsMenuItem
            // 
            this.settingsMenuItem.Name = "settingsMenuItem";
            this.settingsMenuItem.Size = new System.Drawing.Size(167, 22);
            this.settingsMenuItem.Text = "4DO &Settings...";
            this.settingsMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(164, 6);
            // 
            // configureInputMenuItem
            // 
            this.configureInputMenuItem.Name = "configureInputMenuItem";
            this.configureInputMenuItem.Size = new System.Drawing.Size(167, 22);
            this.configureInputMenuItem.Text = "Configure &Input...";
            this.configureInputMenuItem.Click += new System.EventHandler(this.configureInputMenuItem_Click);
            // 
            // toolStripSeparator13
            // 
            this.toolStripSeparator13.Name = "toolStripSeparator13";
            this.toolStripSeparator13.Size = new System.Drawing.Size(164, 6);
            // 
            // languageMenuItem
            // 
            this.languageMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.languageDefaultMenuItem,
            this.toolStripSeparator14});
            this.languageMenuItem.Name = "languageMenuItem";
            this.languageMenuItem.Size = new System.Drawing.Size(167, 22);
            this.languageMenuItem.Text = "&Language";
            // 
            // languageDefaultMenuItem
            // 
            this.languageDefaultMenuItem.Name = "languageDefaultMenuItem";
            this.languageDefaultMenuItem.Size = new System.Drawing.Size(112, 22);
            this.languageDefaultMenuItem.Text = "Default";
            this.languageDefaultMenuItem.Click += new System.EventHandler(this.languageDefaultMenuItem_Click);
            // 
            // toolStripSeparator14
            // 
            this.toolStripSeparator14.Name = "toolStripSeparator14";
            this.toolStripSeparator14.Size = new System.Drawing.Size(109, 6);
            // 
            // toolsMenuItem
            // 
            this.toolsMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DiscBrowserMenuItem});
            this.toolsMenuItem.Name = "toolsMenuItem";
            this.toolsMenuItem.Size = new System.Drawing.Size(47, 20);
            this.toolsMenuItem.Text = "&Tools";
            // 
            // DiscBrowserMenuItem
            // 
            this.DiscBrowserMenuItem.Name = "DiscBrowserMenuItem";
            this.DiscBrowserMenuItem.Size = new System.Drawing.Size(141, 22);
            this.DiscBrowserMenuItem.Text = "&Disc Browser";
            this.DiscBrowserMenuItem.Click += new System.EventHandler(this.DiscBrowserMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gameInfoMenuItem,
            this.toolStripSeparator12,
            this.aboutMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // gameInfoMenuItem
            // 
            this.gameInfoMenuItem.Name = "gameInfoMenuItem";
            this.gameInfoMenuItem.Size = new System.Drawing.Size(180, 22);
            this.gameInfoMenuItem.Text = "Game &Information...";
            this.gameInfoMenuItem.Click += new System.EventHandler(this.gameInfoMenuItem_Click);
            // 
            // toolStripSeparator12
            // 
            this.toolStripSeparator12.Name = "toolStripSeparator12";
            this.toolStripSeparator12.Size = new System.Drawing.Size(177, 6);
            // 
            // aboutMenuItem
            // 
            this.aboutMenuItem.Name = "aboutMenuItem";
            this.aboutMenuItem.Size = new System.Drawing.Size(180, 22);
            this.aboutMenuItem.Text = "&About 4DO...";
            this.aboutMenuItem.Click += new System.EventHandler(this.aboutMenuItem_Click);
            // 
            // refreshFpsTimer
            // 
            this.refreshFpsTimer.Enabled = true;
            this.refreshFpsTimer.Interval = 300;
            this.refreshFpsTimer.Tick += new System.EventHandler(this.RefreshFpsTimer_Tick);
            // 
            // hideMenuTimer
            // 
            this.hideMenuTimer.Interval = 2000;
            this.hideMenuTimer.Tick += new System.EventHandler(this.hideMenuTimer_Tick);
            // 
            // checkInputTimer
            // 
            this.checkInputTimer.Enabled = true;
            this.checkInputTimer.Interval = 75;
            this.checkInputTimer.Tick += new System.EventHandler(this.checkInputTimer_Tick);
            // 
            // sizeBox
            // 
            this.sizeBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.sizeBox.BaseHeight = 0;
            this.sizeBox.BaseWidth = 0;
            this.sizeBox.Location = new System.Drawing.Point(494, 557);
            this.sizeBox.Name = "sizeBox";
            this.sizeBox.Size = new System.Drawing.Size(228, 24);
            this.sizeBox.TabIndex = 4;
            this.sizeBox.Visible = false;
            // 
            // RomNagBox
            // 
            this.RomNagBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RomNagBox.BackColor = System.Drawing.SystemColors.Info;
            this.RomNagBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.RomNagBox.HideText = "(Hide)";
            this.RomNagBox.LinkText = "Choose BIOS Rom";
            this.RomNagBox.Location = new System.Drawing.Point(8, 545);
            this.RomNagBox.MessageText = "No BIOS rom selected.";
            this.RomNagBox.Name = "RomNagBox";
            this.RomNagBox.Size = new System.Drawing.Size(730, 28);
            this.RomNagBox.TabIndex = 1;
            this.RomNagBox.Visible = false;
            this.RomNagBox.CloseClicked += new System.EventHandler(this.RomNagBox_CloseClicked);
            this.RomNagBox.LinkClicked += new System.EventHandler(this.RomNagBox_LinkClicked);
            // 
            // gameCanvas
            // 
            this.gameCanvas.AutoCrop = false;
            this.gameCanvas.BackColor = System.Drawing.Color.Black;
            this.gameCanvas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gameCanvas.ImageSmoothing = true;
            this.gameCanvas.IsConsoleStopped = true;
            this.gameCanvas.IsInResizeMode = false;
            this.gameCanvas.isScale = false;
            this.gameCanvas.Location = new System.Drawing.Point(0, 24);
            this.gameCanvas.Name = "gameCanvas";
            this.gameCanvas.PreserveAspectRatio = true;
            this.gameCanvas.RenderHighResolution = false;
            this.gameCanvas.ScalingAlgorithm = FourDO.Emulation.FreeDO.ScalingAlgorithm.None;
            this.gameCanvas.Size = new System.Drawing.Size(744, 557);
            this.gameCanvas.TabIndex = 3;
            this.gameCanvas.VoidAreaBorder = false;
            this.gameCanvas.VoidAreaPattern = FourDO.UI.VoidAreaPattern.None;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(744, 603);
            this.Controls.Add(this.sizeBox);
            this.Controls.Add(this.RomNagBox);
            this.Controls.Add(this.gameCanvas);
            this.Controls.Add(this.MainStatusStrip);
            this.Controls.Add(this.MainMenuBar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "Main";
            this.Text = "4DO";
            this.Activated += new System.EventHandler(this.Main_Activated);
            this.Deactivate += new System.EventHandler(this.Main_Deactivate);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Main_FormClosed);
            this.Load += new System.EventHandler(this.Main_Load);
            this.ResizeBegin += new System.EventHandler(this.Main_ResizeBegin);
            this.ResizeEnd += new System.EventHandler(this.Main_ResizeEnd);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Main_KeyDown);
            this.Resize += new System.EventHandler(this.Main_Resize);
            this.MainStatusStrip.ResumeLayout(false);
            this.MainStatusStrip.PerformLayout();
            this.MainMenuBar.ResumeLayout(false);
            this.MainMenuBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip MainStatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel VersionStripItem;
        private NagBox RomNagBox;
        private System.Windows.Forms.MenuStrip MainMenuBar;
        private System.Windows.Forms.ToolStripMenuItem fileMenuItem;
        private System.Windows.Forms.ToolStripMenuItem chooseBiosRom1MenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitMenuItem;
        private GameCanvas gameCanvas;
        private System.Windows.Forms.ToolStripStatusLabel FPSStripItem;
        private System.Windows.Forms.Timer refreshFpsTimer;
        private System.Windows.Forms.ToolStripMenuItem openCDImageMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadLastGameMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem optionsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsMenuItem;
        private SizeBox sizeBox;
        private System.Windows.Forms.ToolStripMenuItem displayMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fullScreenMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem snapWindowMenuItem;
        private System.Windows.Forms.ToolStripMenuItem preserveRatioMenuItem;
        private System.Windows.Forms.ToolStripMenuItem smoothResizingMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.Timer hideMenuTimer;
        private System.Windows.Forms.ToolStripMenuItem consoleMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resetMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pauseMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveStateMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadStateMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadLastSaveMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripMenuItem saveStateSlotMenuItem;
        private System.Windows.Forms.ToolStripMenuItem previousSlotMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nextSlotMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem advanceFrameMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeGameMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ToolStripMenuItem configureInputMenuItem;
		private System.Windows.Forms.ToolStripMenuItem VoidAreaMenuItem;
		private System.Windows.Forms.ToolStripMenuItem DrawBorderMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator11;
		private System.Windows.Forms.ToolStripMenuItem Pattern4DOMenuItem;
		private System.Windows.Forms.ToolStripMenuItem PatternBumpsMenuItem;
		private System.Windows.Forms.ToolStripMenuItem PatternMetalMenuItem;
		private System.Windows.Forms.ToolStripMenuItem PatternNoneMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
		private System.Windows.Forms.ToolStripMenuItem gameInfoMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator12;
		private System.Windows.Forms.ToolStripMenuItem audioMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator13;
		private System.Windows.Forms.ToolStripMenuItem languageMenuItem;
		private System.Windows.Forms.ToolStripMenuItem languageDefaultMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator14;
        private System.Windows.Forms.ToolStripMenuItem chooseBiosRom2MenuItem;
		private System.Windows.Forms.ToolStripMenuItem screenshotMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator15;
		private System.Windows.Forms.ToolStripMenuItem autoCropMenuItem;
		private System.Windows.Forms.ToolStripMenuItem scalingModeMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel HealthLabelStripItem;
		private System.Windows.Forms.ToolStripStatusLabel HealthStripItem;
		private System.Windows.Forms.ToolStripMenuItem scalingModeNoneMenuItem;
		private System.Windows.Forms.ToolStripMenuItem scalingModeDoubleResMenuItem;
		private System.Windows.Forms.ToolStripMenuItem scalingModeHq2xMenuItem;
		private System.Windows.Forms.ToolStripMenuItem scalingModeHq3xMenuItem;
		private System.Windows.Forms.ToolStripMenuItem scalingModeHq4xMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator16;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
		private System.Windows.Forms.Timer checkInputTimer;
		private System.Windows.Forms.ToolStripMenuItem toolsMenuItem;
		private System.Windows.Forms.ToolStripMenuItem DiscBrowserMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ScaleMenuItem1;

    }
}

