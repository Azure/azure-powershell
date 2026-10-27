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
	$tag= @{"TagKey" = "TagValue"}
	try
	{
		#Setup
		New-AzResourceGroup -Name $rgname -Location $location

		# Test
		$job = New-AzAppServicePlan -ResourceGroupName $rgname -Name  $whpName -Location  $location -Tier "Standard" -WorkerSize Medium -NumberOfWorkers $capacity -Tag $tag -AsJob
		$job | Wait-Job
		$createResult = $job | Receive-Job

		# Assert
		Assert-AreEqual $whpName $createResult.Name
		Assert-AreEqual "Standard" $createResult.Sku.Tier
		Assert-AreEqual $skuName $createResult.Sku.Name
		Assert-AreEqual $capacity $createResult.Sku.Capacity
		Assert-AreEqual $tag.Keys $createResult.Tags.Keys
        Assert-AreEqual $tag.Values $createResult.Tags.Values
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
	$location = "East US 2"
    $capacity = 1
	$skuName = "P1V3"
    $tier = "PremiumV3"

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
		Assert-AreEqual PremiumV3 $getResult.Sku.Tier
		Assert-AreEqual $skuName $getResult.Sku.Name
		Assert-AreEqual $capacity $getResult.Sku.Capacity
        Assert-AreEqual $true $getResult.IsXenon
        Assert-AreEqual "windows" $getResult.Kind

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
Tests creating a new Web Hosting Plan with Linux
#>
function Test-CreateNewAppServicePlanLinux
{
	# Setup
	$rgname = Get-ResourceGroupName
	$whpName = Get-WebHostPlanName
	$location = Get-Location
    $capacity = 1
	$skuName = "B1"
    $tier = "Basic"

	try
	{
		#Setup
		New-AzResourceGroup -Name $rgname -Location $location

		# Test
		$job = New-AzAppServicePlan -ResourceGroupName $rgname -Name  $whpName -Location  $location -Tier $tier -WorkerSize Small -Linux  -AsJob
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
		Assert-AreEqual $tier $getResult.Sku.Tier
		Assert-AreEqual $skuName $getResult.Sku.Name
		Assert-AreEqual $capacity $getResult.Sku.Capacity
        Assert-AreEqual $true $getResult.Reserved
        Assert-AreEqual "Linux" $getResult.Kind

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
Tests asynchronous scaling when creating and updating an App Service plan.
#>
function Test-AppServicePlanAsyncScaling
{
	$rgname = Get-ResourceGroupName
	$location = "canadacentral"
	$parameters = @{
		ResourceGroupName = $rgname
		Name = Get-WebHostPlanName
		ErrorAction = "Stop"
	}

	New-AzResourceGroup -Name $rgname -Location $location -ErrorAction Stop | Out-Null
	try
	{
		$plan = New-AzAppServicePlan @parameters -Location $location -Tier Standard -WorkerSize Small -AsyncScalingEnabled $true
		Assert-AreEqual $true $plan.AsyncScalingEnabled

		$plan = Set-AzAppServicePlan @parameters -NumberofWorkers 2
		Assert-AreEqual $true $plan.AsyncScalingEnabled
		Assert-AreEqual 2 $plan.Sku.Capacity

		$plan = Set-AzAppServicePlan @parameters -AsyncScalingEnabled $false
		Assert-AreEqual $false $plan.AsyncScalingEnabled

		$plan = $plan | Set-AzAppServicePlan -AsyncScalingEnabled $true -ErrorAction Stop
		Assert-AreEqual $true $plan.AsyncScalingEnabled

		$plan = $plan | Set-AzAppServicePlan -ErrorAction Stop
		Assert-AreEqual $true $plan.AsyncScalingEnabled
		Assert-AreEqual $true (Get-AzAppServicePlan @parameters).AsyncScalingEnabled
	}
	finally
	{
		Remove-AzResourceGroup -Name $rgname -Force
	}
}

<#
.SYNOPSIS
Tests creating and updating a Managed Instance App Service plan.
#>
function Test-AppServicePlanManagedInstance
{
	$rgname = getAssetName -prefix "azps-mi-$([Guid]::NewGuid().ToString('N'))"
	$whpName = Get-WebHostPlanName
	$location = "westcentralus"
	$parameters = @{
		ResourceGroupName = $rgname
		Name = $whpName
	}

	Assert-ThrowsContains { New-AzAppServicePlan @parameters -Location $location -ManagedInstance -Linux -ErrorAction Stop } "Managed Instance plans do not support Linux or Windows containers."
	Assert-ThrowsContains { New-AzAppServicePlan @parameters -Location $location -ManagedInstance -HyperV -ErrorAction Stop } "Managed Instance plans do not support Linux or Windows containers."
	Assert-ThrowsContains { New-AzAppServicePlan @parameters -Location $location -ManagedInstance -PerSiteScaling $true -ErrorAction Stop } "Managed Instance plans do not support per-site scaling."

	New-AzResourceGroup -Name $rgname -Location $location -ErrorAction Stop
	try
	{
		$delegation = New-AzDelegation -Name "appservice" -ServiceName "Microsoft.Web/serverFarms"
		$subnet = New-AzVirtualNetworkSubnetConfig -Name "managedinstance" -AddressPrefix "10.0.0.0/24" -Delegation $delegation
		$vnet = New-AzVirtualNetwork -ResourceGroupName $rgname -Name $whpName -Location $location -AddressPrefix "10.0.0.0/16" -Subnet $subnet
		$plan = New-AzAppServicePlan @parameters -Location $location -Tier PremiumV4 -WorkerSize ExtraSmall -ManagedInstance -AssignIdentity $true -DefaultIdentity "[system]" -RdpEnabled $true -VirtualNetworkSubnetId $vnet.Subnets[0].Id
		Assert-AreEqual $whpName $plan.Name
		Assert-AreEqual $true $plan.IsCustomMode

		$result = Set-AzAppServicePlan @parameters -Tag @{ "TagKey" = "TagValue" }
		Assert-AreEqual $true $result.RdpEnabled
		Assert-AreEqual "SystemAssigned" $result.Identity.Type
		Assert-AreEqual $plan.Identity.PrincipalId $result.Identity.PrincipalId
		Assert-AreEqual "SystemAssigned" $result.PlanDefaultIdentity.IdentityType
		Assert-AreEqual $vnet.Subnets[0].Id $result.Network.VirtualNetworkSubnetId
		Assert-AreEqual "TagValue" $result.Tags["TagKey"]

		$result | Set-AzAppServicePlan -AssignIdentity $false -DefaultIdentity "" -RdpEnabled $false
		$result = Get-AzAppServicePlan @parameters
		Assert-AreEqual $true $result.IsCustomMode
		Assert-AreEqual $false $result.RdpEnabled
		Assert-AreEqual $false $result.PerSiteScaling
		Assert-Null $result.Identity
		Assert-Null $result.PlanDefaultIdentity
	}
	finally
	{
		Remove-AzResourceGroup -Name $rgname -Force
	}
}

function Invoke-ManagedInstanceAppServicePlanTest
{
	param([scriptblock] $Test)

	$rgname = getAssetName -prefix "azps-mi-$([Guid]::NewGuid().ToString('N'))"
	$location = "westcentralus"
	$parameters = @{ ResourceGroupName = $rgname; Name = Get-WebHostPlanName }
	New-AzResourceGroup -Name $rgname -Location $location -ErrorAction Stop
	try
	{
		$delegation = New-AzDelegation -Name "appservice" -ServiceName "Microsoft.Web/serverFarms"
		$subnet = New-AzVirtualNetworkSubnetConfig -Name "managedinstance" -AddressPrefix "10.0.0.0/24" -Delegation $delegation
		$vnet = New-AzVirtualNetwork -ResourceGroupName $rgname -Name $parameters.Name -Location $location -AddressPrefix "10.0.0.0/16" -Subnet $subnet -ErrorAction Stop
		$plan = New-AzAppServicePlan @parameters -Location $location -Tier PremiumV4 -WorkerSize ExtraSmall -ManagedInstance -RdpEnabled $true -VirtualNetworkSubnetId $vnet.Subnets[0].Id -ErrorAction Stop
		New-AzWebApp -ResourceGroupName $rgname -Name $rgname -Location $location -AppServicePlan $plan.Name -ErrorAction Stop
		for ($attempt = 0; $attempt -lt 120; $attempt++)
		{
			$instances = @(Get-AzAppServicePlanManagedInstance @parameters -ErrorAction Stop)
			if ($instances.Count -gt 0 -and $instances[0].Status -eq "Ready") { break }
			Wait-Seconds 10
		}
		Assert-True { $instances.Count -gt 0 -and $instances[0].Status -eq "Ready" } "Managed Instance workers did not become ready after 120 polls."
		& $Test $plan $parameters
	}
	finally
	{
		Remove-AzResourceGroup -Name $rgname -Force -ErrorAction Stop
	}
}

<#
.SYNOPSIS
Tests retrieving Managed Instance workers.
#>
function Test-GetAppServicePlanManagedInstance
{
	Invoke-ManagedInstanceAppServicePlanTest {
		param($plan, $parameters)

		$instances = @(Get-AzAppServicePlanManagedInstance @parameters)
		Assert-True { $instances.Count -gt 0 -and $instances[0] -is [Microsoft.Azure.Management.WebSites.Models.ServerFarmInstance] }
		Assert-AreEqual "Ready" $instances[0].Status
		$instanceName = $instances[0].InstanceName
		Assert-AreEqual $instanceName ($plan | Get-AzAppServicePlanManagedInstance -InstanceName $instanceName.ToUpperInvariant()).InstanceName

		$failure = try { Get-AzAppServicePlanManagedInstance @parameters -InstanceName "MissingWorker" -ErrorAction Continue } catch { $_ }
		Assert-True { $failure -is [System.Management.Automation.ErrorRecord] -and $failure.FullyQualifiedErrorId -like "AppServicePlanManagedInstanceNotFound,*" }
		Assert-AreEqual "ObjectNotFound" $failure.CategoryInfo.Category
		Assert-AreEqual "MissingWorker" $failure.TargetObject
	}
}

<#
.SYNOPSIS
Tests retrieving Managed Instance RDP credentials.
#>
function Test-GetAppServicePlanRdpCredential
{
	Invoke-ManagedInstanceAppServicePlanTest {
		param($plan, $parameters)

		$credential = $plan | Get-AzAppServicePlanRdpCredential
		Assert-True { $credential -is [System.Management.Automation.PSCredential] -and $credential.Password -is [System.Security.SecureString] }
		Assert-True { $credential.Password.Length -gt 0 }
		Assert-AreEqual "Administrator" $credential.UserName

		$emitted = @()
		$failure = try { Get-AzAppServicePlanRdpCredential -ResourceGroupName $parameters.ResourceGroupName -Name "$($plan.Name)-missing" -ErrorAction Stop -OutVariable emitted } catch { $_ }
		Assert-AreEqual 0 $emitted.Count
		Assert-True { $failure -is [System.Management.Automation.ErrorRecord] -and $failure.Exception.Message -like "*NotFound*" }
	}
}

<#
.SYNOPSIS
Tests restarting a Managed Instance worker.
#>
function Test-RestartAppServicePlanManagedInstance
{
	Invoke-ManagedInstanceAppServicePlanTest {
		param($plan, $parameters)

		$instanceName = (Get-AzAppServicePlanManagedInstance @parameters)[0].InstanceName
		Assert-AreEqual 0 @(Restart-AzAppServicePlanManagedInstance @parameters -InstanceName $instanceName -WhatIf -PassThru -ErrorAction Stop).Count
		Assert-AreEqual 0 @($plan | Restart-AzAppServicePlanManagedInstance -InstanceName $instanceName -WhatIf -PassThru -ErrorAction Stop).Count

		$emitted = @()
		$failure = try { Restart-AzAppServicePlanManagedInstance -ResourceGroupName $parameters.ResourceGroupName -Name "$($plan.Name)-missing" -InstanceName $instanceName -PassThru -Confirm:$false -ErrorAction Stop -OutVariable emitted } catch { $_ }
		Assert-AreEqual 0 $emitted.Count
		Assert-True { $failure -is [System.Management.Automation.ErrorRecord] -and $failure.Exception.Message -like "*NotFound*" }

		$result = @($plan | Restart-AzAppServicePlanManagedInstance -InstanceName $instanceName -PassThru -Confirm:$false -ErrorAction Stop)
		Assert-True { $result.Count -eq 1 -and $result[0] -is [bool] -and $result[0] }
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
	$tag= @{"TagKey" = "TagValue"}

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

		#Set Tags
		$tagsResult= Set-AzAppServicePlan  -ResourceGroupName $rgname -Name $whpName -Tag $tag
		# Assert
		Assert-AreEqual $tag.Keys $tagsResult.Tags.Keys
		Assert-AreEqual $tag.Values $tagsResult.Tags.Values
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