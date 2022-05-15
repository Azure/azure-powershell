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
.SYNOPSIS
Get alerts suppression rules on a subscription scope
#>
function Get-AzAlertsSuppressionRule-SubscriptionScope
{
    $alertsSuppressionRule = Get-AzAlertsSuppressionRule
	Validate-AlertsSuppressionRule $alertsSuppressionRule
}

<#
.SYNOPSIS
Get security contacts on a subscription
#>
function CreateAndDelete-AzAlertsSuppressionRule
{
	$ruleName = "Powershell-UT-RuleName"


	$rule = Get-AzAlertsSuppressionRule | where { $_.Name -eq $ruleName }
	Assert-True { $rule.Count -eq 0 }

	$newRequest = New-Object Microsoft.Azure.Commands.Security.Models.AlertsSuppressionRules.PSAlertsSuppressionRule -Property @{ 
		Name = $ruleName
		AlertType = "PS-UT-AlertType"
		Reason = "Other"
		Comment = "PS-UT-Comment"
	}

	Set-AzAlertsSuppressionRule -InputObject $newRequest
	$rule = Get-AzAlertsSuppressionRule | where { $_.Name -eq $ruleName }
	Assert-True { $rule.Count -eq 1 }

	Remove-AzAlertsSuppressionRule -Name $ruleName
}

<#
.SYNOPSIS
Validates a list of alert suppression rules
#>
function Validate-AlertsSuppressionRule
{
	param($alertsSuppressionRule)

    Assert-True { $alertsSuppressionRule.Count -gt 0 }

	Foreach($alertsSuppressionRule in $alertsSuppressionRule)
	{
		Validate-AllowedConnection $alertsSuppressionRule
	}
}

<#
.SYNOPSIS
Validates a single alert suppression rule
#>
function Validate-AlertsSuppressionRule
{
	param($alertsSuppressionRule)

	Assert-NotNull $alertsSuppressionRule
}