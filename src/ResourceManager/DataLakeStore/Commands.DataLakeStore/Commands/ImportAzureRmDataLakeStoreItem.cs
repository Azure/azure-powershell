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

using Microsoft.Azure.Commands.DataLakeStore.Models;
using Microsoft.Azure.Commands.DataLakeStore.Properties;
using System.IO;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.DataLakeStore
{
    [Cmdlet(VerbsData.Import, "AzureRmDataLakeStoreItem", SupportsShouldProcess = true), OutputType(typeof(string))]
    [Alias("Import-AdlStoreItem")]
    public class ImportAzureDataLakeStoreItem : DataLakeStoreFileSystemCmdletBase
    {
        // default number of threads
        private int numThreadsPerFile = 10;
        private int fileCount = 5;

        [Parameter(ValueFromPipelineByPropertyName = true, Position = 0, Mandatory = true,
            HelpMessage = "The DataLakeStore account to execute the filesystem operation in")]
        [ValidateNotNullOrEmpty]
        [Alias("AccountName")]
        public string Account { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Position = 1, Mandatory = true,
            HelpMessage = "The local path to the file or folder to copy")]
        [ValidateNotNull]
        public string Path { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Position = 2, Mandatory = true,
            HelpMessage = "The path in the specified Data Lake account where the file or folder should be copied to. " +
                          "In the format '/folder/file.txt', " +
                          "where the first '/' after the DNS indicates the root of the file system.")]
        [ValidateNotNullOrEmpty]
        public DataLakeStorePathInstance Destination { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Position = 3, Mandatory = false,
            HelpMessage =
                "Optionally indicates that this the folder being copied should be copied to DataLakeStore recursively")]
        public SwitchParameter Recurse { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Position = 4, Mandatory = false,
            HelpMessage =
                "Indicates that the file(s) being copied are a continuation of a previous upload. This will cause the system to attempt to resume from the last file that was not fully uploaded."
            )]
        public SwitchParameter Resume { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Position = 5, Mandatory = false,
            HelpMessage =
                "Indicates that the file(s) being copied should be copied with no concern for new line preservation across appends"
            )]
        public SwitchParameter ForceBinary { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Position = 6, Mandatory = false,
            HelpMessage = "Indicates the maximum number of threads to use per file. Default is 10")]
        public int PerFileThreadCount
        {
            get { return numThreadsPerFile; }
            set { numThreadsPerFile = value; }
        }

        [Parameter(ValueFromPipelineByPropertyName = true, Position = 7, Mandatory = false,
            HelpMessage = "Indicates the maximum number of files to upload in parallel for a folder upload. Default is 5")]
        public int ConcurrentFileCount
        {
            get { return fileCount; }
            set { fileCount = value; }
        }

        [Parameter(ValueFromPipelineByPropertyName = true, Position = 8, Mandatory = false,
            HelpMessage = "Indicates that, if the file or folder exists, it should be overwritten")]
        public SwitchParameter Force { get; set; }

        public override void ExecuteCmdlet()
        {
            var powerShellSourcePath = SessionState.Path.GetUnresolvedProviderPathFromPSPath(Path);
            ConfirmAction(
                Resources.UploadFileMessage,
                Destination.TransformedPath,
                () =>
                {
                    if (Directory.Exists(powerShellSourcePath))
                    {
                        DataLakeStoreFileSystemClient.CopyDirectory(
                            Destination.TransformedPath,
                            Account,
                            powerShellSourcePath,
                            CmdletCancellationToken,
                            ConcurrentFileCount,
                            PerFileThreadCount,
                            Recurse,
                            Force,
                            Resume, ForceBinary, ForceBinary, cmdletRunningRequest: this);
                    }
                    else if (File.Exists(powerShellSourcePath))
                    {
                        DataLakeStoreFileSystemClient.CopyFile(
                            Destination.TransformedPath,
                            Account,
                            powerShellSourcePath,
                            CmdletCancellationToken,
                            PerFileThreadCount,
                            Force,
                            Resume,
                            ForceBinary,
                            cmdletRunningRequest: this);
                    }
                    else
                    {
                        throw new FileNotFoundException(string.Format(Resources.FileOrFolderDoesNotExist, powerShellSourcePath));
                    }

                    // only attempt to write output if this cmdlet hasn't been cancelled.
                    if (!CmdletCancellationToken.IsCancellationRequested && !Stopping)
                    {
                        WriteObject(Destination.OriginalPath);
                    }
                });
        }
    }
}