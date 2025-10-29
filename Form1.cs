using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AI_FileCombiner
{
    public partial class Form1 : Form
    {
        private string concatenatedText;
        private int charsPerPage = 0; // 0 means no pagination
        private int currentPage = 1;

        // Список исключаемых директорий и файлов
        private readonly string[] defaultExcludedDirs = { "\\bin\\", "\\obj\\", "\\.vs\\", "\\.git\\" };
        private readonly string[] defaultExcludedFiles = { "AssemblyInfo.cs" };
        private readonly string[] defaultExcludedExtensions = { ".csproj", ".user", ".sln" };


        public Form1()
        {
            InitializeComponent();
            cb_ExcludeJunk.Checked = true;
            cb_RemoveExtraSpaces.Checked = true;
            cb_useGitIgnoreFile.Checked = true;
        }

        private void browseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var folderBrowserDialog = new FolderBrowserDialog())
            {
                if (!string.IsNullOrEmpty(tb_FolderPath.Text))
                {
                    var parentDir = Directory.GetParent(tb_FolderPath.Text);
                    if (parentDir != null && parentDir.Exists)
                    {
                        folderBrowserDialog.SelectedPath = parentDir.FullName;
                    }
                    else
                    {
                        folderBrowserDialog.SelectedPath = tb_FolderPath.Text;
                    }
                }

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
                string[] filters = filterInput.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                                              .Select(f => f.Trim()).ToArray();

                if (filters.Length == 0) filters = new[] { "*" };

                List<string> allFiles = new List<string>();
                foreach (string filter in filters)
                {
                    allFiles.AddRange(Directory.GetFiles(folderPath, filter, SearchOption.AllDirectories));
                }

                // Инициализируем парсер .gitignore, если нужно. Делаем это один раз.
                var gitignoreParser = cb_useGitIgnoreFile.Checked ? new GitignoreParser(folderPath) : null;

                // Применяем все активные фильтры
                List<string> filteredFiles = allFiles.Where(file =>
                {
                    // 1. Проверяем по .gitignore, если опция включена
                    if (gitignoreParser != null && gitignoreParser.IsIgnored(file))
                    {
                        return false; // Исключаем
                    }

                    // 2. Проверяем по стандартным правилам, если опция включена
                    if (cb_ExcludeJunk.Checked && IsDefaultJunk(file))
                    {
                        return false; // Исключаем
                    }

                    return true; // Если все проверки пройдены, оставляем файл
                }).Distinct().ToList();


                StringBuilder sb = new StringBuilder();
                foreach (string file in filteredFiles)
                {
                    string relativePath = file.Substring(folderPath.Length).Replace('\\', '/');
                    if (!relativePath.StartsWith("/")) relativePath = "/" + relativePath;

                    sb.AppendLine($"// File: {relativePath}");

                    string fileContent = File.ReadAllText(file);

                    if (cb_RemoveExtraSpaces.Checked)
                    {
                        fileContent = Regex.Replace(fileContent, @"^\s+$[\r\n]*", string.Empty, RegexOptions.Multiline); // Удаляем пустые строки
                        fileContent = Regex.Replace(fileContent, @"[ \t]{2,}", " "); // Сжимаем пробелы
                    }

                    sb.Append(fileContent);
                    sb.AppendLine("\n");
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
        private bool IsDefaultJunk(string filePath)
        {
            return defaultExcludedDirs.Any(dir => filePath.IndexOf(dir, StringComparison.OrdinalIgnoreCase) >= 0) ||
                   defaultExcludedFiles.Any(f => filePath.EndsWith(f, StringComparison.OrdinalIgnoreCase)) ||
                   defaultExcludedExtensions.Any(ext => filePath.EndsWith(ext, StringComparison.OrdinalIgnoreCase));
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
                lbl_PageInfo.Visible = true;
                btn_PrevPage.Visible = true;
                btn_NextPage.Visible = true;
            }
            else
            {
                rtb_Output.Text = concatenatedText;
                lbl_PageInfo.Visible = false;
                btn_PrevPage.Visible = false;
                btn_NextPage.Visible = false;
            }
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(rtb_Output.Text))
            {
                Clipboard.SetText(rtb_Output.Text);
            }
        }

        private void btn_NextPage_Click(object sender, EventArgs e)
        {
            if (concatenatedText != null)
            {
                int totalPages = (int)Math.Ceiling((double)concatenatedText.Length / charsPerPage);
                if (currentPage < totalPages)
                {
                    currentPage++;
                    UpdateTextBox();
                }
            }
        }

        private void btn_PrevPage_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                UpdateTextBox();
            }
        }

        private void numericUpDown_CharsPerPage_ValueChanged(object sender, EventArgs e)
        {
            charsPerPage = (int)numericUpDown_CharsPerPage.Value;
            currentPage = 1;
            if (!string.IsNullOrEmpty(concatenatedText))
            {
                UpdateTextBox();
            }
        }

        private void tb_FileFilter_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
