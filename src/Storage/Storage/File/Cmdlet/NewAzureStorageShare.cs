// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

namespace Microsoft.WindowsAzure.Commands.Storage.File.Cmdlet
{
    using System.Globalization;
    using System;
    using System.Management.Automation;
    using global::Azure.Storage.Files.Shares;
    using global::Azure.Storage.Files.Shares.Models;
    using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
    using Microsoft.WindowsAzure.Commands.Common.Storage.ResourceModel;
    using Microsoft.WindowsAzure.Commands.Storage.Common;

    [Cmdlet("New", Azure.Commands.ResourceManager.Common.AzureRMConstants.AzurePrefix + "StorageShare", DefaultParameterSetName = Constants.ShareNameParameterSetName), OutputType(typeof(AzureStorageFileShare))]
    public class NewAzureStorageShare : AzureStorageFileCmdletBase
    {
        [Parameter(
            Position = 0,
            Mandatory = true,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Name of the file share to be created.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(HelpMessage = "The protocols to enable for the share.", Mandatory = false)]
        [ValidateNotNullOrEmpty]
        [PSArgumentCompleter("Smb", "Nfs")]
        public string Protocol
        {
            get
            {
                return protocol?.ToString();
            }

            set
            {
                if (value != null)
                {
                    if (Enum.TryParse<ShareProtocols>(value, out var pro))
                    {
                        protocol = pro;
                    }
                    else
                    {
                        throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Can't parse Protocol \"{0}\", only \"Smb\" and \"Nfs\" are supported.", value));
                    }
                }
                else
                {
                    protocol = null;
                }
            }
        }
        private ShareProtocols? protocol = null;

        [Parameter(HelpMessage = "Only applicable for premium file storage accounts. Specifies whether the snapshot virtual directory should be accessible at the root of share mount point when NFS is enabled. If not specified, the default is true.", Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public bool EnableSnapshotVirtualDirectoryAccess
        {
            get
            {
                return enableSnapshotVirtualDirectoryAccess is null? true : enableSnapshotVirtualDirectoryAccess.Value;
            }
            set
            {
                enableSnapshotVirtualDirectoryAccess = value;
            }
        }
        private bool? enableSnapshotVirtualDirectoryAccess = null;

        // Overwrite the useless parameter
        public override SwitchParameter DisAllowTrailingDot { get; set; }

        public override void ExecuteCmdlet()
        {
            NamingUtil.ValidateShareName(this.Name, false);

            ShareClient share = Util.GetTrack2ShareReference(this.Name,
                (AzureStorageContext)this.Context,
                null,
                ClientOptions);
            ShareCreateOptions options = new ShareCreateOptions();
            options.Protocols = this.protocol;
            options.EnableSnapshotVirtualDirectoryAccess = this.enableSnapshotVirtualDirectoryAccess;
            share.Create(options, cancellationToken: this.CmdletCancellationToken);
            ShareProperties shareProperties = share.GetProperties(cancellationToken: this.CmdletCancellationToken).Value;
            WriteObject(new AzureStorageFileShare(share, (AzureStorageContext)this.Context, shareProperties, ClientOptions));
        }
    }
}
