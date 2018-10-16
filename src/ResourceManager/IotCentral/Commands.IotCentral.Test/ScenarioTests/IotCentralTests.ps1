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


#################################
## IotCentral Cmdlets			   ##
#################################

$global:resourceType = "Microsoft.IoTCentral/IotApps"

<#
.SYNOPSIS
Tests creating Resource Group and Iot Central App
.DESCRIPTION
Smoke[Broken]Test
#>
function Test-CreateSimpleIotCentralApp{
		# Setup
	$rgname = Get-ResourceGroupName
	$rname = Get-ResourceName
	$location = "westus" # Get-Location "Microsoft.IoTCentral" "IotApps" 
	try
	{
		# Test

		# Create Resource Group
		New-AzureRmResourceGroup -Name $rgname -Location $location

		# Create App
		New-AzureRmIotCentralApp -ResourceGroupName $rgname -Name $rname -Subdomain $rname
		$actual = Get-AzureRmIotCentralApp -ResourceGroupName $rgname -Name $rname

		$list = Get-AzureRmIotCentralApp -ResourceGroupName $rgname
	
		# Assert

		# Name
		Assert-AreEqual $actual.Name $rname
		Assert-AreEqual $expected.ResourceGroupName $actual.ResourceGroupName
		Assert-AreEqual $actual.Subdomain $rname
		Assert-AreEqual $actual.Type $resourceType
		Assert-AreEqual 1 @($list).Count
		Assert-AreEqual $actual.Name $list[0].Name
	}
	finally{
		# Clean up
		Clean-ResourceGroup $rgname
	}
}


function Test-CreateComplexIotCentralApp{
	# Setup
	$rgname = Get-ResourceGroupName
	$rname = Get-ResourceName
	$subdomain = ($rname) + "subdomain"
	$location = Get-Location "Microsoft.IoTCentral" "IotApps"
	$sku = "S1"
	$displayName = "Custom IoT Central App DisplayName"
	$tagKey = "key1"
	$tagValue = "value1"
	$tags = @{ $tagKey = $tagValue }
	
	try
	{
		# Test

		# Create Resource Group
		New-AzureRmResourceGroup -Name $rgname -Location $rglocation

		# Create App
		$job = New-AzureRmIotCentralApp -ResourceGroupName $rgname -Name $rname -Subdomain $subdomain -Sku $sku -DisplayName $displayName -Tag $tags -AsJob
		$job | Wait-Job
		$actual = Get-AzureRmIotCentralApp -ResourceGroupName $rgname -Name $rname

		$list = Get-AzureRmIotCentralApp -ResourceGroupName $rgname
	
		# Assert

		# Name
		Assert-AreEqual $actual.Name $rname
		Assert-AreEqual $expected.ResourceGroupName $actual.ResourceGroupName
		Assert-AreEqual $actual.Subdomain $subdomain
		Assert-AreEqual $actual.Sku $sku
		Assert-AreEqual $actual.DisplayName $displayName
		Assert-AreEqual $actual.Tag.Item($tagkey) $tagvalue
		Assert-AreEqual $actual.ResourceType $resourceType
		Assert-AreEqual 1 @($list).Count
		Assert-AreEqual $actual.Name $list[0].Name
	}
	finally{
		# Clean up
		Clean_ResourceGroup $rgname
	}
}

<#
.SYNOPSIS
Tests get resources via piping from resource group
.DESCRIPTION
Smoke[Broken]Test
#>
function Test-GetIotCentralAppsViaPiping
{

	# Setup
	$rgname = Get-ResourceGroupName
	$rname1 = Get-ResourceName
	$rname2 = ($rname1) + "-2"
	$location = "westus"

	# Test
	try{
		New-AzureRmResourceGroup -Name $rgname -Location $location
		New-AzureRmIotCentralApp $rgname $rname1 $rname1
		New-AzureRmIotCentralApp $rgname $rname2 $rname2

		$list = Get-AzureRmResourceGroup $rgname | Get-AzureRmIotCentralApp

		$app1 = $list | where {$_.Name -eq $rname1} | Select-Object -First 1
		$app2 = $list | where {$_.Name -eq $rname2} | Select-Object -First 1
		# Assert
		Assert-AreEqual 2 @($list).Count
		Assert-AreEqual $rname1 $app1.Name
		Assert-AreEqual $rname2 $app2.Name
		Assert-AreEqual $rname1 $app1.Subdomain
		Assert-AreEqual $rname2 $app2.Subdomain
		Assert-AreEqual $resourceType $app1.Type
		Assert-AreEqual $resourceType $app2.Type
	}finally{
		# Clean up
		Clean_ResourceGroup $rgname
	}
}

function Test-GetIotCentralAppsViaResourceIdPiping
{

	# Setup
	$rgname = Get-ResourceGroupName
	$rname1 = Get-ResourceName
	$rname2 = ($rname1) + "-2"
	$location = "westus"

	# Test
	try{
		New-AzureRmResourceGroup -Name $rgname -Location $location
		New-AzureRmIotCentralApp $rgname $rname1 $rname1
		New-AzureRmIotCentralApp $rgname $rname2 $rname2

		$list = Find-AzureRmResource -ResourceType $resourceType -ResourceGroupNameEquals $rgname | Get-AzureRmIotCentralApp

		$app1 = $list | where {$_.Name -eq $rname1} | Select-Object -First 1
		$app2 = $list | where {$_.Name -eq $rname2} | Select-Object -First 1
		# Assert
		Assert-AreEqual 2 @($list).Count
		Assert-AreEqual $rname1 $app1.Name
		Assert-AreEqual $rname2 $app2.Name
		Assert-AreEqual $rname1 $app1.Subdomain
		Assert-AreEqual $rname2 $app2.Subdomain
		Assert-AreEqual $resourceType $app1.Type
		Assert-AreEqual $resourceType $app2.Type
	}finally{
		# Clean up
		Clean_ResourceGroup $rgname
	}
}

<#
.SYNOPSIS
Nagative test. Get resources from an empty group.
#>
function Test-GetIotCentralAppsFromEmptyGroup
{
	# Setup
	$rgname = Get-ResourceGroupName
	$location = "westus"

	try{
		# Test
		New-AzureRmResourceGroup -Name $rgname -Location $location
		$listViaPiping = Get-AzureRmResourceGroup -Name $rgname | Get-AzureRmIotCentralApp
		$listViaDirect = Get-AzureRmIotCentralApp -ResourceGroupName $rgname

		# Assert
		Assert-AreEqual 0 @($listViaPiping).Count
		Assert-AreEqual 0 @($listViaDirect).Count
	}finally{
		Clean_ResourceGroup $rgname
	}
}

<#
.SYNOPSIS
Tests setting a resource.
.DESCRIPTION
SmokeTest
#>
function Test-SetIotCentralAppMetadata
{
	# Setup
	$rgname = Get-ResourceGroupName
	$rname = Get-ResourceName
	$displayName = "Fancy, Custom Display Name."
	$location = "westus"
	$tt1 = "tt1"
	$tv1 = "tv1"
	$tt2 = "tt2"
	$tv2 = "tv2"

	try
	{
		# Test
		New-AzureRmResourceGroup -Name $rgname -Location $location
		$iotCentralApp = New-AzureRmIotCentralApp -Name $rname -Tag @{$tt1 = $tv1} -ResourceGroupName $rgname -Subdomain $rname

		$tags = $iotCentralApp.Tags
		$tags.add($tt2, $tv2)
		# Set resource
		$job = Set-AzureRmIotCentralApp -ResourceGroupName $rgname -Name $rname -Tag $tags -DisplayName $displayName -AsJob
		$job | Wait-Job
		$result = $job | Receive-Job

		$job = Get-AzureRmIotCentralApp -ResourceGroupName $rgname -Name $rname
		$job | Wait-Job
		$actual = $job | Receive-Job

		# Assert
		Assert-AreEqual $actual.Tags.Count 2
		Assert-AreEqual $actual.Tags.Item($tt1) $tv1
		Assert-AreEqual $actual.Tags.Item($tt2) $tv2
		Assert-AreEqual $actual.DisplayName $displayName
		Assert-AreEqual $actual.Subdomain $rname
		Assert-AreEqual $actual.Name $rname
    }
	finally
	{
		Clean-ResourceGroup $rgname
	}
}

<#
.SYNOPSIS
Tests creating Resource Group and Iot Central App
.DESCRIPTION
Smoke[Broken]Test
#>
function Test-RemoveIotCentralApp{
		# Setup
	$rgname = Get-ResourceGroupName
	$rname = Get-ResourceName
	$location = "westus" # Get-Location "Microsoft.IoTCentral" "IotApps" 
	try
	{
		# Test

		# Create Resource Group
		New-AzureRmResourceGroup -Name $rgname -Location $location

		# Create App
		New-AzureRmIotCentralApp -ResourceGroupName $rgname -Name $rname -Subdomain $rname
		$actual = Get-AzureRmIotCentralApp -ResourceGroupName $rgname -Name $rname

		$list = Get-AzureRmIotCentralApp -ResourceGroupName $rgname
	
		# Assert

		# Name
		Assert-AreEqual $actual.Name $rname
		Assert-AreEqual $expected.ResourceGroupName $actual.ResourceGroupName
		Assert-AreEqual $actual.Subdomain $rname
		Assert-AreEqual $actual.Type $resourceType
		Assert-AreEqual 1 @($list).Count
		Assert-AreEqual $actual.Name $list[0].Name

		# Remove
		$job = Remove-AzureRmIotCentralApp -ResourceGroupName $rgname -Name $rname -AsJob
		$job | Wait-Job

		$list = Get-AzureRmIotCentralApp
		Assert-AreEqual 0 @($list).Count
	}
	finally{
		# Clean up
		Clean-ResourceGroup $rgname
	}
}
