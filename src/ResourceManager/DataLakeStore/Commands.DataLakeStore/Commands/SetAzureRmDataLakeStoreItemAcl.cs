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

using System;
using Microsoft.Azure.Commands.DataLakeStore.Models;
using Microsoft.Azure.Commands.DataLakeStore.Properties;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.DataLakeStore
{
    [Cmdlet(VerbsCommon.Set, "AzureRmDataLakeStoreItemAcl", SupportsShouldProcess = true), 
        OutputType(typeof(bool))]
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
        public DataLakeStoreItemAcl Acl { get; set; }

        public override void ExecuteCmdlet()
        {
            ConfirmAction(
                string.Format(Resources.SetDataLakeStoreItemAcl, Path.OriginalPath),
                Path.OriginalPath,
                () =>
                    DataLakeStoreFileSystemClient.SetAcl(Path.TransformedPath, Account,
                        Acl.GetAclSpec()));
        }
    }
}