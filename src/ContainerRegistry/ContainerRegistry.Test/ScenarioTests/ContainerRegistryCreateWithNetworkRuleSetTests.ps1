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
Test Import-AzContainerRegistryImage.
#>
function Test-CreateWithNetworkRuleSet
{
	# Setup
    $resourceGroupName = Get-RandomResourceGroupName
    $RegistryName = Get-RandomRegistryName
    $location = Get-ProviderLocation "Microsoft.ContainerRegistry/registries"
	$SubnetName = Get-RandomResourceName
	$VnetName = Get-RandomResourceName

	try
	{
		New-AzResourceGroup -Name $resourceGroupName -Location $location

		$subnet = New-AzVirtualNetworkSubnetConfig -Name $SubnetName -AddressPrefix "10.0.1.0/24" -ServiceEndpoint "Microsoft.ContainerRegistry"
		$vnet = New-AzVirtualNetwork -Name $VnetName -ResourceGroupName $resourceGroupName -Location $location -AddressPrefix "10.0.0.0/16" -Subnet $subnet
		$rule = New-AzContainerRegistryNetworkRule -VirtualNetworkRule -VirtualNetworkResourceId $vnet.Subnets[0].Id
		$set = Set-AzContainerRegistryNetworkRuleSet -DefaultAction "Allow" -NetworkRule $rule
		$registry = New-AzContainerRegistry -ResourceGroupName $resourceGroupName -Name $RegistryName -Sku "Premium" -Location $location
		$registry = Update-AzContainerRegistry -ResourceGroupName $resourceGroupName -Name $RegistryName -NetworkRuleSet $set

		$usage = Get-AzContainerRegistryUsage -ResourceGroupName $resourceGroupName -RegistryName $RegistryName

		Assert-NotNull $usage
		Assert-AreEqual $vnet.Subnets[0].Id $registry.NetworkRuleSet.VirtualNetworkRules[0].VirtualNetworkResourceId

		Remove-AzContainerRegistry -ResourceGroupName $resourceGroupName -Name $RegistryName
		Remove-AzVirtualNetwork -Name $VnetName -ResourceGroupName $resourceGroupName -force
	}
	finally
	{
		Remove-AzResourceGroup -Name $resourceGroupName -Force
	}
}