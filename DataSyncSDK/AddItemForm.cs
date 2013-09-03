using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Collections;
using System.Xml;

namespace DataSyncSDK
{
    public partial class AddItemForm : Form
    {
        public ContextMenuStrip contextMenuStrip;
        public XmlDocument xmlDoc;
        public string configPath;
        public AddItemForm(ContextMenuStrip contextMenu, string cp)
        {
            try
            {
	            InitializeComponent();
	            this.StartPosition = FormStartPosition.CenterScreen;
	            contextMenuStrip = contextMenu;
	            configPath = cp;
	            xmlDoc = new XmlDocument();
	            xmlDoc.Load(configPath);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }

        private void ImageButton_Click(object sender, EventArgs e)
        {
           
            try
            {
	            this.AddItempenFileDialog.Filter = "PNG文件(*.png)|*.png";
	            if (this.AddItempenFileDialog.ShowDialog() == DialogResult.OK)
	            {
	                this.IconTextBox.Text = this.AddItempenFileDialog.FileName;
	            }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }

        private void ExeButton_Click(object sender, EventArgs e)
        {
            try
            {
	            this.AddItempenFileDialog.Filter = "EXE文件(*.exe)|*.exe";
	            if (this.AddItempenFileDialog.ShowDialog() == DialogResult.OK)
	            {
	                this.ExeTextBox.Text = this.AddItempenFileDialog.FileName;
	            }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            try
            {
	            ToolStripMenuItem s = new ToolStripMenuItem();
	            int hash;
	            s.Text = this.ItemNameTextBox.Text.Trim();
	            if (s.Text.Length <= 0)
	            {
	                return;
	            }
	            hash = s.Text.GetHashCode();
	            NewItem item = new NewItem();
	            item.image = "";
	            if (this.IconTextBox.Text.Trim().Length > 0) { 
	                Image img = Image.FromFile(this.IconTextBox.Text);
	                s.Image = img;
	                item.image = this.IconTextBox.Text;
	            }
	            s.Click += new System.EventHandler(this.DynamicToolStripMenuItem_Click);
	            this.contextMenuStrip.Items.Insert(1,s);
	
	            item.hash = hash;
	            item.itemName = s.Text;
	            item.url = "";
	            item.exePath = "";
	            if (this.UrlTextBox.Text.Trim().Length > 0)
	            {
	                item.url = this.UrlTextBox.Text.Trim();
	            }
	            if (this.ExeTextBox.Text.Trim().Length > 0)
	            {
	                item.exePath = this.ExeTextBox.Text.Trim();
	            }
	            saveItem(item);
	            this.Close();
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }

        }

        private void DynamicToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
	            Process pro;
	            string id;
	            id = sender.ToString().GetHashCode().ToString();
	            xmlDoc.Load(configPath); 
	            XmlNodeList xnl = xmlDoc.SelectSingleNode("items").ChildNodes;
	            foreach (XmlNode xn in xnl)
	            {
	                XmlElement xe = (XmlElement)xn;
	                if (id == xe.GetAttribute("id"))
	                {
	                    XmlNodeList nls = xe.ChildNodes;
	                    foreach (XmlNode xn1 in nls)
	                    {
	                        XmlElement xe2 = (XmlElement)xn1;
	                        if (xe2.Name == "exe")
	                        {
	                            if(xe2.InnerText.Trim().Length>0)
	                            {
	                                pro = Process.Start(xe2.InnerText);
	                            }
	                        }
	                        if (xe2.Name == "url")
	                        {
	                            if (xe2.InnerText.Trim().Length > 0)
	                            {
	                                pro = Process.Start("iexplore.exe", xe2.InnerText);
	                            }
	                        }
	                    }
	                    break;
	                }
	            }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }

        public void saveItem(NewItem item)
        {
            try
            {
	            XmlNode root = xmlDoc.SelectSingleNode("items");
	 
	            XmlElement xe = xmlDoc.CreateElement("item");
	            xe.SetAttribute("id", Convert.ToString(item.hash));
	
	            XmlElement xesub1 = xmlDoc.CreateElement("hash");
	            xesub1.InnerText = Convert.ToString(item.hash);
	            xe.AppendChild(xesub1);
	
	            XmlElement xesub2 = xmlDoc.CreateElement("name");
	            xesub2.InnerText = item.itemName;
	            xe.AppendChild(xesub2);
	
	            XmlElement xesub3 = xmlDoc.CreateElement("exe");
	            xesub3.InnerText = item.exePath;
	            xe.AppendChild(xesub3);
	
	            XmlElement xesub4 = xmlDoc.CreateElement("url");
	            xesub4.InnerText = item.url;
	            xe.AppendChild(xesub4);
	
	            XmlElement xesub5 = xmlDoc.CreateElement("image");
	            xesub5.InnerText = item.image;
	            xe.AppendChild(xesub5);
	
	            root.AppendChild(xe);
	            xmlDoc.Save(this.configPath);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
            
        }

        public class NewItem
        {
            public int hash { get; set; }
            public string itemName { get; set; }
            public string exePath { get; set; }
            public string url { get; set; }
            public string image { get; set; }
        }

    }
}
