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
using Microsoft.Azure.Management.DataLake.Store.Models;
using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Commands.DataLakeStore.Properties;

namespace Microsoft.Azure.Commands.DataLakeStore
{
    [Cmdlet(VerbsCommon.Join, "AzureRmDataLakeStoreItem", SupportsShouldProcess = true), 
        OutputType(typeof(string))]
    [Alias("Join-AdlStoreItem")]
    public class JoinAzureDataLakeStoreItem : DataLakeStoreFileSystemCmdletBase
    {
        [Parameter(ValueFromPipelineByPropertyName = true, Position = 0, Mandatory = true,
            HelpMessage = "The DataLakeStore account to execute the filesystem operation in")]
        [ValidateNotNullOrEmpty]
        [Alias("AccountName")]
        public string Account { get; set; }

        [Alias("Path")]
        [Parameter(ValueFromPipelineByPropertyName = true, Position = 1, Mandatory = true,
            HelpMessage = "The path(s) in the specified Data Lake account that should be concatenated into one file. " +
                          "In the format '/folder/file.txt', " +
                          "where the first '/' after the DNS indicates the root of the file system.")]
        [ValidateNotNull]
        public DataLakeStorePathInstance[] Paths { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Position = 2, Mandatory = true,
            HelpMessage = "The path in the specified Data Lake account where the concatenation should target. " +
                          "In the format '/folder/file.txt', " +
                          "where the first '/' after the DNS indicates the root of the file system.")]
        [ValidateNotNullOrEmpty]
        public DataLakeStorePathInstance Destination { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Position = 3, Mandatory = false,
            HelpMessage = "Indicates that, if the file or folder exists, it should be overwritten")]
        public SwitchParameter Force { get; set; }

        public override void ExecuteCmdlet()
        {
            FileType fileType;
            if (ShouldProcess(Destination.TransformedPath, "Join"))
            {
                if (Force.IsPresent && (DataLakeStoreFileSystemClient.TestFileOrFolderExistence(Destination.TransformedPath, Account,
                        out fileType) && fileType == FileType.FILE))
                    // If it is a directory you are trying to overwrite with a concatenated file, we will error out.
                {
                    DataLakeStoreFileSystemClient.DeleteFileOrFolder(Destination.TransformedPath, Account, false);
                }

                DataLakeStoreFileSystemClient.ConcatenateFiles(Destination.TransformedPath, Account,
                    Paths.Select(path => path.TransformedPath).ToArray());

                WriteObject(Destination.OriginalPath);
            }
        }
    }
}