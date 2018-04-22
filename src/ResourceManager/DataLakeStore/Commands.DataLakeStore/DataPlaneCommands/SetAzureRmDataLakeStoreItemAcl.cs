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
using System.Linq;
using Microsoft.Azure.DataLake.Store.AclTools;

namespace Microsoft.Azure.Commands.DataLakeStore
{
    [Cmdlet(VerbsCommon.Set, "AzureRmDataLakeStoreItemAcl", SupportsShouldProcess = true), 
        OutputType(typeof(DataLakeStoreItemAce))]
    [Alias("Set-AdlStoreItemAcl")]
    public class SetAzureDataLakeStoreItemAcl : DataLakeStoreFileSystemCmdletBase
    {

        [Parameter(ValueFromPipelineByPropertyName = true, Position = 0, Mandatory = true,
            HelpMessage = "The DataLakeStore account to execute the filesystem operation in")]
        [ValidateNotNullOrEmpty]
        [Alias("AccountName")]
        public string Account { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Position = 1, Mandatory = true,
            HelpMessage =
                "The path in the specified Data Lake account that should have its ACL set. Can be a file or folder " +
                "In the format '/folder/file.txt', " +
                "where the first '/' after the DNS indicates the root of the file system.")]
        [ValidateNotNull]
        public DataLakeStorePathInstance Path { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Position = 2, Mandatory = true,
            HelpMessage =
                "The ACL to set. This can be a modified ACL from Get-AzureDataLakeStoreItemAcl or it can be the string " +
                " representation of an ACL as defined in the apache webhdfs specification. Note that this is only supported for named ACEs." +
                "This cmdlet is not to be used for setting the owner or owning group.")]
        public DataLakeStoreItemAce[] Acl { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = false,
            HelpMessage =
                "Indicates the resulting ACL should be returned indicating the result of set operation."
            )]
        public SwitchParameter PassThru { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = false,
            HelpMessage =
                "Indicates the ACL to be set recursively to the child subdirectories and files"
        )]
        public SwitchParameter Recurse { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = false,
            HelpMessage =
                "Indicates the number of files/directories processed in parallel for recursive processing. Default will be computed as a best effort based on system specification."
        )]
        public int Concurrency { get; set; } = -1;

        public override void ExecuteCmdlet()
        {
            WriteWarning(Resources.IncorrectOutputTypeWarning);
            ConfirmAction(
                string.Format(Resources.SetDataLakeStoreItemAcl, Path.OriginalPath),
                Path.OriginalPath,
                () =>
                {
                        if (Recurse)
                        {
                            DataLakeStoreFileSystemClient.ChangeAclRecursively(Path.TransformedPath,
                                Account,
                                Acl.Select(entry => entry.ParseDataLakeStoreItemAce()).ToList(), RequestedAclType.SetAcl, Concurrency);
                        }
                        else
                        {
                            DataLakeStoreFileSystemClient.SetAcl(
                                Path.TransformedPath,
                                Account,
                                Acl.Select(entry => entry.ParseDataLakeStoreItemAce()).ToList());
                        }

                        if (PassThru)
                        {
                            WriteObject(DataLakeStoreFileSystemClient.GetAclStatus(Path.TransformedPath,
                                    Account).Entries.Select(entry => new DataLakeStoreItemAce(entry)));
                        }
                    });
        }
    }
}