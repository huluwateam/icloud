namespace DataSyncSDK
{
    partial class mainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainForm));
            this.icloudNotifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.AddModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DelModeToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.ContactsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PhotoStreamToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DownToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.UploadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DelPhotoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ModifyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SystemSetToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.PhotoStreamSetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HelpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openIcoFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.userLabel = new System.Windows.Forms.Label();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.loginButton = new System.Windows.Forms.Button();
            this.userTextBox = new System.Windows.Forms.TextBox();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.LoginOutButton = new System.Windows.Forms.Button();
            this.loginNotelabel = new System.Windows.Forms.Label();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // icloudNotifyIcon
            // 
            resources.ApplyResources(this.icloudNotifyIcon, "icloudNotifyIcon");
            this.icloudNotifyIcon.ContextMenuStrip = this.contextMenuStrip;
            this.icloudNotifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.icloudNotifyIcon_MouseDoubleClick);
            // 
            // contextMenuStrip
            // 
            resources.ApplyResources(this.contextMenuStrip, "contextMenuStrip");
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddModeToolStripMenuItem,
            this.DelModeToolStripMenuItem1,
            this.ContactsToolStripMenuItem,
            this.PhotoStreamToolStripMenuItem,
            this.ModifyToolStripMenuItem,
            this.SystemSetToolStripMenuItem1,
            this.HelpToolStripMenuItem,
            this.AboutToolStripMenuItem,
            this.ExitToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip1";
            // 
            // AddModeToolStripMenuItem
            // 
            resources.ApplyResources(this.AddModeToolStripMenuItem, "AddModeToolStripMenuItem");
            this.AddModeToolStripMenuItem.Image = global::DataSyncSDK.Properties.Resources.plus;
            this.AddModeToolStripMenuItem.Name = "AddModeToolStripMenuItem";
            this.AddModeToolStripMenuItem.Click += new System.EventHandler(this.AddModeToolStripMenuItem_Click);
            // 
            // DelModeToolStripMenuItem1
            // 
            resources.ApplyResources(this.DelModeToolStripMenuItem1, "DelModeToolStripMenuItem1");
            this.DelModeToolStripMenuItem1.Image = global::DataSyncSDK.Properties.Resources.del;
            this.DelModeToolStripMenuItem1.Name = "DelModeToolStripMenuItem1";
            this.DelModeToolStripMenuItem1.Click += new System.EventHandler(this.DelModeToolStripMenuItem1_Click);
            // 
            // ContactsToolStripMenuItem
            // 
            resources.ApplyResources(this.ContactsToolStripMenuItem, "ContactsToolStripMenuItem");
            this.ContactsToolStripMenuItem.Image = global::DataSyncSDK.Properties.Resources.contacts;
            this.ContactsToolStripMenuItem.Name = "ContactsToolStripMenuItem";
            this.ContactsToolStripMenuItem.Click += new System.EventHandler(this.ContactsToolStripMenuItem_Click);
            // 
            // PhotoStreamToolStripMenuItem
            // 
            resources.ApplyResources(this.PhotoStreamToolStripMenuItem, "PhotoStreamToolStripMenuItem");
            this.PhotoStreamToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DownToolStripMenuItem,
            this.UploadToolStripMenuItem,
            this.DelPhotoToolStripMenuItem});
            this.PhotoStreamToolStripMenuItem.Image = global::DataSyncSDK.Properties.Resources.picture;
            this.PhotoStreamToolStripMenuItem.Name = "PhotoStreamToolStripMenuItem";
            this.PhotoStreamToolStripMenuItem.Click += new System.EventHandler(this.PhotoStreamToolStripMenuItem_Click);
            // 
            // DownToolStripMenuItem
            // 
            resources.ApplyResources(this.DownToolStripMenuItem, "DownToolStripMenuItem");
            this.DownToolStripMenuItem.Name = "DownToolStripMenuItem";
            this.DownToolStripMenuItem.Click += new System.EventHandler(this.DownToolStripMenuItem_Click);
            // 
            // UploadToolStripMenuItem
            // 
            resources.ApplyResources(this.UploadToolStripMenuItem, "UploadToolStripMenuItem");
            this.UploadToolStripMenuItem.Name = "UploadToolStripMenuItem";
            this.UploadToolStripMenuItem.Click += new System.EventHandler(this.UploadToolStripMenuItem_Click);
            // 
            // DelPhotoToolStripMenuItem
            // 
            resources.ApplyResources(this.DelPhotoToolStripMenuItem, "DelPhotoToolStripMenuItem");
            this.DelPhotoToolStripMenuItem.Name = "DelPhotoToolStripMenuItem";
            this.DelPhotoToolStripMenuItem.Click += new System.EventHandler(this.DelPhotoToolStripMenuItem_Click);
            // 
            // ModifyToolStripMenuItem
            // 
            resources.ApplyResources(this.ModifyToolStripMenuItem, "ModifyToolStripMenuItem");
            this.ModifyToolStripMenuItem.Image = global::DataSyncSDK.Properties.Resources.modify;
            this.ModifyToolStripMenuItem.Name = "ModifyToolStripMenuItem";
            this.ModifyToolStripMenuItem.Click += new System.EventHandler(this.ModifyToolStripMenuItem_Click);
            // 
            // SystemSetToolStripMenuItem1
            // 
            resources.ApplyResources(this.SystemSetToolStripMenuItem1, "SystemSetToolStripMenuItem1");
            this.SystemSetToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PhotoStreamSetToolStripMenuItem});
            this.SystemSetToolStripMenuItem1.Image = global::DataSyncSDK.Properties.Resources.advanced;
            this.SystemSetToolStripMenuItem1.Name = "SystemSetToolStripMenuItem1";
            // 
            // PhotoStreamSetToolStripMenuItem
            // 
            resources.ApplyResources(this.PhotoStreamSetToolStripMenuItem, "PhotoStreamSetToolStripMenuItem");
            this.PhotoStreamSetToolStripMenuItem.Name = "PhotoStreamSetToolStripMenuItem";
            this.PhotoStreamSetToolStripMenuItem.Click += new System.EventHandler(this.PhotoStreamSetToolStripMenuItem_Click);
            // 
            // HelpToolStripMenuItem
            // 
            resources.ApplyResources(this.HelpToolStripMenuItem, "HelpToolStripMenuItem");
            this.HelpToolStripMenuItem.Image = global::DataSyncSDK.Properties.Resources.help;
            this.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem";
            this.HelpToolStripMenuItem.Click += new System.EventHandler(this.HelpToolStripMenuItem_Click);
            // 
            // AboutToolStripMenuItem
            // 
            resources.ApplyResources(this.AboutToolStripMenuItem, "AboutToolStripMenuItem");
            this.AboutToolStripMenuItem.Image = global::DataSyncSDK.Properties.Resources.star;
            this.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem";
            this.AboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItem_Click);
            // 
            // ExitToolStripMenuItem
            // 
            resources.ApplyResources(this.ExitToolStripMenuItem, "ExitToolStripMenuItem");
            this.ExitToolStripMenuItem.Image = global::DataSyncSDK.Properties.Resources.exit;
            this.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem";
            this.ExitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // openIcoFileDialog
            // 
            this.openIcoFileDialog.FileName = "Ico";
            resources.ApplyResources(this.openIcoFileDialog, "openIcoFileDialog");
            // 
            // userLabel
            // 
            resources.ApplyResources(this.userLabel, "userLabel");
            this.userLabel.Name = "userLabel";
            // 
            // passwordLabel
            // 
            resources.ApplyResources(this.passwordLabel, "passwordLabel");
            this.passwordLabel.Name = "passwordLabel";
            // 
            // loginButton
            // 
            resources.ApplyResources(this.loginButton, "loginButton");
            this.loginButton.Name = "loginButton";
            this.loginButton.UseVisualStyleBackColor = true;
            this.loginButton.Click += new System.EventHandler(this.loginButton_Click);
            // 
            // userTextBox
            // 
            resources.ApplyResources(this.userTextBox, "userTextBox");
            this.userTextBox.Name = "userTextBox";
            // 
            // passwordTextBox
            // 
            resources.ApplyResources(this.passwordTextBox, "passwordTextBox");
            this.passwordTextBox.Name = "passwordTextBox";
            // 
            // LoginOutButton
            // 
            resources.ApplyResources(this.LoginOutButton, "LoginOutButton");
            this.LoginOutButton.Name = "LoginOutButton";
            this.LoginOutButton.UseVisualStyleBackColor = true;
            this.LoginOutButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // loginNotelabel
            // 
            resources.ApplyResources(this.loginNotelabel, "loginNotelabel");
            this.loginNotelabel.AllowDrop = true;
            this.loginNotelabel.AutoEllipsis = true;
            this.loginNotelabel.ForeColor = System.Drawing.Color.Red;
            this.loginNotelabel.Name = "loginNotelabel";
            this.loginNotelabel.Click += new System.EventHandler(this.loginNotelabel_Click);
            this.loginNotelabel.Hide();
            // 
            // mainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.userTextBox);
            this.Controls.Add(this.passwordTextBox);
            this.Controls.Add(this.LoginOutButton);
            this.Controls.Add(this.loginNotelabel);
            this.Controls.Add(this.passwordLabel);
            this.Controls.Add(this.userLabel);
            this.Controls.Add(this.loginButton);
            this.Name = "mainForm";
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon icloudNotifyIcon;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem ExitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem PhotoStreamToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ModifyToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openIcoFileDialog;
        private System.Windows.Forms.ToolStripMenuItem AddModeToolStripMenuItem;
        private System.Windows.Forms.Label userLabel;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.Button loginButton;
        private System.Windows.Forms.TextBox userTextBox;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.ToolStripMenuItem HelpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AboutToolStripMenuItem;
        private System.Windows.Forms.Button LoginOutButton;
        private System.Windows.Forms.ToolStripMenuItem DelModeToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem DownToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem UploadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DelPhotoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ContactsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SystemSetToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem PhotoStreamSetToolStripMenuItem;
        private System.Windows.Forms.Label loginNotelabel;

    }
}

