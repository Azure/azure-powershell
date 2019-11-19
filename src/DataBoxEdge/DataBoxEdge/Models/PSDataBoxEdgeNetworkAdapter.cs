using Microsoft.WindowsAzure.Commands.Common.Attributes;
using System;
using NetworkAdapter = Microsoft.Azure.Management.EdgeGateway.Models.NetworkAdapter;

namespace Microsoft.Azure.PowerShell.Cmdlets.DataBoxEdge.Models
{
    public class PSDataBoxEdgeNetworkAdapter
    {
        [Ps1Xml(Label = "Name", Target = ViewControl.Table,
            ScriptBlock = "$_.networkAdapter.NetworkAdapterName", Position = 1)]
        [Ps1Xml(Label = "IPv4", Target = ViewControl.Table,
            ScriptBlock = "$_.networkAdapter.Ipv4Configuration.IpAddress", Position = 3)]
        [Ps1Xml(Label = "IPv6", Target = ViewControl.Table,
            ScriptBlock = "$_.networkAdapter.Ipv6Configuration.IpAddress", Position = 4)]
        [Ps1Xml(Label = "Subnet", Target = ViewControl.Table,
            ScriptBlock = "$_.networkAdapter.Ipv4Configuration.Subnet", Position = 5)]
        [Ps1Xml(Label = "Default Gateway", Target = ViewControl.Table,
            ScriptBlock = "$_.networkAdapter.Ipv4Configuration.Gateway", Position = 6)]
        [Ps1Xml(Label = "Physical address", Target = ViewControl.Table,
            ScriptBlock = "$_.networkAdapter.MacAddress", Position = 7)]
        public NetworkAdapter NetworkAdapter;

        [Ps1Xml(Label = "State", Target = ViewControl.Table, Position = 2)]
        public string State;

        [Ps1Xml(Label = "DNS Servers", Target = ViewControl.Table, Position = 8)]
        public string DnsServers;

        [Ps1Xml(Label = "DeviceName", Target = ViewControl.Table, Position = 0)]
        public string DeviceName;

        


        public PSDataBoxEdgeNetworkAdapter()
        {
            NetworkAdapter = new NetworkAdapter();
        }

        public PSDataBoxEdgeNetworkAdapter(string deviceName, NetworkAdapter networkAdapter)
        {
            if (networkAdapter == null)
            {
                throw new ArgumentNullException(nameof(networkAdapter));
            }

            this.DeviceName = deviceName;
            this.NetworkAdapter = networkAdapter;
            this.State = networkAdapter.Status == "Inactive" ? "Disabled" : "Enabled";
            this.DnsServers = string.Join(",", networkAdapter.DnsServers);

        }
    }
}