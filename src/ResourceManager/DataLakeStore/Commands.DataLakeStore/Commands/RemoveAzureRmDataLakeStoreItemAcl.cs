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
    [Cmdlet(VerbsCommon.Remove, "AzureRmDataLakeStoreItemAcl", SupportsShouldProcess = true), OutputType(typeof (bool))]
    [Alias("Remove-AdlStoreItemAcl")]
    public class RemoveAzureDataLakeStoreItemAcl : DataLakeStoreFileSystemCmdletBase
    {
        [Parameter(ValueFromPipelineByPropertyName = true, Position = 0, Mandatory = true,
            HelpMessage = "The DataLakeStore account to execute the filesystem operation in")]
        [ValidateNotNullOrEmpty]
        [Alias("AccountName")]
        public string Account { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Position = 1, Mandatory = true,
            HelpMessage =
                "The path in the specified Data Lake account that should have its ACL removed. Can be a file or folder " +
                "In the format '/folder/file.txt', " +
                "where the first '/' after the DNS indicates the root of the file system.")]
        [ValidateNotNull]
        public DataLakeStorePathInstance Path { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Position = 2, Mandatory = false,
            HelpMessage =
                "Optionally indicates that the ACL to remove is the default ACL on the item. If not specified, will remove the standard ACL for the item"
            )]
        public SwitchParameter Default { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Position = 3, Mandatory = false,
            HelpMessage =
                "Indicates that the ACL should be removed on the file with the specified ACL without prompting.")]
        public SwitchParameter Force { get; set; }

        public override void ExecuteCmdlet()
        {
            if (!Force.IsPresent)
            {
                ConfirmAction(
                    Force.IsPresent,
                    string.Format(Resources.RemovingDataLakeStoreItemAcl,
                        Default ? Resources.DefaultAclWord : string.Empty, Path.OriginalPath),
                    string.Format(Resources.RemoveDataLakeStoreItemAcl,
                        Default ? Resources.DefaultAclWord : string.Empty, Path.OriginalPath),
                    Path.OriginalPath,
                    () =>
                    {
                        if (Default)
                        {
                            DataLakeStoreFileSystemClient.RemoveDefaultAcl(Path.TransformedPath, Account);
                        }
                        else
                        {
                            DataLakeStoreFileSystemClient.RemoveAcl(Path.TransformedPath, Account);
                        }
                    });
            }
            else
            {
                if (Default)
                {
                    DataLakeStoreFileSystemClient.RemoveDefaultAcl(Path.TransformedPath, Account);
                }
                else
                {
                    DataLakeStoreFileSystemClient.RemoveAcl(Path.TransformedPath, Account);
                }
            }
        }
    }
}