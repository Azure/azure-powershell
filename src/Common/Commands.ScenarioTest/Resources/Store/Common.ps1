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

$createdAddOns = @()
$availableAddOnsInUS = $null

<#
.SYNOPSIS
Gets all available add-ons in US.
#>
function Get-AvailableAddOn
{
	if (!$availableAddOnsInUS)
	{
		$availableAddOnsInUS = Get-AzureStoreAddOn -ListAvailable US
	}

	return $availableAddOnsInUS
}

<#
.SYNOPSIS
Gets default location from the available list of add-on locations.

.PARAMETER name
The add-on id.
#>
function Get-DefaultAddOnLocation
{
	param([string] $addonId)

	$addon = Get-AvailableAddOn | Where { $_.AddOn -eq $addonId }
	
	return $addon.Locations[0]
}

<#
.SYNOPSIS
Gets a random object for an available add-on and free plan.

#>
function Get-RandomFreeAddOn
{
	$addons = Get-AvailableAddOn
	$freeAddOns = @()
	foreach ($addon in $addons)
	{
		$freePlan = $addon.Plans | Where { $_.Price -eq 0 }
		if ($freePlan)
		{
			$freeAddOn = @{}
			$freeAddOn.AddOn = $addon.AddOn
			$freeAddOn.Plan = $freePlan
			$freeAddOns += $freeAddOn
		}
	}
	$index = Get-Random -Minimum 0 -Maximum $freeAddOns.Count
	
	return $freeAddOns[$index]
}

<#
.SYNOPSIS
Gets valid and available add-on name.
#>
function Get-AddOnName
{
	do
	{
		$name = "OneSDK" + (Get-Random).ToString()
		$addons = Get-AzureStoreAddOn $name
		$used = ($addons.Count -ne 0)
	} while ($used)

	return $name
}

<#
.SYNOPSIS
Clears the all created resources while doing the test.
#>
function AddOn-TestCleanup
{
	foreach ($name in $global:createdAddOns)
	{
		try { Remove-AzureStoreAddOn $name }
		catch { <# proceed #> }
	}

	$global:createdAddOns = @()
}

<#
.SYNOPSIS
Creates random add-ons with the count specified.

.PARAMETER count
The number of add-ons to create.
#>
function New-RandomAddOn
{
	param([int] $count)

	if (!$count) { $count = 1 }

	1..$count | % { 
		$name = Get-AddOnName;
		$addon = Get-RandomFreeAddOn
		New-AzureStoreAddOn $name $addon.AddOn $addon.Plan $(Get-DefaultAddOnLocation $addon.AddOn)
		$global:createdAddOns += $name;
	}
}

<#
.SYNOPSIS
Gets free add-on from the predefined add-on list.
#>
function Get-FreeAddOn
{
	$addons = Get-AvailableAddOn
	$freeAddOns = @()
	foreach ($addonId in $global:freeAddOnIds)
	#foreach ($addonId in $freeAddOnIds)
	{
		$addon = $addons | Where { $_.AddOn -eq $addonId }
		Write-Debug "Addon Id: "
		Write-Debug $addonId
		$freePlan = $addon.Plans | Where { $_.Price -eq 0 }
		Write-Debug "Free plan: "
		Write-Debug $freePlan.PlanIdentifier
		if ($freePlan)
		{
			Write-Debug "Geet hena"
			$freeAddOn = @{}
			$freeAddOn.AddOn = $addon.AddOn
			$freeAddOn.Plan = $freePlan.PlanIdentifier
			$freeAddOns += $freeAddOn
		}
	}
	$index = Get-Random -Minimum 0 -Maximum $freeAddOns.Count
	
	return $freeAddOns[$index]
}

<#
.SYNOPSIS
Creates add-ons with the count specified.

.PARAMETER count
The number of add-ons to create.
#>
function New-AddOn
{
	param([int] $count)
	$created = $false

	if (!$count) { $count = 1 }

	1..$count | % {
		$name = Get-AddOnName;
		$addon = Get-FreeAddOn
		$created = New-AzureStoreAddOn $name $addon.AddOn $addon.Plan $(Get-DefaultAddOnLocation $addon.AddOn)
		if ($created) { $global:createdAddOns += $name; }
	}

	return $created
}