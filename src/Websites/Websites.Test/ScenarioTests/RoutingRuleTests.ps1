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
Tests creating a new Routing Rule.
#>
function Test-AddWebAppTrafficRoutingRule
{
	# Setup
	$ReroutePercentage="15"
	$rgname = Get-ResourceGroupName
	$appname = Get-WebsiteName
	$location = Get-Location
	$slotName = "staging"
	$planName = Get-WebHostPlanName
	$tier = "Standard"
	$resourceType = "Microsoft.Web/sites"
	try
	{
		#Setup
		New-AzResourceGroup -Name $rgname -Location $location
		$serverFarm = New-AzAppServicePlan -ResourceGroupName $rgname -Name  $planName -Location  $location -Tier $tier
		
		# Create new web app
		$actual =  New-AzWebApp -ResourceGroupName $rgname -Name $appname -Location $location -AppServicePlan $planName
		
		# Assert
		Assert-AreEqual $appname $actual.Name
		Assert-AreEqual $serverFarm.Id $actual.ServerFarmId

		# Create deployment slot
		$job = New-AzWebAppSlot -ResourceGroupName $rgname -Name $appname -Slot $slotName -AsJob
		$job | Wait-Job
		$slot = $job | Receive-Job

		$appWithSlotName = "$appname/$slotName"

		# Assert
		Assert-AreEqual $appWithSlotName $slot.Name
		Assert-AreEqual $serverFarm.Id $slot.ServerFarmId

		#Add Routing Rule for $slot
		$rule=Add-AzWebAppTrafficRouting -ResourceGroupName $rgname -WebAppName $appname -RoutingRule @{ActionHostName=$slot.DefaultHostName;ReroutePercentage=$ReroutePercentage;Name=$slotName}
	   
	   # Assert
		Assert-AreEqual $ReroutePercentage $rule.ReroutePercentage
		Assert-AreEqual $slot.DefaultHostName $rule.ActionHostName
		Assert-AreEqual $slotName $rule.Name
	}
	finally
	{
		# Cleanup
		Remove-AzResourceGroup -Name $rgname -Force
	}
}

<#
.SYNOPSIS
Tests Removing the given Routing Rule.
#>
function Test-RemoveWebAppTrafficRoutingRule
{
	# Setup
	$ReroutePercentage="15"
	$rgname = Get-ResourceGroupName
	$appname = Get-WebsiteName
	$location = Get-Location
	$slotName = "staging"
	$planName = Get-WebHostPlanName
	$tier = "Standard"
	$resourceType = "Microsoft.Web/sites"
	try
	{
		#Setup
		New-AzResourceGroup -Name $rgname -Location $location
		$serverFarm = New-AzAppServicePlan -ResourceGroupName $rgname -Name  $planName -Location  $location -Tier $tier
		
		# Create new web app
		$actual =  New-AzWebApp -ResourceGroupName $rgname -Name $appname -Location $location -AppServicePlan $planName
		
		# Assert
		Assert-AreEqual $appname $actual.Name
		Assert-AreEqual $serverFarm.Id $actual.ServerFarmId

		# Create deployment slot
		$job = New-AzWebAppSlot -ResourceGroupName $rgname -Name $appname -Slot $slotName -AsJob
		$job | Wait-Job
		$slot = $job | Receive-Job

		$appWithSlotName = "$appname/$slotName"

		# Assert
		Assert-AreEqual $appWithSlotName $slot.Name
		Assert-AreEqual $serverFarm.Id $slot.ServerFarmId

		#Add Routing Rule for $slot
		$rule=Add-AzWebAppTrafficRouting -ResourceGroupName $rgname -WebAppName $appname -RoutingRule @{ActionHostName=$slot.DefaultHostName;ReroutePercentage=$ReroutePercentage;Name=$slotName}
	   
	   # Assert
		Assert-AreEqual $ReroutePercentage $rule.ReroutePercentage
		Assert-AreEqual $slot.DefaultHostName $rule.ActionHostName
		Assert-AreEqual $slotName $rule.Name

		#remove 
		$rule=Remove-AzWebAppTrafficRouting -ResourceGroupName $rgname -WebAppName $appname -RuleName $rule.Name
		
		#Assert
		Assert-Null -eq $rule
	}
	finally
	{
		# Cleanup
		Remove-AzResourceGroup -Name $rgname -Force
	}
}

<#
.SYNOPSIS
Tests Returns the given Routing Rule.
#>
function Test-GetWebAppTrafficRoutingRule
{
	# Setup
	$ReroutePercentage="15"
	$rgname = Get-ResourceGroupName
	$appname = Get-WebsiteName
	$location = Get-Location
	$slotName = "staging"
	$planName = Get-WebHostPlanName
	$tier = "Standard"
	$resourceType = "Microsoft.Web/sites"
	try
	{
		#Setup
		New-AzResourceGroup -Name $rgname -Location $location
		$serverFarm = New-AzAppServicePlan -ResourceGroupName $rgname -Name  $planName -Location  $location -Tier $tier
		
		# Create new web app
		$actual =  New-AzWebApp -ResourceGroupName $rgname -Name $appname -Location $location -AppServicePlan $planName
		
		# Assert
		Assert-AreEqual $appname $actual.Name
		Assert-AreEqual $serverFarm.Id $actual.ServerFarmId

		# Create deployment slot
		$job = New-AzWebAppSlot -ResourceGroupName $rgname -Name $appname -Slot $slotName -AsJob
		$job | Wait-Job
		$slot = $job | Receive-Job

		$appWithSlotName = "$appname/$slotName"

		# Assert
		Assert-AreEqual $appWithSlotName $slot.Name
		Assert-AreEqual $serverFarm.Id $slot.ServerFarmId

		#Add Routing Rule for $slot
		Add-AzWebAppTrafficRouting -ResourceGroupName $rgname -WebAppName $appname -RoutingRule @{ActionHostName=$slot.DefaultHostName;ReroutePercentage=$ReroutePercentage;Name=$slotName}
	    #Get 
		$rule= Get-AzWebAppTrafficRouting -ResourceGroupName $rgname -WebAppName $appname -RuleName $slotName

		# Assert
		Assert-AreEqual $ReroutePercentage $rule.ReroutePercentage
		Assert-AreEqual $slot.DefaultHostName $rule.ActionHostName
		Assert-AreEqual $slotName $rule.Name
	}
	finally
	{
		# Cleanup
		Remove-AzResourceGroup -Name $rgname -Force
	}
}

<#
.SYNOPSIS
Tests Updates the given Routing Rule.
#>
function Test-UpdateWebAppTrafficRoutingRule
{
	# Setup
	$ReroutePercentage="15"
	$updatedReroutePercentage="20"
	$rgname = Get-ResourceGroupName
	$appname = Get-WebsiteName
	$location = Get-Location
	$slotName = "staging"
	$planName = Get-WebHostPlanName
	$tier = "Standard"
	$resourceType = "Microsoft.Web/sites"
	try
	{
		#Setup
		New-AzResourceGroup -Name $rgname -Location $location
		$serverFarm = New-AzAppServicePlan -ResourceGroupName $rgname -Name  $planName -Location  $location -Tier $tier
		
		# Create new web app
		$actual =  New-AzWebApp -ResourceGroupName $rgname -Name $appname -Location $location -AppServicePlan $planName
		
		# Assert
		Assert-AreEqual $appname $actual.Name
		Assert-AreEqual $serverFarm.Id $actual.ServerFarmId

		# Create deployment slot
		$job = New-AzWebAppSlot -ResourceGroupName $rgname -Name $appname -Slot $slotName -AsJob
		$job | Wait-Job
		$slot = $job | Receive-Job

		$appWithSlotName = "$appname/$slotName"

		# Assert
		Assert-AreEqual $appWithSlotName $slot.Name
		Assert-AreEqual $serverFarm.Id $slot.ServerFarmId

		#Add Routing Rule for $slot
		$rule=Add-AzWebAppTrafficRouting -ResourceGroupName $rgname -WebAppName $appname -RoutingRule @{ActionHostName=$slot.DefaultHostName;ReroutePercentage=$ReroutePercentage;Name=$slotName}
	   
	   # Assert
		Assert-AreEqual $ReroutePercentage $rule.ReroutePercentage
		Assert-AreEqual $slot.DefaultHostName $rule.ActionHostName
		Assert-AreEqual $slotName $rule.Name

		#Update Routing Rule for $slot
		$rule=Update-AzWebAppTrafficRouting -ResourceGroupName $rgname -WebAppName $appname -RoutingRule @{ActionHostName=$slot.DefaultHostName;ReroutePercentage=$updatedReroutePercentage;Name=$slotName}
	    
		# Assert
		Assert-AreEqual $updatedReroutePercentage $rule.ReroutePercentage
		Assert-AreEqual $slot.DefaultHostName $rule.ActionHostName
		Assert-AreEqual $slotName $rule.Name
	}
	finally
	{
		# Cleanup
		Remove-AzResourceGroup -Name $rgname -Force
	}
}