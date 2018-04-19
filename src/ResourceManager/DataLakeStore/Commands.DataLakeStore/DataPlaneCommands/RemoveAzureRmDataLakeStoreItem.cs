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
using System.Management.Automation;

namespace Microsoft.Azure.Commands.DataLakeStore
{
    [Cmdlet(VerbsCommon.Remove, "AzureRmDataLakeStoreItem", SupportsShouldProcess = true), OutputType(typeof(bool))]
    [Alias("Remove-AdlStoreItem")]
    public class RemoveAzureDataLakeStoreItem : DataLakeStoreFileSystemCmdletBase
    {
        [Parameter(ValueFromPipelineByPropertyName = true, Position = 0, Mandatory = true,
            HelpMessage = "The DataLakeStore account to execute the filesystem operation in")]
        [ValidateNotNullOrEmpty]
        [Alias("AccountName")]
        public string Account { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Position = 1, Mandatory = true,
            HelpMessage = "The path in the specified Data Lake account to remove the file or folder. " +
                          "In the format '/folder/file.txt', " +
                          "where the first '/' after the DNS indicates the root of the file system.")]
        [ValidateNotNull]
        public DataLakeStorePathInstance[] Paths { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Position = 2, Mandatory = false,
            HelpMessage = "Indicates the user wants a recursive delete of the folder.")]
        public SwitchParameter Recurse { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Position = 4, Mandatory = false,
            HelpMessage =
                "Indicates delete should be performed without prompting."
        )]
        public SwitchParameter Force { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Position = 5, Mandatory = false,
            HelpMessage =
                "Indicates a boolean response should be returned indicating the result of the delete operation."
        )]
        public SwitchParameter PassThru { get; set; }

        public override void ExecuteCmdlet()
        {
            bool success = true;
            foreach (var path in Paths)
            {
                ConfirmAction(
                    Force.IsPresent,
                    string.Format(Resources.RemovingDataLakeStoreItem, path.OriginalPath),
                    string.Format(Resources.RemoveDataLakeStoreItem, path.OriginalPath),
                    path.OriginalPath,
                    () =>
                    {
                        success =
                            success &&
                            DataLakeStoreFileSystemClient.DeleteFileOrFolder(path.TransformedPath, Account,
                                Recurse);
                        if (PassThru)
                        {
                            WriteObject(success);
                        }
                    });
            }

        }
    }
}