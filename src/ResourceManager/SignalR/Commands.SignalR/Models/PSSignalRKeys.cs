using Microsoft.Azure.Commands.SignalR.Generated.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.SignalR.Models
{
    public class PSSignalRKeys
    {
        public string Name { get; }

        public string PrimaryKey { get; }

        public string SecondaryKey { get; }

        public PSSignalRKeys(string name, SignalRKeys obj)
        {
            Name = name;
            PrimaryKey = obj.PrimaryKey;
            SecondaryKey = obj.SecondaryKey;
        }
    }
}
