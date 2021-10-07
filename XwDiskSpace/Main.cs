using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XwDiskSpace
{
    public partial class Main : Form
    {
        private Dictionary<string, FolderInfo> FolderSizes = new Dictionary<string, FolderInfo>();
        private Stopwatch runTime = new Stopwatch();
        long totalFilesSoFar = 0;
        long totalFoldersSoFar = 0;
        long totalSpaceSoFar = 0;

        long CurrentFolderSize = 0;
        long CurrentFolderFiles = 0;
        DateTime CurrentFolderModified = DateTime.MinValue;

        //*************************************************************************************************************
        public Main()
        {
            InitializeComponent();

            string CurrentVersion = System.Diagnostics.FileVersionInfo.GetVersionInfo(
               System.Reflection.Assembly.GetAssembly(typeof(Main)).Location).FileVersion.ToString();
            Text = $"XwDiskSpace v{CurrentVersion}";
        }

        //*************************************************************************************************************
        private void Main_Load(object sender, EventArgs e)
        {
#if DEBUG
            textStartPath.Text = @"C:\data";
#endif

            //listViewResult.SmallImageList = imageList;
            listViewResult.FullRowSelect = true;
            listViewResult.Columns.Add("Path");
            listViewResult.Columns.Add("files").TextAlign = HorizontalAlignment.Right;
            listViewResult.Columns.Add("%").TextAlign = HorizontalAlignment.Right;
            listViewResult.Columns.Add("size").TextAlign = HorizontalAlignment.Right;
            listViewResult.Columns.Add("last modified").TextAlign = HorizontalAlignment.Right;
            Main_Resize(sender, e);
        }

        //*************************************************************************************************************
        private void Main_Resize(object sender, EventArgs e)
        {
            if (listViewResult.Columns.Count == 0)
                return;

            listViewResult.Columns[4].Width = 140;
            listViewResult.Columns[3].Width = 100;
            listViewResult.Columns[2].Width = 60;
            listViewResult.Columns[1].Width = 100;
            listViewResult.Columns[0].Width = listViewResult.Width - 20 - 400;
        }

        //*************************************************************************************************************
        private void AddLog(string log, bool addNewLine = true)
        {
            textBoxLog.AppendText(log);
            if (addNewLine)
                textBoxLog.AppendText("\r\n");
        }

        //*************************************************************************************************************
        private void ProcessFolder(string path, int level = 0)
        {
            DirectoryInfo root = null;

            if (level == 1)
            {
                BeginInvoke((Action)(() =>
                {
                    AddLog($"Entering '{path}'...", false);
                }));
            }

            try
            {
                root = new DirectoryInfo(path);
                var objs = root.EnumerateFileSystemInfos();

                foreach (var o in objs)
                {
                    try
                    {
                        if (o.Attributes.HasFlag(FileAttributes.Directory))
                        {
                            totalFoldersSoFar++;
                            ProcessFolder(o.FullName, level + 1);
                        }
                        else
                        {
                            totalFilesSoFar++;
                            long fileSize = ((FileInfo)o).Length;
                            CurrentFolderSize += fileSize;
                            CurrentFolderFiles++;
                            totalSpaceSoFar += fileSize;
                            if (o.LastWriteTime > CurrentFolderModified)
                                CurrentFolderModified = o.LastWriteTime;
                        }
                    }
                    catch (Exception ex)
                    {
                        BeginInvoke((Action)(() =>
                        {
                            AddLog(o.FullName);
                            AddLog(ex.Message);
                        }));
                    }
                }
            }
            catch (Exception ex)
            {
                BeginInvoke((Action)(() =>
                {
                    AddLog(ex.Message);
                }));
            }

            if (level == 1)
            {
                FolderInfo finfo = new FolderInfo();
                finfo.Size = CurrentFolderSize;
                finfo.Files = CurrentFolderFiles;
                finfo.Modified = CurrentFolderModified;
                FolderSizes.Add(path, finfo);
                CurrentFolderSize = 0;
                CurrentFolderFiles = 0;
                CurrentFolderModified = DateTime.MinValue;
                BeginInvoke((Action)(() =>
                {
                    AddLog($"=> {GetFileSize(finfo.Size)}");
                }));
            }
        }

        //*************************************************************************************************************
        private string GetFileSize(double byteCount)
        {
            long m = 1024;
            double m4 = Math.Pow(m, 4);
            double m3 = Math.Pow(m, 3);
            double m2 = Math.Pow(m, 2);
            string size = "0 Bytes";
            if (byteCount >= m4)
                size = String.Format("{0:0.00}", byteCount / m4) + " TB";
            else if (byteCount >= m3)
                size = String.Format("{0:0.00}", byteCount / m3) + " GB";
            else if (byteCount >= m2)
                size = String.Format("{0:0.00}", byteCount / m2) + " MB";
            else if (byteCount >= m)
                size = String.Format("{0:0.00}", byteCount / m) + " KB";
            else if (byteCount < m)
                size = String.Format("{0:0}", byteCount) + " B";

            return size;
        }

        //*************************************************************************************************************
        private void buttonCalculate_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(textStartPath.Text))
            {
                MessageBox.Show("Path does not exists");
                return;
            }

            textStartPath.Enabled = false;
            buttonBrowse.Enabled = false;
            buttonCalculate.Enabled = false;
            textBoxLog.Text = "";
            listViewResult.Items.Clear();
            FolderSizes.Clear();
            totalFilesSoFar = 0;
            totalFoldersSoFar = 0;
            totalSpaceSoFar = 0;

            AddLog("Running...");
            runTime.Start();
            timerTotal.Start();
            timerGrid.Start(); ;

            Task.Run(() =>
            {
                ProcessFolder(textStartPath.Text);
                BeginInvoke((Action)(() =>
                {
                    runTime.Stop();
                    if (totalFoldersSoFar > 0)
                    {
                        AddLog(runTime.Elapsed.ToString());
                        PrintTotals();
                        UpdateTotals();
                    }
                    else
                        AddLog("Path has no subfolders");

                    AddLog("========== DONE ===========");
                    timerTotal.Stop();
                    timerGrid.Stop();
                    UpdateGrid();
                    textStartPath.Enabled = true;
                    buttonBrowse.Enabled = true;
                    buttonCalculate.Enabled = true;
                }));
            });
        }

        //*************************************************************************************************************
        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                textStartPath.Text = folderBrowserDialog1.SelectedPath;
                textBoxLog.Text = "";
                FolderSizes.Clear();
                listViewResult.Items.Clear();
            }
        }

        //*************************************************************************************************************
        private void PrintTotals()
        {
            AddLog($"Folders: {totalFoldersSoFar}, Folders: {totalFilesSoFar}, Space: {GetFileSize(totalSpaceSoFar)}");
        }

        //*************************************************************************************************************
        private void UpdateTotals()
        {
            labelTotalFolders.Text = totalFoldersSoFar.ToString();
            labelTotalFiles.Text = totalFilesSoFar.ToString();
            labelTotalSpace.Text = GetFileSize(totalSpaceSoFar);
        }

        //*************************************************************************************************************
        private void timer1_Tick(object sender, EventArgs e)
        {
            UpdateTotals();
        }

        //*************************************************************************************************************
        private void UpdateGrid()
        {
            listViewResult.SuspendLayout();
            var ordered = FolderSizes.OrderByDescending(x => x.Value.Size).ToDictionary(x => x.Key, x => x.Value);
            listViewResult.Items.Clear();
            int top = 5000;
            foreach (var f in ordered)
            {
                if (top-- == 0)
                    break;
                ListViewItem item = new ListViewItem();
                item.ImageIndex = 0;
                item.Text = f.Key;
                item.SubItems.Add(f.Value.Files.ToString());
                item.SubItems.Add(string.Format("{0:0.00} %", ((double)f.Value.Size) * 100 / totalSpaceSoFar));
                item.SubItems.Add(GetFileSize(f.Value.Size));
                item.SubItems.Add(f.Value.Modified.ToString("yyyy-MM-dd HH:mm:ss"));
                if (top % 2 != 0)
                    item.BackColor = Color.WhiteSmoke;
                listViewResult.Items.Add(item);
            }
            listViewResult.ResumeLayout();
        }

        //*************************************************************************************************************
        private void timerGrid_Tick(object sender, EventArgs e)
        {
            UpdateGrid();
        }

        //*************************************************************************************************************
        private void listViewResult_DoubleClick(object sender, EventArgs e)
        {
            if (buttonCalculate.Enabled == false)
            {
                MessageBox.Show("Wait for current operation to end");
                return;
            }

            if (listViewResult.SelectedItems.Count == 1)
            {
                var item = listViewResult.SelectedItems[0];
                textStartPath.Text = item.SubItems[0].Text;
                buttonCalculate_Click(sender, e);
            }
        }

        //*************************************************************************************************************
        private void buttonExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Text file|*.txt";
            saveFileDialog1.Title = "Export list to txt file";
            saveFileDialog1.ShowDialog();

            if (saveFileDialog1.FileName != "")
            {
                string filePath = saveFileDialog1.FileName;
                File.WriteAllText(filePath, ""); //reset

                var ordered = FolderSizes.OrderByDescending(x => x.Value.Size).ToDictionary(x => x.Key, x => x.Value);
                foreach (var f in ordered)
                {
                    string percent = string.Format("{0:0.00} %", ((double)f.Value.Size) * 100 / totalSpaceSoFar);
                    string size = GetFileSize(f.Value.Size);
                    string modified = f.Value.Modified.ToString("yyyy-MM-dd HH:mm:ss");
                    string line = $"{percent.PadLeft(8, ' ')} | {size.PadLeft(10)} | {modified} | {f.Key}\r\n";
                    File.AppendAllText(filePath, line);
                }
            }
        }

        //*************************************************************************************************************
        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Close window?", "Close...", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                e.Cancel = true;
        }
    }
}
