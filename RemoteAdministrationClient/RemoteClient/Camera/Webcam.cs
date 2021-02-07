using AForge.Video;
using AForge.Video.DirectShow;
using RemoteClient.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RemoteClient.Camera
{
    class Webcam
    {
        private VideoCaptureDevice videoSource;
        private int depth;
        
        public Webcam(int depth)
        {
            videoSource = null;
            this.depth = depth;
        }

        internal void Stop()
        {
            if (videoSource != null)
            {
                videoSource.SignalToStop();
                videoSource.Stop();
            }
        }

        internal void Start()
        {
            if (videoSource != null)
            {
                videoSource.Start();
            }
        }

        internal void setCamera(int index)
        {
            int count = 0;
            var videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo vid in videoDevices)
            {
                if(count == index)
                {
                    videoSource = new VideoCaptureDevice(vid.MonikerString);
                    videoSource.NewFrame += video_NewFrame;
                }
            }
        }

        private void video_NewFrame(object sender, NewFrameEventArgs e)
        {
            RemoteClient.SendMessage(new global::DataObject
            {
                CommandName = "Update",
                CommandType = "Webcam",
                CommandData = Utility.Optimize(e.Frame, depth)
            });
        }

        internal List<string> Load()
        {
            List<string> temp = new List<string>();

            var videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo vid in videoDevices)
            {
                temp.Add(vid.Name);
            }

            return temp;
        }
    }
}
