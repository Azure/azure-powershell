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
using Microsoft.Azure.Commands.Consumption.Common;
using Microsoft.Azure.Commands.Consumption.Models;
using Microsoft.Azure.Management.Consumption;
using Microsoft.Azure.Management.Consumption.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using HelpMessages = Microsoft.Azure.Commands.Consumption.Common.ParameterHelpMessages.BudgetParameterHelpMessages;
using ParameterSetNames = Microsoft.Azure.Commands.Consumption.Common.Constants.ParameterSetNames;

namespace Microsoft.Azure.Commands.Consumption.Cmdlets.Budget
{
    [Cmdlet(VerbsCommon.Remove, "AzureRmConsumptionBudget", DefaultParameterSetName = ParameterSetNames.SubscriptionItemParameterSet, SupportsShouldProcess = true)]
    [OutputType(typeof(bool))]
    public class RemoveAzureRmConsumptionBudget : AzureConsumptionCmdletBase
    {
        [Parameter(ParameterSetName = ParameterSetNames.SubscriptionItemParameterSet, Mandatory = true, HelpMessage = HelpMessages.Name)]
        [ValidateNotNullOrEmpty]
        public string Name;

        [Parameter(ParameterSetName = ParameterSetNames.PipingItemParameterSet, Mandatory = true, ValueFromPipeline = true, HelpMessage = HelpMessages.InputObject)]
        [ValidateNotNullOrEmpty]
        public PSBudget InputObject;

        [Parameter(ParameterSetName = ParameterSetNames.SubscriptionItemParameterSet, Mandatory = false, HelpMessage = HelpMessages.ResourceGroupName)]
        [ValidateNotNullOrEmpty]
        [ResourceGroupCompleter]
        public string ResourceGroupName;

        [Parameter(ParameterSetName = ParameterSetNames.SubscriptionItemParameterSet, Mandatory = false, HelpMessage = HelpMessages.PassThru)]
        [Parameter(ParameterSetName = ParameterSetNames.PipingItemParameterSet, Mandatory = false, HelpMessage = HelpMessages.PassThru)]
        public SwitchParameter PassThru;

        public override void ExecuteCmdlet()
        {
            if (ShouldProcess(Name, "Remove Consumption Budget"))
            {
                try
                {
                    if (InputObject != null)
                    {
                        var name = InputObject.Name;
                        var id = InputObject.Id;
                        var parts = id.Split('/');

                        if (parts.Length >= 4 &&
                            parts[2].Equals("resourceGroups", StringComparison.InvariantCultureIgnoreCase))
                        {
                            var resourceGroupName = parts[3];
                            ConsumptionManagementClient.Budgets.DeleteByResourceGroupName(resourceGroupName, name);
                        }
                        else
                        {
                            ConsumptionManagementClient.Budgets.Delete(name);
                        }
                    }
                    else if (!string.IsNullOrWhiteSpace(this.ResourceGroupName))
                    {
                        ConsumptionManagementClient.Budgets.DeleteByResourceGroupName(this.ResourceGroupName,
                            this.Name);
                    }
                    else
                    {
                        ConsumptionManagementClient.Budgets.Delete(this.Name);
                    }
                }
                catch (ErrorResponseException e)
                {
                    WriteExceptionError(e);
                    return;
                }

                if (PassThru.IsPresent)
                {
                    WriteObject(true);
                }
            }            
        }
    }
}
