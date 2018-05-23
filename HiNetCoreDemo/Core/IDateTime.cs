using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HiNetCoreDemo.Core
{
    public interface IDateTime
    {
        DateTime Now { get; }
    }
}
