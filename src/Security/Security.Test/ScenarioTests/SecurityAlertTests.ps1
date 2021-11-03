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
Get security alerts on a subscription and its resources
#>
function Get-AzureRmSecurityAlert-SubscriptionScope
{
    $alerts = Get-AzSecurityAlert
	Validate-Alerts $alerts
}

<#
.SYNOPSIS
Get security alerts on a resource group and its resources
#>
function Get-AzureRmSecurityAlert-ResourceGroupScope
{
	$rgName = "Sample-RG"

    $alerts = Get-AzSecurityAlert -ResourceGroupName $rgName
	Validate-Alerts $alerts
}

<#
.SYNOPSIS
Get a security alert on a resource group level
#>
function Get-AzureRmSecurityAlert-ResourceGroupLevelResource
{
	$alerts = Get-AzSecurityAlert

	$alert = $alerts | where { $_.Id -like "*resourceGroups*" } | Select -First 1
	$location = Extract-ResourceLocation -ResourceId $alert.Id
	$rgName = Extract-ResourceGroup -ResourceId $alert.Id

    $fetchedAlert = Get-AzSecurityAlert -ResourceGroupName $rgName -Location $location -Name $alert.Name
	Validate-Alert $fetchedAlert
}

<#
.SYNOPSIS
Get a security alert on a subscription level
#>
function Get-AzureRmSecurityAlert-SubscriptionLevelResource
{
	$alerts = Get-AzSecurityAlert
	$alert = $alerts | where { $_.Id -notlike "*resourceGroups*" } | Select -First 1
	$location = Extract-ResourceLocation -ResourceId $alert.Id

    $fetchedAlert = Get-AzSecurityAlert -Location $location -Name $alert.Name
	Validate-Alert $fetchedAlert
}

<#
.SYNOPSIS
Get a security alert by a resource ID
#>
function Get-AzureRmSecurityAlert-ResourceId
{
	$alerts = Get-AzSecurityAlert
	$alert = $alerts | Select -First 1

    $alerts = Get-AzSecurityAlert -ResourceId $alert.Id
	Validate-Alerts $alerts
}

<#
.SYNOPSIS
Change resource group security alert state
#>
function Set-AzureRmSecurityAlert-ResourceGroupLevelResource
{
	$alerts = Get-AzSecurityAlert

	$alert = $alerts | where { $_.Id -like "*resourceGroups*" } | Select -First 1
	$location = Extract-ResourceLocation -ResourceId $alert.Id
	$rgName = Extract-ResourceGroup -ResourceId $alert.Id

	Set-AzSecurityAlert -ResourceGroupName $rgName -Location $location -Name $alert.Name -ActionType "Activate"

	$fetchedAlert = Get-AzSecurityAlert -ResourceGroupName $rgName -Location $location -Name $alert.Name

	Validate-AlertActivity -alert $fetchedAlert
}

<#
.SYNOPSIS
Change subscription security alert state
#>
function Set-AzureRmSecurityAlert-SubscriptionLevelResource
{
	$alerts = Get-AzSecurityAlert
	$alert = $alerts | where { $_.Id -notlike "*resourceGroups*" } | Select -First 1
	$location = Extract-ResourceLocation -ResourceId $alert.Id

	Set-AzSecurityAlert -Location $location -Name $alert.Name -ActionType "Activate"

	$fetchedAlert = Get-AzSecurityAlert -Location $location -Name $alert.Name

	Validate-AlertActivity -alert $fetchedAlert
}

<#
.SYNOPSIS
Change resource group security alert state by a resource ID
#>
function Set-AzureRmSecurityAlert-ResourceId
{
	$alerts = Get-AzSecurityAlert
	$alert = $alerts | Select -First 1

	Set-AzSecurityAlert -ResourceId $alert.Id -ActionType "Activate"
	$fetchedAlert = Get-AzSecurityAlert -ResourceId $alert.Id

	Validate-AlertActivity -alert $fetchedAlert
}

<#
.SYNOPSIS
Validates a list of security alerts
#>
function Validate-Alerts
{
	param($alerts)

    Assert-True { $alerts.Count -gt 0 }

	Foreach($alert in $alerts)
	{
		Validate-Alert $alert
	}
}

<#
.SYNOPSIS
Validates a single alert
#>
function Validate-Alert
{
	param($alert)

	Assert-NotNull $alert
}


<#
.SYNOPSIS
Validates a single alert
#>
function Validate-AlertActivity
{
	param($alert)

	Assert-NotNull $alert
	Assert-True { $alert.Status -eq "Active" }
}