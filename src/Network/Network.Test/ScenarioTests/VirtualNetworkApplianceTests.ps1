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
Tests VirtualNetworkAppliance CRUD operations
#>
function Test-VirtualNetworkApplianceCRUD
{
    # Setup
    $rgname = Get-ResourceGroupName
    $rname = Get-ResourceName
    $location = "eastus2euap"
    $vnetName = Get-ResourceName
    $subnetName = "VirtualNetworkApplianceSubnet"

    try
    {
        # Create the resource group
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $location

        # Create a virtual network with defaultOutboundAccess set to false (required by Azure Policy)
        $subnet = New-AzVirtualNetworkSubnetConfig -Name $subnetName -AddressPrefix "10.0.0.0/24" -DefaultOutboundAccess $false
        $vnet = New-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix "10.0.0.0/16" -Subnet $subnet
        $subnet = Get-AzVirtualNetworkSubnetConfig -Name $subnetName -VirtualNetwork $vnet

        # Create VirtualNetworkAppliance
        $vna = New-AzVirtualNetworkAppliance -Name $rname -ResourceGroupName $rgname -Location $location -SubnetId $subnet.Id -Bandwidth 50 -Tag @{"testKey" = "testValue"}

        # Verify creation
        Assert-NotNull $vna
        Assert-AreEqual $rname $vna.Name
        Assert-AreEqual $rgname $vna.ResourceGroupName
        Assert-NotNull $vna.Location
        Assert-AreEqual "testValue" $vna.Tag["testKey"]
        Assert-AreEqual "Succeeded" $vna.ProvisioningState
        Assert-AreEqual "50" $vna.BandwidthInGbps
        Assert-NotNull $vna.Subnet
        Assert-NotNull $vna.Subnet.Id

        # Verify PrivateIPAddressVersion defaults to IPv4
        Assert-AreEqual "IPv4" $vna.PrivateIPAddressVersion
        
        # Verify IPConfigurations - should have 5 IP configurations
        Assert-NotNull $vna.IPConfigurations
        Assert-AreEqual 5 $vna.IPConfigurations.Count
        
        # Verify the first IP configuration is primary
        $primaryIpConfig = $vna.IPConfigurations | Where-Object { $_.Primary -eq $true }
        Assert-NotNull $primaryIpConfig
        Assert-AreEqual 1 @($primaryIpConfig).Count
        Assert-NotNull $primaryIpConfig.PrivateIPAddress
        
        # Verify all IP configurations have required properties
        foreach ($ipConfig in $vna.IPConfigurations) {
            Assert-NotNull $ipConfig.Name
            Assert-NotNull $ipConfig.PrivateIPAddress
            Assert-AreEqual "Succeeded" $ipConfig.ProvisioningState
        }
        Assert-AreEqual $subnet.Id $vna.Subnet.Id
        Assert-AreEqual "50" $vna.BandwidthInGbps

        # Get VirtualNetworkAppliance by name
        $vnaGet = Get-AzVirtualNetworkAppliance -Name $rname -ResourceGroupName $rgname
        Assert-NotNull $vnaGet
        Assert-AreEqual $rname $vnaGet.Name
        Assert-AreEqual $rgname $vnaGet.ResourceGroupName
        Assert-NotNull $vnaGet.Location
        Assert-AreEqual "testValue" $vnaGet.Tag["testKey"]
        Assert-AreEqual "IPv4" $vnaGet.PrivateIPAddressVersion

        # List VirtualNetworkAppliances in resource group
        $vnaList = Get-AzVirtualNetworkAppliance -ResourceGroupName $rgname
        Assert-NotNull $vnaList
        Assert-True { $vnaList.Count -ge 1 }

        # Update VirtualNetworkAppliance tags
        $vnaUpdated = Update-AzVirtualNetworkAppliance -Name $rname -ResourceGroupName $rgname -Tag @{"updatedKey" = "updatedValue"}
        Assert-NotNull $vnaUpdated
        Assert-AreEqual "updatedValue" $vnaUpdated.Tag["updatedKey"]

        # Remove VirtualNetworkAppliance
        $removeResult = Remove-AzVirtualNetworkAppliance -Name $rname -ResourceGroupName $rgname -Force -PassThru
        Assert-AreEqual $true $removeResult

        # Verify removal - should throw
        Assert-ThrowsLike { Get-AzVirtualNetworkAppliance -Name $rname -ResourceGroupName $rgname } "*not found*"
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Tests VirtualNetworkAppliance creation with DualStack PrivateIPAddressVersion
#>
function Test-VirtualNetworkApplianceDualStack
{
    # Setup
    $rgname = Get-ResourceGroupName
    $rname = Get-ResourceName
    $location = "eastus2euap"
    $vnetName = Get-ResourceName
    $subnetName = "VirtualNetworkApplianceSubnet"

    try
    {
        # Create the resource group
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $location

        # Create a dual-stack virtual network (IPv4 + IPv6) required for DualStack VNA
        $subnet = New-AzVirtualNetworkSubnetConfig -Name $subnetName -AddressPrefix "10.0.0.0/24","ace:cab:deca:deed::/64" -DefaultOutboundAccess $false
        $vnet = New-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix "10.0.0.0/16","ace:cab:deca::/48" -Subnet $subnet
        $subnet = Get-AzVirtualNetworkSubnetConfig -Name $subnetName -VirtualNetwork $vnet

        # Create VirtualNetworkAppliance with DualStack
        $vna = New-AzVirtualNetworkAppliance -Name $rname -ResourceGroupName $rgname -Location $location -SubnetId $subnet.Id -Bandwidth 50 -PrivateIPAddressVersion "DualStack"

        # Verify creation with DualStack
        Assert-NotNull $vna
        Assert-AreEqual $rname $vna.Name
        Assert-AreEqual "Succeeded" $vna.ProvisioningState
        Assert-AreEqual "50" $vna.BandwidthInGbps
        Assert-AreEqual "DualStack" $vna.PrivateIPAddressVersion

        # Get and verify
        $vnaGet = Get-AzVirtualNetworkAppliance -Name $rname -ResourceGroupName $rgname
        Assert-AreEqual "DualStack" $vnaGet.PrivateIPAddressVersion

        # Remove
        $removeResult = Remove-AzVirtualNetworkAppliance -Name $rname -ResourceGroupName $rgname -Force -PassThru
        Assert-AreEqual $true $removeResult
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Tests VirtualNetworkAppliance CapacityProvider create/update scenarios
#>
function Test-VirtualNetworkApplianceCapacityProvider
{
    # Setup
    $rgname = Get-ResourceGroupName
    $providerName = Get-ResourceName
    $consumerName = Get-ResourceName
    $location = "eastus2euap"
    $vnetName = Get-ResourceName
    $subnetName = "VirtualNetworkApplianceSubnet"

    try
    {
        # Create the resource group
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $location

        # Create a virtual network with defaultOutboundAccess set to false (required by Azure Policy)
        $subnet = New-AzVirtualNetworkSubnetConfig -Name $subnetName -AddressPrefix "10.0.0.0/24" -DefaultOutboundAccess $false
        $vnet = New-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix "10.0.0.0/16" -Subnet $subnet
        $subnet = Get-AzVirtualNetworkSubnetConfig -Name $subnetName -VirtualNetwork $vnet

        # Create the "provider" VirtualNetworkAppliance which will supply capacity
        $providerVna = New-AzVirtualNetworkAppliance -Name $providerName -ResourceGroupName $rgname -Location $location -SubnetId $subnet.Id -Bandwidth 50
        Assert-NotNull $providerVna
        Assert-NotNull $providerVna.Id

        # Create the "consumer" VirtualNetworkAppliance that references the provider as its CapacityProvider
        $consumerVna = New-AzVirtualNetworkAppliance -Name $consumerName -ResourceGroupName $rgname -Location $location -SubnetId $subnet.Id -Bandwidth 0 -CapacityProviderId $providerVna.Id

        # Verify creation with CapacityProvider set
        Assert-NotNull $consumerVna
        Assert-AreEqual $consumerName $consumerVna.Name
        Assert-AreEqual "Succeeded" $consumerVna.ProvisioningState
        Assert-NotNull $consumerVna.CapacityProvider
        Assert-AreEqual $providerVna.Id $consumerVna.CapacityProvider.Id

        # Get and verify CapacityProvider is correctly persisted
        $consumerVnaGet = Get-AzVirtualNetworkAppliance -Name $consumerName -ResourceGroupName $rgname
        Assert-NotNull $consumerVnaGet.CapacityProvider
        Assert-AreEqual $providerVna.Id $consumerVnaGet.CapacityProvider.Id
        Assert-AreEqual $subnet.Id $consumerVnaGet.Subnet.Id

        # Update the consumer VNA's CapacityProvider to itself-independent provider (simulate re-pointing),
        # while verifying other properties (Subnet, Bandwidth) remain unchanged
        $consumerVnaUpdated = Update-AzVirtualNetworkAppliance -Name $consumerName -ResourceGroupName $rgname -CapacityProviderId $providerVna.Id
        Assert-NotNull $consumerVnaUpdated
        Assert-NotNull $consumerVnaUpdated.CapacityProvider
        Assert-AreEqual $providerVna.Id $consumerVnaUpdated.CapacityProvider.Id
        Assert-AreEqual $subnet.Id $consumerVnaUpdated.Subnet.Id
        Assert-AreEqual $consumerVnaGet.BandwidthInGbps $consumerVnaUpdated.BandwidthInGbps

        # Update only tags on the consumer VNA (no CapacityProvider specified) - verify CapacityProvider and other
        # properties are preserved (backward-compatible UpdateTags path)
        $consumerVnaTagUpdate = Update-AzVirtualNetworkAppliance -Name $consumerName -ResourceGroupName $rgname -Tag @{"updatedKey" = "updatedValue"}
        Assert-NotNull $consumerVnaTagUpdate
        Assert-AreEqual "updatedValue" $consumerVnaTagUpdate.Tag["updatedKey"]
        Assert-NotNull $consumerVnaTagUpdate.CapacityProvider
        Assert-AreEqual $providerVna.Id $consumerVnaTagUpdate.CapacityProvider.Id

        # Verify the provider VNA itself has no CapacityProvider set (default/backward-compatible scenario)
        $providerVnaGet = Get-AzVirtualNetworkAppliance -Name $providerName -ResourceGroupName $rgname
        Assert-Null $providerVnaGet.CapacityProvider

        # Cleanup consumer then provider
        $removeConsumer = Remove-AzVirtualNetworkAppliance -Name $consumerName -ResourceGroupName $rgname -Force -PassThru
        Assert-AreEqual $true $removeConsumer

        $removeProvider = Remove-AzVirtualNetworkAppliance -Name $providerName -ResourceGroupName $rgname -Force -PassThru
        Assert-AreEqual $true $removeProvider
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}
