using AppConfigSE;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace DBScriptDeploymentTools
{
    public partial class Form1 : Form
    {
        private static ListViewItem gCurrentItem;
        private readonly string version = "V2.0";
        private DateTime startTime;
        private Stopwatch stopWatch = new Stopwatch();
        private const string clipboardMessage = "Content copy to clipboard";

        public Form1()
        {
            InitializeComponent();
            lvView.AllowDrop = true;
            lvView.DragDrop += new DragEventHandler(lvView_DragDrop);
            lvView.DragEnter += new DragEventHandler(lvView_DragEnter);
        }

        private void Form1_Load(object sender, System.EventArgs e)
        {
            var obj = new AppConfigBAL();
            this.Text = obj.ReadTitle() + "  " + version;
        }

        #region Button
        private void btnShowLog_Click(object sender, EventArgs e)
        {
            var info = "";

            foreach (ListViewItem item in lvView.Items)
            {
                if (item.SubItems[3].Text != "DONE")
                {
                    info += item.SubItems[1].Text + "\r\n" + item.SubItems[3].Text + "\r\n";
                }
            }
          
            if (info != "")
            {
                Clipboard.SetText(info);

                lblMessage.Text = clipboardMessage;
                tm2.Enabled = true;
            }
        }

        private void btnProcess_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (lvView.Items.Count > 0)
                {
                    if (ShowMessage("Click OK to continue process to deploy the DB script,\nPlease ensure the model selection is correct as there is no turning back once run,\nAre you sure?", 2) == DialogResult.OK)
                    {
                        lblElapsed.Text = "Elapsed Time: ";
                        StartProcess(true);
                    }
                }
                else
                {
                    ShowMessage("No Database script found", 1);
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            lvView.Items.Clear();
            lblTotal.Text = "Total files: " + lvView.Items.Count;
            lblElapsed.Text = "Elapsed Time: ";
        }

        private void btnClearSelection_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in lvView.SelectedItems)
            {
                item.Selected = false;
            }
        }

        private void lblHelp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ShowMessage("This tool only provide the flexibility to deploy SQL script, developer still need to bear the responsibility to re check the data in db to ensure deployment is success\n\n" +
                "1. Script should be reusable and in clean state\n" +
                "2. Add a sequence in front of all the script files for tool to recognize as tool is run on sequence based\n" +
                "3. Specific script can be select and run seperately by right click\n" +
                "4. Double click will open the selected file\n"
                , 1);
        }

        private void btnSwitch_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region ListView
        private void lvView_DoubleClick(object sender, EventArgs e)
        {
            var location = lvView.SelectedItems[0].SubItems[1].Text;
            Process.Start(location);
        }

        private void lvView_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void lvView_DragDrop(object sender, DragEventArgs e)
        {
            string[] locName = (string[])e.Data.GetData(DataFormats.FileDrop);

            foreach (var loc in locName)
            {
                if (loc.Contains(".sql"))
                {
                    var lv = lvView.Items.Cast<ListViewItem>();

                    if (!lv.Any(x => x.Text == loc))
                    {
                        ListViewItem currItem = lvView.Items.Add(Path.GetFileName(loc));
                        currItem.ToolTipText = loc;
                        AddEmptySubItem(currItem);
                        currItem.SubItems[1].Text = loc;
                        currItem.SubItems[2].Text = AssignServer(loc);
                        if (currItem.SubItems[2].Text == "")
                        {
                            currItem.ForeColor = Color.OrangeRed;
                        }
                    }
                }
                else if (!loc.Contains("."))
                {
                    var files = Directory.GetFiles(loc, "*.sql", SearchOption.AllDirectories);
                    var lv = lvView.Items.Cast<ListViewItem>();

                    foreach (var s in files)
                    {
                        if (lvView.Items.Count > 0)
                        {
                            if (!lv.Any(x => x.Text == s))
                            {
                                ListViewItem currItem = lvView.Items.Add(Path.GetFileName(s));
                                currItem.ToolTipText = s;
                                AddEmptySubItem(currItem);
                                currItem.SubItems[1].Text = s;
                                currItem.SubItems[2].Text = AssignServer(s);
                                if (currItem.SubItems[2].Text == "")
                                {
                                    currItem.ForeColor = Color.OrangeRed;
                                }
                            }
                        }
                        else
                        {
                            ListViewItem currItem = lvView.Items.Add(Path.GetFileName(s));
                            currItem.ToolTipText = s;
                            AddEmptySubItem(currItem);
                            currItem.SubItems[1].Text = s;
                            currItem.SubItems[2].Text = AssignServer(s);
                            if (currItem.SubItems[2].Text == "")
                            {
                                currItem.ForeColor = Color.OrangeRed;
                            }

                        }
                    }
                }
            }
            lblTotal.Text = "Total files: " + lvView.Items.Count;
        }
        #endregion

        #region Background Worker
        private void bg1_DoWork(object sender, DoWorkEventArgs e)
        {
            var s = new AppConfigBAL();

            var lstConn = s.ListOfConnection();
            var selectedServer = serverCntrl1.ServerTag;

            foreach (var ss in selectedServer)
            {
                foreach (ListViewItem item in AllItems(lvView))
                {
                    if (item.SubItems[3].Text == "")
                    {
                        var match = ss.Name + "|" + item.SubItems[2].Text;
                        UpdateToServer(item, lstConn.Where(x => x.Name == match).Select(x => x.ConnectionString).FirstOrDefault());
                    }
                }
            }

        }

        private void bg1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
        }

        private void bg1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            CompleteWork(e, true);
        }

        private void bg2_DoWork(object sender, DoWorkEventArgs e)
        {
            var s = new AppConfigBAL();

            var lstConn = s.ListOfConnection();
            var selectedServer = serverCntrl1.ServerTag;

            foreach (var ss in selectedServer)
            {
                foreach (ListViewItem item in SelectedItem(lvView))
                {
                    if (item.SubItems[3].Text == "")
                    {
                        var match = ss.Name + "|" + item.SubItems[2].Text;
                        UpdateToServer(item, lstConn.Where(x => x.Name == match).Select(x => x.ConnectionString).FirstOrDefault());
                    }
                }
            }
        }

        private void bg2_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        private void bg2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            CompleteWork(e, false);
        }
        #endregion

        #region KeyEvent
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void lvView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A && e.Control)
            {
                foreach (ListViewItem item in lvView.Items)
                {
                    item.Selected = true;
                }
            }
            else if (e.KeyCode == Keys.C && e.Control)
            {
                var info = "";
                foreach (ListViewItem item in lvView.SelectedItems)
                {
                    info +=  item.SubItems[1].Text + "\t" + item.SubItems[3].Text + "\r\n";
                }

                if (info != "")
                {
                    Clipboard.SetText(info);

                    lblMessage.Text = clipboardMessage;
                    tm2.Enabled = true;
                }
            }
        }
        #endregion

        #region ContextMenu
        private void lvView_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (lvView.FocusedItem.Bounds.Contains(e.Location) == true)
                {
                    contextMenuStrip1.Show(Cursor.Position);
                }
            }
        }

        private void showLocationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lvView.BeginUpdate();
            foreach (ListViewItem item in lvView.SelectedItems)
            {
                Process.Start(Path.GetDirectoryName(item.SubItems[1].Text));
            }
            lvView.EndUpdate();
        }

        private void runThisScriptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StartProcess(false);
        }

        private void neptune122ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach(ListViewItem item in lvView.SelectedItems)
            {
                item.SubItems[2].Text = "122";
            }
        }

        private void neptune124ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in lvView.SelectedItems)
            {
                item.SubItems[2].Text = "124";
            }
        }
        #endregion

        #region Functionality

        private void UpdateToServer(ListViewItem item, string connString)
        {
           
            string script = File.ReadAllText(item.SubItems[1].Text);

            using (var conn = new SqlConnection(connString))
            {
                Server server = new Server(new ServerConnection(conn));
                this.Invoke(new MethodInvoker(delegate { gCurrentItem = item; }));
                stopWatch.Reset();
                stopWatch.Start();
                server.ConnectionContext.ExecuteNonQuery(script);
                stopWatch.Stop();
                Thread.Sleep(200);
                item.ForeColor = Color.Green;
                this.Invoke(new MethodInvoker(delegate { item.SubItems[3].Text = "DONE"; }));
                this.Invoke(new MethodInvoker(delegate { item.SubItems[4].Text = stopWatch.Elapsed.ToString(); }));
                this.Invoke(new MethodInvoker(delegate { lvView.RedrawItems(item.Index, item.Index, false); }));

            }
        }

        private void EnableDisabledControl(bool flag)
        {
            serverCntrl1.Enabled = flag;
            btnClear.Enabled = flag;
            btnProcess.Enabled = flag;
            btnShowLog.Enabled = flag;
            btnClearSelection.Enabled = flag;
            runThisScriptToolStripMenuItem.Enabled = flag;
            neptune122ToolStripMenuItem.Enabled = flag;
            neptune124ToolStripMenuItem.Enabled = flag;
            customAssignServerToolStripMenuItem.Enabled = flag;
        }

        private void AddEmptySubItem(ListViewItem currItem)
        {
            currItem.SubItems.Add("");
            currItem.SubItems.Add("");
            currItem.SubItems.Add("");
            currItem.SubItems.Add("");
        }

        private DialogResult ShowMessage(string messages, int boxType, string caption = "Information")
        {
            var result = new DialogResult();

            switch (boxType)
            {
                case 0:
                    result = MessageBox.Show(messages, caption, MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    break;
                case 1:
                    result = MessageBox.Show(messages, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case 2:
                    result = MessageBox.Show(messages, caption, MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                    break;
                case 3:
                    result = MessageBox.Show(messages, caption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    break;

            }

            return result;
        }
        private void tm1_Tick(object sender, EventArgs e)
        {
            var elapsedTime = (DateTime.Now - startTime);
            lblElapsed.Text = "Elapsed Time: " + elapsedTime.Hours.ToString("00.##") + ":" + elapsedTime.Minutes.ToString("00.##") + ":" + elapsedTime.Seconds.ToString("00.##");
        }

        private void tm2_Tick(object sender, EventArgs e)
        {
            lblMessage.Text = "";
            tm2.Enabled = false;
        }

        private void StartProcess(Boolean isAll)
        {
            foreach (ListViewItem item in lvView.Items)
            {
                item.ForeColor = Color.Black;
                item.SubItems[3].Text = "";
            }
            startTime = DateTime.Now;
            tm1.Enabled = true;
            EnableDisabledControl(false);
            if (isAll)
            {
                bg1.RunWorkerAsync();
            }
            else
            {
                bg2.RunWorkerAsync();
            }

        }

        private string AssignServer(string path)
        {
            var serverName = "";
            AppConfigBAL appConfig = new AppConfigBAL();
            var splitAC = appConfig.ReadServerCombination().Split(';');

            foreach(var s in splitAC)
            {
                if (path.ToLower().Contains(s))
                {
                    serverName = s;
                    break;
                }
            }

            return serverName;
        }

        private static List<ListViewItem> SelectedItem(ListView lv)
        {
            if (!lv.InvokeRequired)
                return lv.SelectedItems.Cast<ListViewItem>().ToList();
            else
                return (List<ListViewItem>)lv.Invoke(
                    new Func<ListView, List<ListViewItem>>(SelectedItem),
                    lv);
        }

        private static List<ListViewItem> AllItems(ListView lv)
        {
            if (!lv.InvokeRequired)
                return lv.Items.Cast<ListViewItem>().ToList();
            else
                return (List<ListViewItem>)lv.Invoke(
                    new Func<ListView, List<ListViewItem>>(AllItems),
                    lv);
        }

        private void CompleteWork(RunWorkerCompletedEventArgs e, Boolean isAll)
        {
            stopWatch.Stop();
            if (e.Error != null)
            {
                var currItem = gCurrentItem;

                currItem.ForeColor = Color.Red;
                currItem.SubItems[3].Text = e.Error.InnerException.Message + "\r\n";
                currItem.SubItems[4].Text = stopWatch.Elapsed.ToString();

                if (isAll)
                {
                    bg1.RunWorkerAsync();
                }
                else
                {
                    bg2.RunWorkerAsync();
                }

                EnableDisabledControl(false);
            }
            else
            {
                tm1.Enabled = false;
                ShowMessage("Deployment done", 1);
                EnableDisabledControl(true);
            }
        }

        #endregion
    }
}
