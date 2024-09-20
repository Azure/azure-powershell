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
    using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
    using Microsoft.Azure.Storage.File;
    using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;
    using Microsoft.WindowsAzure.Commands.Common.Storage.ResourceModel;
    using Microsoft.WindowsAzure.Commands.Storage.Common;
    using Microsoft.WindowsAzure.Commands.Storage.Model.ResourceModel;
    using System;
    using System.Globalization;
    using System.Management.Automation;

    [Cmdlet("Close", Azure.Commands.ResourceManager.Common.AzureRMConstants.AzurePrefix + "StorageFileHandle", SupportsShouldProcess = true, DefaultParameterSetName = ShareNameCloseAllParameterSetName)]
    [OutputType(typeof(int))]
    public class CloseAzureStorageFileHandle : AzureStorageFileCmdletBase
    {
        /// <summary>
        /// Parameter set name for ShareName.
        /// </summary>
        public const string ShareNameCloseAllParameterSetName = "ShareNameCloseAll";

        /// <summary>
        /// Parameter set name for directory.
        /// </summary>
        public const string DirectoryCloseAllParameterSetName = "DirectoryCloseAll";

        /// <summary>
        /// Parameter set name for Share CloseAll.
        /// </summary>
        public const string ShareCloseAllParameterSetName = "ShareCloseAll";

        /// <summary>
        /// Parameter set name for File CloseAll.
        /// </summary>
        public const string FileCloseAllParameterSetName = "FileCloseAll";

        /// <summary>
        /// Parameter set name for ShareName.
        /// </summary>
        public const string ShareNameCloseSingleParameterSetName = "ShareNameCloseSingle";

        ///// <summary>
        ///// Parameter set name for directory.
        ///// </summary>
        //public const string DirectoryCloseSingleParameterSetName = "DirectoryCloseSingle";

        /// <summary>
        /// Parameter set name for Share CloseAll.
        /// </summary>
        public const string ShareCloseSingleParameterSetName = "ShareCloseSingle";

        ///// <summary>
        ///// Parameter set name for File CloseAll.
        ///// </summary>
        //public const string FileCloseSingleParameterSetName = "FileCloseSingle";


        [Parameter(
            Position = 0,
            Mandatory = true,
            ParameterSetName = ShareNameCloseAllParameterSetName,
            HelpMessage = "Name of the file share which contains the files/directories to closed handle.")]
        [Parameter(
            Position = 0,
            Mandatory = true,
            ParameterSetName = ShareNameCloseSingleParameterSetName,
            HelpMessage = "Name of the file share which contains the files/directories to closed handle.")]
        [ValidateNotNullOrEmpty]
        public string ShareName { get; set; }

        [CmdletParameterBreakingChangeWithVersion("Share", "13.0.0", "8.0.0", ChangeDescription = "The parameter Share (alias CloudFileShare) will be deprecated, and ShareClient will be mandatory.")]
        [Parameter(
            Position = 0,
            Mandatory = true,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = ShareCloseAllParameterSetName,
            HelpMessage = "CloudFileShare object indicated the share which contains the files/directories to closed handle.")]
        [Parameter(
            Position = 0,
            Mandatory = true,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = ShareCloseSingleParameterSetName,
            HelpMessage = "CloudFileShare object indicated the share which contains the files/directories to closed handle.")]
        [ValidateNotNull]
        [Alias("CloudFileShare")]
        public CloudFileShare Share { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = ShareCloseAllParameterSetName,
            HelpMessage = "ShareClient object indicated the share which contains the files/directories to closed handle.")]
        [Parameter(
            Mandatory = false,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = ShareCloseSingleParameterSetName,
            HelpMessage = "ShareClient object indicated the share which contains the files/directories to closed handle.")]
        [ValidateNotNull]
        public ShareClient ShareClient { get; set; }

        [CmdletParameterBreakingChangeWithVersion("Directory", "13.0.0", "8.0.0", ChangeDescription = "The parameter Directory (alias CloudFileDirectory) will be deprecated, and ShareDirectoryClient will be mandatory.")]
        [Parameter(
            Position = 0,
            Mandatory = true,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = DirectoryCloseAllParameterSetName,
            HelpMessage = "CloudFileDirectory object indicated the base folder which contains the files/directories to closed handle.")]
        [ValidateNotNull]
        [Alias("CloudFileDirectory")]
        public CloudFileDirectory Directory { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = DirectoryCloseAllParameterSetName,
            HelpMessage = "ShareDirectoryClient object indicated the base folder which contains the files/directories to closed handle.")]
        [ValidateNotNull]
        public ShareDirectoryClient ShareDirectoryClient { get; set; }

        [CmdletParameterBreakingChangeWithVersion("File", "13.0.0", "8.0.0", ChangeDescription = "The parameter File (alias CloudFile) will be deprecated, and ShareFileClient will be mandatory.")]
        [Parameter(
            Position = 0,
            Mandatory = true,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = FileCloseAllParameterSetName,
            HelpMessage = "CloudFile object indicated the file to close handle.")]
        [ValidateNotNull]
        [Alias("CloudFile")]
        public CloudFile File { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = FileCloseAllParameterSetName,
            HelpMessage = "ShareFileClient object indicated the file to close handle.")]
        [ValidateNotNull]
        public ShareFileClient ShareFileClient { get; set; }

        [Parameter(
            Position = 1,
            Mandatory = false,
            ParameterSetName = ShareNameCloseAllParameterSetName,
            HelpMessage = "Path to an existing file/directory.")]
        [Parameter(
            Position = 1,
            Mandatory = false,
            ParameterSetName = ShareCloseAllParameterSetName,
            HelpMessage = "Path to an existing file/directory.")]
        [Parameter(
            Position = 1,
            Mandatory = false,
            ParameterSetName = DirectoryCloseAllParameterSetName,
            HelpMessage = "Path to an existing file/directory.")]
        public string Path { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = ShareNameCloseSingleParameterSetName, ValueFromPipeline = true, HelpMessage = "The File Handle to close.")]
        [Parameter(Mandatory = true, ParameterSetName = ShareCloseSingleParameterSetName, ValueFromPipeline = true, HelpMessage = "The File Handle to close.")]
        [ValidateNotNull]
        public PSFileHandle FileHandle { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = ShareNameCloseAllParameterSetName, HelpMessage = "Closed handles Recursively. Only works on File Directory.")]
        [Parameter(Mandatory = false, ParameterSetName = ShareCloseAllParameterSetName, HelpMessage = "Closed handles Recursively. Only works on File Directory.")]
        [Parameter(Mandatory = false, ParameterSetName = DirectoryCloseAllParameterSetName, HelpMessage = "Closed handles Recursively. Only works on File Directory.")]
        public SwitchParameter Recursive { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = ShareNameCloseAllParameterSetName, HelpMessage = "Force close all File handles.")]
        [Parameter(Mandatory = true, ParameterSetName = ShareCloseAllParameterSetName, HelpMessage = "Force close all File handles.")]
        [Parameter(Mandatory = true, ParameterSetName = DirectoryCloseAllParameterSetName, HelpMessage = "Force close all File handles.")]
        [Parameter(Mandatory = true, ParameterSetName = FileCloseAllParameterSetName, HelpMessage = "Force close all File handles.")]
        public SwitchParameter CloseAll { get; set; }

        [Parameter(
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = ShareNameCloseSingleParameterSetName,
            HelpMessage = "Azure Storage Context Object")]
        [Parameter(
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = ShareNameCloseAllParameterSetName,
            HelpMessage = "Azure Storage Context Object")]
        public override IStorageContext Context { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Disallow trailing dot (.) to suffix directory and file names.", ParameterSetName = ShareNameCloseAllParameterSetName)]
        [Parameter(Mandatory = false, HelpMessage = "Disallow trailing dot (.) to suffix directory and file names.", ParameterSetName = ShareNameCloseSingleParameterSetName)]
        public override SwitchParameter DisAllowTrailingDot { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Return the count of closed file handles.")]
        public SwitchParameter PassThru { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public virtual SwitchParameter AsJob { get; set; }

        public override void ExecuteCmdlet()
        {
            if (this.ShouldProcess(string.Format("Close File Handles for File or FileDirectory on Path: {0}", this.Path != null? this.Path : (this.FileHandle != null? this.FileHandle.Path: null) ), "This operation will force the provided file handle(s) closed, which may cause data loss or corruption for active applications/users.", null))
            {
                ShareDirectoryClient baseDirClient = null;
                ShareFileClient targetFile = null;
                switch (this.ParameterSetName)
                {
                    case DirectoryCloseAllParameterSetName:
                        if (this.ShareDirectoryClient != null)
                        {
                            baseDirClient = this.ShareDirectoryClient;
                        }
                        else
                        {
                            baseDirClient = AzureStorageFileDirectory.GetTrack2FileDirClient(this.Directory, ClientOptions);
                        }
                        break;

                    case ShareNameCloseSingleParameterSetName:
                    case ShareNameCloseAllParameterSetName:
                        NamingUtil.ValidateShareName(this.ShareName, false);
                        ShareServiceClient fileserviceClient = Util.GetTrack2FileServiceClient((AzureStorageContext)this.Context, ClientOptions);
                        baseDirClient = fileserviceClient.GetShareClient(this.ShareName).GetRootDirectoryClient();
                        break;

                    case ShareCloseSingleParameterSetName:
                    case ShareCloseAllParameterSetName:
                        if (this.ShareClient != null)
                        {
                            baseDirClient = this.ShareClient.GetRootDirectoryClient(); ;
                        }
                        else
                        {
                            baseDirClient = AzureStorageFileDirectory.GetTrack2FileDirClient(this.Share.GetRootDirectoryReference(), ClientOptions);
                        }
                        break;

                    case FileCloseAllParameterSetName:
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

                if(ParameterSetName == ShareNameCloseSingleParameterSetName || ParameterSetName == ShareCloseSingleParameterSetName)
                {
                    this.Path = FileHandle.Path;
                }

                // When not input path/File, the list handle target must be a Dir
                bool foundAFolder = true;
                ShareDirectoryClient targetDir = baseDirClient;
                if (this.File != null)
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
                        // 2. The File handle request send with CloudFileDirectory and CloudFile are same with same path, so need to differ it.
                    }
                }

                // Recursive only take effect on File Dir
                if (!foundAFolder && Recursive.IsPresent)
                {
                    WriteVerbose("The target object of the 'Path' is an Azure File, the parameter '-Recursive' won't take effect.");
                }

                //Close handle
                CloseHandlesResult closeResult = null;
                int numHandlesClosed = 0;
                int numHandlesFailed = 0;
                if (foundAFolder)
                {
                    if (FileHandle != null)
                    {
                        // close single handle on fileDir
                        if (this.FileHandle.HandleId == null)
                        {
                            throw new System.ArgumentException(string.Format("The HandleId of the FileHandle on path {0} should not be null.", this.FileHandle.Path), "FileHandle");
                        }
                        closeResult = targetDir.ForceCloseHandle(this.FileHandle.HandleId.ToString(), this.CmdletCancellationToken).Value;
                    }
                    else
                    {
                        // close all handle on fileDir
                        closeResult = targetDir.ForceCloseAllHandles(Recursive, this.CmdletCancellationToken);
                    }
                }
                else
                {
                    if (FileHandle != null)
                    {
                        // close single handle on file
                        if (this.FileHandle.HandleId == null)
                        {
                            throw new System.ArgumentException(string.Format("The HandleId of the FileHandle on path {0} should not be null.", this.FileHandle.Path), "FileHandle");
                        }
                        closeResult = targetFile.ForceCloseHandle(this.FileHandle.HandleId.ToString(), this.CmdletCancellationToken).Value;
                    }
                    else
                    {
                        // close all handle on file
                        closeResult = targetFile.ForceCloseAllHandles(this.CmdletCancellationToken);
                    }
                }
                numHandlesClosed += closeResult.ClosedHandlesCount;
                numHandlesFailed += closeResult.FailedHandlesCount;

                if (numHandlesFailed != 0)
                {
                    throw new InvalidOperationException(String.Format("Failed to close file handlers count : {0}.", numHandlesFailed));
                }

                if (PassThru)
                {
                    WriteObject(numHandlesClosed);
                }
            }
        }
    }
}
