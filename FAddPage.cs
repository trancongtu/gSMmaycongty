using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GSM.DAO;
using System.IO;
using DocumentFormat.OpenXml.Wordprocessing;
using ClosedXML.Excel;
using System.Diagnostics;
namespace GSM
{
    public partial class FAddPage : Form
    {
        public FAddPage()
        {
            InitializeComponent();
        }
        string folderPath = Path.Combine(Application.StartupPath, "data", "Page");
        private void btnAdd_Click(object sender, EventArgs e)
        {
            string link = txbLinkPage.Text.Trim();
            string name = txbPageName.Text.Trim();
            if (string.IsNullOrEmpty(link) || string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Tính STT: bằng số dòng hiện tại + 1
            int stt = dataGridView1.Rows.Count;

            // Thêm dòng mới vào DataGridView
            dataGridView1.Rows.Add(stt++, link, name);

            // Xóa ô nhập sau khi thêm
            txbLinkPage.Clear();
            txbPageName.Clear();
            txbLinkPage.Focus();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentCell != null)
            {
                int rowIndex = dataGridView1.CurrentCell.RowIndex;

                if (rowIndex >= 0 && !dataGridView1.Rows[rowIndex].IsNewRow)
                {
                    string value = dataGridView1.Rows[rowIndex].Cells[1].Value?.ToString()?.Trim();                 
                    dataGridView1.Rows.RemoveAt(rowIndex);
                    // Cập nhật lại STT
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        if (!dataGridView1.Rows[i].IsNewRow)
                        {
                            dataGridView1.Rows[i].Cells[0].Value = (i + 1).ToString();
                        }
                    }
                }
            }    
            else
            {
                foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                {
                    if (!row.IsNewRow)
                    {
                        string value = row.Cells[1].Value?.ToString()?.Trim();
                        dataGridView1.Rows.Remove(row);
                    }
                }

                // Cập nhật lại STT
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if (!dataGridView1.Rows[i].IsNewRow)
                    {
                        dataGridView1.Rows[i].Cells[0].Value = (i + 1).ToString();
                    }
                }
            }    
               
        }

        private void BtnResult_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            List<string> headerList = new List<string> { "STT", "ID/URL", "Tên Page" };
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

                    for (int i = 0; i < headerList.Count; i++)
                    {
                        var cell = worksheet.Cell(1, i + 1);
                        cell.Value = headerList[i];
                        cell.Style.Font.Bold = true;
                        cell.Style.Fill.BackgroundColor = XLColor.LightBlue;
                        cell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        cell.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                        cell.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    }                               
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        for (int j = 0; j < dataGridView1.Columns.Count; j++)
                        {
                            Console.WriteLine("đât: " + dataGridView1.Rows[i].Cells[j].Value?.ToString());
                            worksheet.Cell(i + 2, j + 1).Value = dataGridView1.Rows[i].Cells[j].Value?.ToString();
                        }
                    }
                    worksheet.Columns().AdjustToContents();
                    workbook.SaveAs(filePath);
                }
                MessageBox.Show("Đã tạo file: " + filePath);
                // Mở file sau khi tạo
                Process.Start("explorer.exe", filePath);
            }
            
        }
    }
}
