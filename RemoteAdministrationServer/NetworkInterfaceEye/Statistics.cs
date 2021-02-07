using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkInterfaceEye
{
    public interface IStatistics
    {
        string NetworkInterface { get; }
        float DataSent { get; }
        float DataReceived { get; }
        float UploadSpeed { get; }
        float DownloadSpeed { get; }
        Queue<float> LatestDownTransfers { get; }
        Queue<float> LatestUpTransfers { get; }
    }

    public class Statistics : IStatistics
    {
        public Statistics(string name)
        {
            NetworkInterface = name;
            LatestDownTransfers = new Queue<float>(3);
            LatestUpTransfers = new Queue<float>(3);
        }

        // <summary>
        // Holds the name of the selected network interface
        // </summary>
        public string NetworkInterface { get; set; }

        // <summary>
        // Contains the data sent in the most recent time interval
        // </summary>
        public float DataSent { get; set; }

        // <summary>
        // Contains the data received in the most recent time interval
        // </summary>
        public float DataReceived { get; set; }

        // <summary>
        // Returns the upload speed in KiloBytes / Second
        // </summary>
        public float UploadSpeed
        {
            get { return LatestUpTransfers.Sum() / LatestUpTransfers.Count / 1024 / StatisticsFactory.MULTIPLIER; }
        }

        // <summary>
        // Returns the download speed in KiloBytes / Second
        // </summary>
        public float DownloadSpeed
        {
            get { return LatestDownTransfers.Sum() / LatestDownTransfers.Count / 1024 / StatisticsFactory.MULTIPLIER; }
        }

        // <summary>
        // Contains the data received in the three most recent time intervals
        // </summary>
        public Queue<float> LatestDownTransfers { get; set; }

        // <summary>
        // Contains the data sent in the three most recent time intervals
        // </summary>
        public Queue<float> LatestUpTransfers { get; set; }
    }
}
