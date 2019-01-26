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
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.DataLakeAnalytics.Commands
{
    [Cmdlet("Set", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "DataLakeAnalyticsCatalogItemAclEntry", DefaultParameterSetName = UserCatalogParameterSetName, SupportsShouldProcess = true),OutputType(typeof(PSDataLakeAnalyticsAcl))]
    [Alias("Set-AdlCatalogItemAclEntry")]
    public class SetAzureRmDataLakeAnalyticsCatalogItemAclEntry : DataLakeAnalyticsCmdletBase
    {
        private const string UserCatalogParameterSetName = "SetCatalogAclEntryForUser";
        private const string UserCatalogItemParameterSetName = "SetCatalogItemAclEntryForUser";
        private const string GroupCatalogParameterSetName = "SetCatalogAclEntryForGroup";
        private const string GroupCatalogItemParameterSetName = "SetCatalogItemAclEntryForGroup";
        private const string OtherCatalogParameterSetName = "SetCatalogAclEntryForOther";
        private const string OtherCatalogItemParameterSetName = "SetCatalogItemAclEntryForOther";
        private const string UserOwnerCatalogParameterSetName = "SetCatalogAclEntryForUserOwner";
        private const string UserOwnerCatalogItemParameterSetName = "SetCatalogItemAclEntryForUserOwner";
        private const string GroupOwnerCatalogParameterSetName = "SetCatalogAclEntryForGroupOwner";
        private const string GroupOwnerCatalogItemParameterSetName = "SetCatalogItemAclEntryForGroupOwner";

        [Parameter(ValueFromPipelineByPropertyName = true, Position = 0, Mandatory = true,
            HelpMessage = "Specifies the Data Lake Analytics account name.")]
        [ValidateNotNullOrEmpty]
        [Alias("AccountName")]
        public string Account { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = UserCatalogParameterSetName, HelpMessage = "Set ACL entry of catalog for user.")]
        [Parameter(Mandatory = true, ParameterSetName = UserCatalogItemParameterSetName, HelpMessage = "Set ACL entry of catalog item for user.")]
        public SwitchParameter User { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = GroupCatalogParameterSetName, HelpMessage = "Set ACL entry of catalog for group.")]
        [Parameter(Mandatory = true, ParameterSetName = GroupCatalogItemParameterSetName, HelpMessage = "Set ACL entry of catalog item for group.")]
        public SwitchParameter Group { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = OtherCatalogParameterSetName, HelpMessage = "Set ACL entry of catalog for other.")]
        [Parameter(Mandatory = true, ParameterSetName = OtherCatalogItemParameterSetName, HelpMessage = "Set ACL entry of catalog item for other.")]
        public SwitchParameter Other { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = UserOwnerCatalogParameterSetName, HelpMessage = "Set ACL entry of catalog for user owner.")]
        [Parameter(Mandatory = true, ParameterSetName = UserOwnerCatalogItemParameterSetName, HelpMessage = "Set ACL entry of catalog item for user owner.")]
        public SwitchParameter UserOwner { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = GroupOwnerCatalogParameterSetName, HelpMessage = "Set ACL entry of catalog for group owner.")]
        [Parameter(Mandatory = true, ParameterSetName = GroupOwnerCatalogItemParameterSetName, HelpMessage = "Set ACL entry of catalog item for group owner.")]
        public SwitchParameter GroupOwner { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true,
            ParameterSetName = UserCatalogParameterSetName, HelpMessage = "The identity of the user to set.")]
        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true,
            ParameterSetName = GroupCatalogParameterSetName, HelpMessage = "The identity of the group to set.")]
        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true,
            ParameterSetName = UserCatalogItemParameterSetName, HelpMessage = "The identity of the user to set.")]
        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true,
            ParameterSetName = GroupCatalogItemParameterSetName, HelpMessage = "The identity of the group to set.")]
        [Alias("Id", "UserId")]
        public Guid ObjectId { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true,
            ParameterSetName = UserCatalogItemParameterSetName, HelpMessage = "The type of the catalog item(s).")]
        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true,
            ParameterSetName = GroupCatalogItemParameterSetName, HelpMessage = "The type of the catalog item(s).")]
        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true,
            ParameterSetName = OtherCatalogItemParameterSetName, HelpMessage = "The type of the catalog item(s).")]
        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true,
            ParameterSetName = UserOwnerCatalogItemParameterSetName, HelpMessage = "The type of the catalog item(s).")]
        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true,
            ParameterSetName = GroupOwnerCatalogItemParameterSetName, HelpMessage = "The type of the catalog item(s).")]
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
        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true,
            ParameterSetName = OtherCatalogItemParameterSetName,
            HelpMessage = "The catalog item path to search within, in the format:" +
                          "'DatabaseName.<optionalSecondPart>.<optionalThirdPart>.<optionalFourthPart>'.")]
        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true,
            ParameterSetName = UserOwnerCatalogItemParameterSetName,
            HelpMessage = "The catalog item path to search within, in the format:" +
                          "'DatabaseName.<optionalSecondPart>.<optionalThirdPart>.<optionalFourthPart>'.")]
        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true,
            ParameterSetName = GroupOwnerCatalogItemParameterSetName,
            HelpMessage = "The catalog item path to search within, in the format:" +
                          "'DatabaseName.<optionalSecondPart>.<optionalThirdPart>.<optionalFourthPart>'.")]
        [ValidateNotNullOrEmpty]
        public CatalogPathInstance Path { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true,
            ParameterSetName = UserCatalogParameterSetName,
            HelpMessage = "The permissions to set for the ACE. Possible values include: 'None', 'Read', 'ReadWrite'.")]
        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true,
            ParameterSetName = GroupCatalogParameterSetName,
            HelpMessage = "The permissions to set for the ACE. Possible values include: 'None', 'Read', 'ReadWrite'.")]
        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true,
            ParameterSetName = OtherCatalogParameterSetName,
            HelpMessage = "The permissions to set for the ACE. Possible values include: 'None', 'Read', 'ReadWrite'.")]
        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true,
            ParameterSetName = UserOwnerCatalogParameterSetName,
            HelpMessage = "The permissions to set for the ACE. Possible values include: 'None', 'Read', 'ReadWrite'.")]
        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true,
            ParameterSetName = GroupOwnerCatalogParameterSetName,
            HelpMessage = "The permissions to set for the ACE. Possible values include: 'None', 'Read', 'ReadWrite'.")]
        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true,
            ParameterSetName = UserCatalogItemParameterSetName,
            HelpMessage = "The permissions to set for the ACE. Possible values include: 'None', 'Read', 'ReadWrite'.")]
        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true,
            ParameterSetName = GroupCatalogItemParameterSetName,
            HelpMessage = "The permissions to set for the ACE. Possible values include: 'None', 'Read', 'ReadWrite'.")]
        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true,
            ParameterSetName = OtherCatalogItemParameterSetName,
            HelpMessage = "The permissions to set for the ACE. Possible values include: 'None', 'Read', 'ReadWrite'.")]
        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true,
            ParameterSetName = UserOwnerCatalogItemParameterSetName,
            HelpMessage = "The permissions to set for the ACE. Possible values include: 'None', 'Read', 'ReadWrite'.")]
        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true,
            ParameterSetName = GroupOwnerCatalogItemParameterSetName,
            HelpMessage = "The permissions to set for the ACE. Possible values include: 'None', 'Read', 'ReadWrite'.")]
        [ValidateNotNull]
        public DataLakeAnalyticsEnums.PermissionType Permissions { get; set; }

        public override void ExecuteCmdlet()
        {
            string processMessage = string.Empty;
            string target = string.Empty;
            switch (this.ParameterSetName)
            {
                case UserCatalogParameterSetName: case GroupCatalogParameterSetName: case OtherCatalogParameterSetName:
                case UserOwnerCatalogParameterSetName: case GroupOwnerCatalogParameterSetName:
                    processMessage = string.Format(Resources.SetDataLakeCatalogAclEntry, Account);
                    target = Account;
                    break;

                case UserCatalogItemParameterSetName: case GroupCatalogItemParameterSetName: case OtherCatalogItemParameterSetName:
                case UserOwnerCatalogItemParameterSetName: case GroupOwnerCatalogItemParameterSetName:
                    processMessage = string.Format(Resources.SetDataLakeCatalogItemAclEntry, Path.FullCatalogItemPath);
                    target = Path.FullCatalogItemPath;
                    break;

                default: throw new ArgumentException($"Invalid parameter set: {this.ParameterSetName}");
            }

            string aceType = string.Empty;
            string[] returnedAceTypes;
            switch (this.ParameterSetName)
            {
                case UserCatalogParameterSetName: case UserCatalogItemParameterSetName:
                    aceType = AclType.User;
                    returnedAceTypes = new[] {AclType.User, AclType.Group, AclType.Other};
                    break;

                case GroupCatalogParameterSetName: case GroupCatalogItemParameterSetName:
                    aceType = AclType.Group;
                    returnedAceTypes = new[] {AclType.User, AclType.Group, AclType.Other};
                    break;

                case OtherCatalogParameterSetName: case OtherCatalogItemParameterSetName: aceType = AclType.Other;
                    returnedAceTypes = new[] {AclType.User, AclType.Group, AclType.Other};
                    break;

                case UserOwnerCatalogParameterSetName: case UserOwnerCatalogItemParameterSetName:
                    aceType = AclType.UserObj;
                    returnedAceTypes = new[] {AclType.UserObj};
                    break;

                case GroupOwnerCatalogParameterSetName: case GroupOwnerCatalogItemParameterSetName:
                    aceType = AclType.GroupObj;
                    returnedAceTypes = new[] {AclType.GroupObj};
                    break;

                default: throw new ArgumentException($"Invalid parameter set: {this.ParameterSetName}");
            }

            ConfirmAction(
                processMessage,
                target,
                () =>
                {
                    DataLakeAnalyticsClient.AddOrUpdateCatalogItemAclEntry(Account, Path, ItemType, aceType, ObjectId, Permissions);
                    var toReturn = DataLakeAnalyticsClient.GetCatalogItemAclEntry(Account, Path, ItemType, returnedAceTypes)
                        .Select(acl => new PSDataLakeAnalyticsAcl(acl))
                        .ToList();
                    if (toReturn.Count == 1)
                    {
                        WriteObject(toReturn[0]);
                    }
                    else
                    {
                        WriteObject(toReturn, true);
                    }
                });
        }
    }
}
