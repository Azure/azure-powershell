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
	$storageAccountName = "exportStorage"
	
	try
	{
		# Test
		# Create Resource Group
		New-AzResourceGroup -Name $rgname -Location $location

		# Create App
		$created = New-AzHealthcareApisService -Name $rname -ResourceGroupName $rgname -Location $location -Kind $kind -CosmosOfferThroughput $offerThroughput -ManagedIdentity -ExportStorageAccountName $storageAccountName;
	
	    $actual = Get-AzHealthcareApisService -ResourceGroupName $rgname -Name $rname

		# Assert
		Assert-AreEqual $rname $actual.Name
		Assert-AreEqual $offerThroughput $actual.CosmosDbOfferThroughput
		Assert-AreEqual $kind $actual.Kind
		Assert-AreEqual "https://$rname.azurehealthcareapis.com" $actual.Audience
		Assert-AreEqual $storageAccountName $actual.ExportStorageAccountName
		Assert-AreEqual "SystemAssigned" $actual.IdentityType
		Assert-NotNull $actual.IdentityPrincipalId
		Assert-NotNull $actual.IdentityTenantId

		#Update using parameters
		$newOfferThroughput = $offerThroughput - 600
		$updated = Set-AzHealthcareApisService -ResourceId $actual.Id -CosmosOfferThroughput $newOfferThroughput -DisableManagedIdentity;

		$updatedAccount = Get-AzHealthcareApisService -ResourceGroupName $rgname -Name $rname

		# Assert the update
		Assert-AreEqual $rname $updatedAccount.Name
		Assert-AreEqual $newOfferThroughput $updatedAccount.CosmosDbOfferThroughput
		Assert-AreEqual "None" $updatedAccount.IdentityType

		# Create second App
		$rname1 = $rname + "1"
		$created1 = New-AzHealthcareApisService -Name $rname1 -ResourceGroupName $rgname -Location $location -AccessPolicyObjectId $object_id -CosmosOfferThroughput $offerThroughput;
		
		$actual1 = Get-AzHealthcareApisService -ResourceGroupName $rgname -Name $rname1

		# Assert
		Assert-AreEqual $rname1 $actual1.Name
		Assert-AreEqual $offerThroughput $actual1.CosmosDbOfferThroughput

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

<#
.SYNOPSIS
Test PrivateEndpointConnection
#>
function Test-PrivateEndpointConnection
{
    # Setup
    $rgname = Get-ResourceGroupName

    try
    {
        # Test
        $accountname = 'hca' + $rgname;
        $loc = Get-Location;
        $offerThroughput =  Get-OfferThroughput
	    $kind = Get-Kind
	    $storageAccountName = "exportStorage"

        New-AzResourceGroup -Name $rgname -Location $loc;
        $createdAccount = New-AzHealthcareApisService -Name $accountname -ResourceGroupName $rgname -Location $loc -Kind $kind -CosmosOfferThroughput $offerThroughput -ManagedIdentity -ExportStorageAccountName $storageAccountName;
        Assert-NotNull $createdAccount;
        Assert-AreEqual $createdAccount.PublicNetworkAccess "Enabled"
        Assert-AreEqual $createdAccount.PrivateEndpointConnections $null

        $vnet = Get-AzVirtualNetwork -ResourceName anrudraw-vnet -ResourceGroupName anrudraw-demo
        $plsConnection = New-AzPrivateLinkServiceConnection -Name pe-powershell-ut -PrivateLinkServiceId $createdAccount.Id -RequestMessage "Please Approve my request" -GroupId "fhir"
        New-AzPrivateEndpoint -PrivateLinkServiceConnection $plsConnection -Subnet $vnet.Subnets[0] -Name pe-powershell-ut -ResourceGroupName anrudraw-demo -Location $loc 
        
        $account = Get-AzHealthcareApisService -ResourceGroupName $rgname -Name $accountname
        Assert-AreEqual $account.PrivateEndpointConnections.Length 1
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Test PublicNetworkAccessControl
#>
function Test-PublicNetworkAccessControl
{
    # Setup
    $rgname = Get-ResourceGroupName;
    # Test
    $accountname = 'hca' + $rgname;
    $loc = "Central US EUAP";
    $offerThroughput =  Get-OfferThroughput
	$kind = Get-Kind
	$storageAccountName = "exportStorage"

    try
    {
        New-AzResourceGroup -Name $rgname -Location $loc;
        $createdAccount =  New-AzHealthcareApisService -Name $accountname -ResourceGroupName $rgname -Location $loc -Kind $kind -CosmosOfferThroughput $offerThroughput -ManagedIdentity -ExportStorageAccountName $storageAccountName;
        Assert-NotNull $createdAccount;
        Assert-AreEqual $createdAccount.PublicNetworkAccess "Enabled"

        $actual = Get-AzHealthcareApisService -ResourceGroupName $rgname -Name $accountname

        $updatedAccount = Set-AzHealthcareApisService -ResourceId $actual.Id -PublicNetworkAccess "Disabled"
        Assert-NotNull $updatedAccount;
        Assert-AreEqual $updatedAccount.PublicNetworkAccess "Disabled"

        $updatedAccount = Set-AzHealthcareApisService -ResourceId $actual.Id -PublicNetworkAccess "Enabled"
        Assert-NotNull $updatedAccount;
        Assert-AreEqual $updatedAccount.PublicNetworkAccess "Enabled"

        $updatedAccount = Set-AzHealthcareApisService -ResourceId $actual.Id -PublicNetworkAccess "Enabled"
        Assert-NotNull $updatedAccount;
        Assert-AreEqual $updatedAccount.PublicNetworkAccess "Enabled"
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }

    try
    {
        New-AzResourceGroup -Name $rgname -Location $loc;
        $createdAccount = New-AzHealthcareApisService -Name $accountname -ResourceGroupName $rgname -Location $loc -Kind $kind -PublicNetworkAccess "Enabled" -Force;
        Assert-NotNull $createdAccount;
        Assert-AreEqual $createdAccount.PublicNetworkAccess "Enabled"
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }

    try
    {
        New-AzResourceGroup -Name $rgname -Location $loc;
        $createdAccount = New-AzHealthcareApisService -Name $accountname -ResourceGroupName $rgname -Location $loc -Kind $kind -PublicNetworkAccess "Disabled" -Force;
        Assert-NotNull $createdAccount;
        Assert-AreEqual $createdAccount.PublicNetworkAccess "Disabled"
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}