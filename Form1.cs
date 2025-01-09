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

namespace AI_FileCombiner
{
    public partial class Form1 : Form
    {
        private string concatenatedText;
        private int charsPerPage = 0; // 0 means no pagination
        private int currentPage = 1;
        public Form1()
        {
            InitializeComponent();
        }

        private void browseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var folderBrowserDialog = new FolderBrowserDialog())
            {
                if (!string.IsNullOrEmpty(tb_FolderPath.Text)) 
                    folderBrowserDialog.SelectedPath = tb_FolderPath.Text;
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    tb_FolderPath.Text = folderBrowserDialog.SelectedPath;
                }
            }
        }

        private void btn_Concatenate_Click(object sender, EventArgs e)
        {
            string folderPath = tb_FolderPath.Text;
            string filterInput = tb_FileFilter.Text;
            charsPerPage = (int)numericUpDown_CharsPerPage.Value;

            if (string.IsNullOrEmpty(folderPath) || !Directory.Exists(folderPath))
            {
                MessageBox.Show("Укажите корректный путь к папке.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // Split the input string by commas to get multiple filters
                string[] filters = filterInput.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                                          .Select(f => f.Trim()).ToArray();

                List<string> allFiles = new List<string>();

                // If no filters are provided, get all files
                if (filters.Length == 0 || (filters.Length == 1 && string.IsNullOrEmpty(filters[0])))
                {
                    allFiles.AddRange(Directory.GetFiles(folderPath, "*", SearchOption.AllDirectories));
                }
                else
                {
                    foreach (string filter in filters)
                    {
                        try
                        {
                            allFiles.AddRange(Directory.GetFiles(folderPath, filter, SearchOption.AllDirectories));
                        }
                        catch (ArgumentException ex)
                        {
                            MessageBox.Show($"Неверный шаблон поиска: {filter}. Ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }

                // Remove duplicate file paths if any filter matches the same file
                allFiles = allFiles.Distinct().ToList();

                StringBuilder sb = new StringBuilder();
                foreach (string file in allFiles)
                {
                    sb.Append(File.ReadAllText(file));
                    sb.AppendLine(); // Add a newline between files
                }

                concatenatedText = sb.ToString();
                currentPage = 1;
                UpdateTextBox();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при чтении файлов: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void UpdateTextBox()
        {
            if (charsPerPage > 0 && concatenatedText.Length > charsPerPage)
            {
                int startIndex = (currentPage - 1) * charsPerPage;
                int endIndex = Math.Min(startIndex + charsPerPage, concatenatedText.Length);
                rtb_Output.Text = concatenatedText.Substring(startIndex, endIndex - startIndex);

                btn_PrevPage.Enabled = currentPage > 1;
                btn_NextPage.Enabled = endIndex < concatenatedText.Length;

                lbl_PageInfo.Text = $"{currentPage}";
                lbl_PageInfo.Visible = true; // Show page info

                btn_PrevPage.Visible = true;
                btn_NextPage.Visible = true;

            }
            else
            {
                rtb_Output.Text = concatenatedText;

                lbl_PageInfo.Visible = false; // Hide page info if no pagination
                btn_PrevPage.Visible = false;
                btn_NextPage.Visible = false;
            }

        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(rtb_Output.Text);
        }

        private void btn_NextPage_Click(object sender, EventArgs e)
        {
            currentPage++;
            UpdateTextBox();
        }

        private void btn_PrevPage_Click(object sender, EventArgs e)
        {
            currentPage--;
            UpdateTextBox();
        }

        private void numericUpDown_CharsPerPage_ValueChanged(object sender, EventArgs e)
        {
            // Recalculate pagination if the chars per page value is changed
            currentPage = 1;
            UpdateTextBox();
        }

        private void tb_FileFilter_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
