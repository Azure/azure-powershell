using Microsoft.Azure.Management.DataBoxEdge.Models;
using Microsoft.Azure.PowerShell.Cmdlets.StackEdge.Common;
using Microsoft.WindowsAzure.Commands.Common.Attributes;
using System;

namespace Microsoft.Azure.PowerShell.Cmdlets.StackEdge.Models
{
    public class PSStackEdgeStorageContainer
    {
        [Ps1Xml(Label = "Name", Target = ViewControl.Table,
            ScriptBlock = "$_.EdgeStorageContainer.Name", Position = 0)]
        [Ps1Xml(Label = "DataFormat", Target = ViewControl.Table,
            ScriptBlock = "$_.EdgeStorageContainer.DataFormat", Position = 1)]
        [Ps1Xml(Label = "Status", Target = ViewControl.Table,
            ScriptBlock = "$_.EdgeStorageContainer.ContainerStatus", Position = 2)]
        public Container EdgeStorageContainer;

        [Ps1Xml(Label = "ResourceGroupName", Target = ViewControl.Table, Position = 5)]
        public string ResourceGroupName;

        [Ps1Xml(Label = "DeviceName", Target = ViewControl.Table, Position = 4)]
        public string DeviceName;

        [Ps1Xml(Label = "EdgeStorageAccountName", Target = ViewControl.Table, Position = 3)]
        public string EdgeStorageAccountName;

        public string Id;
        public string Name;

        public PSStackEdgeStorageContainer()
        {
            EdgeStorageContainer = new Container();
        }


        public PSStackEdgeStorageContainer(Container container)
        {
            this.EdgeStorageContainer = container ?? throw new ArgumentNullException(nameof(container));
            this.Id = container.Id;
            var resourceIdentifier = new StackEdgeStorageResourceIdentifier(container.Id);
            this.ResourceGroupName = resourceIdentifier.ResourceGroupName;
            this.DeviceName = resourceIdentifier.DeviceName;
            this.EdgeStorageAccountName = resourceIdentifier.EdgeStorageAccountName;
            this.Name = resourceIdentifier.Name;
        }
    }
}