using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using DevExpress.XtraEditors.Filtering.Templates;
using GSM.DTO;
using DevExpress.Utils;
using OpenQA.Selenium.Support.UI;
using static System.Windows.Forms.LinkLabel;
namespace GSM.DAO
{
    public class Libary
    {
    private static Libary instance;

        public static Libary Instance {
            get { if (instance == null) instance = new Libary(); return Libary.instance; }
            private set { Libary.instance = value; }
        }
       
        public ChromeDriver khoitao(string profile)
        {
            ChromeOptions option = new ChromeOptions();
            option.AddArguments("user-data-dir="+profile);
            option.AddArgument("--disable-infobars");
            option.AddArgument("start-maximized");
            option.AddArgument("--disable-extensions");
            option.AddArgument("--no-sandbox");

            //option.AddArgument("--headless"); //chạy ngầm
            ChromeDriver driver = new ChromeDriver(option);
            return driver;
        }
        public ChromeOptions Options (string profile)
        {
            ChromeOptions option = new ChromeOptions();
            option.AddArguments("user-data-dir=" + profile);
            option.AddArgument("--disable-infobars");
            option.AddArgument("start-maximized");
            option.AddArgument("--disable-extensions");

            //option.AddArgument("--headless"); //chạy ngầm
            return option;
        }
        public void RandomTime (int time1, int time2)
        {
            Random random = new Random();
            int time = random.Next(time1, time2);
            Thread.Sleep(time);
        }
    public string ConvertToCookie (string cookie)
        {
            string ConvertToCookie = "";
            string[] cookie2 = cookie.Split(';');
            return ConvertToCookie;
        }
        public List<PersonShare> GetShareOnePost(ChromeDriver Driver, string linkpost)
        {
            List<PersonShare> personshare = new List<PersonShare>();
            Driver.Url = linkpost;
            string sumshare = "";
            RandomTime(6000, 10000);
            //Driver.ExecuteScript("window.scrollTo(0, document.body.scrollHeight)");
            List<IWebElement> btnshare = new List<IWebElement>(Driver.FindElements(By.CssSelector("span[class = 'html-span xdj266r x11i5rnm xat24cr x1mh8g0r xexx8yu x4uap5 x18d9i69 xkhd6sd x1hl2dhg x16tdsg8 x1vvkbs xkrqix3 x1sur9pj']")));
            foreach (IWebElement btn in btnshare)
            {
                Console.WriteLine(btn.Text);
                sumshare = btn.Text;
                if (sumshare.IndexOf("lượt chia sẻ") != -1)
                {
                    btn.Click();
                }
            }
            RandomTime(6000, 10000);
            if (sumshare != "")
            {
                int index = sumshare.IndexOf(" ");
                sumshare = sumshare.Substring(0, index);
                if (sumshare.IndexOf("K") != -1) { sumshare = xulyKshare(sumshare); }// xử lý share cả nghìn
                
            }    
            int a = Convert.ToInt32(sumshare);
            if (a > 10)
            {
                IWebElement element2 = Driver.FindElement(By.XPath("//div[@class = 'xb57i2i x1q594ok x5lxg6s xdt5ytf x6ikm8r x1ja2u2z x1pq812k x1rohswg xfk6m8 x1yqm8si xjx87ck x1l7klhg x1iyjqo2 xs83m0k x2lwn1j xx8ngbg xwo3gff x1oyok0e x1odjw0f x1e4zzel x1n2onr6 xq1qtft x78zum5 x179dxpb']"));
                int last_count = 0;
                int new_count = 0;
                do
                {
                    Libary.Instance.RandomTime(6000, 10000);
                    //last_count = Driver.FindElements(By.XPath("//div[@class = 'xb57i2i x1q594ok x5lxg6s xdt5ytf x6ikm8r x1ja2u2z x1pq812k x1rohswg xfk6m8 x1yqm8si xjx87ck x1l7klhg x1iyjqo2 xs83m0k x2lwn1j xx8ngbg xwo3gff x1oyok0e x1odjw0f x1e4zzel x1n2onr6 xq1qtft x78zum5 x179dxpb']")).Count();
                    last_count = Driver.FindElements(By.CssSelector("div[class = 'x1yztbdb']")).Count();
                    Console.WriteLine(last_count);

                    for (int i = 0; i < 2; i++)
                    {
                        element2.SendKeys(Keys.End);
                        element2.SendKeys(Keys.Up);
                        element2.SendKeys(Keys.Up);
                        element2.SendKeys(Keys.Up);
                        element2.SendKeys(Keys.Down);
                        element2.SendKeys(Keys.Down);
                        element2.SendKeys(Keys.Down);
                        Libary.Instance.RandomTime(6000, 10000);
                    }

                    new_count = Driver.FindElements(By.CssSelector("div[class = 'x1yztbdb']")).Count();
                    Console.WriteLine(new_count);
                }
                while (last_count != new_count);
            }
            List<PersonShare> listpersonshare = new List<PersonShare>();
            IWebElement fullshare = Driver.FindElement(By.CssSelector("div[class = 'xb57i2i x1q594ok x5lxg6s xdt5ytf x6ikm8r x1ja2u2z x1pq812k x1rohswg xfk6m8 x1yqm8si xjx87ck x1l7klhg x1iyjqo2 xs83m0k x2lwn1j xx8ngbg xwo3gff x1oyok0e x1odjw0f x1e4zzel x1n2onr6 xq1qtft x78zum5 x179dxpb']"));
            List<IWebElement> listshare = new List<IWebElement>(fullshare.FindElements(By.CssSelector("a[class = 'x1i10hfl xjbqb8w x1ejq31n xd10rxx x1sy0etr x17r0tee x972fbf xcfux6l x1qhh985 xm0m39n x9f619 x1ypdohk xt0psk2 xe8uvvx xdj266r x11i5rnm xat24cr x1mh8g0r xexx8yu x4uap5 x18d9i69 xkhd6sd x16tdsg8 x1hl2dhg xggy1nq x1a2a7pz x1heor9g xkrqix3 x1sur9pj x1s688f']")));
            foreach (IWebElement share in listshare)
            {
                string link = share.GetAttribute("href");
                string linkshare = Libary.Instance.rutgonlinkshare(link);
                string linkfb = Libary.Instance.xulylinkperson(link);
                Console.WriteLine(linkshare);
                Console.WriteLine(linkfb);
                listpersonshare.Add(new PersonShare(linkshare, linkfb, ""));

            }
            return personshare;
        }
        public List<ShearchPost> GetPostOnePage(ChromeDriver Driver, string linkpost, string time, string soluong, List<ShearchPost> postsave)
        {            
            if ((Driver != null) && (linkpost != ""))
                Driver.Url = linkpost;
                Driver.Navigate();
            
            {
             
                if (soluong != "")
                {
                    int sl = Convert.ToInt32(soluong);
                    int i = postsave.Count();
                    while(i<sl)
                    {
                        Console.WriteLine(i);
                        string thoigian = "";
                        string idpost = "";
                        Driver.ExecuteScript("window.scrollTo(0, document.body.scrollHeight)");
                        RandomTime(5000, 10000);
                        //WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(20));
                        List<IWebElement> fullpost = new List<IWebElement>(Driver.FindElements(By.CssSelector("div[data-pagelet*='TimelineFeedUnit']")));
                        foreach (IWebElement element in fullpost)
                        {
                            IWebElement temp = element.FindElement(By.CssSelector("a[class*='x1sur9pj xkrqix3 x1s688f']"));
                            idpost = temp.GetAttribute("href");
                            idpost = rutgonlinkshare(idpost);
                            Console.WriteLine(idpost);
                            if(kiemtratontaipost(postsave,idpost) != 1)
                            {
                                if (temp.GetAttribute("aria-label") != null) { thoigian = temp.GetAttribute("aria-label"); }
                                string contents = "";
                                List<IWebElement> noidung = new List<IWebElement>(element.FindElements(By.CssSelector("div[class = 'xu06os2 x1ok221b']>span")));
                                foreach (IWebElement content in noidung) // lấy nội dung bài viết
                                {
                                    contents = content.Text;
                                }
                                List<IWebElement> noidunganh = new List<IWebElement>(element.FindElements(By.CssSelector("div[class = 'x6s0dn4 x78zum5 xdt5ytf x5yr21d xl56j7k x10l6tqk x17qophe x13vifvy xh8yej3']>div>div")));
                                if (noidunganh != null) // lấy chữ viết trong các bài có mầu
                                {
                                    foreach (IWebElement nda in noidunganh)
                                    {
                                        contents += nda.Text;
                                    }
                                }
                                List<IWebElement> tuongtac = new List<IWebElement>(element.FindElements(By.CssSelector("div[class = 'x9f619 x1n2onr6 x1ja2u2z x78zum5 xdt5ytf x2lah0s x193iq5w xeuugli xsyo7zv x16hj40l x10b6aqq x1yrsyyn']")));
                                string binhluan = ""; int bl = 0; int cs = 0;
                                string chiase = "";
                                foreach (IWebElement temp2 in tuongtac)
                                {
                                    if (temp2.Text.IndexOf("bình luận") != -1)
                                    {
                                        binhluan = temp2.Text;
                                        int index = binhluan.IndexOf(" ");
                                        binhluan = binhluan.Substring(0, index);
                                        if (binhluan.IndexOf("K") != -1)
                                        {
                                            binhluan = Libary.instance.xulyKshare(binhluan);
                                        }
                                        bl = Convert.ToInt32(binhluan);
                                    }
                                    if (temp2.Text.IndexOf("chia sẻ") != -1)
                                    {
                                        chiase = temp2.Text;
                                        chiase = chiase.Substring(0, chiase.IndexOf(" "));
                                        if (chiase.IndexOf("K") != -1)
                                        {
                                            chiase = Libary.instance.xulyKshare(chiase);
                                        }
                                        cs = Convert.ToInt32(chiase);
                                    }
                                }                                                                                     
                               // postsave.Add(new Post(idpost, contents, thoigian, cs, bl));
                                i++;
                            }    
                            
                        }

                    }
                }
            }
            return postsave;
        }
        public int kiemtratontaipost(List<ShearchPost> posts, string linkbv)
        {
            int temp = 0;
            if (posts.Count > 0)
            {
                foreach (ShearchPost post in posts)
                {
                    if(string.Compare(post.DiaChi.ToString(), linkbv, true) == 0) temp = 1;
                }
            }
            return temp;
        }

        public string SumShare(ChromeDriver Driver, string linkbaiviet)
        {
            string sumshare = "";
            Driver.Url = linkbaiviet;
            Libary.Instance.RandomTime(6000, 10000);
            Driver.ExecuteScript("window.scrollTo(0, document.body.scrollHeight)");
            List<IWebElement> temp = new List<IWebElement>(Driver.FindElements(By.CssSelector("span[class = 'html-span xdj266r x11i5rnm xat24cr x1mh8g0r xexx8yu x4uap5 x18d9i69 xkhd6sd x1hl2dhg x16tdsg8 x1vvkbs x1sur9pj xkrqix3']")));
            sumshare = temp[temp.Count - 1].Text;
            if (sumshare != "")
            {
                int index = sumshare.IndexOf(" ");
                sumshare = sumshare.Substring(0, index);
            }
            return sumshare;
        }
        public List<string> thongtincanhan(ChromeDriver Driver, string link)
        {            
            Driver.Url = link;
            RandomTime(5000, 10000);
            Random random = new Random();
            int ran = random.Next(1, 4);
            randomAction(Driver, ran);
            List<string> thongtin = new List<string>();
            List<IWebElement> element = new List<IWebElement>(Driver.FindElements(By.CssSelector("div[class = 'xzsf02u x6prxxf xvq8zen x126k92a']>span")));
            RandomTime(5000, 10000);
            if (element != null)
            {
                foreach (IWebElement element2 in element)
                {
                    string temp1 = element2.Text;
                    if (temp1.Contains("Sống") == true)
                    {
                        thongtin.Add("songtai");
                        int index = temp1.IndexOf("\n");
                        temp1 = temp1.Substring(index, temp1.Length - index);
                        thongtin.Add(temp1);
                    }
                    if (temp1.Contains("Đến") == true)
                    {
                        thongtin.Add("dentu");
                        int index = temp1.IndexOf("Đến từ");
                        temp1 = temp1.Substring(index + 6, temp1.Length - index - 6);
                        thongtin.Add(temp1);
                    }

                }
            }
            else { thongtin.Add(""); }
            return thongtin;
        }
        public List<Person> ThongtinPerson(ChromeDriver Driver, string link)
        {
            List<Person> person = new List<Person>();
            Driver.Url = link;
            RandomTime(5000, 10000);
            RandomActiconNew(Driver);
            string songtai = "";
            string dentu = "";
            string hocvan = "";
            string tenfb = "";
            List<IWebElement> element = new List<IWebElement>(Driver.FindElements(By.CssSelector("div[class = 'xzsf02u x6prxxf xvq8zen x126k92a']>span")));
            RandomTime(5000, 10000);
            if (element != null)
            {
                foreach (IWebElement element2 in element)
                {
                    string temp1 = element2.Text;
                    if (temp1.Contains("Sống") == true)
                    {
                        int index = temp1.IndexOf("\n");
                        temp1 = temp1.Substring(index, temp1.Length - index);
                        songtai = temp1;
                    }
                    if (temp1.Contains("Đến") == true)
                    {

                        int index = temp1.IndexOf("Đến từ");
                        temp1 = temp1.Substring(index + 6, temp1.Length - index - 6);
                        dentu = temp1;
                    }
                }

            }
            List<IWebElement> thongtinkhac = new List<IWebElement>(Driver.FindElements(By.CssSelector("div[class = 'xzsf02u x6prxxf xvq8zen x126k92a x12nagc']")));
            foreach (IWebElement tt in thongtinkhac)
            {
                hocvan += tt.Text.ToString();
            }
            List<IWebElement> tenfacebook = new List<IWebElement>(Driver.FindElements(By.CssSelector("h1[class = 'html-h1 xdj266r x11i5rnm xat24cr x1mh8g0r xexx8yu x4uap5 x18d9i69 xkhd6sd x1vvkbs x1heor9g x1qlqyl8 x1pd3egz x1a2a7pz']")));
            foreach (IWebElement ten in tenfacebook)
            {
                tenfb += ten.Text.ToString();
            }
            person.Add(new Person(-1, link, tenfb, dentu, songtai, hocvan, ""));
            return person;
        }

        public void RandomActiconNew(ChromeDriver Driver)
        {
            Random ran = new Random();
            int tam = ran.Next(2, 5);
            Console.WriteLine(tam);
            List<IWebElement> fullshare = new List<IWebElement>(Driver.FindElements(By.CssSelector("a[class = 'x1i10hfl xe8uvvx xggy1nq x1o1ewxj x3x9cwd x1e5q0jg x13rtm0m x87ps6o x1lku1pv x1a2a7pz xjyslct xjbqb8w x18o3ruo x13fuv20 xu3j5b3 x1q0q8m5 x26u7qi x972fbf xcfux6l x1qhh985 xm0m39n x9f619 x1heor9g x1ypdohk xdj266r x11i5rnm xat24cr x1mh8g0r xexx8yu x4uap5 x18d9i69 xkhd6sd x1n2onr6 x16tdsg8 x1hl2dhg x1vjfegm x3nfvp2 xrbpyxo x1itg65n x16dsc37']")));

            if (tam < fullshare.Count)
            {
                fullshare[tam].Click();
                Libary.Instance.RandomTime(3000, 5000);
            }
            fullshare[1].Click();
            IWebElement element2 = Driver.FindElement(By.LinkText("Giới thiệu"));
            if (element2 != null)
            {
                element2.Click();
            }
            Libary.Instance.RandomTime(5000, 10000);
        }
        public void randomAction(ChromeDriver Driver, int t)
        {
            if (t == 1)
            {
                IWebElement element = Driver.FindElement(By.LinkText("Bạn bè"));
                if (element != null)
                {
                    element.Click();
                }
                Libary.Instance.RandomTime(5000, 10000);
            }
            if (t == 2)
            {
                IWebElement element = Driver.FindElement(By.LinkText("Ảnh"));
                if (element != null)
                {
                    element.Click();
                }
                Libary.Instance.RandomTime(5000, 10000);
            }
            if (t == 3)
            {
                IWebElement element = Driver.FindElement(By.LinkText("Video"));
                if (element != null)
                {
                    element.Click();
                }
                Libary.Instance.RandomTime(5000, 10000);
            }
            if (t == 4)
            {
                IWebElement element = Driver.FindElement(By.LinkText("Check in"));
                if (element != null)
                {
                    element.Click();
                }
                Libary.Instance.RandomTime(5000, 10000);
            }

            IWebElement element2 = Driver.FindElement(By.LinkText("Giới thiệu"));
            if (element2 != null)
            {
                element2.Click();
            }
            Libary.Instance.RandomTime(5000, 10000);
        }
        public string xululinkshare(string link) // lấy link fb từ linkshare
        {
            string ketqua = "";
            int i = link.IndexOf("&id");
            int j = link.IndexOf("&__");
            if (i != -1 && j != -1)
            {
                link = link.Substring(i + 4, j - i - 4);
                ketqua = "https://Fb.com/" + link;

            }
            else
            {
                int index2 = link.IndexOf("/posts/");
                if (index2 != -1)
                {
                    link = link.Substring(0, index2);
                    ketqua = link.Replace("https://www.facebook.com/", "https://Fb.com/");
                }
            }
            return ketqua;
        }
        public string xulylinkperson2(string link)// rút gọn link person gốc
        {
            string ketqua = "";
            int k = link.IndexOf("?__");
            int i = link.IndexOf("&id=");
            int j = link.IndexOf("&__");
            if ((i != -1) && (j != -1))
            {
                string idfb = link.Substring(i + 4, j - i - 4);
                ketqua = "https://Fb.com/" + idfb;
            }
            if (k != -1)
             {
                ketqua = link.Substring(0, k);
            }
            return ketqua;
        }
        public string xulylinkperson(string link)// lấy linkfb từ linkshare
        {
            string ketqua = "";
            int i = link.IndexOf("&id=");
            int j = link.IndexOf("&__");
            int user = link.IndexOf("/user/");
            int index2 = link.IndexOf("?__");            
            int index1 = link.IndexOf("/posts/");
            if ((i != -1) && (j != -1))
            {
                link = link.Substring(i + 4, j - i - 4);
                ketqua = "https://Fb.com/" + link;

            }
            else
            {
                
                if ((index2 != -1)&&(index1 != -1))
                {
                    link = link.Substring(0, index1);
                    ketqua = link.Replace("https://www.facebook.com/", "https://Fb.com/");
                }
                if ((user != -1) && (index2 != -1))
                {
                    link = link.Substring(user +6, index2 - user - 7);
                    ketqua = link;
                }    
            }
            return ketqua;
        }
        public string LinkShareGroupToLinkFb (string linkshare)
        {
            string ketqua = "";

            return ketqua;
        }
        public string rutgonlinkshare(string link)
        {
            string ketqua = "";
            int index1 = link.IndexOf("/posts/");
            int user = link.IndexOf("/user/");
            int index2 = link.IndexOf("?__");
            int indexid = link.IndexOf("&id");
            int indexid2 = link.IndexOf("&__");
            if ((indexid != -1)&&(indexid2 != -1))
            {
                link = link.Substring(0, indexid2);
            }
            if ((index1 != -1) && (index2 != -1))
            {
                link = link.Substring(0, index2);              
            }
            if (index2 != -1 && user != -1) 
            { 
                link = link.Substring(0, index2-1);
            }
            ketqua = link.Replace("https://www.facebook.com/", "https://Fb.com/");
            return ketqua;
        }
        public string HrefToLinkFb(string link)
        {

            string idfb = "";
            string linkfb = "";
            int i = link.IndexOf("&id=");
            int j = link.IndexOf("&__");
            int k = link.IndexOf("?__");
            int t = link.IndexOf("/posts/");
            if ((i != -1) && (j != -1))
            {
                idfb = link.Substring(i + 4, j - i - 4);
                linkfb = "https://Fb.com/" + idfb;
            }
            if ((k != -1) && (t != -1))
            {

                linkfb = link.Substring(0, t);
            }
            return linkfb;
        }
        public string HrefToIdFb(string link)
        {
            string linkshare = "";
            string idfb = "";
            int i = link.IndexOf("&id=");
            int j = link.IndexOf("&__");
            if ((i != -1) && (j != -1))
            {
                linkshare = link.Substring(0, j);
                idfb = link.Substring(i + 4, j - i - 4);
            }
            return idfb;
        }
        public string HrefShareGroupsToIdFb(string link)
        {

            string idfb = "";

            int i = link.IndexOf("/groups/");
            int k = link.IndexOf("?__");
            int t = link.IndexOf("/user/");
            if ((i != -1) && (k != -1) && (t != -1))
            {
                idfb = link.Substring(t + 6, k - t - 7);
            }
            return idfb;
        }
        public void keoluotshare(ChromeDriver Driver)
        {
            IWebElement element2 = Driver.FindElement(By.XPath("//div[@class = 'xb57i2i x1q594ok x5lxg6s xdt5ytf x6ikm8r x1ja2u2z x1pq812k x1rohswg xfk6m8 x1yqm8si xjx87ck x1l7klhg x1iyjqo2 xs83m0k x2lwn1j xx8ngbg xwo3gff x1oyok0e x1odjw0f x1e4zzel x1n2onr6 xq1qtft x78zum5 x179dxpb']"));
            int last_count = 0;
            int new_count = 0;
            do
            {
                Libary.Instance.RandomTime(6000, 10000);
                //last_count = Driver.FindElements(By.XPath("//div[@class = 'xb57i2i x1q594ok x5lxg6s xdt5ytf x6ikm8r x1ja2u2z x1pq812k x1rohswg xfk6m8 x1yqm8si xjx87ck x1l7klhg x1iyjqo2 xs83m0k x2lwn1j xx8ngbg xwo3gff x1oyok0e x1odjw0f x1e4zzel x1n2onr6 xq1qtft x78zum5 x179dxpb']")).Count();
                last_count = Driver.FindElements(By.CssSelector("div[class = 'x1yztbdb']")).Count();
                Console.WriteLine(last_count);

                for (int i = 0; i < 2; i++)
                {
                    element2.SendKeys(Keys.End);
                    element2.SendKeys(Keys.Up);
                    element2.SendKeys(Keys.Up);
                    element2.SendKeys(Keys.Up);
                    element2.SendKeys(Keys.Down);
                    element2.SendKeys(Keys.Down);
                    element2.SendKeys(Keys.Down);
                    Libary.Instance.RandomTime(6000, 10000);
                }

                new_count = Driver.FindElements(By.CssSelector("div[class = 'x1yztbdb']")).Count();
                Console.WriteLine(new_count);
            }
            while (last_count != new_count);
        }
        public string xulyKshare(string link)
        {
            string ketqua = "";
            int phay = link.IndexOf(",");
            int nghin = link.IndexOf("K");
            if (nghin != -1)
            {
                for (int i = 0; i < link.Length; i++)
                {
                    if (link[i] != ',' && link[i] != 'K')
                    {
                        ketqua += link[i];
                    }
                }
                if (phay != -1)
                {
                    ketqua = ketqua + "00";
                }
                else ketqua = ketqua + "000";
            }
            else ketqua = link;
            return ketqua;
        }
        public string tachsharepage(string share)
        {
            if (share != "")
            {
                int index = share.IndexOf(" ");
                share= share.Substring(0, index);
            }
            string ketqua = "";
            for (int i = 0; i < share.Length; i++)
            {
                if ((share[i] != ',') && (share[i] != 'K'))
                {
                    ketqua += share[i];
                }
            }
            if (share.IndexOf("K") != -1)
            {
                if(share.IndexOf(",") != -1)
                {
                    ketqua = ketqua + "00";
                }  
                else ketqua = ketqua + "000";
            }    
       return ketqua;
        }
        public bool checkCookie(ChromeDriver driver)
        {
            driver.Navigate().GoToUrl("https://www.facebook.com/");
            Thread.Sleep(3000);
            string pageSource = driver.PageSource;

            if (pageSource.Contains("Đăng nhập") || pageSource.Contains("Log in"))
            {
                Console.WriteLine("⚠ Profile chưa đăng nhập! Kiểm tra lại đường dẫn profile.");
                return false;
            }
            else
            {
                Console.WriteLine("✅ Đã đăng nhập Facebook thành công.");
                return true;
            }
        }
    }
}
