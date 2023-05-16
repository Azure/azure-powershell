# ----------------------------------------------------------------------------------
#
# Copyright Microsoft Corporation
# Licensed under the Apache License, Version 2.0 (the "License");
# you may not use this file except in compliance with the License.
# You may obtain a copy of the License at
# http://www.apache.org/licenses/LICENSE-2.0
# Unless required by applicable law or agreed to in writing, software
# distributed under the License is distributed on an "AS IS" BASIS,
# WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
# See the License for the specific language governing permissions and
# limitations under the License.
# ----------------------------------------------------------------------------------

<#
.Synopsis
Constructs an INwRuleSetVirtualNetworkRules object that can be fed as input to Set-AzEventHubNetworkRuleSet
.Description
Constructs an INwRuleSetVirtualNetworkRules object that can be fed as input to Set-AzEventHubNetworkRuleSet
#>
function New-AzEventHubVirtualNetworkRuleConfig{
	[OutputType([Microsoft.Azure.PowerShell.Cmdlets.EventHub.Models.Api20221001Preview.INwRuleSetVirtualNetworkRules])]
	[CmdletBinding(PositionalBinding = $false, ConfirmImpact = 'Medium')]
	param(
		[Parameter(Mandatory, HelpMessage = "Resource ID of Virtual Network Subnet")]
        [System.String]
        # Resource ID of Virtual Network Subnet
        ${SubnetId},

		[Parameter(HelpMessage = "Resource ID of Virtual Network Subnet")]
        [System.Management.Automation.SwitchParameter]
		# The IP Filter Action
        ${IgnoreMissingVnetServiceEndpoint}
	)

	process{
		try{
			$virtualNetworkRule = [Microsoft.Azure.PowerShell.Cmdlets.EventHub.Models.Api20221001Preview.INwRuleSetVirtualNetworkRules]@{
				SubnetId = $SubnetId
			}

			$hasIgnoreMissing = $PSBoundParameters.Remove('IgnoreMissingVnetServiceEndpoint')
			if ($hasIgnoreMissing){
				$virtualNetworkRule.IgnoreMissingVnetServiceEndpoint = $IgnoreMissingVnetServiceEndpoint
			}
			
			return $virtualNetworkRule
		}
		catch{
			throw
		}
	}
}