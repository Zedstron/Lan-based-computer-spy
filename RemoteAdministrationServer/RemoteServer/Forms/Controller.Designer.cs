using System.Windows.Forms;
namespace RemoteServer
{
    partial class Controller
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Controller));
            System.Windows.Forms.AGaugeLabel aGaugeLabel1 = new System.Windows.Forms.AGaugeLabel();
            System.Windows.Forms.AGaugeRange aGaugeRange1 = new System.Windows.Forms.AGaugeRange();
            System.Windows.Forms.AGaugeRange aGaugeRange2 = new System.Windows.Forms.AGaugeRange();
            System.Windows.Forms.AGaugeLabel aGaugeLabel2 = new System.Windows.Forms.AGaugeLabel();
            System.Windows.Forms.AGaugeRange aGaugeRange3 = new System.Windows.Forms.AGaugeRange();
            System.Windows.Forms.AGaugeRange aGaugeRange4 = new System.Windows.Forms.AGaugeRange();
            System.Windows.Forms.AGaugeLabel aGaugeLabel3 = new System.Windows.Forms.AGaugeLabel();
            System.Windows.Forms.AGaugeRange aGaugeRange5 = new System.Windows.Forms.AGaugeRange();
            System.Windows.Forms.AGaugeRange aGaugeRange6 = new System.Windows.Forms.AGaugeRange();
            System.Windows.Forms.AGaugeLabel aGaugeLabel4 = new System.Windows.Forms.AGaugeLabel();
            System.Windows.Forms.AGaugeRange aGaugeRange7 = new System.Windows.Forms.AGaugeRange();
            System.Windows.Forms.AGaugeRange aGaugeRange8 = new System.Windows.Forms.AGaugeRange();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.rtbChat = new System.Windows.Forms.RichTextBox();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage16 = new System.Windows.Forms.TabPage();
            this.groupBox22 = new System.Windows.Forms.GroupBox();
            this.button53 = new System.Windows.Forms.Button();
            this.button51 = new System.Windows.Forms.Button();
            this.button52 = new System.Windows.Forms.Button();
            this.button49 = new System.Windows.Forms.Button();
            this.button50 = new System.Windows.Forms.Button();
            this.button47 = new System.Windows.Forms.Button();
            this.button48 = new System.Windows.Forms.Button();
            this.button45 = new System.Windows.Forms.Button();
            this.button46 = new System.Windows.Forms.Button();
            this.button43 = new System.Windows.Forms.Button();
            this.button44 = new System.Windows.Forms.Button();
            this.button42 = new System.Windows.Forms.Button();
            this.button41 = new System.Windows.Forms.Button();
            this.gaugeUpload = new System.Windows.Forms.AGauge();
            this.gaugeDownload = new System.Windows.Forms.AGauge();
            this.socketGauge = new System.Windows.Forms.AGauge();
            this.pingGauge = new System.Windows.Forms.AGauge();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lvprocesslist = new System.Windows.Forms.ListView();
            this.procname = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.PID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.procstarttime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.proccputime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.memusage = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.peakmemusage = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.noofhandles = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.nonofthreads = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvcxtmnu = new System.Windows.Forms.ContextMenu();
            this.menuItem9 = new System.Windows.Forms.MenuItem();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.stopButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.delimeterTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.writeResultsButton = new System.Windows.Forms.Button();
            this.resultsList = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openContainingFolderContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileNameTextBox = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.unicodeRadioButton = new System.Windows.Forms.RadioButton();
            this.asciiRadioButton = new System.Windows.Forms.RadioButton();
            this.containingTextBox = new System.Windows.Forms.TextBox();
            this.containingCheckBox = new System.Windows.Forms.CheckBox();
            this.olderThanDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.newerThanCheckBox = new System.Windows.Forms.CheckBox();
            this.olderThanCheckBox = new System.Windows.Forms.CheckBox();
            this.newerThanDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.startButton = new System.Windows.Forms.Button();
            this.searchDirTextBox = new System.Windows.Forms.TextBox();
            this.includeSubDirsCheckBox = new System.Windows.Forms.CheckBox();
            this.selectSearchDirButton = new System.Windows.Forms.Button();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.lstClientFiles = new System.Windows.Forms.ListView();
            this.clmName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmSize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.uploadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.downloadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.downloadCMDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.renameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.checkBox7 = new System.Windows.Forms.CheckBox();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.button29 = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.button7 = new System.Windows.Forms.Button();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.button14 = new System.Windows.Forms.Button();
            this.button13 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.button12 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.richTextBox3 = new System.Windows.Forms.RichTextBox();
            this.tabPage8 = new System.Windows.Forms.TabPage();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.trackBar2 = new System.Windows.Forms.TrackBar();
            this.button19 = new System.Windows.Forms.Button();
            this.button18 = new System.Windows.Forms.Button();
            this.button16 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button15 = new System.Windows.Forms.Button();
            this.tabPage11 = new System.Windows.Forms.TabPage();
            this.groupBox12 = new System.Windows.Forms.GroupBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.groupBox13 = new System.Windows.Forms.GroupBox();
            this.button20 = new System.Windows.Forms.Button();
            this.button21 = new System.Windows.Forms.Button();
            this.button22 = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.button23 = new System.Windows.Forms.Button();
            this.tabPage9 = new System.Windows.Forms.TabPage();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.button17 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.tabPage12 = new System.Windows.Forms.TabPage();
            this.groupBox17 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox16 = new System.Windows.Forms.GroupBox();
            this.button40 = new System.Windows.Forms.Button();
            this.comboBox5 = new System.Windows.Forms.ComboBox();
            this.button39 = new System.Windows.Forms.Button();
            this.button38 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button31 = new System.Windows.Forms.Button();
            this.button30 = new System.Windows.Forms.Button();
            this.comboBox4 = new System.Windows.Forms.ComboBox();
            this.button24 = new System.Windows.Forms.Button();
            this.tabPage14 = new System.Windows.Forms.TabPage();
            this.groupBox19 = new System.Windows.Forms.GroupBox();
            this.button35 = new System.Windows.Forms.Button();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.button34 = new System.Windows.Forms.Button();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.button33 = new System.Windows.Forms.Button();
            this.button32 = new System.Windows.Forms.Button();
            this.groupBox18 = new System.Windows.Forms.GroupBox();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.tabPage15 = new System.Windows.Forms.TabPage();
            this.groupBox20 = new System.Windows.Forms.GroupBox();
            this.button36 = new System.Windows.Forms.Button();
            this.checkBox6 = new System.Windows.Forms.CheckBox();
            this.button37 = new System.Windows.Forms.Button();
            this.groupBox21 = new System.Windows.Forms.GroupBox();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage13 = new System.Windows.Forms.TabPage();
            this.groupBox15 = new System.Windows.Forms.GroupBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.groupBox14 = new System.Windows.Forms.GroupBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.button28 = new System.Windows.Forms.Button();
            this.button27 = new System.Windows.Forms.Button();
            this.button26 = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.button25 = new System.Windows.Forms.Button();
            this.tabPage10 = new System.Windows.Forms.TabPage();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.saveLogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.timer_graph = new System.Windows.Forms.Timer(this.components);
            this.timer_ping = new System.Windows.Forms.Timer(this.components);
            this.tabPage17 = new System.Windows.Forms.TabPage();
            this.groupBox23 = new System.Windows.Forms.GroupBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.groupBox24 = new System.Windows.Forms.GroupBox();
            this.richTextBox4 = new System.Windows.Forms.RichTextBox();
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage16.SuspendLayout();
            this.groupBox22.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.contextMenuStrip.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabPage7.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.tabPage8.SuspendLayout();
            this.groupBox8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.groupBox7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).BeginInit();
            this.tabPage11.SuspendLayout();
            this.groupBox12.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.groupBox13.SuspendLayout();
            this.tabPage9.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.tabPage12.SuspendLayout();
            this.groupBox17.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox16.SuspendLayout();
            this.tabPage14.SuspendLayout();
            this.groupBox19.SuspendLayout();
            this.groupBox18.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.tabPage15.SuspendLayout();
            this.groupBox20.SuspendLayout();
            this.groupBox21.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            this.tabPage13.SuspendLayout();
            this.groupBox15.SuspendLayout();
            this.groupBox14.SuspendLayout();
            this.tabPage10.SuspendLayout();
            this.groupBox11.SuspendLayout();
            this.contextMenuStrip2.SuspendLayout();
            this.tabPage17.SuspendLayout();
            this.groupBox23.SuspendLayout();
            this.groupBox24.SuspendLayout();
            this.SuspendLayout();
            // 
            // rtbChat
            // 
            this.rtbChat.BackColor = System.Drawing.Color.Black;
            this.rtbChat.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbChat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbChat.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbChat.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.rtbChat.Location = new System.Drawing.Point(3, 3);
            this.rtbChat.Name = "rtbChat";
            this.rtbChat.ReadOnly = true;
            this.rtbChat.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.rtbChat.Size = new System.Drawing.Size(1136, 484);
            this.rtbChat.TabIndex = 0;
            this.rtbChat.Text = "";
            // 
            // txtMessage
            // 
            this.txtMessage.BackColor = System.Drawing.SystemColors.Window;
            this.txtMessage.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtMessage.Location = new System.Drawing.Point(3, 487);
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(1136, 20);
            this.txtMessage.TabIndex = 1;
            this.txtMessage.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMessage_KeyDown);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1150, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.exitToolStripMenuItem.Text = "&Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 560);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1150, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage16);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Controls.Add(this.tabPage6);
            this.tabControl1.Controls.Add(this.tabPage7);
            this.tabControl1.Controls.Add(this.tabPage8);
            this.tabControl1.Controls.Add(this.tabPage11);
            this.tabControl1.Controls.Add(this.tabPage9);
            this.tabControl1.Controls.Add(this.tabPage12);
            this.tabControl1.Controls.Add(this.tabPage14);
            this.tabControl1.Controls.Add(this.tabPage15);
            this.tabControl1.Controls.Add(this.tabPage13);
            this.tabControl1.Controls.Add(this.tabPage10);
            this.tabControl1.Controls.Add(this.tabPage17);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 24);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1150, 536);
            this.tabControl1.TabIndex = 5;
            // 
            // tabPage16
            // 
            this.tabPage16.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage16.Controls.Add(this.groupBox22);
            this.tabPage16.Controls.Add(this.gaugeUpload);
            this.tabPage16.Controls.Add(this.gaugeDownload);
            this.tabPage16.Controls.Add(this.socketGauge);
            this.tabPage16.Controls.Add(this.pingGauge);
            this.tabPage16.Location = new System.Drawing.Point(4, 22);
            this.tabPage16.Name = "tabPage16";
            this.tabPage16.Size = new System.Drawing.Size(1142, 510);
            this.tabPage16.TabIndex = 15;
            this.tabPage16.Text = "Status Board";
            // 
            // groupBox22
            // 
            this.groupBox22.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox22.Controls.Add(this.button53);
            this.groupBox22.Controls.Add(this.button51);
            this.groupBox22.Controls.Add(this.button52);
            this.groupBox22.Controls.Add(this.button49);
            this.groupBox22.Controls.Add(this.button50);
            this.groupBox22.Controls.Add(this.button47);
            this.groupBox22.Controls.Add(this.button48);
            this.groupBox22.Controls.Add(this.button45);
            this.groupBox22.Controls.Add(this.button46);
            this.groupBox22.Controls.Add(this.button43);
            this.groupBox22.Controls.Add(this.button44);
            this.groupBox22.Controls.Add(this.button42);
            this.groupBox22.Controls.Add(this.button41);
            this.groupBox22.Location = new System.Drawing.Point(657, 48);
            this.groupBox22.Name = "groupBox22";
            this.groupBox22.Size = new System.Drawing.Size(435, 421);
            this.groupBox22.TabIndex = 4;
            this.groupBox22.TabStop = false;
            this.groupBox22.Text = "Quick Actions";
            // 
            // button53
            // 
            this.button53.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button53.Image = ((System.Drawing.Image)(resources.GetObject("button53.Image")));
            this.button53.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button53.Location = new System.Drawing.Point(230, 363);
            this.button53.Name = "button53";
            this.button53.Size = new System.Drawing.Size(188, 50);
            this.button53.TabIndex = 12;
            this.button53.Text = "CD Rom Panic";
            this.button53.UseVisualStyleBackColor = true;
            this.button53.Click += new System.EventHandler(this.button53_Click);
            // 
            // button51
            // 
            this.button51.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button51.Image = ((System.Drawing.Image)(resources.GetObject("button51.Image")));
            this.button51.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button51.Location = new System.Drawing.Point(20, 363);
            this.button51.Name = "button51";
            this.button51.Size = new System.Drawing.Size(204, 50);
            this.button51.TabIndex = 11;
            this.button51.Text = "Black Screen";
            this.button51.UseVisualStyleBackColor = true;
            // 
            // button52
            // 
            this.button52.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button52.Image = ((System.Drawing.Image)(resources.GetObject("button52.Image")));
            this.button52.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button52.Location = new System.Drawing.Point(20, 307);
            this.button52.Name = "button52";
            this.button52.Size = new System.Drawing.Size(398, 50);
            this.button52.TabIndex = 10;
            this.button52.Text = "Initialize Cute Crazy Mouse";
            this.button52.UseVisualStyleBackColor = true;
            // 
            // button49
            // 
            this.button49.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button49.Image = ((System.Drawing.Image)(resources.GetObject("button49.Image")));
            this.button49.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button49.Location = new System.Drawing.Point(230, 251);
            this.button49.Name = "button49";
            this.button49.Size = new System.Drawing.Size(188, 50);
            this.button49.TabIndex = 9;
            this.button49.Text = "Mess with .exe";
            this.button49.UseVisualStyleBackColor = true;
            // 
            // button50
            // 
            this.button50.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button50.Image = ((System.Drawing.Image)(resources.GetObject("button50.Image")));
            this.button50.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button50.Location = new System.Drawing.Point(20, 251);
            this.button50.Name = "button50";
            this.button50.Size = new System.Drawing.Size(204, 50);
            this.button50.TabIndex = 8;
            this.button50.Text = "Crash Computer";
            this.button50.UseVisualStyleBackColor = true;
            this.button50.Click += new System.EventHandler(this.button50_Click);
            // 
            // button47
            // 
            this.button47.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button47.Image = ((System.Drawing.Image)(resources.GetObject("button47.Image")));
            this.button47.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button47.Location = new System.Drawing.Point(230, 195);
            this.button47.Name = "button47";
            this.button47.Size = new System.Drawing.Size(188, 50);
            this.button47.TabIndex = 7;
            this.button47.Text = "Disable CMD";
            this.button47.UseVisualStyleBackColor = true;
            // 
            // button48
            // 
            this.button48.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button48.Image = ((System.Drawing.Image)(resources.GetObject("button48.Image")));
            this.button48.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button48.Location = new System.Drawing.Point(20, 195);
            this.button48.Name = "button48";
            this.button48.Size = new System.Drawing.Size(204, 50);
            this.button48.TabIndex = 6;
            this.button48.Text = "Disable TaskMgr";
            this.button48.UseVisualStyleBackColor = true;
            this.button48.Click += new System.EventHandler(this.button48_Click);
            // 
            // button45
            // 
            this.button45.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button45.Image = ((System.Drawing.Image)(resources.GetObject("button45.Image")));
            this.button45.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button45.Location = new System.Drawing.Point(230, 139);
            this.button45.Name = "button45";
            this.button45.Size = new System.Drawing.Size(188, 50);
            this.button45.TabIndex = 5;
            this.button45.Text = "Lock Mouse";
            this.button45.UseVisualStyleBackColor = true;
            this.button45.Click += new System.EventHandler(this.button45_Click);
            // 
            // button46
            // 
            this.button46.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button46.Image = ((System.Drawing.Image)(resources.GetObject("button46.Image")));
            this.button46.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button46.Location = new System.Drawing.Point(20, 139);
            this.button46.Name = "button46";
            this.button46.Size = new System.Drawing.Size(204, 50);
            this.button46.TabIndex = 4;
            this.button46.Text = "Lock Keyboard";
            this.button46.UseVisualStyleBackColor = true;
            // 
            // button43
            // 
            this.button43.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button43.Image = ((System.Drawing.Image)(resources.GetObject("button43.Image")));
            this.button43.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button43.Location = new System.Drawing.Point(230, 83);
            this.button43.Name = "button43";
            this.button43.Size = new System.Drawing.Size(188, 50);
            this.button43.TabIndex = 3;
            this.button43.Text = "Sleep";
            this.button43.UseVisualStyleBackColor = true;
            this.button43.Click += new System.EventHandler(this.button43_Click);
            // 
            // button44
            // 
            this.button44.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button44.Image = ((System.Drawing.Image)(resources.GetObject("button44.Image")));
            this.button44.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button44.Location = new System.Drawing.Point(20, 83);
            this.button44.Name = "button44";
            this.button44.Size = new System.Drawing.Size(204, 50);
            this.button44.TabIndex = 2;
            this.button44.Text = "Lock Now";
            this.button44.UseVisualStyleBackColor = true;
            this.button44.Click += new System.EventHandler(this.button44_Click);
            // 
            // button42
            // 
            this.button42.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button42.Image = ((System.Drawing.Image)(resources.GetObject("button42.Image")));
            this.button42.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button42.Location = new System.Drawing.Point(230, 27);
            this.button42.Name = "button42";
            this.button42.Size = new System.Drawing.Size(188, 50);
            this.button42.TabIndex = 1;
            this.button42.Text = "Restart";
            this.button42.UseVisualStyleBackColor = true;
            this.button42.Click += new System.EventHandler(this.button42_Click);
            // 
            // button41
            // 
            this.button41.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button41.Image = ((System.Drawing.Image)(resources.GetObject("button41.Image")));
            this.button41.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button41.Location = new System.Drawing.Point(20, 27);
            this.button41.Name = "button41";
            this.button41.Size = new System.Drawing.Size(204, 50);
            this.button41.TabIndex = 0;
            this.button41.Text = "Shutdown";
            this.button41.UseVisualStyleBackColor = true;
            this.button41.Click += new System.EventHandler(this.button41_Click);
            // 
            // gaugeUpload
            // 
            this.gaugeUpload.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.gaugeUpload.BaseArcColor = System.Drawing.Color.Gray;
            this.gaugeUpload.BaseArcRadius = 80;
            this.gaugeUpload.BaseArcStart = 135;
            this.gaugeUpload.BaseArcSweep = 270;
            this.gaugeUpload.BaseArcWidth = 2;
            this.gaugeUpload.Center = new System.Drawing.Point(100, 100);
            aGaugeLabel1.Color = System.Drawing.Color.Brown;
            aGaugeLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            aGaugeLabel1.Name = "GaugeLabel1";
            aGaugeLabel1.Position = new System.Drawing.Point(60, 170);
            aGaugeLabel1.Text = "NI Upload (KB/s)";
            this.gaugeUpload.GaugeLabels.Add(aGaugeLabel1);
            aGaugeRange1.Color = System.Drawing.Color.Green;
            aGaugeRange1.EndValue = 200F;
            aGaugeRange1.InnerRadius = 2;
            aGaugeRange1.InRange = false;
            aGaugeRange1.Name = "GaugeRange1";
            aGaugeRange1.OuterRadius = 4;
            aGaugeRange1.StartValue = 0F;
            aGaugeRange2.Color = System.Drawing.Color.Empty;
            aGaugeRange2.EndValue = 600F;
            aGaugeRange2.InnerRadius = 1;
            aGaugeRange2.InRange = false;
            aGaugeRange2.Name = "GaugeRange2";
            aGaugeRange2.OuterRadius = 2;
            aGaugeRange2.StartValue = 200F;
            this.gaugeUpload.GaugeRanges.Add(aGaugeRange1);
            this.gaugeUpload.GaugeRanges.Add(aGaugeRange2);
            this.gaugeUpload.Location = new System.Drawing.Point(354, 287);
            this.gaugeUpload.MaxValue = 25F;
            this.gaugeUpload.MinValue = 0F;
            this.gaugeUpload.Name = "gaugeUpload";
            this.gaugeUpload.NeedleColor1 = System.Windows.Forms.AGaugeNeedleColor.Gray;
            this.gaugeUpload.NeedleColor2 = System.Drawing.Color.DimGray;
            this.gaugeUpload.NeedleRadius = 100;
            this.gaugeUpload.NeedleType = System.Windows.Forms.NeedleType.Advance;
            this.gaugeUpload.NeedleWidth = 2;
            this.gaugeUpload.ScaleLinesInterColor = System.Drawing.Color.Black;
            this.gaugeUpload.ScaleLinesInterInnerRadius = 73;
            this.gaugeUpload.ScaleLinesInterOuterRadius = 80;
            this.gaugeUpload.ScaleLinesInterWidth = 1;
            this.gaugeUpload.ScaleLinesMajorColor = System.Drawing.Color.Red;
            this.gaugeUpload.ScaleLinesMajorInnerRadius = 70;
            this.gaugeUpload.ScaleLinesMajorOuterRadius = 80;
            this.gaugeUpload.ScaleLinesMajorStepValue = 1F;
            this.gaugeUpload.ScaleLinesMajorWidth = 2;
            this.gaugeUpload.ScaleLinesMinorColor = System.Drawing.Color.Brown;
            this.gaugeUpload.ScaleLinesMinorInnerRadius = 75;
            this.gaugeUpload.ScaleLinesMinorOuterRadius = 80;
            this.gaugeUpload.ScaleLinesMinorTicks = 10;
            this.gaugeUpload.ScaleLinesMinorWidth = 2;
            this.gaugeUpload.ScaleNumbersColor = System.Drawing.Color.Black;
            this.gaugeUpload.ScaleNumbersFormat = null;
            this.gaugeUpload.ScaleNumbersRadius = 92;
            this.gaugeUpload.ScaleNumbersRotation = 0;
            this.gaugeUpload.ScaleNumbersStartScaleLine = 0;
            this.gaugeUpload.ScaleNumbersStepScaleLines = 1;
            this.gaugeUpload.Size = new System.Drawing.Size(216, 193);
            this.gaugeUpload.TabIndex = 3;
            this.gaugeUpload.Value = 0F;
            // 
            // gaugeDownload
            // 
            this.gaugeDownload.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.gaugeDownload.BaseArcColor = System.Drawing.Color.Gray;
            this.gaugeDownload.BaseArcRadius = 80;
            this.gaugeDownload.BaseArcStart = 135;
            this.gaugeDownload.BaseArcSweep = 270;
            this.gaugeDownload.BaseArcWidth = 2;
            this.gaugeDownload.Center = new System.Drawing.Point(100, 100);
            aGaugeLabel2.Color = System.Drawing.Color.Brown;
            aGaugeLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            aGaugeLabel2.Name = "GaugeLabel1";
            aGaugeLabel2.Position = new System.Drawing.Point(45, 170);
            aGaugeLabel2.Text = "NI Download (KB/s)";
            this.gaugeDownload.GaugeLabels.Add(aGaugeLabel2);
            aGaugeRange3.Color = System.Drawing.Color.Green;
            aGaugeRange3.EndValue = 200F;
            aGaugeRange3.InnerRadius = 2;
            aGaugeRange3.InRange = false;
            aGaugeRange3.Name = "GaugeRange1";
            aGaugeRange3.OuterRadius = 4;
            aGaugeRange3.StartValue = 0F;
            aGaugeRange4.Color = System.Drawing.Color.Empty;
            aGaugeRange4.EndValue = 600F;
            aGaugeRange4.InnerRadius = 1;
            aGaugeRange4.InRange = false;
            aGaugeRange4.Name = "GaugeRange2";
            aGaugeRange4.OuterRadius = 2;
            aGaugeRange4.StartValue = 200F;
            this.gaugeDownload.GaugeRanges.Add(aGaugeRange3);
            this.gaugeDownload.GaugeRanges.Add(aGaugeRange4);
            this.gaugeDownload.Location = new System.Drawing.Point(92, 287);
            this.gaugeDownload.MaxValue = 5000F;
            this.gaugeDownload.MinValue = 0F;
            this.gaugeDownload.Name = "gaugeDownload";
            this.gaugeDownload.NeedleColor1 = System.Windows.Forms.AGaugeNeedleColor.Gray;
            this.gaugeDownload.NeedleColor2 = System.Drawing.Color.DimGray;
            this.gaugeDownload.NeedleRadius = 100;
            this.gaugeDownload.NeedleType = System.Windows.Forms.NeedleType.Advance;
            this.gaugeDownload.NeedleWidth = 2;
            this.gaugeDownload.ScaleLinesInterColor = System.Drawing.Color.Black;
            this.gaugeDownload.ScaleLinesInterInnerRadius = 73;
            this.gaugeDownload.ScaleLinesInterOuterRadius = 80;
            this.gaugeDownload.ScaleLinesInterWidth = 1;
            this.gaugeDownload.ScaleLinesMajorColor = System.Drawing.Color.Red;
            this.gaugeDownload.ScaleLinesMajorInnerRadius = 70;
            this.gaugeDownload.ScaleLinesMajorOuterRadius = 80;
            this.gaugeDownload.ScaleLinesMajorStepValue = 600F;
            this.gaugeDownload.ScaleLinesMajorWidth = 2;
            this.gaugeDownload.ScaleLinesMinorColor = System.Drawing.Color.Brown;
            this.gaugeDownload.ScaleLinesMinorInnerRadius = 75;
            this.gaugeDownload.ScaleLinesMinorOuterRadius = 80;
            this.gaugeDownload.ScaleLinesMinorTicks = 10;
            this.gaugeDownload.ScaleLinesMinorWidth = 2;
            this.gaugeDownload.ScaleNumbersColor = System.Drawing.Color.Black;
            this.gaugeDownload.ScaleNumbersFormat = null;
            this.gaugeDownload.ScaleNumbersRadius = 92;
            this.gaugeDownload.ScaleNumbersRotation = 0;
            this.gaugeDownload.ScaleNumbersStartScaleLine = 0;
            this.gaugeDownload.ScaleNumbersStepScaleLines = 1;
            this.gaugeDownload.Size = new System.Drawing.Size(231, 193);
            this.gaugeDownload.TabIndex = 2;
            this.gaugeDownload.Value = 0F;
            // 
            // socketGauge
            // 
            this.socketGauge.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.socketGauge.BaseArcColor = System.Drawing.Color.Gray;
            this.socketGauge.BaseArcRadius = 80;
            this.socketGauge.BaseArcStart = 135;
            this.socketGauge.BaseArcSweep = 270;
            this.socketGauge.BaseArcWidth = 2;
            this.socketGauge.Center = new System.Drawing.Point(100, 100);
            aGaugeLabel3.Color = System.Drawing.Color.Green;
            aGaugeLabel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            aGaugeLabel3.Name = "GaugeLabel1";
            aGaugeLabel3.Position = new System.Drawing.Point(70, 170);
            aGaugeLabel3.Text = "Socket Speed";
            this.socketGauge.GaugeLabels.Add(aGaugeLabel3);
            aGaugeRange5.Color = System.Drawing.Color.Green;
            aGaugeRange5.EndValue = 200F;
            aGaugeRange5.InnerRadius = 2;
            aGaugeRange5.InRange = false;
            aGaugeRange5.Name = "GaugeRange1";
            aGaugeRange5.OuterRadius = 4;
            aGaugeRange5.StartValue = 0F;
            aGaugeRange6.Color = System.Drawing.Color.Empty;
            aGaugeRange6.EndValue = 600F;
            aGaugeRange6.InnerRadius = 1;
            aGaugeRange6.InRange = false;
            aGaugeRange6.Name = "GaugeRange2";
            aGaugeRange6.OuterRadius = 2;
            aGaugeRange6.StartValue = 200F;
            this.socketGauge.GaugeRanges.Add(aGaugeRange5);
            this.socketGauge.GaugeRanges.Add(aGaugeRange6);
            this.socketGauge.Location = new System.Drawing.Point(354, 48);
            this.socketGauge.MaxValue = 5000F;
            this.socketGauge.MinValue = 0F;
            this.socketGauge.Name = "socketGauge";
            this.socketGauge.NeedleColor1 = System.Windows.Forms.AGaugeNeedleColor.Gray;
            this.socketGauge.NeedleColor2 = System.Drawing.Color.DimGray;
            this.socketGauge.NeedleRadius = 100;
            this.socketGauge.NeedleType = System.Windows.Forms.NeedleType.Advance;
            this.socketGauge.NeedleWidth = 2;
            this.socketGauge.ScaleLinesInterColor = System.Drawing.Color.Black;
            this.socketGauge.ScaleLinesInterInnerRadius = 73;
            this.socketGauge.ScaleLinesInterOuterRadius = 80;
            this.socketGauge.ScaleLinesInterWidth = 1;
            this.socketGauge.ScaleLinesMajorColor = System.Drawing.Color.Red;
            this.socketGauge.ScaleLinesMajorInnerRadius = 70;
            this.socketGauge.ScaleLinesMajorOuterRadius = 80;
            this.socketGauge.ScaleLinesMajorStepValue = 500F;
            this.socketGauge.ScaleLinesMajorWidth = 2;
            this.socketGauge.ScaleLinesMinorColor = System.Drawing.Color.Green;
            this.socketGauge.ScaleLinesMinorInnerRadius = 75;
            this.socketGauge.ScaleLinesMinorOuterRadius = 80;
            this.socketGauge.ScaleLinesMinorTicks = 10;
            this.socketGauge.ScaleLinesMinorWidth = 2;
            this.socketGauge.ScaleNumbersColor = System.Drawing.Color.Black;
            this.socketGauge.ScaleNumbersFormat = null;
            this.socketGauge.ScaleNumbersRadius = 92;
            this.socketGauge.ScaleNumbersRotation = 0;
            this.socketGauge.ScaleNumbersStartScaleLine = 0;
            this.socketGauge.ScaleNumbersStepScaleLines = 1;
            this.socketGauge.Size = new System.Drawing.Size(216, 193);
            this.socketGauge.TabIndex = 1;
            this.socketGauge.Value = 0F;
            // 
            // pingGauge
            // 
            this.pingGauge.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pingGauge.BaseArcColor = System.Drawing.Color.Gray;
            this.pingGauge.BaseArcRadius = 80;
            this.pingGauge.BaseArcStart = 135;
            this.pingGauge.BaseArcSweep = 270;
            this.pingGauge.BaseArcWidth = 2;
            this.pingGauge.Center = new System.Drawing.Point(100, 100);
            aGaugeLabel4.Color = System.Drawing.Color.Blue;
            aGaugeLabel4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            aGaugeLabel4.Name = "GaugeLabel1";
            aGaugeLabel4.Position = new System.Drawing.Point(50, 170);
            aGaugeLabel4.Text = "Ping Response (ms)";
            this.pingGauge.GaugeLabels.Add(aGaugeLabel4);
            aGaugeRange7.Color = System.Drawing.Color.Green;
            aGaugeRange7.EndValue = 200F;
            aGaugeRange7.InnerRadius = 2;
            aGaugeRange7.InRange = false;
            aGaugeRange7.Name = "GaugeRange1";
            aGaugeRange7.OuterRadius = 4;
            aGaugeRange7.StartValue = 0F;
            aGaugeRange8.Color = System.Drawing.Color.Empty;
            aGaugeRange8.EndValue = 600F;
            aGaugeRange8.InnerRadius = 1;
            aGaugeRange8.InRange = false;
            aGaugeRange8.Name = "GaugeRange2";
            aGaugeRange8.OuterRadius = 2;
            aGaugeRange8.StartValue = 200F;
            this.pingGauge.GaugeRanges.Add(aGaugeRange7);
            this.pingGauge.GaugeRanges.Add(aGaugeRange8);
            this.pingGauge.Location = new System.Drawing.Point(92, 48);
            this.pingGauge.MaxValue = 1000F;
            this.pingGauge.MinValue = 0F;
            this.pingGauge.Name = "pingGauge";
            this.pingGauge.NeedleColor1 = System.Windows.Forms.AGaugeNeedleColor.Gray;
            this.pingGauge.NeedleColor2 = System.Drawing.Color.DimGray;
            this.pingGauge.NeedleRadius = 100;
            this.pingGauge.NeedleType = System.Windows.Forms.NeedleType.Advance;
            this.pingGauge.NeedleWidth = 2;
            this.pingGauge.ScaleLinesInterColor = System.Drawing.Color.Black;
            this.pingGauge.ScaleLinesInterInnerRadius = 73;
            this.pingGauge.ScaleLinesInterOuterRadius = 80;
            this.pingGauge.ScaleLinesInterWidth = 1;
            this.pingGauge.ScaleLinesMajorColor = System.Drawing.Color.Red;
            this.pingGauge.ScaleLinesMajorInnerRadius = 70;
            this.pingGauge.ScaleLinesMajorOuterRadius = 80;
            this.pingGauge.ScaleLinesMajorStepValue = 50F;
            this.pingGauge.ScaleLinesMajorWidth = 2;
            this.pingGauge.ScaleLinesMinorColor = System.Drawing.Color.Blue;
            this.pingGauge.ScaleLinesMinorInnerRadius = 75;
            this.pingGauge.ScaleLinesMinorOuterRadius = 80;
            this.pingGauge.ScaleLinesMinorTicks = 10;
            this.pingGauge.ScaleLinesMinorWidth = 2;
            this.pingGauge.ScaleNumbersColor = System.Drawing.Color.Black;
            this.pingGauge.ScaleNumbersFormat = null;
            this.pingGauge.ScaleNumbersRadius = 92;
            this.pingGauge.ScaleNumbersRotation = 0;
            this.pingGauge.ScaleNumbersStartScaleLine = 0;
            this.pingGauge.ScaleNumbersStepScaleLines = 1;
            this.pingGauge.Size = new System.Drawing.Size(231, 193);
            this.pingGauge.TabIndex = 0;
            this.pingGauge.Value = 0F;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.Controls.Add(this.rtbChat);
            this.tabPage1.Controls.Add(this.txtMessage);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1142, 510);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Command Prompt";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage2.Controls.Add(this.lvprocesslist);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1142, 510);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Task Manager";
            // 
            // lvprocesslist
            // 
            this.lvprocesslist.Alignment = System.Windows.Forms.ListViewAlignment.SnapToGrid;
            this.lvprocesslist.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.procname,
            this.PID,
            this.procstarttime,
            this.proccputime,
            this.memusage,
            this.peakmemusage,
            this.noofhandles,
            this.nonofthreads});
            this.lvprocesslist.ContextMenu = this.lvcxtmnu;
            this.lvprocesslist.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvprocesslist.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvprocesslist.FullRowSelect = true;
            this.lvprocesslist.Location = new System.Drawing.Point(3, 3);
            this.lvprocesslist.Name = "lvprocesslist";
            this.lvprocesslist.Size = new System.Drawing.Size(1136, 504);
            this.lvprocesslist.TabIndex = 1;
            this.lvprocesslist.UseCompatibleStateImageBehavior = false;
            this.lvprocesslist.View = System.Windows.Forms.View.Details;
            // 
            // procname
            // 
            this.procname.Text = "Process Name";
            this.procname.Width = 120;
            // 
            // PID
            // 
            this.PID.Text = "PID";
            // 
            // procstarttime
            // 
            this.procstarttime.Text = "Start Time";
            this.procstarttime.Width = 70;
            // 
            // proccputime
            // 
            this.proccputime.Text = "CPU Time";
            this.proccputime.Width = 80;
            // 
            // memusage
            // 
            this.memusage.Text = "Memory Usage";
            this.memusage.Width = 90;
            // 
            // peakmemusage
            // 
            this.peakmemusage.Text = "Peak  memory usage";
            this.peakmemusage.Width = 120;
            // 
            // noofhandles
            // 
            this.noofhandles.Text = "No.of Handles";
            this.noofhandles.Width = 90;
            // 
            // nonofthreads
            // 
            this.nonofthreads.Text = "No.of Threads";
            this.nonofthreads.Width = 90;
            // 
            // lvcxtmnu
            // 
            this.lvcxtmnu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem9,
            this.menuItem1});
            // 
            // menuItem9
            // 
            this.menuItem9.Index = 0;
            this.menuItem9.Text = "End Process";
            this.menuItem9.Click += new System.EventHandler(this.menuItem9_Click);
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 1;
            this.menuItem1.Text = "Refresh";
            this.menuItem1.Click += new System.EventHandler(this.menuItem1_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage3.Controls.Add(this.tableLayoutPanel1);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(1142, 510);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Realtime Logs";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox4, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1142, 510);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.richTextBox1);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(3, 3);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(1136, 213);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Active Window Logs";
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.Color.Black;
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.richTextBox1.Location = new System.Drawing.Point(3, 16);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.richTextBox1.Size = new System.Drawing.Size(1130, 194);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.richTextBox2);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(3, 258);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1136, 213);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Realtime Key Logs";
            // 
            // richTextBox2
            // 
            this.richTextBox2.BackColor = System.Drawing.Color.Black;
            this.richTextBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox2.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.richTextBox2.Location = new System.Drawing.Point(3, 16);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.ReadOnly = true;
            this.richTextBox2.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.richTextBox2.Size = new System.Drawing.Size(1130, 194);
            this.richTextBox2.TabIndex = 2;
            this.richTextBox2.Text = "";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 222);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1136, 30);
            this.panel1.TabIndex = 3;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(5, 3);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(145, 23);
            this.button3.TabIndex = 2;
            this.button3.Text = "Write logs to Text File";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(974, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Stop";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(1055, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Start";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.button6);
            this.panel2.Controls.Add(this.button5);
            this.panel2.Controls.Add(this.button4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 477);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1136, 30);
            this.panel2.TabIndex = 4;
            // 
            // button6
            // 
            this.button6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button6.Location = new System.Drawing.Point(977, 3);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 23);
            this.button6.TabIndex = 2;
            this.button6.Text = "Stop";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button5
            // 
            this.button5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button5.Location = new System.Drawing.Point(1058, 3);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 1;
            this.button5.Text = "Start";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(5, 3);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(145, 23);
            this.button4.TabIndex = 0;
            this.button4.Text = "Write logs to Text File";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // tabPage4
            // 
            this.tabPage4.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage4.Controls.Add(this.stopButton);
            this.tabPage4.Controls.Add(this.label2);
            this.tabPage4.Controls.Add(this.groupBox2);
            this.tabPage4.Controls.Add(this.fileNameTextBox);
            this.tabPage4.Controls.Add(this.groupBox1);
            this.tabPage4.Controls.Add(this.label1);
            this.tabPage4.Controls.Add(this.startButton);
            this.tabPage4.Controls.Add(this.searchDirTextBox);
            this.tabPage4.Controls.Add(this.includeSubDirsCheckBox);
            this.tabPage4.Controls.Add(this.selectSearchDirButton);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(1142, 510);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Remote Search";
            // 
            // stopButton
            // 
            this.stopButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.stopButton.Enabled = false;
            this.stopButton.Location = new System.Drawing.Point(353, 212);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(75, 23);
            this.stopButton.TabIndex = 17;
            this.stopButton.Text = "Stop";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Search directory:";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.delimeterTextBox);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.writeResultsButton);
            this.groupBox2.Controls.Add(this.resultsList);
            this.groupBox2.Location = new System.Drawing.Point(20, 241);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(489, 259);
            this.groupBox2.TabIndex = 19;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Results";
            // 
            // delimeterTextBox
            // 
            this.delimeterTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.delimeterTextBox.Location = new System.Drawing.Point(254, 232);
            this.delimeterTextBox.MaxLength = 4;
            this.delimeterTextBox.Name = "delimeterTextBox";
            this.delimeterTextBox.Size = new System.Drawing.Size(38, 20);
            this.delimeterTextBox.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 235);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(249, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Delimeter for text file (may include escapes \\r,\\n,\\t):";
            // 
            // writeResultsButton
            // 
            this.writeResultsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.writeResultsButton.Location = new System.Drawing.Point(333, 230);
            this.writeResultsButton.Name = "writeResultsButton";
            this.writeResultsButton.Size = new System.Drawing.Size(150, 23);
            this.writeResultsButton.TabIndex = 3;
            this.writeResultsButton.Text = "Write results to text file...";
            this.writeResultsButton.UseVisualStyleBackColor = true;
            this.writeResultsButton.Click += new System.EventHandler(this.writeResultsButton_Click);
            // 
            // resultsList
            // 
            this.resultsList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.resultsList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.resultsList.ContextMenuStrip = this.contextMenuStrip;
            this.resultsList.FullRowSelect = true;
            this.resultsList.Location = new System.Drawing.Point(6, 19);
            this.resultsList.MultiSelect = false;
            this.resultsList.Name = "resultsList";
            this.resultsList.ShowItemToolTips = true;
            this.resultsList.Size = new System.Drawing.Size(477, 205);
            this.resultsList.TabIndex = 0;
            this.resultsList.UseCompatibleStateImageBehavior = false;
            this.resultsList.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Path";
            this.columnHeader1.Width = 212;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Size";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader2.Width = 90;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Last modified";
            this.columnHeader3.Width = 120;
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openContainingFolderContextMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(198, 26);
            // 
            // openContainingFolderContextMenuItem
            // 
            this.openContainingFolderContextMenuItem.Name = "openContainingFolderContextMenuItem";
            this.openContainingFolderContextMenuItem.Size = new System.Drawing.Size(197, 22);
            this.openContainingFolderContextMenuItem.Text = "Open containing folder";
            // 
            // fileNameTextBox
            // 
            this.fileNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fileNameTextBox.Location = new System.Drawing.Point(281, 60);
            this.fileNameTextBox.Name = "fileNameTextBox";
            this.fileNameTextBox.Size = new System.Drawing.Size(222, 20);
            this.fileNameTextBox.TabIndex = 15;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.unicodeRadioButton);
            this.groupBox1.Controls.Add(this.asciiRadioButton);
            this.groupBox1.Controls.Add(this.containingTextBox);
            this.groupBox1.Controls.Add(this.containingCheckBox);
            this.groupBox1.Controls.Add(this.olderThanDateTimePicker);
            this.groupBox1.Controls.Add(this.newerThanCheckBox);
            this.groupBox1.Controls.Add(this.olderThanCheckBox);
            this.groupBox1.Controls.Add(this.newerThanDateTimePicker);
            this.groupBox1.Location = new System.Drawing.Point(20, 86);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(489, 120);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Restrictions";
            // 
            // unicodeRadioButton
            // 
            this.unicodeRadioButton.AutoSize = true;
            this.unicodeRadioButton.Enabled = false;
            this.unicodeRadioButton.Location = new System.Drawing.Point(319, 97);
            this.unicodeRadioButton.Name = "unicodeRadioButton";
            this.unicodeRadioButton.Size = new System.Drawing.Size(65, 17);
            this.unicodeRadioButton.TabIndex = 7;
            this.unicodeRadioButton.TabStop = true;
            this.unicodeRadioButton.Text = "Unicode";
            this.unicodeRadioButton.UseVisualStyleBackColor = true;
            // 
            // asciiRadioButton
            // 
            this.asciiRadioButton.AutoSize = true;
            this.asciiRadioButton.Enabled = false;
            this.asciiRadioButton.Location = new System.Drawing.Point(261, 97);
            this.asciiRadioButton.Name = "asciiRadioButton";
            this.asciiRadioButton.Size = new System.Drawing.Size(52, 17);
            this.asciiRadioButton.TabIndex = 6;
            this.asciiRadioButton.TabStop = true;
            this.asciiRadioButton.Text = "ASCII";
            this.asciiRadioButton.UseVisualStyleBackColor = true;
            // 
            // containingTextBox
            // 
            this.containingTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.containingTextBox.Enabled = false;
            this.containingTextBox.Location = new System.Drawing.Point(261, 71);
            this.containingTextBox.Name = "containingTextBox";
            this.containingTextBox.Size = new System.Drawing.Size(222, 20);
            this.containingTextBox.TabIndex = 5;
            // 
            // containingCheckBox
            // 
            this.containingCheckBox.AutoSize = true;
            this.containingCheckBox.Location = new System.Drawing.Point(6, 73);
            this.containingCheckBox.Name = "containingCheckBox";
            this.containingCheckBox.Size = new System.Drawing.Size(224, 17);
            this.containingCheckBox.TabIndex = 4;
            this.containingCheckBox.Text = "Files containing the string (case sensitive):";
            this.containingCheckBox.UseVisualStyleBackColor = true;
            this.containingCheckBox.CheckedChanged += new System.EventHandler(this.containingCheckBox_CheckedChanged);
            // 
            // olderThanDateTimePicker
            // 
            this.olderThanDateTimePicker.CustomFormat = "dd.MM.yyyy HH:mm";
            this.olderThanDateTimePicker.Enabled = false;
            this.olderThanDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.olderThanDateTimePicker.Location = new System.Drawing.Point(261, 45);
            this.olderThanDateTimePicker.Name = "olderThanDateTimePicker";
            this.olderThanDateTimePicker.Size = new System.Drawing.Size(123, 20);
            this.olderThanDateTimePicker.TabIndex = 3;
            // 
            // newerThanCheckBox
            // 
            this.newerThanCheckBox.AutoSize = true;
            this.newerThanCheckBox.Location = new System.Drawing.Point(6, 22);
            this.newerThanCheckBox.Name = "newerThanCheckBox";
            this.newerThanCheckBox.Size = new System.Drawing.Size(106, 17);
            this.newerThanCheckBox.TabIndex = 0;
            this.newerThanCheckBox.Text = "Files newer than:";
            this.newerThanCheckBox.UseVisualStyleBackColor = true;
            this.newerThanCheckBox.CheckedChanged += new System.EventHandler(this.newerThanCheckBox_CheckedChanged);
            // 
            // olderThanCheckBox
            // 
            this.olderThanCheckBox.AutoSize = true;
            this.olderThanCheckBox.Location = new System.Drawing.Point(6, 48);
            this.olderThanCheckBox.Name = "olderThanCheckBox";
            this.olderThanCheckBox.Size = new System.Drawing.Size(100, 17);
            this.olderThanCheckBox.TabIndex = 2;
            this.olderThanCheckBox.Text = "Files older than:";
            this.olderThanCheckBox.UseVisualStyleBackColor = true;
            this.olderThanCheckBox.CheckedChanged += new System.EventHandler(this.olderThanCheckBox_CheckedChanged);
            // 
            // newerThanDateTimePicker
            // 
            this.newerThanDateTimePicker.CustomFormat = "dd.MM.yyyy HH:mm";
            this.newerThanDateTimePicker.Enabled = false;
            this.newerThanDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.newerThanDateTimePicker.Location = new System.Drawing.Point(261, 19);
            this.newerThanDateTimePicker.Name = "newerThanDateTimePicker";
            this.newerThanDateTimePicker.Size = new System.Drawing.Size(123, 20);
            this.newerThanDateTimePicker.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(255, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Filename (may include wildcards, not case sensitive):";
            // 
            // startButton
            // 
            this.startButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.startButton.Location = new System.Drawing.Point(434, 212);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(75, 23);
            this.startButton.TabIndex = 18;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // searchDirTextBox
            // 
            this.searchDirTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.searchDirTextBox.Location = new System.Drawing.Point(125, 11);
            this.searchDirTextBox.Name = "searchDirTextBox";
            this.searchDirTextBox.Size = new System.Drawing.Size(354, 20);
            this.searchDirTextBox.TabIndex = 11;
            // 
            // includeSubDirsCheckBox
            // 
            this.includeSubDirsCheckBox.AutoSize = true;
            this.includeSubDirsCheckBox.Location = new System.Drawing.Point(125, 37);
            this.includeSubDirsCheckBox.Name = "includeSubDirsCheckBox";
            this.includeSubDirsCheckBox.Size = new System.Drawing.Size(129, 17);
            this.includeSubDirsCheckBox.TabIndex = 13;
            this.includeSubDirsCheckBox.Text = "Include subdirectories";
            this.includeSubDirsCheckBox.UseVisualStyleBackColor = true;
            // 
            // selectSearchDirButton
            // 
            this.selectSearchDirButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.selectSearchDirButton.Location = new System.Drawing.Point(485, 11);
            this.selectSearchDirButton.Name = "selectSearchDirButton";
            this.selectSearchDirButton.Size = new System.Drawing.Size(24, 21);
            this.selectSearchDirButton.TabIndex = 12;
            this.selectSearchDirButton.Text = "...";
            this.selectSearchDirButton.UseVisualStyleBackColor = true;
            // 
            // tabPage5
            // 
            this.tabPage5.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage5.Controls.Add(this.splitContainer1);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(1142, 510);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "File Explorer";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.treeView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.lstClientFiles);
            this.splitContainer1.Size = new System.Drawing.Size(1142, 510);
            this.splitContainer1.SplitterDistance = 255;
            this.splitContainer1.TabIndex = 10;
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.HotTracking = true;
            this.treeView1.ImageIndex = 0;
            this.treeView1.ImageList = this.imageList1;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            this.treeView1.SelectedImageIndex = 0;
            this.treeView1.Size = new System.Drawing.Size(1142, 255);
            this.treeView1.TabIndex = 5;
            this.treeView1.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterExpand);
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Drive");
            this.imageList1.Images.SetKeyName(1, "Folder");
            this.imageList1.Images.SetKeyName(2, "");
            this.imageList1.Images.SetKeyName(3, "");
            this.imageList1.Images.SetKeyName(4, "");
            this.imageList1.Images.SetKeyName(5, "");
            this.imageList1.Images.SetKeyName(6, "");
            this.imageList1.Images.SetKeyName(7, "");
            this.imageList1.Images.SetKeyName(8, "");
            this.imageList1.Images.SetKeyName(9, "Document");
            this.imageList1.Images.SetKeyName(10, "Desktop");
            this.imageList1.Images.SetKeyName(11, "");
            this.imageList1.Images.SetKeyName(12, "Computer");
            this.imageList1.Images.SetKeyName(13, "Network");
            this.imageList1.Images.SetKeyName(14, "");
            this.imageList1.Images.SetKeyName(15, "");
            this.imageList1.Images.SetKeyName(16, "");
            this.imageList1.Images.SetKeyName(17, "");
            this.imageList1.Images.SetKeyName(18, "");
            this.imageList1.Images.SetKeyName(19, "");
            this.imageList1.Images.SetKeyName(20, "");
            this.imageList1.Images.SetKeyName(21, "");
            this.imageList1.Images.SetKeyName(22, "");
            this.imageList1.Images.SetKeyName(23, "");
            this.imageList1.Images.SetKeyName(24, "");
            this.imageList1.Images.SetKeyName(25, "");
            this.imageList1.Images.SetKeyName(26, "");
            this.imageList1.Images.SetKeyName(27, "");
            this.imageList1.Images.SetKeyName(28, "");
            // 
            // lstClientFiles
            // 
            this.lstClientFiles.AllowDrop = true;
            this.lstClientFiles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmName,
            this.clmSize,
            this.clmType});
            this.lstClientFiles.ContextMenuStrip = this.contextMenuStrip1;
            this.lstClientFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstClientFiles.Location = new System.Drawing.Point(0, 0);
            this.lstClientFiles.Name = "lstClientFiles";
            this.lstClientFiles.Size = new System.Drawing.Size(1142, 251);
            this.lstClientFiles.TabIndex = 9;
            this.lstClientFiles.UseCompatibleStateImageBehavior = false;
            this.lstClientFiles.View = System.Windows.Forms.View.Details;
            // 
            // clmName
            // 
            this.clmName.Text = "File Name";
            this.clmName.Width = 169;
            // 
            // clmSize
            // 
            this.clmSize.Text = "Size";
            this.clmSize.Width = 113;
            // 
            // clmType
            // 
            this.clmType.Text = "File Type";
            this.clmType.Width = 203;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.uploadToolStripMenuItem,
            this.downloadToolStripMenuItem,
            this.downloadCMDToolStripMenuItem,
            this.openToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.renameToolStripMenuItem,
            this.resetToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(167, 158);
            // 
            // uploadToolStripMenuItem
            // 
            this.uploadToolStripMenuItem.Name = "uploadToolStripMenuItem";
            this.uploadToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.uploadToolStripMenuItem.Text = "Upload";
            this.uploadToolStripMenuItem.Click += new System.EventHandler(this.uploadToolStripMenuItem_Click);
            // 
            // downloadToolStripMenuItem
            // 
            this.downloadToolStripMenuItem.Name = "downloadToolStripMenuItem";
            this.downloadToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.downloadToolStripMenuItem.Text = "Download";
            this.downloadToolStripMenuItem.Click += new System.EventHandler(this.downloadToolStripMenuItem_Click);
            // 
            // downloadCMDToolStripMenuItem
            // 
            this.downloadCMDToolStripMenuItem.Name = "downloadCMDToolStripMenuItem";
            this.downloadCMDToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.downloadCMDToolStripMenuItem.Text = "Download (CMD)";
            this.downloadCMDToolStripMenuItem.Click += new System.EventHandler(this.downloadCMDToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // renameToolStripMenuItem
            // 
            this.renameToolStripMenuItem.Name = "renameToolStripMenuItem";
            this.renameToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.renameToolStripMenuItem.Text = "Rename";
            // 
            // resetToolStripMenuItem
            // 
            this.resetToolStripMenuItem.Name = "resetToolStripMenuItem";
            this.resetToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.resetToolStripMenuItem.Text = "Reset";
            this.resetToolStripMenuItem.Click += new System.EventHandler(this.resetToolStripMenuItem_Click);
            // 
            // tabPage6
            // 
            this.tabPage6.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage6.Controls.Add(this.tableLayoutPanel2);
            this.tabPage6.Location = new System.Drawing.Point(4, 22);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(1142, 510);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Text = "Live Desktop";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.panel3, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.groupBox5, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1136, 504);
            this.tableLayoutPanel2.TabIndex = 7;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.checkBox7);
            this.panel3.Controls.Add(this.checkBox5);
            this.panel3.Controls.Add(this.button29);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.button7);
            this.panel3.Controls.Add(this.trackBar1);
            this.panel3.Controls.Add(this.button8);
            this.panel3.Controls.Add(this.button9);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 447);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1130, 54);
            this.panel3.TabIndex = 0;
            // 
            // checkBox7
            // 
            this.checkBox7.AutoSize = true;
            this.checkBox7.Location = new System.Drawing.Point(592, 30);
            this.checkBox7.Name = "checkBox7";
            this.checkBox7.Size = new System.Drawing.Size(106, 17);
            this.checkBox7.TabIndex = 9;
            this.checkBox7.Text = "Interaction Mode";
            this.checkBox7.UseVisualStyleBackColor = true;
            // 
            // checkBox5
            // 
            this.checkBox5.AutoSize = true;
            this.checkBox5.Location = new System.Drawing.Point(592, 7);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(106, 17);
            this.checkBox5.TabIndex = 8;
            this.checkBox5.Text = "Send Keystrokes";
            this.checkBox5.UseVisualStyleBackColor = true;
            // 
            // button29
            // 
            this.button29.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.25F);
            this.button29.ForeColor = System.Drawing.Color.Maroon;
            this.button29.Image = ((System.Drawing.Image)(resources.GetObject("button29.Image")));
            this.button29.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button29.Location = new System.Drawing.Point(392, 6);
            this.button29.Name = "button29";
            this.button29.Size = new System.Drawing.Size(183, 41);
            this.button29.TabIndex = 7;
            this.button29.Text = "Record Vedio";
            this.button29.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button29.UseVisualStyleBackColor = true;
            this.button29.Click += new System.EventHandler(this.button29_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(144, 19);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(27, 13);
            this.label9.TabIndex = 6;
            this.label9.Text = "70%";
            // 
            // button7
            // 
            this.button7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button7.Location = new System.Drawing.Point(1052, 3);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(75, 23);
            this.button7.TabIndex = 1;
            this.button7.Text = "Start";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // trackBar1
            // 
            this.trackBar1.LargeChange = 50;
            this.trackBar1.Location = new System.Drawing.Point(3, 3);
            this.trackBar1.Maximum = 100;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(142, 45);
            this.trackBar1.SmallChange = 10;
            this.trackBar1.TabIndex = 2;
            this.trackBar1.TickFrequency = 10;
            this.trackBar1.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trackBar1.Value = 70;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // button8
            // 
            this.button8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button8.Location = new System.Drawing.Point(1052, 28);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(75, 23);
            this.button8.TabIndex = 4;
            this.button8.Text = "Stop";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button9
            // 
            this.button9.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.25F);
            this.button9.ForeColor = System.Drawing.Color.Maroon;
            this.button9.Image = ((System.Drawing.Image)(resources.GetObject("button9.Image")));
            this.button9.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button9.Location = new System.Drawing.Point(180, 6);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(206, 41);
            this.button9.TabIndex = 5;
            this.button9.Text = "Take Screenshot";
            this.button9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.pictureBox1);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox5.Location = new System.Drawing.Point(3, 3);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(1130, 438);
            this.groupBox5.TabIndex = 1;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Remote Desktop";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(3, 16);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1124, 419);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseClick);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            // 
            // tabPage7
            // 
            this.tabPage7.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage7.Controls.Add(this.tableLayoutPanel3);
            this.tabPage7.Location = new System.Drawing.Point(4, 22);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Size = new System.Drawing.Size(1142, 510);
            this.tabPage7.TabIndex = 6;
            this.tabPage7.Text = "Chat Box";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.panel4, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.groupBox6, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(1142, 510);
            this.tableLayoutPanel3.TabIndex = 2;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.button14);
            this.panel4.Controls.Add(this.button13);
            this.panel4.Controls.Add(this.button10);
            this.panel4.Controls.Add(this.button11);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(3, 478);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1136, 29);
            this.panel4.TabIndex = 0;
            // 
            // button14
            // 
            this.button14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button14.Location = new System.Drawing.Point(894, 3);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(75, 23);
            this.button14.TabIndex = 3;
            this.button14.Text = "Clear";
            this.button14.UseVisualStyleBackColor = true;
            this.button14.Click += new System.EventHandler(this.button14_Click);
            // 
            // button13
            // 
            this.button13.Location = new System.Drawing.Point(3, 3);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(153, 23);
            this.button13.TabIndex = 2;
            this.button13.Text = "Write Chat to Text File";
            this.button13.UseVisualStyleBackColor = true;
            // 
            // button10
            // 
            this.button10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button10.Location = new System.Drawing.Point(1056, 3);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(75, 23);
            this.button10.TabIndex = 0;
            this.button10.Text = "Start";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // button11
            // 
            this.button11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button11.Location = new System.Drawing.Point(975, 3);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(75, 23);
            this.button11.TabIndex = 1;
            this.button11.Text = "Stop";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.button12);
            this.groupBox6.Controls.Add(this.textBox2);
            this.groupBox6.Controls.Add(this.richTextBox3);
            this.groupBox6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox6.Location = new System.Drawing.Point(3, 3);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(1136, 469);
            this.groupBox6.TabIndex = 1;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Chat Box";
            // 
            // button12
            // 
            this.button12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button12.Location = new System.Drawing.Point(1056, 427);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(75, 36);
            this.button12.TabIndex = 2;
            this.button12.Text = "Send";
            this.button12.UseVisualStyleBackColor = true;
            this.button12.Click += new System.EventHandler(this.button12_Click);
            // 
            // textBox2
            // 
            this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox2.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(3, 427);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(1047, 36);
            this.textBox2.TabIndex = 1;
            this.textBox2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox2_KeyDown);
            // 
            // richTextBox3
            // 
            this.richTextBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox3.Location = new System.Drawing.Point(3, 16);
            this.richTextBox3.Name = "richTextBox3";
            this.richTextBox3.Size = new System.Drawing.Size(1128, 405);
            this.richTextBox3.TabIndex = 0;
            this.richTextBox3.Text = "";
            // 
            // tabPage8
            // 
            this.tabPage8.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage8.Controls.Add(this.groupBox8);
            this.tabPage8.Controls.Add(this.groupBox7);
            this.tabPage8.Location = new System.Drawing.Point(4, 22);
            this.tabPage8.Name = "tabPage8";
            this.tabPage8.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage8.Size = new System.Drawing.Size(1142, 510);
            this.tabPage8.TabIndex = 7;
            this.tabPage8.Text = "Webcam";
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.pictureBox2);
            this.groupBox8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox8.Location = new System.Drawing.Point(203, 3);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(936, 504);
            this.groupBox8.TabIndex = 1;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "View";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(3, 16);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(930, 485);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.label8);
            this.groupBox7.Controls.Add(this.trackBar2);
            this.groupBox7.Controls.Add(this.button19);
            this.groupBox7.Controls.Add(this.button18);
            this.groupBox7.Controls.Add(this.button16);
            this.groupBox7.Controls.Add(this.label4);
            this.groupBox7.Controls.Add(this.comboBox1);
            this.groupBox7.Controls.Add(this.button15);
            this.groupBox7.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox7.Location = new System.Drawing.Point(3, 3);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(200, 504);
            this.groupBox7.TabIndex = 0;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Options";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 152);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(100, 13);
            this.label8.TabIndex = 8;
            this.label8.Text = "Image Quality (70%)";
            // 
            // trackBar2
            // 
            this.trackBar2.Location = new System.Drawing.Point(10, 168);
            this.trackBar2.Maximum = 100;
            this.trackBar2.Name = "trackBar2";
            this.trackBar2.Size = new System.Drawing.Size(184, 45);
            this.trackBar2.TabIndex = 7;
            this.trackBar2.Value = 70;
            this.trackBar2.Scroll += new System.EventHandler(this.trackBar2_Scroll);
            // 
            // button19
            // 
            this.button19.Location = new System.Drawing.Point(7, 92);
            this.button19.Name = "button19";
            this.button19.Size = new System.Drawing.Size(72, 37);
            this.button19.TabIndex = 6;
            this.button19.Text = "Refresh";
            this.button19.UseVisualStyleBackColor = true;
            this.button19.Click += new System.EventHandler(this.button19_Click);
            // 
            // button18
            // 
            this.button18.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.25F);
            this.button18.ForeColor = System.Drawing.Color.Maroon;
            this.button18.Image = ((System.Drawing.Image)(resources.GetObject("button18.Image")));
            this.button18.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button18.Location = new System.Drawing.Point(7, 285);
            this.button18.Name = "button18";
            this.button18.Size = new System.Drawing.Size(190, 62);
            this.button18.TabIndex = 5;
            this.button18.Text = "Take Snapshot";
            this.button18.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button18.UseVisualStyleBackColor = true;
            this.button18.Click += new System.EventHandler(this.button18_Click);
            // 
            // button16
            // 
            this.button16.Location = new System.Drawing.Point(81, 92);
            this.button16.Name = "button16";
            this.button16.Size = new System.Drawing.Size(113, 37);
            this.button16.TabIndex = 3;
            this.button16.Text = "Use This Webcam";
            this.button16.UseVisualStyleBackColor = true;
            this.button16.Click += new System.EventHandler(this.button16_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Choose Webcam";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(7, 60);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(187, 26);
            this.comboBox1.TabIndex = 1;
            // 
            // button15
            // 
            this.button15.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.25F);
            this.button15.ForeColor = System.Drawing.Color.Maroon;
            this.button15.Image = ((System.Drawing.Image)(resources.GetObject("button15.Image")));
            this.button15.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button15.Location = new System.Drawing.Point(7, 219);
            this.button15.Name = "button15";
            this.button15.Size = new System.Drawing.Size(190, 60);
            this.button15.TabIndex = 0;
            this.button15.Text = "Start Streaming";
            this.button15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button15.UseVisualStyleBackColor = true;
            this.button15.Click += new System.EventHandler(this.button15_Click);
            // 
            // tabPage11
            // 
            this.tabPage11.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage11.Controls.Add(this.groupBox12);
            this.tabPage11.Controls.Add(this.groupBox13);
            this.tabPage11.Location = new System.Drawing.Point(4, 22);
            this.tabPage11.Name = "tabPage11";
            this.tabPage11.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage11.Size = new System.Drawing.Size(1142, 510);
            this.tabPage11.TabIndex = 10;
            this.tabPage11.Text = "Microphone";
            // 
            // groupBox12
            // 
            this.groupBox12.Controls.Add(this.pictureBox3);
            this.groupBox12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox12.Location = new System.Drawing.Point(260, 3);
            this.groupBox12.Name = "groupBox12";
            this.groupBox12.Size = new System.Drawing.Size(879, 504);
            this.groupBox12.TabIndex = 3;
            this.groupBox12.TabStop = false;
            this.groupBox12.Text = "View";
            // 
            // pictureBox3
            // 
            this.pictureBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(3, 16);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(873, 485);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 1;
            this.pictureBox3.TabStop = false;
            // 
            // groupBox13
            // 
            this.groupBox13.Controls.Add(this.button20);
            this.groupBox13.Controls.Add(this.button21);
            this.groupBox13.Controls.Add(this.button22);
            this.groupBox13.Controls.Add(this.label10);
            this.groupBox13.Controls.Add(this.comboBox3);
            this.groupBox13.Controls.Add(this.button23);
            this.groupBox13.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox13.Location = new System.Drawing.Point(3, 3);
            this.groupBox13.Name = "groupBox13";
            this.groupBox13.Size = new System.Drawing.Size(257, 504);
            this.groupBox13.TabIndex = 2;
            this.groupBox13.TabStop = false;
            this.groupBox13.Text = "Options";
            // 
            // button20
            // 
            this.button20.Location = new System.Drawing.Point(7, 92);
            this.button20.Name = "button20";
            this.button20.Size = new System.Drawing.Size(72, 37);
            this.button20.TabIndex = 6;
            this.button20.Text = "Refresh";
            this.button20.UseVisualStyleBackColor = true;
            this.button20.Click += new System.EventHandler(this.button20_Click);
            // 
            // button21
            // 
            this.button21.Location = new System.Drawing.Point(7, 178);
            this.button21.Name = "button21";
            this.button21.Size = new System.Drawing.Size(244, 37);
            this.button21.TabIndex = 5;
            this.button21.Text = "Record Stream";
            this.button21.UseVisualStyleBackColor = true;
            // 
            // button22
            // 
            this.button22.Location = new System.Drawing.Point(81, 92);
            this.button22.Name = "button22";
            this.button22.Size = new System.Drawing.Size(170, 37);
            this.button22.TabIndex = 3;
            this.button22.Text = "Use This Source";
            this.button22.UseVisualStyleBackColor = true;
            this.button22.Click += new System.EventHandler(this.button22_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(7, 41);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(102, 13);
            this.label10.TabIndex = 2;
            this.label10.Text = "Choose Microphone";
            // 
            // comboBox3
            // 
            this.comboBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(7, 60);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(244, 26);
            this.comboBox3.TabIndex = 1;
            // 
            // button23
            // 
            this.button23.Location = new System.Drawing.Point(7, 135);
            this.button23.Name = "button23";
            this.button23.Size = new System.Drawing.Size(244, 37);
            this.button23.TabIndex = 0;
            this.button23.Text = "Start Stream";
            this.button23.UseVisualStyleBackColor = true;
            this.button23.Click += new System.EventHandler(this.button23_Click);
            // 
            // tabPage9
            // 
            this.tabPage9.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage9.Controls.Add(this.groupBox10);
            this.tabPage9.Controls.Add(this.groupBox9);
            this.tabPage9.Location = new System.Drawing.Point(4, 22);
            this.tabPage9.Name = "tabPage9";
            this.tabPage9.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage9.Size = new System.Drawing.Size(1142, 510);
            this.tabPage9.TabIndex = 8;
            this.tabPage9.Text = "MessageBox";
            // 
            // groupBox10
            // 
            this.groupBox10.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox10.Controls.Add(this.button17);
            this.groupBox10.Controls.Add(this.label7);
            this.groupBox10.Controls.Add(this.label6);
            this.groupBox10.Controls.Add(this.textBox4);
            this.groupBox10.Controls.Add(this.comboBox2);
            this.groupBox10.Controls.Add(this.label5);
            this.groupBox10.Location = new System.Drawing.Point(194, 314);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(545, 146);
            this.groupBox10.TabIndex = 1;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "Message Options";
            // 
            // button17
            // 
            this.button17.Location = new System.Drawing.Point(208, 89);
            this.button17.Name = "button17";
            this.button17.Size = new System.Drawing.Size(246, 45);
            this.button17.TabIndex = 5;
            this.button17.Text = "Generate";
            this.button17.UseVisualStyleBackColor = true;
            this.button17.Click += new System.EventHandler(this.button17_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(316, 64);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(110, 13);
            this.label7.TabIndex = 4;
            this.label7.Text = "Message Status : Null";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label6.Location = new System.Drawing.Point(84, 61);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(118, 17);
            this.label6.TabIndex = 3;
            this.label6.Text = "No of Messages :";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(208, 60);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(100, 20);
            this.textBox4.TabIndex = 2;
            this.textBox4.Text = "1";
            // 
            // comboBox2
            // 
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.25F);
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "Information",
            "Warning",
            "Error",
            "Confirmation"});
            this.comboBox2.Location = new System.Drawing.Point(208, 19);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(246, 34);
            this.comboBox2.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label5.Location = new System.Drawing.Point(93, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(109, 17);
            this.label5.TabIndex = 0;
            this.label5.Text = "Message Type :";
            // 
            // groupBox9
            // 
            this.groupBox9.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox9.Controls.Add(this.textBox3);
            this.groupBox9.Location = new System.Drawing.Point(191, 42);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(548, 238);
            this.groupBox9.TabIndex = 0;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Message Text";
            // 
            // textBox3
            // 
            this.textBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox3.Location = new System.Drawing.Point(3, 16);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(542, 219);
            this.textBox3.TabIndex = 0;
            // 
            // tabPage12
            // 
            this.tabPage12.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage12.Controls.Add(this.groupBox17);
            this.tabPage12.Controls.Add(this.groupBox16);
            this.tabPage12.Location = new System.Drawing.Point(4, 22);
            this.tabPage12.Name = "tabPage12";
            this.tabPage12.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage12.Size = new System.Drawing.Size(1142, 510);
            this.tabPage12.TabIndex = 11;
            this.tabPage12.Text = "Browsers";
            // 
            // groupBox17
            // 
            this.groupBox17.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox17.Controls.Add(this.dataGridView1);
            this.groupBox17.Location = new System.Drawing.Point(73, 167);
            this.groupBox17.Name = "groupBox17";
            this.groupBox17.Size = new System.Drawing.Size(1027, 337);
            this.groupBox17.TabIndex = 4;
            this.groupBox17.TabStop = false;
            this.groupBox17.Text = "Result";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 16);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dataGridView1.Size = new System.Drawing.Size(1021, 318);
            this.dataGridView1.TabIndex = 0;
            // 
            // groupBox16
            // 
            this.groupBox16.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox16.Controls.Add(this.button40);
            this.groupBox16.Controls.Add(this.comboBox5);
            this.groupBox16.Controls.Add(this.button39);
            this.groupBox16.Controls.Add(this.button38);
            this.groupBox16.Controls.Add(this.textBox1);
            this.groupBox16.Controls.Add(this.button31);
            this.groupBox16.Controls.Add(this.button30);
            this.groupBox16.Controls.Add(this.comboBox4);
            this.groupBox16.Controls.Add(this.button24);
            this.groupBox16.Location = new System.Drawing.Point(76, 37);
            this.groupBox16.Name = "groupBox16";
            this.groupBox16.Size = new System.Drawing.Size(1024, 114);
            this.groupBox16.TabIndex = 3;
            this.groupBox16.TabStop = false;
            this.groupBox16.Text = "Detected Browsers";
            // 
            // button40
            // 
            this.button40.Location = new System.Drawing.Point(335, 59);
            this.button40.Name = "button40";
            this.button40.Size = new System.Drawing.Size(142, 33);
            this.button40.TabIndex = 9;
            this.button40.Text = "Fetch Credentials";
            this.button40.UseVisualStyleBackColor = true;
            this.button40.Click += new System.EventHandler(this.button40_Click);
            // 
            // comboBox5
            // 
            this.comboBox5.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.25F);
            this.comboBox5.FormattingEnabled = true;
            this.comboBox5.Location = new System.Drawing.Point(599, 59);
            this.comboBox5.Name = "comboBox5";
            this.comboBox5.Size = new System.Drawing.Size(302, 34);
            this.comboBox5.TabIndex = 8;
            // 
            // button39
            // 
            this.button39.Location = new System.Drawing.Point(907, 59);
            this.button39.Name = "button39";
            this.button39.Size = new System.Drawing.Size(110, 34);
            this.button39.TabIndex = 7;
            this.button39.Text = "Render HTML";
            this.button39.UseVisualStyleBackColor = true;
            // 
            // button38
            // 
            this.button38.Location = new System.Drawing.Point(483, 59);
            this.button38.Name = "button38";
            this.button38.Size = new System.Drawing.Size(110, 34);
            this.button38.TabIndex = 6;
            this.button38.Text = "Open URL";
            this.button38.UseVisualStyleBackColor = true;
            this.button38.Click += new System.EventHandler(this.button38_Click);
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.textBox1.Location = new System.Drawing.Point(335, 19);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(683, 32);
            this.textBox1.TabIndex = 5;
            // 
            // button31
            // 
            this.button31.Location = new System.Drawing.Point(27, 59);
            this.button31.Name = "button31";
            this.button31.Size = new System.Drawing.Size(110, 33);
            this.button31.TabIndex = 4;
            this.button31.Text = "Detect Browsers";
            this.button31.UseVisualStyleBackColor = true;
            this.button31.Click += new System.EventHandler(this.button31_Click);
            // 
            // button30
            // 
            this.button30.Location = new System.Drawing.Point(239, 59);
            this.button30.Name = "button30";
            this.button30.Size = new System.Drawing.Size(90, 33);
            this.button30.TabIndex = 3;
            this.button30.Text = "Clear History";
            this.button30.UseVisualStyleBackColor = true;
            this.button30.Click += new System.EventHandler(this.button30_Click);
            // 
            // comboBox4
            // 
            this.comboBox4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.25F);
            this.comboBox4.FormattingEnabled = true;
            this.comboBox4.Location = new System.Drawing.Point(27, 19);
            this.comboBox4.Name = "comboBox4";
            this.comboBox4.Size = new System.Drawing.Size(302, 34);
            this.comboBox4.TabIndex = 2;
            // 
            // button24
            // 
            this.button24.Location = new System.Drawing.Point(143, 59);
            this.button24.Name = "button24";
            this.button24.Size = new System.Drawing.Size(90, 33);
            this.button24.TabIndex = 1;
            this.button24.Text = "Read History";
            this.button24.UseVisualStyleBackColor = true;
            this.button24.Click += new System.EventHandler(this.button24_Click);
            // 
            // tabPage14
            // 
            this.tabPage14.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage14.Controls.Add(this.groupBox19);
            this.tabPage14.Controls.Add(this.groupBox18);
            this.tabPage14.Location = new System.Drawing.Point(4, 22);
            this.tabPage14.Name = "tabPage14";
            this.tabPage14.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage14.Size = new System.Drawing.Size(1142, 510);
            this.tabPage14.TabIndex = 13;
            this.tabPage14.Text = "Clipboard";
            // 
            // groupBox19
            // 
            this.groupBox19.Controls.Add(this.button35);
            this.groupBox19.Controls.Add(this.checkBox4);
            this.groupBox19.Controls.Add(this.button34);
            this.groupBox19.Controls.Add(this.checkBox3);
            this.groupBox19.Controls.Add(this.button33);
            this.groupBox19.Controls.Add(this.button32);
            this.groupBox19.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox19.Location = new System.Drawing.Point(3, 3);
            this.groupBox19.Name = "groupBox19";
            this.groupBox19.Size = new System.Drawing.Size(200, 504);
            this.groupBox19.TabIndex = 4;
            this.groupBox19.TabStop = false;
            this.groupBox19.Text = "Options";
            // 
            // button35
            // 
            this.button35.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button35.Location = new System.Drawing.Point(3, 151);
            this.button35.Name = "button35";
            this.button35.Size = new System.Drawing.Size(191, 36);
            this.button35.TabIndex = 4;
            this.button35.Text = "Fetch Clipboard";
            this.button35.UseVisualStyleBackColor = true;
            this.button35.Click += new System.EventHandler(this.button35_Click);
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Location = new System.Drawing.Point(34, 117);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(110, 17);
            this.checkBox4.TabIndex = 2;
            this.checkBox4.Text = "Sync Local Board";
            this.checkBox4.UseVisualStyleBackColor = true;
            // 
            // button34
            // 
            this.button34.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button34.Location = new System.Drawing.Point(3, 276);
            this.button34.Name = "button34";
            this.button34.Size = new System.Drawing.Size(191, 36);
            this.button34.TabIndex = 3;
            this.button34.Text = "Clear Log";
            this.button34.UseVisualStyleBackColor = true;
            this.button34.Click += new System.EventHandler(this.button34_Click);
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(34, 94);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(119, 17);
            this.checkBox3.TabIndex = 0;
            this.checkBox3.Text = "Hook into Clipboard";
            this.checkBox3.UseVisualStyleBackColor = true;
            this.checkBox3.CheckedChanged += new System.EventHandler(this.checkBox3_CheckedChanged);
            // 
            // button33
            // 
            this.button33.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button33.Location = new System.Drawing.Point(3, 234);
            this.button33.Name = "button33";
            this.button33.Size = new System.Drawing.Size(191, 36);
            this.button33.TabIndex = 2;
            this.button33.Text = "Save Data";
            this.button33.UseVisualStyleBackColor = true;
            this.button33.Click += new System.EventHandler(this.button33_Click);
            // 
            // button32
            // 
            this.button32.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button32.Location = new System.Drawing.Point(3, 192);
            this.button32.Name = "button32";
            this.button32.Size = new System.Drawing.Size(191, 36);
            this.button32.TabIndex = 1;
            this.button32.Text = "Clear Clipboard";
            this.button32.UseVisualStyleBackColor = true;
            this.button32.Click += new System.EventHandler(this.button32_Click);
            // 
            // groupBox18
            // 
            this.groupBox18.Controls.Add(this.dataGridView2);
            this.groupBox18.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox18.Location = new System.Drawing.Point(209, 3);
            this.groupBox18.Name = "groupBox18";
            this.groupBox18.Size = new System.Drawing.Size(930, 504);
            this.groupBox18.TabIndex = 0;
            this.groupBox18.TabStop = false;
            this.groupBox18.Text = "Viewer";
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView2.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView2.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView2.Location = new System.Drawing.Point(3, 16);
            this.dataGridView2.MultiSelect = false;
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView2.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridView2.RowHeadersVisible = false;
            this.dataGridView2.Size = new System.Drawing.Size(924, 485);
            this.dataGridView2.TabIndex = 0;
            this.dataGridView2.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellContentClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "No";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Data";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Time";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Action";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // tabPage15
            // 
            this.tabPage15.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage15.Controls.Add(this.groupBox20);
            this.tabPage15.Controls.Add(this.groupBox21);
            this.tabPage15.Location = new System.Drawing.Point(4, 22);
            this.tabPage15.Name = "tabPage15";
            this.tabPage15.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage15.Size = new System.Drawing.Size(1142, 510);
            this.tabPage15.TabIndex = 14;
            this.tabPage15.Text = "Device Log";
            // 
            // groupBox20
            // 
            this.groupBox20.Controls.Add(this.button36);
            this.groupBox20.Controls.Add(this.checkBox6);
            this.groupBox20.Controls.Add(this.button37);
            this.groupBox20.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox20.Location = new System.Drawing.Point(3, 3);
            this.groupBox20.Name = "groupBox20";
            this.groupBox20.Size = new System.Drawing.Size(200, 504);
            this.groupBox20.TabIndex = 6;
            this.groupBox20.TabStop = false;
            this.groupBox20.Text = "Options";
            // 
            // button36
            // 
            this.button36.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button36.Location = new System.Drawing.Point(5, 110);
            this.button36.Name = "button36";
            this.button36.Size = new System.Drawing.Size(191, 36);
            this.button36.TabIndex = 3;
            this.button36.Text = "Clear Log";
            this.button36.UseVisualStyleBackColor = true;
            this.button36.Click += new System.EventHandler(this.button36_Click);
            // 
            // checkBox6
            // 
            this.checkBox6.AutoSize = true;
            this.checkBox6.Location = new System.Drawing.Point(33, 34);
            this.checkBox6.Name = "checkBox6";
            this.checkBox6.Size = new System.Drawing.Size(149, 17);
            this.checkBox6.TabIndex = 0;
            this.checkBox6.Text = "Hook into Device Change";
            this.checkBox6.UseVisualStyleBackColor = true;
            this.checkBox6.CheckedChanged += new System.EventHandler(this.checkBox6_CheckedChanged);
            // 
            // button37
            // 
            this.button37.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button37.Location = new System.Drawing.Point(5, 68);
            this.button37.Name = "button37";
            this.button37.Size = new System.Drawing.Size(191, 36);
            this.button37.TabIndex = 2;
            this.button37.Text = "Save Data";
            this.button37.UseVisualStyleBackColor = true;
            // 
            // groupBox21
            // 
            this.groupBox21.Controls.Add(this.dataGridView3);
            this.groupBox21.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox21.Location = new System.Drawing.Point(313, 3);
            this.groupBox21.Name = "groupBox21";
            this.groupBox21.Size = new System.Drawing.Size(826, 504);
            this.groupBox21.TabIndex = 5;
            this.groupBox21.TabStop = false;
            this.groupBox21.Text = "Viewer";
            // 
            // dataGridView3
            // 
            this.dataGridView3.AllowUserToAddRows = false;
            this.dataGridView3.AllowUserToDeleteRows = false;
            this.dataGridView3.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView3.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView3.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8,
            this.dataGridViewTextBoxColumn3});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView3.DefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridView3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView3.Location = new System.Drawing.Point(3, 16);
            this.dataGridView3.MultiSelect = false;
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.ReadOnly = true;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView3.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dataGridView3.RowHeadersVisible = false;
            this.dataGridView3.Size = new System.Drawing.Size(820, 485);
            this.dataGridView3.TabIndex = 0;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.FillWeight = 76.14214F;
            this.dataGridViewTextBoxColumn1.HeaderText = "No";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.FillWeight = 111.9289F;
            this.dataGridViewTextBoxColumn2.HeaderText = "Name";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Device Type";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Event Type";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "Port";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "Volume";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.FillWeight = 111.9289F;
            this.dataGridViewTextBoxColumn3.HeaderText = "Time";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // tabPage13
            // 
            this.tabPage13.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage13.Controls.Add(this.groupBox15);
            this.tabPage13.Controls.Add(this.groupBox14);
            this.tabPage13.Location = new System.Drawing.Point(4, 22);
            this.tabPage13.Name = "tabPage13";
            this.tabPage13.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage13.Size = new System.Drawing.Size(1142, 510);
            this.tabPage13.TabIndex = 12;
            this.tabPage13.Text = "Remote Client";
            // 
            // groupBox15
            // 
            this.groupBox15.Controls.Add(this.textBox6);
            this.groupBox15.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox15.Location = new System.Drawing.Point(371, 3);
            this.groupBox15.Name = "groupBox15";
            this.groupBox15.Size = new System.Drawing.Size(768, 504);
            this.groupBox15.TabIndex = 1;
            this.groupBox15.TabStop = false;
            this.groupBox15.Text = "Status Board";
            // 
            // textBox6
            // 
            this.textBox6.BackColor = System.Drawing.Color.Black;
            this.textBox6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox6.ForeColor = System.Drawing.Color.Blue;
            this.textBox6.Location = new System.Drawing.Point(3, 16);
            this.textBox6.Multiline = true;
            this.textBox6.Name = "textBox6";
            this.textBox6.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox6.Size = new System.Drawing.Size(762, 485);
            this.textBox6.TabIndex = 0;
            // 
            // groupBox14
            // 
            this.groupBox14.Controls.Add(this.checkBox2);
            this.groupBox14.Controls.Add(this.button28);
            this.groupBox14.Controls.Add(this.button27);
            this.groupBox14.Controls.Add(this.button26);
            this.groupBox14.Controls.Add(this.checkBox1);
            this.groupBox14.Controls.Add(this.button25);
            this.groupBox14.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox14.Location = new System.Drawing.Point(3, 3);
            this.groupBox14.Name = "groupBox14";
            this.groupBox14.Size = new System.Drawing.Size(368, 504);
            this.groupBox14.TabIndex = 0;
            this.groupBox14.TabStop = false;
            this.groupBox14.Text = "Control Panel";
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.checkBox2.Location = new System.Drawing.Point(15, 233);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(119, 22);
            this.checkBox2.TabIndex = 6;
            this.checkBox2.Text = "Hard Destruct";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // button28
            // 
            this.button28.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.25F);
            this.button28.Location = new System.Drawing.Point(15, 164);
            this.button28.Name = "button28";
            this.button28.Size = new System.Drawing.Size(323, 63);
            this.button28.TabIndex = 5;
            this.button28.Text = "Self Destruct";
            this.button28.UseVisualStyleBackColor = true;
            this.button28.Click += new System.EventHandler(this.button28_Click);
            // 
            // button27
            // 
            this.button27.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.25F);
            this.button27.Location = new System.Drawing.Point(15, 373);
            this.button27.Name = "button27";
            this.button27.Size = new System.Drawing.Size(323, 63);
            this.button27.TabIndex = 4;
            this.button27.Text = "Operation Fail Safe";
            this.button27.UseVisualStyleBackColor = true;
            this.button27.Click += new System.EventHandler(this.button27_Click);
            // 
            // button26
            // 
            this.button26.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.25F);
            this.button26.Location = new System.Drawing.Point(15, 304);
            this.button26.Name = "button26";
            this.button26.Size = new System.Drawing.Size(323, 63);
            this.button26.TabIndex = 3;
            this.button26.Text = "Self Test";
            this.button26.UseVisualStyleBackColor = true;
            this.button26.Click += new System.EventHandler(this.button26_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.checkBox1.Location = new System.Drawing.Point(15, 104);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(159, 22);
            this.checkBox1.TabIndex = 2;
            this.checkBox1.Text = "Ask Admin Priviliges";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // button25
            // 
            this.button25.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.25F);
            this.button25.Location = new System.Drawing.Point(15, 35);
            this.button25.Name = "button25";
            this.button25.Size = new System.Drawing.Size(323, 63);
            this.button25.TabIndex = 1;
            this.button25.Text = "Restart";
            this.button25.UseVisualStyleBackColor = true;
            this.button25.Click += new System.EventHandler(this.button25_Click);
            // 
            // tabPage10
            // 
            this.tabPage10.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage10.Controls.Add(this.groupBox11);
            this.tabPage10.Location = new System.Drawing.Point(4, 22);
            this.tabPage10.Name = "tabPage10";
            this.tabPage10.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage10.Size = new System.Drawing.Size(1142, 510);
            this.tabPage10.TabIndex = 9;
            this.tabPage10.Text = "Client Exceptions";
            // 
            // groupBox11
            // 
            this.groupBox11.Controls.Add(this.textBox5);
            this.groupBox11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox11.Location = new System.Drawing.Point(3, 3);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new System.Drawing.Size(1136, 504);
            this.groupBox11.TabIndex = 0;
            this.groupBox11.TabStop = false;
            this.groupBox11.Text = "Log Book";
            // 
            // textBox5
            // 
            this.textBox5.ContextMenuStrip = this.contextMenuStrip2;
            this.textBox5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.25F);
            this.textBox5.ForeColor = System.Drawing.Color.Red;
            this.textBox5.Location = new System.Drawing.Point(3, 16);
            this.textBox5.Multiline = true;
            this.textBox5.Name = "textBox5";
            this.textBox5.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox5.Size = new System.Drawing.Size(1130, 485);
            this.textBox5.TabIndex = 0;
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.saveLogToolStripMenuItem});
            this.contextMenuStrip2.Name = "contextMenuStrip1";
            this.contextMenuStrip2.Size = new System.Drawing.Size(125, 48);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(124, 22);
            this.toolStripMenuItem1.Text = "Clear Log";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // saveLogToolStripMenuItem
            // 
            this.saveLogToolStripMenuItem.Name = "saveLogToolStripMenuItem";
            this.saveLogToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.saveLogToolStripMenuItem.Text = "Save Log";
            this.saveLogToolStripMenuItem.Click += new System.EventHandler(this.saveLogToolStripMenuItem_Click);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog1_FileOk);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // timer_graph
            // 
            this.timer_graph.Interval = 2500;
            // 
            // timer_ping
            // 
            this.timer_ping.Interval = 1000;
            this.timer_ping.Tick += new System.EventHandler(this.timer_ping_Tick);
            // 
            // tabPage17
            // 
            this.tabPage17.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage17.Controls.Add(this.groupBox24);
            this.tabPage17.Controls.Add(this.groupBox23);
            this.tabPage17.Location = new System.Drawing.Point(4, 22);
            this.tabPage17.Name = "tabPage17";
            this.tabPage17.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage17.Size = new System.Drawing.Size(1142, 510);
            this.tabPage17.TabIndex = 16;
            this.tabPage17.Text = "Remote SQL";
            // 
            // groupBox23
            // 
            this.groupBox23.Controls.Add(this.textBox7);
            this.groupBox23.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox23.Location = new System.Drawing.Point(3, 3);
            this.groupBox23.Name = "groupBox23";
            this.groupBox23.Size = new System.Drawing.Size(1136, 188);
            this.groupBox23.TabIndex = 0;
            this.groupBox23.TabStop = false;
            this.groupBox23.Text = "Query Box";
            // 
            // textBox7
            // 
            this.textBox7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox7.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.textBox7.Location = new System.Drawing.Point(3, 16);
            this.textBox7.Multiline = true;
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(1130, 169);
            this.textBox7.TabIndex = 0;
            this.textBox7.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox7_KeyUp);
            // 
            // groupBox24
            // 
            this.groupBox24.Controls.Add(this.richTextBox4);
            this.groupBox24.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox24.Location = new System.Drawing.Point(3, 191);
            this.groupBox24.Name = "groupBox24";
            this.groupBox24.Size = new System.Drawing.Size(1136, 316);
            this.groupBox24.TabIndex = 1;
            this.groupBox24.TabStop = false;
            this.groupBox24.Text = "Result";
            // 
            // richTextBox4
            // 
            this.richTextBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox4.Location = new System.Drawing.Point(3, 16);
            this.richTextBox4.Name = "richTextBox4";
            this.richTextBox4.Size = new System.Drawing.Size(1130, 297);
            this.richTextBox4.TabIndex = 0;
            this.richTextBox4.Text = "";
            // 
            // Controller
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1150, 582);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Controller";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Controller";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.controller_FormClosing);
            this.Load += new System.EventHandler(this.Controller_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Controller_KeyDown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage16.ResumeLayout(false);
            this.groupBox22.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.contextMenuStrip.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage5.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.tabPage6.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabPage7.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.tabPage8.ResumeLayout(false);
            this.groupBox8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).EndInit();
            this.tabPage11.ResumeLayout(false);
            this.groupBox12.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.groupBox13.ResumeLayout(false);
            this.groupBox13.PerformLayout();
            this.tabPage9.ResumeLayout(false);
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.tabPage12.ResumeLayout(false);
            this.groupBox17.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox16.ResumeLayout(false);
            this.groupBox16.PerformLayout();
            this.tabPage14.ResumeLayout(false);
            this.groupBox19.ResumeLayout(false);
            this.groupBox19.PerformLayout();
            this.groupBox18.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.tabPage15.ResumeLayout(false);
            this.groupBox20.ResumeLayout(false);
            this.groupBox20.PerformLayout();
            this.groupBox21.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            this.tabPage13.ResumeLayout(false);
            this.groupBox15.ResumeLayout(false);
            this.groupBox15.PerformLayout();
            this.groupBox14.ResumeLayout(false);
            this.groupBox14.PerformLayout();
            this.tabPage10.ResumeLayout(false);
            this.groupBox11.ResumeLayout(false);
            this.groupBox11.PerformLayout();
            this.contextMenuStrip2.ResumeLayout(false);
            this.tabPage17.ResumeLayout(false);
            this.groupBox23.ResumeLayout(false);
            this.groupBox23.PerformLayout();
            this.groupBox24.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbChat;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.ListView lvprocesslist;
        private System.Windows.Forms.ColumnHeader procname;
        private System.Windows.Forms.ColumnHeader PID;
        private System.Windows.Forms.ColumnHeader procstarttime;
        private System.Windows.Forms.ColumnHeader proccputime;
        private System.Windows.Forms.ColumnHeader memusage;
        private System.Windows.Forms.ColumnHeader peakmemusage;
        private System.Windows.Forms.ColumnHeader noofhandles;
        private System.Windows.Forms.ColumnHeader nonofthreads;
        private System.Windows.Forms.ContextMenu lvcxtmnu;
        private System.Windows.Forms.MenuItem menuItem9;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox delimeterTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button writeResultsButton;
        private System.Windows.Forms.ListView resultsList;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem openContainingFolderContextMenuItem;
        private System.Windows.Forms.TextBox fileNameTextBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton unicodeRadioButton;
        private System.Windows.Forms.RadioButton asciiRadioButton;
        private System.Windows.Forms.TextBox containingTextBox;
        private System.Windows.Forms.CheckBox containingCheckBox;
        private System.Windows.Forms.DateTimePicker olderThanDateTimePicker;
        private System.Windows.Forms.CheckBox newerThanCheckBox;
        private System.Windows.Forms.CheckBox olderThanCheckBox;
        private System.Windows.Forms.DateTimePicker newerThanDateTimePicker;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.TextBox searchDirTextBox;
        private System.Windows.Forms.CheckBox includeSubDirsCheckBox;
        private System.Windows.Forms.Button selectSearchDirButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.ListView lstClientFiles;
        private System.Windows.Forms.ColumnHeader clmName;
        private System.Windows.Forms.ColumnHeader clmSize;
        private System.Windows.Forms.ColumnHeader clmType;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem downloadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem renameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.ToolStripMenuItem uploadToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TabPage tabPage7;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.RichTextBox richTextBox3;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.TabPage tabPage8;
        private System.Windows.Forms.Button button14;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Button button19;
        private System.Windows.Forms.Button button18;
        private System.Windows.Forms.Button button16;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button15;
        private System.Windows.Forms.TabPage tabPage9;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.Button button17;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TabPage tabPage10;
        private System.Windows.Forms.GroupBox groupBox11;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem saveLogToolStripMenuItem;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TrackBar trackBar2;
        private System.Windows.Forms.TabPage tabPage11;
        private System.Windows.Forms.GroupBox groupBox12;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.GroupBox groupBox13;
        private System.Windows.Forms.Button button20;
        private System.Windows.Forms.Button button21;
        private System.Windows.Forms.Button button22;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.Button button23;
        private System.Windows.Forms.TabPage tabPage12;
        private System.Windows.Forms.Button button24;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TabPage tabPage13;
        private System.Windows.Forms.GroupBox groupBox15;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.GroupBox groupBox14;
        private System.Windows.Forms.Button button27;
        private System.Windows.Forms.Button button26;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button button25;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.Button button28;
        private System.Windows.Forms.GroupBox groupBox17;
        private System.Windows.Forms.GroupBox groupBox16;
        private System.Windows.Forms.Button button31;
        private System.Windows.Forms.Button button30;
        private System.Windows.Forms.ComboBox comboBox4;
        private System.Windows.Forms.TabPage tabPage14;
        private System.Windows.Forms.Button button32;
        private System.Windows.Forms.GroupBox groupBox18;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Button button34;
        private System.Windows.Forms.Button button33;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewButtonColumn Column4;
        private System.Windows.Forms.GroupBox groupBox19;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.Button button35;
        private System.Windows.Forms.MenuItem menuItem1;
        private System.Windows.Forms.ToolStripMenuItem resetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem downloadCMDToolStripMenuItem;
        private System.Windows.Forms.TabPage tabPage15;
        private System.Windows.Forms.GroupBox groupBox20;
        private System.Windows.Forms.Button button36;
        private System.Windows.Forms.CheckBox checkBox6;
        private System.Windows.Forms.Button button37;
        private System.Windows.Forms.GroupBox groupBox21;
        private System.Windows.Forms.DataGridView dataGridView3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.Button button29;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox comboBox5;
        private System.Windows.Forms.Button button39;
        private System.Windows.Forms.Button button38;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TabPage tabPage16;
        private System.Windows.Forms.Timer timer_graph;
        private System.Windows.Forms.Timer timer_ping;
        private AGauge pingGauge;
        private AGauge gaugeUpload;
        private AGauge gaugeDownload;
        private AGauge socketGauge;
        private Button button40;
        private CheckBox checkBox7;
        private CheckBox checkBox5;
        private GroupBox groupBox22;
        private Button button51;
        private Button button52;
        private Button button49;
        private Button button50;
        private Button button47;
        private Button button48;
        private Button button45;
        private Button button46;
        private Button button43;
        private Button button44;
        private Button button42;
        private Button button41;
        private Button button53;
        private TabPage tabPage17;
        private GroupBox groupBox24;
        private RichTextBox richTextBox4;
        private GroupBox groupBox23;
        private TextBox textBox7;
    }
}