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

using Microsoft.Azure.Management.WebSites;
using Microsoft.Azure.Management.WebSites.Models;
using System;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.WebApps.Cmdlets.AppServicePlans
{
    [Cmdlet(VerbsCommon.Get, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "AppServicePlanManagedInstance", DefaultParameterSetName = "S1")]
    [OutputType(typeof(ServerFarmInstance))]
    public class GetAzureAppServicePlanManagedInstance : AppServicePlanBaseCmdlet
    {
        [Parameter(HelpMessage = "The name of an instance to retrieve. Omit this parameter to list all instances in the plan.")]
        [ValidateNotNullOrEmpty]
        public string InstanceName { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();
            var details = WebsitesClient.WrappedWebsitesClient.AppServicePlans.GetServerFarmInstanceDetails(ResourceGroupName, Name);
            if (details == null)
            {
                throw new InvalidOperationException("The service did not return instance details for the App Service plan.");
            }

            if (string.IsNullOrEmpty(InstanceName))
            {
                WriteObject(details.Instances, true);
            }
            else
            {
                var instance = details.Instances?.FirstOrDefault(item => string.Equals(item.InstanceName, InstanceName, StringComparison.OrdinalIgnoreCase));
                if (instance == null)
                {
                    ThrowTerminatingError(new ErrorRecord(
                        new ItemNotFoundException($"Instance '{InstanceName}' was not found in App Service plan '{Name}'."),
                        "AppServicePlanManagedInstanceNotFound",
                        ErrorCategory.ObjectNotFound,
                        InstanceName));
                    return;
                }

                WriteObject(instance);
            }
        }
    }
}
