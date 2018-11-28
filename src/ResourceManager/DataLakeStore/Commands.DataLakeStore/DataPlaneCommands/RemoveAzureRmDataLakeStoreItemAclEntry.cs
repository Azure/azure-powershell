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
using Microsoft.Azure.Commands.DataLakeStore.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.DataLake.Store.Acl;
using Microsoft.Azure.DataLake.Store.AclTools;

namespace Microsoft.Azure.Commands.DataLakeStore
{
    [Cmdlet("Remove", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "DataLakeStoreItemAclEntry", SupportsShouldProcess = true,DefaultParameterSetName = BaseParameterSetName),OutputType(typeof(bool))]
    [Alias("Remove-AdlStoreItemAclEntry")]
    public class RemoveAzureDataLakeStoreItemAclEntry : DataLakeStoreFileSystemCmdletBase
    {
        internal const string BaseParameterSetName = "RemoveByACLObject";
        internal const string SpecificAceParameterSetName = "RemoveSpecificACE";

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
        public DataLakeStoreItemAce[] Acl { get; set; }

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
            Mandatory = false, HelpMessage = "Indicates that the ACL entry is a default ACE to be removed. Only named default entries can be removed this way.")]
        public SwitchParameter Default { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = false,
            HelpMessage =
                "Indicates a boolean response should be returned indicating the result of the delete operation."
        )]
        public SwitchParameter PassThru { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true,  Mandatory = false, HelpMessage = "Indicates the ACL to be removed recursively to the child subdirectories and files")]
        public SwitchParameter Recurse { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = false,
            HelpMessage =
                "Number of files/directories processed in parallel. Optional: a reasonable default will be selected"
        )]
        public int Concurrency { get; set; } = -1;

        [Parameter(Mandatory = false, HelpMessage =
                "If passed then progress status is showed. Only applicable when recursive Acl remove is done."
        )]
        public SwitchParameter ShowProgress { get; set; }

        public override void ExecuteCmdlet()
        {
            var aclSpec = ParameterSetName.Equals(BaseParameterSetName)
                ? Acl.Select(entry => entry.ParseDataLakeStoreItemAce()).ToList()
                : new List<AclEntry>() { new AclEntry((AclType)AceType, Id.ToString(), Default ? AclScope.Default : AclScope.Access, AclAction.None) };// Action doesnt have any affect here so just hardcoded some constant

            ConfirmAction(
                string.Format(Resources.RemoveDataLakeStoreItemAcl, string.Empty, Path.OriginalPath),
                Path.OriginalPath,
                () =>
                {
                    if (Recurse)
                    {
                        // Currently SDK default thread calculation is not correct, so pass a default thread count
                        int threadCount = Concurrency == -1 ? DataLakeStoreFileSystemClient.ImportExportMaxThreads : Concurrency;

                        DataLakeStoreFileSystemClient.ChangeAclRecursively(Path.TransformedPath,
                            Account, aclSpec, RequestedAclType.RemoveAcl, threadCount, this, ShowProgress, CmdletCancellationToken);
                    }
                    else
                    {
                        DataLakeStoreFileSystemClient.RemoveAclEntries(Path.TransformedPath, Account, aclSpec);
                    }

                    if (PassThru)
                    {
                        WriteObject(true);
                    }
                });
        }
    }
}
