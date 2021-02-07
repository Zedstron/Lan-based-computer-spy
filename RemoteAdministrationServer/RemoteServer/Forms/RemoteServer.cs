using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;

namespace RemoteServer
{
    public partial class RemoteServer : Form
    {
        public delegate void SetListBoxItem(String str, String type);
        
        public RemoteServer()
        {
            InitializeComponent();

            TreeNode node;
            node = tvClientList.Nodes.Add("Connected Monitoring Agents");
            ImageList il = new ImageList();
            il.Images.Add(new Icon("server.ico"));
            tvClientList.ImageList = il;
            node.ImageIndex = 1;
        }

        public void ClientAdded(object sender, EventArgs e) 
        {
            TcpClient tcpClient = ((MyEventArgs)e).clientSock;
            String remoteIP = ((IPEndPoint)tcpClient.Client.RemoteEndPoint).Address.ToString();
            String remotePort = ((IPEndPoint)tcpClient.Client.RemoteEndPoint).Port.ToString();

            UpdateClientList(remoteIP + " : " + remotePort + " : " + Myserver.Resolve(remoteIP, false), "Add"); 
        }

        public void UpdateClientList(string str, string type)
        {
            if (this.tvClientList.InvokeRequired)
            {
                SetListBoxItem d= new SetListBoxItem(UpdateClientList);
                this.Invoke(d, new object[] { str, type });
            }
            else
            {
                // If type is Add, the add Client info in Tree View
                if (type.Equals("Add"))
                {
                    this.tvClientList.Nodes[0].Nodes.Add(str);

                    if ((tvClientList.Nodes[0].GetNodeCount(false) > 0) && !tvClientList.Nodes[0].IsExpanded)
                        tvClientList.Nodes[0].Expand();
                }
                    // Else delete Client information from Tree View
                else
                {
                    foreach (TreeNode n in tvClientList.Nodes[0].Nodes)
                    {
                        if (n.Text.Contains(str))
                        {
                            tvClientList.Nodes.Remove(n);
                        }
                    }
                }
            }
        }

        private void tvClientList_DoubleClick(object sender, System.EventArgs e) 
        {
            int index = tvClientList.SelectedNode.Index;
            Myserver.Show(index);
        }


        #region Menu Commands

        /// <summary>
        /// Event Called when Main Form is closed. It stops the server and Disposes all Resources
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_FormClosing(Object sender, FormClosingEventArgs e) 
        {
            Myserver.Stop();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new MyAboutBox()).ShowDialog(); 
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        bool server = false;
        private void button1_Click(object sender, EventArgs e)
        {
            if(!server)
            {
                server = true;
                Myserver.Start(8080);
                button1.Text = "Stop Server";
            }
            else
            {
                server = false;

                Myserver.Stop();
                tvClientList.Nodes[0].Nodes.Clear();

                button1.Text = "Start Server";
            }
        }

        private void RemoteServer_Load(object sender, EventArgs e)
        {
            Myserver.owner = this;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            Myserver.OpenASAP = checkBox1.Checked;
        }
    }
}