using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkInterfaceEye
{
    public static class StatisticsFactory
    {
        private static Queue<float> _latestDownTransfers = new Queue<float>();
        private static Queue<float> _latestUpTransfers = new Queue<float>();
        private static Statistics stats;

        public const int MULTIPLIER = 25;

        // <summary>
        // Creates a new statistic and uses the latest transferrates from the previous stats
        // </summary>
        public static Statistics CreateStatistics(string interfaceName)
        {
            stats = new Statistics(interfaceName)
            {
                LatestDownTransfers = _latestDownTransfers,
                LatestUpTransfers = _latestUpTransfers
            };

            return stats;
        }

        // <summary>
        // Adds a value to the current running statistics summary's upload list
        // </summary>
        public static void AddSentData(float d)
        {
            stats.DataSent = d;
            if (_latestUpTransfers.Count == 3)
            {
                _latestUpTransfers.Dequeue();
            }
            _latestUpTransfers.Enqueue(d);

            stats.LatestUpTransfers = _latestUpTransfers;
        }

        // <summary>
        // Adds a value to the current running statistics summary's download list
        // </summary>
        public static void AddReceivedData(float d)
        {
            stats.DataReceived = d;

            if (_latestDownTransfers.Count == 3)
            {
                _latestDownTransfers.Dequeue();
            }

            _latestDownTransfers.Enqueue(d);

            stats.LatestDownTransfers = _latestDownTransfers;
        }
    }
}
