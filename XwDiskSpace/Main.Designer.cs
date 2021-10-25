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
            this.SuspendLayout();
            // 
            // textStartPath
            // 
            this.textStartPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textStartPath.Location = new System.Drawing.Point(98, 21);
            this.textStartPath.Margin = new System.Windows.Forms.Padding(4);
            this.textStartPath.Name = "textStartPath";
            this.textStartPath.Size = new System.Drawing.Size(1338, 31);
            this.textStartPath.TabIndex = 0;
            this.textStartPath.WordWrap = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 27);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Path:";
            // 
            // buttonBrowse
            // 
            this.buttonBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonBrowse.Location = new System.Drawing.Point(1450, 19);
            this.buttonBrowse.Margin = new System.Windows.Forms.Padding(6);
            this.buttonBrowse.Name = "buttonBrowse";
            this.buttonBrowse.Size = new System.Drawing.Size(48, 42);
            this.buttonBrowse.TabIndex = 2;
            this.buttonBrowse.Text = "...";
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
            this.listViewResult.Location = new System.Drawing.Point(24, 463);
            this.listViewResult.Margin = new System.Windows.Forms.Padding(6);
            this.listViewResult.MultiSelect = false;
            this.listViewResult.Name = "listViewResult";
            this.listViewResult.Size = new System.Drawing.Size(1776, 854);
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
            this.textBoxLog.Location = new System.Drawing.Point(24, 73);
            this.textBoxLog.Margin = new System.Windows.Forms.Padding(6);
            this.textBoxLog.Multiline = true;
            this.textBoxLog.Name = "textBoxLog";
            this.textBoxLog.ReadOnly = true;
            this.textBoxLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxLog.Size = new System.Drawing.Size(1776, 283);
            this.textBoxLog.TabIndex = 8;
            // 
            // buttonCalculate
            // 
            this.buttonCalculate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCalculate.Location = new System.Drawing.Point(1510, 19);
            this.buttonCalculate.Margin = new System.Windows.Forms.Padding(6);
            this.buttonCalculate.Name = "buttonCalculate";
            this.buttonCalculate.Size = new System.Drawing.Size(294, 42);
            this.buttonCalculate.TabIndex = 9;
            this.buttonCalculate.Text = "Get Subfolders Space";
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
            this.label2.Location = new System.Drawing.Point(30, 424);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 25);
            this.label2.TabIndex = 10;
            this.label2.Text = "Total folders:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(525, 424);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(159, 25);
            this.label3.TabIndex = 11;
            this.label3.Text = "Total file count:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1064, 424);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(130, 25);
            this.label4.TabIndex = 12;
            this.label4.Text = "Total space:";
            // 
            // labelTotalFolders
            // 
            this.labelTotalFolders.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelTotalFolders.Location = new System.Drawing.Point(179, 420);
            this.labelTotalFolders.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelTotalFolders.Name = "labelTotalFolders";
            this.labelTotalFolders.Size = new System.Drawing.Size(222, 33);
            this.labelTotalFolders.TabIndex = 13;
            // 
            // labelTotalFiles
            // 
            this.labelTotalFiles.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelTotalFiles.Location = new System.Drawing.Point(696, 420);
            this.labelTotalFiles.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelTotalFiles.Name = "labelTotalFiles";
            this.labelTotalFiles.Size = new System.Drawing.Size(235, 33);
            this.labelTotalFiles.TabIndex = 14;
            // 
            // labelTotalSpace
            // 
            this.labelTotalSpace.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelTotalSpace.Location = new System.Drawing.Point(1206, 421);
            this.labelTotalSpace.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelTotalSpace.Name = "labelTotalSpace";
            this.labelTotalSpace.Size = new System.Drawing.Size(230, 33);
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
            this.label5.Location = new System.Drawing.Point(92, 1337);
            this.label5.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(1662, 25);
            this.label5.TabIndex = 16;
            this.label5.Text = "You can double click on a item in the list to get that folder sub folders size bu" +
    "t it recalculates all the sizes. Its done this way to keep a low memory footprin" +
    "t on huge storages.";
            // 
            // buttonExport
            // 
            this.buttonExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonExport.Location = new System.Drawing.Point(1574, 415);
            this.buttonExport.Margin = new System.Windows.Forms.Padding(6);
            this.buttonExport.Name = "buttonExport";
            this.buttonExport.Size = new System.Drawing.Size(230, 42);
            this.buttonExport.TabIndex = 17;
            this.buttonExport.Text = "Export to txt file";
            this.buttonExport.UseVisualStyleBackColor = true;
            this.buttonExport.Click += new System.EventHandler(this.buttonExport_Click);
            // 
            // labelCurrentSpace
            // 
            this.labelCurrentSpace.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelCurrentSpace.Location = new System.Drawing.Point(1206, 368);
            this.labelCurrentSpace.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelCurrentSpace.Name = "labelCurrentSpace";
            this.labelCurrentSpace.Size = new System.Drawing.Size(230, 33);
            this.labelCurrentSpace.TabIndex = 21;
            // 
            // labelCurrentFiles
            // 
            this.labelCurrentFiles.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelCurrentFiles.Location = new System.Drawing.Point(696, 367);
            this.labelCurrentFiles.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelCurrentFiles.Name = "labelCurrentFiles";
            this.labelCurrentFiles.Size = new System.Drawing.Size(235, 33);
            this.labelCurrentFiles.TabIndex = 20;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(1041, 369);
            this.label8.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(153, 25);
            this.label8.TabIndex = 19;
            this.label8.Text = "Current space:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(502, 369);
            this.label9.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(182, 25);
            this.label9.TabIndex = 18;
            this.label9.Text = "Current file count:";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1828, 1379);
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
            this.Margin = new System.Windows.Forms.Padding(4);
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
    }
}

