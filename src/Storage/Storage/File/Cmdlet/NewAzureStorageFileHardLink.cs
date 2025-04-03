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
    using global::Azure.Storage.Files.Shares;
    using global::Azure.Storage.Files.Shares.Models;
    using Microsoft.WindowsAzure.Commands.Common.Storage.ResourceModel;
    using Microsoft.WindowsAzure.Commands.Storage.Common;
    using Microsoft.WindowsAzure.Commands.Storage.Model.ResourceModel;
    using System.Globalization;
    using System.Management.Automation;

    [Cmdlet("New", Azure.Commands.ResourceManager.Common.AzureRMConstants.AzurePrefix + "StorageFileHardLink", DefaultParameterSetName = Constants.ShareNameParameterSetName, SupportsShouldProcess = true), OutputType(typeof(AzureStorageFile))]
    public class NewAzureStorageFileHardLink : AzureStorageFileCmdletBase
    {
        [Parameter(
            Position = 0,
            Mandatory = true,
            ParameterSetName = Constants.ShareNameParameterSetName,
            HelpMessage = "Name of the file share where the directory would be created.")]
        [ValidateNotNullOrEmpty]
        public string ShareName { get; set; }

        [Parameter(
            Position = 0,
            Mandatory = true,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = Constants.ShareParameterSetName,
            HelpMessage = "ShareClient object indicated the share where the files/directories would be listed.")]
        [ValidateNotNull]
        public ShareClient ShareClient { get; set; }

        [Parameter(
            Position = 0,
            Mandatory = true,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = Constants.DirectoryParameterSetName,
            HelpMessage = "ShareDirectoryClient object indicated the base folder where the files/directories would be listed.")]
        [ValidateNotNull]
        public ShareDirectoryClient ShareDirectoryClient { get; set; }

        [Parameter(
            Position = 1,
            Mandatory = true,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Path of the hard link to be created.")]
        [ValidateNotNullOrEmpty]
        public string Path { get; set; }

        [Parameter(
            Position = 2,
            Mandatory = true,
            HelpMessage = "Path of the file to create the hard link to, not including the share. For example:\"targetDirectory/targetSubDirectory/.../targetFile\". The target file must be in the same share and hence the same storage account.")]
        [ValidateNotNullOrEmpty]
        public string TargetFile { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "If the target file has an active lease, specify the lease ID of the target file with this parameter.")]
        [ValidateNotNullOrEmpty]
        public string TargetFileLeaseId { get; set; }

        // Overwrite the useless parameter
        public override SwitchParameter DisAllowTrailingDot { get; set; }

        public override void ExecuteCmdlet()
        {
            if (ShouldProcess(this.Path, "Create File Hard Link"))
            {
                ShareDirectoryClient baseDirClient;
                switch (this.ParameterSetName)
                {
                    case Constants.DirectoryParameterSetName:
                        CheckContextForObjectInput((AzureStorageContext)this.Context);
                        baseDirClient = this.ShareDirectoryClient;
                        break;

                    case Constants.ShareNameParameterSetName:
                        NamingUtil.ValidateShareName(this.ShareName, false);
                        ShareServiceClient fileserviceClient = Util.GetTrack2FileServiceClient((AzureStorageContext)this.Context, ClientOptions);
                        baseDirClient = fileserviceClient.GetShareClient(this.ShareName).GetRootDirectoryClient();
                        break;

                    case Constants.ShareParameterSetName:
                        CheckContextForObjectInput((AzureStorageContext)this.Context);
                        baseDirClient = this.ShareClient.GetRootDirectoryClient();
                        break;

                    default:
                        throw new PSArgumentException(string.Format(CultureInfo.InvariantCulture, "Invalid parameter set name: {0}", this.ParameterSetName));
                }
                ShareFileClient sharefile = baseDirClient.GetFileClient(this.Path);
                ShareFileInfo info = sharefile.CreateHardLink(this.TargetFile,
                    this.TargetFileLeaseId is null ? null : new ShareFileRequestConditions()
                    {
                        LeaseId = null,
                    },
                    this.CmdletCancellationToken).Value;
                WriteObject(new AzureStorageFile(sharefile, (AzureStorageContext)this.Context, info, this.ClientOptions));
            }
        }
    }
}
