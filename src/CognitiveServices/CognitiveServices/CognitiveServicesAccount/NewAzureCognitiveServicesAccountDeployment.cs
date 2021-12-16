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

using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.CognitiveServices;
using Microsoft.Azure.Management.CognitiveServices.Models;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Management.CognitiveServices
{
    /// <summary>
    /// Create a new Cognitive Services Account Deployment
    /// </summary>
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "CognitiveServicesAccountDeployment", SupportsShouldProcess = true, DefaultParameterSetName = DefaultParameterSet), OutputType(typeof(Deployment))]
    public class NewAzureCognitiveServicesAccountDeploymentCommand : CognitiveServicesAccountBaseCmdlet
    {
        private const string DefaultParameterSet = "DefaultParameterSet";

        [Parameter(
            Position = 0,
            Mandatory = true,
            ParameterSetName = DefaultParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Resource Group Name.")]
        [ResourceGroupCompleter()]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Position = 1,
            Mandatory = true,
            ParameterSetName = DefaultParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Cognitive Services Account Name.")]
        [Alias(CognitiveServicesAccountNameAlias)]
        [ValidateNotNullOrEmpty]
        public string AccountName { get; set; }

        [Parameter(
            Position = 2,
            Mandatory = true,
            ParameterSetName = DefaultParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Cognitive Services Deployment Name.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            Position = 3,
            Mandatory = true,
            ParameterSetName = DefaultParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Cognitive Services Deployment Properties.")]
        public DeploymentProperties Properties { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            RunCmdLet(() =>
            {
                var deployment = new Deployment()
                {
                    Properties = Properties
                };

                var createAccountResponse = CognitiveServicesClient.Deployments.BeginCreateOrUpdate(
                                    ResourceGroupName,
                                    AccountName,
                                    Name,
                                    deployment);

                    WriteObject(createAccountResponse);
            });
        }
    }
}
