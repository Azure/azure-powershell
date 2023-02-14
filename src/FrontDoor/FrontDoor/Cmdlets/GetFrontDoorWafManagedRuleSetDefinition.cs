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

using Microsoft.Azure.Commands.FrontDoor.Common;
using Microsoft.Azure.Commands.FrontDoor.Helpers;
using Microsoft.Azure.Commands.FrontDoor.Models;
using Microsoft.Azure.Management.FrontDoor.Models;
using Microsoft.Rest.Azure;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.FrontDoor.Cmdlets
{
    /// <summary>
    /// Defines the Get-AzFrontDoorWafManagedRuleSetDefinition cmdlet.
    /// </summary>
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "FrontDoorWafManagedRuleSetDefinition"), OutputType(typeof(PSManagedRuleSetDefinition))]
    public class GetFrontDoorWafManagedRuleSetDefinition : AzureFrontDoorCmdletBase
    {
        public override void ExecuteCmdlet()
        {
            AzureOperationResponse<IPage<ManagedRuleSetDefinition>> managedSets = FrontDoorManagementClient.ManagedRuleSets.ListWithHttpMessagesAsync().GetAwaiter().GetResult();
            List<PSManagedRuleSetDefinition> managedRuleSetDefinitions = managedSets.Body?.Select(managedRuleSetDefinition => managedRuleSetDefinition.ToPSManagedRuleSetDefinition()).ToList();
            string nextLink = managedSets.Body.NextPageLink;
            while (nextLink != null)
            {
                var nextLinkSets = FrontDoorManagementClient.ManagedRuleSets.ListNextWithHttpMessagesAsync(nextLink).GetAwaiter().GetResult();
                managedRuleSetDefinitions.AddRange(nextLinkSets.Body?.Select(managedRuleSetDefinition => managedRuleSetDefinition.ToPSManagedRuleSetDefinition()));
                nextLink = nextLinkSets.Body.NextPageLink;
            }

            WriteObject(managedRuleSetDefinitions.ToArray(), true);
        }
    }
}
