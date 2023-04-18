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
Constructs an IThrottlingPolicy object that can be fed as input to New-AzEventHubApplicationGroup or Set-AzEventHubApplicationGroup
.Description
Constructs an IThrottlingPolicy object that can be fed as input to New-AzEventHubApplicationGroup or Set-AzEventHubApplicationGroup
#>
function New-AzEventHubThrottlingPolicyConfig{
	[OutputType([Microsoft.Azure.PowerShell.Cmdlets.EventHub.Models.Api20221001Preview.IThrottlingPolicy])]
	[CmdletBinding(PositionalBinding = $false, ConfirmImpact = 'Medium')]
	param(
		[Parameter(Mandatory, HelpMessage = "Name of Throttling Policy Config")]
        [System.String]
        # Name of Throttling Policy Config
        ${Name},

		[Parameter(Mandatory, HelpMessage = "The Threshold limit above which the application group will be throttled.Rate limit is always per second.")]
        [System.Int64]
		# The Threshold limit above which the application group will be throttled.Rate limit is always per second.
        ${RateLimitThreshold},

		[Parameter(Mandatory, HelpMessage = "Metric Id on which the throttle limit should be set, MetricId can be discovered by hovering over Metric in the Metrics section of Event Hub Namespace inside Azure Portal")]
        [Microsoft.Azure.PowerShell.Cmdlets.EventHub.Support.MetricId]
		# Metric Id on which the throttle limit should be set, MetricId can be discovered by hovering over Metric in the Metrics section of Event Hub Namespace inside Azure Portal.
        ${MetricId}
	)

	process{
		try{
			$policy = [Microsoft.Azure.PowerShell.Cmdlets.EventHub.Models.Api20221001Preview.IThrottlingPolicy]@{
				Name = $Name
				MetricId = $MetricId
				RateLimitThreshold = $RateLimitThreshold
			}
			
			return $policy
		}
		catch{
			throw
		}
	}
}