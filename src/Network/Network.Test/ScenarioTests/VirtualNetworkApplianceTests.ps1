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
        Assert-AreEqual 50 $vna.BandwidthInGbps
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
        Assert-AreEqual 50 $vna.BandwidthInGbps

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
        Assert-AreEqual 50 $vna.BandwidthInGbps
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
