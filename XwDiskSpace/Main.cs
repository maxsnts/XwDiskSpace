using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XwDiskSpace
{
    public partial class Main : Form
    {
        private Dictionary<string, FolderInfo> FolderSizes = new Dictionary<string, FolderInfo>();
        private Stopwatch runTime = new Stopwatch();
        long totalFilesSoFar = 0;
        long totalChildsSoFar = 0;
        long totalFoldersSoFar = 0;
        long totalSpaceSoFar = 0;
        long CurrentFolderSize = 0;
        long CurrentFolderFiles = 0;
        DateTime CurrentFolderModified = DateTime.MinValue;
        StringBuilder Errors = new StringBuilder();
        string CurrentVersion = "";
        private Regex regexInclude = null;
        private Regex regexExclude = null;
        private bool Running = false;
        private bool Cancel = false;

        //****************************************************************************************************
        public Main()
        {
            InitializeComponent();
            CurrentVersion = System.Diagnostics.FileVersionInfo.GetVersionInfo(
               System.Reflection.Assembly.GetAssembly(typeof(Main)).Location).FileVersion.ToString();
            Text = $"XwDiskSpace v{CurrentVersion}";
        }

        //****************************************************************************************************
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

        //****************************************************************************************************
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

        //****************************************************************************************************
        private void AddLog(string log, bool addNewLine = true, bool error = false)
        {
            string msg = log;
            if (addNewLine)
                msg += "\r\n";

            textBoxLog.AppendText(msg);

            if (error)
                Errors.Append(msg);
        }

        //****************************************************************************************************
        private void ProcessFolder(string path, int level = 0)
        {
            DirectoryInfo root = null;

            if (level == 1)
            {
                if (checkInclude.Checked || checkExclude.Checked)
                {
                    string folderName = Path.GetFileName(path.TrimEnd(new char[] { '\\' }));
                    if (checkInclude.Checked)
                    {
                        if (!regexInclude.IsMatch(folderName))
                            return;
                    }

                    if (checkExclude.Checked)
                    {
                        if (regexExclude.IsMatch(folderName))
                            return;
                    }
                }
            
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
                            AddLog(o.FullName, true, true);
                            AddLog(ex.Message, true, true);
                        }));
                    }

                    if (Cancel)
                        return;
                }
            }
            catch (Exception ex)
            {
                BeginInvoke((Action)(() =>
                {
                    AddLog(path, true, true);
                    AddLog(ex.Message, true, true);
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
                totalChildsSoFar++;
            }
        }

        //****************************************************************************************************
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

        //****************************************************************************************************
        private void buttonCalculate_Click(object sender, EventArgs e)
        {
            if (Running)
            {
                AddLog("\r\n======== CANCELED =========", true, true);
                Cancel = true;
                return;
            }

            if (!Directory.Exists(textStartPath.Text))
            {
                MessageBox.Show("Path does not exists");
                return;
            }

            if (checkInclude.Checked)
            {
                textInclude.Text = textInclude.Text.Trim();
                
                if (textInclude.Text == string.Empty)
                {
                    checkInclude.Checked = false;
                }

                try
                {
                    regexInclude = new Regex(textInclude.Text
                        , RegexOptions.CultureInvariant | RegexOptions.IgnoreCase | RegexOptions.Compiled);
                }
                catch
                {
                    MessageBox.Show("Invalid include regex");
                    return;
                }
            }

            if (checkExclude.Checked)
            {
                textExclude.Text = textExclude.Text.Trim();
                
                if (textExclude.Text == string.Empty)
                {
                    checkExclude.Checked = false;
                }

                if (!textExclude.Text.StartsWith("(?"))
                    textExclude.Text = "(?i)" + textExclude.Text;

                try
                {
                    regexExclude = new Regex(textExclude.Text
                        , RegexOptions.CultureInvariant | RegexOptions.IgnoreCase | RegexOptions.Compiled);
                }
                catch
                {
                    MessageBox.Show("Invalid exclude regex");
                    return;
                }
            }

            textBoxLog.Text = "";
            Errors.Clear();
            listViewResult.Items.Clear();
            FolderSizes.Clear();
            totalFilesSoFar = 0;
            totalFoldersSoFar = 0;
            totalChildsSoFar = 0;
            totalSpaceSoFar = 0;

            AddLog("Running...");
            runTime.Start();
            timerTotal.Start();
            timerGrid.Start();

            Cancel = false;
            Running = true;
            Task.Run(() =>
            {
                try
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
                        
                    }));
                }
                finally
                {
                    Running = false;
                }
            });
        }

        //****************************************************************************************************
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

        //****************************************************************************************************
        private void PrintTotals()
        {
            AddLog($"Folders: {totalFoldersSoFar}, Folders: {totalFilesSoFar}, Space: {GetFileSize(totalSpaceSoFar)}");
        }

        //****************************************************************************************************
        private void UpdateTotals()
        {
            labelCurrentFiles.Text = CurrentFolderFiles.ToString();
            labelCurrentSpace.Text = GetFileSize(CurrentFolderSize);
            labelChilds.Text = totalChildsSoFar.ToString();
            labelTotalFolders.Text = totalFoldersSoFar.ToString();
            labelTotalFiles.Text = totalFilesSoFar.ToString();
            labelTotalSpace.Text = GetFileSize(totalSpaceSoFar);
        }

        //***************************************************************************************************
        private void timer1_Tick(object sender, EventArgs e)
        {
            UpdateTotals();
        }

        //****************************************************************************************************
        private void UpdateGrid()
        {
            listViewResult.BeginUpdate();
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
            listViewResult.EndUpdate();
        }

        //****************************************************************************************************
        private void timerGrid_Tick(object sender, EventArgs e)
        {
            UpdateGrid();
        }

        //****************************************************************************************************
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

        //****************************************************************************************************
        private void buttonExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Text file|*.txt";
            saveFileDialog1.Title = "Export list to txt file";
            saveFileDialog1.ShowDialog();

            if (saveFileDialog1.FileName != "")
            {
                string filePath = saveFileDialog1.FileName;
                File.WriteAllText(filePath, $" XwDiskSpace v{CurrentVersion} export file\r\n");
                File.AppendAllText(filePath, $"----------------------------------------------------------------------------\r\n");
                File.AppendAllText(filePath, $" TOTAL SPACE : {GetFileSize(totalSpaceSoFar)} in {textStartPath.Text}\r\n");
                File.AppendAllText(filePath, $"----------------------------------------------------------------------------\r\n");
                File.AppendAllText(filePath, $" Check for erros at the end of the report ... \r\n");
                File.AppendAllText(filePath, $"----------------------------------------------------------------------------\r\n");
                File.AppendAllText(filePath, $" PERCENT |    SIZE    |    LAST MODIFIED    | PATH  \r\n");
                File.AppendAllText(filePath, $"----------------------------------------------------------------------------\r\n");

                var ordered = FolderSizes.OrderByDescending(x => x.Value.Size).ToDictionary(x => x.Key, x => x.Value);
                foreach (var f in ordered)
                {
                    string percent = string.Format("{0:0.00} %", ((double)f.Value.Size) * 100 / totalSpaceSoFar);
                    string size = GetFileSize(f.Value.Size);
                    string modified = f.Value.Modified.ToString("yyyy-MM-dd HH:mm:ss");
                    string line = $"{percent.PadLeft(8, ' ')} | {size.PadLeft(10)} | {modified} | {f.Key}\r\n";
                    File.AppendAllText(filePath, line);
                }

                File.AppendAllText(filePath, $"----------------------------------------------------------------------------\r\n");
                File.AppendAllText(filePath, Errors.ToString());
            }
        }

        //****************************************************************************************************
        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Close window?", "Close...", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                e.Cancel = true;
        }

        //****************************************************************************************************
        private void checkInclude_CheckedChanged(object sender, EventArgs e)
        {
            textInclude.Enabled = checkInclude.Checked;
        }

        //****************************************************************************************************
        private void checkExclude_CheckedChanged(object sender, EventArgs e)
        {
            textExclude.Enabled = checkExclude.Checked;
        }

        //****************************************************************************************************
        private void textInclude_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Regex rgx = new Regex(textInclude.Text.Trim());
                textInclude.ForeColor = Color.Black;
            }
            catch
            {
                textInclude.ForeColor = Color.Red;
            }
        }

        //****************************************************************************************************
        private void textExclude_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Regex rgx = new Regex(textExclude.Text.Trim());
                textExclude.ForeColor = Color.Black;
            }
            catch
            {
                textExclude.ForeColor = Color.Red;
            }
        }

        //****************************************************************************************************
        private void timerUI_Tick(object sender, EventArgs e)
        {
            if (Running)
            {
                buttonCalculate.Text = "Cancel";
                textStartPath.Enabled = false;
                buttonBrowse.Enabled = false;
                checkInclude.Enabled = false;
                checkExclude.Enabled = false;
                textInclude.Enabled = false;
                textExclude.Enabled = false;
            }
            else
            {
                buttonCalculate.Text = "Get childs space";
                textStartPath.Enabled = true;
                buttonBrowse.Enabled = true;
                checkInclude.Enabled = true;
                checkExclude.Enabled = true;
                if (checkInclude.Checked)
                    textInclude.Enabled = true;
                if (checkExclude.Checked)
                    textExclude.Enabled = true;
            }
        }
    }
}
