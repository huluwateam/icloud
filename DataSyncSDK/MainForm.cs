using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;
using DataSync;
using System.Collections;
using System.Xml;
using System.Threading;

namespace DataSyncSDK
{
    public delegate void loginClick(object sender, EventArgs e);
    public partial class mainForm : Form
    {
        public TransferProgressCallBack callback = new TransferProgressCallBack(TransferProgress);
        public IcloudRecePushCallBack icloudRecePushCallBack = new IcloudRecePushCallBack(icloudRecePushcb);
        public DataSyncObject ds = null;
        public string resourcesPath;
        public string menuConfig;
        public string systemConfig;
        public XmlDocument xmlDoc = new XmlDocument();
        public mainForm()
        {
            try
            {
	            InitializeComponent();
	            Icon icon;
	            string path = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
	            resourcesPath = path + "resource" + "\\" + "notifyIco.ico";
	            menuConfig = path + "config" + "\\" + "menuConfig.xml";
	            systemConfig = path + "config" + "\\" + "config.xml";
	            icon = new Icon(resourcesPath);
	            this.icloudNotifyIcon.Icon = icon;
	            this.Icon = icon;
	
	            ds = new DataSyncObject(systemConfig);
	            this.StartPosition = FormStartPosition.CenterScreen;
	            initMenu();
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }

        }

        private void initMenu()
        {
            
            try
            {
	            xmlDoc.Load(menuConfig);
	            XmlNode root = xmlDoc.SelectSingleNode("items");
	            XmlNodeList xnl = root.ChildNodes;
	            ToolStripMenuItem s;
	            foreach (XmlNode xnf in xnl)
	            {
	                s = new ToolStripMenuItem();
	                XmlElement xe = (XmlElement)xnf;
	                XmlNodeList xnf1=xe.ChildNodes;
	
	                foreach (XmlNode xn2 in xnf1)
	                {
	                    if (xn2.Name == "name" && xn2.InnerText.Trim().Length > 0)
	                    {
	                        s.Text = xn2.InnerText;
	                        s.Click += new System.EventHandler(this.menuItem_Click);
	                        this.contextMenuStrip.Items.Insert(1, s);
	                    }
	                    if (xn2.Name == "image" && xn2.InnerText.Trim().Length > 0)
	                    {
	                        Image img = Image.FromFile(xn2.InnerText);
	                        s.Image = img;
	                    }
	                    
	                }
	            }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }

        private void menuItem_Click(object sender, EventArgs e)
        {
            try
            {
	            Process pro;
	            string id;
	            id = sender.ToString().GetHashCode().ToString();
	            xmlDoc.Load(menuConfig);
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
	                            if (xe2.InnerText.Trim().Length > 0)
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

        private void icloudNotifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
//             this.Visible = true;
//             this.WindowState = FormWindowState.Normal;
//             this.Show();
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void ModifyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            try
            {
	            Icon icon = null;
	            string path = "";
	            string selectFile = null;
	            path = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
	            path += "resource";
	            path += "\\";
	            path += "notifyIco.ico";
	            this.openIcoFileDialog.Filter = "ICO文件(*.ico)|*.ico";
	            if (this.openIcoFileDialog.ShowDialog() == DialogResult.OK)
	            {
	                selectFile = this.openIcoFileDialog.FileName;
	            }
	            else
	            {
	                Console.Write("DialogResult == ok");
	                return;
	            }
	            if (fileUpdata(selectFile, path)==false)
	            {
	                Console.Write("fileUpdata == false");
	                return;
	            }
	            if (path != null && path.Length > 0)
	                icon = new Icon(path);
	            this.icloudNotifyIcon.Icon = icon;
	            this.Icon = icon;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }

        }

        private bool fileUpdata(string srcfile,string desfile)
        {
            try
            {
	            FileInfo df = new FileInfo(desfile);
	            FileInfo sf = new FileInfo(srcfile);
	            if (df.Exists)
	            {
	                df.Delete();
	            }
	            byte[] buf = new byte[1024];
	            FileStream dfs = df.OpenWrite();
	            FileStream sfs = sf.OpenRead();
	
	            int read = sfs.Read(buf, 0, 1024);
	            while (read > 0)
	            {
	                dfs.Write(buf, 0, read);
	                read = sfs.Read(buf, 0, 1024);
	            }
	            dfs.Close();
	            sfs.Close();
	
	            return true;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
            return false;
        }

        private void SetToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void PhotoStreamToolStripMenuItem_Click(object sender, EventArgs e)
        {
//             PhotoForm pf = new PhotoForm(cloud);
//             pf.Show();
        }

        public static bool TransferProgress(int transfered, int total)
        {
            //Console.WriteLine("TransferProgress:{0}-{1}", transfered, total);
            return false;
        }

        public static void icloudRecePushcb(int type)
        {
            Console.WriteLine("icloudRecePushcb,type:"+type);
            
        }

        private void loginButton_Click(object sender, EventArgs e)
        {

            try
            {
	            string user;
	            string ps;
	            bool ret = true;
	            user = this.userTextBox.Text;
	            ps = this.passwordTextBox.Text;
	
	            Context loginctx = new Context();
	            loginctx.transferProgresscallback = new TransferProgressCallBack(TransferProgress);
	            loginctx.loginUsername = user;
	            loginctx.loginPassword = ps;
                this.loginNotelabel.Hide();
	            ret = ds.login(loginctx);
	            if (ret == true)
	            {
	                this.Hide();
	            }
	            else
                {
                    this.loginNotelabel.Show();
	                this.loginNotelabel.Text = "登陆失败，请检查用户名或密码是否输入正确。（注意：您必须先在iOS或OS X 设备上使用您的Apple ID 设置iCloud。）";
	            }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }
        private void AddModeToolStripMenuItem_Click(object sender, EventArgs e)
        {

            try
            {
	            AddItemForm af = new AddItemForm(this.contextMenuStrip, menuConfig);
	            af.Show();
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
	            Process pro = Process.Start("iexplore.exe", "http://www.baidu.com");
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DelModeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
	            DelItemForm df = new DelItemForm(this.contextMenuStrip, menuConfig);
	            df.Show();
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }

        private void Contact_Click(object sender, EventArgs e)
        {
            try
            {
	            DelItemForm df = new DelItemForm(this.contextMenuStrip, menuConfig);
	            df.Show();
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }


        private void HelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
	            string path = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
	            string help = path + "html" + "\\" + "help.htm";
	            Process pro = Process.Start("iexplore.exe", help);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
	            string path = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
	            string about = path + "html" + "\\" + "about.htm";
	            Process pro = Process.Start("iexplore.exe", about);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }

        private void DownToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
	            Thread t = new Thread(new ThreadStart(downPhoto));
	            t.Start();
	            System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo("Explorer.exe");
	            psi.Arguments = "/e," + ds.gIcloud.defaultPhotoSavePath.Replace('/','\\');
	            System.Diagnostics.Process.Start(psi);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
           
        }

        public void downPhoto()
        {
            try
            {
	            if (ds.gIcloud == null)
	                return;
	            List<FileNode> fileList = ds.gIcloud.getPhotoList();  //获取下载文件列表接口
	            if (fileList == null)
	                return;
	            Context getctx;
	            foreach (FileNode item in fileList)
	            {
	                getctx = new Context();
	                getctx.transferProgresscallback = new TransferProgressCallBack(TransferProgress);
	                getctx.modeType = Context.ICLOUD_PS_MODE;
	                getctx.inItem = item;
	                ds.get(getctx);
	            }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }

        private void UploadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
	            UploadPhoto up;
	            this.openIcoFileDialog.Multiselect = true;
	            this.openIcoFileDialog.Filter = "JPG文件(*.jpg)|*.jpg|JPEG文件(*.jpeg)|*.jpeg|PNG文件(*.png)|*.png|GIF文件(*.gif)|*.gif|BMP文件(*.bmp)|*.bmp|TIFF文件(*.tiff)|*.tiff";
	            if (this.openIcoFileDialog.ShowDialog() == DialogResult.OK)
	            {
	                string[] files;
	                
	                files = this.openIcoFileDialog.FileNames;
	                up = new UploadPhoto(ds, files);
	                Thread t = new Thread(new ThreadStart(up.uploadPhoto));
	                t.Start();
	            }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }

        public class UploadPhoto {
            DataSyncObject dso;
            string[] files;
            public UploadPhoto(DataSyncObject ds, string[] fs)
            {
                dso = ds;
                files = fs;
            }

           public void uploadPhoto(){
               try
               {
	               if (files == null)
	                   return;
	               Context putctx;
	               for (int i = 0; i < files.Length; i++)
	               {
	                   putctx = new Context();
	                   putctx.transferProgresscallback = new TransferProgressCallBack(TransferProgress);
	                   putctx.srcFileFullName = files[i];
	                   putctx.modeType = Context.ICLOUD_PS_MODE;
	                   dso.put(putctx);
	               }
	
	               List<FileNode> fileList = dso.gIcloud.getPhotoList();  //获取下载文件列表接口
	               if (fileList == null)
	                   return;
	               Context getctx;
	               foreach (FileNode item in fileList)
	               {
	
	                   getctx = new Context();
	                   getctx.transferProgresscallback = new TransferProgressCallBack(TransferProgress);
	                   getctx.modeType = Context.ICLOUD_PS_MODE;
	                   getctx.inItem = item;
	                   dso.get(getctx);//下载文件接口
	                   
	               }
               }
               catch (System.Exception ex)
               {
                   Console.WriteLine(ex.StackTrace);
               }
            }
        }

        public class DeletePhoto
        {
            string[] files;
            DataSyncObject d;
            public DeletePhoto(DataSyncObject ds, string[] fs)
            {
                files = fs;
                d = ds;
            }

            public void delPhoto()
            {
                try
                {
	                if (files == null)
	                    return;
	                FileInfo f;
	                Context delctx;
	                bool ret = false ;
	                for (int i = 0; i < files.Length; i++)
	                {
	                    delctx = new Context();
	                    delctx.modeType = Context.ICLOUD_PS_MODE;
	                    delctx.srcFileFullName = files[i];
	                    delctx.modeType = Context.ICLOUD_PS_MODE;
	                    ret = d.delete(delctx);
	                    if (ret) 
	                    {
	                        f = new FileInfo(files[i]);
	                        if (f.Exists)
	                        {
	                            f.Delete();
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

        private void DelPhotoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
           {
	           DeletePhoto up;
	            OpenFileDialog openFileDialog = new OpenFileDialog();
	
	            openFileDialog.InitialDirectory = ds.gIcloud.defaultPhotoSavePath.Replace('/','\\');
	            openFileDialog.Multiselect = true;
	
	            openFileDialog.Filter = "JPG文件(*.jpg)|*.jpg|JPEG文件(*.jpeg)|*.jpeg|PNG文件(*.png)|*.png|GIF文件(*.gif)|*.gif|BMP文件(*.bmp)|*.bmp|TIFF文件(*.tiff)|*.tiff";
	            if (openFileDialog.ShowDialog() == DialogResult.OK)
	            {
	                string[] files;
	                files = openFileDialog.FileNames;
	                up = new DeletePhoto(ds, files);
	                Thread t = new Thread(new ThreadStart(up.delPhoto));
	                t.Start();
	            }
           }
           catch (System.Exception ex)
           {
               Console.WriteLine(ex.StackTrace);
           }
        }

        private void ContactsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
	            ContactForm df = new ContactForm(ds);
	            df.Show();
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }


        private void PhotoStreamSetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
	            PhotoStreamSetForm pf = new PhotoStreamSetForm(ds);
	            pf.Show();
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }

        private void loginNotelabel_Click(object sender, EventArgs e)
        {

        }

        
           
    }
}
