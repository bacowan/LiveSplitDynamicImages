namespace LiveSplitDynamicImages
{
    partial class Settings
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
            this.GoldSettings = new LiveSplitDynamicImages.SingleTransitionSettings();
            this.DarkGreenSettings = new LiveSplitDynamicImages.SingleTransitionSettings();
            this.LightGreenSettings = new LiveSplitDynamicImages.SingleTransitionSettings();
            this.LightRedSettings = new LiveSplitDynamicImages.SingleTransitionSettings();
            this.DarkRedSettings = new LiveSplitDynamicImages.SingleTransitionSettings();
            this.MiscSettings = new LiveSplitDynamicImages.MiscTransitionSettings();
            this.SuspendLayout();
            // 
            // GoldSettings
            // 
            this.GoldSettings.Location = new System.Drawing.Point(3, 563);
            this.GoldSettings.Name = "GoldSettings";
            this.GoldSettings.pipe = null;
            this.GoldSettings.Size = new System.Drawing.Size(441, 134);
            this.GoldSettings.TabIndex = 4;
            this.GoldSettings.Title = "Gold";
            // 
            // DarkGreenSettings
            // 
            this.DarkGreenSettings.Location = new System.Drawing.Point(3, 423);
            this.DarkGreenSettings.Name = "DarkGreenSettings";
            this.DarkGreenSettings.pipe = null;
            this.DarkGreenSettings.Size = new System.Drawing.Size(441, 134);
            this.DarkGreenSettings.TabIndex = 3;
            this.DarkGreenSettings.Title = "Dark Green";
            // 
            // LightGreenSettings
            // 
            this.LightGreenSettings.Location = new System.Drawing.Point(3, 283);
            this.LightGreenSettings.Name = "LightGreenSettings";
            this.LightGreenSettings.pipe = null;
            this.LightGreenSettings.Size = new System.Drawing.Size(441, 134);
            this.LightGreenSettings.TabIndex = 2;
            this.LightGreenSettings.Title = "Light Green";
            // 
            // LightRedSettings
            // 
            this.LightRedSettings.Location = new System.Drawing.Point(3, 143);
            this.LightRedSettings.Name = "LightRedSettings";
            this.LightRedSettings.pipe = null;
            this.LightRedSettings.Size = new System.Drawing.Size(441, 134);
            this.LightRedSettings.TabIndex = 1;
            this.LightRedSettings.Title = "Light Red";
            // 
            // DarkRedSettings
            // 
            this.DarkRedSettings.Location = new System.Drawing.Point(3, 3);
            this.DarkRedSettings.Name = "DarkRedSettings";
            this.DarkRedSettings.pipe = null;
            this.DarkRedSettings.Size = new System.Drawing.Size(441, 134);
            this.DarkRedSettings.TabIndex = 0;
            this.DarkRedSettings.Title = "Dark Red";
            // 
            // MiscSettings
            // 
            this.MiscSettings.Location = new System.Drawing.Point(7, 701);
            this.MiscSettings.Name = "MiscSettings";
            this.MiscSettings.Size = new System.Drawing.Size(439, 131);
            this.MiscSettings.TabIndex = 5;
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.MiscSettings);
            this.Controls.Add(this.GoldSettings);
            this.Controls.Add(this.DarkGreenSettings);
            this.Controls.Add(this.LightGreenSettings);
            this.Controls.Add(this.LightRedSettings);
            this.Controls.Add(this.DarkRedSettings);
            this.Name = "Settings";
            this.Size = new System.Drawing.Size(446, 835);
            this.ResumeLayout(false);

        }

        #endregion

        private SingleTransitionSettings DarkRedSettings;
        private SingleTransitionSettings LightRedSettings;
        private SingleTransitionSettings LightGreenSettings;
        private SingleTransitionSettings DarkGreenSettings;
        private SingleTransitionSettings GoldSettings;
        private MiscTransitionSettings MiscSettings;
    }
}
