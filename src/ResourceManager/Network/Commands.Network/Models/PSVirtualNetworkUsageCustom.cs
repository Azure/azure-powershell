using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.Network.Models
{
    public partial class PSVirtualNetworkUsage
    {
        public string NameText
        {
            get { return Name.LocalizedValue; }
        }
    }
}
