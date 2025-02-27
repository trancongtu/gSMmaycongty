using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.Utils;
using GSM.DAO;
using GSM.DTO;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace GSM
{
    public partial class GetShareOnePost : Form
    {
        public GetShareOnePost()
        {
            InitializeComponent();
        }

        private void btnShearch_Click(object sender, EventArgs e)
        {
            string profile = "D://CODE/Project/GSM/TCT022025";        
            ChromeOptions option = Libary.Instance.Options(profile);
            ChromeDriver Driver = new ChromeDriver(option);
            Driver.Url = txbLinkPost.Text;
            Thread.Sleep(5000);
            List<IWebElement> btnshare = new List<IWebElement>(Driver.FindElements(By.CssSelector("span[class = 'html-span xdj266r x11i5rnm xat24cr x1mh8g0r xexx8yu x4uap5 x18d9i69 xkhd6sd x1hl2dhg x16tdsg8 x1vvkbs xkrqix3 x1sur9pj']")));
            foreach (IWebElement btn in btnshare)
            {
                Console.WriteLine(btn.Text);
                string sumshare = btn.Text;
                if (sumshare.IndexOf("lượt chia sẻ") != -1)
                {
                    btn.Click();
                }
            }
            Thread.Sleep(5000);
            IWebElement fullshare = Driver.FindElement(By.CssSelector("div[class = 'xb57i2i x1q594ok x5lxg6s xdt5ytf x6ikm8r x1ja2u2z x1pq812k x1rohswg xfk6m8 x1yqm8si xjx87ck x1l7klhg x1iyjqo2 xs83m0k x2lwn1j xx8ngbg xwo3gff x1oyok0e x1odjw0f x1e4zzel x1n2onr6 xq1qtft x78zum5 x179dxpb']"));
            List<IWebElement> listshare = new List<IWebElement>(fullshare.FindElements(By.CssSelector("a[class = 'x1i10hfl xjbqb8w x1ejq31n xd10rxx x1sy0etr x17r0tee x972fbf xcfux6l x1qhh985 xm0m39n x9f619 x1ypdohk xt0psk2 xe8uvvx xdj266r x11i5rnm xat24cr x1mh8g0r xexx8yu x4uap5 x18d9i69 xkhd6sd x16tdsg8 x1hl2dhg xggy1nq x1a2a7pz x1heor9g xkrqix3 x1sur9pj x1s688f']")));
            foreach(IWebElement share in listshare)
            {   string link = share.GetAttribute("href");
                string linkshare = Libary.Instance.rutgonlinkshare(link);
                string linkfb = Libary.Instance.xulylinkperson(link);
                Console.WriteLine(linkshare);
                Console.WriteLine(linkfb);
            }    
            Driver.Quit();

            //List<PersonShare> listpersonshare = new List<PersonShare>();
            //listpersonshare = Libary.Instance.GetShareOnePost(Driver, txbLinkPost.Text);
        }
    }
}
