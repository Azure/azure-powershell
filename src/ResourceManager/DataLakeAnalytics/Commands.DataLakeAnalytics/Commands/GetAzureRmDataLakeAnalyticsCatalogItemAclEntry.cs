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
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.DataLake.Analytics.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.DataLakeAnalytics.Commands
{
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "DataLakeAnalyticsCatalogItemAclEntry", DefaultParameterSetName = BaseCatalogParameterSetName),OutputType(typeof(PSDataLakeAnalyticsAcl))]
    [Alias("Get-AdlCatalogItemAclEntry")]
    public class GetAzureRmDataLakeAnalyticsCatalogItemAclEntry : DataLakeAnalyticsCmdletBase
    {
        private const string BaseCatalogParameterSetName = "GetCatalogAclEntry";
        private const string UserOwnerCatalogParameterSetName = "GetCatalogAclEntryForUserOwner";
        private const string GroupOwnerCatalogParameterSetName = "GetCatalogAclEntryForGroupOwner";
        private const string BaseCatalogItemParameterSetName = "GetCatalogItemAclEntry";
        private const string UserOwnerCatalogItemParameterSetName = "GetCatalogItemAclEntryForUserOwner";
        private const string GroupOwnerCatalogItemParameterSetName = "GetCatalogItemAclEntryForGroupOwner";

        [Parameter(ValueFromPipelineByPropertyName = true, Position = 0, Mandatory = true,
            ParameterSetName = BaseCatalogParameterSetName, HelpMessage = "Specifies the Data Lake Analytics account name.")]
        [Parameter(ValueFromPipelineByPropertyName = true, Position = 0, Mandatory = true,
            ParameterSetName = UserOwnerCatalogParameterSetName, HelpMessage = "Specifies the Data Lake Analytics account name.")]
        [Parameter(ValueFromPipelineByPropertyName = true, Position = 0, Mandatory = true,
            ParameterSetName = GroupOwnerCatalogParameterSetName, HelpMessage = "Specifies the Data Lake Analytics account name.")]
        [Parameter(ValueFromPipelineByPropertyName = true, Position = 0, Mandatory = true,
            ParameterSetName = BaseCatalogItemParameterSetName, HelpMessage = "Specifies the Data Lake Analytics account name.")]
        [Parameter(ValueFromPipelineByPropertyName = true, Position = 0, Mandatory = true,
            ParameterSetName = UserOwnerCatalogItemParameterSetName, HelpMessage = "Specifies the Data Lake Analytics account name.")]
        [Parameter(ValueFromPipelineByPropertyName = true, Position = 0, Mandatory = true,
            ParameterSetName = GroupOwnerCatalogItemParameterSetName, HelpMessage = "Specifies the Data Lake Analytics account name.")]
        [ValidateNotNullOrEmpty]
        [Alias("AccountName")]
        public string Account { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = UserOwnerCatalogParameterSetName, HelpMessage = "Get ACL entry of catalog for user owner.")]
        [Parameter(Mandatory = true, ParameterSetName = UserOwnerCatalogItemParameterSetName, HelpMessage = "Get ACL entry of catalog item for user owner.")]
        public SwitchParameter UserOwner { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = GroupOwnerCatalogParameterSetName, HelpMessage = "Get ACL entry of catalog for group owner.")]
        [Parameter(Mandatory = true, ParameterSetName = GroupOwnerCatalogItemParameterSetName, HelpMessage = "Get ACL entry of catalog item for group owner.")]
        public SwitchParameter GroupOwner { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true,
            ParameterSetName = BaseCatalogItemParameterSetName, HelpMessage = "The type of the catalog item(s).")]
        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true,
            ParameterSetName = UserOwnerCatalogItemParameterSetName, HelpMessage = "The type of the catalog item(s).")]
        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true,
            ParameterSetName = GroupOwnerCatalogItemParameterSetName, HelpMessage = "The type of the catalog item(s).")]
        [PSArgumentCompleter("Database")]
        public string ItemType { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true,
            ParameterSetName = BaseCatalogItemParameterSetName,
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

        public override void ExecuteCmdlet()
        {
            string[] requiredAceTypes;
            switch (ParameterSetName)
            {
                case BaseCatalogParameterSetName: case BaseCatalogItemParameterSetName:
                    requiredAceTypes = new[] {AclType.User, AclType.Group, AclType.Other};
                    break;

                case UserOwnerCatalogParameterSetName:  case UserOwnerCatalogItemParameterSetName:
                    requiredAceTypes = new[] {AclType.UserObj};
                    break;

                case GroupOwnerCatalogParameterSetName: case GroupOwnerCatalogItemParameterSetName:
                    requiredAceTypes = new[] {AclType.GroupObj};
                    break;

                default: throw new ArgumentException($"Invalid parameter set: {this.ParameterSetName}");
            }

            var toReturn = DataLakeAnalyticsClient.GetCatalogItemAclEntry(Account, Path, ItemType, requiredAceTypes).Select(acl => new PSDataLakeAnalyticsAcl(acl)).ToList();
            if (toReturn.Count == 1)
            {
                WriteObject(toReturn[0]);
            }
            else
            {
                WriteObject(toReturn, true);
            }
        }
    }
}
