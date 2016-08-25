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

using System.IO;
using Microsoft.Azure.Commands.DataLakeStore.Models;
using Microsoft.Azure.Commands.DataLakeStore.Properties;
using Microsoft.Azure.Management.DataLake.Store.Models;
using Microsoft.Rest.Azure;
using System;
using System.Management.Automation;
using System.Net;

namespace Microsoft.Azure.Commands.DataLakeStore
{
    [Cmdlet(VerbsData.Export, "AzureRmDataLakeStoreItem", SupportsShouldProcess = true), OutputType(typeof(string))]
    [Alias("Export-AdlStoreItem")]
    public class ExportAzureDataLakeStoreItem : DataLakeStoreFileSystemCmdletBase
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
            HelpMessage = "The path to the file or folder to download")]
        [ValidateNotNull]
        public DataLakeStorePathInstance Path { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Position = 2, Mandatory = true,
            HelpMessage = "The local path to download the file or folder to")]
        [ValidateNotNullOrEmpty]
        public string Destination { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Position = 3, Mandatory = false,
            HelpMessage = "Indicates if the download should be recursive for folder downloads. The default is false.")]
        [ValidateNotNullOrEmpty]
        public SwitchParameter Recurse { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Position = 4, Mandatory = false,
            HelpMessage =
                "Indicates that the file(s) being copied are a continuation of a previous download. This will cause the system to attempt to resume from the last file that was not fully downloaded."
            )]
        public SwitchParameter Resume { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Position = 5, Mandatory = false,
            HelpMessage = "Indicates the maximum number of threads to use per file. Default is 10")]
        public int PerFileThreadCount
        {
            get { return numThreadsPerFile; }
            set { numThreadsPerFile = value; }
        }

        [Parameter(ValueFromPipelineByPropertyName = true, Position = 6, Mandatory = false,
            HelpMessage = "Indicates the maximum number of files to download in parallel for a folder download. Default is 5")]
        public int ConcurrentFileCount
        {
            get { return fileCount; }
            set { fileCount = value; }
        }

        [Parameter(ValueFromPipelineByPropertyName = true, Position = 7, Mandatory = false,
            HelpMessage = "Indicates that, if the file or folder exists, it should be overwritten")]
        public SwitchParameter Force { get; set; }

        public override void ExecuteCmdlet()
        {
            // We will let this throw itself if the path they give us is invalid
            // TODO: perhaps in the future catch this and throw a cmdlet specific exception
            var powerShellReadyPath = SessionState.Path.GetUnresolvedProviderPathFromPSPath(Destination);

            FileType type;
            ConfirmAction(
                VerbsData.Export,
                Path.TransformedPath,
                () =>
                {
                    if (!DataLakeStoreFileSystemClient.TestFileOrFolderExistence(Path.TransformedPath, Account, out type))
                    {
                        throw new CloudException(string.Format(Resources.InvalidExportPathType, Path.TransformedPath));
                    }

                    if (type == FileType.FILE)
                    {
                        DataLakeStoreFileSystemClient.CopyFile(powerShellReadyPath, Account, Path.TransformedPath, CmdletCancellationToken,
                            isDownload: true, overwrite: Force, cmdletRunningRequest: this, threadCount: PerFileThreadCount, resume: Resume);
                    }
                    else
                    {
                        DataLakeStoreFileSystemClient.CopyDirectory(powerShellReadyPath, Account, Path.TransformedPath,
                            CmdletCancellationToken,
                            isDownload: true, overwrite: Force, cmdletRunningRequest: this,
                            perFileThreadCount: PerFileThreadCount, concurrentFileCount: ConcurrentFileCount, recursive: Recurse, resume: Resume);
                    }

                    WriteObject(powerShellReadyPath);
                });
        }
    }
}