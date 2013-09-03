using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using DataSync;

namespace DataSyncSDK
{
    public partial class PhotoStreamSetForm : Form
    {
        public string configFile;
        public DataSyncObject dso;
        public PhotoStreamSetForm(DataSyncObject ds)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            configFile = getConfigFile();
            if (configFile != null)
            {
                getDefDir(configFile);
            }
            dso = ds;
        }

        public string getConfigFile()
        {
            string path = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
            string systemConfig = null;  
            systemConfig = path + "config" + "\\" + "config.xml";
            return systemConfig;
        }

        public string getDefDir(string configFile)
        {
            string dir = null;
            if (configFile == null)
                return null;
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(configFile);
            XmlNode root = xmlDoc.SelectSingleNode("system");
            XmlNodeList xnl = root.ChildNodes;
            foreach (XmlNode xnf in xnl)
            {
                XmlElement xe = (XmlElement)xnf;
                if (xe.Name == "photoDefaultDir")
                {
                    this.PhotoStreamDefDirTextBox.Text = xe.InnerText.Trim();
                    
                }

            }

            return dir;
        }

        public void setDir(string configFile)
        {
            if (configFile == null)
                return ;
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(configFile);
            XmlNode root = xmlDoc.SelectSingleNode("system");
            XmlNodeList xnl = root.ChildNodes;
            foreach (XmlNode xnf in xnl)
            {
                XmlElement xe = (XmlElement)xnf;
                if (xe.Name == "photoDefaultDir")
                {
                    xe.InnerText = this.PhotoStreamDefDirTextBox.Text.Trim();
                    if (Directory.Exists(xe.InnerText.Trim()) == false)
                        Directory.CreateDirectory(xe.InnerText.Trim());
                }
            }
            dso.gIcloud.defaultPhotoSavePath = this.PhotoStreamDefDirTextBox.Text.Trim();
            xmlDoc.Save(configFile);
        }

        private void photoStreamDefDirSetButton_Click(object sender, EventArgs e)
        {
            setDir(configFile);
            this.Close();
        }

        private void selectButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.ShowNewFolderButton = false;
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                string path = folderBrowserDialog.SelectedPath;
                this.PhotoStreamDefDirTextBox.Text = path.Replace('\\','/');
            }
        }
    }
}
