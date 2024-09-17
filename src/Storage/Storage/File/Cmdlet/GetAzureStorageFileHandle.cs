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
    using Microsoft.WindowsAzure.Commands.Storage.Model.ResourceModel;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Management.Automation;

    [Cmdlet("Get", Azure.Commands.ResourceManager.Common.AzureRMConstants.AzurePrefix + "StorageFileHandle", DefaultParameterSetName = Constants.ShareNameParameterSetName, SupportsPaging = true)]
    [OutputType(typeof(PSFileHandle))]
    public class GetAzureStorageFileHandle : AzureStorageFileCmdletBase
    {
        [Parameter(
            Position = 0,
            Mandatory = true,
            ParameterSetName = Constants.ShareNameParameterSetName,
            HelpMessage = "Name of the file share where the files/directories would list File Handles.")]
        [ValidateNotNullOrEmpty]
        public string ShareName { get; set; }

        [CmdletParameterBreakingChangeWithVersion("Share", "13.0.0", "8.0.0", ChangeDescription = "The parameter Share (alias CloudFileShare) will be deprecated, and ShareClient will be mandatory.")]
        [Parameter(
            Position = 0,
            Mandatory = true,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = Constants.ShareParameterSetName,
            HelpMessage = "CloudFileShare object indicated the share where the files/directories would list File Handles.")]
        [ValidateNotNull]
        [Alias("CloudFileShare")]
        public CloudFileShare Share { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = Constants.ShareParameterSetName,
            HelpMessage = "ShareClient object indicated the share where the files/directories would list File Handles")]
        [ValidateNotNull]
        public ShareClient ShareClient { get; set; }

        [CmdletParameterBreakingChangeWithVersion("Directory", "13.0.0", "8.0.0", ChangeDescription = "The parameter Directory (alias CloudFileDirectory) will be deprecated, and ShareDirectoryClient will be mandatory.")]
        [Parameter(
            Position = 0,
            Mandatory = true,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = Constants.DirectoryParameterSetName,
            HelpMessage = "CloudFileDirectory object indicated the base folder where the files/directories would list File Handles.")]
        [ValidateNotNull]
        [Alias("CloudFileDirectory")]
        public CloudFileDirectory Directory { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = Constants.DirectoryParameterSetName,
            HelpMessage = "ShareDirectoryClient object indicated the base folder where the files/directories would list File Handles")]
        [ValidateNotNull]
        public ShareDirectoryClient ShareDirectoryClient { get; set; }

        [CmdletParameterBreakingChangeWithVersion("File", "13.0.0", "8.0.0", ChangeDescription = "The parameter File (alias CloudFile) will be deprecated, and ShareFileClient will be mandatory.")]
        [Parameter(
            Position = 0,
            Mandatory = true,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = Constants.FileParameterSetName,
            HelpMessage = "CloudFile object indicated the file to list File Handles.")]
        [ValidateNotNull]
        [Alias("CloudFile")]
        public CloudFile File { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = Constants.FileParameterSetName,
            HelpMessage = "ShareFileClient object indicated the file to list File Handles.")]
        [ValidateNotNull]
        public ShareFileClient ShareFileClient { get; set; }

        [Parameter(
            Position = 1,
            Mandatory = false,
            ParameterSetName = Constants.ShareNameParameterSetName,
            HelpMessage = "Path to an existing file/directory.")]
        [Parameter(
            Position = 1,
            Mandatory = false,
            ParameterSetName = Constants.DirectoryParameterSetName,
            HelpMessage = "Path to an existing file/directory.")]
        [Parameter(
            Position = 1,
            Mandatory = false,
            ParameterSetName = Constants.ShareParameterSetName,
            HelpMessage = "Path to an existing file/directory.")]
        public string Path { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "List handles Recursively. Only works on File Directory.")]
        public SwitchParameter Recursive { get; set; }

        public override void ExecuteCmdlet()
        {
            ShareDirectoryClient baseDirClient = null;
            ShareFileClient targetFile = null;
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
                    }
                    break;

                case Constants.FileParameterSetName:
                    if (this.ShareFileClient != null)
                    {
                        targetFile = this.ShareFileClient;
                    }
                    else
                    {

                        targetFile = AzureStorageFile.GetTrack2FileClient(this.File, ClientOptions);
                    }
                    break;

                default:
                    throw new PSArgumentException(string.Format(CultureInfo.InvariantCulture, "Invalid parameter set name: {0}", this.ParameterSetName));
            }

            // When not input path/File, the list handle target must be a Dir
            bool foundAFolder = true;
            ShareDirectoryClient targetDir = baseDirClient;
            if (targetFile != null)
            {
                foundAFolder = false;
            }
            else
            {
                if (!string.IsNullOrEmpty(this.Path))
                {
                    targetDir = baseDirClient.GetSubdirectoryClient(this.Path);

                    // Don't need check the path target to File or FileDir since: 
                    // 1. check File/FileDir exist will fail on File/FileDir with DeletePending status
                    // 2. The File handle request send with CloudFileDirectory and CloudFile are same with same path, so don't need to differ it.
                }
            }

            // Recursive only take effect on File Dir
            if (!foundAFolder && Recursive.IsPresent)
            {
                WriteVerbose("The target object of the 'Path' is an Azure File, the parameter '-Recursive' won't take effect.");
            }

            //List handle
            Pageable<ShareFileHandle> listResult;
            List<PSFileHandle> handleReturn = new List<PSFileHandle>();
            ulong first = MyInvocation.BoundParameters.ContainsKey("First") ? this.PagingParameters.First : ulong.MaxValue;
            ulong skip = MyInvocation.BoundParameters.ContainsKey("Skip") ? this.PagingParameters.Skip : 0;

            // Any items before this count should be return
            ulong lastCount = MyInvocation.BoundParameters.ContainsKey("First") ? skip + first : ulong.MaxValue;
            ulong currentCount = 0;
            if (foundAFolder)
            {
                // list handle on fileDir
                listResult = targetDir.GetHandles(Recursive, this.CmdletCancellationToken);
            }
            else
            {
                // list handle on file
                listResult = targetFile.GetHandles(this.CmdletCancellationToken);
            }

            IEnumerable<Page<ShareFileHandle>> handlePages = listResult.AsPages();

            foreach (var handlePage in handlePages)
            {
                if (currentCount + (ulong)handlePage.Values.Count - 1 < skip)
                {
                    // skip the whole chunk if they are all in skip
                    currentCount += (ulong)handlePage.Values.Count;
                }
                else
                {
                    foreach (ShareFileHandle handle in handlePage.Values)
                    {
                        // not return "skip" count of items in the begin, and only return "first" count of items after that.
                        if (currentCount >= skip && currentCount < lastCount)
                        {
                            handleReturn.Add(new PSFileHandle(handle));
                        }
                        currentCount++;
                        if (currentCount >= lastCount)
                        {
                            break;
                        }
                    }
                }
            }

            WriteObject(handleReturn, true);
        }
    }
}
