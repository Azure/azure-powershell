using Microsoft.Azure.PowerShell.Cmdlets.StackEdge.Common;
using Microsoft.WindowsAzure.Commands.Common.Attributes;
using System;
using System.Collections.Generic;
using Share = Microsoft.Azure.Management.DataBoxEdge.Models.Share;

namespace Microsoft.Azure.PowerShell.Cmdlets.StackEdge.Models
{
    public class PSStackEdgeShare
    {
        [Ps1Xml(Label = "Name", Target = ViewControl.Table,
            ScriptBlock = "$_.share.Name", Position = 0)]
        [Ps1Xml(Label = "Type", Target = ViewControl.Table,
            ScriptBlock = "$_.share.AccessProtocol")]
        [Ps1Xml(Label = "DataPolicy", Target = ViewControl.Table,
            ScriptBlock = "$_.share.DataPolicy")]
        public Share Share;

        public string ResourceGroupName;

        [Ps1Xml(Label = "StorageAccountName", Target = ViewControl.Table)]
        public string StorageAccountName;

        [Ps1Xml(Label = "DeviceName", Target = ViewControl.Table)]
        public string DeviceName;

        public string Id;
        public string Name;
        public List<Dictionary<string, string>> UserAccessRight;
        public List<Dictionary<string, string>> ClientAccessRight;

        public PSStackEdgeShare()
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

        public PSStackEdgeShare(Share share)
        {
            this.Share = share ?? throw new ArgumentNullException("share");
            this.Id = share.Id;
            if (share.AzureContainerInfo != null)
            {
                this.StorageAccountName = GetStorageAccountCredentialAccountName(share.AzureContainerInfo
                    .StorageAccountCredentialId);
            }
            else
            {
                this.StorageAccountName = "N/A";
            }

            var resourceIdentifier = new StackEdgeResourceIdentifier(share.Id);
            this.ResourceGroupName = resourceIdentifier.ResourceGroupName;
            this.DeviceName = resourceIdentifier.DeviceName;
            this.Name = resourceIdentifier.ResourceName;
            if (share.AccessProtocol.Equals("SMB") && share.UserAccessRights != null &&
                share.UserAccessRights.Count > 0)
            {
                UserAccessRight = new List<Dictionary<string, string>>();
                foreach (var userAccessRight in share.UserAccessRights)
                {
                    var userIdentifier = new StackEdgeResourceIdentifier(userAccessRight.UserId);
                    var username = userIdentifier.Name;
                    var accessRight = new Dictionary<string, string>()
                    {
                        {"Username", username},
                        {"AccessRight", userAccessRight.AccessType}
                    };
                    UserAccessRight.Add(accessRight);
                }
            }
            else if (share.ClientAccessRights != null && share.ClientAccessRights.Count > 0)
            {
                ClientAccessRight = new List<Dictionary<string, string>>();
                foreach (var shareClientAccessRight in share.ClientAccessRights)
                {
                    var accessRight = new Dictionary<string, string>()
                    {
                        {"ClientId", shareClientAccessRight.Client},
                        {"AccessRight", shareClientAccessRight.AccessPermission}
                    };
                    ClientAccessRight.Add(accessRight);
                }
            }
        }
    }
}