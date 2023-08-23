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
Constructs an INwRuleSetIPRules object that can be fed as input to Set-AzEventHubNetworkRuleSet
.Description
Constructs an INwRuleSetIPRules object that can be fed as input to Set-AzEventHubNetworkRuleSet
#>
function New-AzEventHubIPRuleConfig{
	[OutputType([Microsoft.Azure.PowerShell.Cmdlets.EventHub.Models.Api20221001Preview.INwRuleSetIPRules])]
	[CmdletBinding(PositionalBinding = $false, ConfirmImpact = 'Medium')]
	param(
		[Parameter(Mandatory, HelpMessage = "IP Mask")]
        [System.String]
        # IP Mask
        ${IPMask},

		[Parameter(HelpMessage = "The IP Filter Action")]
        [Microsoft.Azure.PowerShell.Cmdlets.EventHub.Support.NetworkRuleIPAction]
		# The IP Filter Action
        ${Action}
	)

	process{
		try{
			$ipRule = [Microsoft.Azure.PowerShell.Cmdlets.EventHub.Models.Api20221001Preview.INwRuleSetIPRules]@{
				IPMask = $IPMask
				Action = $Action
			}
			
			return $ipRule
		}
		catch{
			throw
		}
	}
}