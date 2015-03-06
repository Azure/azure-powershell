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
function Test-CreatesNewSimpleWebsite
{
	# Setup
	$rgname = Get-ResourceGroupName
	$wname = Get-WebsiteName
	$location = Get-Location
	$whpName = Get-WebHostPlanName
	$apiversion = "2014-04-01"
	$resourceType = "Microsoft.Web/sites"
	try
	{
		#Setup
		New-AzureResourceGroup -Name $rgname -Location $location
		New-AzureWebHostingPlan -ResourceGroupName $rgname -WebHostingPlanName  $whpName -location  $location

		# Test
		$actual = New-AzureWebsite -ResourceGroupName $rgname -WebsiteName $wname -Location $location -WebHostingPlan $whpName 
		$result = Get-AzureWebsite -ResourceGroupName $rgname -WebsiteName $wname

		# Assert
		Assert-AreEqual $wname $result.Name
		Assert-AreEqual $whpName $result.Properties.ServerFarm
	}
    finally
	{
		# Cleanup
		Remove-AzureWebsite -ResourceGroupName $rgname -WebsiteName $wname -Force
		Remove-AzureWebHostingPlan -ResourceGroupName $rgname -WebHostingPlanName  $whpName -Force
		Remove-AzureResourceGroup -Name $rgname -Force
    }
}

<#
.SYNOPSIS
Tests creating a new Web Hosting Plan.
#>
function Test-CreatesNewWebHostingPlan
{
	# Setup
	$rgname = Get-ResourceGroupName
	$whpName = Get-WebHostPlanName
	$location = Get-Location

	try
	{
		#Setup
		New-AzureResourceGroup -Name $rgname -Location $location
		# Test
		$actual = New-AzureWebHostingPlan -ResourceGroupName $rgname -WebHostingPlanName  $whpName -location  $location 
		$result = Get-AzureWebHostingPlan -ResourceGroupName $rgname -WebHostingPlanName  $whpName
		# Assert
		Assert-AreEqual $whpName $result.WebHostingPlan.Name
		Assert-AreEqual 1 $result.WebHostingPlan.Properties.NumberOfWorkers
		Assert-AreEqual "Standard" $result.WebHostingPlan.Properties.Sku
		Assert-AreEqual "Small" $result.WebHostingPlan.Properties.WorkerSize
	}
    finally
    {
		# Cleanup
		Remove-AzureWebHostingPlan -ResourceGroupName $rgname -WebHostingPlanName  $whpName -Force
		Remove-AzureResourceGroup -Name $rgname -Force
    }
}