namespace AI_FileCombiner
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.browseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tb_FolderPath = new System.Windows.Forms.TextBox();
            this.tb_FileFilter = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_Concatenate = new System.Windows.Forms.Button();
            this.numericUpDown_CharsPerPage = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_NextPage = new System.Windows.Forms.Button();
            this.btn_PrevPage = new System.Windows.Forms.Button();
            this.lbl_PageInfo = new System.Windows.Forms.Label();
            this.rtb_Output = new System.Windows.Forms.RichTextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.cb_useGitIgnoreFile = new System.Windows.Forms.CheckBox();
            this.cb_RemoveExtraSpaces = new System.Windows.Forms.CheckBox();
            this.cb_ExcludeJunk = new System.Windows.Forms.CheckBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_CharsPerPage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.browseToolStripMenuItem,
            this.copyToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(994, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // browseToolStripMenuItem
            // 
            this.browseToolStripMenuItem.Name = "browseToolStripMenuItem";
            this.browseToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.browseToolStripMenuItem.Text = "Browse";
            this.browseToolStripMenuItem.Click += new System.EventHandler(this.browseToolStripMenuItem_Click);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.copyToolStripMenuItem.Text = "Copy";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // tb_FolderPath
            // 
            this.tb_FolderPath.Location = new System.Drawing.Point(3, 16);
            this.tb_FolderPath.Name = "tb_FolderPath";
            this.tb_FolderPath.ReadOnly = true;
            this.tb_FolderPath.Size = new System.Drawing.Size(433, 20);
            this.tb_FolderPath.TabIndex = 1;
            // 
            // tb_FileFilter
            // 
            this.tb_FileFilter.Location = new System.Drawing.Point(6, 68);
            this.tb_FileFilter.Name = "tb_FileFilter";
            this.tb_FileFilter.Size = new System.Drawing.Size(100, 20);
            this.tb_FileFilter.TabIndex = 2;
            this.tb_FileFilter.TextChanged += new System.EventHandler(this.tb_FileFilter_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "File filter (*.cs):";
            // 
            // btn_Concatenate
            // 
            this.btn_Concatenate.Location = new System.Drawing.Point(862, 16);
            this.btn_Concatenate.Name = "btn_Concatenate";
            this.btn_Concatenate.Size = new System.Drawing.Size(128, 43);
            this.btn_Concatenate.TabIndex = 5;
            this.btn_Concatenate.Text = "Run";
            this.btn_Concatenate.UseVisualStyleBackColor = true;
            this.btn_Concatenate.Click += new System.EventHandler(this.btn_Concatenate_Click);
            // 
            // numericUpDown_CharsPerPage
            // 
            this.numericUpDown_CharsPerPage.Location = new System.Drawing.Point(205, 67);
            this.numericUpDown_CharsPerPage.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numericUpDown_CharsPerPage.Name = "numericUpDown_CharsPerPage";
            this.numericUpDown_CharsPerPage.Size = new System.Drawing.Size(120, 20);
            this.numericUpDown_CharsPerPage.TabIndex = 6;
            this.numericUpDown_CharsPerPage.ValueChanged += new System.EventHandler(this.numericUpDown_CharsPerPage_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(202, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Chars per page::";
            // 
            // btn_NextPage
            // 
            this.btn_NextPage.Location = new System.Drawing.Point(939, 67);
            this.btn_NextPage.Name = "btn_NextPage";
            this.btn_NextPage.Size = new System.Drawing.Size(52, 30);
            this.btn_NextPage.TabIndex = 8;
            this.btn_NextPage.Text = "=>";
            this.btn_NextPage.UseVisualStyleBackColor = true;
            this.btn_NextPage.Click += new System.EventHandler(this.btn_NextPage_Click);
            // 
            // btn_PrevPage
            // 
            this.btn_PrevPage.Location = new System.Drawing.Point(862, 68);
            this.btn_PrevPage.Name = "btn_PrevPage";
            this.btn_PrevPage.Size = new System.Drawing.Size(52, 30);
            this.btn_PrevPage.TabIndex = 9;
            this.btn_PrevPage.Text = "<=";
            this.btn_PrevPage.UseVisualStyleBackColor = true;
            this.btn_PrevPage.Click += new System.EventHandler(this.btn_PrevPage_Click);
            // 
            // lbl_PageInfo
            // 
            this.lbl_PageInfo.AutoSize = true;
            this.lbl_PageInfo.Location = new System.Drawing.Point(920, 76);
            this.lbl_PageInfo.Name = "lbl_PageInfo";
            this.lbl_PageInfo.Size = new System.Drawing.Size(13, 13);
            this.lbl_PageInfo.TabIndex = 10;
            this.lbl_PageInfo.Text = "0";
            // 
            // rtb_Output
            // 
            this.rtb_Output.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtb_Output.Location = new System.Drawing.Point(0, 0);
            this.rtb_Output.Name = "rtb_Output";
            this.rtb_Output.ReadOnly = true;
            this.rtb_Output.Size = new System.Drawing.Size(994, 430);
            this.rtb_Output.TabIndex = 11;
            this.rtb_Output.Text = "";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.cb_useGitIgnoreFile);
            this.splitContainer1.Panel1.Controls.Add(this.cb_RemoveExtraSpaces);
            this.splitContainer1.Panel1.Controls.Add(this.cb_ExcludeJunk);
            this.splitContainer1.Panel1.Controls.Add(this.btn_Concatenate);
            this.splitContainer1.Panel1.Controls.Add(this.tb_FolderPath);
            this.splitContainer1.Panel1.Controls.Add(this.tb_FileFilter);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.numericUpDown_CharsPerPage);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.lbl_PageInfo);
            this.splitContainer1.Panel1.Controls.Add(this.btn_NextPage);
            this.splitContainer1.Panel1.Controls.Add(this.btn_PrevPage);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.rtb_Output);
            this.splitContainer1.Size = new System.Drawing.Size(994, 534);
            this.splitContainer1.SplitterDistance = 100;
            this.splitContainer1.TabIndex = 12;
            // 
            // cb_useGitIgnoreFile
            // 
            this.cb_useGitIgnoreFile.AutoSize = true;
            this.cb_useGitIgnoreFile.Location = new System.Drawing.Point(489, 62);
            this.cb_useGitIgnoreFile.Name = "cb_useGitIgnoreFile";
            this.cb_useGitIgnoreFile.Size = new System.Drawing.Size(91, 17);
            this.cb_useGitIgnoreFile.TabIndex = 13;
            this.cb_useGitIgnoreFile.Text = "Use .gitignore";
            this.cb_useGitIgnoreFile.UseVisualStyleBackColor = true;
            // 
            // cb_RemoveExtraSpaces
            // 
            this.cb_RemoveExtraSpaces.AutoSize = true;
            this.cb_RemoveExtraSpaces.Location = new System.Drawing.Point(489, 39);
            this.cb_RemoveExtraSpaces.Name = "cb_RemoveExtraSpaces";
            this.cb_RemoveExtraSpaces.Size = new System.Drawing.Size(129, 17);
            this.cb_RemoveExtraSpaces.TabIndex = 12;
            this.cb_RemoveExtraSpaces.Text = "Remove extra spaces";
            this.cb_RemoveExtraSpaces.UseVisualStyleBackColor = true;
            // 
            // cb_ExcludeJunk
            // 
            this.cb_ExcludeJunk.AutoSize = true;
            this.cb_ExcludeJunk.Location = new System.Drawing.Point(489, 16);
            this.cb_ExcludeJunk.Name = "cb_ExcludeJunk";
            this.cb_ExcludeJunk.Size = new System.Drawing.Size(121, 17);
            this.cb_ExcludeJunk.TabIndex = 11;
            this.cb_ExcludeJunk.Text = "Exclude \"Junk\" files";
            this.cb_ExcludeJunk.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(994, 558);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_CharsPerPage)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem browseToolStripMenuItem;
        private System.Windows.Forms.TextBox tb_FolderPath;
        private System.Windows.Forms.TextBox tb_FileFilter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_Concatenate;
        private System.Windows.Forms.NumericUpDown numericUpDown_CharsPerPage;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_NextPage;
        private System.Windows.Forms.Button btn_PrevPage;
        private System.Windows.Forms.Label lbl_PageInfo;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.RichTextBox rtb_Output;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.CheckBox cb_RemoveExtraSpaces;
        private System.Windows.Forms.CheckBox cb_ExcludeJunk;
        private System.Windows.Forms.CheckBox cb_useGitIgnoreFile;
    }
}

