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
Tests CRUD Lifecycle Management for IoT Central Apps.
#>
function Test-IotCentralAppLifecycleManagement{
	# Setup
	$rgname = Get-ResourceGroupName
	$rname = Get-ResourceName
	$subdomain = ($rname) + "subdomain"
	$location = Get-Location "Microsoft.IoTCentral" "IotApps"
	$st2Sku = "ST2"
	$st1Sku = "ST1"
	$displayName = "Custom IoT Central App DisplayName"
	$tagKey = "key1"
	$tagValue = "value1"
	$tags = @{ $tagKey = $tagValue }
	
	try
	{
		# Test

		# Create Resource Group
		New-AzResourceGroup -Name $rgname -Location $location

		# Create App
		$created = New-AzIotCentralApp -ResourceGroupName $rgname -Name $rname -Subdomain $subdomain -Sku $st2Sku -DisplayName $displayName -Tag $tags
		$actual = Get-AzIotCentralApp -ResourceGroupName $rgname -Name $rname

		$list = Get-AzIotCentralApp -ResourceGroupName $rgname
	
		# Assert
		Assert-AreEqual $actual.Name $rname
		Assert-AreEqual $actual.Subdomain $subdomain
		Assert-AreEqual $actual.DisplayName $displayName
		Assert-AreEqual $actual.Tag.Item($tagkey) $tagvalue
		Assert-AreEqual 1 @($list).Count
		Assert-AreEqual $actual.Name $list[0].Name
		Assert-AreEqual $actual.Sku.Name $st2Sku

		# Get App
		$rname1 = $rname
		$rname2 = ($rname1) + "-2"

		New-AzIotCentralApp $rgname $rname2 $rname2
		$list = Get-AzIotCentralApp -ResourceGroupName $rgname
		$app1 = $list | where {$_.Name -eq $rname1} | Select-Object -First 1
		$app2 = $list | where {$_.Name -eq $rname2} | Select-Object -First 1

		# Assert
		Assert-AreEqual 2 @($list).Count
		Assert-AreEqual $rname1 $app1.Name
		Assert-AreEqual $rname2 $app2.Name
		Assert-AreEqual $subdomain $app1.Subdomain
		Assert-AreEqual $rname2 $app2.Subdomain
		Assert-AreEqual $resourceType $app1.Type
		Assert-AreEqual $resourceType $app2.Type

		# Test getting from empty group
		$emptyrg = ($rgname) + "empty"
		New-AzResourceGroup -Name $emptyrg -Location $location
		$listViaDirect = Get-AzIotCentralApp -ResourceGroupName $emptyrg

		# Assert
		Assert-AreEqual 0 @($listViaDirect).Count

		# Update App
		$tt1 = $tagKey
		$tv1 = $tagValue
		$tt2 = "tt2"
		$tv2 = "tv2"
		$displayName = "New Custom Display Name."
		$newSubdomain = $subdomain + "new"
		$tags = $actual.Tag
		$tags.add($tt2, $tv2)
		# Set resource
		$job = Set-AzIotCentralApp -ResourceGroupName $rgname -Name $rname -Tag $tags -DisplayName $displayName -Subdomain $newSubdomain -Sku $st1Sku -AsJob
		$job | Wait-Job
		$result = $job | Receive-Job

		$actual = Get-AzIotCentralApp -ResourceGroupName $rgname -Name $rname

		# Assert
		Assert-AreEqual $actual.Tag.Count 2
		Assert-AreEqual $actual.Tag.Item($tt1) $tv1
		Assert-AreEqual $actual.Tag.Item($tt2) $tv2
		Assert-AreEqual $actual.DisplayName $displayName
		Assert-AreEqual $actual.Subdomain $newSubdomain
		Assert-AreEqual $actual.Name $rname
		Assert-AreEqual $actual.Sku.Name $st1Sku

		# Delete
		# $job = Find-AzResource -ResourceType $resourceType -ResourceGroupNameEquals $rgname | Get-AzIotCentralApp | Remove-AzIotCentralApp -AsJob
		# $job | Wait-Job
		Get-AzIotCentralApp -ResourceGroupName $rgname | Remove-AzIotCentralApp

		$list = Get-AzIotCentralApp -ResourceGroupName $rgname
		Assert-AreEqual 0 @($list).Count
	}
	finally{
		# Clean up
		# Remove-AzResourceGroup -Name $rgname -Force
	}
}