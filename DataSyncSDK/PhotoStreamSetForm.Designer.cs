namespace DataSyncSDK
{
    partial class PhotoStreamSetForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PhotoStreamSetForm));
            this.psDefDirLabel = new System.Windows.Forms.Label();
            this.photoStreamDefDirSetButton = new System.Windows.Forms.Button();
            this.PhotoStreamDefDirTextBox = new System.Windows.Forms.TextBox();
            this.selectButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // psDefDirLabel
            // 
            resources.ApplyResources(this.psDefDirLabel, "psDefDirLabel");
            this.psDefDirLabel.Name = "psDefDirLabel";
            // 
            // photoStreamDefDirSetButton
            // 
            resources.ApplyResources(this.photoStreamDefDirSetButton, "photoStreamDefDirSetButton");
            this.photoStreamDefDirSetButton.Name = "photoStreamDefDirSetButton";
            this.photoStreamDefDirSetButton.UseVisualStyleBackColor = true;
            this.photoStreamDefDirSetButton.Click += new System.EventHandler(this.photoStreamDefDirSetButton_Click);
            // 
            // PhotoStreamDefDirTextBox
            // 
            resources.ApplyResources(this.PhotoStreamDefDirTextBox, "PhotoStreamDefDirTextBox");
            this.PhotoStreamDefDirTextBox.Name = "PhotoStreamDefDirTextBox";
            // 
            // selectButton
            // 
            resources.ApplyResources(this.selectButton, "selectButton");
            this.selectButton.Name = "selectButton";
            this.selectButton.UseVisualStyleBackColor = true;
            this.selectButton.Click += new System.EventHandler(this.selectButton_Click);
            // 
            // PhotoStreamSetForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.selectButton);
            this.Controls.Add(this.PhotoStreamDefDirTextBox);
            this.Controls.Add(this.photoStreamDefDirSetButton);
            this.Controls.Add(this.psDefDirLabel);
            this.Name = "PhotoStreamSetForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label psDefDirLabel;
        private System.Windows.Forms.Button photoStreamDefDirSetButton;
        private System.Windows.Forms.TextBox PhotoStreamDefDirTextBox;
        private System.Windows.Forms.Button selectButton;
    }
}