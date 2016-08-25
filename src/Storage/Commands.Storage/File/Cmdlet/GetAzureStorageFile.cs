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
    using Microsoft.WindowsAzure.Storage;
    using Microsoft.WindowsAzure.Storage.File;
    using System.Globalization;
    using System.Management.Automation;
    using System.Net;

    [Cmdlet(VerbsCommon.Get, Constants.FileCmdletName, DefaultParameterSetName = Constants.ShareNameParameterSetName)]
    public class GetAzureStorageFile : AzureStorageFileCmdletBase
    {
        [Parameter(
            Position = 0,
            Mandatory = true,
            ParameterSetName = Constants.ShareNameParameterSetName,
            HelpMessage = "Name of the file share where the files/directories would be listed.")]
        [ValidateNotNullOrEmpty]
        public string ShareName { get; set; }

        [Parameter(
            Position = 0,
            Mandatory = true,
            ValueFromPipeline = true,
            ParameterSetName = Constants.ShareParameterSetName,
            HelpMessage = "CloudFileShare object indicated the share where the files/directories would be listed.")]
        [ValidateNotNull]
        public CloudFileShare Share { get; set; }

        [Parameter(
            Position = 0,
            Mandatory = true,
            ValueFromPipeline = true,
            ParameterSetName = Constants.DirectoryParameterSetName,
            HelpMessage = "CloudFileDirectory object indicated the base folder where the files/directories would be listed.")]
        [ValidateNotNull]
        public CloudFileDirectory Directory { get; set; }

        [Parameter(
            Position = 1,
            HelpMessage = "Path to an existing file/directory.")]
        public string Path { get; set; }

        public override void ExecuteCmdlet()
        {
            CloudFileDirectory baseDirectory;
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

                default:
                    throw new PSArgumentException(string.Format(CultureInfo.InvariantCulture, "Invalid parameter set name: {0}", this.ParameterSetName));
            }

            if (string.IsNullOrEmpty(this.Path))
            {
                this.RunTask(async (taskId) =>
                {
                    await this.Channel.EnumerateFilesAndDirectoriesAsync(
                        baseDirectory,
                        item => this.OutputStream.WriteObject(taskId, item),
                        this.RequestOptions,
                        this.OperationContext,
                        this.CmdletCancellationToken);
                });
            }
            else
            {
                this.RunTask(async (taskId) =>
                {
                    bool foundAFolder = true;
                    string[] subfolders = NamingUtil.ValidatePath(this.Path);
                    CloudFileDirectory targetDir = baseDirectory.GetDirectoryReferenceByPath(subfolders);

                    try
                    {
                        await this.Channel.FetchDirectoryAttributesAsync(
                            targetDir,
                            null,
                            this.RequestOptions,
                            this.OperationContext,
                            this.CmdletCancellationToken);
                    }
                    catch (StorageException se)
                    {
                        if (null == se.RequestInformation
                            || (int)HttpStatusCode.NotFound != se.RequestInformation.HttpStatusCode)
                        {
                            throw;
                        }

                        foundAFolder = false;
                    }

                    if (foundAFolder)
                    {
                        this.OutputStream.WriteObject(taskId, targetDir);
                        return;
                    }

                    string[] filePath = NamingUtil.ValidatePath(this.Path, true);
                    CloudFile targetFile = baseDirectory.GetFileReferenceByPath(filePath);

                    await this.Channel.FetchFileAttributesAsync(
                        targetFile,
                        null,
                        this.RequestOptions,
                        this.OperationContext,
                        this.CmdletCancellationToken);

                    this.OutputStream.WriteObject(taskId, targetFile);
                });
            }
        }
    }
}
