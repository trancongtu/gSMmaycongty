using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.ClipboardSource.SpreadsheetML;
using ClosedXML.Excel;
using GSM.DAO;
using OpenQA.Selenium;
using System.Threading;
using OpenQA.Selenium.Chrome;
using GSM.DTO;
using System.Text.RegularExpressions;
using System.Diagnostics;
using DevExpress.Internal.WinApi.Windows.UI.Notifications;
using System.Collections.ObjectModel;
namespace GSM
{
    public partial class FGroupsGSM : Form
    {
        public FGroupsGSM()
        {
            InitializeComponent();
            
        }
        string folderPath = Path.Combine(Application.StartupPath, "data", "Page");
        string keywordFillter = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "Page", "keywordFillter.txt");
        List<(string url, string name)> pageList = new List<(string, string)>();
        int sobai = 10;
        
        private void btnAdd_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Excel Files|*.xlsx";
            openFileDialog.Title = "Chọn file Excel";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
               // var pageList = new List<(string url, string name)>();

                using (var workbook = new XLWorkbook(filePath))
                {
                    var worksheet = workbook.Worksheets.Worksheet(1); // Lấy sheet đầu tiên
                    int row = 2; // Bỏ dòng tiêu đề

                    while (!worksheet.Cell(row, 2).IsEmpty())
                    {
                        string idOrUrl = worksheet.Cell(row, 2).GetString().Trim();
                        string pageName = worksheet.Cell(row, 3).GetString().Trim(); // Đọc tên page từ cột 3

                        if (!string.IsNullOrEmpty(idOrUrl))
                        {
                            pageList.Add((idOrUrl, pageName));
                        }

                        row++;
                    }
                }

                // Kiểm tra dữ liệu đọc được
                foreach (var item in pageList)
                {
                    Console.WriteLine($"URL/ID: {item.url}, Tên page: {item.name}");
                }
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            /*
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            List<string> headerList = new List<string> { "STT", "ID/URL", "Tên Page" };
            Excell.Instance.CreateExcelFile(headerList, folderPath);
            */
            FAddPage fadd = new FAddPage();
            fadd.ShowDialog();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            string profile = "C://User/trant/PycharmProject/PythonProject/ProfileTCT";
            ChromeOptions option = Libary.Instance.Options(profile);
            ChromeDriver driver = new ChromeDriver(option);
            List<PostInfo> listpost = new List<PostInfo>();
            HashSet<string> uniqueLinks = new HashSet<string>(); // Lưu URL/ID bài viết đã thu thập
            int j = 1;
            if (pageList.Count > 0)
            {
                foreach (var item in pageList)
                {
                    int postcount = 0;                  
                    driver.Url = item.url;
                    int maxpost = 1;
                    Libary.Instance.RandomTime(5000, 10000);                    
                    while (postcount < sobai && maxpost<30)
                    {
                        IWebElement timeline;
                        ReadOnlyCollection<IWebElement> posts;

                        if (item.url.Contains("groups"))
                        {
                            timeline = driver.FindElement(By.CssSelector("div[data-pagelet='GroupFeed']"));
                            posts = timeline.FindElements(By.CssSelector("div[class = 'x1n2onr6 x1ja2u2z']"));
                        } 
                        else
                        {
                            timeline = driver.FindElement(By.CssSelector("div[data-pagelet='ProfileTimeline']"));
                            posts = timeline.FindElements(By.CssSelector("div[class = 'x1yztbdb x1n2onr6 xh8yej3 x1ja2u2z']"));
                        }                       
                        foreach (var post in posts)
                        {
                            string fullcontent = "", originalContent = "", PostTime = "", originalTime = "", PostLink = "", originalPostLink = "";
                            string commentCount = "", shareCount = "";
                            (fullcontent, originalContent) = ShearchPostDAO.Instance.GetPostContent(post);
                            var posttime = post.FindElements(By.CssSelector("a[class = 'x1i10hfl xjbqb8w x1ejq31n xd10rxx x1sy0etr x17r0tee x972fbf xcfux6l x1qhh985 xm0m39n x9f619 x1ypdohk xt0psk2 xe8uvvx xdj266r x11i5rnm xat24cr x1mh8g0r xexx8yu x4uap5 x18d9i69 xkhd6sd x16tdsg8 x1hl2dhg xggy1nq x1a2a7pz x1heor9g xkrqix3 x1sur9pj x1s688f']"));
                            //var postinfor = post.FindElements(By.CssSelector("span[class='xjp7ctv'] > a"));

                            List<string> timeList = new List<string>(); // Danh sách thời gian
                            List<string> linkList = new List<string>(); // Danh sách link
                                                                        // lấy link bài viết trước
                            Regex timeRegex = new Regex(@"\b(\d+\s*(giờ|phút|ngày|hôm qua|Tháng))\b", RegexOptions.IgnoreCase);

                            foreach (var temp in posttime)
                            {
                                string textContent = temp.Text.Trim();
                                Console.WriteLine("t4ext: " + textContent);
                                if (!string.IsNullOrEmpty(textContent) && timeRegex.IsMatch(textContent))
                                {
                                    timeList.Add(textContent);

                                    // Lấy trực tiếp href từ temp
                                    string href = temp.GetAttribute("href");                               
                                    linkList.Add(href ?? ""); // Nếu không có href thì để trống
                                }
                            }                           
                            if (timeList.Count > 0)
                            {
                                if (timeList.Count == 1 && linkList.Count == 1)
                                {
                                    PostTime = timeList[0];
                                    PostLink = linkList[0];
                                }
                            }
                            if (!uniqueLinks.Add(PostLink))
                            {
                                Console.WriteLine("❌ Bỏ qua bài viết trùng: ");
                                continue;
                            }
                            else
                            {
                                maxpost++;
                                (commentCount, shareCount) = ShearchPostDAO.Instance.ExtractCommentAndShareCount(post);
                                // In ra console hoặc đưa vào danh sách
                                List<string> keywordList = new List<string>();                            
                                if (cbFilllter.Checked)
                                {
                                    keywordList = Excell.Instance.DocDanhSachTuKhoa(keywordFillter);
                                }

                                if (!cbFilllter.Checked || ShearchPostDAO.Instance.SoSanhNoiDungTuyetDoi(keywordList, fullcontent))
                                {
                                    listpost.Add(new PostInfo(PostLink, fullcontent, PostTime, shareCount, commentCount, "", "", item.name));
                                    postcount++;
                                }
                            }                          
                        }
                        if (postcount < sobai)
                        {
                            driver.ExecuteScript("window.scrollTo(0, document.body.scrollHeight)");
                            Thread.Sleep(2000); // Chờ trang load thêm bài
                        }                                         
                    }                                       
                }
                driver.Quit();
                foreach (PostInfo post in listpost)
                {
                    dataGridView1.Rows.Add(j++, post.ThoiGian, post.NoiDung, post.DiaChi, post.UserName, post.ChiaSe, post.BinhLuan, post.PageName);
                }
            }
            else MessageBox.Show("chưa chọn file lưu page");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (int.TryParse(comboBox1.SelectedItem?.ToString(), out int value))
            {
                sobai = value;
            }
            else
            {              
                MessageBox.Show("Vui lòng chọn số bài hợp lệ!");
                return;
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
          FEditPage f = new FEditPage();
            f.ShowDialog();
            }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dataGridView1.Rows.Count)
            {
                // Lấy giá trị từ cột 0 (ví dụ: cột chứa link)
                txbLinkPost.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value?.ToString();
                txbContent.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value?.ToString();           
            }
        }

        private void btnFillter_Click(object sender, EventArgs e)
        {
            if (File.Exists(keywordFillter))
            {
                Process.Start("notepad.exe", keywordFillter);
            }
            else
            {
                DialogResult result = MessageBox.Show(
        "❌ File 'keywordsFillter.txt' chưa tồn tại!\nBạn có muốn tạo file này không?",
        "Thiếu file",
        MessageBoxButtons.YesNo,
        MessageBoxIcon.Question
                );
                if (result == DialogResult.Yes)
                {
                    // Tạo file rỗng
                    File.WriteAllText(keywordFillter, "");

                    // Mở Notepad với file vừa tạo
                    Process.Start("notepad.exe", "keywordsFillter.txt");
                }
            }
            
        }
    }
}
