using Microsoft.Azure.PowerShell.Cmdlets.StackEdge.Common;
using Microsoft.WindowsAzure.Commands.Common.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using NetworkSettings = Microsoft.Azure.Management.DataBoxEdge.Models.NetworkSettings;

namespace Microsoft.Azure.PowerShell.Cmdlets.StackEdge.Models
{
    public class PSStackEdgeNetworkSetting
    {
        public NetworkSettings NetworkSettings;


        [Ps1Xml(Label = "ResourceGroupName", Target = ViewControl.Table, Position = 3, GroupByThis = false)]
        public string ResourceGroupName { get; set; }

        [Ps1Xml(Label = "Adapter Name", Target = ViewControl.Table, Position = 1)]
        public string Name;

        public IList<PSStackEdgeNetworkAdapter> NetworkAdapters { get; }

        [Ps1Xml(Label = "DeviceName", Target = ViewControl.Table, Position = 2)]
        public string DeviceName;

        public string Id;

        public PSStackEdgeNetworkSetting()
        {
            NetworkSettings = new NetworkSettings();
        }

        public PSStackEdgeNetworkSetting(NetworkSettings networkSettings)
        {
            if (networkSettings == null)
            {
                throw new ArgumentNullException(nameof(networkSettings));
            }

            this.NetworkSettings = networkSettings;
            this.Id = networkSettings.Id;
            var stackEdgeResourceIdentifier = new StackEdgeResourceIdentifier(networkSettings.Id);
            this.ResourceGroupName = stackEdgeResourceIdentifier.ResourceGroupName;
            this.DeviceName = stackEdgeResourceIdentifier.DeviceName;
            this.Name = stackEdgeResourceIdentifier.Name;
            this.NetworkAdapters = 
                 networkSettings.NetworkAdapters.Select(t =>
                    new PSStackEdgeNetworkAdapter(t)).ToList();
        }
    }
}