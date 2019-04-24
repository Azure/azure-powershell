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
Tests creating a new Web Hosting Plan.
#>
function Test-CreateNewAppServicePlan
{
	# Setup
	$rgname = Get-ResourceGroupName
	$whpName = Get-WebHostPlanName
	$location = Get-Location
	$capacity = 2
	$skuName = "S2"

	try
	{
		#Setup
		New-AzResourceGroup -Name $rgname -Location $location

		# Test
		$job = New-AzAppServicePlan -ResourceGroupName $rgname -Name  $whpName -Location  $location -Tier "Standard" -WorkerSize Medium -NumberOfWorkers $capacity -AsJob
		$job | Wait-Job
		$createResult = $job | Receive-Job

		# Assert
		Assert-AreEqual $whpName $createResult.Name
		Assert-AreEqual "Standard" $createResult.Sku.Tier
		Assert-AreEqual $skuName $createResult.Sku.Name
		Assert-AreEqual $capacity $createResult.Sku.Capacity

		# Assert

		$getResult = Get-AzAppServicePlan -ResourceGroupName $rgname -Name $whpName
		Assert-AreEqual $whpName $getResult.Name
		Assert-AreEqual "Standard" $getResult.Sku.Tier
		Assert-AreEqual $skuName $getResult.Sku.Name
		Assert-AreEqual $capacity $getResult.Sku.Capacity
	}
	finally
	{
		# Cleanup
		Remove-AzAppServicePlan -ResourceGroupName $rgname -Name  $whpName -Force
		Remove-AzResourceGroup -Name $rgname -Force
	}
}

<#
.SYNOPSIS
Tests creating a new Web Hosting Plan with HyperV container.
#>
function Test-CreateNewAppServicePlanHyperV
{
	# Setup
	$rgname = Get-ResourceGroupName
	$whpName = Get-WebHostPlanName
	$location = Get-Location
    $capacity = 1
	$skuName = "PC2"
    $tier = "PremiumContainer"

	try
	{
		#Setup
		New-AzResourceGroup -Name $rgname -Location $location

		# Test
		$job = New-AzAppServicePlan -ResourceGroupName $rgname -Name  $whpName -Location  $location -Tier $tier -WorkerSize Small -HyperV  -AsJob
		$job | Wait-Job
		$createResult = $job | Receive-Job

		# Assert
		Assert-AreEqual $whpName $createResult.Name
		Assert-AreEqual $tier $createResult.Sku.Tier
		Assert-AreEqual $skuName $createResult.Sku.Name
		Assert-AreEqual $capacity $createResult.Sku.Capacity

		# Assert

		$getResult = Get-AzAppServicePlan -ResourceGroupName $rgname -Name $whpName
		Assert-AreEqual $whpName $getResult.Name
		Assert-AreEqual PremiumContainer $getResult.Sku.Tier
		Assert-AreEqual $skuName $getResult.Sku.Name
		Assert-AreEqual $capacity $getResult.Sku.Capacity
        Assert-AreEqual $true $getResult.IsXenon
        Assert-AreEqual "xenon" $getResult.Kind

	}
	finally
	{
		# Cleanup
		Remove-AzAppServicePlan -ResourceGroupName $rgname -Name  $whpName -Force
		Remove-AzResourceGroup -Name $rgname -Force
	}
}


<#
.SYNOPSIS
Tests creating a new Web Hosting Plan.
#>
function Test-SetAppServicePlan
{
	# Setup
	$rgname = Get-ResourceGroupName
	$whpName = Get-WebHostPlanName
	$location = Get-Location
	$tier = "Shared"
	$skuName ="D1"
	$capacity = 0
	$perSiteScaling = $false;

	$newTier ="PremiumV2"
	$newSkuName = "P2v2"
	$newWorkerSize = "Medium"
	$newCapacity = 2
	$newPerSiteScaling = $true;


	try
	{
		#Setup
		New-AzResourceGroup -Name $rgname -Location $location
		# Test
		$actual = New-AzAppServicePlan -ResourceGroupName $rgname -Name  $whpName -Location  $location -Tier $tier -PerSiteScaling $perSiteScaling
		$result = Get-AzAppServicePlan -ResourceGroupName $rgname -Name  $whpName
		# Assert
		Assert-AreEqual $whpName $result.Name
		Assert-AreEqual $capacity $result.Sku.Capacity
		Assert-AreEqual $tier $result.Sku.Tier
		Assert-AreEqual $skuName $result.Sku.Name
		Assert-AreEqual $perSiteScaling $result.PerSiteScaling

		# Set the created service plan
		$job = Set-AzAppServicePlan  -ResourceGroupName $rgname -Name  $whpName -Tier $newTier -NumberofWorkers $newCapacity -WorkerSize $newWorkerSize -PerSiteScaling $newPerSiteScaling -AsJob
		$job | Wait-Job
		$newresult = $job | Receive-Job

		# Assert
		Assert-AreEqual $whpName $newresult.Name
		Assert-AreEqual $newCapacity $newresult.Sku.Capacity
		Assert-AreEqual $newTier $newresult.Sku.Tier
		Assert-AreEqual $newSkuName $newresult.Sku.Name
		Assert-AreEqual $newPerSiteScaling $newresult.PerSiteScaling

		# Set service plan via pipeline
		$newresult.Sku.Capacity = $capacity
		$newresult.Sku.Tier = $tier
		$newresult.Sku.Name = $skuName
		$newresult.PerSiteScaling = $perSiteScaling

		$newresult | Set-AzAppServicePlan

		#Retrieve service plan
		$newresult = Get-AzAppServicePlan -ResourceGroupName $rgname -Name  $whpName

		# Assert
		Assert-AreEqual $whpName $newresult.Name
		Assert-AreEqual $capacity $newresult.Sku.Capacity
		Assert-AreEqual $tier $newresult.Sku.Tier
		Assert-AreEqual $skuName $newresult.Sku.Name
		Assert-AreEqual $perSiteScaling $newresult.PerSiteScaling

	}
	finally
	{
		# Cleanup
		Remove-AzAppServicePlan -ResourceGroupName $rgname -Name  $whpName -Force
		Remove-AzResourceGroup -Name $rgname -Force
	}
}

<#
.SYNOPSIS
Tests retrieving app service plans	
#>
function Test-GetAppServicePlan
{
	# Setup
	$rgname = Get-ResourceGroupName
	
	$apiversion = "2015-08-01"
	$resourceType = "Microsoft.Web/sites"

	$location1 = Get-Location
	$serverFarmName1 = Get-WebHostPlanName
	$tier1 = "Shared"
	$skuName1 ="D1"
	$capacity1 = 0

	$location2 = Get-SecondaryLocation
	$serverFarmName2 = Get-WebHostPlanName
	$tier2 ="Standard"
	$skuName2 = "S2"
	$workerSize2 = "Medium"
	$capacity2 = 2
	try
	{
		#Setup
		New-AzResourceGroup -Name $rgname -Location $location1
		$serverFarm1 = New-AzAppServicePlan -ResourceGroupName $rgname -Name  $serverFarmName1 -Location  $location1 -Tier $tier1
		
		# Assert
		Assert-AreEqual $serverFarmName1 $serverFarm1.Name
		Assert-AreEqual $capacity1 $serverFarm1.Sku.Capacity
		Assert-AreEqual $tier1 $serverFarm1.Sku.Tier
		Assert-AreEqual $skuName1 $serverFarm1.Sku.Name
		
		# Get app service plan by resource group and name
		$serverFarm1 = Get-AzAppServicePlan -ResourceGroupName $rgname -Name  $serverFarmName1 

		# Assert
		Assert-AreEqual $serverFarmName1 $serverFarm1.Name
		Assert-AreEqual $capacity1 $serverFarm1.Sku.Capacity
		Assert-AreEqual $tier1 $serverFarm1.Sku.Tier
		Assert-AreEqual $skuName1 $serverFarm1.Sku.Name

		# Create second app service plan
		$serverFarm2 = New-AzAppServicePlan -ResourceGroupName $rgname -Name  $serverFarmName2 -Location  $location2 -Tier $tier2 -WorkerSize $workerSize2 -NumberofWorkers $capacity2
		
		# Assert
		Assert-AreEqual $serverFarmName2 $serverFarm2.Name
		Assert-AreEqual $capacity2 $serverFarm2.Sku.Capacity
		Assert-AreEqual $tier2 $serverFarm2.Sku.Tier
		Assert-AreEqual $skuName2 $serverFarm2.Sku.Name
		
		# Get app service plans by name
		$result = Get-AzAppServicePlan -Name $serverFarmName1

		# Assert
		Assert-AreEqual 1 $result.Count
		$serverFarm1 = $result[0]
		Assert-AreEqual $serverFarmName1 $serverFarm1.Name
		Assert-AreEqual $capacity1 $serverFarm1.Sku.Capacity
		Assert-AreEqual $tier1 $serverFarm1.Sku.Tier
		Assert-AreEqual $skuName1 $serverFarm1.Sku.Name

		# Get all app service plans by subscription
		$result = Get-AzAppServicePlan

		# Assert
		Assert-True { $result.Count -ge 2 }

		# Get all app service plans by location
		$result = Get-AzAppServicePlan -Location $location1 | Select -expand Name 
		
		# Assert
		Assert-True { $result -contains $serverFarmName1 }
		Assert-False { $result -contains $serverFarmName2 }

		# Get all app service plans by resource group
		$result = Get-AzAppServicePlan -ResourceGroupName $rgname | Select -expand Name
		
		# Assert
		Assert-AreEqual 2 $result.Count
		Assert-True { $result -contains $serverFarmName1 }
		Assert-True { $result -contains $serverFarmName2 }

	}
	finally
	{
		# Cleanup
		Remove-AzAppServicePlan -ResourceGroupName $rgname -Name  $serverFarmName1 -Force
		Remove-AzAppServicePlan -ResourceGroupName $rgname -Name  $serverFarmName2 -Force
		Remove-AzResourceGroup -Name $rgname -Force
	}
}

<#
.SYNOPSIS
Tests removing an app service plan
#>
function Test-RemoveAppServicePlan
{
	# Setup
	$rgname = Get-ResourceGroupName
	$serverFarmName = Get-WebHostPlanName
	$location = Get-Location
	$capacity = 0
	$skuName = "D1"
	$tier = "Shared"

	try
	{
		#Setup
		New-AzResourceGroup -Name $rgname -Location $location

		$serverFarm = New-AzAppServicePlan -ResourceGroupName $rgname -Name  $serverFarmName -Location  $location -Tier $tier
		
		# Assert
		Assert-AreEqual $serverFarmName $serverFarm.Name
		Assert-AreEqual $tier $serverFarm.Sku.Tier
		Assert-AreEqual $skuName $serverFarm.Sku.Name
		Assert-AreEqual $capacity $serverFarm.Sku.Capacity

		# Remove App service plan
		$serverFarm |Remove-AzAppServicePlan -Force -AsJob | Wait-Job
		
		$result = Get-AzAppServicePlan -ResourceGroupName $rgname

		Assert-AreEqual 0 $result.Count 
	}
	finally
	{
		# Cleanup
		Remove-AzResourceGroup -Name $rgname -Force
	}
}

<#
.SYNOPSIS
Tests creating a new Web Hosting Plan.
#>
function Test-CreateNewAppServicePlanInAse
{
	# Setup
	$rgname = Get-ResourceGroupName
	$whpName = Get-WebHostPlanName
	$location = "West US"
	$capacity = 1
	$skuName = "I1"
	$skuTier = "Isolated"
	$aseName = "asedemops"
	$aseResourceGroupName = "asedemorg"

	try
	{
		#Setup
		New-AzResourceGroup -Name $rgname -Location $location

		# Test
		$createResult = New-AzAppServicePlan -ResourceGroupName $rgname -Name  $whpName -Location  $location -Tier $skuTier -WorkerSize Medium -NumberOfWorkers $capacity -AseName $aseName -AseResourceGroupName $aseResourceGroupName
		
		# Assert
		Assert-AreEqual $whpName $createResult.Name
		Assert-AreEqual "Isolated" $createResult.Sku.Tier
		Assert-AreEqual $skuName $createResult.Sku.Name

		# Assert
		$getResult = Get-AzAppServicePlan -ResourceGroupName $rgname -Name $whpName
		Assert-AreEqual $whpName $getResult.Name
		Assert-AreEqual "Isolated" $getResult.Sku.Tier
		Assert-AreEqual $skuName $getResult.Sku.Name
	}
	finally
	{
		# Cleanup
		Remove-AzAppServicePlan -ResourceGroupName $rgname -Name  $whpName -Force
		Remove-AzResourceGroup -Name $rgname -Force
	}
}