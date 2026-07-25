namespace CheckScreenColor
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            capturePanel = new Panel();
            targetPanel = new Panel();
            pollTimer = new System.Windows.Forms.Timer(components);
            capturePanel.SuspendLayout();
            SuspendLayout();
            //
            // capturePanel
            //
            capturePanel.BackColor = Color.Lime;
            capturePanel.Controls.Add(targetPanel);
            capturePanel.Dock = DockStyle.Fill;
            capturePanel.Location = new Point(0, 0);
            capturePanel.Name = "capturePanel";
            capturePanel.Size = new Size(80, 61);
            capturePanel.TabIndex = 0;
            //
            // targetPanel
            //
            targetPanel.BackColor = Color.Lime;
            targetPanel.BorderStyle = BorderStyle.FixedSingle;
            targetPanel.Location = new Point(36, 27);
            targetPanel.Name = "targetPanel";
            targetPanel.Size = new Size(7, 7);
            targetPanel.TabIndex = 0;
            //
            // pollTimer
            //
            pollTimer.Interval = PollIntervalMs;
            pollTimer.Tick += PollTimer_Tick;
            //
            // MainForm
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(80, 61);
            Controls.Add(capturePanel);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "MainForm";
            ShowIcon = false;
            Text = "CheckScreenColor";
            TopMost = true;
            TransparencyKey = Color.Lime;
            Load += MainForm_Load;
            capturePanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel capturePanel;
        private Panel targetPanel;
        private System.Windows.Forms.Timer pollTimer;
    }
}
