namespace LiveSplitDynamicImages
{
    partial class SingleTransitionSettings
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.imageBrowseAndTestGold = new LiveSplitDynamicImages.ImageBrowseAndTest();
            this.imageBrowseAndTestDarkGreen = new LiveSplitDynamicImages.ImageBrowseAndTest();
            this.imageBrowseAndTestLightGreen = new LiveSplitDynamicImages.ImageBrowseAndTest();
            this.imageBrowseAndTestLightRed = new LiveSplitDynamicImages.ImageBrowseAndTest();
            this.imageBrowseAndTestDarkRed = new LiveSplitDynamicImages.ImageBrowseAndTest();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.imageBrowseAndTestNone = new LiveSplitDynamicImages.ImageBrowseAndTest();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.imageBrowseAndTestNone);
            this.groupBox1.Controls.Add(this.imageBrowseAndTestGold);
            this.groupBox1.Controls.Add(this.imageBrowseAndTestDarkGreen);
            this.groupBox1.Controls.Add(this.imageBrowseAndTestLightGreen);
            this.groupBox1.Controls.Add(this.imageBrowseAndTestLightRed);
            this.groupBox1.Controls.Add(this.imageBrowseAndTestDarkRed);
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(437, 130);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Transition Colour";
            // 
            // imageBrowseAndTestGold
            // 
            this.imageBrowseAndTestGold.imagePath = null;
            this.imageBrowseAndTestGold.label = "Gold";
            this.imageBrowseAndTestGold.Location = new System.Drawing.Point(285, 42);
            this.imageBrowseAndTestGold.Name = "imageBrowseAndTestGold";
            this.imageBrowseAndTestGold.pipe = null;
            this.imageBrowseAndTestGold.Size = new System.Drawing.Size(38, 83);
            this.imageBrowseAndTestGold.TabIndex = 5;
            // 
            // imageBrowseAndTestDarkGreen
            // 
            this.imageBrowseAndTestDarkGreen.imagePath = null;
            this.imageBrowseAndTestDarkGreen.label = "Dark Green";
            this.imageBrowseAndTestDarkGreen.Location = new System.Drawing.Point(208, 42);
            this.imageBrowseAndTestDarkGreen.Name = "imageBrowseAndTestDarkGreen";
            this.imageBrowseAndTestDarkGreen.pipe = null;
            this.imageBrowseAndTestDarkGreen.Size = new System.Drawing.Size(71, 83);
            this.imageBrowseAndTestDarkGreen.TabIndex = 4;
            // 
            // imageBrowseAndTestLightGreen
            // 
            this.imageBrowseAndTestLightGreen.imagePath = null;
            this.imageBrowseAndTestLightGreen.label = "Light Green";
            this.imageBrowseAndTestLightGreen.Location = new System.Drawing.Point(135, 42);
            this.imageBrowseAndTestLightGreen.Name = "imageBrowseAndTestLightGreen";
            this.imageBrowseAndTestLightGreen.pipe = null;
            this.imageBrowseAndTestLightGreen.Size = new System.Drawing.Size(67, 83);
            this.imageBrowseAndTestLightGreen.TabIndex = 3;
            // 
            // imageBrowseAndTestLightRed
            // 
            this.imageBrowseAndTestLightRed.imagePath = null;
            this.imageBrowseAndTestLightRed.label = "Light Red";
            this.imageBrowseAndTestLightRed.Location = new System.Drawing.Point(69, 42);
            this.imageBrowseAndTestLightRed.Name = "imageBrowseAndTestLightRed";
            this.imageBrowseAndTestLightRed.pipe = null;
            this.imageBrowseAndTestLightRed.Size = new System.Drawing.Size(54, 83);
            this.imageBrowseAndTestLightRed.TabIndex = 2;
            // 
            // imageBrowseAndTestDarkRed
            // 
            this.imageBrowseAndTestDarkRed.imagePath = null;
            this.imageBrowseAndTestDarkRed.label = "Dark Red";
            this.imageBrowseAndTestDarkRed.Location = new System.Drawing.Point(5, 42);
            this.imageBrowseAndTestDarkRed.Name = "imageBrowseAndTestDarkRed";
            this.imageBrowseAndTestDarkRed.pipe = null;
            this.imageBrowseAndTestDarkRed.Size = new System.Drawing.Size(58, 83);
            this.imageBrowseAndTestDarkRed.TabIndex = 1;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(6, 19);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(168, 17);
            this.checkBox1.TabIndex = 0;
            this.checkBox1.Text = "Same Image for All Transitions";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // imageBrowseAndTestNone
            // 
            this.imageBrowseAndTestNone.imagePath = null;
            this.imageBrowseAndTestNone.label = "None";
            this.imageBrowseAndTestNone.Location = new System.Drawing.Point(329, 42);
            this.imageBrowseAndTestNone.Name = "imageBrowseAndTestNone";
            this.imageBrowseAndTestNone.pipe = null;
            this.imageBrowseAndTestNone.Size = new System.Drawing.Size(38, 83);
            this.imageBrowseAndTestNone.TabIndex = 6;
            // 
            // SingleTransitionSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "SingleTransitionSettings";
            this.Size = new System.Drawing.Size(441, 134);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox checkBox1;
        private ImageBrowseAndTest imageBrowseAndTestGold;
        private ImageBrowseAndTest imageBrowseAndTestDarkGreen;
        private ImageBrowseAndTest imageBrowseAndTestLightGreen;
        private ImageBrowseAndTest imageBrowseAndTestLightRed;
        private ImageBrowseAndTest imageBrowseAndTestDarkRed;
        private ImageBrowseAndTest imageBrowseAndTestNone;
    }
}
