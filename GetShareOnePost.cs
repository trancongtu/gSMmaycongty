using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
using OfficeOpenXml;
using static System.Windows.Forms.LinkLabel;

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
            if (txbLinkPost.Text != "")
            {
                //int j = 1;
                string sumshare = "";
            string profile = "C://User/trant/PycharmProject/PythonProject/ProfileTCT";        
            ChromeOptions option = Libary.Instance.Options(profile);
            ChromeDriver Driver = new ChromeDriver(option);
            Driver.Url = txbLinkPost.Text;
            Libary.Instance.RandomTime(4000, 6000);
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
            Thread.Sleep(5000);
            if (sumshare != "")
            {
                int index = sumshare.IndexOf(" ");
                sumshare = sumshare.Substring(0, index);
                sumshare = Libary.Instance.xulyKshare(sumshare); // xử lý share cả nghìn
            }
            int a = Convert.ToInt32(sumshare);           
            if (a > 10) Libary.Instance.keoluotshare(Driver);
            List<PersonShare> listpersonshare = new List<PersonShare>();
            List<IWebElement> listshare = new List<IWebElement>(Driver.FindElements(By.CssSelector("div[class = 'xb57i2i x1q594ok x5lxg6s xdt5ytf x6ikm8r x1ja2u2z x1pq812k x1rohswg xfk6m8 x1yqm8si xjx87ck x1l7klhg x1iyjqo2 xs83m0k x2lwn1j xx8ngbg xwo3gff x1oyok0e x1odjw0f x1e4zzel x1n2onr6 xq1qtft x78zum5 x179dxpb']>div>div>div>div>div>div>div>div>div>div:nth-of-type(2)>div")));
            foreach (IWebElement share in listshare)
            {
                IWebElement share1 = share.FindElement(By.CssSelector("a[class = 'x1i10hfl xjbqb8w x1ejq31n xd10rxx x1sy0etr x17r0tee x972fbf xcfux6l x1qhh985 xm0m39n x9f619 x1ypdohk xt0psk2 xe8uvvx xdj266r x11i5rnm xat24cr x1mh8g0r xexx8yu x4uap5 x18d9i69 xkhd6sd x16tdsg8 x1hl2dhg xggy1nq x1a2a7pz x1heor9g xkrqix3 x1sur9pj x1s688f']"));
                if (share1 != null)
                {
                    string link = share1.GetAttribute("href");
                    string linkshare = Libary.Instance.rutgonlinkshare(link);
                    string linkfb = Libary.Instance.HrefToLinkFb(link);
                    string idfb = Libary.Instance.HrefToIdFb(link);
                    if (linkfb.IndexOf("/groups/") != -1)
                    {
                        string linkfbnew = "";
                        string idfb2 = "";
                        string linkfb2 = "";
                        IWebElement share2 = share.FindElement(By.CssSelector("a[class = 'x1i10hfl xjbqb8w x1ejq31n xd10rxx x1sy0etr x17r0tee x972fbf xcfux6l x1qhh985 xm0m39n x9f619 x1ypdohk xt0psk2 xe8uvvx xdj266r x11i5rnm xat24cr x1mh8g0r xexx8yu x4uap5 x18d9i69 xkhd6sd x16tdsg8 x1hl2dhg xggy1nq x1a2a7pz xkrqix3 x1sur9pj xzsf02u x1s688f']"));
                        linkfbnew = share2.GetAttribute("href");
                        idfb2 = Libary.Instance.HrefShareGroupsToIdFb(linkfbnew);
                        linkfb2 = "Https://Fb.com/" + idfb2;
                        listpersonshare.Add(new PersonShare(linkshare, linkfb2, idfb2));
                    }
                    else listpersonshare.Add(new PersonShare(linkshare, linkfb, idfb));

                }
            }
            int j = 1;
            foreach (PersonShare person2 in listpersonshare)
            {
                List<Person> person = new List<Person>();
                string linkfb = person2.LinkFb.ToString();
                string diachichiase = person2.DiachiShare.ToString();
                string idfb = person2.IdFb.ToString();
                if (linkfb != "")
                {

                    person = Libary.Instance.ThongtinPerson(Driver, linkfb);
                    foreach (Person per in person)
                    {
                        string songtai = per.NoiSong.ToString();
                        string dentu = per.DenTu.ToString();
                        string tenfb = per.TenFb.ToString();
                        string thongtinkhac = per.HocVan.ToString();
                        dgvGetShareOnePost.Rows.Add(j++, diachichiase, linkfb, tenfb, idfb, songtai, dentu, thongtinkhac);
                    }
                }
            }
            Driver.Quit();
        }
            else { MessageBox.Show("Chưa nhập địa chỉ bài viết"); }


        }

        private void btnSavePerson_Click(object sender, EventArgs e)
        {
          string folderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "data");
            string filePath = Path.Combine(folderPath, "data.xlsx");
            try
            {
                // Kiểm tra và tạo thư mục nếu chưa tồn tại
                ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                FileInfo fileInfo = new FileInfo(filePath);
                using (ExcelPackage package = fileInfo.Exists ? new ExcelPackage(fileInfo) : new ExcelPackage())
                {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets.Count > 0
                        ? package.Workbook.Worksheets[0]
                        : package.Workbook.Worksheets.Add("Sheet1");

                    int startRow = worksheet.Dimension?.Rows + 1 ?? 1;

                    // Nếu file mới, ghi tiêu đề cột
                    if (startRow == 1)
                    {
                        for (int i = 0; i < dgvGetShareOnePost.Columns.Count; i++)
                        {
                            worksheet.Cells[1, i + 1].Value = dgvGetShareOnePost.Columns[i].HeaderText;
                        }
                        startRow = 2;
                    }
                    // Đọc dữ liệu cột "Địa chỉ Facebook" (cột thứ 3) từ file Excel
                    HashSet<string> existingAddresses = new HashSet<string>();
                    if (worksheet.Dimension != null)
                    {
                        for (int row = 2; row <= worksheet.Dimension.Rows; row++)
                        {
                            string cellValue = worksheet.Cells[row, 3].Text.Trim();
                            if (!string.IsNullOrEmpty(cellValue))
                            {
                                existingAddresses.Add(cellValue);
                            }
                        }
                    }
                    int stt = worksheet.Dimension?.Rows - 1 ?? 0; // Tính số thứ tự từ file
                    for (int rowIndex = 0; rowIndex < dgvGetShareOnePost.Rows.Count; rowIndex++)
                    {
                        if (!dgvGetShareOnePost.Rows[rowIndex].IsNewRow)
                        {
                            string facebookAddress = dgvGetShareOnePost.Rows[rowIndex].Cells[2].Value?.ToString()?.Trim();
                            if (!string.IsNullOrEmpty(facebookAddress) && existingAddresses.Contains(facebookAddress))
                            {
                                continue; // Bỏ qua nếu đã tồn tại
                            }

                            stt++;
                            worksheet.Cells[startRow, 1].Value = stt; // Ghi số thứ tự
                            for (int colIndex = 1; colIndex < dgvGetShareOnePost.Columns.Count; colIndex++)
                            {
                                worksheet.Cells[startRow, colIndex + 1].Value = dgvGetShareOnePost.Rows[rowIndex].Cells[colIndex].Value?.ToString() ?? "";
                            }
                            startRow++;
                        }
                    }

                    package.SaveAs(fileInfo);
                }
                MessageBox.Show("Dữ liệu đã được lưu vào file Excel thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi ghi file Excel: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
