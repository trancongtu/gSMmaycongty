using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClosedXML.Excel;
using DevExpress.XtraPrinting;
using System.IO;
using System.Diagnostics;
namespace GSM
{
    public partial class FEditPage : Form
    {
        string folderPath = Path.Combine(Application.StartupPath, "data", "Page");
        List<(string url, string name)> pageList = new List<(string, string)>();
        int selectedRowIndex = -1; // dòng được trọn
        string currentExcelFilePath = "";
        public FEditPage()
        {
            InitializeComponent();
            hiendata();
        }
        public void hiendata()
        {
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Excel Files|*.xlsx";
            openFileDialog.Title = "Chọn file Excel";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                currentExcelFilePath = openFileDialog.FileName;
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
                int j = 1;
                foreach (var item in pageList)
                {
                    dataGridView1.Rows.Add(j++,item.url, item.name);
                }
            }
        }
        private void UpdateExcelFromDataGridView(string filePath)
        {
            using (var workbook = new XLWorkbook(filePath))
            {
                var worksheet = workbook.Worksheet(1);

                // Xóa toàn bộ dữ liệu cũ (trừ dòng tiêu đề nếu có)
                var lastRow = worksheet.LastRowUsed().RowNumber();
                if (lastRow > 1)
                {
                    worksheet.Rows(2, lastRow).Delete(); // Xóa từ dòng 2 trở đi
                }

                // Ghi lại dữ liệu từ DataGridView
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    var row = dataGridView1.Rows[i];
                    if (row.IsNewRow) continue;

                    int excelRow = i + 2;

                    worksheet.Cell(excelRow, 1).Value = i + 1; // STT
                    worksheet.Cell(excelRow, 2).Value = row.Cells[1].Value?.ToString(); // Link Page
                    worksheet.Cell(excelRow, 3).Value = row.Cells[2].Value?.ToString(); // Tên Page
                }
                worksheet.Columns().AdjustToContents();
                workbook.Save();
            }

            MessageBox.Show("Đã cập nhật file Excel thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dataGridView1.Rows.Count)
            {
                // Lấy giá trị từ cột 0 (ví dụ: cột chứa link)
                txbLinkPage.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value?.ToString();
                txbPageName.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value?.ToString();
                selectedRowIndex = e.RowIndex;
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (selectedRowIndex >= 0 && selectedRowIndex < dataGridView1.Rows.Count)
            {
                // Cập nhật lại nội dung trong DataGridView từ TextBox
                dataGridView1.Rows[selectedRowIndex].Cells[1].Value = txbLinkPage.Text;
                dataGridView1.Rows[selectedRowIndex].Cells[2].Value = txbPageName.Text;
                // Nếu có các TextBox khác, bạn có thể update thêm cột khác ở đây
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một dòng để chỉnh sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(currentExcelFilePath))
            {
                UpdateExcelFromDataGridView(currentExcelFilePath);
                Process.Start("explorer.exe", currentExcelFilePath);
            }
            else
            {
                MessageBox.Show("Không tìm thấy đường dẫn file Excel.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
