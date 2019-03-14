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
Tests VirtualNetworkTap using ipendpoints
#>
function Test-VirtualNetworkTapCRUDUsingIpConfig
{
    #added temporarily
    # Register-AzResourceProvider -ProviderNamespace "Microsoft.Network"

    # Setup
    $rgname = Get-ResourceGroupName
    $vnetName = Get-ResourceName
    $subnetName = Get-ResourceName
    $publicIpName = Get-ResourceName
    $nicName = Get-ResourceName
    $domainNameLabel = Get-ResourceName
    $rglocation = Get-ProviderLocation ResourceManagement
    $resourceTypeParent = "Microsoft.Network/networkInterfaces"
    $location = Get-ProviderLocation $resourceTypeParent
    $rname = Get-ResourceName

    try 
    {
        # Create the resource group
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval" } 
        
        # Create the Virtual Network
        $subnet = New-AzVirtualNetworkSubnetConfig -Name $subnetName -AddressPrefix 10.0.1.0/24
        $vnet = New-AzvirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnet
        
        # Create the publicip
        $publicip = New-AzPublicIpAddress -ResourceGroupName $rgname -name $publicIpName -location $location -AllocationMethod Dynamic -DomainNameLabel $domainNameLabel

        # Create NetworkInterface
        $job = New-AzNetworkInterface -Name $nicName -ResourceGroupName $rgname -Location $location -Subnet $vnet.Subnets[0] -PublicIpAddress $publicip -AsJob
        $job | Wait-Job
        $expectedNic = Get-AzNetworkInterface -Name $nicName -ResourceGroupName $rgname

        # Create required dependencies
        $DestinationEndpoint = $expectedNic.IpConfigurations[0]
        $actualVtap = New-AzVirtualNetworkTap -ResourceGroupName $rgname -Name $rname -Location $location -DestinationNetworkInterfaceIPConfiguration $DestinationEndpoint

        $vVirtualNetworkTap = Get-AzVirtualNetworkTap -ResourceGroupName $rgname -Name $rname;
        Assert-NotNull $vVirtualNetworkTap;
        Assert-AreEqual $vVirtualNetworkTap.ResourceGroupName $actualVtap.ResourceGroupName;
        Assert-AreEqual $vVirtualNetworkTap.Name $rname;
        Assert-AreEqual $vVirtualNetworkTap.DestinationNetworkInterfaceIPConfiguration.Id $DestinationEndpoint.Id

        $list = Get-AzVirtualNetworkTap -ResourceGroupName "*"
        Assert-True { $list.Count -ge 0 }

        $list = Get-AzVirtualNetworkTap -Name "*"
        Assert-True { $list.Count -ge 0 }

        $list = Get-AzVirtualNetworkTap -ResourceGroupName "*" -Name "*"
        Assert-True { $list.Count -ge 0 }

        $vVirtualNetworkTaps = Get-AzureRmVirtualNetworkTap -ResourceGroupName $rgname;
        Assert-NotNull $vVirtualNetworkTaps;

        $vVirtualNetworkTapsAll = Get-AzureRmVirtualNetworkTap;
        Assert-NotNull $vVirtualNetworkTapsAll;

        #update the Vtap resource 
        $vVirtualNetworkTap.DestinationPort = 8888;
        Set-AzVirtualNetworkTap -VirtualNetworkTap $vVirtualNetworkTap

        $vVirtualNetworkTap = Get-AzVirtualNetworkTap -ResourceGroupName $rgname -Name $rname;
        Assert-NotNull $vVirtualNetworkTap;
        Assert-AreEqual $vVirtualNetworkTap.ResourceGroupName $actualVtap.ResourceGroupName;
        Assert-AreEqual $vVirtualNetworkTap.Name $rname;
        Assert-AreEqual $vVirtualNetworkTap.DestinationNetworkInterfaceIPConfiguration.Id $DestinationEndpoint.Id
        Assert-AreEqual $vVirtualNetworkTap.DestinationPort 8888

        # Remove VirtualNetworkTap
        $removeVirtualNetworkTap = Remove-AzVirtualNetworkTap -ResourceGroupName $rgname -Name $rname -PassThru -Force;
        Assert-AreEqual $true $removeVirtualNetworkTap;

        # Get VirtualNetworkTap should fail
        Assert-ThrowsLike { Get-AzVirtualNetworkTap -ResourceGroupName $rgname -Name $rname } "*${rname}*not found*";
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

