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
using Microsoft.Azure.Management.DataLake.Store.Models;
using Microsoft.PowerShell.Commands;
using Microsoft.Rest.Azure;
using System.IO;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.DataLakeStore
{
    [Cmdlet(VerbsCommon.New, "AzureRmDataLakeStoreItem", SupportsShouldProcess = true), 
        OutputType(typeof(string))]
    [Alias("New-AdlStoreItem")]
    public class NewAzureDataLakeStoreItem : DataLakeStoreFileSystemCmdletBase
    {
        private FileSystemCmdletProviderEncoding _encoding = FileSystemCmdletProviderEncoding.UTF8;

        [Parameter(ValueFromPipelineByPropertyName = true, Position = 0, Mandatory = true,
            HelpMessage = "The DataLakeStore account to execute the filesystem operation in")]
        [ValidateNotNullOrEmpty]
        [Alias("AccountName")]
        public string Account { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Position = 1, Mandatory = true,
            HelpMessage = "The path in the specified Data Lake account where the action should take place. " +
                          "In the format '/folder/file.txt', " +
                          "where the first '/' after the DNS indicates the root of the file system.")]
        [ValidateNotNullOrEmpty]
        public DataLakeStorePathInstance Path { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Position = 2, ValueFromPipeline = true, Mandatory = false,
            HelpMessage = "Optional content for the file to contain upon creation")]
        [ValidateNotNull]
        public object Value { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Position = 3, Mandatory = false,
            HelpMessage =
                "Optionally indicates the encoding for the content being uploaded as part of 'Value'. Default is UTF8")]
        public FileSystemCmdletProviderEncoding Encoding
        {
            get { return _encoding; }
            set { _encoding = value; }
        }

        [Parameter(ValueFromPipelineByPropertyName = true, Position = 3, Mandatory = false,
            HelpMessage = "Optionally indicates that this new item is a folder and not a file.")]
        public SwitchParameter Folder { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Position = 4, Mandatory = false,
            HelpMessage = "Indicates that, if the file or folder exists, it should be overwritten")]
        public SwitchParameter Force { get; set; }

        public override void ExecuteCmdlet()
        {
            FileType ignored;

            ConfirmAction(
                Force.IsPresent,
                string.Format(Resources.OverwriteFileMessage, Path.TransformedPath),
                "Create",
                Path.TransformedPath,
                () =>
                {
                    if (Folder)
                    {
                        DataLakeStoreFileSystemClient.CreateDirectory(Path.TransformedPath, Account);
                    }
                    else
                    {
                        if (Path.TransformedPath.EndsWith("/"))
                        {
                            throw new CloudException(string.Format(Resources.InvalidFilePath, Path.TransformedPath));
                        }

                        DataLakeStoreFileSystemClient.CreateFile(Path.TransformedPath, Account,
                            Value != null ? new MemoryStream(GetBytes(Value, Encoding)) : new MemoryStream(), Force);
                    }

                    WriteObject(Path.OriginalPath);
                },
                () => DataLakeStoreFileSystemClient.TestFileOrFolderExistence(Path.TransformedPath, Account, out ignored));
        }
    }
}