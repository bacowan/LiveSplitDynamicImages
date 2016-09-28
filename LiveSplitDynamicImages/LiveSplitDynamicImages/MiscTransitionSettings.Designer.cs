namespace LiveSplitDynamicImages
{
    partial class MiscTransitionSettings
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
            this.imageBrowseAndTestRunEndNoPB = new LiveSplitDynamicImages.ImageBrowseAndTest();
            this.imageBrowseAndTestRunEndPB = new LiveSplitDynamicImages.ImageBrowseAndTest();
            this.imageBrowseAndTestNewRun = new LiveSplitDynamicImages.ImageBrowseAndTest();
            this.imageBrowseAndTestReset = new LiveSplitDynamicImages.ImageBrowseAndTest();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.imageBrowseAndTestReset);
            this.groupBox1.Controls.Add(this.imageBrowseAndTestRunEndNoPB);
            this.groupBox1.Controls.Add(this.imageBrowseAndTestRunEndPB);
            this.groupBox1.Controls.Add(this.imageBrowseAndTestNewRun);
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(437, 130);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Misc Transitions";
            // 
            // imageBrowseAndTestRunEndNoPB
            // 
            this.imageBrowseAndTestRunEndNoPB.imagePath = null;
            this.imageBrowseAndTestRunEndNoPB.label = "Run End No PB";
            this.imageBrowseAndTestRunEndNoPB.Location = new System.Drawing.Point(148, 19);
            this.imageBrowseAndTestRunEndNoPB.Name = "imageBrowseAndTestRunEndNoPB";
            this.imageBrowseAndTestRunEndNoPB.pipe = null;
            this.imageBrowseAndTestRunEndNoPB.Size = new System.Drawing.Size(94, 83);
            this.imageBrowseAndTestRunEndNoPB.TabIndex = 3;
            // 
            // imageBrowseAndTestRunEndPB
            // 
            this.imageBrowseAndTestRunEndPB.imagePath = null;
            this.imageBrowseAndTestRunEndPB.label = "Run End PB";
            this.imageBrowseAndTestRunEndPB.Location = new System.Drawing.Point(69, 19);
            this.imageBrowseAndTestRunEndPB.Name = "imageBrowseAndTestRunEndPB";
            this.imageBrowseAndTestRunEndPB.pipe = null;
            this.imageBrowseAndTestRunEndPB.Size = new System.Drawing.Size(73, 83);
            this.imageBrowseAndTestRunEndPB.TabIndex = 2;
            // 
            // imageBrowseAndTestNewRun
            // 
            this.imageBrowseAndTestNewRun.imagePath = null;
            this.imageBrowseAndTestNewRun.label = "New Run";
            this.imageBrowseAndTestNewRun.Location = new System.Drawing.Point(5, 19);
            this.imageBrowseAndTestNewRun.Name = "imageBrowseAndTestNewRun";
            this.imageBrowseAndTestNewRun.pipe = null;
            this.imageBrowseAndTestNewRun.Size = new System.Drawing.Size(58, 83);
            this.imageBrowseAndTestNewRun.TabIndex = 1;
            // 
            // imageBrowseAndTestReset
            // 
            this.imageBrowseAndTestReset.imagePath = null;
            this.imageBrowseAndTestReset.label = "Reset";
            this.imageBrowseAndTestReset.Location = new System.Drawing.Point(248, 19);
            this.imageBrowseAndTestReset.Name = "imageBrowseAndTestReset";
            this.imageBrowseAndTestReset.pipe = null;
            this.imageBrowseAndTestReset.Size = new System.Drawing.Size(38, 83);
            this.imageBrowseAndTestReset.TabIndex = 4;
            // 
            // MiscTransitionSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "MiscTransitionSettings";
            this.Size = new System.Drawing.Size(439, 131);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private ImageBrowseAndTest imageBrowseAndTestRunEndNoPB;
        private ImageBrowseAndTest imageBrowseAndTestRunEndPB;
        private ImageBrowseAndTest imageBrowseAndTestNewRun;
        private ImageBrowseAndTest imageBrowseAndTestReset;
    }
}
