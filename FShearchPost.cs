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
            HashSet<string> uniquePosts = new HashSet<string>();
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
                    int soluong = 3;
                    while (postCount < soluong)
                    {
                        driver.ExecuteScript("window.scrollTo(0, document.body.scrollHeight)");
                        Libary.Instance.RandomTime(5000, 10000);
                      
                        try
                        {
                            var posts = driver.FindElements(By.CssSelector("div[role='article']"));
                            foreach (var post in posts)
                            {


                                // ✅ Lấy link bài viết
                                /*var postLinkElement = post.FindElement(By.CssSelector("a[class = 'x1i10hfl xjbqb8w x1ejq31n xd10rxx x1sy0etr x17r0tee x972fbf xcfux6l x1qhh985 xm0m39n x9f619 x1ypdohk xt0psk2 xe8uvvx xdj266r x11i5rnm xat24cr x1mh8g0r xexx8yu x4uap5 x18d9i69 xkhd6sd x16tdsg8 x1hl2dhg xggy1nq x1a2a7pz x1heor9g xkrqix3 x1sur9pj x1s688f']"));
                                string linkShare = postLinkElement.GetAttribute("href");
                                Console.WriteLine(linkShare);
                                // lấy link fb
                               
                                var personpost = post.FindElements(By.CssSelector("span[class = 'xjp7ctv']>a"));
                                if (personpost.Count() > 1)
                                {
                                    foreach (var per in personpost)
                                    {
                                        string linkfb = per.GetAttribute("href");
                                        Console.WriteLine(linkfb);
                                    }
                                }
                                else
                                {
                                    string linkfb = personpost[1].GetAttribute("href");
                                    Console.WriteLine(linkfb);
                                }
                                */
                                var postLinkElement = post.FindElement(By.CssSelector("a[class = 'x1i10hfl xjbqb8w x1ejq31n xd10rxx x1sy0etr x17r0tee x972fbf xcfux6l x1qhh985 xm0m39n x9f619 x1ypdohk xt0psk2 xe8uvvx xdj266r x11i5rnm xat24cr x1mh8g0r xexx8yu x4uap5 x18d9i69 xkhd6sd x16tdsg8 x1hl2dhg xggy1nq x1a2a7pz x1heor9g xkrqix3 x1sur9pj x1s688f']"));
                                string linkShare = postLinkElement.GetAttribute("href");

                                // 2️⃣ Lấy link Facebook & tên người đăng bài
                                var personpost = post.FindElements(By.CssSelector("span[class='xjp7ctv'] > a"));

                                string linkFb = "";
                                string nameFb = "";

                                if (personpost.Count >= 4)
                                {
                                    // Nếu bài share, lấy phần tử thứ 4 (người đăng bài)
                                    linkFb = personpost[3].GetAttribute("href");
                                    nameFb = personpost[3].Text;
                                }
                                else if (personpost.Count > 0)
                                {
                                    // Nếu bài cá nhân, lấy phần tử cuối cùng
                                    linkFb = personpost.Last().GetAttribute("href");
                                    nameFb = personpost.Last().Text;
                                }
                                Console.WriteLine("linkshare: " + linkShare);
                                Console.WriteLine("linkfb: " + linkFb);
                                Console.WriteLine("tenfb: " + nameFb);
                                // 🔍 Tránh trùng lặp
                                if (uniquePosts.Contains(linkShare)) continue;
                                uniquePosts.Add(linkShare);
                                postsList.Add(new string[] { (postCount + 1).ToString(), linkShare, "", "", "", "" });
                                postCount++;
                                if (postCount >= soluong) break;
                            }           
                        }
                        catch(Exception ex)
                        {
                            Console.WriteLine("❌ Lỗi khi lấy dữ liệu bài viết: " + ex.Message);
                        }
                    }
                }
                driver.Quit();
                // hiển thị
               
            }
            catch (Exception ex)
            {
                Console.WriteLine("❌ Lỗi khi lấy dữ liệu bài viết: " + ex.Message);
            }
            
        }
    }
}
