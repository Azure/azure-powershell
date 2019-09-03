# ----------------------------------------------------------------------------------
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
Check NotFound exception processing
#>
function Test-NotFound
{
    $rgLocation = Get-ProviderLocation ResourceManagement
    $resourceTypeParent = "Microsoft.Network/PublicIpAddresses"
    $location = Get-ProviderLocation $resourceTypeParent

    $rgName = Get-ResourceGroupName
    $resourceName = Get-ResourceName

    try
    {
        # Create the resource group
        New-AzResourceGroup -Name $rgName -Location $location

        # Get PublicIpAddress that doesn't exist
        Assert-ThrowsLike { $ip = Get-AzPublicIpAddress -ResourceGroupName $rgName -Name $resourceName } "*was not found.*";
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgName
    }
}

<#
.SYNOPSIS
Check InvalidName exception processing
#>
function Test-InvalidName
{
    $rgLocation = Get-ProviderLocation ResourceManagement
    $resourceTypeParent = "Microsoft.Network/PublicIpAddresses"
    $location = Get-ProviderLocation $resourceTypeParent

    $rgName = Get-ResourceGroupName
    $resourceInvalidName = "!"

    try
    {
        # Create the resource group
        New-AzResourceGroup -Name $rgName -Location $location

        Assert-ThrowsLike { $ip = New-AzPublicIpAddress -ResourceGroupName $rgName -Name $resourceInvalidName -Location $location -AllocationMethod Dynamic } "*Resource name ! is invalid.*";
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgName
    }
}

<#
.SYNOPSIS
Check InvalidName exception processing
#>
function Test-DuplicateResource
{
    $rgLocation = Get-ProviderLocation ResourceManagement
    $resourceTypeParent = "Microsoft.Network/PublicIpAddresses"
    $location = Get-ProviderLocation $resourceTypeParent

    $rgName = Get-ResourceGroupName
    $resourceName = Get-ResourceName

    $vnetAddressPrefix = "10.0.0.0/8"
    $subnetAddressPrefix = "10.0.1.0/24"

    try
    {
        # Create the resource group
        New-AzResourceGroup -Name $rgName -Location $location
        $subnet = New-AzVirtualNetworkSubnetConfig -Name $resourceName -AddressPrefix $subnetAddressPrefix
        $vnet = New-AzVirtualNetwork -ResourceGroupName $rgName -Name $resourceName -Location $location -AddressPrefix $vnetAddressPrefix -Subnet $subnet
        $vnet.Subnets.Add($subnet);
        Assert-ThrowsLike { Set-AzVirtualNetwork -VirtualNetwork $vnet } "*Cannot parse the request.*";
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgName
    }
}

<#
.SYNOPSIS
Check InvalidName exception processing
#>
function Test-IntersectAddressSpace
{
    $rgLocation = Get-ProviderLocation ResourceManagement
    $resourceTypeParent = "Microsoft.Network/PublicIpAddresses"
    $location = Get-ProviderLocation $resourceTypeParent

    $rgName = Get-ResourceGroupName
    $resourceName = Get-ResourceName

    $vnetAddressPrefix = "10.0.0.0/8"
    $subnetAddressPrefix = "10.0.1.0/24"

    try
    {
        # Create the resource group
        New-AzResourceGroup -Name $rgName -Location $location
        $subnet = New-AzVirtualNetworkSubnetConfig -Name $resourceName -AddressPrefix $subnetAddressPrefix
        $vnet = New-AzVirtualNetwork -ResourceGroupName $rgName -Name $resourceName -Location $location -AddressPrefix $vnetAddressPrefix -Subnet $subnet
        Add-AzVirtualNetworkSubnetConfig -Name "${resourceName}2" -AddressPrefix $subnetAddressPrefix -VirtualNetwork $vnet
        Assert-ThrowsLike { Set-AzVirtualNetwork -VirtualNetwork $vnet } "*Subnet*is not valid in virtual network*";
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgName
    }
}