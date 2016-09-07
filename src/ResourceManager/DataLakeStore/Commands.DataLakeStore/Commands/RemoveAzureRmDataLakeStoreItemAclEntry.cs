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
using System;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.DataLakeStore
{
    [Cmdlet(VerbsCommon.Remove, "AzureRmDataLakeStoreItemAclEntry", SupportsShouldProcess = true,
        DefaultParameterSetName = BaseParameterSetName),
     OutputType(typeof(bool))]
    [Alias("Remove-AdlStoreItemAclEntry")]
    public class RemoveAzureDataLakeStoreItemAclEntry : DataLakeStoreFileSystemCmdletBase
    {
        internal const string BaseParameterSetName = "Remove ACL Entries using ACL object";
        internal const string SpecificAceParameterSetName = "Remove specific ACE";

        [Parameter(ValueFromPipelineByPropertyName = true, ParameterSetName = BaseParameterSetName, Position = 0,
            Mandatory = true, HelpMessage = "The DataLakeStore account to execute the filesystem operation in")]
        [Parameter(ValueFromPipelineByPropertyName = true, ParameterSetName = SpecificAceParameterSetName, Position = 0,
            Mandatory = true, HelpMessage = "The DataLakeStore account to execute the filesystem operation in")]
        [ValidateNotNullOrEmpty]
        [Alias("AccountName")]
        public string Account { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, ParameterSetName = BaseParameterSetName, Position = 1,
            Mandatory = true,
            HelpMessage =
                "The path in the specified Data Lake account that should have ACL entries removed. Can be a file or folder " +
                "In the format '/folder/file.txt', " +
                "where the first '/' after the DNS indicates the root of the file system.")]
        [Parameter(ValueFromPipelineByPropertyName = true, ParameterSetName = SpecificAceParameterSetName, Position = 1,
            Mandatory = true,
            HelpMessage =
                "The path in the specified Data Lake account that should have ACL entries removed. Can be a file or folder " +
                "In the format '/folder/file.txt', " +
                "where the first '/' after the DNS indicates the root of the file system.")]
        [ValidateNotNull]
        public DataLakeStorePathInstance Path { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, ParameterSetName = BaseParameterSetName, Position = 2,
            Mandatory = true,
            HelpMessage =
                "The ACL spec containing the entries to remove. These entries MUST exist in the ACL spec for the file already. This can be a modified ACL from Get-AzureDataLakeStoreItemAcl or it can be the string " +
                " representation of an ACL as defined in the apache webhdfs specification. Note that this is only supported for named ACEs." +
                "This cmdlet is not to be used for setting the owner or owning group.")]
        public DataLakeStoreItemAcl Acl { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, ParameterSetName = SpecificAceParameterSetName, Position = 2,
            Mandatory = true, HelpMessage = "Indicates the type of ACE to remove (user, group, mask, other)")]
        public DataLakeStoreEnums.AceType AceType { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, ParameterSetName = SpecificAceParameterSetName, Position = 3,
            Mandatory = false,
            HelpMessage =
                "The identity of the user or group to remove. Optional. If none is passed this will attempt to remove an unamed ACE, which is necessary for both mask and other ACEs"
            )]
        [ValidateNotNullOrEmpty]
        public Guid Id { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, ParameterSetName = SpecificAceParameterSetName, Position = 4, 
            Mandatory = false, HelpMessage = "Indicates that the ACL entry is a default ACE to be removed.")]
        public SwitchParameter Default { get; set; }

        public override void ExecuteCmdlet()
        {
            string aclSpec = string.Empty;
            if(ParameterSetName.Equals(BaseParameterSetName))
            {
                WriteWarning(Resources.ObsoleteWarningForAclObjects);
                aclSpec = Acl.GetAclSpec(false);
            }
            else
            {
                aclSpec = string.Format("{0}{1}:{2}", Default ? "default:" : string.Empty, AceType, Id).ToLowerInvariant();
            }
            
            ConfirmAction(
                string.Format(Resources.RemoveDataLakeStoreItemAcl, string.Empty, Path.OriginalPath),
                Path.OriginalPath,
                () => { DataLakeStoreFileSystemClient.RemoveAclEntries(Path.TransformedPath, Account, aclSpec); });
        }
    }
}