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
Get security compliances on a subscription
#>
function Get-AzureRmSecurityCompliance-SubscriptionScope
{
    $compliances = Get-AzSecurityCompliance
	Validate-Compliances $compliances
}

<#
.SYNOPSIS
Get security compliance on a specific day
#>
function Get-AzureRmSecurityCompliance-SubscriptionLevelResource
{
	$compliance = Get-AzSecurityCompliance | Select -First 1
    $fetchedCompliance = Get-AzSecurityCompliance -Name $compliance.Name
	Validate-Compliance $fetchedCompliance
}

<#
.SYNOPSIS
Get security compliance by a resource ID
#>
function Get-AzureRmSecurityCompliance-ResourceId
{
	$compliance = Get-AzSecurityCompliance | Select -First 1

	$location = Get-AzSecurityLocation | Select -First 1

	$context = Get-AzContext
	$subscriptionId = $context.Subscription.Id
	

    $fetchedCompliance = Get-AzSecurityCompliance -ResourceId "/subscriptions/$subscriptionId/providers/Microsoft.Seucurity/locations/$location/compliances/$($compliance.Name)"
	Validate-Compliances $fetchedCompliance
}

<#
.SYNOPSIS
Validates a list of security compliances
#>
function Validate-Compliances
{
	param($compliances)

    Assert-True { $compliances.Count -gt 0 }

	Foreach($compliance in $compliances)
	{
		Validate-Compliance $compliance
	}
}

<#
.SYNOPSIS
Validates a single compliance
#>
function Validate-Compliance
{
	param($compliance)

	Assert-NotNull $compliance
}