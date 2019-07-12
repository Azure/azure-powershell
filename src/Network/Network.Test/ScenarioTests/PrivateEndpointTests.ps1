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
Test creating new PrivateEndpoint 
#>
function Test-PrivateEndpointCRUD
{
    # Setup
    $rgname = Get-ResourceGroupName;
    $rglocation = Get-ProviderLocation ResourceManagement;
    $rname = Get-ResourceName;
    $vnetName = Get-ResourceName;
    $location = Get-ProviderLocation "Microsoft.Network/privateEndpoints" "eastus2euap";
    # Dependency parameters
    $SubnetName = "SubnetName";
    $SubnetAddressPrefix = "10.0.1.0/24";
    $PrivateLinkServiceConnectionName = "PrivateLinkServiceConnectionName";
    $IpConfigurationName = "IpConfigurationName";
    $PrivateLinkServiceName = "PrivateLinkServiceName";

    try
    {
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $rglocation;

        # Create Virtual networks
        $frontendSubnet = New-AzVirtualNetworkSubnetConfig -Name "frontendSubnet" -AddressPrefix "10.0.1.0/24";
        $backendSubnet = New-AzVirtualNetworkSubnetConfig -Name "backendSubnet" -AddressPrefix "10.0.2.0/24";
        $otherSubnet = New-AzVirtualNetworkSubnetConfig -Name "otherSubnet" -AddressPrefix "10.0.3.0/24"; 
        $vnet = New-AzVirtualNetwork -Name "vnet" -ResourceGroupName $rgname -Location $rglocation -AddressPrefix "10.0.0.0/16" -Subnet $frontendSubnet,$backendSubnet,$otherSubnet;

        # Create LoadBalancer
        $frontendIP = New-AzLoadBalancerFrontendIpConfig -Name "LB-Frontend" -PrivateIpAddress 10.0.1.5 -SubnetId $vnet.subnets[0].Id;
        $beaddresspool= New-AzLoadBalancerBackendAddressPoolConfig -Name "LB-backend";
        $LB = New-AzLoadBalancer -ResourceGroupName $rgname -Name "LB" -Location $rglocation -FrontendIpConfiguration $frontendIP -BackendAddressPool $beaddresspool;
        
        # Create required dependencies for private link service
        $IpConfiguration = New-AzPrivateLinkServiceIpConfig -Name $IpConfigurationName -PrivateIpAddress 10.0.3.5 -Subnet $vnet.subnets[2];
        $LoadBalancerFrontendIpConfiguration = Get-AzLoadBalancerFrontendIpConfig -LoadBalancer $LB;
        
        # Create PrivateLinkService
        $vPrivateLinkService = New-AzPrivateLinkService -ResourceGroupName $rgname -ServiceName $PrivateLinkServiceName -Location $location -IpConfiguration $IpConfiguration -LoadBalancerFrontendIpConfiguration $LoadBalancerFrontendIpConfiguration;
        
        # Create required dependencies
        $PrivateLinkServiceConnection = New-AzPrivateLinkServiceConnection -Name $PrivateLinkServiceConnectionName -PrivateLinkServiceId  $vPrivateLinkService.Id

        # Create PrivateEndpoint
        $vPrivateEndpoint = New-AzPrivateEndpoint -ResourceGroupName $rgname -Name $rname -Location $location -Subnet $vnet.subnets[2] -PrivateLinkServiceConnection $PrivateLinkServiceConnection;
        Assert-NotNull $vPrivateEndpoint;
        Assert-True { Check-CmdletReturnType "New-AzPrivateEndpoint" $vPrivateEndpoint };
        Assert-NotNull $vPrivateEndpoint.Subnets;
        Assert-True { $vPrivateEndpoint.Subnets.Length -gt 0 };
        Assert-NotNull $vPrivateEndpoint.PrivateLinkServiceConnections;
        Assert-True { $vPrivateEndpoint.PrivateLinkServiceConnections.Length -gt 0 };
        Assert-AreEqual $rname $vPrivateEndpoint.Name;

        # Get PrivateEndpoint
        $vPrivateEndpoint = Get-AzPrivateEndpoint -ResourceGroupName $rgname -Name $rname;
        Assert-NotNull $vPrivateEndpoint;
        Assert-True { Check-CmdletReturnType "Get-AzPrivateEndpoint" $vPrivateEndpoint };
        Assert-AreEqual $rname $vPrivateEndpoint.Name;

        # Get all PrivateEndpoints in resource group
        $listPrivateEndpoint = Get-AzPrivateEndpoint -ResourceGroupName $rgname;
        Assert-NotNull ($listPrivateEndpoint | Where-Object { $_.ResourceGroupName -eq $rgname -and $_.Name -eq $rname });

        # Get all PrivateEndpoints in subscription
        $listPrivateEndpoint = Get-AzPrivateEndpoint;
        Assert-NotNull ($listPrivateEndpoint | Where-Object { $_.ResourceGroupName -eq $rgname -and $_.Name -eq $rname });

        # Get all PrivateEndpoints in subscription wildcard for resource group
        $listPrivateEndpoint = Get-AzPrivateEndpoint -ResourceGroupName "*";
        Assert-NotNull ($listPrivateEndpoint | Where-Object { $_.ResourceGroupName -eq $rgname -and $_.Name -eq $rname });

        # Get all PrivateEndpoints in subscription wildcard for name
        $listPrivateEndpoint = Get-AzPrivateEndpoint -Name "*";
        Assert-NotNull ($listPrivateEndpoint | Where-Object { $_.ResourceGroupName -eq $rgname -and $_.Name -eq $rname });

        # Get all PrivateEndpoints in subscription wildcard for both resource group and name
        $listPrivateEndpoint = Get-AzPrivateEndpoint -ResourceGroupName "*" -Name "*";
        Assert-NotNull ($listPrivateEndpoint | Where-Object { $_.ResourceGroupName -eq $rgname -and $_.Name -eq $rname });

        # Remove PrivateEndpoint
        $job = Remove-AzPrivateEndpoint -ResourceGroupName $rgname -Name $rname -PassThru -Force -AsJob;
        $job | Wait-Job;
        $removePrivateEndpoint = $job | Receive-Job;
        Assert-AreEqual $true $removePrivateEndpoint;

        # Get PrivateEndpoint should fail
        Assert-ThrowsContains { Get-AzPrivateEndpoint -ResourceGroupName $rgname -Name $rname } "not found";
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname;
    }
}
