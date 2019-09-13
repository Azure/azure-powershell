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
    $rname = Get-ResourceName;
    $location = Get-ProviderLocation "Microsoft.Network/privateEndpoints" "westcentralus";
    # Dependency parameters
    $vnetName = Get-ResourceName;
    $ilbFrontName = "LB-Frontend";
    $ilbBackendName = "LB-Backend";
    $ilbName = Get-ResourceName;
    $PrivateLinkServiceConnectionName = "PrivateLinkServiceConnectionName";
    $IpConfigurationName = "IpConfigurationName";
    $PrivateLinkServiceName = "PrivateLinkServiceName";
    $vnetPEName = "VNetPE";

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

        # Create PrivateLinkService
        $IpConfiguration = New-AzPrivateLinkServiceIpConfig -Name $IpConfigurationName -PrivateIpAddress 10.0.3.5 -Subnet $vnet.subnets[2];
        $LoadBalancerFrontendIpConfiguration = Get-AzLoadBalancer -Name $ilbName | Get-AzLoadBalancerFrontendIpConfig;

        $job = New-AzPrivateLinkService -ResourceGroupName $rgname -Name $PrivateLinkServiceName -Location $location -IpConfiguration $IpConfiguration -LoadBalancerFrontendIpConfiguration $LoadBalancerFrontendIpConfiguration -AsJob;
        $job | Wait-Job
        $plscreate = $job | Receive-Job
        $vPrivateLinkService = Get-AzPrivateLinkService -Name $PrivateLinkServiceName -ResourceGroupName $rgName

        # Verfify if private link service is created successfully
        Assert-NotNull $vPrivateLinkService;
        Assert-AreEqual $PrivateLinkServiceName $vPrivateLinkService.Name;
        Assert-NotNull $vPrivateLinkService.IpConfigurations;
        Assert-True { $vPrivateLinkService.IpConfigurations.Length -gt 0 };
        Assert-AreEqual "Succeeded" $vPrivateLinkService.ProvisioningState

        # Create virtual network for private endpoint
        $peSubnet = New-AzVirtualNetworkSubnetConfig -Name "peSubnet" -AddressPrefix "11.0.1.0/24" -PrivateEndpointNetworkPoliciesFlag "Disabled"
        $vnetPE = New-AzVirtualNetwork -Name $vnetPEName -ResourceGroupName $rgName -Location $location -AddressPrefix "11.0.0.0/16" -Subnet $peSubnet

        # Create PrivateEndpoint
        $PrivateLinkServiceConnection = New-AzPrivateLinkServiceConnection -Name $PrivateLinkServiceConnectionName -PrivateLinkServiceId  $vPrivateLinkService.Id

        $job = New-AzPrivateEndpoint -ResourceGroupName $rgname -Name $rname -Location $location -Subnet $vnetPE.subnets[0] -PrivateLinkServiceConnection $PrivateLinkServiceConnection -AsJob;
        $job | Wait-Job
        $pecreate = $job | Receive-Job
        
        $vPrivateEndpoint = Get-AzPrivateEndpoint -Name $rname -ResourceGroupName $rgname
        
        # Verification
        Assert-NotNull $vPrivateEndpoint;
        Assert-AreEqual $rname $vPrivateEndpoint.Name;
        Assert-NotNull $vPrivateEndpoint.Subnet;
        Assert-NotNull $vPrivateEndpoint.NetworkInterfaces;
        Assert-True { $vPrivateEndpoint.NetworkInterfaces.Length -gt 0 };
        Assert-AreEqual "Succeeded" $vPrivateEndpoint.ProvisioningState;

        # Verify connectivity info on associated NIC
        $nicName = ($vPrivateEndpoint.NetworkInterfaces[0].Id -split "/")[-1];
        Assert-True { $nicName -is [string] -and $nicName.Length -gt 0 };

        $nic = Get-AzNetworkInterface -ResourceGroupName $rgname -Name $nicName;
        Assert-NotNull $nic;
        Assert-NotNull $nic.PrivateEndpoint;
        Assert-AreEqual $nic.PrivateEndpoint.Id $vPrivateEndpoint.Id;
        Assert-NotNull $nic.IpConfigurations;
        Assert-True { $nic.IpConfigurations.Length -gt 0 };

        $plsProps = $nic.IpConfigurations[0].PrivateLinkConnectionProperties;
        Assert-NotNull $plsProps;
        Assert-True { $plsProps.GroupId -is [string] };
        Assert-True { $plsProps.RequiredMemberName -is [string] };
        Assert-True { $plsProps.Fqdns -is [System.Collections.Generic.List[string]] };

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
        Assert-AreEqual true $removePrivateEndpoint;

        $list = Get-AzPrivateEndpoint -ResourceGroupName $rgname
        Assert-AreEqual 0 @($list).Count

        # Remove Private Link Service
        $job = Remove-AzPrivateLinkService -ResourceGroupName $rgname -Name $PrivateLinkServiceName -PassThru -Force -AsJob;
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
