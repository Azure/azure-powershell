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

using System.Management.Automation;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Azure.Commands.ResourceManager.Common;

namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.Implementation
{
    [Cmdlet(VerbsCommon.Get,  AzureRMConstants.AzureRMPrefix + "DeploymentScript", DefaultParameterSetName = GetAzDeploymentScript.DeploymentScriptByName), OutputType(typeof(PSBlueprint), typeof(PSPublishedBlueprint))]
    public class GetAzDeploymentScript
    {
        internal const string DeploymentScriptByName = "GetDeploymentScriptByName";
        internal const string DeploymentScriptById = "GetDeploymentScriptById";
        internal const string DeploymentScriptList = "GetDeploymentScriptList";

        [Parameter(Position = 0, ParameterSetName = DeploymentScriptByName, Mandatory = true, HelpMessage = "To-Do")]
        public string Name { get; set; }

        [Parameter(Position = 0, ParameterSetName = DeploymentScriptByName, Mandatory = true, HelpMessage = "To-Do")]
        public string SubscriptionId { get; set; }

        [Parameter(Position = 0, ParameterSetName = DeploymentScriptByName, Mandatory = true, HelpMessage = "To-Do")]
        public string ResourceGroupName { get; set; }

        [Alias("ResourceId")]
        [Parameter(ParameterSetName = DeploymentScriptById, Mandatory = true,
            HelpMessage = "The fully qualified resource Id of the deployment script. Example: /subscriptions/{subId}/providers/Microsoft.Resources/deploymentScripts/{deploymentName}")]
        [ValidateNotNullOrEmpty]
        public string Id { get; set; }
    }
}
