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
using System.Management.Automation;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.CosmosDB.Helpers;
using Microsoft.Azure.Commands.CosmosDB.Models;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;

namespace Microsoft.Azure.Commands.CosmosDB
{
    [Cmdlet(VerbsCommon.Remove, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "CosmosDBFleetspaceAccount", DefaultParameterSetName = NameParameterSet, SupportsShouldProcess = true), OutputType(typeof(void), typeof(bool))]
    public class RemoveAzCosmosDBFleetspaceAccount : AzureCosmosDBCmdletBase
    {
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        [Parameter(Mandatory = true, ParameterSetName = NameParameterSet, HelpMessage = Constants.ResourceGroupNameHelpMessage)]
        public string ResourceGroupName { get; set; }

        [ValidateNotNullOrEmpty]
        [Parameter(Mandatory = true, ParameterSetName = NameParameterSet, HelpMessage = Constants.FleetNameHelpMessage)]
        public string FleetName { get; set; }

        [ValidateNotNullOrEmpty]
        [Parameter(Mandatory = true, ParameterSetName = NameParameterSet, HelpMessage = Constants.FleetspaceNameHelpMessage)]
        public string FleetspaceName { get; set; }

        [ValidateNotNullOrEmpty]
        [Parameter(Mandatory = true, ParameterSetName = NameParameterSet, HelpMessage = Constants.FleetspaceAccountNameHelpMessage)]
        public string Name { get; set; }

        [ValidateNotNull]
        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = ObjectParameterSet, HelpMessage = Constants.FleetspaceAccountObjectHelpMessage)]
        public PSFleetspaceAccountGetResults InputObject { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.PassThruHelpMessage)]
        public SwitchParameter PassThru { get; set; }

        public override void ExecuteCmdlet()
        {
            if (ParameterSetName.Equals(ObjectParameterSet, StringComparison.Ordinal))
            {
                ResourceIdentifier resourceIdentifier = new ResourceIdentifier(InputObject.Id);
                ResourceGroupName = resourceIdentifier.ResourceGroupName;
                FleetName = ExtractFleetNameFromResourceId(InputObject.Id);
                FleetspaceName = ExtractFleetspaceNameFromResourceId(InputObject.Id);
                Name = InputObject.Name;
            }

            if (ShouldProcess(Name, "Removing fleetspace account from CosmosDB Fleetspace"))
            {
                CosmosDBManagementClient.FleetspaceAccount.DeleteWithHttpMessagesAsync(ResourceGroupName, FleetName, FleetspaceName, Name).GetAwaiter().GetResult();

                if (PassThru)
                {
                    WriteObject(true);
                }
            }

            return;
        }

        private string ExtractFleetNameFromResourceId(string resourceId)
        {
            // Extract fleet name from resource ID
            // Format: /subscriptions/{subscription}/resourceGroups/{rg}/providers/Microsoft.DocumentDB/fleets/{fleet}/fleetspaces/{fleetspace}/accounts/{account}
            string[] parts = resourceId.Split('/');
            for (int i = 0; i < parts.Length - 1; i++)
            {
                if (parts[i].Equals("fleets", StringComparison.OrdinalIgnoreCase))
                {
                    return parts[i + 1];
                }
            }
            throw new ArgumentException("Invalid resource ID format");
        }

        private string ExtractFleetspaceNameFromResourceId(string resourceId)
        {
            // Extract fleetspace name from resource ID
            // Format: /subscriptions/{subscription}/resourceGroups/{rg}/providers/Microsoft.DocumentDB/fleets/{fleet}/fleetspaces/{fleetspace}/accounts/{account}
            string[] parts = resourceId.Split('/');
            for (int i = 0; i < parts.Length - 1; i++)
            {
                if (parts[i].Equals("fleetspaces", StringComparison.OrdinalIgnoreCase))
                {
                    return parts[i + 1];
                }
            }
            throw new ArgumentException("Invalid resource ID format");
        }
    }
}
