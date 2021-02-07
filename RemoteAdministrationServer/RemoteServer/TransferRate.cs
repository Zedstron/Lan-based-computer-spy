using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RemoteServer
{
    class TransferRate : EventArgs
    {
        private float rate;
        public TransferRate(float trate)
        {
            rate = trate;
        }

        public float Rate
        {
            get
            {
                return rate;
            }
        }
    }
}
