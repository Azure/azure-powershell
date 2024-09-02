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
    using global::Azure;
    using global::Azure.Storage.Files.Shares;
    using global::Azure.Storage.Files.Shares.Models;
    using Microsoft.Azure.Storage.File;
    using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;
    using Microsoft.WindowsAzure.Commands.Common.Storage.ResourceModel;
    using Microsoft.WindowsAzure.Commands.Storage.Common;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Management.Automation;

    [CmdletOutputBreakingChangeWithVersion(typeof(AzureStorageFile), "13.0.0", "8.0.0", ChangeDescription = "The child property CloudFile from deprecated v11 SDK will be removed. Use child property ShareFileClient instead.")]
    [CmdletOutputBreakingChangeWithVersion(typeof(AzureStorageFileDirectory), "13.0.0", "8.0.0", ChangeDescription = "The child property CloudFileDirectory from deprecated v11 SDK will be removed. Use child property ShareDirectoryClient instead.")]
    [Cmdlet("Get", Azure.Commands.ResourceManager.Common.AzureRMConstants.AzurePrefix + "StorageFile", DefaultParameterSetName = Constants.ShareNameParameterSetName)]
    [OutputType(typeof(AzureStorageFile))]
    public class GetAzureStorageFile : AzureStorageFileCmdletBase
    {
        [Parameter(
            Position = 0,
            Mandatory = true,
            ParameterSetName = Constants.ShareNameParameterSetName,
            HelpMessage = "Name of the file share where the files/directories would be listed.")]
        [ValidateNotNullOrEmpty]
        public string ShareName { get; set; }

        [CmdletParameterBreakingChangeWithVersion("Share", "13.0.0", "8.0.0", ChangeDescription = "The parameter Share (alias CloudFileShare) will be deprecated, and ShareClient will be mandatory.")]
        [Parameter(
            Position = 0,
            Mandatory = true,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = Constants.ShareParameterSetName,
            HelpMessage = "CloudFileShare object indicated the share where the files/directories would be listed.")]
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
            HelpMessage = "CloudFileDirectory object indicated the base folder where the files/directories would be listed.")]
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
            HelpMessage = "Path to an existing file/directory.")]
        public string Path { get; set; }


        [Parameter(Mandatory = false, HelpMessage = "Not include extended file info like timestamps, ETag, attributes, permissionKey in list file and Directory.")]
        public SwitchParameter ExcludeExtendedInfo { get; set; }

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

            if (string.IsNullOrEmpty(this.Path))
            {
                ShareDirectoryGetFilesAndDirectoriesOptions listFileOptions = new ShareDirectoryGetFilesAndDirectoriesOptions();
                if (!this.ExcludeExtendedInfo.IsPresent)
                {
                    listFileOptions.Traits = ShareFileTraits.All;
                    listFileOptions.IncludeExtendedInfo = true;
                }
                Pageable<ShareFileItem> fileItems = baseDirClient.GetFilesAndDirectories(listFileOptions, this.CmdletCancellationToken);
                IEnumerable<Page<ShareFileItem>> fileitempages = fileItems.AsPages();
                foreach (var page in fileitempages)
                {
                    foreach (var file in page.Values)
                    {
                        if (!file.IsDirectory) // is file
                        {
                            ShareFileClient shareFileClient = baseDirClient.GetFileClient(file.Name);
                            WriteObject(new AzureStorageFile(shareFileClient, (AzureStorageContext)this.Context, file, ClientOptions)); 
                        }
                        else // Dir
                        {
                            ShareDirectoryClient shareDirClient = baseDirClient.GetSubdirectoryClient(file.Name);
                            WriteObject(new AzureStorageFileDirectory(shareDirClient, (AzureStorageContext)this.Context, file, ClientOptions)); 
                        }

                    }
                }
            }
            else
            {
                if (ExcludeExtendedInfo.IsPresent)
                {
                    WriteWarning("'-ExcludeExtendedInfo' will be omit, it only works when list file and directory without '-Path'.");
                }
                bool foundAFolder = true;
                ShareDirectoryClient targetDir = baseDirClient.GetSubdirectoryClient(this.Path);
                ShareDirectoryProperties dirProperties = null;

                try
                {
                    dirProperties = targetDir.GetProperties(this.CmdletCancellationToken).Value;
                }
                catch (global::Azure.RequestFailedException e) when (e.Status == 404 || e.Status == 403)
                {
                    foundAFolder = false;
                }

                if (foundAFolder)
                {
                    WriteObject(new AzureStorageFileDirectory(targetDir, (AzureStorageContext)this.Context, dirProperties)); 
                    return;
                }

                ShareFileClient targetFile = baseDirClient.GetFileClient(this.Path);
                ShareFileProperties fileProperties = targetFile.GetProperties(this.CmdletCancellationToken).Value;

                WriteObject(new AzureStorageFile(targetFile, (AzureStorageContext)this.Context, fileProperties, ClientOptions)); 
            }
        }
    }
}
