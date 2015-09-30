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
Tests creating a new website.
#>
function Test-CreatesNewSimpleWebApp
{
	# Setup
	$rgname = Get-ResourceGroupName
	$wname = Get-WebsiteName
	$location = Get-Location
	$whpName = Get-WebHostPlanName
	$apiversion = "2014-04-01"
	$resourceType = "Microsoft.Web/sites"
	$slotName = $wname + "(Dev)" 
	try
	{
		#Setup
		New-AzureRmResourceGroup -Name $rgname -Location $location
		New-AzureRmAppServicePlan -ResourceGroupName $rgname -Name  $whpName -Location  $location

		# Test
		$actual = New-AzureRmWebApp -ResourceGroupName $rgname -Name $wname -Location $location -AppServicePlan $whpName 
		$result = Get-AzureRmWebApp -ResourceGroupName $rgname -Name $wname
		$slotCreate = New-AzureRmWebApp -ResourceGroupName $rgname -Name $wname -Location $location -AppServicePlan $whpName -SlotName Dev


		# Assert
		Assert-AreEqual $wname $result.Name
		Assert-AreEqual $whpName $result.Properties.ServerFarm
		Assert-AreEqual $slotName $slotCreate.Name
	}
    finally
	{
		# Cleanup
		Remove-AzureRmWebApp -ResourceGroupName $rgname -Name $wname -Force
		Remove-AzureRmAppServicePlan -ResourceGroupName $rgname -Name  $whpName -Force
		Remove-AzureRmResourceGroup -Name $rgname -Force
    }
}

<#
.SYNOPSIS
Tests creating a new Web Hosting Plan.
#>
function Test-CreatesNewAppServicePlan
{
	# Setup
	$rgname = Get-ResourceGroupName
	$whpName = Get-WebHostPlanName
	$location = Get-Location

	try
	{
		#Setup
		New-AzureRmResourceGroup -Name $rgname -Location $location
		# Test
		$actual = New-AzureRmAppServicePlan -ResourceGroupName $rgname -Name  $whpName -Location  $location 
		$result = Get-AzureRmAppServicePlan -ResourceGroupName $rgname -Name  $whpName
		# Assert
		Assert-AreEqual $whpName $result.WebHostingPlan.Name
		Assert-AreEqual 1 $result.WebHostingPlan.Properties.NumberOfWorkers
		Assert-AreEqual "Standard" $result.WebHostingPlan.Properties.Sku
		Assert-AreEqual "Small" $result.WebHostingPlan.Properties.WorkerSize
	}
    finally
    {
		# Cleanup
		Remove-AzureRmAppServicePlan -ResourceGroupName $rgname -Name  $whpName -Force
		Remove-AzureRmResourceGroup -Name $rgname -Force
    }
}

<#
.SYNOPSIS
Tests creating a new Web Hosting Plan.
#>
function Test-SetNewAppServicePlan
{
	# Setup
	$rgname = Get-ResourceGroupName
	$whpName = Get-WebHostPlanName
	$location = Get-Location

	try
	{
		#Setup
		New-AzureRmResourceGroup -Name $rgname -Location $location
		# Test
		$actual = New-AzureRmAppServicePlan -ResourceGroupName $rgname -Name  $whpName -Location  $location 
		$result = Get-AzureRmAppServicePlan -ResourceGroupName $rgname -Name  $whpName
		# Assert
		Assert-AreEqual $whpName $result.WebHostingPlan.Name
		Assert-AreEqual 1 $result.WebHostingPlan.Properties.NumberOfWorkers
		Assert-AreEqual "Standard" $result.WebHostingPlan.Properties.Sku
		Assert-AreEqual "Small" $result.WebHostingPlan.Properties.WorkerSize

		# Test setting the created service plan
		$newresult = Set-AzureRmAppServicePlan  -ResourceGroupName $rgname -Name  $whpName -Location  $location -Sku Premium -NumberofWorkers 12 -WorkerSize Medium
		# due to a bug Set and New are not returning the appropriate object so need to get.
		$newresult = Get-AzureRmAppServicePlan -ResourceGroupName $rgname -Name  $whpName

		# Assert
		Assert-AreEqual $whpName $result.WebHostingPlan.Name
		Assert-AreEqual 12 $newresult.WebHostingPlan.Properties.NumberOfWorkers
		Assert-AreEqual "Premium" $newresult.WebHostingPlan.Properties.Sku
		Assert-AreEqual "Medium" $newresult.WebHostingPlan.Properties.WorkerSize
	}
    finally
    {
		# Cleanup
		Remove-AzureRmAppServicePlan -ResourceGroupName $rgname -Name  $whpName -Force
		Remove-AzureRmResourceGroup -Name $rgname -Force
    }
}