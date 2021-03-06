namespace FourDO.UI
{
    partial class GameCanvas
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.HideMouseTimer = new System.Windows.Forms.Timer(this.components);
            this.pnlBlack = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // HideMouseTimer
            // 
            this.HideMouseTimer.Interval = 1000;
            this.HideMouseTimer.Tick += new System.EventHandler(this.HideMouseTimer_Tick);
            // 
            // pnlBlack
            // 
            this.pnlBlack.Location = new System.Drawing.Point(25, 156);
            this.pnlBlack.Name = "pnlBlack";
            this.pnlBlack.Size = new System.Drawing.Size(98, 58);
            this.pnlBlack.TabIndex = 1;
            this.pnlBlack.Visible = false;
            // 
            // GameCanvas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImage = global::FourDO.Properties.Images.VoidImageBumps;
            this.Controls.Add(this.pnlBlack);
            this.DoubleBuffered = true;
            this.Name = "GameCanvas";
            this.Size = new System.Drawing.Size(286, 238);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.GameCanvas_Paint);
            this.MouseEnter += new System.EventHandler(this.GameCanvas_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.GameCanvas_MouseLeave);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.GameCanvas_MouseMove);
            this.Resize += new System.EventHandler(this.GameCanvas_Resize);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer HideMouseTimer;
		private System.Windows.Forms.Panel pnlBlack;
    }
}
