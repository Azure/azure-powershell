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
Tests Access Restrictions for WebApps
.DESCRIPTION
SmokeTest
#>
function Test-GetWebAppAccessRestriction
{
	# Setup
	$rgname = Get-ResourceGroupName
	$wname = Get-WebsiteName	
	$location = Get-WebLocation
	$whpName = Get-WebHostPlanName
	$tier = "S1"

	try
	{
		#Setup
		New-AzResourceGroup -Name $rgname -Location $location
		$serverFarm = New-AzAppServicePlan -ResourceGroupName $rgname -Name  $whpName -Location  $location -Tier $tier
		
		# Create new web app
		$webApp = New-AzWebApp -ResourceGroupName $rgname -Name $wname -Location $location -AppServicePlan $whpName 
		
		# Assert
		Assert-AreEqual $wname $webApp.Name
		Assert-AreEqual $serverFarm.Id $webApp.ServerFarmId
		
		# Get initial access restriction
		$actual = Get-AzWebAppAccessRestrictionConfig -ResourceGroupName $rgname -Name $wname

		# Assert
		Assert-AreEqual $false $actual.ScmSiteUseMainSiteRestrictionConfig
		Assert-AreEqual 1 $actual.MainSiteAccessRestrictions.Count
		Assert-AreEqual "Allow all" $actual.MainSiteAccessRestrictions[0].RuleName
		Assert-AreEqual "Allow" $actual.MainSiteAccessRestrictions[0].Action
		Assert-AreEqual 1 $actual.ScmSiteAccessRestrictions.Count
		Assert-AreEqual "Allow all" $actual.ScmSiteAccessRestrictions[0].RuleName
		Assert-AreEqual "Allow" $actual.ScmSiteAccessRestrictions[0].Action

	}
	finally
	{
		# Cleanup
		Remove-AzResourceGroup -Name $rgname -Force
	}
}

<#
.SYNOPSIS
Set inherit restrictions from main flag
#>
function Test-UpdateWebAppAccessRestrictionSimple
{
	# Setup
	$rgname = Get-ResourceGroupName
	$wname = Get-WebsiteName	
	$location = Get-WebLocation
	$whpName = Get-WebHostPlanName
	$tier = "S1"

	try
	{
		# Setup
		New-AzResourceGroup -Name $rgname -Location $location
		$serverFarm = New-AzAppServicePlan -ResourceGroupName $rgname -Name  $whpName -Location  $location -Tier $tier
		
		# Create new web app
		$webApp = New-AzWebApp -ResourceGroupName $rgname -Name $wname -Location $location -AppServicePlan $whpName 
		
		# Assert Setup
		Assert-AreEqual $wname $webApp.Name
		Assert-AreEqual $serverFarm.Id $webApp.ServerFarmId
		
		# Run Tests
		Update-AzWebAppAccessRestrictionConfig -ResourceGroupName $rgname -Name $wname -ScmSiteUseMainSiteRestrictionConfig
		$actual = Get-AzWebAppAccessRestrictionConfig -ResourceGroupName $rgname -Name $wname

		# Assert		
		Assert-AreEqual $true $actual.ScmSiteUseMainSiteRestrictionConfig
	}
	finally
	{
		# Cleanup
		Remove-AzResourceGroup -Name $rgname -Force
	}
}

<#
.SYNOPSIS
Set inherit restrictions from main flag to true and back to false
#>
function Test-UpdateWebAppAccessRestrictionComplex
{
	# Setup
	$rgname = Get-ResourceGroupName
	$wname = Get-WebsiteName	
	$location = Get-WebLocation
	$whpName = Get-WebHostPlanName
	$tier = "Shared"

	try
	{
		# Setup
		New-AzResourceGroup -Name $rgname -Location $location
		$serverFarm = New-AzAppServicePlan -ResourceGroupName $rgname -Name  $whpName -Location  $location -Tier $tier
		
		# Create new web app
		$webApp = New-AzWebApp -ResourceGroupName $rgname -Name $wname -Location $location -AppServicePlan $whpName 
		
		# Assert Setup
		Assert-AreEqual $wname $webApp.Name
		Assert-AreEqual $serverFarm.Id $webApp.ServerFarmId
		
		# Run Tests
		$actual = Update-AzWebAppAccessRestrictionConfig -ResourceGroupName $rgname -Name $wname -ScmSiteUseMainSiteRestrictionConfig -PassThru

		# Assert
		Assert-AreEqual $true $actual.ScmSiteUseMainSiteRestrictionConfig

		# Run Tests
		Update-AzWebAppAccessRestrictionConfig -ResourceGroupName $rgname -Name $wname -ScmSiteUseMainSiteRestrictionConfig:$false
		$actual = Get-AzWebAppAccessRestrictionConfig -ResourceGroupName $rgname -Name $wname

		# Assert
		Assert-AreEqual $false $actual.ScmSiteUseMainSiteRestrictionConfig
	}
	finally
	{
		# Cleanup
		Remove-AzResourceGroup -Name $rgname -Force
	}
}

<#
.SYNOPSIS
Add IpAddress Access Restriction
#>
function Test-AddWebAppAccessRestriction
{
	# Setup
	$rgname = Get-ResourceGroupName
	$wname = Get-WebsiteName	
	$location = Get-WebLocation
	$whpName = Get-WebHostPlanName
	$tier = "Shared"

	try
	{
		# Setup
		New-AzResourceGroup -Name $rgname -Location $location
		$serverFarm = New-AzAppServicePlan -ResourceGroupName $rgname -Name  $whpName -Location  $location -Tier $tier
		
		# Create new web app
		$webApp = New-AzWebApp -ResourceGroupName $rgname -Name $wname -Location $location -AppServicePlan $whpName 
		
		# Assert Setup
		Assert-AreEqual $wname $webApp.Name
		Assert-AreEqual $serverFarm.Id $webApp.ServerFarmId
		
		# Run Tests
		$actual = Add-AzWebAppAccessRestrictionRule -ResourceGroupName $rgname -WebAppName $wname -Name developers -Action Allow -IpAddress 130.220.0.0/27 -Priority 200 -PassThru

		# Assert
		Assert-AreEqual 2 $actual.MainSiteAccessRestrictions.Count
		Assert-AreEqual "developers" $actual.MainSiteAccessRestrictions[0].RuleName
		Assert-AreEqual "Allow" $actual.MainSiteAccessRestrictions[0].Action
		Assert-AreEqual "Deny all" $actual.MainSiteAccessRestrictions[1].RuleName
		Assert-AreEqual "Deny" $actual.MainSiteAccessRestrictions[1].Action
	}
	finally
	{
		# Cleanup
		Remove-AzResourceGroup -Name $rgname -Force
	}
}

<#
.SYNOPSIS
Add ServiceTag Access Restriction
#>
function Test-AddWebAppAccessRestrictionServiceTag
{
	# Setup
	$rgname = Get-ResourceGroupName
	$wname = Get-WebsiteName	
	$location = Get-WebLocation
	$whpName = Get-WebHostPlanName
	$tier = "Shared"
	$serviceTag = "AzureFrontDoor.Backend"

	try
	{
		# Setup
		New-AzResourceGroup -Name $rgname -Location $location
		$serverFarm = New-AzAppServicePlan -ResourceGroupName $rgname -Name  $whpName -Location  $location -Tier $tier
		
		# Create new web app
		$webApp = New-AzWebApp -ResourceGroupName $rgname -Name $wname -Location $location -AppServicePlan $whpName 
		
		# Assert Setup
		Assert-AreEqual $wname $webApp.Name
		Assert-AreEqual $serverFarm.Id $webApp.ServerFarmId
		
		# Run Tests
		$actual = Add-AzWebAppAccessRestrictionRule -ResourceGroupName $rgname -WebAppName $wname -Name frontdoor -Action Allow -ServiceTag $serviceTag -Priority 400 -PassThru

		# Assert
		Assert-AreEqual 2 $actual.MainSiteAccessRestrictions.Count
		Assert-AreEqual "frontdoor" $actual.MainSiteAccessRestrictions[0].RuleName
		Assert-AreEqual "Allow" $actual.MainSiteAccessRestrictions[0].Action
		Assert-AreEqual $serviceTag $actual.MainSiteAccessRestrictions[0].IpAddress
		Assert-AreEqual "Deny all" $actual.MainSiteAccessRestrictions[1].RuleName
		Assert-AreEqual "Deny" $actual.MainSiteAccessRestrictions[1].Action
	}
	finally
	{
		# Cleanup
		Remove-AzResourceGroup -Name $rgname -Force
	}
}

<#
.SYNOPSIS
Add HttpHeader Access Restriction
#>
function Test-AddWebAppAccessRestrictionHttpHeaders
{
	# Setup
	$rgname = Get-ResourceGroupName
	$wname = Get-WebsiteName	
	$location = Get-WebLocation
	$whpName = Get-WebHostPlanName
	$tier = "Shared"
	$serviceTag = "AzureFrontDoor.Backend"

	try
	{
		# Setup
		New-AzResourceGroup -Name $rgname -Location $location
		$serverFarm = New-AzAppServicePlan -ResourceGroupName $rgname -Name  $whpName -Location  $location -Tier $tier
		
		# Create new web app
		$webApp = New-AzWebApp -ResourceGroupName $rgname -Name $wname -Location $location -AppServicePlan $whpName 
		
		# Assert Setup
		Assert-AreEqual $wname $webApp.Name
		Assert-AreEqual $serverFarm.Id $webApp.ServerFarmId
		
		# Run Tests
		$actual = Add-AzWebAppAccessRestrictionRule -ResourceGroupName $rgname -WebAppName $wname -Name singleinstance-frontdoor -Action Allow -ServiceTag $serviceTag `
		-Priority 500 -HttpHeader @{'x-azure-fdid' = '355deb06-47c4-4ba4-9641-c7d7a98b913e'; 'x-forwarded-host' = 'www.contoso.com', 'app.contoso.com' } -PassThru

		# Assert
		Assert-AreEqual 2 $actual.MainSiteAccessRestrictions.Count
		Assert-AreEqual "singleinstance-frontdoor" $actual.MainSiteAccessRestrictions[0].RuleName
		Assert-AreEqual "Allow" $actual.MainSiteAccessRestrictions[0].Action
		Assert-AreEqual $serviceTag $actual.MainSiteAccessRestrictions[0].IpAddress
		Assert-NotNull $actual.MainSiteAccessRestrictions[0].HttpHeader
		Assert-AreEqual "Deny all" $actual.MainSiteAccessRestrictions[1].RuleName
		Assert-AreEqual "Deny" $actual.MainSiteAccessRestrictions[1].Action
	}
	finally
	{
		# Cleanup
		Remove-AzResourceGroup -Name $rgname -Force
	}
}

<#
.SYNOPSIS
Add Subnet Access Restriction
#>
function Test-AddWebAppAccessRestrictionServiceEndpoint
{
	# Setup
	$rgname = Get-ResourceGroupName
	$wname = Get-WebsiteName	
	$location = Get-WebLocation
	$whpName = Get-WebHostPlanName
	$vNetResourceGroupName = "pstest-rg"
	$vNetName = "pstest-vnet"
	$subnetName = "endpoint-subnet"
	$tier = "Shared"

	try
	{
		# Setup
		Write-Debug "Starting Test-AddWebAppAccessRestrictionServiceEndpoint"
		New-AzResourceGroup -Name $rgname -Location $location
		############
		# Test depends on vNet being created in the active TestFramework subscription (default location is West US)
		# $endpointSubnet = New-AzVirtualNetworkSubnetConfig -Name $subnetName -AddressPrefix "10.0.0.0/24"
		# New-AzVirtualNetwork -Name $vNetName -ResourceGroupName $vNetResourceGroupName -Location $location -AddressPrefix "10.0.0.0/16" -Subnet $endpointSubnet
		############

		# vNet is in different RG, so we need to fetch Id. Get Subnet in AzResource is currently not working, so manually constructing string
		$subscriptionId = getSubscription
		$subnetId = '/subscriptions/' + $subscriptionId + '/resourceGroups/' + $vNetResourceGroupName + '/providers/Microsoft.Network/virtualNetworks/' + $vNetName +  '/subnets/' + $subnetName
				
		$serverFarm = New-AzAppServicePlan -ResourceGroupName $rgname -Name  $whpName -Location  $location -Tier $tier
		
		# Create new web app
		$webApp = New-AzWebApp -ResourceGroupName $rgname -Name $wname -Location $location -AppServicePlan $whpName 
				
		# Assert Setup
		Assert-AreEqual $wname $webApp.Name
		Assert-AreEqual $serverFarm.Id $webApp.ServerFarmId		
		
		# Run Tests
		$actual = Add-AzWebAppAccessRestrictionRule -ResourceGroupName $rgname -WebAppName $wname -Name vNetIntegration -Action Allow -SubnetId $subnetId -Priority 150 -PassThru

		# Assert
		Assert-AreEqual 2 $actual.MainSiteAccessRestrictions.Count
		Assert-AreEqual "vNetIntegration" $actual.MainSiteAccessRestrictions[0].RuleName
		Assert-AreEqual "Allow" $actual.MainSiteAccessRestrictions[0].Action
		Assert-AreEqual "Deny all" $actual.MainSiteAccessRestrictions[1].RuleName
		Assert-AreEqual "Deny" $actual.MainSiteAccessRestrictions[1].Action

		# Assert for set of ServiceEndpoint is currently not possible
	}
	finally
	{
		# Cleanup
		Remove-AzResourceGroup -Name $rgname -Force
	}
}

<#
.SYNOPSIS
Add and Remove IpAddress Access Restriction
#>
function Test-RemoveWebAppAccessRestriction
{
	# Setup
	$rgname = Get-ResourceGroupName
	$wname = Get-WebsiteName	
	$location = Get-WebLocation
	$whpName = Get-WebHostPlanName
	$tier = "Shared"

	try
	{
		# Setup
		New-AzResourceGroup -Name $rgname -Location $location
		$serverFarm = New-AzAppServicePlan -ResourceGroupName $rgname -Name  $whpName -Location  $location -Tier $tier
		
		# Create new web app
		$webApp = New-AzWebApp -ResourceGroupName $rgname -Name $wname -Location $location -AppServicePlan $whpName 
		
		# Assert Setup
		Assert-AreEqual $wname $webApp.Name
		Assert-AreEqual $serverFarm.Id $webApp.ServerFarmId
		
		# Run Tests
		$actual = Add-AzWebAppAccessRestrictionRule -ResourceGroupName $rgname -WebAppName $wname -Name developers -Action Allow -IpAddress 130.220.0.0/27 -Priority 200 -PassThru

		# Assert
		Assert-AreEqual 2 $actual.MainSiteAccessRestrictions.Count
		Assert-AreEqual "developers" $actual.MainSiteAccessRestrictions[0].RuleName
		Assert-AreEqual "Allow" $actual.MainSiteAccessRestrictions[0].Action
		Assert-AreEqual "Deny all" $actual.MainSiteAccessRestrictions[1].RuleName
		Assert-AreEqual "Deny" $actual.MainSiteAccessRestrictions[1].Action

		# Run Tests
		$actual = Remove-AzWebAppAccessRestrictionRule -ResourceGroupName $rgname -WebAppName $wname -Name developers -PassThru

		# Assert
		Assert-AreEqual 1 $actual.MainSiteAccessRestrictions.Count
		Assert-AreEqual "Allow all" $actual.MainSiteAccessRestrictions[0].RuleName
		Assert-AreEqual "Allow" $actual.MainSiteAccessRestrictions[0].Action
	}
	finally
	{
		# Cleanup
		Remove-AzResourceGroup -Name $rgname -Force
	}
}

<#
.SYNOPSIS
Add and Remove ServiceTag Access Restriction
#>
function Test-RemoveWebAppAccessRestrictionServiceTag
{
	# Setup
	$rgname = Get-ResourceGroupName
	$wname = Get-WebsiteName	
	$location = Get-WebLocation
	$whpName = Get-WebHostPlanName
	$tier = "Shared"
	$serviceTag = "AzureCloud"

	try
	{
		# Setup
		New-AzResourceGroup -Name $rgname -Location $location
		$serverFarm = New-AzAppServicePlan -ResourceGroupName $rgname -Name  $whpName -Location  $location -Tier $tier
		
		# Create new web app
		$webApp = New-AzWebApp -ResourceGroupName $rgname -Name $wname -Location $location -AppServicePlan $whpName 
		
		# Assert Setup
		Assert-AreEqual $wname $webApp.Name
		Assert-AreEqual $serverFarm.Id $webApp.ServerFarmId
		
		# Run Tests
		$actual = Add-AzWebAppAccessRestrictionRule -ResourceGroupName $rgname -WebAppName $wname -Name all-azure -Action Allow -ServiceTag $serviceTag -Priority 400 -PassThru

		# Assert
		Assert-AreEqual 2 $actual.MainSiteAccessRestrictions.Count
		Assert-AreEqual "all-azure" $actual.MainSiteAccessRestrictions[0].RuleName
		Assert-AreEqual $serviceTag $actual.MainSiteAccessRestrictions[0].IpAddress
		Assert-AreEqual "Allow" $actual.MainSiteAccessRestrictions[0].Action
		Assert-AreEqual "Deny all" $actual.MainSiteAccessRestrictions[1].RuleName
		Assert-AreEqual "Deny" $actual.MainSiteAccessRestrictions[1].Action

		# Run Tests
		$actual = Remove-AzWebAppAccessRestrictionRule -ResourceGroupName $rgname -WebAppName $wname -ServiceTag $serviceTag -PassThru

		# Assert
		Assert-AreEqual 1 $actual.MainSiteAccessRestrictions.Count
		Assert-AreEqual "Allow all" $actual.MainSiteAccessRestrictions[0].RuleName
		Assert-AreEqual "Allow" $actual.MainSiteAccessRestrictions[0].Action
	}
	finally
	{
		# Cleanup
		Remove-AzResourceGroup -Name $rgname -Force
	}
}

<#
.SYNOPSIS
Add IpAddress Access Restriction to SCM Site
#>
function Test-AddWebAppAccessRestrictionScm
{
	# Setup
	$rgname = Get-ResourceGroupName
	$wname = Get-WebsiteName	
	$location = Get-WebLocation
	$whpName = Get-WebHostPlanName
	$tier = "Shared"

	try
	{
		# Setup
		New-AzResourceGroup -Name $rgname -Location $location
		$serverFarm = New-AzAppServicePlan -ResourceGroupName $rgname -Name  $whpName -Location  $location -Tier $tier
		
		# Create new web app
		$webApp = New-AzWebApp -ResourceGroupName $rgname -Name $wname -Location $location -AppServicePlan $whpName 
		
		# Assert Setup
		Assert-AreEqual $wname $webApp.Name
		Assert-AreEqual $serverFarm.Id $webApp.ServerFarmId
		
		# Run Tests
		$actual = Add-AzWebAppAccessRestrictionRule -ResourceGroupName $rgname -WebAppName $wname -Name developers -Action Allow -IpAddress 130.220.0.0/27 -Priority 200 -TargetScmSite -PassThru

		# Assert
		Assert-AreEqual 2 $actual.ScmSiteAccessRestrictions.Count
		Assert-AreEqual "developers" $actual.ScmSiteAccessRestrictions[0].RuleName
		Assert-AreEqual "Allow" $actual.ScmSiteAccessRestrictions[0].Action
		Assert-AreEqual "Deny all" $actual.ScmSiteAccessRestrictions[1].RuleName
		Assert-AreEqual "Deny" $actual.ScmSiteAccessRestrictions[1].Action
	}
	finally
	{
		# Cleanup
		Remove-AzResourceGroup -Name $rgname -Force
	}
}

<#
.SYNOPSIS
Add and Remove IpAddress Access Restriction from SCM Site
#>
function Test-RemoveWebAppAccessRestrictionScm
{
	# Setup
	$rgname = Get-ResourceGroupName
	$wname = Get-WebsiteName	
	$location = Get-WebLocation
	$whpName = Get-WebHostPlanName
	$tier = "Shared"

	try
	{
		# Setup
		New-AzResourceGroup -Name $rgname -Location $location
		$serverFarm = New-AzAppServicePlan -ResourceGroupName $rgname -Name  $whpName -Location  $location -Tier $tier
		
		# Create new web app
		$webApp = New-AzWebApp -ResourceGroupName $rgname -Name $wname -Location $location -AppServicePlan $whpName 
		
		# Assert Setup
		Assert-AreEqual $wname $webApp.Name
		Assert-AreEqual $serverFarm.Id $webApp.ServerFarmId
		
		# Run Tests
		$actual = Add-AzWebAppAccessRestrictionRule -ResourceGroupName $rgname -WebAppName $wname -Name developers -Action Allow -IpAddress 130.220.0.0/27 -Priority 200 -TargetScmSite -PassThru

		# Assert
		Assert-AreEqual 2 $actual.ScmSiteAccessRestrictions.Count
		Assert-AreEqual "developers" $actual.ScmSiteAccessRestrictions[0].RuleName
		Assert-AreEqual "Allow" $actual.ScmSiteAccessRestrictions[0].Action
		Assert-AreEqual "Deny all" $actual.ScmSiteAccessRestrictions[1].RuleName
		Assert-AreEqual "Deny" $actual.ScmSiteAccessRestrictions[1].Action

		# Run Tests
		$actual = Remove-AzWebAppAccessRestrictionRule -ResourceGroupName $rgname -WebAppName $wname -Name developers -TargetScmSite -PassThru

		# Assert
		Assert-AreEqual 1 $actual.ScmSiteAccessRestrictions.Count
		Assert-AreEqual "Allow all" $actual.ScmSiteAccessRestrictions[0].RuleName
		Assert-AreEqual "Allow" $actual.ScmSiteAccessRestrictions[0].Action
	}
	finally
	{
		# Cleanup
		Remove-AzResourceGroup -Name $rgname -Force
	}
}

<#
.SYNOPSIS
Tests Access Restrictions for WebApps with Deployment Slot
#>
function Test-AddWebAppAccessRestrictionSlot
{
	# Setup
	$rgname = Get-ResourceGroupName
	$wname = Get-WebsiteName	
	$location = Get-WebLocation
	$whpName = Get-WebHostPlanName
	$slotName = "stage"
	$tier = "S1"

	try
	{
		#Setup
		New-AzResourceGroup -Name $rgname -Location $location
		$serverFarm = New-AzAppServicePlan -ResourceGroupName $rgname -Name  $whpName -Location  $location -Tier $tier
		
		# Create new web app
		$webApp = New-AzWebApp -ResourceGroupName $rgname -Name $wname -Location $location -AppServicePlan $whpName 
		$webAppSlot = New-AzWebAppSlot -ResourceGroupName $rgname -Name $wname -AppServicePlan $whpName -Slot $slotName

		# Assert
		Assert-AreEqual $wname $webApp.Name
		Assert-AreEqual $serverFarm.Id $webApp.ServerFarmId
		
		# Get initial access restriction
		$actual = Get-AzWebAppAccessRestrictionConfig -ResourceGroupName $rgname -Name $wname -SlotName $slotName

		# Assert
		Assert-AreEqual $false $actual.ScmSiteUseMainSiteRestrictionConfig
		Assert-AreEqual 1 $actual.MainSiteAccessRestrictions.Count
		Assert-AreEqual "Allow all" $actual.MainSiteAccessRestrictions[0].RuleName
		Assert-AreEqual "Allow" $actual.MainSiteAccessRestrictions[0].Action
		Assert-AreEqual 1 $actual.ScmSiteAccessRestrictions.Count
		Assert-AreEqual "Allow all" $actual.ScmSiteAccessRestrictions[0].RuleName
		Assert-AreEqual "Allow" $actual.ScmSiteAccessRestrictions[0].Action

		# Run Tests
		$actual = Add-AzWebAppAccessRestrictionRule -ResourceGroupName $rgname -WebAppName $wname -Name developers -Action Allow -IpAddress 130.220.0.0/27 -Priority 200 -SlotName $slotName -PassThru

		# Assert
		Assert-AreEqual 2 $actual.MainSiteAccessRestrictions.Count
		Assert-AreEqual "developers" $actual.MainSiteAccessRestrictions[0].RuleName
		Assert-AreEqual "Allow" $actual.MainSiteAccessRestrictions[0].Action
		Assert-AreEqual "Deny all" $actual.MainSiteAccessRestrictions[1].RuleName
		Assert-AreEqual "Deny" $actual.MainSiteAccessRestrictions[1].Action
	}
	finally
	{
		# Cleanup
		Remove-AzResourceGroup -Name $rgname -Force
	}
}