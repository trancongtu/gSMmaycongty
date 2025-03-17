using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using DevExpress.Utils;
using GSM.DAO;
using GSM.DTO;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace GSM
{
    public partial class FShearchPost : Form
    {
        string projectFolder = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName;
        string dataFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data");
        string keywordFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "keywords.txt");
        public FShearchPost()
        {
            InitializeComponent();
            CheckAndCreateKeywordFile();
        }
        private void CheckAndCreateKeywordFile()
        {
            // Tạo thư mục Data nếu chưa có
            if (!Directory.Exists(dataFolder))
            {
                Directory.CreateDirectory(dataFolder);
            }

            // Kiểm tra file keywords.txt
            if (!File.Exists(keywordFile))
            {
                File.WriteAllText(keywordFile, ""); // Tạo file rỗng
                MessageBox.Show("📂 Đã tạo file 'keywords.txt'. Hãy nhập từ khóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Process.Start("notepad.exe", keywordFile); // Mở Notepad
            }
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnOpenKeywords_Click(object sender, EventArgs e)
        {
            if (File.Exists(keywordFile))
            {
                Process.Start("notepad.exe", keywordFile);
            }
            else
            {
                MessageBox.Show("❌ File keywords.txt chưa tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnShreach_Click(object sender, EventArgs e)
        {
            lblStatus.Text = "🔍 Đang đọc từ khóa...";
            HashSet<string> uniqueLinks = new HashSet<string>();
            List<string[]> postsList = new List<string[]>();
            // Đọc từ khóa từ file
            if (!File.Exists(keywordFile))
            {
                MessageBox.Show("❌ Không tìm thấy file keywords.txt!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            List<string> keywords = new List<string>(File.ReadAllLines(keywordFile));
            if (keywords.Count == 0)
            {
                MessageBox.Show("❌ File keywords.txt trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Process.Start("notepad.exe", keywordFile); // Mở lại Notepad nếu trống
                return;
            }
            lblStatus.Text = "✅ Đã tải " + keywords.Count + " từ khóa.";
            // Cấu hình Selenium WebDriver
            string profile = "C://User/trant/PycharmProject/PythonProject/ProfileTCT";
            ChromeOptions option = Libary.Instance.Options(profile);
            ChromeDriver driver = new ChromeDriver(option);
            try
            {
                driver.Navigate().GoToUrl("https://www.facebook.com/");
                Thread.Sleep(3000);
                string pageSource = driver.PageSource;

                if (pageSource.Contains("Đăng nhập") || pageSource.Contains("Log in"))
                {
                    Console.WriteLine("⚠ Profile chưa đăng nhập! Kiểm tra lại đường dẫn profile.");
                }
                else
                {
                    Console.WriteLine("✅ Đã đăng nhập Facebook thành công.");
                }
                foreach (string keyword in keywords)
                {
                    WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
                    lblStatus.Text = $"🔄 Đang tìm '{keyword}'...";
                    //cấu hình bài viết
                    IWebElement searchBox = driver.FindElement(By.XPath("//input[@type='search']"));
                    searchBox.SendKeys(keyword);
                    searchBox.SendKeys(OpenQA.Selenium.Keys.Enter);
                    Thread.Sleep(5000);
                   
                    int postCount = 0;
                    //int maxPosts = 10; // Lấy tối đa 10 bài viết
                    var btnposts = driver.FindElements(By.CssSelector("span[class = 'x193iq5w xeuugli x13faqbe x1vvkbs x1xmvt09 x6prxxf xvq8zen xk50ysn xzsf02u']"));
                    foreach (var btnpost in btnposts)
                    {
                        if (btnpost.Text == "Bài viết") btnpost.Click();
                    }
                    Thread.Sleep(10000);
                    var baivietu = driver.FindElement(By.CssSelector("input[aria-label = 'Bài viết từ']"));
                    if (baivietu != null) { baivietu.Click(); }
                    Libary.Instance.RandomTime(2000, 4000);
                    var moinguoi = driver.FindElement(By.CssSelector("li[id = 'Mọi người']"));
                    if (moinguoi != null) { moinguoi.Click(); }
                    Libary.Instance.RandomTime(2000, 4000);
                    var thoigian = driver.FindElement(By.CssSelector("input[aria-label = 'Bài viết gần đây']"));
                    if (thoigian != null) { thoigian.Click(); }
                    Libary.Instance.RandomTime(2000, 4000); ;

                    // bắt đầu lấy bài viết                                    
                    int soluong = 7;
                    List<Post> listpost = new List<Post>();
                    while (postCount < soluong)
                    {            
                        Libary.Instance.RandomTime(5000, 10000);                
                        var posts = driver.FindElements(By.CssSelector("div[role='article']"));                       
                        string linkbaiviet = "";// link bài tự đăng
                        string linkshare = "";// link share lại
                        string linkgoc = "";// link bài gốc
                        string linkFb = "";// link người đăng
                        string nameFb = "";// Tên người đăng
                        string share = "";
                        string comment = "";
                        string tgdang = "";// thời gian tự đăng
                        string thoigianlinkgoc = "";// thời gian bài gốc đăng đối với bài share lại
                        string fullcontent = "";
                        string linkchot = "";// link lưu post
                        string namepage = "";// tên page được đối tượng đăng
                        string linkpage = "";
                        int trangthai = -1; // 0 tự đăng, 1 đăng page, 2 share lại bài
                        foreach (var post in posts)
                        {
                            try
                            {
                                //lấy thông tin bài đăng
                                var postinfor = post.FindElements(By.CssSelector("div[class='xu06os2 x1ok221b']"));
                                linkbaiviet = "";// link bài tự đăng
                                linkshare = "";// link share lại
                                linkgoc = "";// link bài gốc
                                linkFb = "";// link người đăng
                                nameFb = "";// Tên người đăng
                                share = "";
                                comment = "";
                                tgdang = "";// thời gian tự đăng
                                thoigianlinkgoc = "";// thời gian bài gốc đăng đối với bài share lại
                                fullcontent = "";
                                linkchot = "";// link lưu post
                                namepage = "";// tên page được đối tượng đăng
                                linkpage = "";
                                trangthai = -1;//reset trạng thái
                                int sodem = 1;
                                if (postinfor.Count >= 2)
                                {
                                    Console.WriteLine("--------------");
                                    Console.WriteLine("Bài Thứ: " + sodem++);
                                    // Thời gian đăng và xác định trạng thái//  
                                    // lấy thời gian, link bài viết
                                    var timepost = postinfor[1].FindElements(By.CssSelector("a[class = 'x1i10hfl xjbqb8w x1ejq31n xd10rxx x1sy0etr x17r0tee x972fbf xcfux6l x1qhh985 xm0m39n x9f619 x1ypdohk xt0psk2 xe8uvvx xdj266r x11i5rnm xat24cr x1mh8g0r xexx8yu x4uap5 x18d9i69 xkhd6sd x16tdsg8 x1hl2dhg xggy1nq x1a2a7pz x1heor9g xkrqix3 x1sur9pj x1s688f']"));
                                    Console.WriteLine("timpostcountL "+timepost.Count.ToString());
                                    if (timepost.Count >= 3)
                                    {
                                        Console.WriteLine("có lớn hơn 3 mốc thời gian => đăng page đủ thông tin");
                                        //bài đăng trên page
                                        tgdang = timepost[2].Text;
                                        Console.WriteLine(" thời gian đăng: " +tgdang);
                                        linkshare = timepost[2].GetAttribute("href");
                                        //linkshare = Libary.Instance.rutgonlinkshare(linkshare);
                                        Console.WriteLine(" llink share: " +linkshare);
                                        linkFb = timepost[1].GetAttribute("href");
                                        nameFb = timepost[1].Text;
                                      
                                        Console.WriteLine(" linkfb: " + linkFb + " --" +nameFb);
                                        trangthai = 1;
                                    }
                                    if(timepost.Count == 2)
                                    {
                                        Console.WriteLine("có 2 mốc thời gian => share lại");
                                        tgdang = timepost[1].Text;
                                        linkshare = timepost[1].GetAttribute("href");
                                        thoigianlinkgoc = timepost[1].Text;
                                        linkgoc = timepost[1].GetAttribute("href");
                                        trangthai = 2;
                                        //linkgoc = Libary.Instance.rutgonlinkshare(linkgoc);
                                        Console.WriteLine("link share: " + linkshare);
                                        Console.WriteLine("tên fb share: " + nameFb);
                                    }
                                    else
                                    {
                                        Console.WriteLine("có 1 mốc thời gian => đăng trang cá nhân hoặc đăng page ẩn danh");
                                        // bài đăng trang cá nhân hoặc đăng page ẩn danh
                                        trangthai = postinfor[0].FindElements(By.CssSelector("span[class='xjp7ctv'] > div > span")).Any() ? 4 : 0;
                                        tgdang = timepost.Last().Text;
                                        linkbaiviet = timepost.Last().GetAttribute("href");
                                        linkbaiviet = Libary.Instance.rutgonlinkshare(linkbaiviet);
                                        Console.WriteLine(" tg đăg: " + tgdang);
                                        Console.WriteLine(" link đăng: " + linkbaiviet);                                       
                                    }
                                    if (!string.IsNullOrEmpty(linkbaiviet)) linkchot = linkbaiviet;
                                    if (!string.IsNullOrEmpty(linkshare)) linkchot = linkshare;
                                    Console.WriteLine("link chốt: " + linkchot);
                                    // lấy tên và link Fb
                                    // cá nhân đăng lên page
                                    var personpost = postinfor[0].FindElements(By.CssSelector("span[class='xjp7ctv'] > a"));
                                    if (personpost.Count == 4) // cá nhân đăng lên page hoặc share lại có hiện thông tin
                                    {
                                        if (trangthai == 2)// trường hợp share lại
                                        {
                                           
                                            linkFb = personpost[2].GetAttribute("href");
                                            nameFb = personpost[2].Text;
                                            linkpage = personpost[4].GetAttribute("href");
                                            namepage = personpost[4].Text;
                                            Console.WriteLine("trường hợp share lại: " + linkpage + "--" + nameFb);
                                        }
                                        if(trangthai == 1)
                                     // trường hợp đăng page đủ thông tin
                                        {
                                            linkpage = personpost[3].GetAttribute("href");
                                            //linkpage = Libary.Instance.xulylinkperson2(linkFb);// link page
                                            namepage = personpost[3].Text; // Tên page  
                                            nameFb = personpost[4].Text;// tên đăng
                                            linkFb = personpost[4].GetAttribute("href");// link đăng
                                            Console.WriteLine("trường hợp đăng page: " + linkpage + "--" + namepage);
                                            Console.WriteLine("người đăng page: " + linkFb + "--" + nameFb);
                                        }
                                    }
                    
                                    if (personpost.Count == 2)
                                    {
                                        // Nếu bài cá nhân hoặc ẩn danh
                                       if(trangthai == 0)
                                        {
                                            linkFb = personpost.Last().GetAttribute("href");
                                            linkFb = Libary.Instance.xulylinkperson2(linkFb);
                                            nameFb = personpost.Last().Text;
                                            Console.WriteLine("bài cá nhân: " + linkFb + "--" + nameFb);
                                        }    
                                       
                                    }
                                    if (personpost.Count == 0)// trường hợp tag tên đường dẫn thay đổi
                                    {
                                        var personpost2 = postinfor[0].FindElements(By.CssSelector("span[class='xjp7ctv']>span>span>a"));
                                        if (personpost2.Count >= 1)
                                        {
                                            linkFb = personpost2[0].GetAttribute("href");
                                            nameFb = personpost2[0].Text;
                                            Console.WriteLine("trường hợp đặc biệt: " + linkFb + "--" + nameFb);
                                        }                                      
                                    }                                                                                                      
                                }
                                fullcontent = "";
                                if (uniqueLinks.Add(linkchot))
                                {
                                    //Lấy nội dung bài viết
                                    var contentpost = post.FindElements(By.CssSelector("span[class = 'x193iq5w xeuugli x13faqbe x1vvkbs x1xmvt09 x1lliihq x1s928wv xhkezso x1gmr53x x1cpjm7i x1fgarty x1943h6x xudqn12 x3x7a5m x6prxxf xvq8zen xo1l8bm xzsf02u x1yc453h']"));

                                    foreach (var content in contentpost)
                                    {
                                        if (content.Text.IndexOf("Xem thêm") != -1)
                                        {
                                            try
                                            {
                                                // Tìm `div[role='button']` bên trong `span` đó
                                                var seeMoreButton = content.FindElement(By.CssSelector("div[role='button']"));
                                                // Click để mở rộng nội dung
                                                //((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", seeMoreButton);
                                                Thread.Sleep(1000); // Đợi 1s trước khi click
                                                seeMoreButton.Click();
                                                Thread.Sleep(2000); // Chờ nội dung mở rộng
                                            }
                                            catch (Exception ex)
                                            {
                                                Console.WriteLine("Lỗi khi click 'Xem thêm': " + ex.Message);
                                            }
                                        }
                                        fullcontent += content.Text.Trim() + "\n";
                                    }
                                    // lấy số share
                                    var countshare = post.FindElement(By.CssSelector(" span[class = 'html-span xdj266r x11i5rnm xat24cr x1mh8g0r xexx8yu x4uap5 x18d9i69 xkhd6sd x1hl2dhg x16tdsg8 x1vvkbs xkrqix3 x1sur9pj']"));
                                    try
                                    {
                                        share = countshare.Text;
                                        share = Libary.Instance.tachsharepage(share);                                     
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine("❌ Lỗi khi lấy số bình luận bài viết: " + ex.Message);
                                    }
                                }                                                                                                 
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("❌ Lỗi khi lấy dữ liệu bài viết: " + ex.Message);
                            }
                            int luotshare = 0;
                            if (!string.IsNullOrEmpty(linkchot))
                            {      if (share != "") luotshare = Convert.ToInt32(share);       
                                listpost.Add(new Post(linkchot, fullcontent, tgdang, linkFb, nameFb,linkgoc, thoigianlinkgoc, namepage,luotshare,luotshare));
                            }
                            
                            postCount++;
                        }
                       if(postCount < soluong)
                        {
                         driver.ExecuteScript("window.scrollTo(0, document.body.scrollHeight)");
                        }    
                         
                    }
                    int j = 1;
                    foreach (Post post in listpost)
                    {
                        dataGridView1.Rows.Add(j++, post.DiaChi.ToString(), post.NoiDung.ToString(), post.LinkFb.ToString(), post.TenFb.ToString(), post.ThoiGian.ToString(), post.LinkGoc.ToString(), post.ThoiGianDangGoc.ToString(), post.NoiShare.ToString(), post.BinhLuan.ToString(), post.ChiaSe.ToString());
                    }
                }
                driver.Quit();
               
            }
            catch (Exception ex)
            {
                Console.WriteLine("❌ Lỗi khi lấy dữ liệu bài viết: " + ex.Message);
            }
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0) // Đảm bảo không click vào tiêu đề cột
    {
                // Lấy dữ liệu từ cột chứa nội dung bài viết (giả sử là cột thứ 3 - index 2)
                string content = dataGridView1.Rows[e.RowIndex].Cells[2].Value?.ToString();
                string linkbv = dataGridView1.Rows[e.RowIndex].Cells[1].Value?.ToString();
                // Gán vào TextBox
                txbcontent.Text = content;
                txblinkbv.Text = linkbv;
            }
        }
    }
}
