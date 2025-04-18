using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClosedXML.Excel;
using System.Windows.Forms;

using System.IO;
namespace GSM.DAO
{
    public class Excell
    {
        private static Excell instance;

        public static Excell Instance
        {
            get { if (instance == null) instance = new Excell(); return Excell.instance; }
            private set { Excell.instance = value; }
        }

            public void CreateExcelFile(List<string> headers, string folderPath)
        {
            // Đảm bảo thư mục tồn tại
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            // Hộp thoại lưu file
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = folderPath;
            saveFileDialog.Filter = "Excel Files|*.xlsx";
            saveFileDialog.Title = "Đặt tên file Excel";
            saveFileDialog.FileName = "DanhSach.xlsx";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;

                using (var workbook = new XLWorkbook())
                {
                    var worksheet = workbook.Worksheets.Add("Danh sách");

                    for (int i = 0; i < headers.Count; i++)
                    {
                        var cell = worksheet.Cell(1, i + 1);
                        cell.Value = headers[i];
                        cell.Style.Font.Bold = true;
                        cell.Style.Fill.BackgroundColor = XLColor.LightBlue;
                        cell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        cell.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                        cell.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    }

                    worksheet.Columns().AdjustToContents();
                    workbook.SaveAs(filePath);
                }

                MessageBox.Show("Đã tạo file: " + filePath);

                // Mở file sau khi tạo
                Process.Start("explorer.exe", filePath);
            }
        }
        public List<string> DocDanhSachTuKhoa(string filePath) // mở txt đọc từng dòng lưu list
        {
            if (!File.Exists(filePath))
            {
                MessageBox.Show($"❌ File '{filePath}' không tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return new List<string>();
            }

            return File.ReadAllLines(filePath)
                       .Where(line => !string.IsNullOrWhiteSpace(line))
                       .Select(line => line.Trim())
                       .ToList();
        }
    }

    
}
