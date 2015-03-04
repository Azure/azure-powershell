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
	$rgname = "Default-Web-WestUS"
	$wname = "ngoliPSWebsite"
	$location = "West US"
	$webHostingPlan = "NGoliStandard"
	$apiversion = "2014-04-01"
	$resourceType = "Microsoft.Web/sites"
	try
	{
			# Test
			$actual = New-AzureWebsite -ResourceGroupName $rgname -WebsiteName $wname -Location $location -WebHostingPlan $webHostingPlan 
			$result = Get-AzureWebsite -ResourceGroupName $rgname -WebsiteName $wname 

			# Assert 
			Assert-AreEqual $wname $result.Properties.RepositorySiteName
			Assert-AreEqual $webHostingPlan $result.Properties.ServerFarm
	}
    finally
    {
			# Cleanup
			#Clean-Website($rgname,$wname)
			Remove-AzureWebsite -ResourceGroupName $rgname -WebsiteName $wname -Force
    }
}

<#
.SYNOPSIS
Tests creating a new Web Hosting Plan.
#>
function Test-CreatesNewWebHostingPlan
{
	# Setup
	$rgname = "Default-Web-WestUS"
	$whpName = "ngoliPSWHP"
	$location = "West US"
	try
	{
			# Test
			$actual = New-AzureWebHostingPlan -ResourceGroupName $rgname -WHPName $whpName -location  $location 
			$result = Get-AzureWebHostingPlan -ResourceGroupName $rgname -WHPName $whpName
			# Assert 
			Assert-AreEqual $whpName $result.WebHostingPlan.Name
			Assert-AreEqual 1 $result.WebHostingPlan.Properties.NumberOfWorkers
			Assert-AreEqual "Standard" $result.WebHostingPlan.Properties.Sku
			Assert-AreEqual "Small" $result.WebHostingPlan.Properties.WorkerSize
	}
    finally
    {
			# Cleanup
			Remove-AzureWebHostingPlan -ResourceGroupName $rgname -WHPName $whpName -Force
    }
}