using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Xml;

namespace DataSync
{
    public partial class DelItemForm : Form
    {
        public ContextMenuStrip contextMenuStrip;
        public string configPath;
        public XmlDocument xmlDoc;
        public DelItemForm(ContextMenuStrip contextMenu, string cf)
        {
            try
            {
	            InitializeComponent();
	            this.StartPosition = FormStartPosition.CenterScreen;
	            contextMenuStrip = contextMenu;
	            configPath = cf;
	            xmlDoc = new XmlDocument();
	            init();
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }

        private void init()
        {
            try
            {
	            xmlDoc.Load(configPath);
	            XmlNodeList xnl = xmlDoc.SelectSingleNode("items").ChildNodes;
	            foreach (XmlNode xn in xnl)
	            {
	                XmlElement xe = (XmlElement)xn;
	                XmlNodeList nls = xe.ChildNodes;
	                foreach (XmlNode xn1 in nls)
	                {
	                    XmlElement xe2 = (XmlElement)xn1;
	                    if (xe2.Name == "name")
	                    {
	                        this.DelCheckedListBox.Items.Add(xe2.InnerText);
	                        break;
	                    }
	                }
	            }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }

        private void CnclButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            try
            {
	            string temp="";
	            int hash;
	            XmlNodeList xnl = xmlDoc.SelectSingleNode("items").ChildNodes;
	            XmlNode root = xmlDoc.SelectSingleNode("items");
	            for (int i = 0; i < this.DelCheckedListBox.Items.Count; i++)
	            {
	                if (this.DelCheckedListBox.GetItemChecked(i))
	                {
	                    temp = this.DelCheckedListBox.GetItemText(this.DelCheckedListBox.Items[i]);
	                    hash = temp.GetHashCode();
	                    delItemFromXml(root,xnl, hash);
	                    delItemFromMemuStrip(hash);
	                }
	            }
	            xmlDoc.Save(this.configPath);
	            this.Close();
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }

        private void delItemFromXml(XmlNode root,XmlNodeList xnl, int h)
        {
            try
            {
	            
	            foreach (XmlNode xn in xnl)
	            {
	                string id = Convert.ToString(h);
	                XmlElement xe = (XmlElement)xn;
	                if (id == xe.GetAttribute("id"))
	                {
	                    root.RemoveChild(xe);
	                }
	            }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }

        private void delItemFromMemuStrip(int key)
        {
            try
            {
	            int itemHash;
	            foreach (ToolStripItem item in this.contextMenuStrip.Items)
	            {
	                if (item is ToolStripMenuItem)
	                {
	                    itemHash = item.Text.GetHashCode();
	                    if (key == itemHash)
	                    {
	                        this.contextMenuStrip.Items.Remove(item);
	                        return;
	                    }
	                }
	            }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }
    }
}
