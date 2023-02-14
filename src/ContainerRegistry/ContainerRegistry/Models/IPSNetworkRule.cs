using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.ContainerRegistry.Models
{
    public interface IPSNetworkRule
    {
        string Action { get; set; }
        string NetworkRuleType { get; }

        void Validate();
    }
}
