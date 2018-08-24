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

using Microsoft.Azure.Commands.DataLakeAnalytics.Models;
using Microsoft.Azure.Commands.DataLakeAnalytics.Properties;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.DataLake.Analytics.Models;
using System;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.DataLakeAnalytics.Commands
{
    [Cmdlet("Remove", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "DataLakeAnalyticsCatalogItemAclEntry", DefaultParameterSetName = UserCatalogParameterSetName, SupportsShouldProcess = true),OutputType(typeof(bool))]
    [Alias("Remove-AdlCatalogItemAclEntry")]
    public class RemoveAzureRmDataLakeAnalyticsCatalogItemAclEntry : DataLakeAnalyticsCmdletBase
    {
        private const string UserCatalogParameterSetName = "RemoveCatalogAclEntryForUser";
        private const string UserCatalogItemParameterSetName = "RemoveCatalogItemAclEntryForUser";
        private const string GroupCatalogParameterSetName = "RemoveCatalogAclEntryForGroup";
        private const string GroupCatalogItemParameterSetName = "RemoveCatalogItemAclEntryForGroup";

        [Parameter(ValueFromPipelineByPropertyName = true, Position = 0, Mandatory = true,
            HelpMessage = "Specifies the Data Lake Analytics account name.")]
        [ValidateNotNullOrEmpty]
        [Alias("AccountName")]
        public string Account { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = UserCatalogParameterSetName, HelpMessage = "Remove ACL entry of catalog for user.")]
        [Parameter(Mandatory = true, ParameterSetName = UserCatalogItemParameterSetName, HelpMessage = "Remove ACL entry of catalog item for user.")]
        public SwitchParameter User { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = GroupCatalogParameterSetName, HelpMessage = "Remove ACL entry of catalog for group.")]
        [Parameter(Mandatory = true, ParameterSetName = GroupCatalogItemParameterSetName, HelpMessage = "Remove ACL entry of catalog item for group.")]
        public SwitchParameter Group { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true,
            ParameterSetName = UserCatalogParameterSetName, HelpMessage = "The identity of the user to remove.")]
        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true,
            ParameterSetName = GroupCatalogParameterSetName, HelpMessage = "The identity of the group to remove.")]
        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true,
            ParameterSetName = UserCatalogItemParameterSetName, HelpMessage = "The identity of the user to remove.")]
        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true,
            ParameterSetName = GroupCatalogItemParameterSetName, HelpMessage = "The identity of the group to remove.")]
        [Alias("Id", "UserId")]
        public Guid ObjectId { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true,
            ParameterSetName = UserCatalogItemParameterSetName, HelpMessage = "The type of the catalog item(s).")]
        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true,
            ParameterSetName = GroupCatalogItemParameterSetName, HelpMessage = "The type of the catalog item(s).")]
        [PSArgumentCompleter("Database")]
        public string ItemType { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true,
            ParameterSetName = UserCatalogItemParameterSetName,
            HelpMessage = "The catalog item path to search within, in the format:" +
                          "'DatabaseName.<optionalSecondPart>.<optionalThirdPart>.<optionalFourthPart>'.")]
        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true,
            ParameterSetName = GroupCatalogItemParameterSetName,
            HelpMessage = "The catalog item path to search within, in the format:" +
                          "'DatabaseName.<optionalSecondPart>.<optionalThirdPart>.<optionalFourthPart>'.")]
        [ValidateNotNullOrEmpty]
        public CatalogPathInstance Path { get; set; }

        [Parameter(Mandatory = false,
            HelpMessage = "Indicates a boolean response should be returned indicating the result of the delete operation.")]
        public SwitchParameter PassThru { get; set; }

        public override void ExecuteCmdlet()
        {
            string processMessage = string.Empty;
            string target = string.Empty;

            switch (this.ParameterSetName)
            {
                case UserCatalogParameterSetName: case GroupCatalogParameterSetName:
                    processMessage = string.Format(Resources.RemoveDataLakeAnalyticsCatalogAcl, Account);
                    target = Account;
                    break;

                case UserCatalogItemParameterSetName: case GroupCatalogItemParameterSetName:
                    processMessage = string.Format(Resources.RemoveDataLakeAnalyticsCatalogItemAcl, Path.FullCatalogItemPath);
                    target = Path.FullCatalogItemPath ?? Account;
                    break;

                default: throw new ArgumentException($"Invalid parameter set: {this.ParameterSetName}");
            }

            string aceType = string.Empty;
            switch (this.ParameterSetName)
            {
                case UserCatalogParameterSetName: case UserCatalogItemParameterSetName: aceType = AclType.User; break;
                case GroupCatalogParameterSetName: case GroupCatalogItemParameterSetName: aceType = AclType.Group; break;
                default: throw new ArgumentException($"Invalid parameter set: {this.ParameterSetName}");
            }

            ConfirmAction(
                processMessage,
                target,
                () =>
                {
                    DataLakeAnalyticsClient.RemoveCatalogItemAclEntry(Account, Path, ItemType, aceType, ObjectId);
                    if (PassThru)
                    {
                        WriteObject(true);
                    }
                });
        }
    }
}
