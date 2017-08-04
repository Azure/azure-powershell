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
	Tests creating and updating a virtual network rule
#>
function Test-CreateAndUpdateVirtualNetworkRule
{
	# Setup
	$location = "East US 2 EUAP"
	$rg = Create-ResourceGroupForTest $location 	
	$server = Create-ServerForTest $rg $location

	$virtualNetworkRuleName = Get-VirtualNetworkRuleName

	$vnetName1 = "vnet1"
	$virtualNetworkSubnetId1 = Get-VirtualNetworkSubnetId $vnetName1

	$vnetName2 = "vnet2"
	$virtualNetworkSubnetId2 = Get-VirtualNetworkSubnetId $vnetName2

	try
	{
		# Create rule
		$virtualNetworkRule = New-AzureRmSqlServerVirtualNetworkRule -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -VirtualNetworkRuleName $virtualNetworkRuleName -VirtualNetworkSubnetId $virtualNetworkSubnetId1
		Assert-AreEqual $virtualNetworkRule.ServerName $server.ServerName
		Assert-AreEqual $virtualNetworkRule.VirtualNetworkRuleName $virtualNetworkRuleName
		Assert-AreEqual $virtualNetworkRule.VirtualNetworkSubnetId $virtualNetworkSubnetId1
		
		# Update existing rule
		$virtualNetworkRule = Set-AzureRmSqlServerVirtualNetworkRule -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -VirtualNetworkRuleName $virtualNetworkRuleName -VirtualNetworkSubnetId $virtualNetworkSubnetId2
		Assert-AreEqual $virtualNetworkRule.ServerName $server.ServerName
		Assert-AreEqual $virtualNetworkRule.VirtualNetworkRuleName $virtualNetworkRuleName
		Assert-AreEqual $virtualNetworkRule.VirtualNetworkSubnetId $virtualNetworkSubnetId2
	}
	finally
	{
		# Clean the enviroment 
		Remove-AzureRmSqlServerVirtualNetworkRule -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -VirtualNetworkRuleName $virtualNetworkRuleName -Force
		Remove-ResourceGroupForTest $rg
	}
}

<#
	.SYNOPSIS
	Tests Getting a virtual network rule
#>
function Test-GetVirtualNetworkRule
{
	# Setup
	$location = "East US 2 EUAP"
	$rg = Create-ResourceGroupForTest $location 	
	$server = Create-ServerForTest $rg $location

	$virtualNetworkRuleName1 = Get-VirtualNetworkRuleName
	$vnetName1 = "vnet1"
	$virtualNetworkSubnetId1 = Get-VirtualNetworkSubnetId $vnetName1

	$virtualNetworkRuleName2 = Get-VirtualNetworkRuleName
	$vnetName2 = "vnet2"
	$virtualNetworkSubnetId2 = Get-VirtualNetworkSubnetId $vnetName2

	try
	{
		# Create rule 1
		$virtualNetworkRule1 = New-AzureRmSqlServerVirtualNetworkRule -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -VirtualNetworkRuleName $virtualNetworkRuleName1 -VirtualNetworkSubnetId $virtualNetworkSubnetId1
		Assert-AreEqual $virtualNetworkRule1.ServerName $server.ServerName
		Assert-AreEqual $virtualNetworkRule1.VirtualNetworkRuleName $virtualNetworkRuleName1
		Assert-AreEqual $virtualNetworkRule1.VirtualNetworkSubnetId $virtualNetworkSubnetId1

		# Create rule 2
		$virtualNetworkRule2 = New-AzureRmSqlServerVirtualNetworkRule -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -VirtualNetworkRuleName $virtualNetworkRuleName2 -VirtualNetworkSubnetId $virtualNetworkSubnetId2
		Assert-AreEqual $virtualNetworkRule2.ServerName $server.ServerName
		Assert-AreEqual $virtualNetworkRule2.VirtualNetworkRuleName $virtualNetworkRuleName2
		Assert-AreEqual $virtualNetworkRule2.VirtualNetworkSubnetId $virtualNetworkSubnetId2
		
		# Get rule
		$resp = Get-AzureRmSqlServerVirtualNetworkRule -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -VirtualNetworkRuleName $virtualNetworkRuleName1
		Assert-AreEqual $resp.VirtualNetworkSubnetId $virtualNetworkSubnetId1

		# Get list of rules
		$resp = Get-AzureRmSqlServerVirtualNetworkRule -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName
		Assert-AreEqual $resp.Count 2
	}
	finally
	{
		# Clean the enviroment 
		Remove-AzureRmSqlServerVirtualNetworkRule -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -VirtualNetworkRuleName $virtualNetworkRuleName1 -Force
		Remove-AzureRmSqlServerVirtualNetworkRule -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -VirtualNetworkRuleName $virtualNetworkRuleName2 -Force
		Remove-ResourceGroupForTest $rg
	}
}

<#
	.SYNOPSIS
	Tests Removing a server
#>
function Test-RemoveVirtualNetworkRule
{
	# Setup
	$location = "East US 2 EUAP"
	$rg = Create-ResourceGroupForTest $location 	

	$virtualNetworkRuleName = Get-VirtualNetworkRuleName
	$vnetName = "vnet1"
	$virtualNetwork = New-AzureRmVirtualNetwork $rg $vnetName $location
	$virtualNetworkSubnetId = $virtualNetwork.Subnets[0].Id

	$server = Create-ServerForTest $rg $location

	try
	{
		# Create rule
		$virtualNetworkRule = New-AzureRmSqlServerVirtualNetworkRule -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -VirtualNetworkRuleName $virtualNetworkRuleName -VirtualNetworkSubnetId $virtualNetworkSubnetId
		Assert-AreEqual $virtualNetworkRule.ServerName $server.ServerName
		Assert-AreEqual $virtualNetworkRule.VirtualNetworkRuleName $virtualNetworkRuleName
		Assert-AreEqual $virtualNetworkRule.VirtualNetworkSubnetId $virtualNetworkSubnetId
		
		# Remove rule and check if rule is deleted
		$resp = Remove-AzureRmSqlServerVirtualNetworkRule -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -VirtualNetworkRuleName $virtualNetworkRuleName -Force
		$all = Get-AzureRmSqlServerVirtualNetworkRule -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName
		Assert-AreEqual $all.Count 0

	}
	finally
	{
		Remove-ResourceGroupForTest $rg
	}
}

<#
.SYNOPSIS
Gets the virtual network subnet id used in the virtual network rules tests
#>
function Get-VirtualNetworkSubnetId ($vnetName)
{
	$vnetSubscriptionId = "d513e2e9-97db-40f6-8d1a-ab3b340cc81a"
	$vnetResourceGroupName = "vnetRg"
	$subnetName = "subnet1"
	
	# vnetsubnetid is of form - "/subscriptions/d513e2e9-97db-40f6-8d1a-ab3b340cc81a/resourceGroups/naduttacvnetrg/providers/Microsoft.Network/virtualNetworks/vnetND3/subnets/subnet1"
	$vnetSubnetId = "/subscriptions/$vnetSubscriptionId/resourceGroups/$vnetResourceGroupName/providers/Microsoft.Network/virtualNetworks/$vnetName/subnets/$subnetName"

	return $vnetSubnetId
}

<#
	.SYNOPSIS
	Create a virtual network
#>
function New-AzureRmVirtualNetwork ($resourceGroup, $vnetName, $location = "westcentralus")
{
	BEGIN {
		$context = Get-Context
		$client = Get-NetworkClient $context
	}

	PROCESS {

		<#$addressSpace = New-Object -Type Microsoft.Azure.Management.Network.Models.AddressSpace
		$addessSpace.AddressPrefixes =  "10.0.0.0/16"#>
		
		# Initialize subnet
		$subnet = New-Object -Type Microsoft.Azure.Management.Network.Models.Subnet
		$subnet.Name = "subnet1"
		$subnet.AddressPrefix = "10.0.1.0/24"
		$privateAccessServices = New-Object -Type Microsoft.Azure.Management.Network.Models.PrivateAccessServicePropertiesFormat
		$privateAccessServices.Service = "Microsoft.Sql"
		$listPrivateAccessServices = New-Object System.Collections.Generic.List[Microsoft.Azure.Management.Network.Models.PrivateAccessServicePropertiesFormat]
		$listPrivateAccessServices.Add($privateAccessServices)
		$subnet.PrivateAccessServices = $listPrivateAccessServices

		# Initialize Vnet
		$virtualNetworkParams = New-Object -Type Microsoft.Azure.Management.Network.Models.VirtualNetwork
		$virtualNetworkParams.Location = $location
		$virtualNetworkParams.AddressSpace = $addressSpace
		$virtualNetworkParams.DhcpOptions = $DhcpOptions
		$listSubnets = New-Object System.Collections.Generic.List[Microsoft.Azure.Management.Network.Models.Subnet]
		$listSubnets.Add($subnet)
		$virtualNetworkParams.Subnets = $listSubnets

		# Create Virtual Network
		$createVnet = $client.VirtualNetworks.CreateOrUpdateWithHttpMessagesAsync($resourceGroup, $vnetName, $virtualNetworkParams, $null, [System.Threading.CancellationToken]::None)

		# Get Virtual Network
		$getVnet = $client.VirtualNetworks.Get($resourceGroup, $vnetName)

		$rg = $getVnet.Result
	}

	END{}
}

function Get-Context
{
      return [Microsoft.Azure.Commands.Common.Authentication.Abstractions.AzureRmProfileProvider]::Instance.Profile.DefaultContext
}

<#
	.SYNOPSIS
	Gets Networking Client
#>
function Get-NetworkClient
{
	param([Microsoft.Azure.Commands.Common.Authentication.Abstractions.IAzureContext] $context)
    $factory = [Microsoft.Azure.Commands.Common.Authentication.AzureSession]::Instance.ClientFactory
    [System.Type[]]$types = [Microsoft.Azure.Commands.Common.Authentication.Abstractions.IAzureContext], [string]
    $networkClient = [Microsoft.Azure.Management.Network.NetworkManagementClient]
    $networkVersion = [System.Reflection.Assembly]::GetAssembly($networkClient).GetName().Version
    if ($networkVersion.Major -gt 3)
    {
      $method = [Microsoft.Azure.Commands.Common.Authentication.IClientFactory].GetMethod("CreateArmClient", $types)
    }
    else
    {
      $method = [Microsoft.Azure.Commands.Common.Authentication.IHyakClientFactory].GetMethod("CreateClient", $types)
    }
    $closedMethod = $method.MakeGenericMethod([Microsoft.Azure.Management.Network.NetworkManagementClient])
    $arguments = $context, [Microsoft.Azure.Commands.Common.Authentication.Abstractions.AzureEnvironment+Endpoint]::ResourceManager
    $client = $closedMethod.Invoke($factory, $arguments)
    return $client
}
