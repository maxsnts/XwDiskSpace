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
        //private ImageList imageList = new ImageList();
        private Dictionary<string, long> FolderSizes = new Dictionary<string, long>();
        private Stopwatch runTime = new Stopwatch();
        long totalFilesSoFar = 0;
        long totalFoldersSoFar = 0;
        long totalSpaceSoFar = 0;

        //*************************************************************************************************************
        public Main()
        {
            //imageList.Images.Add(global::XwNoNagle.Properties.Resources.nic);   //0

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
            textStartPath.Text = @"\\storage\users\Max";
#endif

            //listViewResult.SmallImageList = imageList;
            listViewResult.FullRowSelect = true;
            listViewResult.Columns.Add("Path");
            listViewResult.Columns.Add("size");
            Main_Resize(sender, e);
        }

        //*************************************************************************************************************
        private void Main_Resize(object sender, EventArgs e)
        {
            if(listViewResult.Columns.Count == 0)
                return;

            listViewResult.Columns[1].Width = 150;
            listViewResult.Columns[0].Width = listViewResult.Width - 20 - 150;
        }

        //*************************************************************************************************************
        private void AddLog(string log)
        {
            textBoxLog.AppendText(log + "\r\n");
        }

        //*************************************************************************************************************
        private long ProcessFolder(string path, int level = 0)
        {
            long folderSize = 0;
            DirectoryInfo root = null;

            if (level == 1)
            {
                BeginInvoke((Action)(() =>
                {
                    AddLog($"Entering '{path}'...");
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
                            folderSize += ProcessFolder(o.FullName, level + 1);
                        }
                        else
                        {
                            totalFilesSoFar++;
                            long fileSize = ((FileInfo)o).Length;
                            folderSize += fileSize;
                            totalSpaceSoFar += fileSize;
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
                FolderSizes.Add(path, folderSize);
                BeginInvoke((Action)(() =>
                {
                    AddLog($"Folder space: {GetFileSize(folderSize)}");
                }));
            }

            return folderSize;
        }
        
        //*************************************************************************************************************
        private string GetFileSize(double byteCount)
        {
            long m = 1024;
            double m4 = Math.Pow(m, 4);
            double m3 = Math.Pow(m, 3);
            double m2 = Math.Pow(m, 2);
            string size = "0 Bytes";
            if (byteCount == 0)
                size = "0 B";
            //else if (byteCount >= m4)
            //    size = String.Format("{0:##.00}", byteCount / m4) + " TB";
            else if (byteCount >= m3)
                size = String.Format("{0:##.00}", byteCount / m3) + " GB";
            else if (byteCount >= m2)
                size = String.Format("{0:##.00}", byteCount / m2) + " MB";
            else if (byteCount >= m)
                size = String.Format("{0:##.00}", byteCount / m) + " KB";
            else if (byteCount < m)
                size = String.Format("{0:##}", byteCount) + " B";

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

            Task.Run( () =>
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
            var ordered = FolderSizes.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
            listViewResult.Items.Clear();
            int top = 5000;
            foreach (var f in ordered)
            {
                if (top-- == 0)
                    break;
                ListViewItem item = new ListViewItem();
                item.ImageIndex = 0;
                item.Text = f.Key;
                item.SubItems.Add(GetFileSize(f.Value));
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
    }
}
