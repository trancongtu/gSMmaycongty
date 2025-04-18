using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
        string keywordfilter = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "keywordsfilter.txt");
        private int soluong = 4;
        private string thoigian = "1 ngày";
        private int locbai = 2;
        public FShearchPost()
        {
            InitializeComponent();
            AddButtonColumn();
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
        private void AddButtonColumn()
        {
            DataGridViewButtonColumn btnColumn = new DataGridViewButtonColumn();
            btnColumn.Name = "DetailButton";  // Tên cột
            btnColumn.HeaderText = "Chi Tiết"; // Tiêu đề cột
            btnColumn.Text = "Xem"; // Văn bản hiển thị trên nút
            btnColumn.UseColumnTextForButtonValue = true; // Hiển thị text trên button
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.Columns.Add(btnColumn);
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
                if(Libary.Instance.checkCookie(driver) == true)
                {
                    foreach (string keyword in keywords)
                    {
                        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
                        lblStatus.Text = $"🔄 Đang tìm '{keyword}'...";
                        //cấu hình bài viết
                        IWebElement searchBox = driver.FindElement(By.XPath("//input[@type='search']"));
                        searchBox.SendKeys(OpenQA.Selenium.Keys.Control + "a");
                        // Gửi phím Delete để xóa nội dung đã chọn
                        searchBox.SendKeys(OpenQA.Selenium.Keys.Delete);
                        searchBox.SendKeys(keyword);
                        searchBox.SendKeys(OpenQA.Selenium.Keys.Enter);
                        Thread.Sleep(5000);
                        //------------xong phần tìm ô tìm bài
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
                        List<ShearchPost> listpost = new List<ShearchPost>();
                        while (postCount < soluong)
                        {
                            Libary.Instance.RandomTime(5000, 10000);
                            var posts = driver.FindElements(By.CssSelector("div[class= 'x9f619 x1n2onr6 x1ja2u2z']"));
                            string linkbaiviet = "";// link bài tự đăng                        
                            string linkFb = "";// link người đăng
                            string nameFb = "";// Tên người đăng
                            string shareCount = "";
                            string commentCount = "";
                            string fullcontent = "";
                            string originalContent = "";
                            string timepost = "";
                            string trangthai = ""; // 0 tự đăng, 1 đăng page, 2 share lại bài
                            string shareTime = "", originalTime = "", sharePostLink = "", originalPostLink = "";
                            string OriginalPosterLink = "";
                            string OriginalPosterName = "";
                            string PageName = "";// tên page được đối tượng đăng
                            string PageLink = "";
                            foreach (var post in posts)
                            {
                                try
                                {
                                    linkbaiviet = "N/A";// link bài tự đăng
                                    linkFb = "N/A";// link người đăng
                                    nameFb = "N/A";// Tên người đăng
                                    shareCount = "chưa có";
                                    commentCount = "chưa có";
                                    fullcontent = "N/A";
                                    originalContent = "không có";
                                    OriginalPosterLink = "N/A";
                                    OriginalPosterName = "N/A";
                                    PageName = "không";// tên page được đối tượng đăng
                                    PageLink = "không";
                                    timepost = "N/A";
                                    trangthai = "chưa xác định";//reset trạng thái
                                    int indextime = -1;
                                    int indexpost = -1;
                                   // int sodem = 1;
                                    var posttime = post.FindElements(By.CssSelector("a[class = 'x1i10hfl xjbqb8w x1ejq31n xd10rxx x1sy0etr x17r0tee x972fbf xcfux6l x1qhh985 xm0m39n x9f619 x1ypdohk xt0psk2 xe8uvvx xdj266r x11i5rnm xat24cr x1mh8g0r xexx8yu x4uap5 x18d9i69 xkhd6sd x16tdsg8 x1hl2dhg xggy1nq x1a2a7pz x1heor9g xkrqix3 x1sur9pj x1s688f']"));
                                    var postinfor = post.FindElements(By.CssSelector("span[class='xjp7ctv'] > a"));
                                    Console.WriteLine("indexpost: " + postinfor.Count.ToString());
                                    Console.WriteLine("timepost: " + posttime.Count.ToString());
                                    indextime = posttime.Count;
                                    indexpost = postinfor.Count;
                                    List<string> timeList = new List<string>(); // Danh sách thời gian
                                    List<string> linkList = new List<string>(); // Danh sách link
                                                                                // lấy link bài viết trước
                                    Regex timeRegex = new Regex(@"\b(\d+\s*(giờ|phút|ngày|hôm qua|Tháng))\b", RegexOptions.IgnoreCase);

                                    foreach (var temp in posttime)
                                    {
                                        string textContent = temp.Text.Trim();

                                        if (!string.IsNullOrEmpty(textContent) && timeRegex.IsMatch(textContent))
                                        {
                                            timeList.Add(textContent);

                                            // Lấy trực tiếp href từ temp
                                            string href = temp.GetAttribute("href");
                                            linkList.Add(href ?? ""); // Nếu không có href thì để trống
                                        }
                                    }
                                    shareTime = ""; originalTime = ""; sharePostLink = ""; originalPostLink = "";
                                    Console.WriteLine("timelistCount: " + timeList.Count.ToString());
                                    foreach (var time in timeList)
                                    {
                                        Console.WriteLine(time.ToString());
                                    }
                                    Console.WriteLine("linklistCount: " + linkList.Count.ToString());
                                    foreach (var link in linkList)
                                    {
                                        Console.WriteLine(link.ToString());
                                    }
                                    if (timeList.Count == 1) // co
                                    {
                                        // 🔸 Bài tự đăng
                                        timepost = timeList[0];
                                        linkbaiviet = linkList[0];
                                        trangthai = "Bài Cá nhân, Page đăng";
                                        linkbaiviet = ShearchPostDAO.Instance.ShortenFacebookPostLink(linkbaiviet);
                                    }
                                    else if (timeList.Count == 2)
                                    {
                                        // 🔹 Bài share
                                        shareTime = timeList[0];
                                        timepost = shareTime;
                                        originalTime = timeList[1];
                                        sharePostLink = linkList[0];
                                        originalPostLink = linkList[1];
                                        originalPostLink = ShearchPostDAO.Instance.ShortenFacebookPostLink(originalPostLink);
                                        trangthai = "bài cá nhân, page share lại";
                                        linkbaiviet = ShearchPostDAO.Instance.ShortenFacebookPostLink(sharePostLink);
                                    }
                                    Console.WriteLine("địa chỉ bv: " + linkbaiviet);
                                    Console.WriteLine("thời gian dang/share:" + timepost);
                                    Console.WriteLine("thời gian goc:" + originalTime);
                                    if (!uniqueLinks.Add(linkbaiviet))
                                    {
                                        Console.WriteLine("❌ Bỏ qua bài viết trùng: ");
                                        continue;
                                    }
                                    else //Nếu chưa có mới tiếp tục làm
                                    {
                                        switch (indextime)
                                        {
                                            case 1:
                                                if (indexpost == 1)
                                                {
                                                    Console.WriteLine("Bài cá nhân đăng kèm cảm xúc, đăng page ẩn danh");

                                                    var personpost2 = post.FindElements(By.CssSelector("span[class='xjp7ctv']>span>span>a"));
                                                    if (personpost2.Count >= 1)
                                                    {
                                                        linkFb = personpost2[0].GetAttribute("href");
                                                        linkFb = ShearchPostDAO.Instance.ShortenFacebookPostLink(linkFb);
                                                        nameFb = personpost2[0].Text;
                                                        Console.WriteLine("trường hợp cá nhân kèm cảm xúc hoặc tag tên: ");
                                                        Console.WriteLine("dia chi nguoi dang: " + linkFb);
                                                        Console.WriteLine("ten nguoi dang: " + nameFb);
                                                        trangthai = "bài đăng kèm tag";
                                                    }
                                                }
                                                if (indexpost == 2)
                                                {

                                                    Console.WriteLine("Bài cá nhân,page tự đăng");
                                                    linkFb = postinfor[1].GetAttribute("href");
                                                    linkFb = ShearchPostDAO.Instance.ShortenFacebookPostLink(linkFb);
                                                    nameFb = postinfor[1].Text;
                                                    Console.WriteLine("trường hợp cá nhân, page tự đăng: ");
                                                    Console.WriteLine("dia chi nguoi dang: " + linkFb);
                                                    Console.WriteLine("ten nguoi dang: " + nameFb);
                                                }
                                                break;
                                            case 2: //indextime =2
                                                if (indexpost == 4)
                                                {
                                                    Console.WriteLine("Share lại bài cá nhân hoặc page đăng");
                                                    OriginalPosterLink = postinfor[3].GetAttribute("href");
                                                    OriginalPosterLink = ShearchPostDAO.Instance.ShortenFacebookPostLink(OriginalPosterLink);
                                                    OriginalPosterName = postinfor[3].Text.ToString();
                                                    Console.WriteLine("trường hợp share lại: ");
                                                    Console.WriteLine("link nguoi goc: " + OriginalPosterLink);
                                                    Console.WriteLine("ten dang goc: " + OriginalPosterName);
                                                    linkFb = postinfor[1].GetAttribute("href");
                                                    linkFb = ShearchPostDAO.Instance.ShortenFacebookPostLink(linkFb);
                                                    nameFb = postinfor[1].Text;
                                                    Console.WriteLine("ca nha/page share: " + nameFb + "--" + linkFb);
                                                }
                                                if (indexpost == 6)
                                                {
                                                    Console.WriteLine("Share lại bài cá nhân/page dang len page khac");
                                                    OriginalPosterLink = postinfor[5].GetAttribute("href");
                                                    OriginalPosterLink = ShearchPostDAO.Instance.ShortenFacebookPostLink(OriginalPosterLink);
                                                    OriginalPosterName = postinfor[5].Text.ToString();
                                                    Console.WriteLine("trường hợp share lại: ");
                                                    Console.WriteLine("link nguoi goc: " + OriginalPosterLink);
                                                    Console.WriteLine("ten dang goc: " + OriginalPosterName);
                                                    linkFb = postinfor[3].GetAttribute("href");
                                                    linkFb = ShearchPostDAO.Instance.ShortenFacebookPostLink(linkFb);
                                                    nameFb = postinfor[3].Text;
                                                    PageLink = postinfor[1].GetAttribute("href");
                                                    PageLink = ShearchPostDAO.Instance.ShortenFacebookPostLink(PageLink);
                                                    PageName = postinfor[1].Text;
                                                    Console.WriteLine("ca nha/page share: " + nameFb + "--" + linkFb);
                                                }

                                                break;
                                        }
                                        // lay noi dung
                                        try
                                        {
                                            (fullcontent, originalContent) = ShearchPostDAO.Instance.GetPostContent(post);
                                        }
                                        catch (Exception ex)
                                        {
                                            Console.WriteLine("Lỗi gọi hàm GetPostContent" + ex.Message);
                                        }
                                        try
                                        {
                                            (commentCount, shareCount) = ShearchPostDAO.Instance.ExtractCommentAndShareCount(post);
                                        }
                                        catch (Exception ex)
                                        {
                                            Console.WriteLine("Lỗi gọi hàm ExtractcommentAndShareCount" + ex.Message);
                                        }

                                    }
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine("❌ Lỗi khi lấy dữ liệu bài viết: " + ex.Message);
                                }

                                //----------PHAN LỌC NỘI DUNG
                                List<string> tuKhoaTieuCuc = File.ReadAllLines(keywordfilter)
                                 .Select(x => x.Trim().ToLower())
                                 .Where(x => !string.IsNullOrEmpty(x))
                                 .ToList();
                                int diemtieucuc = 0;
                                string noiDungLower = fullcontent.ToLower();
                                foreach (var tu in tuKhoaTieuCuc)
                                {
                                    if (noiDungLower.Contains(tu))
                                    {
                                        diemtieucuc++;
                                    }
                                }
                                if (!string.IsNullOrEmpty(linkbaiviet))
                                {
                                    if (timepost.Contains("giờ") || timepost.Contains("phút"))
                                    {
                                        listpost.Add(new ShearchPost(linkbaiviet, fullcontent, timepost, linkFb, nameFb, originalPostLink, originalTime, originalContent, OriginalPosterName, OriginalPosterLink, PageLink, PageName, trangthai, shareCount, commentCount,diemtieucuc));
                                        postCount++;
                                    }
                                }
                            }
                            if (postCount < soluong)
                            {
                                driver.ExecuteScript("window.scrollTo(0, document.body.scrollHeight)");
                            }

                        }
                        var listTieuCuc = listpost
                             .Where(p => p.Chamdiem >= 0)
                             .OrderByDescending(p => p.Chamdiem)
                             .ToList();
                        int j = 1;
                        foreach (ShearchPost post in listpost)
                        {
                            int rowIndex = dataGridView1.Rows.Add(j++, post.DiaChi, post.NoiDung, post.ThoiGian, post.BinhLuan, post.ChiaSe, post.GhiChu,post.Chamdiem);
                            dataGridView1.Rows[rowIndex].Tag = post;
                        }
                    }
                    driver.Quit();
                }    
              
               
            }
            catch (Exception ex)
            {
                Console.WriteLine("❌ Lỗi khi lấy dữ liệu bài viết: " + ex.Message);
            }
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Đảm bảo không click vào tiêu đề cột
            {
                // Lấy dữ liệu từ cột chứa nội dung bài viết (giả sử là cột thứ 3 - index 2)
                string content = dataGridView1.Rows[e.RowIndex].Cells[2].Value?.ToString();
                string linkbv = dataGridView1.Rows[e.RowIndex].Cells[1].Value?.ToString();
                // Gán vào TextBox
                txbcontent.Text = content;
                txblinkbv.Text = linkbv;
            }
            if (dataGridView1.Columns[e.ColumnIndex].Name == "DetailButton" && e.RowIndex >= 0)
            {
                ShearchPost selectedPost = dataGridView1.Rows[e.RowIndex].Tag as ShearchPost;
                if (selectedPost != null)
                {
                    FDetailShearchPost detailForm = new FDetailShearchPost();
                    detailForm.SetData(
                       selectedPost.DiaChi,
                       selectedPost.ChiaSe,
                       selectedPost.BinhLuan,
                       selectedPost.ThoiGian,
                       selectedPost.TenFb,
                       selectedPost.LinkFb,
                       selectedPost.NamePage,
                       selectedPost.LinkPage,
                       selectedPost.Noidunggoc,
                       selectedPost.NoiDung,
                       selectedPost.LinkGoc,
                       selectedPost.ThoiGianDangGoc,
                       selectedPost.OriginalName,
                       selectedPost.OriginalLink,
                       selectedPost.GhiChu
                    );
                    detailForm.ShowDialog();
                }
            }
        }

        private void btnKeywordfilter_Click(object sender, EventArgs e)
        {

            if (File.Exists(keywordfilter))
            {
                Process.Start("notepad.exe", keywordfilter);
            }
            else
            {
                MessageBox.Show("❌ File keywords.txt chưa tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void CbLocNoidung_CheckedChanged(object sender, EventArgs e)
        {
            if (!File.Exists(keywordfilter))
            {
                File.WriteAllText(keywordfilter, ""); // Tạo file rỗng
                MessageBox.Show("📂 Đã tạo file 'keywords.txt'. Hãy nhập từ khóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Process.Start("notepad.exe", keywordfilter); // Mở Notepad
            }
        }
    }
}
