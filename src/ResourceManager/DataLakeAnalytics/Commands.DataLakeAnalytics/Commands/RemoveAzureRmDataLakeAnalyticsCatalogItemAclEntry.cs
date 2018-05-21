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
using System;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.DataLakeAnalytics.Commands
{
    [Cmdlet(VerbsCommon.Remove, "AzureRmDataLakeAnalyticsCatalogItemAclEntry", DefaultParameterSetName = UserOrGroupCatalogParameterSetName, SupportsShouldProcess = true),
        OutputType(typeof(bool))]
    [Alias("Remove-AdlCatalogItemAclEntry")]
    public class RemoveAzureRmDataLakeAnalyticsCatalogItemAclEntry : DataLakeAnalyticsCmdletBase
    {
        private const string UserOrGroupCatalogParameterSetName = "RemoveCatalogAclEntryForUserOrGroup";
        private const string UserOrGroupCatalogItemParameterSetName = "RemoveCatalogItemAclEntryForUserOrGroup";

        [Parameter(ValueFromPipelineByPropertyName = true, Position = 0, Mandatory = true,
            HelpMessage = "Specifies the Data Lake Analytics account name.")]
        [ValidateNotNullOrEmpty]
        [Alias("AccountName")]
        public string Account { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Position = 1, Mandatory = true,
            ParameterSetName = UserOrGroupCatalogParameterSetName, HelpMessage = "The identity of the user or group to remove.")]
        [Parameter(ValueFromPipelineByPropertyName = true, Position = 1, Mandatory = true,
            ParameterSetName = UserOrGroupCatalogItemParameterSetName, HelpMessage = "The identity of the user or group to remove.")]
        [Alias("Id")]
        [ValidateNotNullOrEmpty]
        public Guid ObjectId { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Position = 2, Mandatory = true,
            ParameterSetName = UserOrGroupCatalogItemParameterSetName, HelpMessage = "The type of the catalog item(s).")]
        [PSArgumentCompleter("Database")]
        public string ItemType { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Position = 3, Mandatory = true,
            ParameterSetName = UserOrGroupCatalogItemParameterSetName,
            HelpMessage = "The catalog item path to search within, in the format:" +
                          "'DatabaseName.<optionalSecondPart>.<optionalThirdPart>.<optionalFourthPart>'.")]
        [ValidateNotNullOrEmpty]
        public CatalogPathInstance Path { get; set; }

        [Parameter(Mandatory = false,
            HelpMessage = "Forces the command to run without asking for user confirmation.")]
        public SwitchParameter Force { get; set; }

        [Parameter(Mandatory = false,
            HelpMessage = "Indicates a boolean response should be returned indicating the result of the delete operation.")]
        public SwitchParameter PassThru { get; set; }

        public override void ExecuteCmdlet()
        {
            string continueMessage = string.Empty;
            string processMessage = string.Empty;
            string target = string.Empty;

            switch (this.ParameterSetName)
            {
                case UserOrGroupCatalogParameterSetName:
                    continueMessage = string.Format(Resources.RemovingDataLakeAnalyticsCatalogAcl, Account);
                    processMessage = string.Format(Resources.RemoveDataLakeAnalyticsCatalogAcl, Account);
                    target = Account;
                    break;

                case UserOrGroupCatalogItemParameterSetName:
                    continueMessage = string.Format(Resources.RemovingDataLakeAnalyticsCatalogItemAcl, Path.FullCatalogItemPath);
                    processMessage = string.Format(Resources.RemoveDataLakeAnalyticsCatalogItemAcl, Path.FullCatalogItemPath);
                    target = Path.FullCatalogItemPath;
                    break;

                default: throw new ArgumentException($"Invalid parameter set: {this.ParameterSetName}");
            }

            ConfirmAction(
                Force.IsPresent,
                continueMessage,
                processMessage,
                target,
                () =>
                {
                    DataLakeAnalyticsClient.RemoveCatalogItemAclEntry(Account, Path, ItemType, ObjectId);
                    if (PassThru)
                    {
                        WriteObject(true);
                    }
                });
        }
    }
}
