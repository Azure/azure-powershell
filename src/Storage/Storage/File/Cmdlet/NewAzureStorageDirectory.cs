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
    using Microsoft.Azure.Storage.File;
    using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;
    using Microsoft.WindowsAzure.Commands.Common.Storage.ResourceModel;
    using Microsoft.WindowsAzure.Commands.Storage.Common;
    using System.Globalization;
    using System.Management.Automation;

    [CmdletOutputBreakingChangeWithVersion(typeof(AzureStorageFileDirectory), "13.0.0", "8.0.0", ChangeDescription = "The child property CloudFileDirectory from deprecated v11 SDK will be removed. Use child property ShareDirectoryClient instead.")]
    [Cmdlet("New", Azure.Commands.ResourceManager.Common.AzureRMConstants.AzurePrefix + "StorageDirectory", DefaultParameterSetName = Constants.ShareNameParameterSetName), OutputType(typeof(AzureStorageFileDirectory))]
    public class NewAzureStorageDirectory : AzureStorageFileCmdletBase
    {
        [Parameter(
            Position = 0,
            Mandatory = true,
            ParameterSetName = Constants.ShareNameParameterSetName,
            HelpMessage = "Name of the file share where the directory would be created.")]
        [ValidateNotNullOrEmpty]
        public string ShareName { get; set; }

        [CmdletParameterBreakingChangeWithVersion("Share", "13.0.0", "8.0.0", ChangeDescription = "The parameter Share (alias CloudFileShare) will be deprecated, and ShareClient will be mandatory.")]
        [Parameter(
            Position = 0,
            Mandatory = true,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = Constants.ShareParameterSetName,
            HelpMessage = "CloudFileShare object indicated the share where the directory would be created.")]
        [ValidateNotNull]
        [Alias("CloudFileShare")]
        public CloudFileShare Share { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = Constants.ShareParameterSetName,
            HelpMessage = "ShareClient object indicated the share where the files/directories would be listed.")]
        [ValidateNotNull]
        public ShareClient ShareClient { get; set; }

        [CmdletParameterBreakingChangeWithVersion("Directory", "13.0.0", "8.0.0", ChangeDescription = "The parameter Directory (alias CloudFileDirectory) will be deprecated, and ShareDirectoryClient will be mandatory.")]
        [Parameter(
            Position = 0,
            Mandatory = true,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = Constants.DirectoryParameterSetName,
            HelpMessage = "CloudFileDirectory object indicated the base folder where the new directory would be created.")]
        [ValidateNotNull]
        [Alias("CloudFileDirectory")]
        public CloudFileDirectory Directory { get; set; }

        [Parameter(
            Mandatory = false,
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
            HelpMessage = "Path of the directory to be created.")]
        [ValidateNotNullOrEmpty]
        public string Path { get; set; }

        public override void ExecuteCmdlet()
        {

            ShareDirectoryClient baseDirClient;
            switch (this.ParameterSetName)
            {
                case Constants.DirectoryParameterSetName:
                    if (this.ShareDirectoryClient != null)
                    {
                        baseDirClient = this.ShareDirectoryClient;
                    }
                    else
                    {

                        baseDirClient = AzureStorageFileDirectory.GetTrack2FileDirClient(this.Directory, ClientOptions);

                        // Build and set storage context for the output object when
                        // 1. input track1 object and storage context is missing 2. the current context doesn't match the context of the input object 
                        if (ShouldSetContext(this.Context, this.Directory.ServiceClient))
                        {
                            this.Context = GetStorageContextFromTrack1FileServiceClient(this.Directory.ServiceClient, DefaultContext);
                        }
                    }
                    break;

                case Constants.ShareNameParameterSetName:
                    NamingUtil.ValidateShareName(this.ShareName, false);
                    ShareServiceClient fileserviceClient = Util.GetTrack2FileServiceClient((AzureStorageContext)this.Context, ClientOptions);
                    baseDirClient = fileserviceClient.GetShareClient(this.ShareName).GetRootDirectoryClient();
                    break;

                case Constants.ShareParameterSetName:
                    if (this.ShareClient != null)
                    {
                        baseDirClient = this.ShareClient.GetRootDirectoryClient();
                    }
                    else
                    {

                        baseDirClient = AzureStorageFileDirectory.GetTrack2FileDirClient(this.Share.GetRootDirectoryReference(), ClientOptions);

                        // Build and set storage context for the output object when
                        // 1. input track1 object and storage context is missing 2. the current context doesn't match the context of the input object 
                        if (ShouldSetContext(this.Context, this.Share.ServiceClient))
                        {
                            this.Context = GetStorageContextFromTrack1FileServiceClient(this.Share.ServiceClient, DefaultContext);
                        }
                    }
                    break;

                default:
                    throw new PSArgumentException(string.Format(CultureInfo.InvariantCulture, "Invalid parameter set name: {0}", this.ParameterSetName));
            }

            ShareDirectoryClient directoryToBeCreated = baseDirClient.GetSubdirectoryClient(this.Path);
            directoryToBeCreated.Create(cancellationToken: this.CmdletCancellationToken);
            WriteObject(new AzureStorageFileDirectory(directoryToBeCreated, (AzureStorageContext)this.Context, shareDirectoryProperties: null, ClientOptions));           
        }
    }
}
