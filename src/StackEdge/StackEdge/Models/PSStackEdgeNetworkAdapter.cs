using Microsoft.WindowsAzure.Commands.Common.Attributes;
using System;
using NetworkAdapter = Microsoft.Azure.Management.DataBoxEdge.Models.NetworkAdapter;

namespace Microsoft.Azure.PowerShell.Cmdlets.StackEdge.Models
{
    public class PSStackEdgeNetworkAdapter
    {
        [Ps1Xml(Label = "IPv4", Target = ViewControl.Table,
            ScriptBlock = "$_.networkAdapter.Ipv4Configuration.IpAddress", Position = 1)]
        [Ps1Xml(Label = "IPv6", Target = ViewControl.Table,
            ScriptBlock = "$_.networkAdapter.Ipv6Configuration.IpAddress", Position = 2)]
        [Ps1Xml(Label = "Subnet", Target = ViewControl.Table,
            ScriptBlock = "$_.networkAdapter.Ipv4Configuration.Subnet", Position = 3)]
        [Ps1Xml(Label = "Default Gateway", Target = ViewControl.Table,
            ScriptBlock = "$_.networkAdapter.Ipv4Configuration.Gateway", Position = 4)]
        [Ps1Xml(Label = "Physical address", Target = ViewControl.Table,
            ScriptBlock = "$_.networkAdapter.MacAddress", Position = 5)]
        public NetworkAdapter NetworkAdapter;

        [Ps1Xml(Label = "State", Target = ViewControl.Table, Position = 0)]
        public string State;

        [Ps1Xml(Label = "DNS Servers", Target = ViewControl.Table, Position = 6)]
        public string DnsServers;

        public PSStackEdgeNetworkAdapter()
        {
            NetworkAdapter = new NetworkAdapter();
        }

        public PSStackEdgeNetworkAdapter(NetworkAdapter networkAdapter)
        {
            if (networkAdapter == null)
            {
                throw new ArgumentNullException(nameof(networkAdapter));
            }

            this.NetworkAdapter = networkAdapter;
            this.State = networkAdapter.Status == "Inactive" ? "Disabled" : "Enabled";
            this.DnsServers = string.Join(",", networkAdapter.DnsServers);
        }
    }
}