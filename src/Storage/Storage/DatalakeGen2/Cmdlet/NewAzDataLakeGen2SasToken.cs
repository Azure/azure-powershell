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

namespace Microsoft.WindowsAzure.Commands.Storage.Blob.Cmdlet
{
    using Commands.Common.Storage.ResourceModel;
    using Microsoft.WindowsAzure.Commands.Storage.Common;
    using Microsoft.WindowsAzure.Commands.Storage.Model.Contract;
    using System.Management.Automation;
    using System.Security.Permissions;
    using global::Azure.Storage.Files.DataLake;
    using global::Azure.Storage.Sas;
    using System;

    /// <summary>
    /// list azure blobs in specified azure FileSystem
    /// </summary>
    [Cmdlet("New", Azure.Commands.ResourceManager.Common.AzureRMConstants.AzurePrefix + "DataLakeGen2SasToken", DefaultParameterSetName = ManualParameterSet), OutputType(typeof(String))]
    public class NewDataLakeGen2SasTokenCommand : StorageCloudBlobCmdletBase
    {
        /// <summary>
        /// manually set the name parameter
        /// </summary>
        private const string ManualParameterSet = "ReceiveManual";

        /// <summary>
        /// File or Dir pipeline
        /// </summary>
        private const string ItemParameterSet = "ItemPipeline";

        [Parameter(ValueFromPipeline = true, Position = 0, Mandatory = true, HelpMessage = "FileSystem name", ParameterSetName = ManualParameterSet)]
        [ValidateNotNullOrEmpty]
        public string FileSystem { get; set; }

        [Parameter(ValueFromPipeline = true, Mandatory = false, HelpMessage =
                "The path in the specified FileSystem that should be retrieved. Can be a file or directory " +
                "In the format 'directory/file.txt' or 'directory1/directory2/'. Skip set this parameter to get the root directory of the Filesystem.", 
            ParameterSetName = ManualParameterSet)]
        [ValidateNotNullOrEmpty]
        public string Path { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "Azure Datalake Gen2 Item Object to remove.",
            ValueFromPipeline = true, ParameterSetName = ItemParameterSet)]
        [ValidateNotNull]
        public AzureDataLakeGen2Item InputObject { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Permissions for a blob. Permissions can be any not-empty subset of \"racwdlmeop\".")]
        [ValidateNotNullOrEmpty]
        public string Permission { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Protocol can be used in the request with this SAS token.")]
        [ValidateNotNull]
        public SasProtocol? Protocol { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "IP, or IP range ACL (access control list) that the request would be accepted by Azure Storage.")]
        [ValidateNotNullOrEmpty]
        public string IPAddressOrRange { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Start Time")]
        [ValidateNotNull]
        public DateTimeOffset? StartTime { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Expiry Time")]
        [ValidateNotNull]
        public DateTimeOffset? ExpiryTime { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Display full uri with sas token")]
        public SwitchParameter FullUri { get; set; }

        // Overwrite the useless parameter
        public override int? ConcurrentTaskCount { get; set; }
        public override int? ClientTimeoutPerRequest { get; set; }
        public override int? ServerTimeoutPerRequest { get; set; }
        public override string TagCondition { get; set; }

        /// <summary>
        /// Initializes a new instance of the GetDataLakeGen2ItemCommand class.
        /// </summary>
        public NewDataLakeGen2SasTokenCommand()
            : this(null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the GetDataLakeGen2ItemCommand class.
        /// </summary>
        /// <param name="channel">IStorageBlobManagement channel</param>
        public NewDataLakeGen2SasTokenCommand(IStorageBlobManagement channel)
        {
            Channel = channel;
        }

        /// <summary>
        /// Execute command
        /// </summary>
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        public override void ExecuteCmdlet()
        {
            IStorageBlobManagement localChannel = Channel;

            // When the input context is Oauth bases, can't generate normal SAS, but UserDelegationSas
            bool generateUserDelegationSas = false;
            if (Channel != null && Channel.StorageContext != null && Channel.StorageContext.StorageAccount.Credentials.IsToken)
            {
                if (ShouldProcess(this.Path, "Generate User Delegation SAS, since input Storage Context is OAuth based."))
                {
                    generateUserDelegationSas = true;
                }
                else
                {
                    return;
                }
            }

            if (this.ParameterSetName == ItemParameterSet)
            {
                if (this.InputObject.IsDirectory)
                {
                    this.FileSystem = this.InputObject.Directory.FileSystemName;
                    this.Path = this.InputObject.Directory.Path;
                }
                else
                {
                    this.FileSystem = this.InputObject.File.FileSystemName;
                    this.Path = this.InputObject.File.Path;
                }
            }

            DataLakeSasBuilder sasBuilder = new DataLakeSasBuilder();
            sasBuilder.FileSystemName = this.FileSystem;
            sasBuilder.Path = this.Path;
            sasBuilder.SetPermissions(this.Permission, true);
            if (StartTime != null)
            {
                sasBuilder.StartsOn = StartTime.Value.ToUniversalTime();
            }
            if (ExpiryTime != null)
            {
                sasBuilder.ExpiresOn = ExpiryTime.Value.ToUniversalTime();
            }
            else
            {
                if (sasBuilder.StartsOn != DateTimeOffset.MinValue)
                {
                    sasBuilder.ExpiresOn = sasBuilder.StartsOn.AddHours(1).ToUniversalTime();
                }
                else
                {
                    sasBuilder.ExpiresOn = DateTimeOffset.UtcNow.AddHours(1);
                }
            }
            if (this.IPAddressOrRange != null)
            {
                sasBuilder.IPRange = Util.SetupIPAddressOrRangeForSASTrack2(this.IPAddressOrRange);
            }
            if (this.Protocol != null)
            {
                sasBuilder.Protocol = this.Protocol.Value;
            }

            DataLakeFileSystemClient fileSystem = GetFileSystemClientByName(localChannel, this.FileSystem);

            DataLakePathClient pathClient;
            DataLakeFileClient fileClient;
            DataLakeDirectoryClient dirClient;
            if (GetExistDataLakeGen2Item(fileSystem, this.Path, out fileClient, out dirClient))
            {
                // Directory
                sasBuilder.IsDirectory = true;
                pathClient = dirClient;
                //WriteDataLakeGen2Item(localChannel, dirClient);
                // sasBuilder.ToSasQueryParameters()
            }
            else 
            {
                //File
                sasBuilder.IsDirectory = false;
                pathClient = fileClient;
                //WriteDataLakeGen2Item(Channel, fileClient);
            }
            string sasToken = SasTokenHelper.GetDatalakeGen2SharedAccessSignature(Channel.StorageContext, sasBuilder, generateUserDelegationSas, DataLakeClientOptions, CmdletCancellationToken);


            if (FullUri)
            {
                string fullUri = pathClient.Uri.ToString();
                fullUri = fullUri + "?" + sasToken;
                WriteObject(fullUri);
            }
            else
            {
                WriteObject(sasToken);
            }
        }
    }
}
