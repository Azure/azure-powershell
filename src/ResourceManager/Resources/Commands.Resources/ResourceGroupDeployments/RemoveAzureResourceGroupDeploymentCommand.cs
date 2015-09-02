﻿// ----------------------------------------------------------------------------------
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

using Microsoft.Azure.Commands.Resources.Models;
using System.Management.Automation;
using ProjectResources = Microsoft.Azure.Commands.Resources.Properties.Resources;

namespace Microsoft.Azure.Commands.Resources.ResourceGroups
{
    /// <summary>
    /// Deletes a deployment.
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, "AzureResourceGroupDeployment"), OutputType(typeof(bool))]
    public class RemoveAzureResourceGroupDeploymentCommand : ResourcesBaseCmdlet
    {
        [Parameter(Position = 0, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The name of the resource group.")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Alias("DeploymentName")]
        [Parameter(Position = 1, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The name of the deployment.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Position = 2, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Do not confirm the remove.")]
        public SwitchParameter Force { get; set; }

        [Parameter(Position = 3, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "True if succeed, false otherwise.")]
        public SwitchParameter PassThru { get; set; }
        
        public override void ExecuteCmdlet()
        {
            ConfirmAction(
                Force.IsPresent,
                string.Format(ProjectResources.DeleteResourceGroupDeployment, Name),
                ProjectResources.DeleteResourceGroupDeploymentMessage,
                ResourceGroupName,
                () => ResourcesClient.DeleteDeployment(ResourceGroupName, Name));

            if (PassThru)
            {
                WriteObject(true);
            }
        }
    }
}