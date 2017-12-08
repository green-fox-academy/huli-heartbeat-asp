using System;
using System.Collections.Generic;
using System.Text;

namespace HeartBeat
{
    public class ServerStatus
    {
        public ServerStatus(int Status)
        {
            HttpStatus = Status;
        }
        public int HttpStatus { get; }
    }
}
