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
    $rglocation = "eastus2euap";
    $rname = Get-ResourceName;
    $location = Get-ProviderLocation "Microsoft.Network/privateLinkServices" "eastus2euap";
    # Dependency parameters
    $IpConfigurationName = "IpConfigurationName";

    try
    {
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $rglocation;

        # Create Virtual networks
        $frontendSubnet = New-AzVirtualNetworkSubnetConfig -Name "frontendSubnet" -AddressPrefix "10.0.1.0/24";
        $backendSubnet = New-AzVirtualNetworkSubnetConfig -Name "backendSubnet" -AddressPrefix "10.0.2.0/24";
        $otherSubnet = New-AzVirtualNetworkSubnetConfig -Name "otherSubnet" -AddressPrefix "10.0.3.0/24"; 
        $vnet = New-AzVirtualNetwork -Name "vnet" -ResourceGroupName $rgname -Location $location -AddressPrefix "10.0.0.0/16" -Subnet $frontendSubnet,$backendSubnet,$otherSubnet;

        # Create LoadBalancer
        $frontendIP = New-AzLoadBalancerFrontendIpConfig -Name "LB-Frontend" -PrivateIpAddress 10.0.1.5 -SubnetId $vnet.subnets[0].Id;
        $beaddresspool= New-AzLoadBalancerBackendAddressPoolConfig -Name "LB-backend";
        $LB = New-AzLoadBalancer -ResourceGroupName $rgname -Name "LB" -Location $location -FrontendIpConfiguration $frontendIP -BackendAddressPool $beaddresspool -Sku Standard;
        
        # Create required dependencies
        $IpConfiguration = New-AzPrivateLinkServiceIpConfig -Name $IpConfigurationName -PrivateIpAddress 10.0.3.5 -Subnet $vnet.subnets[2];
        $LoadBalancerFrontendIpConfiguration = Get-AzLoadBalancerFrontendIpConfig -LoadBalancer $LB;
        
        # Create PrivateLinkService
        $vPrivateLinkService = New-AzPrivateLinkService -ResourceGroupName $rgName -ServiceName $rname -Location $location -IpConfiguration $IpConfiguration -LoadBalancerFrontendIpConfiguration $LoadBalancerFrontendIpConfiguration;
        Assert-NotNull $vPrivateLinkService;
        Assert-True { Check-CmdletReturnType "New-AzPrivateLinkService" $vPrivateLinkService };
        Assert-NotNull $vPrivateLinkService.IpConfigurations;
        Assert-True { $vPrivateLinkService.IpConfigurations.Length -gt 0 };
        Assert-AreEqual $rname $vPrivateLinkService.Name;

        # Get PrivateLinkService
        $vPrivateLinkService = Get-AzPrivateLinkService -ResourceGroupName $rgname -Name $rname;
        Assert-NotNull $vPrivateLinkService;
        Assert-True { Check-CmdletReturnType "Get-AzPrivateLinkService" $vPrivateLinkService };
        Assert-AreEqual $rname $vPrivateLinkService.Name;

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
        $job = Remove-AzPrivateLinkService -ResourceGroupName $rgname -ServiceName $rname -PassThru -Force -AsJob;
        $job | Wait-Job;
        $removePrivateLinkService = $job | Receive-Job;
        Assert-AreEqual $true $removePrivateLinkService;

        # Get PrivateLinkService should fail
        Assert-ThrowsLike { Get-AzPrivateLinkService -ResourceGroupName $rgname -Name $rname } "*not*found*";
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname;
    }
}

