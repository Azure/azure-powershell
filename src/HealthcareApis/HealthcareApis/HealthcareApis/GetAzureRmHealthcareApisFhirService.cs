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
// 

using Microsoft.Azure.Commands.HealthcareApisFhirService.Common;
using Microsoft.Azure.Commands.HealthcareApisFhirService.Models;
using Microsoft.Azure.Management.HealthcareApis;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.HealthcareApisFhirService.Commands
{

    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "HealthcareApisFhirService", DefaultParameterSetName = ServiceNameParameterSet, SupportsShouldProcess = true), OutputType(typeof(PSFhirAccount))]
    public class GetAzureRmHealthcareApisFhirService : HealthcareApisBaseCmdlet
    {
        protected const string ServiceNameParameterSet = "ServiceNameParameterSet";
        protected const string ResourceIdParameterSet = "ResourceIdParameterSet";

        [Parameter(
          Mandatory = true,
          ParameterSetName = ServiceNameParameterSet,
          ValueFromPipelineByPropertyName = true,
          HelpMessage = "HealthcareApiFhirService Name.")]
        [Alias(HealthcareApisAccountNameAlias, AccountNameAlias)]
        [ValidateNotNullOrEmpty]
        [ValidatePattern("^[a-zA-Z0-9][a-zA-Z0-9_.-]*$")]
        [ValidateLength(2, 64)]
        public string Name { get; set; }

        [Parameter(
           Mandatory = true,
           ParameterSetName = ServiceNameParameterSet,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "Resource Group Name.")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }


        [Parameter(
           Mandatory = true,
           ParameterSetName = ResourceIdParameterSet,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "Resource Id Name.")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            RunCmdLet(() =>
            {
                switch (ParameterSetName)
                {
                    case ServiceNameParameterSet:
                        {
                            var healthcareApisAccount = this.HealthcareApisClient.Services.Get(this.ResourceGroupName, this.Name);
                            WriteHealthcareApisAccount(healthcareApisAccount);
                            break;
                        }
                    case ResourceIdParameterSet:
                        {

                            string resourceGroupName;
                            string resourceName;

                            if (ValidateAndExtractName(this.ResourceId, out resourceGroupName, out resourceName))
                            {
                                var healthcareApisAccount = this.HealthcareApisClient.Services.Get(resourceGroupName, resourceName);
                                WriteHealthcareApisAccount(healthcareApisAccount);
                            }
                            break;

                        }
                }

            });

        }
    }
}
