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

using Microsoft.Azure.Commands.ContainerRegistry.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Management.ContainerRegistry.Models;
using Microsoft.Azure.Management.Internal.Resources.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using System.Collections;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.ContainerRegistry.Commands
{
    [Cmdlet("Set", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ContainerRegistryNetworkRuleSet", DefaultParameterSetName = AddNetworkRuleWithoutInputObject)]
    [OutputType(typeof(PSNetworkRuleSet))]
    public class SetAzureContainerRegistryNetworkRuleSet : ContainerRegistryCmdletBase
    {
        [Parameter(Mandatory = true, ParameterSetName = AddNetworkRuleWithoutInputObject, HelpMessage = "Default action, could be 'Allow' or 'Deny'")]
        [Parameter(Mandatory = false, ParameterSetName = AddNetworkRuleWithInputObject, HelpMessage = "Default action, could be 'Allow' or 'Deny'")]
        [ValidateSet("Allow", "Deny")]
        [ValidateNotNullOrEmpty]
        public string DefaultAction { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "List of Network rules")]
        public IPSNetworkRule[] NetworkRule { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = AddNetworkRuleWithInputObject, HelpMessage = "Input PSNetworkRuleSet")]
        [ValidateNotNullOrEmpty]
        public PSNetworkRuleSet InputObject { get; set; }

        public override void ExecuteCmdlet()
        {
            if (this.IsParameterBound(c => c.InputObject))
            {
                if (this.IsParameterBound(c => c.DefaultAction))
                {
                    InputObject.DefaultAction = DefaultAction;
                }
                InputObject.AddNetworkRules(NetworkRule);
            }
            else
            {
                InputObject = new PSNetworkRuleSet(DefaultAction, NetworkRule);
            }

            WriteObject(InputObject);
        }
    }
}
