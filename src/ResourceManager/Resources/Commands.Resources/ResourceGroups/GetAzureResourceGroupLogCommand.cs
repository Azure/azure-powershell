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

using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.Azure.Commands.Resources.Models;

namespace Microsoft.Azure.Commands.Resources
{
    /// <summary>
    /// Get the list of events for a deployment.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureResourceGroupLog", DefaultParameterSetName = LastDeploymentSetName), OutputType(typeof(List<PSDeploymentEventData>))]
    public class GetAzureResourceGroupLogCommand : ResourcesBaseCmdlet
    {
        internal const string AllSetName = "All";
        internal const string LastDeploymentSetName = "Last deployment";
        internal const string DeploymentNameSetName = "Deployment by name";

        [Alias("ResourceGroupName")]
        [Parameter(Position = 0, ParameterSetName = AllSetName, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Name of the resource group you want to see the logs.")]
        [Parameter(Position = 0, ParameterSetName = LastDeploymentSetName, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Name of the resource group you want to see the logs.")]
        [Parameter(Position = 0, ParameterSetName = DeploymentNameSetName, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Name of the resource group you want to see the logs.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(ParameterSetName = DeploymentNameSetName, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Name of the deployment whose logs you want to see.")]
        [ValidateNotNullOrEmpty]
        public string DeploymentName { get; set; }
        
        [Parameter(ParameterSetName = AllSetName, HelpMessage = "Optional. If given, return logs of all the operations including CRUD and deployment.")]
        public SwitchParameter All { get; set; }

        public override void ExecuteCmdlet()
        {
            GetPSResourceGroupLogParameters parameters = new GetPSResourceGroupLogParameters
                {
                    Name = Name,
                    DeploymentName = DeploymentName,
                    All = All.IsPresent
                };
            WriteObject(ResourcesClient.GetResourceGroupLogs(parameters), true);
        }
    }
}