using LibUsbDotNet.DeviceNotify;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace RemoteClient.Core
{
    public class DeviceNotification
    {
        private IDeviceNotifier UsbDeviceNotifier;

       public static DataTable getDevices()
       {
           DataTable dt = new DataTable();
           return dt;
       }

       public void Hook()
       {
           UsbDeviceNotifier = DeviceNotifier.OpenDeviceNotifier();
           UsbDeviceNotifier.OnDeviceNotify += OnDeviceNotifyEvent;
       }

       public void Unhook()
       {
           UsbDeviceNotifier.OnDeviceNotify -= OnDeviceNotifyEvent;
       }

       private void OnDeviceNotifyEvent(object sender, DeviceNotifyEventArgs e)
       {
           Send(e);   
       }

       private void Send(DeviceNotifyEventArgs device)
       {
           List<string> data = new List<string>();

           data.Add(device.Device.Name);
           data.Add(device.DeviceType.ToString());
           data.Add(device.EventType.ToString());
           data.Add(device.Port.Name);
           data.Add(device.Volume.Letter);

           RemoteClient.SendMessage(new global::DataObject
           {
               CommandType = "Device",
               CommandName = "notify",
               CommandData = data
           });
       }
    }
}
