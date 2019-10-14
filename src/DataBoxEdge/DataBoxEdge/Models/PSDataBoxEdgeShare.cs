using System;
using Microsoft.Azure.PowerShell.Cmdlets.DataBoxEdge.Common;
using Microsoft.WindowsAzure.Commands.Common.Attributes;
using Share = Microsoft.Azure.Management.EdgeGateway.Models.Share;

namespace Microsoft.Azure.PowerShell.Cmdlets.DataBoxEdge.Models
{
    public class PSDataBoxEdgeShare
    {
        [Ps1Xml(Label = "Name", Target = ViewControl.Table,
            ScriptBlock = "$_.share.Name", Position = 0)]
        [Ps1Xml(Label = "Type", Target = ViewControl.Table,
            ScriptBlock = "$_.share.AccessProtocol")]
        [Ps1Xml(Label = "DataPolicy", Target = ViewControl.Table,
            ScriptBlock = "$_.share.DataPolicy")]
        [Ps1Xml(Label = "DataFormat", Target = ViewControl.Table,
            ScriptBlock = "$_.share.AzureContainerInfo.DataFormat")]
        
        public Share Share;

        [Ps1Xml(Label = "ResourceGroupName", Target = ViewControl.Table)]
        public string ResourceGroupName;

        [Ps1Xml(Label = "Name", Target = ViewControl.Table)]
        public string StorageAccountName;

        [Ps1Xml(Label = "DeviceName", Target = ViewControl.Table)]
        public string DeviceName;
        public string Id;
        public string Name;

        public PSDataBoxEdgeShare()
        {
            Share = new Share();
        }

        private static string GetStorageAccountCredentialAccountName(string resourceId)
        {
            var splits = resourceId.Split(new[] {'/'});
            for (var i = 0; i < splits.Length; i++)
            {
                if (splits[i].Equals("storageAccountCredentials", StringComparison.CurrentCultureIgnoreCase))
                {
                    return splits[i + 1];
                }
            }

            throw new Exception("InvalidStorageAccountCredential");
        }

        public PSDataBoxEdgeShare(Share share)
        {
            this.Share = share ?? throw new ArgumentNullException("share");
            this.Id = share.Id;
            this.StorageAccountName = GetStorageAccountCredentialAccountName(share.AzureContainerInfo
                .StorageAccountCredentialId);
            var resourceIdentifier = new DataBoxEdgeResourceIdentifier(share.Id);
            this.ResourceGroupName = resourceIdentifier.ResourceGroupName;
            this.DeviceName = resourceIdentifier.DeviceName;
            this.Name = resourceIdentifier.ResourceName;
        }
    }
}