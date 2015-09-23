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

########################################################################### General Store Scenario Tests ###########################################################################

<#
.SYNOPSIS
Tests any cloud based cmdlet with invalid credentials and expect it'll throw an exception.
#>
function Test-WithInvalidCredentials
{
	param([ScriptBlock] $cloudCmdlet)
	
	# Setup
	Remove-AllSubscriptions

	# Test
	Assert-Throws $cloudCmdlet "No current subscription has been designated. Use Select-AzureSubscription -Current <subscriptionName> to set the current subscription."
}

########################################################################### Get-AzureStoreAddOn Scenario Tests ###########################################################################

<#
.SYNOPSIS
Tests using Get-AzureStoreAddOn -ListAvailable with default country (US)
#>
function Test-GetAzureStoreAddOnListAvailableWithDefaultCountry
{
	# Test
	$actual = Get-AzureStoreAddOn -ListAvailable

	# Assert
	Assert-True { $actual.Count -gt 0 }
	$actual | % { Assert-NotNull $_.Provider; Assert-NotNull $_.AddOn; Assert-NotNull $_.Plans Assert-NotNull $_.Locations }
}

<#
.SYNOPSIS
Tests using Get-AzureStoreAddOn -ListAvailable with specified country that will not return any addons.
#>
function Test-GetAzureStoreAddOnListAvailableWithNoAddOns
{
	# Test
	$actual = Get-AzureStoreAddOn -ListAvailable "E1"

	# Assert
	Assert-True { $actual.Count -eq 0 }
}

<#
.SYNOPSIS
Tests using Get-AzureStoreAddOn -ListAvailable with specified country that will return addons.
#>
function Test-GetAzureStoreAddOnListAvailableWithCountry
{
	# Test
	$actual = Get-AzureStoreAddOn -ListAvailable "CH"

	# Assert
	Assert-True { $actual.Count -gt 0 }
}

<#
.SYNOPSIS
Tests using Get-AzureStoreAddOn -ListAvailable with invalid country name.
#>
function Test-GetAzureStoreAddOnListAvailableWithInvalidCountryName
{
	# Test
	Assert-Throws { Get-AzureStoreAddOn -ListAvailable "UnitedStates" } "Cannot validate argument on parameter 'Country'. The country name is invalid, please use a valid two character country code, as described in ISO 3166-1 alpha-2."
}

<#
.SYNOPSIS
Tests using Get-AzureStoreAddOn with empty add-ons.
#>
function Test-GetAzureStoreAddOnWithNoAddOns
{
	# Setup
	$current = Get-AzureStoreAddOn

	if ($current.Count -ne 0)
	{
		Write-Warning "The test can't run because the account is not setup correctly (add-on count should be 0)";
		exit;
	}

	# Test
	$actual = Get-AzureStoreAddOn

	# Assert
	Assert-True { $actual.Count -eq 0 }
}

<#
.SYNOPSIS
Tests using Get-AzureStoreAddOn with one add-on.
#>
function Test-GetAzureStoreAddOnWithOneAddOn
{
	# Setup
	$current = Get-AzureStoreAddOn

	if ($current.Count -ne 0)
	{
		Write-Warning "The test can't run because the account is not setup correctly (add-on count should be 0)";
		exit;
	}
	New-AddOn

	# Test
	$actual = Get-AzureStoreAddOn

	# Assert
	Assert-True { $actual.Count -eq 1 }
}

<#
.SYNOPSIS
Tests using Get-AzureStoreAddOn with many add-ons
#>
function Test-GetAzureStoreAddOnWithMultipleAddOns
{
	# Setup
	New-AddOn 3

	# Test
	$actual = Get-AzureStoreAddOn

	# Assert
	Assert-True { $actual.Count -gt 1 }
}

<#
.SYNOPSIS
Tests using Get-AzureStoreAddOn with getting existing add-on
#>
function Test-GetAzureStoreAddOnWithExistingAddOn
{
	# Setup
	New-AddOn
	$expected = $global:createdAddOns[0]

	# Test
	$actual = Get-AzureStoreAddOn $global:createdAddOns[0]

	# Assert
	$actual = $actual[0].Name
	Assert-AreEqual $expected $actual
}

<#
.SYNOPSIS
Tests using Get-AzureStoreAddOn with case invesitive.
#>
function Test-GetAzureStoreAddOnCaseInsinsitive
{
	# Setup
	New-AddOn
	$expected = $global:createdAddOns[0]

	# Test
	$actual = Get-AzureStoreAddOn $expected.ToUpper()

	# Assert
	$actual = $actual[0].Name
	Assert-AreEqual $expected.ToUpper() $actual.ToUpper()
}

<#
.SYNOPSIS
Tests using Get-AzureStoreAddOn with invalid add-on name, expects to fail.
#>
function Test-GetAzureStoreAddOnWithInvalidName
{
	# Test
	Assert-Throws { Get-AzureStoreAddOn "Invalid Name" } "The provided add-on name 'Invalid Name' is invalid"
}

<#
.SYNOPSIS
Tests using Get-AzureStoreAddOn with valid and non-existing add-on.
#>
function Test-GetAzureStoreAddOnValidNonExisting
{
	# Test
	$actual = Get-AzureStoreAddOn "NonExistingAddOn"

	# Assert
	Assert-AreEqual 0 $actual.Count
}

<#
.SYNOPSIS
Tests using Get-AzureStoreAddOn with App Service
#>
function Test-GetAzureStoreAddOnWithAppService
{
	# Setup
	New-AddOn

	# Test
	$actual = Get-AzureStoreAddOn

	# Assert
	$addon = $actual[0]
	Assert-AreEqual "App Service" $addon.Type
}

<#
.SYNOPSIS
Tests the piping between Get-AzureAddOn and Remove-AzureAddOn
#>
function Test-GetAzureStoreAddOnPipedToRemoveAzureAddOn
{
	# Setup
	New-AddOn
	$name = $global:createdAddOns[0]

	# Test
	Get-AzureStoreAddOn $name | Remove-AzureStoreAddOn

	# Assert
	$actual = Get-AzureStoreAddOn $name
	Assert-AreEqual 0 $actual.Count
}

########################################################################### New-AzureStoreAddOn Scenario Tests ###########################################################################

<#
.SYNOPSIS
Tests New-AzureStoreAddOn when missing a required parameter and expects it to fail.
#>
function Test-NewAzureStoreAddOnMissingRequiredParameter
{
	# Test
	Assert-Throws { New-AzureStoreAddOn AddOn Plan Location }
	Assert-Throws { New-AzureStoreAddOn Name Plan Location }
	Assert-Throws { New-AzureStoreAddOn Name AddOn Location }
	Assert-Throws { New-AzureStoreAddOn Name AddOn Plan }
}

<#
.SYNOPSIS
Tests New-AzureStoreAddOn with invalid name and expects it to fail.
#>
function Test-NewAzureStoreAddOnWithInvalidName
{
	# Test
	Assert-Throws { New-AzureStoreAddOn "Invalid Name" MicrosoftTranslator 2M-1 "West US" }
}

<#
.SYNOPSIS
Tests New-AzureStoreAddOn with invalid location and expects it to fail.
#>
function Test-NewAzureStoreAddOnWithInvalidWindowsAzureLocation
{
	# Test
	Assert-Throws { New-AzureStoreAddOn AddOnName MicrosoftTranslator 2M-1 "Invalid Location" }
}

<#
.SYNOPSIS
Tests New-AzureStoreAddOn happy path.
#>
function Test-NewAzureStoreAddOnSuccessfull
{
	# Test
	$created = New-AddOn

	# Assert
	$name = $global:createdAddOns[0]
	$actual = Get-AzureStoreAddOn $name
	Assert-AreEqual $name $actual.Name
	Assert-True { $created }
}

<#
.SYNOPSIS
Tests New-AzureStoreAddOn using existing add-on name and expects to fail.
#>
function Test-NewAzureStoreAddOnWithExistingName
{
	# Setup
	New-AddOn
	$name = $global:createdAddOns[0]
	$addon = Get-FreeAddOn

	# Test
	Assert-Throws { New-AzureStoreAddOn $name $addon.AddOn $addon.Plan $(Get-DefaultAddOnLocation $addon.AddOn) }
}

<#
.SYNOPSIS
Tests New-AzureStoreAddOn using non-existing add-on and expects to fail.
#>
function Test-NewAzureStoreAddOnWithInvalidAddOn
{
	# Setup
	New-AddOn
	$name = $global:createdAddOns[0]
	$addon = Get-FreeAddOn

	# Test
	Assert-Throws { New-AzureStoreAddOn $name "Invalid AddOn" $addon.Plan $(Get-DefaultAddOnLocation $addon.AddOn) }
}

<#
.SYNOPSIS
Tests New-AzureStoreAddOn using an invalid plan
#>
function Test-NewAzureStoreAddOnWithInvalidPlan
{
	# Test
	Assert-Throws { New-AzureStoreAddOn $(Get-AddOnName) MicrosoftTranslator free $(Get-DefaultAddOnLocation MicrosoftTranslator) }
}

<#
.SYNOPSIS
Tests New-AzureStoreAddOn with invalid location and expects it to fail.
#>
function Test-NewAzureStoreAddOnWithInvalidLocation
{
	# Test
	Assert-Throws { New-AzureStoreAddOn addonname sendgrid_azure free "North Central US" }
}

<#
.SYNOPSIS
Tests New-AzureStoreAddOn with invalid promo code.
#>
function Test-NewAzureStoreAddOnWithInvalidPromoCode
{
	# Setup
	$msg = "The REST operation failed with message 'Billing validation for the resource failed with error message: Error: BadUserInput, Description: Promotion Code entered is invalid..' and error code 'BadRequest'"

	# Test
	Assert-Throws { New-AzureStoreAddOn addonname sendgrid_azure free "West US" invalidpromo } $msg
}

<#
.SYNOPSIS
Tests New-AzureStoreAddOn with valid promo code.
#>
function Test-NewAzureStoreAddOnWithValidPromoCode
{
	# Setup
	$name = Get-AddOnName
	$addonId = "sendgrid_azure"

	# Test
	New-AzureStoreAddOn $name $addonId bronze $(Get-DefaultAddOnLocation $addonId) $promotionCode

	# Assert
	$actual = Get-AzureStoreAddOn $name
	Assert-NotNull $actual
	Assert-AreEqual $name $actual.Name
}

<#
.SYNOPSIS
Tests New-AzureStoreAddOn with user choice No and expects to not purchase.
#>
function Test-NewAzureStoreAddOnWithNo
{
	# Test
	$actual = New-AddOn

	# Assert
	Assert-False { $actual }
}

<#
.SYNOPSIS
Tests New-AzureStoreAddOn confirmation message
#>
function Test-NewAzureStoreAddOnConfirmationMessage
{
	# Setup
	$name = Get-AddOnName
	$addonId = "sendgrid_azure"
	$plan = "free"

	# Test
	$actual = New-AzureStoreAddOn $name $addonId $plan $(Get-DefaultAddOnLocation $addonId)

	# Assert
	Assert-True { $actual }
}

########################################################################### Remove-AzureStoreAddOn Scenario Tests ###########################################################################

<#
.SYNOPSIS
Tests Remove-AzureStoreAddOn happy path.
#>
function Test-RemoveAzureStoreAddOnSuccessfull
{
	# Setup
	New-AddOn

	# Test
	$actual = Remove-AzureStoreAddOn $global:createdAddOns[0] -PassThru

	# Assert
	Assert-True { $actual }
}

<#
.SYNOPSIS
Tests Remove-AzureStoreAddOn with different add-on name casing and expects to remove.
#>
function Test-RemoveAzureStoreAddOnWithCasing
{
	# Setup
	New-AddOn
	$name = $global:createdAddOns[0].ToUpper()

	# Test
	$actual = Remove-AzureStoreAddOn $name -PassThru

	# Assert
	Assert-True { $actual }
}

<#
.SYNOPSIS
Tests Remove-AzureStoreAddOn with non-existing add-on and expects to throw exception
#>
function Test-RemoveAzureStoreAddOnNotExisting
{
	# Test
	Assert-Throws { Remove-AzureStoreAddOn "NotExistingName" }
}

<#
.SYNOPSIS
Tests Remove-AzureStoreAddOn piped from Get-AzureStoreAddOn
#>
function Test-RemoveAzureStoreAddOnPipedFromGetAzureAddOn
{
	# Setup
	New-AddOn
	$name = $global:createdAddOns[0]

	# Test
	$actual  = Get-AzureStoreAddOn $name | Remove-AzureStoreAddOn -PassThru

	# Assert
	Assert-True { $actual }
}

<#
.SYNOPSIS
Tests Remove-AzureStoreAddOn piped from Get-AzureStoreAddOn with multiple add-ons
#>
function Test-RemoveAzureStoreAddOnMultiplePipedFromGetAzureAddOn
{
	# Setup
	New-AddOn 3
	$addons = @()
	foreach ($name in $global:createdAddOns)
	{
		$addons += Get-AzureStoreAddOn $name
	}

	# Test
	$actual = $addons | Remove-AzureStoreAddOn -PassThru

	# Assert
	Assert-True { $actual }
}

<#
.SYNOPSIS
Tests Remove-AzureStoreAddOn with No and expects not to purchase.
#>
function Test-RemoveAzureStoreAddOnWithNo
{
	# Setup
	New-AddOn

	# Test
	$actual = Remove-AzureStoreAddOn $global:createdAddOns[0] -PassThru

	# Assert
	Assert-False { $actual }
}