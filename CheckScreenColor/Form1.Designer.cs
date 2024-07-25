namespace CheckScreenColor
{
    partial class Form1
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
            capturePanel = new Panel();
            targetPanel = new Panel();
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
            targetPanel.BorderStyle = BorderStyle.FixedSingle;
            targetPanel.Location = new Point(38, 26);
            targetPanel.Name = "targetPanel";
            targetPanel.Size = new Size(5, 5);
            targetPanel.TabIndex = 0;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(80, 61);
            Controls.Add(capturePanel);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Form1";
            ShowIcon = false;
            TopMost = true;
            TransparencyKey = Color.Lime;
            Load += Form1_Load;
            capturePanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel capturePanel;
        private Panel targetPanel;
    }
}
