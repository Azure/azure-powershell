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
    using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
    using Microsoft.Azure.Storage;
    using Microsoft.Azure.Storage.File;
    using Microsoft.WindowsAzure.Commands.Storage.Model.ResourceModel;
    using System.Globalization;
    using System.Management.Automation;
    using System.Net;

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

        [Parameter(
            Position = 0,
            Mandatory = true,
            ValueFromPipeline = true,
            ParameterSetName = ShareCloseAllParameterSetName,
            HelpMessage = "CloudFileShare object indicated the share which contains the files/directories to closed handle.")]
        [Parameter(
            Position = 0,
            Mandatory = true,
            ValueFromPipeline = true,
            ParameterSetName = ShareCloseSingleParameterSetName,
            HelpMessage = "CloudFileShare object indicated the share which contains the files/directories to closed handle.")]
        [ValidateNotNull]
        public CloudFileShare Share { get; set; }

        [Parameter(
            Position = 0,
            Mandatory = true,
            ValueFromPipeline = true,
            ParameterSetName = DirectoryCloseAllParameterSetName,
            HelpMessage = "CloudFileDirectory object indicated the base folder which contains the files/directories to closed handle.")]
        [ValidateNotNull]
        public CloudFileDirectory Directory { get; set; }

        [Parameter(
            Position = 0,
            Mandatory = true,
            ValueFromPipeline = true,
            ParameterSetName = FileCloseAllParameterSetName,
            HelpMessage = "CloudFile object indicated the file to close handle.")]
        [ValidateNotNull]
        public CloudFile File { get; set; }

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

        [Parameter(Mandatory = false, HelpMessage = "Return whether the specified blob is successfully removed")]
        public SwitchParameter PassThru { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public virtual SwitchParameter AsJob { get; set; }

        public override void ExecuteCmdlet()
        {
            if (this.ShouldProcess(string.Format("Close File Handles for File or FileDirectory on Path: {0}", this.Path != null? this.Path : (this.FileHandle != null? this.FileHandle.Path: null) ), "This operation will force the provided file handle(s) closed, which may cause data loss or corruption for active applications/users.", null))
            {
                CloudFileDirectory baseDirectory = null;
                switch (this.ParameterSetName)
                {
                    case DirectoryCloseAllParameterSetName:
                        baseDirectory = this.Directory;
                        break;

                    case ShareNameCloseSingleParameterSetName:
                    case ShareNameCloseAllParameterSetName:
                        baseDirectory = this.BuildFileShareObjectFromName(this.ShareName).GetRootDirectoryReference();
                        break;

                    case ShareCloseSingleParameterSetName:
                    case ShareCloseAllParameterSetName:
                        baseDirectory = this.Share.GetRootDirectoryReference();
                        break;
                    case FileCloseAllParameterSetName:
                        // Don't need to set baseDirectory when input is a CloudFile
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
                CloudFileDirectory targetDir = baseDirectory;
                CloudFile targetFile = null;
                if (this.File != null)
                {
                    targetFile = this.File;
                    foundAFolder = false;
                }
                else
                {
                    if (!string.IsNullOrEmpty(this.Path))
                    {
                        string[] subfolders = NamingUtil.ValidatePath(this.Path);
                        targetDir = baseDirectory.GetDirectoryReferenceByPath(subfolders);

                        if (!targetDir.Exists())
                        {
                            foundAFolder = false;
                        }

                        if (!foundAFolder)
                        {
                            //Get file
                            string[] filePath = NamingUtil.ValidatePath(this.Path, true);
                            targetFile = baseDirectory.GetFileReferenceByPath(filePath);

                            this.Channel.FetchFileAttributesAsync(
                                targetFile,
                                null,
                                this.RequestOptions,
                                this.OperationContext,
                                this.CmdletCancellationToken).ConfigureAwait(false);
                        }
                    }
                }

                // Recursive only take effect on File Dir
                if (!foundAFolder && Recursive.IsPresent)
                {
                    WriteVerbose("The target object of the 'Path' is an Azure File, the parameter '-Recursive' won't take effect.");
                }

                //Close handle
                CloseFileHandleResultSegment closeResult = null;
                FileContinuationToken continuationToken = null;
                int numHandlesClosed = 0;
                do
                {
                    if (foundAFolder)
                    {
                        if (FileHandle != null)
                        {
                            // close single handle on fileDir
                            if (this.FileHandle.HandleId == null)
                            {
                                throw new System.ArgumentException(string.Format("The HandleId of the FileHandle on path {0} should not be null.", this.FileHandle.Path), "FileHandle");
                            }
                            closeResult = targetDir.CloseHandleSegmented(this.FileHandle.HandleId.ToString(), continuationToken, Recursive, null, this.RequestOptions, this.OperationContext);
                        }
                        else
                        {
                            // close all handle on fileDir
                            closeResult = targetDir.CloseAllHandlesSegmented(continuationToken, Recursive, null, this.RequestOptions, this.OperationContext);
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
                            closeResult = targetFile.CloseHandleSegmented(this.FileHandle.HandleId.ToString(), continuationToken, null, this.RequestOptions, this.OperationContext);
                        }
                        else
                        {
                            // close all handle on file
                            closeResult = targetFile.CloseAllHandlesSegmented(continuationToken, null, this.RequestOptions, this.OperationContext);
                        }
                    }
                    numHandlesClosed += closeResult.NumHandlesClosed;
                    continuationToken = closeResult.ContinuationToken;
                } while (continuationToken != null && continuationToken.NextMarker != null);

                if (PassThru)
                {
                    WriteObject(numHandlesClosed);
                }
            }
        }
    }
}
