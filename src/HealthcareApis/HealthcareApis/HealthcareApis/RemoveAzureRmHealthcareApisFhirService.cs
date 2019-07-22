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

using Microsoft.Azure.Commands.HealthcareApisFhirService.Common;
using Microsoft.Azure.Commands.HealthcareApisFhirService.Models;
using Microsoft.Azure.Commands.HealthcareApisFhirService.Properties;
using Microsoft.Azure.Management.HealthcareApis;
using System.Globalization;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.HealthcareApisFhirService.Commands
{
    [Cmdlet("Remove", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "HealthcareApisFhirService", DefaultParameterSetName = ServiceNameParameterSet, SupportsShouldProcess = true), OutputType(typeof(bool))]
    public class RemoveAzureRmHealthcareApisFhirService : HealthcareApisBaseCmdlet
    {
        protected const string ServiceNameParameterSet = "ServiceNameParameterSet";
        protected const string ResourceIdParameterSet = "ResourceIdParameterSet";
        protected const string InputObjectParameterSet = "InputObjectParameterSet";

        [Parameter(
            Position = 0,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = ServiceNameParameterSet,
            HelpMessage = "Maps Account Name.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
           Position = 1,
           Mandatory = true,
           ValueFromPipelineByPropertyName = true,
           ParameterSetName = ServiceNameParameterSet,
           HelpMessage = "Resource Group Name.")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
          ParameterSetName = InputObjectParameterSet,
          HelpMessage = "HealthcareApis fhir service piped from Get-AzHealthcareApisFhirService.",
          ValueFromPipeline = true)]
        public PSFhirAccount InputObject { get; set; }


        [Parameter(
            Position = 0,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = ResourceIdParameterSet,
            HelpMessage = "HealthcareApis Fhir Service ResourceId.")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            RunCmdLet(() =>
            {
                string rgName = null;
                string name = null;

                switch (ParameterSetName)
                {
                    case InputObjectParameterSet:
                        {
                            rgName = InputObject.ResourceGroupName;
                            name = InputObject.Name;
                            break;
                        }
                    case ServiceNameParameterSet:
                        {
                            rgName = this.ResourceGroupName;
                            name = this.Name;
                            break;
                        }
                    case ResourceIdParameterSet:
                        {
                            ValidateAndExtractName(this.ResourceId, out rgName, out name);
                            break;
                        }
                }

                if (!string.IsNullOrEmpty(rgName)
                    && !string.IsNullOrEmpty(name)
                    && ShouldProcess(name, string.Format(CultureInfo.CurrentCulture, Resources.RemoveService_ProcessMessage, name)))
                {
                    this.HealthcareApisClient.Services.Delete(rgName, name);
                    WriteObject(true);
                }
            });
        }

    }
}
