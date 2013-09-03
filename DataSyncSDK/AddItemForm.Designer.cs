namespace DataSyncSDK
{
    partial class AddItemForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddItemForm));
            this.ItemNameLabel = new System.Windows.Forms.Label();
            this.ItemImagelabel = new System.Windows.Forms.Label();
            this.ExeLabel = new System.Windows.Forms.Label();
            this.UrlLabel = new System.Windows.Forms.Label();
            this.CloseButton = new System.Windows.Forms.Button();
            this.OkButton = new System.Windows.Forms.Button();
            this.ItemNameTextBox = new System.Windows.Forms.TextBox();
            this.IconTextBox = new System.Windows.Forms.TextBox();
            this.ExeTextBox = new System.Windows.Forms.TextBox();
            this.UrlTextBox = new System.Windows.Forms.TextBox();
            this.Notelabel = new System.Windows.Forms.Label();
            this.ImageButton = new System.Windows.Forms.Button();
            this.ExeButton = new System.Windows.Forms.Button();
            this.AddItempenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // ItemNameLabel
            // 
            resources.ApplyResources(this.ItemNameLabel, "ItemNameLabel");
            this.ItemNameLabel.Name = "ItemNameLabel";
            // 
            // ItemImagelabel
            // 
            resources.ApplyResources(this.ItemImagelabel, "ItemImagelabel");
            this.ItemImagelabel.Name = "ItemImagelabel";
            // 
            // ExeLabel
            // 
            resources.ApplyResources(this.ExeLabel, "ExeLabel");
            this.ExeLabel.Name = "ExeLabel";
            // 
            // UrlLabel
            // 
            resources.ApplyResources(this.UrlLabel, "UrlLabel");
            this.UrlLabel.Name = "UrlLabel";
            // 
            // CloseButton
            // 
            resources.ApplyResources(this.CloseButton, "CloseButton");
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // OkButton
            // 
            resources.ApplyResources(this.OkButton, "OkButton");
            this.OkButton.Name = "OkButton";
            this.OkButton.UseVisualStyleBackColor = true;
            this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // ItemNameTextBox
            // 
            resources.ApplyResources(this.ItemNameTextBox, "ItemNameTextBox");
            this.ItemNameTextBox.Name = "ItemNameTextBox";
            // 
            // IconTextBox
            // 
            resources.ApplyResources(this.IconTextBox, "IconTextBox");
            this.IconTextBox.Name = "IconTextBox";
            // 
            // ExeTextBox
            // 
            resources.ApplyResources(this.ExeTextBox, "ExeTextBox");
            this.ExeTextBox.Name = "ExeTextBox";
            // 
            // UrlTextBox
            // 
            resources.ApplyResources(this.UrlTextBox, "UrlTextBox");
            this.UrlTextBox.Name = "UrlTextBox";
            // 
            // Notelabel
            // 
            resources.ApplyResources(this.Notelabel, "Notelabel");
            this.Notelabel.ForeColor = System.Drawing.Color.Red;
            this.Notelabel.Name = "Notelabel";
            // 
            // ImageButton
            // 
            resources.ApplyResources(this.ImageButton, "ImageButton");
            this.ImageButton.Name = "ImageButton";
            this.ImageButton.UseVisualStyleBackColor = true;
            this.ImageButton.Click += new System.EventHandler(this.ImageButton_Click);
            // 
            // ExeButton
            // 
            resources.ApplyResources(this.ExeButton, "ExeButton");
            this.ExeButton.Name = "ExeButton";
            this.ExeButton.UseVisualStyleBackColor = true;
            this.ExeButton.Click += new System.EventHandler(this.ExeButton_Click);
            // 
            // AddItempenFileDialog
            // 
            this.AddItempenFileDialog.FileName = "AddItempenFileDialog";
            // 
            // AddItemForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ExeButton);
            this.Controls.Add(this.ImageButton);
            this.Controls.Add(this.Notelabel);
            this.Controls.Add(this.UrlTextBox);
            this.Controls.Add(this.ExeTextBox);
            this.Controls.Add(this.IconTextBox);
            this.Controls.Add(this.ItemNameTextBox);
            this.Controls.Add(this.OkButton);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.UrlLabel);
            this.Controls.Add(this.ExeLabel);
            this.Controls.Add(this.ItemImagelabel);
            this.Controls.Add(this.ItemNameLabel);
            this.Name = "AddItemForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ItemNameLabel;
        private System.Windows.Forms.Label ItemImagelabel;
        private System.Windows.Forms.Label ExeLabel;
        private System.Windows.Forms.Label UrlLabel;
        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.Button OkButton;
        private System.Windows.Forms.TextBox ItemNameTextBox;
        private System.Windows.Forms.TextBox IconTextBox;
        private System.Windows.Forms.TextBox ExeTextBox;
        private System.Windows.Forms.TextBox UrlTextBox;
        private System.Windows.Forms.Label Notelabel;
        private System.Windows.Forms.Button ImageButton;
        private System.Windows.Forms.Button ExeButton;
        private System.Windows.Forms.OpenFileDialog AddItempenFileDialog;
    }
}