using Microsoft.Azure.PowerShell.Cmdlets.DataBoxEdge.Common;
using Microsoft.WindowsAzure.Commands.Common.Attributes;
using System;
using System.Collections.Generic;
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

        public List<Dictionary<string, string>> UserAccessRights;
        public List<Dictionary<string, string>> ClientAccessRights;

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
            if (share.AzureContainerInfo != null)
            {
                this.StorageAccountName = GetStorageAccountCredentialAccountName(share.AzureContainerInfo
                    .StorageAccountCredentialId);
            }

            var resourceIdentifier = new DataBoxEdgeResourceIdentifier(share.Id);
            this.ResourceGroupName = resourceIdentifier.ResourceGroupName;
            this.DeviceName = resourceIdentifier.DeviceName;
            this.Name = resourceIdentifier.ResourceName;
            if (share.AccessProtocol.Equals("SMB") && share.UserAccessRights != null &&
                share.UserAccessRights.Count > 0)
            {
                UserAccessRights = new List<Dictionary<string, string>>();
                foreach (var userAccessRight in share.UserAccessRights)
                {
                    var userIdentifier = new DataBoxEdgeResourceIdentifier(userAccessRight.UserId);
                    var username = userIdentifier.Name;
                    var accessRight = new Dictionary<string, string>()
                    {
                        {"Username", username},
                        {"AccessRight", userAccessRight.AccessType}
                    };
                    UserAccessRights.Add(accessRight);
                }
            }
            else if (share.ClientAccessRights != null && share.ClientAccessRights.Count > 0)
            {
                ClientAccessRights = new List<Dictionary<string, string>>();
                foreach (var shareClientAccessRight in share.ClientAccessRights)
                {
                    var accessRight = new Dictionary<string, string>()
                    {
                        {"ClientId", shareClientAccessRight.Client},
                        {"AccessRight", shareClientAccessRight.AccessPermission}
                    };
                    ClientAccessRights.Add(accessRight);
                }
            }
        }
    }
}