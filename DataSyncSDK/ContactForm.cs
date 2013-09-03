using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;
using DataSync;
namespace DataSyncSDK
{
    public partial class ContactForm : Form
    {
        private DataSyncObject dso;

        private Dictionary<string, Contact> contactDic = new Dictionary<string, Contact>();

        private BackgroundWorker bgw;

        //private Button btnAdd;

        //记录当前是否处于创建新联系人状态
        private bool isNewContact = true;

        public ContactForm(DataSyncObject ds)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.PhoneTypeCb_1.FormattingEnabled = true;
//             this.PhoneTypeCb_1.Items.AddRange(new object[]{           
//             "手机",
//             "家庭",
//             "工作",
//             "工作传真",
//             "家庭传真",
//             "传呼",
//             "其他"
//             });
            this.PhoneTypeCb_1.SelectedIndex = 0;

            this.PhoneTypeCb_2.FormattingEnabled = true;
//             this.PhoneTypeCb_2.Items.AddRange(new object[]{           
//             "手机",
//             "家庭",
//             "工作",
//             "工作传真",
//             "家庭传真",
//             "传呼",
//             "其他"
//             });
            this.PhoneTypeCb_2.SelectedIndex = 1;


            this.EmailTypeCb_1.FormattingEnabled = true;
//             this.EmailTypeCb_1.Items.AddRange(new object[]{                     
//             "家庭",
//             "工作",
//             "手机",
//             "其他"
//             });
            this.EmailTypeCb_1.SelectedIndex = 0;

            this.EmailTypeCb_2.FormattingEnabled = true;
//             this.EmailTypeCb_2.Items.AddRange(new object[]{                     
//             "家庭",
//             "工作",
//             "手机",
//             "其他"
//             });
            this.EmailTypeCb_2.SelectedIndex = 1;



            this.IMTypeCb_1.FormattingEnabled = true;
//             this.IMTypeCb_1.Items.AddRange(new object[]{           
//             "AIM",
//             "QQ",
//             "MSN",
//             "Skype",
//             "ICQ",
//             "飞信",
//             });
            this.IMTypeCb_1.SelectedIndex = 0;


            this.IMTypeCb_2.FormattingEnabled = true;
//             this.IMTypeCb_2.Items.AddRange(new object[]{           
//             "AIM",
//             "QQ",
//             "MSN",
//             "Skype",
//             "ICQ",
//             "飞信",
//             });
            this.IMTypeCb_2.SelectedIndex = 1;


            this.AddrTypeCb_1.FormattingEnabled = true;
//             this.AddrTypeCb_1.Items.AddRange(new object[]{           
//             "家庭",
//             "工作",
//             "其他"
//             });
            this.AddrTypeCb_1.SelectedIndex = 0;

            this.AddrTypeCb_2.FormattingEnabled = true;
//             this.AddrTypeCb_2.Items.AddRange(new object[]{           
//             "家庭",
//             "工作",
//             "其他"
//             });
            this.AddrTypeCb_2.SelectedIndex = 1;

            dso = ds;

            bgw = new BackgroundWorker();
            bgw.WorkerSupportsCancellation = true;
            bgw.WorkerReportsProgress = true;
            bgw.DoWork += new DoWorkEventHandler(RefreshContact);
            bgw.RunWorkerAsync();
        }
        
        //private void RefreshContact()
        private void RefreshContact(object sender, DoWorkEventArgs e)
        {
            try
            {
	            Context ctx = new Context();
	            ctx.modeType = Context.ICLOUD_CONTACT_MODE;
	            dso.get(ctx);
	            this.Invoke(new Action(() =>
	            {//当需要操作界面元素时，需要用Invoke，注意这里面不能有繁琐的操作
	                this.ContactlistBox.Items.Clear();
	            }));
	            if (ctx.outContactList == null)
	            {
	                return;
	            }
	            List<Contact> lContact = ctx.outContactList;
	
	            contactDic.Clear();
	
	            for (int i = 0; i < lContact.Count; i++)
	            {
	                string name = lContact[i].lastName + " " + lContact[i].firstName;
	                this.Invoke(new Action(() =>
	                {//当需要操作界面元素时，需要用Invoke，注意这里面不能有繁琐的操作
	                    this.ContactlistBox.Items.Add(name);
	                }));
	
	                if (contactDic.ContainsKey(name))
	                {
	                    continue;
	                }
	                contactDic.Add(name, lContact[i]);
	            }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }

        private void ContactForm_Load(object sender, EventArgs e)
        {
            
        }

        private void delContactBtn_Click(object sender, EventArgs e)
        {
            try
            {
	            if (ContactlistBox.SelectedIndex != -1)
	            {
	                //调用icloud接口删除联系人
	                string key = this.ContactlistBox.SelectedItem.ToString();
	                if (contactDic.ContainsKey(key))
	                {
	                    Contact contact = contactDic[key];
	                    List<Contact> lContacts = new List<Contact>();
	                    lContacts.Add(contact);
	
	                    Context ctx = new Context();
	                    ctx.modeType = Context.ICLOUD_CONTACT_MODE;
	                    ctx.contactList = lContacts;
	                    dso.delete(ctx);
	                }
	
	                this.ContactlistBox.Items.Remove(this.ContactlistBox.SelectedItem);
	            }
	
	            //清除联系人具体信息界面数据
	            ClearInterfaceData();
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }

        private void RefreshContactBtn_Click(object sender, EventArgs e)
        {
            //刷新通讯录
            try
            {
	            bgw = new BackgroundWorker();
	            bgw.WorkerSupportsCancellation = true;
	            bgw.WorkerReportsProgress = true;
	            bgw.DoWork += new DoWorkEventHandler(RefreshContact);
	            bgw.RunWorkerAsync();
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private Contact updateContactData(Contact contact)
        {
            try
            {
	            //从界面获取数据更新到contact中
	            if (contact == null)
	            {
	                contact = new Contact();
	            }
	
	            //获取姓名
	            if (FirstNameTB.Text.Length > 0)
	            {
	                contact.firstName = FirstNameTB.Text;
	            }
	
	            if (lastNameTB.Text.Length > 0)
	            {
	                contact.lastName = lastNameTB.Text;
	            }
	
	            //获取电话号码
	            List<Phone> lPhone = contact.phones;
	            if (phoneNumTB_1.Text.Length > 0)
	            {   
	                if (lPhone == null)
	                {
	                    lPhone = new List<Phone>();
	                }
	
	                Phone phone;
	                if (lPhone.Count > 0)
	                {
	                    phone = lPhone[0];
	                    phone.field = phoneNumTB_1.Text;
	                    phone.label = PhoneTypeCb_1.Text;
	                }
	                else
	                {
	                    phone = new Phone();
	                    phone.field = phoneNumTB_1.Text;
	                    phone.label = PhoneTypeCb_1.Text;
	                    lPhone.Add(phone);
	                }
	            }
	
	            if (phoneNumTB_2.Text.Length > 0)
	            {
	                if (lPhone == null)
	                {
	                    lPhone = new List<Phone>();
	                }
	
	                Phone phone;
	                if (lPhone.Count > 1)
	                {
	                    phone = lPhone[1];
	                    phone.field = phoneNumTB_2.Text;
	                    phone.label = PhoneTypeCb_2.Text;
	                }
	                else
	                {
	                    phone = new Phone();
	                    phone.field = phoneNumTB_2.Text;
	                    phone.label = PhoneTypeCb_2.Text;
	                    lPhone.Add(phone);
	                }
	            }
	            contact.phones = lPhone;
	
	            //获取邮件地址
	            List<EmailAdr> lEmail = contact.emailAddresses;
	            if (EmailTB_1.Text.Length > 0)
	            {
	                if (lEmail == null)
	                {
	                    lEmail = new List<EmailAdr>();
	                }
	
	                EmailAdr emailAdr;
	                if (lEmail.Count > 0)
	                {
	                    emailAdr = lEmail[0];
	                    emailAdr.field = EmailTB_1.Text;
	                    emailAdr.label = EmailTypeCb_1.Text;
	                }
	                else
	                {
	                    emailAdr = new EmailAdr();
	                    emailAdr.field = EmailTB_1.Text;
	                    emailAdr.label = EmailTypeCb_1.Text;
	                    lEmail.Add(emailAdr);
	                }
	            }
	            if (EmailTB_2.Text.Length > 0)
	            {
	                if (lEmail == null)
	                {
	                    lEmail = new List<EmailAdr>();
	                }
	
	                EmailAdr emailAdr;
	                if (lEmail.Count > 1)
	                {
	                    emailAdr = lEmail[1];
	                    emailAdr.field = EmailTB_2.Text;
	                    emailAdr.label = EmailTypeCb_2.Text;
	                }
	                else
	                {
	                    emailAdr = new EmailAdr();
	                    emailAdr.field = EmailTB_2.Text;
	                    emailAdr.label = EmailTypeCb_2.Text;
	                    lEmail.Add(emailAdr);
	                }
	            }
	            contact.emailAddresses = lEmail;
	
	            //获取即时通讯
	            List<IM> lIM = contact.IMs;
	            if (IMTB_1.Text.Length > 0)
	            {
	                if (lIM == null)
	                {
	                    lIM = new List<IM>();
	                }
	
	                IM im;
	                if (lIM.Count > 0)
	                {
	                    im = lIM[0];
	                    if (im.field == null)
	                    {
	                        im.field = new IMsfield();
	                    }
	                    im.field.userName = IMTB_1.Text;
	                    im.field.IMService = IMTypeCb_1.Text;
	                }
	                else
	                {
	                    im = new IM();
	                    im.field = new IMsfield();
	                    im.field.userName = IMTB_1.Text;
	                    im.field.IMService = IMTypeCb_1.Text;
	                    lIM.Add(im);
	                }
	            }
	            if (IMTB_2.Text.Length > 0)
	            {
	                if (lIM == null)
	                {
	                    lIM = new List<IM>();
	                }
	
	                IM im;
	                if (lIM.Count > 1)
	                {
	                    im = lIM[1];
	                    if (im.field == null)
	                    {
	                        im.field = new IMsfield();
	                    }
	                    im.field.userName = IMTB_2.Text;
	                    im.field.IMService = IMTypeCb_2.Text;
	                }
	                else
	                {
	                    im = new IM();
	                    im.field = new IMsfield();
	                    im.field.userName = IMTB_2.Text;
	                    im.field.IMService = IMTypeCb_2.Text;
	                    lIM.Add(im);
	                }
	            }
	            contact.IMs = lIM;
	
	            //获取通讯地址
	            List<StreetAdr> lStreetAdr = contact.streetAddresses;
	            if (AddrCountryTB_1.Text.Length > 0 || AddrProvinceTB_1.Text.Length > 0
	                || AddrCityTB_1.Text.Length > 0 || AddrStreetTB_1.Text.Length > 0)
	            {
	                if (lStreetAdr == null)
	                {
	                    lStreetAdr = new List<StreetAdr>();
	                }
	
	                StreetAdr streetAdr;
	                if (lStreetAdr.Count > 0)
	                {
	                    streetAdr = lStreetAdr[0];
	                    streetAdr.label = AddrTypeCb_1.Text;
	                    if (streetAdr.field == null)
	                    {
	                        streetAdr.field = new StreetField();
	                    }
	                    streetAdr.field.country = AddrCountryTB_1.Text;
	                    streetAdr.field.state = AddrProvinceTB_1.Text;
	                    streetAdr.field.city = AddrCityTB_1.Text;
	                    streetAdr.field.street = AddrStreetTB_1.Text;
	                }
	                else
	                {
	                    streetAdr = new StreetAdr();
	                    streetAdr.label = AddrTypeCb_1.Text;
	                    streetAdr.field = new StreetField();
	                    streetAdr.field.country = AddrCountryTB_1.Text;
	                    streetAdr.field.state = AddrProvinceTB_1.Text;
	                    streetAdr.field.city = AddrCityTB_1.Text;
	                    streetAdr.field.street = AddrStreetTB_1.Text;
	                    lStreetAdr.Add(streetAdr);
	                }
	
	            }
	
	            if (AddrCountryTB_2.Text.Length > 0 || AddrProvinceTB_2.Text.Length > 0
	                || AddrCityTB_2.Text.Length > 0 || AddrStreetTB_2.Text.Length > 0
	                || AddrZipTB_2.Text.Length > 0)
	            {
	                if (lStreetAdr == null)
	                {
	                    lStreetAdr = new List<StreetAdr>();
	                }
	
	                StreetAdr streetAdr;
	                if (lStreetAdr.Count > 1)
	                {
	                    streetAdr = lStreetAdr[1];
	                    streetAdr.label = AddrTypeCb_2.Text;
	                    if (streetAdr.field == null)
	                    {
	                        streetAdr.field = new StreetField();
	                    }
	                    streetAdr.field.country = AddrCountryTB_2.Text;
	                    streetAdr.field.state = AddrProvinceTB_2.Text;
	                    streetAdr.field.city = AddrCityTB_2.Text;
	                    streetAdr.field.street = AddrStreetTB_2.Text;
	                }
	                else
	                {
	                    streetAdr = new StreetAdr();
	                    streetAdr.label = AddrTypeCb_2.Text;
	                    streetAdr.field = new StreetField();
	                    streetAdr.field.country = AddrCountryTB_2.Text;
	                    streetAdr.field.state = AddrProvinceTB_2.Text;
	                    streetAdr.field.city = AddrCityTB_2.Text;
	                    streetAdr.field.street = AddrStreetTB_2.Text;
	                    lStreetAdr.Add(streetAdr);
	                }
	            }
	
	            //获取备注
	            if (noteTB.Text.Length > 0)
	            {
	                contact.notes = noteTB.Text;
	            }
                return contact;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }

            return null;
        }

        private void updateContactBtn_Click(object sender, EventArgs e)
        {
            try
           {
	           if (isNewContact)
	            {
	                //创建新联系人
	                Contact contact = updateContactData(null);
	                List<Contact> lContacts = new List<Contact>();
	                lContacts.Add(contact);
	                Context ctx = new Context();
	                ctx.modeType = Context.ICLOUD_CONTACT_MODE;
	                ctx.contactList = lContacts;
	                dso.put(ctx);
	            }
	            else
	            {
	                //修改联系人
	                if (ContactlistBox.SelectedIndex != -1)
	                {
	                    string key = this.ContactlistBox.SelectedItem.ToString();
	                    if (contactDic.ContainsKey(key))
	                    {
	                        Contact contact = contactDic[key];
	
	                        contact = updateContactData(contact);
	
	                        List<Contact> lContacts = new List<Contact>();
	                        lContacts.Add(contact);
	                        Context ctx = new Context();
	                        ctx.modeType = Context.ICLOUD_CONTACT_MODE;
	                        ctx.contactList = lContacts;
	                        dso.updata(ctx);
	                    }
	                }
	            }
	
	            //TODO:使用刷新通讯录要修改成直接修改
	            bgw = new BackgroundWorker();
	            bgw.WorkerSupportsCancellation = true;
	            bgw.WorkerReportsProgress = true;
	            bgw.DoWork += new DoWorkEventHandler(RefreshContact);
	            bgw.RunWorkerAsync();
	
	            //清除联系人具体信息界面数据
	            ClearInterfaceData();
           }
           catch (System.Exception ex)
           {
               Console.WriteLine(ex.StackTrace);
           }
        }

        private void ClearInterfaceData()
        {
            try
            {
	            FirstNameTB.Text = "";
	            lastNameTB.Text = "";
	
	            phoneNumTB_1.Text = "";
	            phoneNumTB_2.Text = "";
	            PhoneTypeCb_1.Text = (string)PhoneTypeCb_1.Items[0];
	            PhoneTypeCb_2.Text = (string)PhoneTypeCb_1.Items[1];
	
	            EmailTB_1.Text = "";
	            EmailTB_2.Text = "";
	            EmailTypeCb_1.Text = (string)EmailTypeCb_1.Items[0];
	            EmailTypeCb_2.Text = (string)EmailTypeCb_2.Items[1];
	
	            IMTB_1.Text = "";
	            IMTB_2.Text = "";
	            IMTypeCb_1.Text = (string)IMTypeCb_1.Items[0];
	            IMTypeCb_2.Text = (string)IMTypeCb_2.Items[1];
	
	            AddrCountryTB_1.Text = "";
	            AddrProvinceTB_1.Text = "";
	            AddrCityTB_1.Text = "";
	            AddrStreetTB_1.Text = "";
	            AddrZipTB_1.Text = "";
	
	            AddrCountryTB_2.Text = "";
	            AddrProvinceTB_2.Text = "";
	            AddrCityTB_2.Text = "";
	            AddrStreetTB_2.Text = "";
	            AddrZipTB_2.Text = "";
	
	            AddrTypeCb_1.Text = (string)AddrTypeCb_1.Items[0];
	            AddrTypeCb_2.Text = (string)AddrTypeCb_2.Items[1];
	
	            noteTB.Text = "";
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }

        private void ResolveContact(Contact contact)
        {
            try
            {
	            ClearInterfaceData();
	
	            string firstName = contact.firstName;
	            string lastName = contact.lastName;
	
	            FirstNameTB.Text = firstName;
	            lastNameTB.Text = lastName;
	
	            //解析电话号码 只暂时显示前两个
	            List<Phone> lPhone = contact.phones;
	            for (int i = 0; lPhone != null && i < lPhone.Count; i++)
	            {
	                if (i == 0)
	                {
	                    Phone phone = lPhone[0];
	                    string strPhone = phone.field;
	                    string strLabel = phone.label;
	                    phoneNumTB_1.Text = strPhone;
	                    PhoneTypeCb_1.Text = strLabel;
	                }
	                else if (i == 1)
	                {
	                    Phone phone = lPhone[1];
	                    string strPhone = phone.field;
	                    string strLabel = phone.label;
	                    phoneNumTB_2.Text = strPhone;
	                    PhoneTypeCb_2.Text = strLabel;
	                }
	                else
	                {
	                    break;
	                }
	            }//end of for
	
	            //解析邮件 只暂时显示前两个
	            List<EmailAdr> lEmailAdr = contact.emailAddresses;
	            for (int i = 0; lEmailAdr != null && i < lEmailAdr.Count; i++)
	            {
	                if (i == 0)
	                {
	                    EmailAdr emailAdr = lEmailAdr[0];
	                    string strEmail= emailAdr.field;
	                    string strLabel = emailAdr.label;
	                    EmailTB_1.Text = strEmail;
	                    EmailTypeCb_1.Text = strLabel;
	                }
	                else if (i == 1)
	                {
	                    EmailAdr emailAdr = lEmailAdr[1];
	                    string strEmail = emailAdr.field;
	                    string strLabel = emailAdr.label;
	                    EmailTB_2.Text = strEmail;
	                    EmailTypeCb_2.Text = strLabel;
	                }
	                else
	                {
	                    break;
	                }
	            }//end of for
	
	
	            //即时通讯 只暂时显示前两个
	            List<IM> lIM = contact.IMs;
	            for (int i = 0; lIM != null && i < lIM.Count; i++)
	            {
	                if (i == 0)
	                {
	                    IM im = lIM[0];
	                    string strUserName = im.field.userName;
	                    string strIMService = im.field.IMService;
	                    IMTB_1.Text = strUserName;
	                    IMTypeCb_1.Text = strIMService;
	                }
	                else if (i == 1)
	                {
	                    IM im = lIM[1];
	                    string strUserName = im.field.userName;
	                    string strIMService = im.field.IMService;
	                    IMTB_2.Text = strUserName;
	                    IMTypeCb_2.Text = strIMService;
	                }
	                else
	                {
	                    break;
	                }
	            }//end of for
	
	            //通讯地址解析，只暂时显示前两个
	            List<StreetAdr> lStreetAdr = contact.streetAddresses;
	            for (int i = 0; lStreetAdr != null && i < lStreetAdr.Count; i++)
	            {
	                if (i == 0)
	                {
	                    StreetAdr streetAdr = lStreetAdr[0];
	                    string strCountry = streetAdr.field.country;
	                    string strState = streetAdr.field.state;
	                    string strCity = streetAdr.field.city;
	                    string strStreet = streetAdr.field.street;
	
	                    string strLabel = streetAdr.label;
	
	
	                    AddrCountryTB_1.Text = strCountry;
	                    AddrProvinceTB_1.Text = strState;
	                    AddrCityTB_1.Text = strCity;
	                    AddrStreetTB_1.Text = strStreet;
	
	                    AddrTypeCb_1.Text = strLabel;
	                }
	                else if (i == 1)
	                {
	                    StreetAdr streetAdr = lStreetAdr[1];
	                    string strCountry = streetAdr.field.country;
	                    string strState = streetAdr.field.state;
	                    string strCity = streetAdr.field.city;
	                    string strStreet = streetAdr.field.street;
	
	                    string strLabel = streetAdr.label;
	
	                    AddrCountryTB_2.Text = strCountry;
	                    AddrProvinceTB_2.Text = strState;
	                    AddrCityTB_2.Text = strCity;
	                    AddrStreetTB_2.Text = strStreet;
	
	                    AddrTypeCb_2.Text = strLabel;
	                }
	                else
	                {
	                    break;
	                }         
	            }
	
	            //解析备注
	            if (contact.notes != null)
	            {
	                noteTB.Text = contact.notes;
	            }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }

        private void ContactlistBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
	            isNewContact = false;
	
	            if (ContactlistBox.SelectedIndex != -1)
	            {
	                //显示当前联系人详细信息
	                string key = this.ContactlistBox.SelectedItem.ToString();
	                if (contactDic.ContainsKey(key))
	                {
	                    Contact contact = contactDic[key];
	                    ResolveContact(contact);
	                }
	            }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }

        }

        private void newContactBtn_Click(object sender, EventArgs e)
        {
            try
            {
	            ContactlistBox.ClearSelected();
	
	            isNewContact = true;
	            ClearInterfaceData();
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }

        private void EmailTypeCb_1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
}
