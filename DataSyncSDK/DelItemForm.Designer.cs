namespace DataSync
{
    partial class DelItemForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DelItemForm));
            this.DelCheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.CnclButton = new System.Windows.Forms.Button();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // DelCheckedListBox
            // 
            resources.ApplyResources(this.DelCheckedListBox, "DelCheckedListBox");
            this.DelCheckedListBox.CheckOnClick = true;
            this.DelCheckedListBox.FormattingEnabled = true;
            this.DelCheckedListBox.Name = "DelCheckedListBox";
            // 
            // CnclButton
            // 
            resources.ApplyResources(this.CnclButton, "CnclButton");
            this.CnclButton.Name = "CnclButton";
            this.CnclButton.UseVisualStyleBackColor = true;
            this.CnclButton.Click += new System.EventHandler(this.CnclButton_Click);
            // 
            // DeleteButton
            // 
            resources.ApplyResources(this.DeleteButton, "DeleteButton");
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.UseVisualStyleBackColor = true;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // DelItemForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.DeleteButton);
            this.Controls.Add(this.CnclButton);
            this.Controls.Add(this.DelCheckedListBox);
            this.Name = "DelItemForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckedListBox DelCheckedListBox;
        private System.Windows.Forms.Button CnclButton;
        private System.Windows.Forms.Button DeleteButton;
    }
}