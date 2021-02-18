using Microsoft.Azure.PowerShell.Cmdlets.StackEdge.Common;
using Microsoft.Azure.PowerShell.Cmdlets.StackEdge.Models;
using Microsoft.WindowsAzure.Commands.Common.Attributes;
using System;
using System.Collections.Generic;
using Microsoft.Azure.Management.DataBoxEdge.Models;

namespace Microsoft.Azure.PowerShell.Cmdlets.StackEdge.Models
{
    public class PSStackEdgeStorageAccount
    {
        
        [Ps1Xml(Label = "ContainerCount", Target = ViewControl.Table,
            ScriptBlock = "$_.edgeStorageAccount.ContainerCount", Position = 1)]
        [Ps1Xml(Label = "Status", Target = ViewControl.Table,
            ScriptBlock = "$_.edgeStorageAccount.StorageAccountStatus", Position = 2)]
        [Ps1Xml(Label = "BlobEndpoint", Target = ViewControl.Table,
            ScriptBlock = "$_.edgeStorageAccount.BlobEndpoint", Position = 3)]
        public StorageAccount EdgeStorageAccount;

        
        [Ps1Xml(Label = "Name", Target = ViewControl.Table, Position = 0)]
        public string Name;

        [Ps1Xml(Label = "CloudStorageAccountName", Target = ViewControl.Table, Position = 4)]
        public string StorageAccountName;
        
        [Ps1Xml(Label = "ResourceGroupName", Target = ViewControl.Table, Position = 6)]
        public string ResourceGroupName;
        
        [Ps1Xml(Label = "DeviceName", Target = ViewControl.Table, Position = 5)]
        public string DeviceName;

        public string Id;
        
        public PSStackEdgeStorageAccount()
        {
            EdgeStorageAccount = new StorageAccount();
        }

        private static string GetStorageAccountCredentialAccountName(string resourceId)
        {
            var splits = resourceId.Split(new[] { '/' });
            for (var i = 0; i < splits.Length; i++)
            {
                if (splits[i].Equals("storageAccountCredentials", StringComparison.CurrentCultureIgnoreCase))
                {
                    return splits[i + 1];
                }
            }

            throw new Exception("InvalidStorageAccountCredential");
        }

        public PSStackEdgeStorageAccount(StorageAccount edgeStorageAccount)
        {
            this.EdgeStorageAccount = edgeStorageAccount ?? throw new ArgumentNullException("edgeStorageAccount");
            this.Id = edgeStorageAccount.Id;
            var resourceIdentifier = new StackEdgeResourceIdentifier(EdgeStorageAccount.Id);
            this.ResourceGroupName = resourceIdentifier.ResourceGroupName;
            this.DeviceName = resourceIdentifier.DeviceName;
            this.Name = resourceIdentifier.ResourceName;
            if (edgeStorageAccount.DataPolicy == "Cloud")
            {
                this.StorageAccountName = GetStorageAccountCredentialAccountName(edgeStorageAccount.StorageAccountCredentialId);
            }
        }
    }
}