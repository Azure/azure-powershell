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

function Check-CmdletReturnType
{
    param($cmdletName, $cmdletReturn)

    $cmdletData = Get-Command $cmdletName;
    Assert-NotNull $cmdletData;
    [array]$cmdletReturnTypes = $cmdletData.OutputType.Name | Foreach-Object { return ($_ -replace "Microsoft.Azure.Commands.Network.Models.","") };
    [array]$cmdletReturnTypes = $cmdletReturnTypes | Foreach-Object { return ($_ -replace "System.","") };
    $realReturnType = $cmdletReturn.GetType().Name -replace "Microsoft.Azure.Commands.Network.Models.","";
    return $cmdletReturnTypes -contains $realReturnType;
}

<#
.SYNOPSIS
Test creating new PrivateLinkService using minimal set of parameters
#>
function Test-PrivateLinkServiceCRUD
{
    # Setup
    $rgname = Get-ResourceGroupName;
    $rname = Get-ResourceName;
    $location = Get-ProviderLocation "Microsoft.Network/privateLinkServices" "eastus2euap";
    # Dependency parameters
    $IpConfigurationName = "IpConfigurationName";
    $vnetName = Get-ResourceName;
    $ilbFrontName = "LB-Frontend";
    $ilbBackendName = "LB-Backend";
    $ilbName = Get-ResourceName;

    try
    {
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $location;

        # Create Virtual networks
        $frontendSubnet = New-AzVirtualNetworkSubnetConfig -Name "frontendSubnet" -AddressPrefix "10.0.1.0/24";
        $backendSubnet = New-AzVirtualNetworkSubnetConfig -Name "backendSubnet" -AddressPrefix "10.0.2.0/24";
        $otherSubnet = New-AzVirtualNetworkSubnetConfig -Name "otherSubnet" -AddressPrefix "10.0.3.0/24" -PrivateLinkServiceNetworkPoliciesFlag "Disabled"; 
        $vnet = New-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix "10.0.0.0/16" -Subnet $frontendSubnet,$backendSubnet,$otherSubnet;

        # Create LoadBalancer
        $frontendIP = New-AzLoadBalancerFrontendIpConfig -Name $ilbFrontName -PrivateIpAddress "10.0.1.5" -SubnetId $vnet.subnets[0].Id;
        $beaddresspool= New-AzLoadBalancerBackendAddressPoolConfig -Name $ilbBackendName;
        $job = New-AzLoadBalancer -ResourceGroupName $rgname -Name $ilbName -Location $location -FrontendIpConfiguration $frontendIP -BackendAddressPool $beaddresspool -Sku "Standard" -AsJob;
        $job | Wait-Job
        $ilbcreate = $job | Receive-Job

        # Verfify if load balancer is created successfully
        Assert-NotNull $ilbcreate;
        Assert-AreEqual $ilbName $ilbcreate.Name;
        Assert-AreEqual $location $ilbcreate.Location;
        Assert-AreEqual "Succeeded" $ilbcreate.ProvisioningState

        # Create required dependencies
        $IpConfiguration = New-AzPrivateLinkServiceIpConfig -Name $IpConfigurationName -PrivateIpAddress 10.0.3.5 -Subnet $vnet.subnets[2];
        $LoadBalancerFrontendIpConfiguration = Get-AzLoadBalancer -Name $ilbName | Get-AzLoadBalancerFrontendIpConfig
        
        # Create PrivateLinkService
        $job = New-AzPrivateLinkService -ResourceGroupName $rgName -Name $rname -Location $location -IpConfiguration $IpConfiguration -LoadBalancerFrontendIpConfiguration $LoadBalancerFrontendIpConfiguration -AsJob;
        $job | Wait-Job
        $plscreate = $job | Receive-Job
        
        $vPrivateLinkService = Get-AzPrivateLinkService -Name $rname -ResourceGroupName $rgName
        
        # Verification
        Assert-NotNull $vPrivateLinkService;
        Assert-AreEqual $rname $vPrivateLinkService.Name;
        Assert-NotNull $vPrivateLinkService.IpConfigurations;
        Assert-True { $vPrivateLinkService.IpConfigurations.Length -gt 0 };
        Assert-AreEqual "Succeeded" $vPrivateLinkService.ProvisioningState

        # Get all PrivateLinkServices in resource group
        $listPrivateLinkService = Get-AzPrivateLinkService -ResourceGroupName $rgname;
        Assert-NotNull ($listPrivateLinkService | Where-Object { $_.ResourceGroupName -eq $rgname -and $_.Name -eq $rname });

        # Get all PrivateLinkServices in subscription
        $listPrivateLinkService = Get-AzPrivateLinkService;
        Assert-NotNull ($listPrivateLinkService | Where-Object { $_.ResourceGroupName -eq $rgname -and $_.Name -eq $rname });

        # Get all PrivateLinkServices in subscription wildcard for resource group
        $listPrivateLinkService = Get-AzPrivateLinkService -ResourceGroupName "*";
        Assert-NotNull ($listPrivateLinkService | Where-Object { $_.ResourceGroupName -eq $rgname -and $_.Name -eq $rname });

        # Get all PrivateLinkServices in subscription wildcard for name
        $listPrivateLinkService = Get-AzPrivateLinkService -Name "*";
        Assert-NotNull ($listPrivateLinkService | Where-Object { $_.ResourceGroupName -eq $rgname -and $_.Name -eq $rname });

        # Get all PrivateLinkServices in subscription wildcard for both resource group and name
        $listPrivateLinkService = Get-AzPrivateLinkService -ResourceGroupName "*" -Name "*";
        Assert-NotNull ($listPrivateLinkService | Where-Object { $_.ResourceGroupName -eq $rgname -and $_.Name -eq $rname });

        # Remove PrivateLinkService
        $job = Remove-AzPrivateLinkService -ResourceGroupName $rgname -Name $rname -PassThru -Force -AsJob;
        $job | Wait-Job;
        $removePrivateLinkService = $job | Receive-Job;
        Assert-AreEqual true $removePrivateLinkService;

        $list = Get-AzPrivateLinkService -ResourceGroupName $rgname
        Assert-AreEqual 0 @($list).Count
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname;
    }
} 

