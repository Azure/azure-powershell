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

    $rgName = Get-ResourceGroupName
    $pipName = Get-ResourceName

    try
    {
        # Create the resource group
        New-AzResourceGroup -Name $rgName -Location $rgLocation

        # Get PublicIpAddress that doesn't exist
        Assert-ThrowsLike { Get-AzPublicIpAddress -ResourceGroupName $rgName -Name $pipName } "*ResourceNotFound*was not found*"
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
    $location = Get-ProviderLocation "Microsoft.Network/publicIpAddresses"

    $rgName = Get-ResourceGroupName
    $invalidName = "!"

    try
    {
        # Create the resource group
        New-AzResourceGroup -Name $rgName -Location $rgLocation

        # Create PublicIpAddress with incorrect name
        $scriptBlock = { New-AzPublicIpAddress -ResourceGroupName $rgName -Name $invalidName -Location $location -AllocationMethod Dynamic }
        Assert-ThrowsLike $scriptBlock "*InvalidResourceName*Resource name ${invalidName} is invalid*"
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgName
    }
}

<#
.SYNOPSIS
Check DuplicateResourceName exception processing
#>
function Test-DuplicateResource
{
    $rgLocation = Get-ProviderLocation ResourceManagement
    $location = Get-ProviderLocation "Microsoft.Network/virtualNetworks"

    $rgName = Get-ResourceGroupName
    $vnetName = Get-ResourceName
    $subnetName = Get-ResourceName

    $vnetAddressPrefix = "10.0.0.0/8"
    $subnetAddressPrefix = "10.0.1.0/24"

    try
    {
        # Create the resource group
        New-AzResourceGroup -Name $rgName -Location $rgLocation

        $subnet = New-AzVirtualNetworkSubnetConfig -Name $subnetName -AddressPrefix $subnetAddressPrefix
        $vnet = New-AzVirtualNetwork -ResourceGroupName $rgName -Name $vnetName -Location $location -AddressPrefix $vnetAddressPrefix -Subnet $subnet
        $vnet.Subnets.Add($subnet)

        # Update VirtualNetwork with two duplicate subnets
        Assert-ThrowsLike { Set-AzVirtualNetwork -VirtualNetwork $vnet } "*InvalidRequestFormat*Additional details*DuplicateResourceName*"
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgName
    }
}

<#
.SYNOPSIS
Check NetcfgInvalidSubnet exception processing
#>
function Test-IntersectAddressSpace
{
    $rgLocation = Get-ProviderLocation ResourceManagement
    $location = Get-ProviderLocation "Microsoft.Network/virtualNetworks"

    $rgName = Get-ResourceGroupName
    $vnetName = Get-ResourceName
    $subnetName = Get-ResourceName

    $vnetAddressPrefix = "10.0.0.0/8"
    $subnetAddressPrefix = "10.0.1.0/24"

    try
    {
        # Create the resource group
        New-AzResourceGroup -Name $rgName -Location $rgLocation

        $subnet = New-AzVirtualNetworkSubnetConfig -Name $subnetName -AddressPrefix $subnetAddressPrefix
        $vnet = New-AzVirtualNetwork -ResourceGroupName $rgName -Name $vnetName -Location $location -AddressPrefix $vnetAddressPrefix -Subnet $subnet
        Add-AzVirtualNetworkSubnetConfig -Name "${subnetName}2" -AddressPrefix $subnetAddressPrefix -VirtualNetwork $vnet
        
        # Update VirtualNetwork with two intersecting subnets
        Assert-ThrowsLike { Set-AzVirtualNetwork -VirtualNetwork $vnet } "*NetcfgInvalidSubnet*Subnet*is not valid in virtual network*"
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgName
    }
}

<#
.SYNOPSIS
Check processing of ErrorResponse exceptions
#>
function Test-ErrorResponseException
{
    $rgLocation = Get-ProviderLocation ResourceManagement

    $rgName = Get-ResourceGroupName
    $nwName = Get-ResourceName

    try
    {
        # Create the resource group
        New-AzResourceGroup -Name $rgName -Location $rgLocation

        # Try to create another NW in a region
        [array]$nw = Get-AzNetworkWatcher
        if($nw.Length -gt 0)
        {
            $existingLocation = $nw[0].Location
            Assert-ThrowsLike { New-AzNetworkWatcher -Name $nwName -ResourceGroupName $rgName -Location $existingLocation } "*NetworkWatcherCountLimitReached*"
        }

        # Try to create NW with invalid name
        [array]$availableLocations = (Get-AzResourceProvider -ProviderNamespace "Microsoft.Network" | Where-Object { $_.ResourceTypes.ResourceTypeName -eq "networkWatchers" }).Locations
        if($availableLocations.Length -gt 0)
        {
            $location = Normalize-Location $availableLocations[0]
            Assert-ThrowsLike { New-AzNetworkWatcher -Name "!" -ResourceGroupName $rgName -Location $location } "*InvalidResourceName*"
        }
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgName
    }
}
