namespace XwDiskSpace
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.textStartPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonBrowse = new System.Windows.Forms.Button();
            this.listViewResult = new System.Windows.Forms.ListView();
            this.textBoxLog = new System.Windows.Forms.TextBox();
            this.buttonCalculate = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.timerTotal = new System.Windows.Forms.Timer(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.labelTotalFolders = new System.Windows.Forms.Label();
            this.labelTotalFiles = new System.Windows.Forms.Label();
            this.labelTotalSpace = new System.Windows.Forms.Label();
            this.timerGrid = new System.Windows.Forms.Timer(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.buttonExport = new System.Windows.Forms.Button();
            this.labelCurrentSpace = new System.Windows.Forms.Label();
            this.labelCurrentFiles = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.textInclude = new System.Windows.Forms.TextBox();
            this.textExclude = new System.Windows.Forms.TextBox();
            this.checkInclude = new System.Windows.Forms.CheckBox();
            this.checkExclude = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.labelChilds = new System.Windows.Forms.Label();
            this.timerUI = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // textStartPath
            // 
            this.textStartPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textStartPath.Location = new System.Drawing.Point(90, 11);
            this.textStartPath.Margin = new System.Windows.Forms.Padding(2);
            this.textStartPath.Name = "textStartPath";
            this.textStartPath.Size = new System.Drawing.Size(652, 20);
            this.textStartPath.TabIndex = 0;
            this.textStartPath.WordWrap = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Parent path:";
            // 
            // buttonBrowse
            // 
            this.buttonBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonBrowse.Location = new System.Drawing.Point(747, 10);
            this.buttonBrowse.Name = "buttonBrowse";
            this.buttonBrowse.Size = new System.Drawing.Size(147, 22);
            this.buttonBrowse.TabIndex = 2;
            this.buttonBrowse.Text = "Select folder";
            this.buttonBrowse.UseVisualStyleBackColor = true;
            this.buttonBrowse.Click += new System.EventHandler(this.buttonBrowse_Click);
            // 
            // listViewResult
            // 
            this.listViewResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewResult.GridLines = true;
            this.listViewResult.HideSelection = false;
            this.listViewResult.Location = new System.Drawing.Point(12, 278);
            this.listViewResult.MultiSelect = false;
            this.listViewResult.Name = "listViewResult";
            this.listViewResult.Size = new System.Drawing.Size(882, 431);
            this.listViewResult.TabIndex = 7;
            this.listViewResult.UseCompatibleStateImageBehavior = false;
            this.listViewResult.View = System.Windows.Forms.View.Details;
            this.listViewResult.DoubleClick += new System.EventHandler(this.listViewResult_DoubleClick);
            // 
            // textBoxLog
            // 
            this.textBoxLog.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxLog.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxLog.Location = new System.Drawing.Point(12, 97);
            this.textBoxLog.Multiline = true;
            this.textBoxLog.Name = "textBoxLog";
            this.textBoxLog.ReadOnly = true;
            this.textBoxLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxLog.Size = new System.Drawing.Size(882, 115);
            this.textBoxLog.TabIndex = 8;
            // 
            // buttonCalculate
            // 
            this.buttonCalculate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCalculate.Location = new System.Drawing.Point(747, 36);
            this.buttonCalculate.Name = "buttonCalculate";
            this.buttonCalculate.Size = new System.Drawing.Size(147, 51);
            this.buttonCalculate.TabIndex = 9;
            this.buttonCalculate.Text = "Get childs space";
            this.buttonCalculate.UseVisualStyleBackColor = true;
            this.buttonCalculate.Click += new System.EventHandler(this.buttonCalculate_Click);
            // 
            // timerTotal
            // 
            this.timerTotal.Interval = 500;
            this.timerTotal.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 250);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Total folders:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(262, 250);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Total file count:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(532, 250);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Total space:";
            // 
            // labelTotalFolders
            // 
            this.labelTotalFolders.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelTotalFolders.Location = new System.Drawing.Point(90, 248);
            this.labelTotalFolders.Name = "labelTotalFolders";
            this.labelTotalFolders.Size = new System.Drawing.Size(111, 17);
            this.labelTotalFolders.TabIndex = 13;
            // 
            // labelTotalFiles
            // 
            this.labelTotalFiles.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelTotalFiles.Location = new System.Drawing.Point(348, 248);
            this.labelTotalFiles.Name = "labelTotalFiles";
            this.labelTotalFiles.Size = new System.Drawing.Size(118, 17);
            this.labelTotalFiles.TabIndex = 14;
            // 
            // labelTotalSpace
            // 
            this.labelTotalSpace.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelTotalSpace.Location = new System.Drawing.Point(603, 249);
            this.labelTotalSpace.Name = "labelTotalSpace";
            this.labelTotalSpace.Size = new System.Drawing.Size(115, 17);
            this.labelTotalSpace.TabIndex = 15;
            // 
            // timerGrid
            // 
            this.timerGrid.Interval = 5000;
            this.timerGrid.Tick += new System.EventHandler(this.timerGrid_Tick);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(46, 717);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(815, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "You can double click on a item in the list to get that folder sub folders size bu" +
    "t it recalculates all the sizes. Its done this way to keep a low memory footprin" +
    "t on huge storages.";
            // 
            // buttonExport
            // 
            this.buttonExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonExport.Location = new System.Drawing.Point(779, 246);
            this.buttonExport.Name = "buttonExport";
            this.buttonExport.Size = new System.Drawing.Size(115, 22);
            this.buttonExport.TabIndex = 17;
            this.buttonExport.Text = "Export to txt file";
            this.buttonExport.UseVisualStyleBackColor = true;
            this.buttonExport.Click += new System.EventHandler(this.buttonExport_Click);
            // 
            // labelCurrentSpace
            // 
            this.labelCurrentSpace.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelCurrentSpace.Location = new System.Drawing.Point(603, 221);
            this.labelCurrentSpace.Name = "labelCurrentSpace";
            this.labelCurrentSpace.Size = new System.Drawing.Size(115, 17);
            this.labelCurrentSpace.TabIndex = 21;
            // 
            // labelCurrentFiles
            // 
            this.labelCurrentFiles.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelCurrentFiles.Location = new System.Drawing.Point(348, 221);
            this.labelCurrentFiles.Name = "labelCurrentFiles";
            this.labelCurrentFiles.Size = new System.Drawing.Size(118, 17);
            this.labelCurrentFiles.TabIndex = 20;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(532, 223);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 13);
            this.label8.TabIndex = 19;
            this.label8.Text = "Child space:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(262, 222);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(79, 13);
            this.label9.TabIndex = 18;
            this.label9.Text = "Child file count:";
            // 
            // textInclude
            // 
            this.textInclude.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textInclude.Enabled = false;
            this.textInclude.Location = new System.Drawing.Point(226, 38);
            this.textInclude.Margin = new System.Windows.Forms.Padding(2);
            this.textInclude.Name = "textInclude";
            this.textInclude.Size = new System.Drawing.Size(516, 20);
            this.textInclude.TabIndex = 22;
            this.textInclude.WordWrap = false;
            this.textInclude.TextChanged += new System.EventHandler(this.textInclude_TextChanged);
            // 
            // textExclude
            // 
            this.textExclude.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textExclude.Enabled = false;
            this.textExclude.Location = new System.Drawing.Point(226, 66);
            this.textExclude.Margin = new System.Windows.Forms.Padding(2);
            this.textExclude.Name = "textExclude";
            this.textExclude.Size = new System.Drawing.Size(516, 20);
            this.textExclude.TabIndex = 25;
            this.textExclude.WordWrap = false;
            this.textExclude.TextChanged += new System.EventHandler(this.textExclude_TextChanged);
            // 
            // checkInclude
            // 
            this.checkInclude.AutoSize = true;
            this.checkInclude.Location = new System.Drawing.Point(18, 40);
            this.checkInclude.Name = "checkInclude";
            this.checkInclude.Size = new System.Drawing.Size(199, 17);
            this.checkInclude.TabIndex = 26;
            this.checkInclude.Text = "Include only childs with name (regex)";
            this.checkInclude.UseVisualStyleBackColor = true;
            this.checkInclude.CheckedChanged += new System.EventHandler(this.checkInclude_CheckedChanged);
            // 
            // checkExclude
            // 
            this.checkExclude.AutoSize = true;
            this.checkExclude.Location = new System.Drawing.Point(18, 68);
            this.checkExclude.Name = "checkExclude";
            this.checkExclude.Size = new System.Drawing.Size(180, 17);
            this.checkExclude.TabIndex = 27;
            this.checkExclude.Text = "Exclude childs with name (regex)";
            this.checkExclude.UseVisualStyleBackColor = true;
            this.checkExclude.CheckedChanged += new System.EventHandler(this.checkExclude_CheckedChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(15, 223);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(64, 13);
            this.label10.TabIndex = 28;
            this.label10.Text = "Total childs:";
            // 
            // labelChilds
            // 
            this.labelChilds.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelChilds.Location = new System.Drawing.Point(90, 222);
            this.labelChilds.Name = "labelChilds";
            this.labelChilds.Size = new System.Drawing.Size(111, 17);
            this.labelChilds.TabIndex = 29;
            // 
            // timerUI
            // 
            this.timerUI.Enabled = true;
            this.timerUI.Tick += new System.EventHandler(this.timerUI_Tick);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(906, 739);
            this.Controls.Add(this.labelChilds);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.checkExclude);
            this.Controls.Add(this.checkInclude);
            this.Controls.Add(this.textExclude);
            this.Controls.Add(this.textInclude);
            this.Controls.Add(this.labelCurrentSpace);
            this.Controls.Add(this.labelCurrentFiles);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.buttonExport);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.labelTotalSpace);
            this.Controls.Add(this.labelTotalFiles);
            this.Controls.Add(this.labelTotalFolders);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonCalculate);
            this.Controls.Add(this.textBoxLog);
            this.Controls.Add(this.listViewResult);
            this.Controls.Add(this.buttonBrowse);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textStartPath);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "XwDiskSpace";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.Load += new System.EventHandler(this.Main_Load);
            this.Resize += new System.EventHandler(this.Main_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textStartPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonBrowse;
        private System.Windows.Forms.ListView listViewResult;
        private System.Windows.Forms.TextBox textBoxLog;
        private System.Windows.Forms.Button buttonCalculate;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Timer timerTotal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelTotalFolders;
        private System.Windows.Forms.Label labelTotalFiles;
        private System.Windows.Forms.Label labelTotalSpace;
        private System.Windows.Forms.Timer timerGrid;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button buttonExport;
        private System.Windows.Forms.Label labelCurrentSpace;
        private System.Windows.Forms.Label labelCurrentFiles;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textInclude;
        private System.Windows.Forms.TextBox textExclude;
        private System.Windows.Forms.CheckBox checkInclude;
        private System.Windows.Forms.CheckBox checkExclude;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label labelChilds;
        private System.Windows.Forms.Timer timerUI;
    }
}

