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
Tests EventHubs Private Endpoint Manual Approval Operations
#>

function WaitforStatetoBeSucceded 
{
	param([string]$resourceGroupName,[string]$namespaceName,[string]$privateEndpointName)
	
	$createdPrivateEndpoint = Get-AzEventHubPrivateEndpointConnection -ResourceGroup $resourceGroupName -Namespace $namespaceName -Name $privateEndpointName

	while($createdPrivateEndpoint.ProvisioningState -ne "Succeeded")
	{
		Wait-Seconds 10
		$createdPrivateEndpoint = Get-AzEventHubPrivateEndpointConnection -ResourceGroup $resourceGroupName -Namespace $namespaceName -Name $privateEndpointName
	}

	return $createdPrivateEndpoint
}

function PrivateEndpointTest
{
	# Setup    
	$location =  Get-Location
	$resourceGroupName = getAssetName "RSG-Private-Endpoint"
	$namespaceName = getAssetName "Eventhub-Namespace-"
	$peConnectionName1 = getAssetName "pe-connection-ns1-"
	$peConnectionName2 = getAssetName "pe-connection-ns2-"
	$peConnectionName3 = getAssetName "pe-connection-ns3-"
	$peConnectionName4 = getAssetName "pe-connection-ns4-"
	$peName1 = getAssetName "pe-Name1-"
	$peName2 = getAssetName "pe-Name2-"
	$peName3 = getAssetName "pe-Name3-"
	$peName4 = getAssetName "pe-Name4-"
	$vnetName1 = getAssetName "vnet-ns1-"
	$vnetName2 = getAssetName "vnet-ns2-"
	$subnetName1 = "frontendsubnet"
	$subnetName2 = "backendsubnet"

	try{
		
		# Create ResourceGroup
		Write-Debug " Create resource group"    
		Write-Debug "Resource group name : $resourceGroupName"
		New-AzResourceGroup -Name $resourceGroupName -Location $location -Force
	   
		# Create EventHub Namespace 
		Write-Debug " Create new Eventhub namespace"
		Write-Debug "Namespace name : $namespaceName"
		$result = New-AzEventHubNamespace -ResourceGroup $resourceGroupName -Name $namespaceName -Location $location

		$frontendSubnet = New-AzVirtualNetworkSubnetConfig -Name $subnetName1 -AddressPrefix "10.0.1.0/24" ## Create frontend subnet 
		$backendSubnet = New-AzVirtualNetworkSubnetConfig -Name $subnetName2 -AddressPrefix "10.0.2.0/24"
		$virtualNetwork = New-AzVirtualNetwork -ResourceGroupName $resourceGroupName -Location $location -Name $vnetName1 -AddressPrefix 10.0.0.0/16 -Subnet $frontendSubnet, $backendSubnet
		
		
		$privateEndpointConnection = New-AzPrivateLinkServiceConnection -Name $peConnectionName1 -PrivateLinkServiceId $result.Id -GroupId "namespace"
		$virtualNetwork = Get-AzVirtualNetwork -ResourceGroupName  $resourceGroupName -Name $vnetName1
		$subnet1 = $virtualNetwork | Select -ExpandProperty subnets | Where-Object  {$_.Name -eq $subnetName1}
		$privateEndpoint = New-AzPrivateEndpoint -ResourceGroupName $resourceGroupName -Name $peName1 -Location $location -Subnet $subnet1 -PrivateLinkServiceConnection $privateEndpointConnection -ByManualRequest -Force

		$privateEndpointConnection = New-AzPrivateLinkServiceConnection -Name $peConnectionName2 -PrivateLinkServiceId $result.Id -GroupId "namespace" -RequestMessage "Hello"
		$virtualNetwork = Get-AzVirtualNetwork -ResourceGroupName  $resourceGroupName -Name $vnetName1
		$subnet2 = $virtualNetwork | Select -ExpandProperty subnets | Where-Object  {$_.Name -eq $subnetName2}
		$privateEndpoint = New-AzPrivateEndpoint -ResourceGroupName $resourceGroupName -Name $peName2 -Location $location -Subnet $subnet2 -PrivateLinkServiceConnection $privateEndpointConnection -ByManualRequest -Force

		$listOfPrivateEndpoints = Get-AzEventHubPrivateEndpointConnection -ResourceGroupName $resourceGroupName -NamespaceName $namespaceName

		Assert-AreEqual 2 $listOfPrivateEndpoints.Count

		$privateEndpointId1 = $listOfPrivateEndpoints[0].Name
		$descriptionId1 = $listOfPrivateEndpoints[0].Description

		$privateEndpointId2 = $listOfPrivateEndpoints[1].Name
		$descriptionId2 = $listOfPrivateEndpoints[1].Description

		$privateEndpoint1 = Get-AzEventHubPrivateEndpointConnection -ResourceGroupName $resourceGroupName -NamespaceName $namespaceName -Name $privateEndpointId1
		Assert-AreEqual $privateEndpoint1.ConnectionState "Pending"
		Assert-AreEqual $privateEndpoint1.Description $descriptionId1

		$privateEndpoint2 = Get-AzEventHubPrivateEndpointConnection -ResourceId $listOfPrivateEndpoints[1].Id
		Assert-AreEqual $privateEndpoint2.ConnectionState "Pending"
		Assert-AreEqual $privateEndpoint2.Description $descriptionId2

		$privateEndpoint1 = Approve-AzEventHubPrivateEndpointConnection -ResourceGroupName $resourceGroupName -NamespaceName $namespaceName -Name $privateEndpointId1
		
		$privateEndpoint1 = WaitforStatetoBeSucceded $resourceGroupName $namespaceName $privateEndpointId1

		Assert-AreEqual $privateEndpoint1.ConnectionState "Approved"
		Assert-AreEqual $privateEndpoint1.ProvisioningState "Succeeded"
		Assert-AreEqual $privateEndpoint1.Description ""

		$privateEndpoint2 = Get-AzEventHubPrivateEndpointConnection -ResourceGroupName $resourceGroupName -NamespaceName $namespaceName -Name $privateEndpointId2
		Assert-AreEqual $privateEndpoint2.ConnectionState "Pending"
		Assert-AreEqual $privateEndpoint2.Description $descriptionId2

		$privateEndpoint2 = Approve-AzEventHubPrivateEndpointConnection -ResourceId $privateEndpoint2.Id
		
		$privateEndpoint2 = WaitforStatetoBeSucceded $resourceGroupName $namespaceName $privateEndpointId2

		Assert-AreEqual $privateEndpoint2.ConnectionState "Approved"
		Assert-AreEqual $privateEndpoint2.Description ""

		#
		$privateEndpoint1 = Get-AzEventHubPrivateEndpointConnection -ResourceId $privateEndpoint1.Id
		Assert-AreEqual $privateEndpoint1.ConnectionState "Approved"

		$privateEndpoint2 = Get-AzEventHubPrivateEndpointConnection -ResourceId $privateEndpoint2.Id
		Assert-AreEqual $privateEndpoint2.ConnectionState "Approved"
		Assert-AreEqual $privateEndpoint2.Description ""

		$privateEndpoint2 = Get-AzEventHubPrivateEndpointConnection -ResourceId $privateEndpoint2.Id.ToLower()
		Assert-AreEqual $privateEndpoint2.ConnectionState "Approved"
		Assert-AreEqual $privateEndpoint2.Description ""

		$privateEndpoint1 = Deny-AzEventHubPrivateEndpointConnection -ResourceId $privateEndpoint1.Id
		Assert-AreEqual $privateEndpoint1.ProvisioningState "Updating"
		Assert-AreEqual $privateEndpoint1.ConnectionState "Rejected"

		$privateEndpoint1 = WaitforStatetoBeSucceded $resourceGroupName $namespaceName $privateEndpointId1
		Assert-AreEqual $privateEndpoint1.ConnectionState "Rejected"
		Assert-AreEqual $privateEndpoint1.Description ""

		$privateEndpoint2 = Deny-AzEventHubPrivateEndpointConnection -ResourceGroupName $resourceGroupName -NamespaceName $namespaceName -Name $privateEndpointId2
		Assert-AreEqual "Updating" $privateEndpoint2.ProvisioningState
		Assert-AreEqual "Rejected" $privateEndpoint2.ConnectionState

		$privateEndpoint2 = WaitforStatetoBeSucceded $resourceGroupName $namespaceName $privateEndpointId2
		Assert-AreEqual $privateEndpoint2.ConnectionState "Rejected"
		Assert-AreEqual $privateEndpoint2.Description ""

		Remove-AzEventHubPrivateEndpointConnection -ResourceId $privateEndpoint1.Id
		Remove-AzEventHubPrivateEndpointConnection -ResourceGroupName $resourceGroupName -NamespaceName $namespaceName -Name $privateEndpointId2

		Wait-Seconds 40

		$listOfPrivateEndpoints = Get-AzEventHubPrivateEndpointConnection -ResourceId $result.Id
		Assert-AreEqual 0 $listOfPrivateEndpoints.Count

		$privateEndpointConnection = New-AzPrivateLinkServiceConnection -Name $peConnectionName3 -PrivateLinkServiceId $result.Id -GroupId "namespace"
		$privateEndpoint = New-AzPrivateEndpoint -ResourceGroupName $resourceGroupName -Name $peName3 -Location $location -Subnet $subnet2 -PrivateLinkServiceConnection $privateEndpointConnection -ByManualRequest -Force
		
		$listOfPrivateEndpoints = Get-AzEventHubPrivateEndpointConnection -ResourceId $result.Id
		Assert-AreEqual 1 $listOfPrivateEndpoints.Count

		$privateEndpointId1 = $listOfPrivateEndpoints[0].Name

		$privateEndpoint1 = WaitforStatetoBeSucceded $resourceGroupName $namespaceName $privateEndpointId1
		Assert-AreEqual $privateEndpoint1.ConnectionState "Pending"
		
		Approve-AzEventHubPrivateEndpointConnection -ResourceGroupName $resourceGroupName -NamespaceName $namespaceName -Name $privateEndpointId1 -Description "Approving this connection"

		$privateEndpoint1 = WaitforStatetoBeSucceded $resourceGroupName $namespaceName $privateEndpointId1
		Assert-AreEqual $privateEndpoint1.Description "Approving this connection"
		Assert-AreEqual $privateEndpoint1.ConnectionState "Approved"
		Assert-AreEqual $privateEndpoint1.ProvisioningState "Succeeded"

		Deny-AzEventHubPrivateEndpointConnection -ResourceGroupName $resourceGroupName -NamespaceName $namespaceName -Name $privateEndpointId1 -Description "Rejecting this connection"

		$privateEndpoint1 = WaitforStatetoBeSucceded $resourceGroupName $namespaceName $privateEndpointId1
		Assert-AreEqual $privateEndpoint1.Description "Rejecting this connection"
		Assert-AreEqual $privateEndpoint1.ConnectionState "Rejected"
		Assert-AreEqual $privateEndpoint1.ProvisioningState "Succeeded"

		Remove-AzEventHubPrivateEndpointConnection -ResourceGroupName $resourceGroupName -NamespaceName $namespaceName -Name $privateEndpointId1
		Wait-Seconds 30

		$privateEndpointConnection = New-AzPrivateLinkServiceConnection -Name $peConnectionName4 -PrivateLinkServiceId $result.Id -GroupId "namespace"
		$privateEndpoint = New-AzPrivateEndpoint -ResourceGroupName $resourceGroupName -Name $peName4 -Location $location -Subnet $subnet2 -PrivateLinkServiceConnection $privateEndpointConnection -ByManualRequest -Force
		
		$listOfPrivateEndpoints = Get-AzEventHubPrivateEndpointConnection -ResourceId $result.Id
		Assert-AreEqual 1 $listOfPrivateEndpoints.Count

		$privateEndpointId1 = $listOfPrivateEndpoints[0].Name

		$privateEndpoint1 = WaitforStatetoBeSucceded $resourceGroupName $namespaceName $privateEndpointId1
		Assert-AreEqual $privateEndpoint1.ConnectionState "Pending"
		
		Approve-AzEventHubPrivateEndpointConnection -ResourceId $privateEndpoint1.Id -Description "Approving this connection"

		$privateEndpoint1 = WaitforStatetoBeSucceded $resourceGroupName $namespaceName $privateEndpointId1
		Assert-AreEqual $privateEndpoint1.Description "Approving this connection"
		Assert-AreEqual $privateEndpoint1.ConnectionState "Approved"
		Assert-AreEqual $privateEndpoint1.ProvisioningState "Succeeded"

		Deny-AzEventHubPrivateEndpointConnection -ResourceId $privateEndpoint1.Id -Description "Rejecting this connection"

		$privateEndpoint1 = WaitforStatetoBeSucceded $resourceGroupName $namespaceName $privateEndpointId1
		Assert-AreEqual $privateEndpoint1.Description "Rejecting this connection"
		Assert-AreEqual $privateEndpoint1.ConnectionState "Rejected"
		Assert-AreEqual $privateEndpoint1.ProvisioningState "Succeeded"

		$privateLink = Get-AzEventHubPrivateLink -ResourceGroupName $resourceGroupName -NamespaceName $namespaceName

		Assert-AreEqual "namespace" $privateLink.GroupId
		Assert-AreEqual "namespace" $privateLink.Name
		Assert-AreEqual "Microsoft.EventHub/namespaces/privateLinkResources" $privateLink.Type
		Assert-AreEqual 1 $privateLink.RequiredMembers.Count
		Assert-AreEqual 1 $privateLink.RequiredZoneNames.Count

		Remove-AzEventHubPrivateEndpointConnection -ResourceGroupName $resourceGroupName -NamespaceName $namespaceName -Name $privateEndpointId1
		Wait-Seconds 30

	}
	finally{
		Write-Debug " Delete resourcegroup"
		Remove-AzResourceGroup -Name $resourceGroupName -Force
	}

}