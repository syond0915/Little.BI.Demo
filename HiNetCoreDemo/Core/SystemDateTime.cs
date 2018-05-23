using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HiNetCoreDemo.Core
{
    public class SystemDateTime:IDateTime
    {
        public DateTime Now
        {
            get { return DateTime.Now; }
        }
    }
}
