using Microsoft.Azure.PowerShell.Cmdlets.StackEdge.Common;
using Microsoft.WindowsAzure.Commands.Common.Attributes;
using StorageAccountCredential = Microsoft.Azure.Management.DataBoxEdge.Models.StorageAccountCredential;

namespace Microsoft.Azure.PowerShell.Cmdlets.StackEdge.Models
{
    public class PSStackEdgeStorageAccountCredential
    {
        [Ps1Xml(Label = "SslStatus", Target = ViewControl.Table,
            ScriptBlock = "$_.storageAccountCredential.SslStatus")]
        public StorageAccountCredential StorageAccountCredential;

        [Ps1Xml(Label = "ResourceGroupName", Target = ViewControl.Table)]
        public string ResourceGroupName;

        [Ps1Xml(Label = "DeviceName", Target = ViewControl.Table)]
        public string DeviceName;

        public string Id;
        [Ps1Xml(Label = "Name", Target = ViewControl.Table)]
        public string Name;

        public PSStackEdgeStorageAccountCredential()
        {
            StorageAccountCredential = new StorageAccountCredential();
        }

        public PSStackEdgeStorageAccountCredential(StorageAccountCredential storageAccountCredential)
        {
            this.StorageAccountCredential = storageAccountCredential;
            this.Id = storageAccountCredential.Id;
            var resourceIdentifier = new StackEdgeResourceIdentifier(storageAccountCredential.Id);
            this.ResourceGroupName = resourceIdentifier.ResourceGroupName;
            this.DeviceName = resourceIdentifier.DeviceName;
            this.Name = resourceIdentifier.ResourceName;

        }
    }
}