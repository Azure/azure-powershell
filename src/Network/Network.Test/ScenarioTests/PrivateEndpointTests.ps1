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

<#
.SYNOPSIS
Test creating new dns zone group 
#>
function Test-PrivateDnsZoneGroupCRUD
{
    # Setup
    $rgname = Get-ResourceGroupName;
    $rname = Get-ResourceName;
    $location = Get-ProviderLocation "Microsoft.Network/privateEndpoints" "westus";
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

        # Create PrivateLinkService
        $IpConfiguration = New-AzPrivateLinkServiceIpConfig -Name $IpConfigurationName -PrivateIpAddress 10.0.3.5 -Subnet $vnet.subnets[2];
        $LoadBalancerFrontendIpConfiguration = Get-AzLoadBalancer -Name $ilbName | Get-AzLoadBalancerFrontendIpConfig;

        $job = New-AzPrivateLinkService -ResourceGroupName $rgname -Name $PrivateLinkServiceName -Location $location -IpConfiguration $IpConfiguration -LoadBalancerFrontendIpConfiguration $LoadBalancerFrontendIpConfiguration -AsJob;
        $job | Wait-Job
        $plscreate = $job | Receive-Job
        $vPrivateLinkService = Get-AzPrivateLinkService -Name $PrivateLinkServiceName -ResourceGroupName $rgName

        # Create virtual network for private endpoint
        $peSubnet = New-AzVirtualNetworkSubnetConfig -Name "peSubnet" -AddressPrefix "11.0.1.0/24" -PrivateEndpointNetworkPoliciesFlag "Disabled"
        $vnetPE = New-AzVirtualNetwork -Name $vnetPEName -ResourceGroupName $rgName -Location $location -AddressPrefix "11.0.0.0/16" -Subnet $peSubnet

        # Create PrivateEndpoint
        $PrivateLinkServiceConnection = New-AzPrivateLinkServiceConnection -Name $PrivateLinkServiceConnectionName -PrivateLinkServiceId  $vPrivateLinkService.Id

        $job = New-AzPrivateEndpoint -ResourceGroupName $rgname -Name $rname -Location $location -Subnet $vnetPE.subnets[0] -PrivateLinkServiceConnection $PrivateLinkServiceConnection -AsJob;
        $job | Wait-Job
        $pecreate = $job | Receive-Job
        
        $vPrivateEndpoint = Get-AzPrivateEndpoint -Name $rname -ResourceGroupName $rgname
        
        # New private dns zone created by Az.PrivateDns.
        $zone1 = New-AzPrivateDnsZone -ResourceGroupName $rgname -Name "xdm.vault.azure.com"
        $config = New-AzPrivateDnsZoneConfig -Name xdm-vault-azure-com -PrivateDnsZoneId $zone1.ResourceId
        $job = New-AzPrivateDnsZoneGroup -ResourceGroupName $rgname -PrivateEndpointName $rname -name dnsgroup1 -PrivateDnsZoneConfig $config -AsJob
        $job | Wait-Job
        $dnsZoneGroup = $job | Receive-Job

        # Assert
        Assert-AreEqual $dnsZoneGroup.Name dnsgroup1
        Assert-AreEqual $dnsZoneGroup.PrivateDnsZoneConfigs[0].Name xdm-vault-azure-com
        Assert-AreEqual $dnsZoneGroup.PrivateDnsZoneConfigs[0].PrivateDnsZoneId $zone1.ResourceId

        # Update dns zone
        $zone2 = New-AzPrivateDnsZone -ResourceGroupName $rgname -Name "xdm1.vault.azure.com"
        $config1 = New-AzPrivateDnsZoneConfig -Name xdm1-vault-azure-com -PrivateDnsZoneId $zone2.ResourceId
        $job = Set-AzPrivateDnsZoneGroup -ResourceGroupName $rgname -PrivateEndpointName $rname -name dnsgroup1 -PrivateDnsZoneConfig $config1 -AsJob
        $job | Wait-Job
        $dnsZoneGroup = $job | Receive-Job

        # Assert
        Assert-AreEqual $dnsZoneGroup.Name dnsgroup1
        Assert-AreEqual $dnsZoneGroup.PrivateDnsZoneConfigs[0].Name xdm1-vault-azure-com
        Assert-AreEqual $dnsZoneGroup.PrivateDnsZoneConfigs[0].PrivateDnsZoneId $zone2.ResourceId

        # Remove zone group
        $job = Remove-AzPrivateDnsZoneGroup -ResourceGroupName $rgname -PrivateEndpointName $rname -name dnsgroup1 -PassThru -Force -AsJob
        $job | Wait-Job
        $jobResult = $job | Receive-Job;
        Assert-AreEqual true $jobResult;
        
        # Check deleted objects
        $list = Get-AzPrivateDnsZoneGroup -ResourceGroupName $rgname -PrivateEndpointName $rname
        Assert-AreEqual 0 @($list).Count

    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname;
    }
}

<#
.SYNOPSIS
Test creating a private endpoint in an edge zone. Subscriptions need to be explicitly whitelisted for access to edge zones.
#>
function Test-PrivateEndpointInEdgeZone
{
    # Setup
    $rgname = Get-ResourceGroupName
    $rname = Get-ResourceName
    $location = "westus"
    # Dependency parameters
    $vnetName = Get-ResourceName
    $ilbFrontName = "LB-Frontend"
    $ilbBackendName = "LB-Backend"
    $ilbName = Get-ResourceName
    $PrivateLinkServiceConnectionName = "PrivateLinkServiceConnectionName"
    $IpConfigurationName = "IpConfigurationName"
    $PrivateLinkServiceName = "PrivateLinkServiceName"
    $vnetPEName = "VNetPE"
    $edgeZone = "microsoftlosangeles1"

    try
    {
        New-AzResourceGroup -Name $rgname -Location $location

        # Create Virtual networks
        $frontendSubnet = New-AzVirtualNetworkSubnetConfig -Name "frontendSubnet" -AddressPrefix "10.0.1.0/24"
        $backendSubnet = New-AzVirtualNetworkSubnetConfig -Name "backendSubnet" -AddressPrefix "10.0.2.0/24"
        $otherSubnet = New-AzVirtualNetworkSubnetConfig -Name "otherSubnet" -AddressPrefix "10.0.3.0/24" -PrivateLinkServiceNetworkPoliciesFlag "Disabled"
        $vnet = New-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix "10.0.0.0/16" -Subnet $frontendSubnet,$backendSubnet,$otherSubnet -EdgeZone $edgeZone

        # Create LoadBalancer
        $frontendIP = New-AzLoadBalancerFrontendIpConfig -Name $ilbFrontName -PrivateIpAddress "10.0.1.5" -SubnetId $vnet.subnets[0].Id
        $beaddresspool= New-AzLoadBalancerBackendAddressPoolConfig -Name $ilbBackendName
        $ilbcreate = New-AzLoadBalancer -ResourceGroupName $rgname -Name $ilbName -Location $location -FrontendIpConfiguration $frontendIP -BackendAddressPool $beaddresspool -Sku "Standard" -EdgeZone $edgeZone

        # Verfify if load balancer is created successfully
        Assert-NotNull $ilbcreate
        Assert-AreEqual $ilbName $ilbcreate.Name
        Assert-AreEqual $location $ilbcreate.Location
        Assert-AreEqual "Succeeded" $ilbcreate.ProvisioningState

        # Create PrivateLinkService
        $IpConfiguration = New-AzPrivateLinkServiceIpConfig -Name $IpConfigurationName -PrivateIpAddress 10.0.3.5 -Subnet $vnet.subnets[2]
        $LoadBalancerFrontendIpConfiguration = Get-AzLoadBalancer -Name $ilbName | Get-AzLoadBalancerFrontendIpConfig

        $vPrivateLinkService = New-AzPrivateLinkService -ResourceGroupName $rgname -Name $PrivateLinkServiceName -Location $location -IpConfiguration $IpConfiguration -LoadBalancerFrontendIpConfiguration $LoadBalancerFrontendIpConfiguration -EdgeZone $edgeZone

        # Verfify if private link service is created successfully
        Assert-NotNull $vPrivateLinkService
        Assert-AreEqual $PrivateLinkServiceName $vPrivateLinkService.Name
        Assert-NotNull $vPrivateLinkService.IpConfigurations;
        Assert-True { $vPrivateLinkService.IpConfigurations.Length -gt 0 }
        Assert-AreEqual "Succeeded" $vPrivateLinkService.ProvisioningState

        # Create virtual network for private endpoint
        $peSubnet = New-AzVirtualNetworkSubnetConfig -Name "peSubnet" -AddressPrefix "11.0.1.0/24" -PrivateEndpointNetworkPoliciesFlag "Disabled"
        $vnetPE = New-AzVirtualNetwork -Name $vnetPEName -ResourceGroupName $rgName -Location $location -AddressPrefix "11.0.0.0/16" -Subnet $peSubnet -EdgeZone $edgeZone

        # Create PrivateEndpoint
        $PrivateLinkServiceConnection = New-AzPrivateLinkServiceConnection -Name $PrivateLinkServiceConnectionName -PrivateLinkServiceId  $vPrivateLinkService.Id
        New-AzPrivateEndpoint -ResourceGroupName $rgname -Name $rname -Location $location -Subnet $vnetPE.subnets[0] -PrivateLinkServiceConnection $PrivateLinkServiceConnection -EdgeZone $edgeZone

        $vPrivateEndpoint = Get-AzPrivateEndpoint -Name $rname -ResourceGroupName $rgname

        Assert-AreEqual $vPrivateEndpoint.ExtendedLocation.Name $edgeZone
        Assert-AreEqual $vPrivateEndpoint.ExtendedLocation.Type "EdgeZone"
    }
    catch [Microsoft.Azure.Commands.Network.Common.NetworkCloudException]
    {
        Assert-NotNull { $_.Exception.Message -match 'Resource type .* does not support edge zone .* in location .* The supported edge zones are .*' }
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Test ApplicationSecurityGroup property of the private endpoint.
It is qualified to pass ApplicationSecurityGroup as input parameter while updating the ApplicationSecurityGroup as well as its underneath properties is not allowed
#>
function Test-PrivateEndpointApplicationSecurityGroup
{
    # Setup
    $rgname = Get-ResourceGroupName
    $rname = Get-ResourceName
    $location = "eastus"
    # Dependency parameters
    $vnetName = Get-ResourceName
    $nlbFrontName = "LB-Frontend"
    $nlbBackendName = "LB-Backend"
    $nlbName = Get-ResourceName
    $plsName = "PrivateLinkServiceName"
    $plsConnectionName = "PrivateLinkServiceConnectionName"
    $IpConfigurationName = "IpConfigurationName"
    $vnetPEName = "VNetPE"

    try
    {
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $location

        # Create Virtual networks
        $frontendSubnet = New-AzVirtualNetworkSubnetConfig -Name "frontendSubnet" -AddressPrefix "10.0.1.0/24"
        $backendSubnet = New-AzVirtualNetworkSubnetConfig -Name "backendSubnet" -AddressPrefix "10.0.2.0/24"
        $otherSubnet = New-AzVirtualNetworkSubnetConfig -Name "otherSubnet" -AddressPrefix "10.0.3.0/24" -PrivateLinkServiceNetworkPoliciesFlag "Disabled"
        $vnet = New-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix "10.0.0.0/16" -Subnet $frontendSubnet,$backendSubnet,$otherSubnet

        # Create LoadBalancer
        $frontendIP = New-AzLoadBalancerFrontendIpConfig -Name $nlbFrontName -PrivateIpAddress "10.0.1.5" -SubnetId $vnet.subnets[0].Id
        $beaddresspool= New-AzLoadBalancerBackendAddressPoolConfig -Name $nlbBackendName;
        $job = New-AzLoadBalancer -ResourceGroupName $rgname -Name $nlbName -Location $location -FrontendIpConfiguration $frontendIP -BackendAddressPool $beaddresspool -Sku "Standard" -AsJob
        $job | Wait-Job
        $nlbcreate = $job | Receive-Job

        # Verfify if load balancer is created successfully
        Assert-NotNull $nlbcreate
        Assert-AreEqual $nlbName $nlbcreate.Name
        Assert-AreEqual $location $nlbcreate.Location
        Assert-AreEqual "Succeeded" $nlbcreate.ProvisioningState

        # Create PrivateLinkService
        $IpConfiguration = New-AzPrivateLinkServiceIpConfig -Name $IpConfigurationName -PrivateIpAddress 10.0.3.5 -Subnet $vnet.subnets[2]
        $LoadBalancerFrontendIpConfiguration = Get-AzLoadBalancer -Name $nlbName | Get-AzLoadBalancerFrontendIpConfig

        $job = New-AzPrivateLinkService -ResourceGroupName $rgname -Name $plsName -Location $location -IpConfiguration $IpConfiguration -LoadBalancerFrontendIpConfiguration $LoadBalancerFrontendIpConfiguration -AsJob
        $job | Wait-Job
        $plscreate = $job | Receive-Job
        $pls = Get-AzPrivateLinkService -Name $plsName -ResourceGroupName $rgName

        # Verfify if private link service is created successfully
        Assert-NotNull $pls
        Assert-AreEqual $plsName $pls.Name
        Assert-NotNull $pls.IpConfigurations
        Assert-True { $pls.IpConfigurations.Length -gt 0 }
        Assert-AreEqual "Succeeded" $pls.ProvisioningState

        # Create virtual network for private endpoint
        $peSubnet = New-AzVirtualNetworkSubnetConfig -Name "peSubnet" -AddressPrefix "11.0.1.0/24" -PrivateEndpointNetworkPoliciesFlag "Disabled"
        $vnetPE = New-AzVirtualNetwork -Name $vnetPEName -ResourceGroupName $rgName -Location $location -AddressPrefix "11.0.0.0/16" -Subnet $peSubnet

        # Create application security groups for private endpoint
        $asg1 = New-AzApplicationSecurityGroup -Name "ApplicationSecurityGroupName1" -ResourceGroupName $rgname -Location $location
        $asg2 = New-AzApplicationSecurityGroup -Name "ApplicationSecurityGroupName2" -ResourceGroupName $rgname -Location $location

        # Create PrivateEndpoint
        $plsConnection = New-AzPrivateLinkServiceConnection -Name $plsConnectionName -PrivateLinkServiceId  $pls.Id

        $job = New-AzPrivateEndpoint -ResourceGroupName $rgname -Name $rname -Location $location -Subnet $vnetPE.subnets[0] -PrivateLinkServiceConnection $plsConnection -ApplicationSecurityGroup $asg1,$asg2 -AsJob
        $job | Wait-Job
        $pecreate = $job | Receive-Job
        
        $pe = Get-AzPrivateEndpoint -Name $rname -ResourceGroupName $rgname
        
        # Verification for New-
        Assert-NotNull $pe
        Assert-AreEqual $rname $pe.Name
        Assert-AreEqual "Succeeded" $pe.ProvisioningState
        Assert-NotNull $pe.ApplicationSecurityGroups
        Assert-True { $pe.ApplicationSecurityGroups.Count -eq 2 }
        foreach ($asg in $pe.ApplicationSecurityGroups)
        {
            Assert-NotNull $asg.Id
        }

        # Add application security group
        $asgNew = New-AzApplicationSecurityGroup -Name "ApplicationSecurityGroupNew" -ResourceGroupName $rgname -Location $location
        $pe.ApplicationSecurityGroups.Add($asgNew)
        Set-AzPrivateEndpoint -PrivateEndpoint $pe
        # Verification after Set-
        $pe = Get-AzPrivateEndpoint -Name $rname -ResourceGroupName $rgname
        Assert-AreEqual 3 $pe.ApplicationSecurityGroups.Count
        Assert-AreEqual $asgNew.Id $pe.ApplicationSecurityGroups[2].Id

        # Remove application security group
        $asg0 = $pe.ApplicationSecurityGroups[0]
        $asg0Id = $asg0.Id
        $pe.ApplicationSecurityGroups.Remove($asg0)
        Set-AzPrivateEndpoint -PrivateEndpoint $pe
        # Verify after Set-
        $pe = Get-AzPrivateEndpoint -Name $rname -ResourceGroupName $rgname
        Assert-AreEqual 2 $pe.ApplicationSecurityGroups.Count
        foreach ($asg in $pe.ApplicationSecurityGroups)
        {
            Assert-AreNotEqual $asg0Id $asg.Name
        }

        # Assign application security group
        $asg = New-AzApplicationSecurityGroup -Name "ApplicationSecurityGroup" -ResourceGroupName $rgname -Location $location
        $pe.ApplicationSecurityGroups = $asg
        Set-AzPrivateEndpoint -PrivateEndpoint $pe
        # Verification after Set-
        $pe = Get-AzPrivateEndpoint -Name $rname -ResourceGroupName $rgname
        Assert-AreEqual 1 $pe.ApplicationSecurityGroups.Count
        Assert-AreEqual $asg.Id $pe.ApplicationSecurityGroups[0].Id
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

    <#
.SYNOPSIS
Test IpConfiguration property of the private endpoint.
It is qualified to pass IpConfiguration as input parameter while updating the IpConfiguration as well as its underneath properties is not allowed
#>
function Test-PrivateEndpointIpConfiguration
{
    # Setup
    $rgname = Get-ResourceGroupName
    $rname = Get-ResourceName
    $location = "eastus"
    # Dependency parameters
    $vnetName = Get-ResourceName
    $nlbFrontName = "LB-Frontend"
    $nlbBackendName = "LB-Backend"
    $nlbName = Get-ResourceName
    $plsName = "PrivateLinkServiceName"
    $plsConnectionName = "PrivateLinkServiceConnectionName"
    $IpConfigurationName = "IpConfigurationName"
    $vnetPEName = "VNetPE"

    try
    {
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $location

        # Create Virtual networks
        $frontendSubnet = New-AzVirtualNetworkSubnetConfig -Name "frontendSubnet" -AddressPrefix "10.0.1.0/24"
        $backendSubnet = New-AzVirtualNetworkSubnetConfig -Name "backendSubnet" -AddressPrefix "10.0.2.0/24"
        $otherSubnet = New-AzVirtualNetworkSubnetConfig -Name "otherSubnet" -AddressPrefix "10.0.3.0/24" -PrivateLinkServiceNetworkPoliciesFlag "Disabled"
        $vnet = New-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix "10.0.0.0/16" -Subnet $frontendSubnet,$backendSubnet,$otherSubnet

        # Create LoadBalancer
        $frontendIP = New-AzLoadBalancerFrontendIpConfig -Name $nlbFrontName -PrivateIpAddress "10.0.1.5" -SubnetId $vnet.subnets[0].Id
        $beaddresspool= New-AzLoadBalancerBackendAddressPoolConfig -Name $nlbBackendName;
        $job = New-AzLoadBalancer -ResourceGroupName $rgname -Name $nlbName -Location $location -FrontendIpConfiguration $frontendIP -BackendAddressPool $beaddresspool -Sku "Standard" -AsJob
        $job | Wait-Job
        $nlbcreate = $job | Receive-Job

        # Verfify if load balancer is created successfully
        Assert-NotNull $nlbcreate
        Assert-AreEqual $nlbName $nlbcreate.Name
        Assert-AreEqual $location $nlbcreate.Location
        Assert-AreEqual "Succeeded" $nlbcreate.ProvisioningState

        # Create PrivateLinkService
        $IpConfiguration = New-AzPrivateLinkServiceIpConfig -Name $IpConfigurationName -PrivateIpAddress 10.0.3.5 -Subnet $vnet.subnets[2]
        $LoadBalancerFrontendIpConfiguration = Get-AzLoadBalancer -Name $nlbName | Get-AzLoadBalancerFrontendIpConfig

        $job = New-AzPrivateLinkService -ResourceGroupName $rgname -Name $plsName -Location $location -IpConfiguration $IpConfiguration -LoadBalancerFrontendIpConfiguration $LoadBalancerFrontendIpConfiguration -AsJob
        $job | Wait-Job
        $plscreate = $job | Receive-Job
        $pls = Get-AzPrivateLinkService -Name $plsName -ResourceGroupName $rgName

        # Verfify if private link service is created successfully
        Assert-NotNull $pls
        Assert-AreEqual $plsName $pls.Name
        Assert-NotNull $pls.IpConfigurations
        Assert-True { $pls.IpConfigurations.Length -gt 0 }
        Assert-AreEqual "Succeeded" $pls.ProvisioningState

        # Create virtual network for private endpoint
        $peSubnet = New-AzVirtualNetworkSubnetConfig -Name "peSubnet" -AddressPrefix "11.0.1.0/24" -PrivateEndpointNetworkPoliciesFlag "Disabled"
        $vnetPE = New-AzVirtualNetwork -Name $vnetPEName -ResourceGroupName $rgName -Location $location -AddressPrefix "11.0.0.0/16" -Subnet $peSubnet

        # Create ip configuration for private endpoint
        $ipconfig = New-AzPrivateEndpointIpConfiguration -Name "IpConfiguration" -PrivateIpAddress "11.0.1.100"

        # Create PrivateEndpoint
        $plsConnection = New-AzPrivateLinkServiceConnection -Name $plsConnectionName -PrivateLinkServiceId  $pls.Id

        $job = New-AzPrivateEndpoint -ResourceGroupName $rgname -Name $rname -Location $location -Subnet $vnetPE.subnets[0] -PrivateLinkServiceConnection $plsConnection -IpConfiguration $ipconfig -AsJob
        $job | Wait-Job
        $pecreate = $job | Receive-Job
        
        $pe = Get-AzPrivateEndpoint -Name $rname -ResourceGroupName $rgname
        
        # Verification for New-
        Assert-NotNull $pe
        Assert-AreEqual $rname $pe.Name
        Assert-AreEqual "Succeeded" $pe.ProvisioningState
        Assert-AreEqual "IpConfiguration" $pe.IpConfigurations[0].Name
        Assert-AreEqual "11.0.1.100" $pe.IpConfigurations[0].PrivateIPAddress

        # Update properties of IpConfiguration for the private endpoint
        Assert-ThrowsLike { $pe.IpConfigurations[0].PrivateIPAddress = "pipaddress" } "* is a ReadOnly property."
        $pe.IpConfigurations[0].Name = "IpConfiguration-Updated"
        $pe.IpConfigurations[0].GroupId = "IpConfiguration-Updated-GroupId"
        $pe.IpConfigurations[0].MemberName = "IpConfiguration-Updated-MemberName"
        Set-AzPrivateEndpoint -PrivateEndpoint $pe
        # Verify after Set-
        $pe = Get-AzPrivateEndpoint -Name $rname -ResourceGroupName $rgname
        Assert-AreEqual "IpConfiguration-Updated" $pe.IpConfigurations[0].Name
        Assert-AreEqual "IpConfiguration-Updated-GroupId" $pe.IpConfigurations[0].GroupId
        Assert-AreEqual "IpConfiguration-Updated-MemberName" $pe.IpConfigurations[0].MemberName
        Assert-AreEqual "11.0.1.100" $pe.IpConfigurations[0].PrivateIPAddress

        # Add ip configuration
        $ipcfgNew = New-AzPrivateEndpointIpConfiguration -Name "IpConfiguration-New" -GroupId "IpConfiguration-New-GroupId" -MemberName "IpConfiguration-New-MemberName" -PrivateIpAddress "11.0.1.101"
        $pe.IpConfigurations.Add($ipcfgNew)
        Set-AzPrivateEndpoint -PrivateEndpoint $pe
        # Verification after Set-
        $pe = Get-AzPrivateEndpoint -Name $rname -ResourceGroupName $rgname
        Assert-AreEqual 2 $pe.IpConfigurations.Count
        Assert-AreEqual $ipcfgNew.Name $pe.IpConfigurations[1].Name
        Assert-AreEqual $ipcfgNew.GroupId $pe.IpConfigurations[1].GroupId
        Assert-AreEqual $ipcfgNew.MemberName $pe.IpConfigurations[1].MemberName
        Assert-AreEqual $ipcfgNew.PrivateIPAddress $pe.IpConfigurations[1].PrivateIPAddress

        # Remove ip configuration
        $ipcfg0 = $pe.IpConfigurations[0]
        $ipcfg0Name = $ipcfg0.Name
        $pe.IpConfigurations.Remove($ipcfg0)
        Set-AzPrivateEndpoint -PrivateEndpoint $pe
        # Verify after Set-
        $pe = Get-AzPrivateEndpoint -Name $rname -ResourceGroupName $rgname
        Assert-AreEqual 1 $pe.IpConfigurations.Count
        foreach ($ipcfg in $pe.IpConfigurations)
        {
            Assert-AreNotEqual $ipcfg.Name $ipcfg0Name.Name
        }

        # Assign ip configuration
        $ipcfg = New-AzPrivateEndpointIpConfiguration -Name "pe-ipcfg" -GroupId "pe-ipcfg-groupid" -MemberName "pe-ipcfg-membername" -PrivateIpAddress "11.0.1.111"
        $pe.IpConfigurations = $ipcfg
        Set-AzPrivateEndpoint -PrivateEndpoint $pe
        # Verification after Set-
        $pe = Get-AzPrivateEndpoint -Name $rname -ResourceGroupName $rgname
        Assert-AreEqual 1 $pe.IpConfigurations.Count
        Assert-AreEqual $ipcfg.Name $pe.IpConfigurations[0].Name
        Assert-AreEqual $ipcfg.GroupId $pe.IpConfigurations[0].GroupId
        Assert-AreEqual $ipcfg.MemberName $pe.IpConfigurations[0].MemberName
        Assert-AreEqual $ipcfg.PrivateIPAddress $pe.IpConfigurations[0].PrivateIPAddress
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

    <#
.SYNOPSIS
Test CustomNetworkInterfaceName property of the private endpoint.
It is qualified to pass CustomNetworkInterfaceName as input parameter while updating the CustomNetworkInterfaceName is not allowed
#>
function Test-PrivateEndpointCustomNetworkInterfaceName
{
    # Setup
    $rgname = Get-ResourceGroupName
    $rname = Get-ResourceName
    $location = "eastus"
    # Dependency parameters
    $vnetName = Get-ResourceName
    $nlbFrontName = "LB-Frontend"
    $nlbBackendName = "LB-Backend"
    $nlbName = Get-ResourceName
    $plsName = "PrivateLinkServiceName"
    $plsConnectionName = "PrivateLinkServiceConnectionName"
    $IpConfigurationName = "IpConfigurationName"
    $vnetPEName = "VNetPE"

    try
    {
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $location

        # Create Virtual networks
        $frontendSubnet = New-AzVirtualNetworkSubnetConfig -Name "frontendSubnet" -AddressPrefix "10.0.1.0/24"
        $backendSubnet = New-AzVirtualNetworkSubnetConfig -Name "backendSubnet" -AddressPrefix "10.0.2.0/24"
        $otherSubnet = New-AzVirtualNetworkSubnetConfig -Name "otherSubnet" -AddressPrefix "10.0.3.0/24" -PrivateLinkServiceNetworkPoliciesFlag "Disabled"
        $vnet = New-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix "10.0.0.0/16" -Subnet $frontendSubnet,$backendSubnet,$otherSubnet

        # Create LoadBalancer
        $frontendIP = New-AzLoadBalancerFrontendIpConfig -Name $nlbFrontName -PrivateIpAddress "10.0.1.5" -SubnetId $vnet.subnets[0].Id
        $beaddresspool= New-AzLoadBalancerBackendAddressPoolConfig -Name $nlbBackendName;
        $job = New-AzLoadBalancer -ResourceGroupName $rgname -Name $nlbName -Location $location -FrontendIpConfiguration $frontendIP -BackendAddressPool $beaddresspool -Sku "Standard" -AsJob
        $job | Wait-Job
        $nlbcreate = $job | Receive-Job

        # Verfify if load balancer is created successfully
        Assert-NotNull $nlbcreate
        Assert-AreEqual $nlbName $nlbcreate.Name
        Assert-AreEqual $location $nlbcreate.Location
        Assert-AreEqual "Succeeded" $nlbcreate.ProvisioningState

        # Create PrivateLinkService
        $IpConfiguration = New-AzPrivateLinkServiceIpConfig -Name $IpConfigurationName -PrivateIpAddress 10.0.3.5 -Subnet $vnet.subnets[2]
        $LoadBalancerFrontendIpConfiguration = Get-AzLoadBalancer -Name $nlbName | Get-AzLoadBalancerFrontendIpConfig

        $job = New-AzPrivateLinkService -ResourceGroupName $rgname -Name $plsName -Location $location -IpConfiguration $IpConfiguration -LoadBalancerFrontendIpConfiguration $LoadBalancerFrontendIpConfiguration -AsJob
        $job | Wait-Job
        $plscreate = $job | Receive-Job
        $pls = Get-AzPrivateLinkService -Name $plsName -ResourceGroupName $rgName

        # Verfify if private link service is created successfully
        Assert-NotNull $pls
        Assert-AreEqual $plsName $pls.Name
        Assert-NotNull $pls.IpConfigurations
        Assert-True { $pls.IpConfigurations.Length -gt 0 }
        Assert-AreEqual "Succeeded" $pls.ProvisioningState

        # Create virtual network for private endpoint
        $peSubnet = New-AzVirtualNetworkSubnetConfig -Name "peSubnet" -AddressPrefix "11.0.1.0/24" -PrivateEndpointNetworkPoliciesFlag "Disabled"
        $vnetPE = New-AzVirtualNetwork -Name $vnetPEName -ResourceGroupName $rgName -Location $location -AddressPrefix "11.0.0.0/16" -Subnet $peSubnet

        # Create PrivateEndpoint with custom network interface name
        $plsConnection = New-AzPrivateLinkServiceConnection -Name $plsConnectionName -PrivateLinkServiceId  $pls.Id

        $job = New-AzPrivateEndpoint -ResourceGroupName $rgname -Name $rname -Location $location -Subnet $vnetPE.subnets[0] -PrivateLinkServiceConnection $plsConnection -CustomNetworkInterfaceName "CustomNetworkInterfaceName" -AsJob
        $job | Wait-Job
        $pecreate = $job | Receive-Job
        
        $pe = Get-AzPrivateEndpoint -Name $rname -ResourceGroupName $rgname
        
        # Verification for New-
        Assert-NotNull $pe
        Assert-AreEqual $rname $pe.Name
        Assert-AreEqual "Succeeded" $pe.ProvisioningState
        Assert-AreEqual "CustomNetworkInterfaceName" $pe.CustomNetworkInterfaceName

        # Update custom network interface name for the private endpoint
        Assert-ThrowsLike  { $pe.CustomNetworkInterfaceName = "testcustomnetworkinterfacename" } "* is a ReadOnly property."

        # Verfication after Set-
        $pe | Set-AzPrivateEndpoint
        $pe = Get-AzPrivateEndpoint -Name $rname -ResourceGroupName $rgname
        Assert-NotNull $pe
        Assert-AreEqual "CustomNetworkInterfaceName" $pe.CustomNetworkInterfaceName
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}