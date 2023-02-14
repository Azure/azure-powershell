﻿// ----------------------------------------------------------------------------------
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
using System.Management.Automation;
using Microsoft.Azure.DataLake.Store;

namespace Microsoft.Azure.Commands.DataLakeStore
{
    [Cmdlet("Test", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "DataLakeStoreItem"), OutputType(typeof(bool))]
    [Alias("Test-AdlStoreItem")]
    public class TestAzureDataLakeStoreItem : DataLakeStoreFileSystemCmdletBase
    {
        [Parameter(ValueFromPipelineByPropertyName = true, Position = 0, Mandatory = true,
            HelpMessage = "The DataLakeStore account to execute the filesystem operation in")]
        [ValidateNotNullOrEmpty]
        [Alias("AccountName")]
        public string Account { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Position = 1, Mandatory = true,
            HelpMessage = "The path in the specified Data Lake account to test for the existence of the file. " +
                          "In the format '/folder/file.txt', " +
                          "where the first '/' after the DNS indicates the root of the file system.")]
        [ValidateNotNull]
        public DataLakeStorePathInstance Path { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Position = 2, Mandatory = false,
            HelpMessage = "Indicates the type of path expected when testing. Valid values are Any, File or Folder.")]
        public DataLakeStoreEnums.PathType PathType { get; set; }

        public override void ExecuteCmdlet()
        {
            DirectoryEntryType fileType;
            if (DataLakeStoreFileSystemClient.TestFileOrFolderExistence(Path.TransformedPath, Account, out fileType))
            {
                if (PathType == DataLakeStoreEnums.PathType.Any)
                {
                    WriteObject(true);
                }
                else if (PathType == DataLakeStoreEnums.PathType.File && fileType == DirectoryEntryType.FILE)
                {
                    WriteObject(true);
                }
                else if (PathType == DataLakeStoreEnums.PathType.Folder && fileType == DirectoryEntryType.DIRECTORY)
                {
                    WriteObject(true);
                }
                else
                {
                    WriteObject(false);
                }
            }
            else
            {
                WriteObject(false);
            }
        }
    }
}
