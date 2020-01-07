using Microsoft.Azure.PowerShell.Cmdlets.DataBoxEdge.Common;
using Microsoft.WindowsAzure.Commands.Common.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using NetworkSettings = Microsoft.Azure.Management.DataBoxEdge.Models.NetworkSettings;

namespace Microsoft.Azure.PowerShell.Cmdlets.DataBoxEdge.Models
{
    public class PSDataBoxEdgeNetworkSetting
    {
        public NetworkSettings NetworkSettings;


        [Ps1Xml(Label = "ResourceGroupName", Target = ViewControl.Table, Position = 3, GroupByThis = false)]
        public string ResourceGroupName { get; set; }

        [Ps1Xml(Label = "Adapter Name", Target = ViewControl.Table, Position = 1)]
        public string Name;

        public IList<PSDataBoxEdgeNetworkAdapter> NetworkAdapters { get; }

        [Ps1Xml(Label = "DeviceName", Target = ViewControl.Table, Position = 2)]
        public string DeviceName;

        public string Id;

        public PSDataBoxEdgeNetworkSetting()
        {
            NetworkSettings = new NetworkSettings();
        }

        public PSDataBoxEdgeNetworkSetting(NetworkSettings networkSettings)
        {
            if (networkSettings == null)
            {
                throw new ArgumentNullException(nameof(networkSettings));
            }

            this.NetworkSettings = networkSettings;
            this.Id = networkSettings.Id;
            var dataBoxEdgeResourceIdentifier = new DataBoxEdgeResourceIdentifier(networkSettings.Id);
            this.ResourceGroupName = dataBoxEdgeResourceIdentifier.ResourceGroupName;
            this.DeviceName = dataBoxEdgeResourceIdentifier.DeviceName;
            this.Name = dataBoxEdgeResourceIdentifier.Name;
            this.NetworkAdapters = 
                 networkSettings.NetworkAdapters.Select(t =>
                    new PSDataBoxEdgeNetworkAdapter(this.DeviceName, t)).ToList();
        }
    }
}