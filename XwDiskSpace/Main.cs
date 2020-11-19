using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XwDiskSpace
{
    public partial class Main : Form
    {
        private ImageList imageList = new ImageList();
        private Dictionary<string, long> FolderSizes = new Dictionary<string, long>();
        private Stopwatch runTime = new Stopwatch();
        
        //*************************************************************************************************************
        public Main()
        {
            //            imageList.Images.Add(global::XwNoNagle.Properties.Resources.nic);   //0

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

            listViewResult.SmallImageList = imageList;
            listViewResult.FullRowSelect = true;
            listViewResult.Columns.Add("name");
            listViewResult.Columns.Add("zone");
            listViewResult.Columns.Add("type");
            listViewResult.Columns.Add("value");
            Main_Resize(sender, e);
        }

        //*************************************************************************************************************
        private void Main_Resize(object sender, EventArgs e)
        {
            if(listViewResult.Columns.Count == 0)
                return;

            listViewResult.Columns[0].Width = 200;
            listViewResult.Columns[1].Width = 200;
            listViewResult.Columns[2].Width = 100;
            listViewResult.Columns[3].Width = listViewResult.Width - 20 - 500;
        }

        //*************************************************************************************************************
        private void AddLog(string log)
        {
            textBoxLog.AppendText(log + "\r\n");
            Refresh();
        }

        //*************************************************************************************************************
        private long ProcessFolder(string path, int level = 0)
        {
            long folderSize = 0;
            DirectoryInfo root = null;

            try
            {
                root = new DirectoryInfo(path);
                var objs = root.EnumerateFileSystemInfos();
                foreach (var o in objs)
                {
                    if (o.Attributes.HasFlag(FileAttributes.Directory))
                    {
                        folderSize += ProcessFolder(o.FullName, level + 1);
                    }
                    
                    if (o.Attributes.HasFlag(FileAttributes.Archive))
                    {
                        folderSize += ((FileInfo)o).Length;
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

            /*
            try
            {
                root = new DirectoryInfo(path);
                var files = root.EnumerateFiles();
                foreach (FileInfo file in files)
                {
                    try
                    {
                        folderSize += file.Length;
                    }
                    catch (Exception ex)
                    {
                        AddLog(ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                AddLog(ex.Message);
            }
            
            try
            { 
                var folders = root.EnumerateDirectories();
                foreach (DirectoryInfo folder in folders)
                {
                    folderSize += ProcessFolder(folder.FullName, level+1);
                }
            }
            catch (Exception ex)
            {
                AddLog(ex.Message);
            }
            */

            if (level == 1)
                FolderSizes.Add(path, folderSize);
            
            return folderSize;
        }
        
        //*************************************************************************************************************
        private string GetFileSize(double byteCount)
        {
            string size = "0 Bytes";
            if (byteCount == 0)
                size = "0 B";
            else if (byteCount >= (1024 * 1024 * 1024))
                size = String.Format("{0:##.00}", byteCount / (1024 * 1024 * 1024)) + " Gb";
            else if (byteCount >= (1024 * 1024))
                size = String.Format("{0:##.00}", byteCount / (1024 * 1024)) + " Mb";
            else if (byteCount >= 1024)
                size = String.Format("{0:##.00}", byteCount / 1024) + " Kb";
            else if (byteCount < 1024)
                size = String.Format("{0:##}", byteCount) + " B";

            return size;
        }

        //*************************************************************************************************************
        private void buttonCalculate_Click(object sender, EventArgs e)
        {
            textBoxLog.Text = "";
            listViewResult.Items.Clear();
            FolderSizes.Clear();

            AddLog("Running...");
            runTime.Start();

            Task.Run( () =>
            {
                ProcessFolder(textStartPath.Text);
                var ordered = FolderSizes.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);

                int top = 500;
                foreach (var f in ordered)
                {   if (top-- == 0)
                        break;
                    ListViewItem item = new ListViewItem();
                    item.ImageIndex = 0;
                    item.Text = f.Key;
                    item.SubItems.Add(GetFileSize(f.Value));

                    BeginInvoke((Action)(() =>
                    {
                        listViewResult.Items.Add(item);
                    }));
                }

                BeginInvoke((Action)(() =>
                {
                    runTime.Stop();
                    AddLog(runTime.Elapsed.ToString());
                    AddLog("========== DONE ===========");
                }));
            });
        }
    }
}
