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
    using Microsoft.Azure.Storage.File;
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

        [Parameter(
            Position = 0,
            Mandatory = true,
            ValueFromPipeline = true,
            ParameterSetName = Constants.ShareParameterSetName,
            HelpMessage = "CloudFileShare object indicated the share where the files/directories would list File Handles.")]
        [ValidateNotNull]
        public CloudFileShare Share { get; set; }

        [Parameter(
            Position = 0,
            Mandatory = true,
            ValueFromPipeline = true,
            ParameterSetName = Constants.DirectoryParameterSetName,
            HelpMessage = "CloudFileDirectory object indicated the base folder where the files/directories would list File Handles.")]
        [ValidateNotNull]
        public CloudFileDirectory Directory { get; set; }

        [Parameter(
            Position = 0,
            Mandatory = true,
            ValueFromPipeline = true,
            ParameterSetName = Constants.FileParameterSetName,
            HelpMessage = "CloudFile object indicated the file to list File Handles.")]
        [ValidateNotNull]
        public CloudFile File { get; set; }

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
            CloudFileDirectory baseDirectory = null;
            switch (this.ParameterSetName)
            {
                case Constants.DirectoryParameterSetName:
                    baseDirectory = this.Directory;
                    break;

                case Constants.ShareNameParameterSetName:
                    baseDirectory = this.BuildFileShareObjectFromName(this.ShareName).GetRootDirectoryReference();
                    break;

                case Constants.ShareParameterSetName:
                    baseDirectory = this.Share.GetRootDirectoryReference();
                    break;
                case Constants.FileParameterSetName:
                    // Don't need to set baseDirectory when input is a CloudFile
                    break;

                default:
                    throw new PSArgumentException(string.Format(CultureInfo.InvariantCulture, "Invalid parameter set name: {0}", this.ParameterSetName));
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

            //List handle
            FileHandleResultSegment listResult;
            FileContinuationToken continuationToken = null;
            List<PSFileHandle> handleReturn = new List<PSFileHandle>();
            ulong first = MyInvocation.BoundParameters.ContainsKey("First") ? this.PagingParameters.First : ulong.MaxValue;
            ulong skip = MyInvocation.BoundParameters.ContainsKey("Skip") ? this.PagingParameters.Skip : 0;

            // Any items before this count should be return
            ulong lastCount = MyInvocation.BoundParameters.ContainsKey("First") ? skip + first : ulong.MaxValue;
            ulong currentCount = 0;
            do
            {
                if (foundAFolder)
                {
                    // list handle on fileDir
                    listResult = targetDir.ListHandlesSegmented(continuationToken, null, Recursive, null, this.RequestOptions, this.OperationContext);
                }
                else
                {
                    // list handle on file
                    listResult = targetFile.ListHandlesSegmented(continuationToken, null, null, this.RequestOptions, this.OperationContext);
                }

                List<FileHandle> handleList = new List<FileHandle>(listResult.Results);

                if (currentCount + (ulong)handleList.Count - 1 < skip)
                {
                    // skip the whole chunk if they are all in skip
                    currentCount += (ulong)handleList.Count;
                }
                else
                {
                    foreach (FileHandle handle in handleList)
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
                continuationToken = listResult.ContinuationToken;
            } while (continuationToken != null && continuationToken.NextMarker != null && currentCount < lastCount);

            WriteObject(handleReturn, true);
        }
    }
}
