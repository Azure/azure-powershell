using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.SignalR
{
    public interface IWithResourceGroupAndName
    {
        string ResourceGroupName { get; set; }
        string Name { get; set; }
    }
}
