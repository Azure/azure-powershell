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
## HealthcareApis Cmdlet
#################################

$global:resourceType = "Microsoft.HealthcareApis/services"

<#
.SYNOPSIS
Tests CRUD Operations for HealthcareApis Fhir Service.
#>
function Test-AzRmHealthcareApisService{
	# Setup
	$rgname = Get-ResourceGroupName
	$rname = Get-ResourceName
	$location = Get-Location
	$offerThroughput =  Get-OfferThroughput
	$kind = Get-Kind
	$object_id = Get-AccessPolicyObjectID;
	
	try
	{
		# Test
		# Create Resource Group
		New-AzResourceGroup -Name $rgname -Location $location

	# Create App
		
		$created = New-AzHealthcareApisService -Name $rname -ResourceGroupName  $rgname -Location $location -Kind $kind -AccessPolicyObjectId $object_id -CosmosOfferThroughput $offerThroughput;
	
	    $actual = Get-AzHealthcareApisService -ResourceGroupName $rgname -Name $rname

		# Assert
		Assert-AreEqual $actual.Name $rname
		Assert-AreEqual $actual.CosmosDbOfferThroughput $offerThroughput
		Assert-AreEqual $actual.Kind $kind
		#Update using parameters
		$newOfferThroughput = $offerThroughput - 600
		$updated = Set-AzHealthcareApisService -ResourceId $actual.Id -CosmosOfferThroughput $newOfferThroughput;

		$updatedAccount = Get-AzHealthcareApisService -ResourceGroupName $rgname -Name $rname
		# Assert the update
		Assert-AreEqual $updatedAccount.Name $rname
		Assert-AreEqual $updatedAccount.CosmosDbOfferThroughput $newOfferThroughput

		$rname1 = $rname + "1"
		$created1 = New-AzHealthcareApisService -Name $rname1 -ResourceGroupName  $rgname -Location $location -AccessPolicyObjectId $object_id -CosmosOfferThroughput $offerThroughput;
		
		$actual1 = Get-AzHealthcareApisService -ResourceGroupName $rgname -Name $rname1

		# Assert
		Assert-AreEqual $actual1.Name $rname1
		Assert-AreEqual $actual1.CosmosDbOfferThroughput $offerThroughput

		$list = Get-AzHealthcareApisService -ResourceGroupName $rgname

		$app1 = $list | where {$_.Name -eq $rname} | Select-Object -First 1
		$app2 = $list | where {$_.Name -eq $rname1} | Select-Object -First 1

		Assert-AreEqual 2 @($list).Count
		Assert-AreEqual $rname $app1.Name
		Assert-AreEqual $rname1 $app2.Name

		$list | Remove-AzHealthcareApisService

		$list = Get-AzHealthcareApisService -ResourceGroupName $rgname
		
		Assert-AreEqual 0 @($list).Count
	}
	finally{
		# Clean up
		Remove-AzResourceGroup -Name $rgname -Force
	}
}