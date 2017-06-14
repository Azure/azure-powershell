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
Tests creating a public Load balancer.
#>
function Test-LoadBalancerCRUD-Public
{
    # Setup
    $rgname = Get-ResourceGroupName
    $vnetName = Get-ResourceName
    $subnetName = Get-ResourceName
    $publicIpName = Get-ResourceName
    $domainNameLabel = Get-ResourceName
    $lbName = Get-ResourceName
    $frontendName = Get-ResourceName
    $backendAddressPoolName = Get-ResourceName
    $probeName = Get-ResourceName
    $inboundNatRuleName = Get-ResourceName
    $lbruleName = Get-ResourceName
    $rglocation = Get-ProviderLocation ResourceManagement
    $resourceTypeParent = "Microsoft.Network/loadBalancers"
    $location = Get-ProviderLocation $resourceTypeParent
    
    try 
    {
        # Create the resource group
        $resourceGroup = New-AzureRmResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval"} 
        
        # Create the Virtual Network
        $subnet = New-AzureRmVirtualNetworkSubnetConfig -Name $subnetName -AddressPrefix 10.0.1.0/24
        $vnet = New-AzureRmvirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnet
        
        # Create the publicip
        $publicip = New-AzureRmPublicIpAddress -ResourceGroupName $rgname -name $publicIpName -location $location -AllocationMethod Dynamic -DomainNameLabel $domainNameLabel

        # Create LoadBalancer
        $frontend = New-AzureRmLoadBalancerFrontendIpConfig -Name $frontendName -PublicIpAddress $publicip
        $backendAddressPool = New-AzureRmLoadBalancerBackendAddressPoolConfig -Name $backendAddressPoolName
        $probe = New-AzureRmLoadBalancerProbeConfig -Name $probeName -RequestPath healthcheck.aspx -Protocol http -Port 80 -IntervalInSeconds 15 -ProbeCount 2
        $inboundNatRule = New-AzureRmLoadBalancerInboundNatRuleConfig -Name $inboundNatRuleName -FrontendIPConfiguration $frontend -Protocol Tcp -FrontendPort 3389 -BackendPort 3389 -IdleTimeoutInMinutes 15 -EnableFloatingIP
        $lbrule = New-AzureRmLoadBalancerRuleConfig -Name $lbruleName -FrontendIPConfiguration $frontend -BackendAddressPool $backendAddressPool -Probe $probe -Protocol Tcp -FrontendPort 80 -BackendPort 80 -IdleTimeoutInMinutes 15 -EnableFloatingIP -LoadDistribution SourceIP
        $actualLb = New-AzureRmLoadBalancer -Name $lbName -ResourceGroupName $rgname -Location $location -FrontendIpConfiguration $frontend -BackendAddressPool $backendAddressPool -Probe $probe -InboundNatRule $inboundNatRule -LoadBalancingRule $lbrule
        
        $expectedLb = Get-AzureRmLoadBalancer -Name $lbName -ResourceGroupName $rgname

        # Verification
        Assert-AreEqual $expectedLb.ResourceGroupName $actualLb.ResourceGroupName
        Assert-AreEqual $expectedLb.Name $actualLb.Name
        Assert-AreEqual $expectedLb.Location $actualLb.Location
        Assert-AreEqual "Succeeded" $expectedLb.ProvisioningState
        Assert-NotNull $expectedLb.ResourceGuid
        Assert-AreEqual 1 @($expectedLb.FrontendIPConfigurations).Count
        
        Assert-AreEqual $frontendName $expectedLb.FrontendIPConfigurations[0].Name
        Assert-AreEqual $publicip.Id $expectedLb.FrontendIPConfigurations[0].PublicIpAddress.Id
        Assert-Null $expectedLb.FrontendIPConfigurations[0].PrivateIpAddress

        Assert-AreEqual $backendAddressPoolName $expectedLb.BackendAddressPools[0].Name

        Assert-AreEqual $probeName $expectedLb.Probes[0].Name
        Assert-AreEqual $probe.RequestPath $expectedLb.Probes[0].RequestPath

        Assert-AreEqual $inboundNatRuleName $expectedLb.InboundNatRules[0].Name
        Assert-AreEqual $expectedLb.FrontendIPConfigurations[0].Id $expectedLb.InboundNatRules[0].FrontendIPConfiguration.Id

        Assert-AreEqual $lbruleName $expectedLb.LoadBalancingRules[0].Name
        Assert-AreEqual $expectedLb.FrontendIPConfigurations[0].Id $expectedLb.LoadBalancingRules[0].FrontendIPConfiguration.Id
        Assert-AreEqual $expectedLb.BackendAddressPools[0].Id $expectedLb.LoadBalancingRules[0].BackendAddressPool.Id

        # List
        $list = Get-AzureRmLoadBalancer -ResourceGroupName $rgname
        Assert-AreEqual 1 @($list).Count
        Assert-AreEqual $expectedLb.Etag $list[0].Etag
        Assert-AreEqual $expectedLb.FrontendIPConfigurations[0].Etag $list[0].FrontendIPConfigurations[0].Etag
        Assert-AreEqual $expectedLb.BackendAddressPools[0].Etag $list[0].BackendAddressPools[0].Etag
        Assert-AreEqual $expectedLb.InboundNatRules[0].Etag $list[0].InboundNatRules[0].Etag
        Assert-AreEqual $expectedLb.Probes[0].Etag $list[0].Probes[0].Etag
        Assert-AreEqual $expectedLb.LoadBalancingRules[0].Etag $list[0].LoadBalancingRules[0].Etag

        # Delete
        $deleteLb = Remove-AzureRmLoadBalancer -Name $lbName -ResourceGroupName $rgname -PassThru -Force
        Assert-AreEqual true $deleteLb
        
        $list = Get-AzureRmLoadBalancer -ResourceGroupName $rgname
        Assert-AreEqual 0 @($list).Count
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Tests creating an internal Load balancer with dynamic ip.
#>
function Test-LoadBalancerCRUD-InternalDynamic
{
    # Setup
    $rgname = Get-ResourceGroupName
    $vnetName = Get-ResourceName
    $subnetName = Get-ResourceName
    $publicIpName = Get-ResourceName
    $domainNameLabel = Get-ResourceName
    $lbName = Get-ResourceName
    $frontendName = Get-ResourceName
    $backendAddressPoolName = Get-ResourceName
    $probeName = Get-ResourceName
    $inboundNatRuleName = Get-ResourceName
    $lbruleName = Get-ResourceName
    $rglocation = Get-ProviderLocation ResourceManagement
    $resourceTypeParent = "Microsoft.Network/loadBalancers"
    $location = Get-ProviderLocation $resourceTypeParent
    
    try 
    {
        # Create the resource group
        $resourceGroup = New-AzureRmResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval"} 
        
        # Create the Virtual Network
        $subnet = New-AzureRmVirtualNetworkSubnetConfig -Name $subnetName -AddressPrefix 10.0.1.0/24
        $vnet = New-AzureRmvirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnet
        
        # Create the publicip
        $publicip = New-AzureRmPublicIpAddress -ResourceGroupName $rgname -name $publicIpName -location $location -AllocationMethod Dynamic -DomainNameLabel $domainNameLabel

        # Create LoadBalancer
        $frontend = New-AzureRmLoadBalancerFrontendIpConfig -Name $frontendName -Subnet $vnet.Subnets[0]
        $backendAddressPool = New-AzureRmLoadBalancerBackendAddressPoolConfig -Name $backendAddressPoolName
        $probe = New-AzureRmLoadBalancerProbeConfig -Name $probeName -RequestPath healthcheck.aspx -Protocol http -Port 80 -IntervalInSeconds 15 -ProbeCount 2
        $inboundNatRule = New-AzureRmLoadBalancerInboundNatRuleConfig -Name $inboundNatRuleName -FrontendIPConfiguration $frontend -Protocol Tcp -FrontendPort 3389 -BackendPort 3389 -IdleTimeoutInMinutes 15 -EnableFloatingIP
        $lbrule = New-AzureRmLoadBalancerRuleConfig -Name $lbruleName -FrontendIPConfiguration $frontend -BackendAddressPool $backendAddressPool -Probe $probe -Protocol Tcp -FrontendPort 80 -BackendPort 80 -IdleTimeoutInMinutes 15 -EnableFloatingIP -LoadDistribution SourceIP
        $actualLb = New-AzureRmLoadBalancer -Name $lbName -ResourceGroupName $rgname -Location $location -FrontendIpConfiguration $frontend -BackendAddressPool $backendAddressPool -Probe $probe -InboundNatRule $inboundNatRule -LoadBalancingRule $lbrule
        
        $expectedLb = Get-AzureRmLoadBalancer -Name $lbName -ResourceGroupName $rgname

        # Verification
        Assert-AreEqual $expectedLb.ResourceGroupName $actualLb.ResourceGroupName
        Assert-AreEqual $expectedLb.Name $actualLb.Name
        Assert-AreEqual $expectedLb.Location $actualLb.Location
        Assert-AreEqual "Succeeded" $expectedLb.ProvisioningState
        Assert-AreEqual 1 @($expectedLb.FrontendIPConfigurations).Count
        
        Assert-AreEqual $frontendName $expectedLb.FrontendIPConfigurations[0].Name
        Assert-AreEqual $vnet.Subnets[0].Id $expectedLb.FrontendIPConfigurations[0].Subnet.Id
        Assert-NotNull $expectedLb.FrontendIPConfigurations[0].PrivateIpAddress

        Assert-AreEqual $backendAddressPoolName $expectedLb.BackendAddressPools[0].Name

        Assert-AreEqual $probeName $expectedLb.Probes[0].Name
        Assert-AreEqual $probe.RequestPath $expectedLb.Probes[0].RequestPath

        Assert-AreEqual $inboundNatRuleName $expectedLb.InboundNatRules[0].Name
        Assert-AreEqual $expectedLb.FrontendIPConfigurations[0].Id $expectedLb.InboundNatRules[0].FrontendIPConfiguration.Id

        Assert-AreEqual $lbruleName $expectedLb.LoadBalancingRules[0].Name
        Assert-AreEqual $expectedLb.FrontendIPConfigurations[0].Id $expectedLb.LoadBalancingRules[0].FrontendIPConfiguration.Id
        Assert-AreEqual $expectedLb.BackendAddressPools[0].Id $expectedLb.LoadBalancingRules[0].BackendAddressPool.Id

        # List
        $list = Get-AzureRmLoadBalancer -ResourceGroupName $rgname
        Assert-AreEqual 1 @($list).Count
        Assert-AreEqual $expectedLb.Etag $list[0].Etag
        Assert-AreEqual $expectedLb.FrontendIPConfigurations[0].Etag $list[0].FrontendIPConfigurations[0].Etag
        Assert-AreEqual $expectedLb.BackendAddressPools[0].Etag $list[0].BackendAddressPools[0].Etag
        Assert-AreEqual $expectedLb.InboundNatRules[0].Etag $list[0].InboundNatRules[0].Etag
        Assert-AreEqual $expectedLb.Probes[0].Etag $list[0].Probes[0].Etag
        Assert-AreEqual $expectedLb.LoadBalancingRules[0].Etag $list[0].LoadBalancingRules[0].Etag

        # Delete
        $deleteLb = Remove-AzureRmLoadBalancer -Name $lbName -ResourceGroupName $rgname -PassThru -Force
        Assert-AreEqual true $deleteLb
        
        $list = Get-AzureRmLoadBalancer -ResourceGroupName $rgname
        Assert-AreEqual 0 @($list).Count
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Tests creating an internal Load balancer with static ip.
#>
function Test-LoadBalancerCRUD-InternalStatic
{
    # Setup
    $rgname = Get-ResourceGroupName
    $vnetName = Get-ResourceName
    $subnetName = Get-ResourceName
    $publicIpName = Get-ResourceName
    $domainNameLabel = Get-ResourceName
    $lbName = Get-ResourceName
    $frontendName = Get-ResourceName
    $backendAddressPoolName = Get-ResourceName
    $probeName = Get-ResourceName
    $inboundNatRuleName = Get-ResourceName
    $lbruleName = Get-ResourceName
    $rglocation = Get-ProviderLocation ResourceManagement
    $resourceTypeParent = "Microsoft.Network/loadBalancers"
    $location = Get-ProviderLocation $resourceTypeParent
    
    try 
    {
        # Create the resource group
        $resourceGroup = New-AzureRmResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval"} 
        
        # Create the Virtual Network
        $subnet = New-AzureRmVirtualNetworkSubnetConfig -Name $subnetName -AddressPrefix 10.0.1.0/24
        $vnet = New-AzureRmvirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnet
        
        # Create the publicip
        $publicip = New-AzureRmPublicIpAddress -ResourceGroupName $rgname -name $publicIpName -location $location -AllocationMethod Dynamic -DomainNameLabel $domainNameLabel

        # Create LoadBalancer
        $frontend = New-AzureRmLoadBalancerFrontendIpConfig -Name $frontendName -Subnet $vnet.Subnets[0] -PrivateIpAddress "10.0.1.5"
        $backendAddressPool = New-AzureRmLoadBalancerBackendAddressPoolConfig -Name $backendAddressPoolName
        $probe = New-AzureRmLoadBalancerProbeConfig -Name $probeName -RequestPath healthcheck.aspx -Protocol http -Port 80 -IntervalInSeconds 15 -ProbeCount 2
        $inboundNatRule = New-AzureRmLoadBalancerInboundNatRuleConfig -Name $inboundNatRuleName -FrontendIPConfiguration $frontend -Protocol Tcp -FrontendPort 3389 -BackendPort 3389 -IdleTimeoutInMinutes 15 -EnableFloatingIP
        $lbrule = New-AzureRmLoadBalancerRuleConfig -Name $lbruleName -FrontendIPConfiguration $frontend -BackendAddressPool $backendAddressPool -Probe $probe -Protocol Tcp -FrontendPort 80 -BackendPort 80 -IdleTimeoutInMinutes 15 -EnableFloatingIP -LoadDistribution SourceIP
        $actualLb = New-AzureRmLoadBalancer -Name $lbName -ResourceGroupName $rgname -Location $location -FrontendIpConfiguration $frontend -BackendAddressPool $backendAddressPool -Probe $probe -InboundNatRule $inboundNatRule -LoadBalancingRule $lbrule
        
        $expectedLb = Get-AzureRmLoadBalancer -Name $lbName -ResourceGroupName $rgname

        # Verification
        Assert-AreEqual $expectedLb.ResourceGroupName $actualLb.ResourceGroupName
        Assert-AreEqual $expectedLb.Name $actualLb.Name
        Assert-AreEqual $expectedLb.Location $actualLb.Location
        Assert-AreEqual "Succeeded" $expectedLb.ProvisioningState
        Assert-AreEqual 1 @($expectedLb.FrontendIPConfigurations).Count
        
        Assert-AreEqual $frontendName $expectedLb.FrontendIPConfigurations[0].Name
        Assert-AreEqual $vnet.Subnets[0].Id $expectedLb.FrontendIPConfigurations[0].Subnet.Id
        Assert-AreEqual "10.0.1.5" $expectedLb.FrontendIPConfigurations[0].PrivateIpAddress

        Assert-AreEqual $backendAddressPoolName $expectedLb.BackendAddressPools[0].Name

        Assert-AreEqual $probeName $expectedLb.Probes[0].Name
        Assert-AreEqual $probe.RequestPath $expectedLb.Probes[0].RequestPath

        Assert-AreEqual $inboundNatRuleName $expectedLb.InboundNatRules[0].Name
        Assert-AreEqual $expectedLb.FrontendIPConfigurations[0].Id $expectedLb.InboundNatRules[0].FrontendIPConfiguration.Id

        Assert-AreEqual $lbruleName $expectedLb.LoadBalancingRules[0].Name
        Assert-AreEqual $expectedLb.FrontendIPConfigurations[0].Id $expectedLb.LoadBalancingRules[0].FrontendIPConfiguration.Id
        Assert-AreEqual $expectedLb.BackendAddressPools[0].Id $expectedLb.LoadBalancingRules[0].BackendAddressPool.Id

        # List
        $list = Get-AzureRmLoadBalancer -ResourceGroupName $rgname
        Assert-AreEqual 1 @($list).Count
        Assert-AreEqual $expectedLb.Etag $list[0].Etag
        Assert-AreEqual $expectedLb.FrontendIPConfigurations[0].Etag $list[0].FrontendIPConfigurations[0].Etag
        Assert-AreEqual $expectedLb.BackendAddressPools[0].Etag $list[0].BackendAddressPools[0].Etag
        Assert-AreEqual $expectedLb.InboundNatRules[0].Etag $list[0].InboundNatRules[0].Etag
        Assert-AreEqual $expectedLb.Probes[0].Etag $list[0].Probes[0].Etag
        Assert-AreEqual $expectedLb.LoadBalancingRules[0].Etag $list[0].LoadBalancingRules[0].Etag

        # Delete
        $deleteLb = Remove-AzureRmLoadBalancer -Name $lbName -ResourceGroupName $rgname -PassThru -Force
        Assert-AreEqual true $deleteLb
        
        $list = Get-AzureRmLoadBalancer -ResourceGroupName $rgname
        Assert-AreEqual 0 @($list).Count
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Tests creating a public Load balancer without InboundNAtRule
#>
function Test-LoadBalancerCRUD-PublicNoInboundNATRule
{
    # Setup
    $rgname = Get-ResourceGroupName
    $vnetName = Get-ResourceName
    $subnetName = Get-ResourceName
    $publicIpName = Get-ResourceName
    $domainNameLabel = Get-ResourceName
    $lbName = Get-ResourceName
    $frontendName = Get-ResourceName
    $backendAddressPoolName = Get-ResourceName
    $probeName = Get-ResourceName
    $inboundNatRuleName = Get-ResourceName
    $lbruleName = Get-ResourceName
    $rglocation = Get-ProviderLocation ResourceManagement
    $resourceTypeParent = "Microsoft.Network/loadBalancers"
    $location = Get-ProviderLocation $resourceTypeParent
    
    try 
    {
        # Create the resource group
        $resourceGroup = New-AzureRmResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval"} 
        
        # Create the Virtual Network
        $subnet = New-AzureRmVirtualNetworkSubnetConfig -Name $subnetName -AddressPrefix 10.0.1.0/24
        $vnet = New-AzureRmvirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnet
        
        # Create the publicip
        $publicip = New-AzureRmPublicIpAddress -ResourceGroupName $rgname -name $publicIpName -location $location -AllocationMethod Dynamic -DomainNameLabel $domainNameLabel

        # Create LoadBalancer
        $frontend = New-AzureRmLoadBalancerFrontendIpConfig -Name $frontendName -PublicIpAddress $publicip
        $backendAddressPool = New-AzureRmLoadBalancerBackendAddressPoolConfig -Name $backendAddressPoolName
        $probe = New-AzureRmLoadBalancerProbeConfig -Name $probeName -RequestPath healthcheck.aspx -Protocol http -Port 80 -IntervalInSeconds 15 -ProbeCount 2
        $lbrule = New-AzureRmLoadBalancerRuleConfig -Name $lbruleName -FrontendIPConfiguration $frontend -BackendAddressPool $backendAddressPool -Probe $probe -Protocol Tcp -FrontendPort 80 -BackendPort 80 -IdleTimeoutInMinutes 15 -EnableFloatingIP -LoadDistribution SourceIP
        $actualLb = New-AzureRmLoadBalancer -Name $lbName -ResourceGroupName $rgname -Location $location -FrontendIpConfiguration $frontend -BackendAddressPool $backendAddressPool -Probe $probe -LoadBalancingRule $lbrule
        
        $expectedLb = Get-AzureRmLoadBalancer -Name $lbName -ResourceGroupName $rgname

        # Verification
        Assert-AreEqual $expectedLb.ResourceGroupName $actualLb.ResourceGroupName
        Assert-AreEqual $expectedLb.Name $actualLb.Name
        Assert-AreEqual $expectedLb.Location $actualLb.Location
        Assert-AreEqual "Succeeded" $expectedLb.ProvisioningState
        Assert-AreEqual 1 @($expectedLb.FrontendIPConfigurations).Count
        
        Assert-AreEqual $frontendName $expectedLb.FrontendIPConfigurations[0].Name
        Assert-AreEqual $publicip.Id $expectedLb.FrontendIPConfigurations[0].PublicIpAddress.Id
        Assert-Null $expectedLb.FrontendIPConfigurations[0].PrivateIpAddress

        Assert-AreEqual $backendAddressPoolName $expectedLb.BackendAddressPools[0].Name

        Assert-AreEqual $probeName $expectedLb.Probes[0].Name
        Assert-AreEqual $probe.RequestPath $expectedLb.Probes[0].RequestPath

        Assert-AreEqual $lbruleName $expectedLb.LoadBalancingRules[0].Name
        Assert-AreEqual $expectedLb.FrontendIPConfigurations[0].Id $expectedLb.LoadBalancingRules[0].FrontendIPConfiguration.Id
        Assert-AreEqual $expectedLb.BackendAddressPools[0].Id $expectedLb.LoadBalancingRules[0].BackendAddressPool.Id

        # List
        $list = Get-AzureRmLoadBalancer -ResourceGroupName $rgname
        Assert-AreEqual 1 @($list).Count
        Assert-AreEqual $expectedLb.Etag $list[0].Etag
        Assert-AreEqual $expectedLb.FrontendIPConfigurations[0].Etag $list[0].FrontendIPConfigurations[0].Etag
        Assert-AreEqual $expectedLb.BackendAddressPools[0].Etag $list[0].BackendAddressPools[0].Etag
        Assert-AreEqual $expectedLb.Probes[0].Etag $list[0].Probes[0].Etag
        Assert-AreEqual $expectedLb.LoadBalancingRules[0].Etag $list[0].LoadBalancingRules[0].Etag

        # Delete
        $deleteLb = Remove-AzureRmLoadBalancer -Name $lbName -ResourceGroupName $rgname -PassThru -Force
        Assert-AreEqual true $deleteLb
        
        $list = Get-AzureRmLoadBalancer -ResourceGroupName $rgname
        Assert-AreEqual 0 @($list).Count
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Tests creating an internal Load balancer using resource ids
#>
function Test-LoadBalancerCRUD-InternalUsingId
{
    # Setup
    $rgname = Get-ResourceGroupName
    $vnetName = Get-ResourceName
    $subnetName = Get-ResourceName
    $publicIpName = Get-ResourceName
    $domainNameLabel = Get-ResourceName
    $lbName = Get-ResourceName
    $frontendName = Get-ResourceName
    $backendAddressPoolName = Get-ResourceName
    $probeName = Get-ResourceName
    $inboundNatRuleName = Get-ResourceName
    $lbruleName = Get-ResourceName
    $rglocation = Get-ProviderLocation ResourceManagement
    $resourceTypeParent = "Microsoft.Network/loadBalancers"
    $location = Get-ProviderLocation $resourceTypeParent
    
    try 
    {
        # Create the resource group
        $resourceGroup = New-AzureRmResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval"} 
        
        # Create the Virtual Network
        $subnet = New-AzureRmVirtualNetworkSubnetConfig -Name $subnetName -AddressPrefix 10.0.1.0/24
        $vnet = New-AzureRmvirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnet
        
        # Create the publicip
        $publicip = New-AzureRmPublicIpAddress -ResourceGroupName $rgname -name $publicIpName -location $location -AllocationMethod Dynamic -DomainNameLabel $domainNameLabel

        $frontend = New-AzureRmLoadBalancerFrontendIpConfig -Name $frontendName -SubnetId $vnet.Subnets[0].Id
        $backendAddressPool = New-AzureRmLoadBalancerBackendAddressPoolConfig -Name $backendAddressPoolName
        $probe = New-AzureRmLoadBalancerProbeConfig -Name $probeName -RequestPath healthcheck.aspx -Protocol http -Port 80 -IntervalInSeconds 15 -ProbeCount 2
        $inboundNatRule = New-AzureRmLoadBalancerInboundNatRuleConfig -Name $inboundNatRuleName -FrontendIPConfigurationId $frontend.Id -Protocol Tcp -FrontendPort 3389 -BackendPort 3389 -IdleTimeoutInMinutes 15 -EnableFloatingIP
        $lbrule = New-AzureRmLoadBalancerRuleConfig -Name $lbruleName -FrontendIPConfigurationId $frontend.Id -BackendAddressPoolId $backendAddressPool.Id -ProbeId $probe.Id -Protocol Tcp -FrontendPort 80 -BackendPort 80 -IdleTimeoutInMinutes 15 -EnableFloatingIP
        $actualLb = New-AzureRmLoadBalancer -Name $lbName -ResourceGroupName $rgname -Location $location -FrontendIpConfiguration $frontend -BackendAddressPool $backendAddressPool -Probe $probe -InboundNatRule $inboundNatRule -LoadBalancingRule $lbrule
        
        $expectedLb = Get-AzureRmLoadBalancer -Name $lbName -ResourceGroupName $rgname
        
        # Verification
        Assert-AreEqual $expectedLb.ResourceGroupName $actualLb.ResourceGroupName	
        Assert-AreEqual $expectedLb.Name $actualLb.Name	
        Assert-AreEqual $expectedLb.Location $actualLb.Location
        Assert-AreEqual "Succeeded" $expectedLb.ProvisioningState
        Assert-AreEqual 1 @($expectedLb.FrontendIPConfigurations).Count
        
        Assert-AreEqual $frontendName $expectedLb.FrontendIPConfigurations[0].Name
        Assert-AreEqual $vnet.Subnets[0].Id $expectedLb.FrontendIPConfigurations[0].Subnet.Id
        
        Assert-AreEqual $backendAddressPoolName $expectedLb.BackendAddressPools[0].Name

        Assert-AreEqual $probeName $expectedLb.Probes[0].Name
        Assert-AreEqual $probe.RequestPath $expectedLb.Probes[0].RequestPath
        
        Assert-AreEqual $inboundNatRuleName $expectedLb.InboundNatRules[0].Name
        Assert-AreEqual $expectedLb.FrontendIPConfigurations[0].Id $expectedLb.InboundNatRules[0].FrontendIPConfiguration.Id
        
        Assert-AreEqual $lbruleName $expectedLb.LoadBalancingRules[0].Name
        Assert-AreEqual $expectedLb.FrontendIPConfigurations[0].Id $expectedLb.LoadBalancingRules[0].FrontendIPConfiguration.Id
        Assert-AreEqual $expectedLb.BackendAddressPools[0].Id $expectedLb.LoadBalancingRules[0].BackendAddressPool.Id
        
        # List
        $list = Get-AzureRmLoadBalancer -ResourceGroupName $rgname
        Assert-AreEqual 1 @($list).Count
        Assert-AreEqual $expectedLb.Etag $list[0].Etag
        Assert-AreEqual $expectedLb.FrontendIPConfigurations[0].Etag $list[0].FrontendIPConfigurations[0].Etag
        Assert-AreEqual $expectedLb.BackendAddressPools[0].Etag $list[0].BackendAddressPools[0].Etag
        Assert-AreEqual $expectedLb.InboundNatRules[0].Etag $list[0].InboundNatRules[0].Etag
        Assert-AreEqual $expectedLb.Probes[0].Etag $list[0].Probes[0].Etag
        Assert-AreEqual $expectedLb.LoadBalancingRules[0].Etag $list[0].LoadBalancingRules[0].Etag
        
        # Delete
        $deleteLb = Remove-AzureRmLoadBalancer -Name $lbName -ResourceGroupName $rgname -PassThru -Force
        Assert-AreEqual true $deleteLb
        
        $list = Get-AzureRmLoadBalancer -ResourceGroupName $rgname
        Assert-AreEqual 0 @($list).Count
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Tests creating a public Load balancer using resource ids
#>
function Test-LoadBalancerCRUD-PublicUsingId
{
    # Setup
    $rgname = Get-ResourceGroupName
    $vnetName = Get-ResourceName
    $subnetName = Get-ResourceName
    $publicIpName = Get-ResourceName
    $domainNameLabel = Get-ResourceName
    $lbName = Get-ResourceName
    $frontendName = Get-ResourceName
    $backendAddressPoolName = Get-ResourceName
    $probeName = Get-ResourceName
    $inboundNatRuleName = Get-ResourceName
    $lbruleName = Get-ResourceName
    $rglocation = Get-ProviderLocation ResourceManagement
    $resourceTypeParent = "Microsoft.Network/loadBalancers"
    $location = Get-ProviderLocation $resourceTypeParent
    
    try 
    {
        # Create the resource group
        $resourceGroup = New-AzureRmResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval"} 
        
        # Create the Virtual Network
        $subnet = New-AzureRmVirtualNetworkSubnetConfig -Name $subnetName -AddressPrefix 10.0.1.0/24
        $vnet = New-AzureRmvirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnet
        
        # Create the publicip
        $publicip = New-AzureRmPublicIpAddress -ResourceGroupName $rgname -name $publicIpName -location $location -AllocationMethod Dynamic -DomainNameLabel $domainNameLabel

        $frontend = New-AzureRmLoadBalancerFrontendIpConfig -Name $frontendName -PublicIpAddressId $publicip.Id
        $backendAddressPool = New-AzureRmLoadBalancerBackendAddressPoolConfig -Name $backendAddressPoolName
        $probe = New-AzureRmLoadBalancerProbeConfig -Name $probeName -RequestPath healthcheck.aspx -Protocol http -Port 80 -IntervalInSeconds 15 -ProbeCount 2
        $inboundNatRule = New-AzureRmLoadBalancerInboundNatRuleConfig -Name $inboundNatRuleName -FrontendIPConfigurationId $frontend.Id -Protocol Tcp -FrontendPort 3389 -BackendPort 3389 -IdleTimeoutInMinutes 15 -EnableFloatingIP
        $lbrule = New-AzureRmLoadBalancerRuleConfig -Name $lbruleName -FrontendIPConfigurationId $frontend.Id -BackendAddressPoolId $backendAddressPool.Id -ProbeId $probe.Id -Protocol Tcp -FrontendPort 80 -BackendPort 80 -IdleTimeoutInMinutes 15 -EnableFloatingIP
        $actualLb = New-AzureRmLoadBalancer -Name $lbName -ResourceGroupName $rgname -Location $location -FrontendIpConfiguration $frontend -BackendAddressPool $backendAddressPool -Probe $probe -InboundNatRule $inboundNatRule -LoadBalancingRule $lbrule
        
        $expectedLb = Get-AzureRmLoadBalancer -Name $lbName -ResourceGroupName $rgname
        
        # Verification
        Assert-AreEqual $expectedLb.ResourceGroupName $actualLb.ResourceGroupName	
        Assert-AreEqual $expectedLb.Name $actualLb.Name	
        Assert-AreEqual $expectedLb.Location $actualLb.Location
        Assert-AreEqual "Succeeded" $expectedLb.ProvisioningState
        Assert-AreEqual 1 @($expectedLb.FrontendIPConfigurations).Count
        
        Assert-AreEqual $frontendName $expectedLb.FrontendIPConfigurations[0].Name
        Assert-AreEqual $publicip.Id $expectedLb.FrontendIPConfigurations[0].PublicIpAddress.Id
        
        Assert-AreEqual $backendAddressPoolName $expectedLb.BackendAddressPools[0].Name
        
        Assert-AreEqual $probeName $expectedLb.Probes[0].Name
        Assert-AreEqual $probe.RequestPath $expectedLb.Probes[0].RequestPath
        
        Assert-AreEqual $inboundNatRuleName $expectedLb.InboundNatRules[0].Name
        Assert-AreEqual $expectedLb.FrontendIPConfigurations[0].Id $expectedLb.InboundNatRules[0].FrontendIPConfiguration.Id
        
        Assert-AreEqual $lbruleName $expectedLb.LoadBalancingRules[0].Name
        Assert-AreEqual $expectedLb.FrontendIPConfigurations[0].Id $expectedLb.LoadBalancingRules[0].FrontendIPConfiguration.Id
        Assert-AreEqual $expectedLb.BackendAddressPools[0].Id $expectedLb.LoadBalancingRules[0].BackendAddressPool.Id
        
        # List
        $list = Get-AzureRmLoadBalancer -ResourceGroupName $rgname
        Assert-AreEqual 1 @($list).Count
        Assert-AreEqual $expectedLb.Etag $list[0].Etag
        Assert-AreEqual $expectedLb.FrontendIPConfigurations[0].Etag $list[0].FrontendIPConfigurations[0].Etag
        Assert-AreEqual $expectedLb.BackendAddressPools[0].Etag $list[0].BackendAddressPools[0].Etag
        Assert-AreEqual $expectedLb.InboundNatRules[0].Etag $list[0].InboundNatRules[0].Etag
        Assert-AreEqual $expectedLb.Probes[0].Etag $list[0].Probes[0].Etag
        Assert-AreEqual $expectedLb.LoadBalancingRules[0].Etag $list[0].LoadBalancingRules[0].Etag
        
        # Delete
        $deleteLb = Remove-AzureRmLoadBalancer -Name $lbName -ResourceGroupName $rgname -PassThru -Force
        Assert-AreEqual true $deleteLb
        
        $list = Get-AzureRmLoadBalancer -ResourceGroupName $rgname
        Assert-AreEqual 0 @($list).Count
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Tests creating a public Load balancer without a lb rule
#>
function Test-LoadBalancerCRUD-PublicNoLbRule
{
    # Setup
    $rgname = Get-ResourceGroupName
    $vnetName = Get-ResourceName
    $subnetName = Get-ResourceName
    $publicIpName = Get-ResourceName
    $domainNameLabel = Get-ResourceName
    $lbName = Get-ResourceName
    $frontendName = Get-ResourceName
    $backendAddressPoolName = Get-ResourceName
    $probeName = Get-ResourceName
    $inboundNatRuleName = Get-ResourceName
    $lbruleName = Get-ResourceName
    $rglocation = Get-ProviderLocation ResourceManagement
    $resourceTypeParent = "Microsoft.Network/loadBalancers"
    $location = Get-ProviderLocation $resourceTypeParent
    
    try 
    {
        # Create the resource group
        $resourceGroup = New-AzureRmResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval"} 
        
        # Create the Virtual Network
        $subnet = New-AzureRmVirtualNetworkSubnetConfig -Name $subnetName -AddressPrefix 10.0.1.0/24
        $vnet = New-AzureRmvirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnet
        
        # Create the publicip
        $publicip = New-AzureRmPublicIpAddress -ResourceGroupName $rgname -name $publicIpName -location $location -AllocationMethod Dynamic -DomainNameLabel $domainNameLabel

        # Create LoadBalancer
        $frontend = New-AzureRmLoadBalancerFrontendIpConfig -Name $frontendName -PublicIpAddress $publicip
        $backendAddressPool = New-AzureRmLoadBalancerBackendAddressPoolConfig -Name $backendAddressPoolName
        $probe = New-AzureRmLoadBalancerProbeConfig -Name $probeName -RequestPath healthcheck.aspx -Protocol http -Port 80 -IntervalInSeconds 15 -ProbeCount 2
        $inboundNatRule = New-AzureRmLoadBalancerInboundNatRuleConfig -Name $inboundNatRuleName -FrontendIPConfiguration $frontend -Protocol Tcp -FrontendPort 3389 -BackendPort 3389 -IdleTimeoutInMinutes 15 -EnableFloatingIP
        $actualLb = New-AzureRmLoadBalancer -Name $lbName -ResourceGroupName $rgname -Location $location -FrontendIpConfiguration $frontend -BackendAddressPool $backendAddressPool -Probe $probe -InboundNatRule $inboundNatRule
        
        $expectedLb = Get-AzureRmLoadBalancer -Name $lbName -ResourceGroupName $rgname

        # Verification
        Assert-AreEqual $expectedLb.ResourceGroupName $actualLb.ResourceGroupName
        Assert-AreEqual $expectedLb.Name $actualLb.Name
        Assert-AreEqual $expectedLb.Location $actualLb.Location
        Assert-AreEqual "Succeeded" $expectedLb.ProvisioningState
        Assert-AreEqual 1 @($expectedLb.FrontendIPConfigurations).Count
        
        Assert-AreEqual $frontendName $expectedLb.FrontendIPConfigurations[0].Name
        Assert-AreEqual $publicip.Id $expectedLb.FrontendIPConfigurations[0].PublicIpAddress.Id
        Assert-Null $expectedLb.FrontendIPConfigurations[0].PrivateIpAddress

        Assert-AreEqual $backendAddressPoolName $expectedLb.BackendAddressPools[0].Name

        Assert-AreEqual $probeName $expectedLb.Probes[0].Name
        Assert-AreEqual $probe.RequestPath $expectedLb.Probes[0].RequestPath

        Assert-AreEqual $inboundNatRuleName $expectedLb.InboundNatRules[0].Name
        Assert-AreEqual $expectedLb.FrontendIPConfigurations[0].Id $expectedLb.InboundNatRules[0].FrontendIPConfiguration.Id

        # List
        $list = Get-AzureRmLoadBalancer -ResourceGroupName $rgname
        Assert-AreEqual 1 @($list).Count
        Assert-AreEqual $expectedLb.Etag $list[0].Etag
        Assert-AreEqual $expectedLb.FrontendIPConfigurations[0].Etag $list[0].FrontendIPConfigurations[0].Etag
        Assert-AreEqual $expectedLb.BackendAddressPools[0].Etag $list[0].BackendAddressPools[0].Etag
        Assert-AreEqual $expectedLb.InboundNatRules[0].Etag $list[0].InboundNatRules[0].Etag
        Assert-AreEqual $expectedLb.Probes[0].Etag $list[0].Probes[0].Etag
        
        # Delete
        $deleteLb = Remove-AzureRmLoadBalancer -Name $lbName -ResourceGroupName $rgname -PassThru -Force
        Assert-AreEqual true $deleteLb
        
        $list = Get-AzureRmLoadBalancer -ResourceGroupName $rgname
        Assert-AreEqual 0 @($list).Count
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}


<#
.SYNOPSIS
Tests creating new simple Load balancer and edit child resources using config cmdlets
#>
function Test-LoadBalancerChildResource
{
    # Setup
    $rgname = Get-ResourceGroupName
    $vnetName = Get-ResourceName
    $subnetName = Get-ResourceName
    $publicIpName = Get-ResourceName
    $domainNameLabel = Get-ResourceName
    $lbName = Get-ResourceName
    $frontendName = Get-ResourceName
    $backendAddressPoolName = Get-ResourceName
    $probeName = Get-ResourceName
    $inboundNatRuleName = Get-ResourceName
    $lbruleName = Get-ResourceName
    $rglocation = Get-ProviderLocation ResourceManagement
    $resourceTypeParent = "Microsoft.Network/loadBalancers"
    $location = Get-ProviderLocation $resourceTypeParent
    
    try 
    {
        # Create the resource group
        $resourceGroup = New-AzureRmResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval"} 
        
        # Create the Virtual Network
        $subnet = New-AzureRmVirtualNetworkSubnetConfig -Name $subnetName -AddressPrefix 10.0.1.0/24
        $vnet = New-AzureRmvirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnet
        
        # Create the publicip
        $publicip = New-AzureRmPublicIpAddress -ResourceGroupName $rgname -name $publicIpName -location $location -AllocationMethod Dynamic -DomainNameLabel $domainNameLabel

        $frontend = New-AzureRmLoadBalancerFrontendIpConfig -Name $frontendName -SubnetId $vnet.Subnets[0].Id
        $backendAddressPool = New-AzureRmLoadBalancerBackendAddressPoolConfig -Name $backendAddressPoolName
        $probe = New-AzureRmLoadBalancerProbeConfig -Name $probeName -RequestPath healthcheck.aspx -Protocol http -Port 80 -IntervalInSeconds 15 -ProbeCount 2
        $inboundNatRule = New-AzureRmLoadBalancerInboundNatRuleConfig -Name $inboundNatRuleName -FrontendIPConfigurationId $frontend.Id -Protocol Tcp -FrontendPort 3389 -BackendPort 3389 -IdleTimeoutInMinutes 15 -EnableFloatingIP
        $lbrule = New-AzureRmLoadBalancerRuleConfig -Name $lbruleName -FrontendIPConfigurationId $frontend.Id -BackendAddressPoolId $backendAddressPool.Id -ProbeId $probe.Id -Protocol Tcp -FrontendPort 80 -BackendPort 80 -IdleTimeoutInMinutes 15 -EnableFloatingIP
        New-AzureRmLoadBalancer -Name $lbName -ResourceGroupName $rgname -Location $location -FrontendIpConfiguration $frontend -BackendAddressPool $backendAddressPool -Probe $probe -InboundNatRule $inboundNatRule -LoadBalancingRule $lbrule
        
        $lb = Get-AzureRmLoadBalancer -Name $lbName -ResourceGroupName $rgname
        
        # Test FrontendConfig cmdlets
        $frontendName2 = Get-ResourceName
        $lb = $lb | Add-AzureRmLoadBalancerFrontendIpConfig -Name $frontendName2 -Subnet $vnet.Subnets[0]

        Assert-AreEqual 2 @($lb.FrontendIPConfigurations).Count
        Assert-AreEqual $frontendName2 $lb.FrontendIPConfigurations[1].Name
        Assert-AreEqual "Dynamic" $lb.FrontendIPConfigurations[1].PrivateIPAllocationMethod
        Assert-AreEqual $vnet.Subnets[0].Id $lb.FrontendIPConfigurations[1].Subnet.Id

        $lb = $lb | Set-AzureRmLoadBalancerFrontendIpConfig -Name $frontendName2 -Subnet $vnet.Subnets[0] -PrivateIpAddress "10.0.1.5"
        Assert-AreEqual 2 @($lb.FrontendIPConfigurations).Count
        Assert-AreEqual $frontendName2 $lb.FrontendIPConfigurations[1].Name
        Assert-AreEqual "Static" $lb.FrontendIPConfigurations[1].PrivateIPAllocationMethod
        Assert-AreEqual $vnet.Subnets[0].Id $lb.FrontendIPConfigurations[1].Subnet.Id
        Assert-AreEqual "10.0.1.5" $lb.FrontendIPConfigurations[1].PrivateIpAddress

        $frontendIpconfig = $lb | Get-AzureRmLoadBalancerFrontendIpConfig -Name $frontendName2
        $frontendIpconfigList = $lb | Get-AzureRmLoadBalancerFrontendIpConfig
        Assert-AreEqual 2 @($frontendIpconfigList).Count
        Assert-AreEqual $frontendName $frontendIpconfigList[0].Name
        Assert-AreEqual $frontendName2 $frontendIpconfigList[1].Name
        Assert-AreEqual $frontendIpconfig.Name $frontendIpconfigList[1].Name

        $lb = $lb | Remove-AzureRmLoadBalancerFrontendIpConfig -Name $frontendName2
        Assert-AreEqual 1 @($lb.FrontendIPConfigurations).Count
        Assert-AreEqual $frontendName $lb.FrontendIPConfigurations[0].Name

        # Test BackendAddressPool cmdlets
        $backendAddressPoolName2 = Get-ResourceName
        $lb =  Get-AzureRmLoadBalancer -Name $lbName -ResourceGroupName $rgname | Add-AzureRmLoadBalancerBackendAddressPoolConfig -Name $backendAddressPoolName2 | Set-AzureRmLoadBalancer

        Assert-AreEqual 2 @($lb.BackendAddressPools).Count
        Assert-AreEqual $backendAddressPoolName2 $lb.BackendAddressPools[1].Name

        $backendAddressPoolConfig = Get-AzureRmLoadBalancer -Name $lbName -ResourceGroupName $rgname| Get-AzureRmLoadBalancerBackendAddressPoolConfig -Name $backendAddressPoolName2
        $backendAddressPoolConfigList = Get-AzureRmLoadBalancer -Name $lbName -ResourceGroupName $rgname | Get-AzureRmLoadBalancerBackendAddressPoolConfig
        Assert-AreEqual 2 @($backendAddressPoolconfigList).Count
        Assert-AreEqual $backendAddressPoolName $backendAddressPoolConfigList[0].Name
        Assert-AreEqual $backendAddressPoolName2 $backendAddressPoolConfigList[1].Name
        Assert-AreEqual $backendAddressPoolConfig.Name $backendAddressPoolConfigList[1].Name

        $lb =  Get-AzureRmLoadBalancer -Name $lbName -ResourceGroupName $rgname | Remove-AzureRmLoadBalancerBackendAddressPoolConfig -Name $backendAddressPoolName2 | Set-AzureRmLoadBalancer
        Assert-AreEqual 1 @($lb.BackendAddressPools).Count
        Assert-AreEqual $backendAddressPoolName $lb.BackendAddressPools[0].Name

        # Test Probe cmdlets
        $probeName2 = Get-ResourceName
        $lb =  Get-AzureRmLoadBalancer -Name $lbName -ResourceGroupName $rgname | Add-AzureRmLoadBalancerProbeConfig -Name $probeName2 -RequestPath healthcheck2.aspx -Protocol http -Port 81 -IntervalInSeconds 16 -ProbeCount 3 | Set-AzureRmLoadBalancer

        Assert-AreEqual 2 @($lb.Probes).Count
        Assert-AreEqual $probeName2 $lb.Probes[1].Name
        Assert-AreEqual "healthcheck2.aspx" $lb.Probes[1].RequestPath
        Assert-AreEqual 81 $lb.Probes[1].Port

        $lb =  Get-AzureRmLoadBalancer -Name $lbName -ResourceGroupName $rgname | Set-AzureRmLoadBalancerProbeConfig -Name $probeName2 -RequestPath healthcheck2.aspx -Protocol http -Port 85 -IntervalInSeconds 16 -ProbeCount 3 | Set-AzureRmLoadBalancer
        Assert-AreEqual 2 @($lb.Probes).Count
        Assert-AreEqual $probeName2 $lb.Probes[1].Name
        Assert-AreEqual "healthcheck2.aspx" $lb.Probes[1].RequestPath
        Assert-AreEqual 85 $lb.Probes[1].Port

        $probeConfig = Get-AzureRmLoadBalancer -Name $lbName -ResourceGroupName $rgname | Get-AzureRmLoadBalancerProbeConfig -Name $probeName2
        $probeConfigList = Get-AzureRmLoadBalancer -Name $lbName -ResourceGroupName $rgname | Get-AzureRmLoadBalancerProbeConfig
        Assert-AreEqual 2 @($probeConfigList).Count
        Assert-AreEqual $probeName $probeConfigList[0].Name
        Assert-AreEqual $probeName2 $probeConfigList[1].Name
        Assert-AreEqual $probeConfig.Name $probeConfigList[1].Name

        $lb =  Get-AzureRmLoadBalancer -Name $lbName -ResourceGroupName $rgname | Remove-AzureRmLoadBalancerProbeConfig -Name $probeName2 | Set-AzureRmLoadBalancer
        Assert-AreEqual 1 @($lb.Probes).Count
        Assert-AreEqual $probeName $lb.Probes[0].Name

        # Test InboundNatRule cmdlets
        $inboundNatRuleName2 = Get-ResourceName
        $lb = Get-AzureRmLoadBalancer -Name $lbName -ResourceGroupName $rgname | Add-AzureRmLoadBalancerInboundNatRuleConfig -Name $inboundNatRuleName2 -FrontendIPConfigurationId $lb.FrontendIPConfigurations[0].Id -Protocol Tcp -FrontendPort 3350 -BackendPort 3350 -IdleTimeoutInMinutes 17 -EnableFloatingIP | Set-AzureRmLoadBalancer
        
        Assert-AreEqual 2 @($lb.InboundNatRules).Count
        Assert-AreEqual $inboundNatRuleName2 $lb.InboundNatRules[1].Name
        Assert-AreEqual 3350 $lb.InboundNatRules[1].FrontendPort
        Assert-AreEqual 3350 $lb.InboundNatRules[1].BackendPort
        Assert-AreEqual true $lb.InboundNatRules[1].EnableFloatingIP

        $lb = Get-AzureRmLoadBalancer -Name $lbName -ResourceGroupName $rgname | Set-AzureRmLoadBalancerInboundNatRuleConfig -Name $inboundNatRuleName2 -FrontendIPConfigurationId $lb.FrontendIPConfigurations[0].Id -Protocol Tcp -FrontendPort 3352 -BackendPort 3351 -IdleTimeoutInMinutes 17 | Set-AzureRmLoadBalancer
        Assert-AreEqual 2 @($lb.InboundNatRules).Count
        Assert-AreEqual $inboundNatRuleName2 $lb.InboundNatRules[1].Name
        Assert-AreEqual 3352 $lb.InboundNatRules[1].FrontendPort
        Assert-AreEqual 3351 $lb.InboundNatRules[1].BackendPort
        Assert-AreEqual false $lb.InboundNatRules[1].EnableFloatingIP

        $inboundNatRuleConfig = Get-AzureRmLoadBalancer -Name $lbName -ResourceGroupName $rgname | Get-AzureRmLoadBalancerInboundNatRuleConfig -Name $inboundNatRuleName2
        $inboundNatRuleConfigList = Get-AzureRmLoadBalancer -Name $lbName -ResourceGroupName $rgname | Get-AzureRmLoadBalancerInboundNatRuleConfig
        Assert-AreEqual 2 @($inboundNatRuleConfigList).Count
        Assert-AreEqual $inboundNatRuleName $inboundNatRuleConfigList[0].Name
        Assert-AreEqual $inboundNatRuleName2 $inboundNatRuleConfigList[1].Name
        Assert-AreEqual $inboundNatRuleConfig.Name $inboundNatRuleConfigList[1].Name

        $lb =  Get-AzureRmLoadBalancer -Name $lbName -ResourceGroupName $rgname | Remove-AzureRmLoadBalancerInboundNatRuleConfig -Name $inboundNatRuleName2 | Set-AzureRmLoadBalancer
        Assert-AreEqual 1 @($lb.InboundNatRules).Count
        Assert-AreEqual $inboundNatRuleName $lb.InboundNatRules[0].Name

        # Test LoadBalancingRule Cmdlets
        $lbruleName2 = Get-ResourceName
        $lb = Get-AzureRmLoadBalancer -Name $lbName -ResourceGroupName $rgname | Add-AzureRmLoadBalancerRuleConfig -Name $lbruleName2 -FrontendIPConfigurationId $lb.FrontendIPConfigurations[0].Id -BackendAddressPoolId $lb.BackendAddressPools[0].Id -ProbeId $lb.Probes[0].Id -Protocol Tcp -FrontendPort 82 -BackendPort 83 -IdleTimeoutInMinutes 15 -LoadDistribution SourceIP| Set-AzureRmLoadBalancer
        
        Assert-AreEqual 2 @($lb.LoadBalancingRules).Count
        Assert-AreEqual $lbruleName2 $lb.LoadBalancingRules[1].Name
        Assert-AreEqual 82 $lb.LoadBalancingRules[1].FrontendPort
        Assert-AreEqual 83 $lb.LoadBalancingRules[1].BackendPort
        Assert-AreEqual false $lb.LoadBalancingRules[1].EnableFloatingIP
        Assert-AreEqual "SourceIP" $lb.LoadBalancingRules[1].LoadDistribution

        $lb = Get-AzureRmLoadBalancer -Name $lbName -ResourceGroupName $rgname | Set-AzureRmLoadBalancerRuleConfig -Name $lbruleName2 -FrontendIPConfigurationId $lb.FrontendIPConfigurations[0].Id -BackendAddressPoolId $lb.BackendAddressPools[0].Id -ProbeId $lb.Probes[0].Id -Protocol Tcp -FrontendPort 84 -BackendPort 84 -IdleTimeoutInMinutes 17 -EnableFloatingIP | Set-AzureRmLoadBalancer
        Assert-AreEqual 2 @($lb.LoadBalancingRules).Count
        Assert-AreEqual $lbruleName2 $lb.LoadBalancingRules[1].Name
        Assert-AreEqual 84 $lb.LoadBalancingRules[1].FrontendPort
        Assert-AreEqual 84 $lb.LoadBalancingRules[1].BackendPort
        Assert-AreEqual true $lb.LoadBalancingRules[1].EnableFloatingIP
        Assert-AreEqual "Default" $lb.LoadBalancingRules[1].LoadDistribution

        $lbruleConfig = Get-AzureRmLoadBalancer -Name $lbName -ResourceGroupName $rgname | Get-AzureRmLoadBalancerRuleConfig -Name $lbruleName2
        $lbruleConfigList = Get-AzureRmLoadBalancer -Name $lbName -ResourceGroupName $rgname | Get-AzureRmLoadBalancerRuleConfig
        Assert-AreEqual 2 @($inboundNatRuleConfigList).Count
        Assert-AreEqual $lbruleName $lbruleConfigList[0].Name
        Assert-AreEqual $lbruleName2 $lbruleConfigList[1].Name
        Assert-AreEqual $lbruleConfig.Name $lbruleConfigList[1].Name

        $lb = Get-AzureRmLoadBalancer -Name $lbName -ResourceGroupName $rgname | Remove-AzureRmLoadBalancerRuleConfig -Name $lbruleName2 | Set-AzureRmLoadBalancer
        Assert-AreEqual 1 @($lb.LoadBalancingRules).Count
        Assert-AreEqual $lbruleName $lb.LoadBalancingRules[0].Name

        # Delete
        $deleteLb = $lb | Remove-AzureRmLoadBalancer -PassThru -Force
        Assert-AreEqual true $deleteLb
        
        $list = Get-AzureRmLoadBalancer -ResourceGroupName $rgname
        Assert-AreEqual 0 @($list).Count
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Tests creating and editing a simple Load balancer 
#>
function Test-LoadBalancerSet
{
    # Setup
    $rgname = Get-ResourceGroupName
    $vnetName = Get-ResourceName
    $subnetName = Get-ResourceName
    $publicIpName = Get-ResourceName
    $domainNameLabel = Get-ResourceName
    $lbName = Get-ResourceName
    $frontendName = Get-ResourceName
    $backendAddressPoolName = Get-ResourceName
    $probeName = Get-ResourceName
    $inboundNatRuleName = Get-ResourceName
    $lbruleName = Get-ResourceName
    $rglocation = Get-ProviderLocation ResourceManagement
    $resourceTypeParent = "Microsoft.Network/loadBalancers"
    $location = Get-ProviderLocation $resourceTypeParent
    
    try 
    {
        # Create the resource group
        $resourceGroup = New-AzureRmResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval"} 
        
        # Create the Virtual Network
        $subnet = New-AzureRmVirtualNetworkSubnetConfig -Name $subnetName -AddressPrefix 10.0.1.0/24
        $vnet = New-AzureRmvirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnet
        
        # Create the publicip
        $publicip = New-AzureRmPublicIpAddress -ResourceGroupName $rgname -name $publicIpName -location $location -AllocationMethod Dynamic -DomainNameLabel $domainNameLabel

        $frontend = New-AzureRmLoadBalancerFrontendIpConfig -Name $frontendName -SubnetId $vnet.Subnets[0].Id
        $backendAddressPool = New-AzureRmLoadBalancerBackendAddressPoolConfig -Name $backendAddressPoolName
        $probe = New-AzureRmLoadBalancerProbeConfig -Name $probeName -RequestPath healthcheck.aspx -Protocol http -Port 80 -IntervalInSeconds 15 -ProbeCount 2
        $inboundNatRule = New-AzureRmLoadBalancerInboundNatRuleConfig -Name $inboundNatRuleName -FrontendIPConfigurationId $frontend.Id -Protocol Tcp -FrontendPort 3389 -BackendPort 3389 -IdleTimeoutInMinutes 15 -EnableFloatingIP
        $lbrule = New-AzureRmLoadBalancerRuleConfig -Name $lbruleName -FrontendIPConfigurationId $frontend.Id -BackendAddressPoolId $backendAddressPool.Id -ProbeId $probe.Id -Protocol Tcp -FrontendPort 80 -BackendPort 80 -IdleTimeoutInMinutes 15 -EnableFloatingIP
        New-AzureRmLoadBalancer -Name $lbName -ResourceGroupName $rgname -Location $location -FrontendIpConfiguration $frontend -BackendAddressPool $backendAddressPool -Probe $probe -InboundNatRule $inboundNatRule -LoadBalancingRule $lbrule
        
        $lb = Get-AzureRmLoadBalancer -Name $lbName -ResourceGroupName $rgname
    
        # Test Probe cmdlets
        $probeName2 = Get-ResourceName
        $lb = Get-AzureRmLoadBalancer -Name $lbName -ResourceGroupName $rgname | Add-AzureRmLoadBalancerProbeConfig -Name $probeName2 -RequestPath healthcheck2.aspx -Protocol http -Port 81 -IntervalInSeconds 16 -ProbeCount 3 | Set-AzureRmLoadBalancer

        Assert-AreEqual 2 @($lb.Probes).Count
        Assert-AreEqual $probeName2 $lb.Probes[1].Name
        Assert-AreEqual "healthcheck2.aspx" $lb.Probes[1].RequestPath
        Assert-AreEqual 81 $lb.Probes[1].Port

        $lb = Get-AzureRmLoadBalancer -Name $lbName -ResourceGroupName $rgname | Set-AzureRmLoadBalancer
        Assert-AreEqual 2 @($lb.Probes).Count
        Assert-AreEqual $probeName2 $lb.Probes[1].Name
        Assert-AreEqual "healthcheck2.aspx" $lb.Probes[1].RequestPath
        Assert-AreEqual 81 $lb.Probes[1].Port

        # Delete
        $deleteLb = $lb | Remove-AzureRmLoadBalancer -PassThru -Force
        Assert-AreEqual true $deleteLb
        
        $list = Get-AzureRmLoadBalancer -ResourceGroupName $rgname
        Assert-AreEqual 0 @($list).Count
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Tests creating an empty Load balancer 
#>
function Test-CreateEmptyLoadBalancer
{
    # Setup
    $rgname = Get-ResourceGroupName
    $lbName = Get-ResourceName
    $rglocation = Get-ProviderLocation ResourceManagement
    $resourceTypeParent = "Microsoft.Network/loadBalancers"
    $location = Get-ProviderLocation $resourceTypeParent
    
    try 
    {
        # Create the resource group
        $resourceGroup = New-AzureRmResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval"} 
        
        # Create empty load balancer
        New-AzureRmLoadBalancer -Name $lbName -ResourceGroupName $rgname -Location $location

        $lb = Get-AzureRmLoadBalancer -Name $lbName -ResourceGroupName $rgname
        Assert-AreEqual $lbName $lb.Name
        Assert-AreEqual 0 @($lb.FrontendIpConfigurations).Count
        Assert-AreEqual 0 @($lb.BackendAddressPools).Count
        Assert-AreEqual 0 @($lb.Probes).Count
        Assert-AreEqual 0 @($lb.InboundNatRules).Count
        Assert-AreEqual 0 @($lb.LoadBalancingRules).Count

        # Delete
        $deleteLb = $lb | Remove-AzureRmLoadBalancer -PassThru -Force
        Assert-AreEqual true $deleteLb
        
        $list = Get-AzureRmLoadBalancer -ResourceGroupName $rgname
        Assert-AreEqual 0 @($list).Count
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Tests creating a Load balancer with NIC references
#>
function Test-LoadBalancer-NicAssociation
{
    # Setup
    $rgname = Get-ResourceGroupName
    $vnetName = Get-ResourceName
    $subnetName = Get-ResourceName
    $publicIpName = Get-ResourceName
    $lbName = Get-ResourceName
    $frontendName = Get-ResourceName
    $backendAddressPoolName = Get-ResourceName
    $probeName = Get-ResourceName
    $inboundNatRuleName1 = Get-ResourceName
    $inboundNatRuleName2 = Get-ResourceName
    $lbruleName = Get-ResourceName
    $nicname1 = Get-ResourceName
    $nicname2 = Get-ResourceName
    $nicname3 = Get-ResourceName
    $rglocation = Get-ProviderLocation ResourceManagement
    $resourceTypeParent = "Microsoft.Network/loadBalancers"
    $location = Get-ProviderLocation $resourceTypeParent
    
    try 
    {
        # Create the resource group
        $resourceGroup = New-AzureRmResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval" } 
        
        # Create the Virtual Network
        $subnet = New-AzureRmVirtualNetworkSubnetConfig -Name $subnetName -AddressPrefix 10.0.1.0/24
        $vnet = New-AzureRmvirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnet
        
        # Create the publicip
        $publicip = New-AzureRmPublicIpAddress -ResourceGroupName $rgname -name $publicIpName -location $location -AllocationMethod Dynamic

        # Create LoadBalancer
        $frontend = New-AzureRmLoadBalancerFrontendIpConfig -Name $frontendName -PublicIpAddress $publicip
        $backendAddressPool = New-AzureRmLoadBalancerBackendAddressPoolConfig -Name $backendAddressPoolName
        $probe = New-AzureRmLoadBalancerProbeConfig -Name $probeName -RequestPath healthcheck.aspx -Protocol http -Port 80 -IntervalInSeconds 15 -ProbeCount 2
        $inboundNatRule1 = New-AzureRmLoadBalancerInboundNatRuleConfig -Name $inboundNatRuleName1 -FrontendIPConfiguration $frontend -Protocol Tcp -FrontendPort 3389 -BackendPort 3389 -IdleTimeoutInMinutes 15 -EnableFloatingIP
        $inboundNatRule2 = New-AzureRmLoadBalancerInboundNatRuleConfig -Name $inboundNatRuleName2 -FrontendIPConfiguration $frontend -Protocol Tcp -FrontendPort 3391 -BackendPort 3392
        $lbrule = New-AzureRmLoadBalancerRuleConfig -Name $lbruleName -FrontendIPConfiguration $frontend -BackendAddressPool $backendAddressPool -Probe $probe -Protocol Tcp -FrontendPort 80 -BackendPort 80 -IdleTimeoutInMinutes 15 -EnableFloatingIP -LoadDistribution SourceIP
        $lb = New-AzureRmLoadBalancer -Name $lbName -ResourceGroupName $rgname -Location $location -FrontendIpConfiguration $frontend -BackendAddressPool $backendAddressPool -Probe $probe -InboundNatRule $inboundNatRule1,$inboundNatRule2 -LoadBalancingRule $lbrule
        
        # Verification of Load Balancer
        Assert-AreEqual $rgname $lb.ResourceGroupName
        Assert-AreEqual $lbName $lb.Name
        Assert-NotNull $lb.Location
        Assert-AreEqual "Succeeded" $lb.ProvisioningState
        Assert-AreEqual 1 @($lb.FrontendIPConfigurations).Count

        Assert-Null $lb.InboundNatRules[0].BackendIPConfiguration
        Assert-Null $lb.InboundNatRules[1].BackendIPConfiguration
        Assert-AreEqual 0 @($lb.BackendAddressPools[0].BackendIpConfigurations).Count

        # Create 3 network interfaces and accociate to loadbalancer
        $nic1 = New-AzureRmNetworkInterface -Name $nicname1 -ResourceGroupName $rgname -Location $location -Subnet $vnet.Subnets[0]
        $nic2 = New-AzureRmNetworkInterface -Name $nicname2 -ResourceGroupName $rgname -Location $location -Subnet $vnet.Subnets[0]
        $nic3 = New-AzureRmNetworkInterface -Name $nicname3 -ResourceGroupName $rgname -Location $location -Subnet $vnet.Subnets[0]

        # Associate the nic to the load balancer
        $nic1.IpConfigurations[0].LoadBalancerBackendAddressPools.Add($lb.BackendAddressPools[0]);
        $nic1.IpConfigurations[0].LoadBalancerInboundNatRules.Add($lb.InboundNatRules[0]);
        $nic2.IpConfigurations[0].LoadBalancerBackendAddressPools.Add($lb.BackendAddressPools[0]);
        $nic3.IpConfigurations[0].LoadBalancerInboundNatRules.Add($lb.InboundNatRules[1]);

        # set the nics
        $nic1 = $nic1 | Set-AzureRmNetworkInterface
        $nic2 = $nic2 | Set-AzureRmNetworkInterface
        $nic3 = $nic3 | Set-AzureRmNetworkInterface

        # Verify the Load balancer references
        $lb = Get-AzureRmLoadBalancer -Name $lbName -ResourceGroupName $rgname

        Assert-AreEqual $nic1.IpConfigurations[0].Id $lb.InboundNatRules[0].BackendIPConfiguration.Id
        Assert-AreEqual $nic3.IpConfigurations[0].Id $lb.InboundNatRules[1].BackendIPConfiguration.Id
        Assert-AreEqual 2 @($lb.BackendAddressPools[0].BackendIpConfigurations).Count

        # Delete
        $deleteLb = Remove-AzureRmLoadBalancer -Name $lbName -ResourceGroupName $rgname -PassThru -Force
        Assert-AreEqual true $deleteLb
        
        $list = Get-AzureRmLoadBalancer -ResourceGroupName $rgname
        Assert-AreEqual 0 @($list).Count
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Tests creating a NIC with Loadbalancer references
#>
function Test-LoadBalancer-NicAssociationDuringCreate
{
    # Setup
    $rgname = Get-ResourceGroupName
    $vnetName = Get-ResourceName
    $subnetName = Get-ResourceName
    $publicIpName = Get-ResourceName
    $lbName = Get-ResourceName
    $frontendName = Get-ResourceName
    $backendAddressPoolName = Get-ResourceName
    $probeName = Get-ResourceName
    $inboundNatRuleName1 = Get-ResourceName
    $inboundNatRuleName2 = Get-ResourceName
    $lbruleName = Get-ResourceName
    $nicname1 = Get-ResourceName
    $nicname2 = Get-ResourceName
    $nicname3 = Get-ResourceName
    $rglocation = Get-ProviderLocation ResourceManagement
    $resourceTypeParent = "Microsoft.Network/loadBalancers"
    $location = Get-ProviderLocation $resourceTypeParent
    
    try 
    {
        # Create the resource group
        $resourceGroup = New-AzureRmResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval" } 
        
        # Create the Virtual Network
        $subnet = New-AzureRmVirtualNetworkSubnetConfig -Name $subnetName -AddressPrefix 10.0.1.0/24
        $vnet = New-AzureRmvirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnet
        
        # Create the publicip
        $publicip = New-AzureRmPublicIpAddress -ResourceGroupName $rgname -name $publicIpName -location $location -AllocationMethod Dynamic

        # Create LoadBalancer
        $frontend = New-AzureRmLoadBalancerFrontendIpConfig -Name $frontendName -PublicIpAddress $publicip
        $backendAddressPool = New-AzureRmLoadBalancerBackendAddressPoolConfig -Name $backendAddressPoolName
        $probe = New-AzureRmLoadBalancerProbeConfig -Name $probeName -RequestPath healthcheck.aspx -Protocol http -Port 80 -IntervalInSeconds 15 -ProbeCount 2
        $inboundNatRule1 = New-AzureRmLoadBalancerInboundNatRuleConfig -Name $inboundNatRuleName1 -FrontendIPConfiguration $frontend -Protocol Tcp -FrontendPort 3389 -BackendPort 3389 -IdleTimeoutInMinutes 15 -EnableFloatingIP
        $inboundNatRule2 = New-AzureRmLoadBalancerInboundNatRuleConfig -Name $inboundNatRuleName2 -FrontendIPConfiguration $frontend -Protocol Tcp -FrontendPort 3391 -BackendPort 3392
        $lbrule = New-AzureRmLoadBalancerRuleConfig -Name $lbruleName -FrontendIPConfiguration $frontend -BackendAddressPool $backendAddressPool -Probe $probe -Protocol Tcp -FrontendPort 80 -BackendPort 80 -IdleTimeoutInMinutes 15 -EnableFloatingIP -LoadDistribution SourceIP
        $lb = New-AzureRmLoadBalancer -Name $lbName -ResourceGroupName $rgname -Location $location -FrontendIpConfiguration $frontend -BackendAddressPool $backendAddressPool -Probe $probe -InboundNatRule $inboundNatRule1,$inboundNatRule2 -LoadBalancingRule $lbrule
        
        # Verification of Load Balancer
        Assert-AreEqual $rgname $lb.ResourceGroupName
        Assert-AreEqual $lbName $lb.Name
        Assert-NotNull $lb.Location
        Assert-AreEqual "Succeeded" $lb.ProvisioningState
        Assert-AreEqual 1 @($lb.FrontendIPConfigurations).Count

        Assert-Null $lb.InboundNatRules[0].BackendIPConfiguration
        Assert-Null $lb.InboundNatRules[1].BackendIPConfiguration
        Assert-AreEqual 0 @($lb.BackendAddressPools[0].BackendIpConfigurations).Count

        # Create 3 network interfaces and accociate to loadbalancer
        $nic1 = New-AzureRmNetworkInterface -Name $nicname1 -ResourceGroupName $rgname -Location $location -Subnet $vnet.Subnets[0] -LoadBalancerBackendAddressPool $lb.BackendAddressPools[0] -LoadBalancerInboundNatRule $lb.InboundNatRules[0]
        $nic2 = New-AzureRmNetworkInterface -Name $nicname2 -ResourceGroupName $rgname -Location $location -SubnetId $vnet.Subnets[0].Id -LoadBalancerBackendAddressPoolId $lb.BackendAddressPools[0].Id
        $nic3 = New-AzureRmNetworkInterface -Name $nicname3 -ResourceGroupName $rgname -Location $location -SubnetId $vnet.Subnets[0].Id -LoadBalancerInboundNatRuleId $lb.InboundNatRules[1].Id

        # set the nics
        $nic1 = $nic1 | Set-AzureRmNetworkInterface
        $nic2 = $nic2 | Set-AzureRmNetworkInterface
        $nic3 = $nic3 | Set-AzureRmNetworkInterface

        # Verify the Load balancer references
        $lb = Get-AzureRmLoadBalancer -Name $lbName -ResourceGroupName $rgname

        Assert-AreEqual $nic1.IpConfigurations[0].Id $lb.InboundNatRules[0].BackendIPConfiguration.Id
        Assert-AreEqual $nic3.IpConfigurations[0].Id $lb.InboundNatRules[1].BackendIPConfiguration.Id
        Assert-AreEqual 2 @($lb.BackendAddressPools[0].BackendIpConfigurations).Count

        # Delete
        $deleteLb = Remove-AzureRmLoadBalancer -Name $lbName -ResourceGroupName $rgname -PassThru -Force
        Assert-AreEqual true $deleteLb
        
        $list = Get-AzureRmLoadBalancer -ResourceGroupName $rgname
        Assert-AreEqual 0 @($list).Count
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Tests creating new internal Load balancer and CRUD inbound nat pools on the load balancer
#>
function Test-LoadBalancerInboundNatPoolConfigCRUD-InternalLB  
{
    # Setup
    $rgname = Get-ResourceGroupName
    $vnetName = Get-ResourceName
    $subnetName = Get-ResourceName
    $publicIpName = Get-ResourceName
    $domainNameLabel = Get-ResourceName
    $lbName = Get-ResourceName
    $frontendName = Get-ResourceName
    $rglocation = "West US" 
    $resourceTypeParent = "Microsoft.Network/loadBalancers"
    $location = "West US" 
    
    try 
    {
        # Create the resource group
        $resourceGroup = New-AzureRmResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval" } 
        
        # Create the Virtual Network
        $subnet = New-AzureRmVirtualNetworkSubnetConfig -Name $subnetName -AddressPrefix 10.0.1.0/24
        $vnet = New-AzureRmvirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnet
        
        # Create the publicip
        $publicip = New-AzureRmPublicIpAddress -ResourceGroupName $rgname -name $publicIpName -location $location -AllocationMethod Dynamic -DomainNameLabel $domainNameLabel

        $frontend = New-AzureRmLoadBalancerFrontendIpConfig -Name $frontendName -SubnetId $vnet.Subnets[0].Id
        New-AzureRmLoadBalancer -Name $lbName -ResourceGroupName $rgname -Location $location -FrontendIpConfiguration $frontend 
        
        $lb = Get-AzureRmLoadBalancer -Name $lbName -ResourceGroupName $rgname

        # Test InboundNatPool cmdlets
        $inboundNatPoolName = Get-ResourceName
        $lb = Get-AzureRmLoadBalancer -Name $lbName -ResourceGroupName $rgname 
        $lb = $lb | Add-AzureRmLoadBalancerInboundNatPoolConfig -Name $inboundNatPoolName -FrontendIPConfigurationId $lb.FrontendIPConfigurations[0].Id -Protocol Tcp -FrontendPortRangeStart 3360 -FrontendPortRangeEnd 3362 -BackendPort 3370 | Set-AzureRmLoadBalancer

        Assert-AreEqual 1 @($lb.InboundNatPools).Count
        Assert-AreEqual $inboundNatPoolName $lb.InboundNatPools[0].Name
        Assert-AreEqual 3360 $lb.InboundNatPools[0].FrontendPortRangeStart
        Assert-AreEqual 3362 $lb.InboundNatPools[0].FrontendPortRangeEnd
        Assert-AreEqual 3370 $lb.InboundNatPools[0].BackendPort
        Assert-AreEqual Tcp $lb.InboundNatPools[0].Protocol

        $inboundNatPoolName2 = Get-ResourceName
        $lb = Get-AzureRmLoadBalancer -Name $lbName -ResourceGroupName $rgname | Add-AzureRmLoadBalancerInboundNatPoolConfig -Name $inboundNatPoolName2 -FrontendIPConfigurationId $lb.FrontendIPConfigurations[0].Id -Protocol Udp -FrontendPortRangeStart 3366 -FrontendPortRangeEnd 3368 -BackendPort 3376 | Set-AzureRmLoadBalancer
        
        Assert-AreEqual 2 @($lb.InboundNatPools).Count
        Assert-AreEqual $inboundNatPoolName2 $lb.InboundNatPools[1].Name
        Assert-AreEqual 3366 $lb.InboundNatPools[1].FrontendPortRangeStart
        Assert-AreEqual 3368 $lb.InboundNatPools[1].FrontendPortRangeEnd
        Assert-AreEqual 3376 $lb.InboundNatPools[1].BackendPort
        Assert-AreEqual Udp $lb.InboundNatPools[1].Protocol

        $lb = Get-AzureRmLoadBalancer -Name $lbName -ResourceGroupName $rgname | Set-AzureRmLoadBalancerInboundNatPoolConfig -Name $inboundNatPoolName2 -FrontendIPConfigurationId $lb.FrontendIPConfigurations[0].Id -Protocol Tcp -FrontendPortRangeStart 3363 -FrontendPortRangeEnd 3364 -BackendPort 3373 | Set-AzureRmLoadBalancer
        Assert-AreEqual 2 @($lb.InboundNatPools).Count
        Assert-AreEqual $inboundNatPoolName2 $lb.InboundNatPools[1].Name
        Assert-AreEqual 3363 $lb.InboundNatPools[1].FrontendPortRangeStart
        Assert-AreEqual 3364 $lb.InboundNatPools[1].FrontendPortRangeEnd
        Assert-AreEqual 3373 $lb.InboundNatPools[1].BackendPort
        Assert-AreEqual Tcp $lb.InboundNatPools[1].Protocol


        $inboundNatPoolConfig = Get-AzureRmLoadBalancer -Name $lbName -ResourceGroupName $rgname | Get-AzureRmLoadBalancerInboundNatPoolConfig -Name $inboundNatPoolName2
        $inboundNatPoolConfigList = Get-AzureRmLoadBalancer -Name $lbName -ResourceGroupName $rgname | Get-AzureRmLoadBalancerInboundNatPoolConfig
        Assert-AreEqual 2 @($inboundNatPoolConfigList).Count
        Assert-AreEqual $inboundNatPoolName $inboundNatPoolConfigList[0].Name
        Assert-AreEqual $inboundNatPoolName2 $inboundNatPoolConfigList[1].Name
        Assert-AreEqual $inboundNatPoolConfig.Name $inboundNatPoolConfigList[1].Name

        $lb =  Get-AzureRmLoadBalancer -Name $lbName -ResourceGroupName $rgname | Remove-AzureRmLoadBalancerInboundNatPoolConfig -Name $inboundNatPoolName2 | Set-AzureRmLoadBalancer
        Assert-AreEqual 1 @($lb.InboundNatPools).Count
        Assert-AreEqual $inboundNatPoolName $lb.InboundNatPools[0].Name

        # Delete
        $deleteLb = $lb | Remove-AzureRmLoadBalancer -PassThru -Force
        Assert-AreEqual true $deleteLb
        
        $list = Get-AzureRmLoadBalancer -ResourceGroupName $rgname
        Assert-AreEqual 0 @($list).Count
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Tests creating new public Load balancer and CRUD inbound nat pools on the load balancer
#>
function Test-LoadBalancerInboundNatPoolConfigCRUD-PublicLB
{
    # Setup
    $rgname = Get-ResourceGroupName
    $vnetName = Get-ResourceName
    $subnetName = Get-ResourceName
    $publicIpName = Get-ResourceName
    $domainNameLabel = Get-ResourceName
    $lbName = Get-ResourceName
    $frontendName = Get-ResourceName
    $inboundNatPoolName = Get-ResourceName
    $rglocation = "West US" 
    $resourceTypeParent = "Microsoft.Network/loadBalancers"
    $location = "West US" 
    
    try 
    {
        # Create the resource group
        $resourceGroup = New-AzureRmResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval" } 
        
        # Create the publicip
        $publicip = New-AzureRmPublicIpAddress -ResourceGroupName $rgname -name $publicIpName -location $location -AllocationMethod Dynamic -DomainNameLabel $domainNameLabel

        # Create LoadBalancer with one Inbound NAT Pool
        $frontend = New-AzureRmLoadBalancerFrontendIpConfig -Name $frontendName -PublicIpAddress $publicip
        $inboundNatPool = New-AzureRmLoadBalancerInboundNatPoolConfig -Name $inboundNatPoolName -FrontendIPConfigurationId $frontend.Id -Protocol Tcp -FrontendPortRangeStart 3360 -FrontendPortRangeEnd 3362 -BackendPort 3370 
        $actualLb = New-AzureRmLoadBalancer -Name $lbName -ResourceGroupName $rgname -Location $location -FrontendIpConfiguration $frontend -InboundNatPool $inboundNatPool
        
        $expectedLb = Get-AzureRmLoadBalancer -Name $lbName -ResourceGroupName $rgname

        # LB Verifications
        Assert-AreEqual $expectedLb.ResourceGroupName $actualLb.ResourceGroupName
        Assert-AreEqual $expectedLb.Name $actualLb.Name
        Assert-AreEqual $expectedLb.Location $actualLb.Location
        Assert-AreEqual "Succeeded" $expectedLb.ProvisioningState
        Assert-NotNull $expectedLb.ResourceGuid
        Assert-AreEqual 1 @($expectedLb.FrontendIPConfigurations).Count
        
        Assert-AreEqual 1 @($expectedLb.InboundNatPools).Count
        Assert-AreEqual $inboundNatPoolName $expectedLb.InboundNatPools[0].Name
        Assert-AreEqual 3360 $expectedLb.InboundNatPools[0].FrontendPortRangeStart
        Assert-AreEqual 3362 $expectedLb.InboundNatPools[0].FrontendPortRangeEnd
        Assert-AreEqual 3370 $expectedLb.InboundNatPools[0].BackendPort
        Assert-AreEqual Tcp $expectedLb.InboundNatPools[0].Protocol
        Assert-AreEqual $expectedLb.FrontendIPConfigurations[0].Id $expectedLb.InboundNatPools[0].FrontendIPConfiguration.Id

        # Test InboundNatPool cmdlets
        $inboundNatPoolName2 = Get-ResourceName
        $lb = Get-AzureRmLoadBalancer -Name $lbName -ResourceGroupName $rgname 
        $lb = Add-AzureRmLoadBalancerInboundNatPoolConfig -LoadBalancer $lb -Name $inboundNatPoolName2 -FrontendIPConfiguration $lb.FrontendIPConfigurations[0] -Protocol Udp -FrontendPortRangeStart 3366 -FrontendPortRangeEnd 3368 -BackendPort 3376 | Set-AzureRmLoadBalancer
        
        Assert-AreEqual 2 @($lb.InboundNatPools).Count
        Assert-AreEqual $inboundNatPoolName2 $lb.InboundNatPools[1].Name
        Assert-AreEqual 3366 $lb.InboundNatPools[1].FrontendPortRangeStart
        Assert-AreEqual 3368 $lb.InboundNatPools[1].FrontendPortRangeEnd
        Assert-AreEqual 3376 $lb.InboundNatPools[1].BackendPort
        Assert-AreEqual Udp $lb.InboundNatPools[1].Protocol

        $lb = Get-AzureRmLoadBalancer -Name $lbName -ResourceGroupName $rgname | Set-AzureRmLoadBalancerInboundNatPoolConfig -Name $inboundNatPoolName2 -FrontendIPConfigurationId $lb.FrontendIPConfigurations[0].Id -Protocol Tcp -FrontendPortRangeStart 3363 -FrontendPortRangeEnd 3364 -BackendPort 3373 | Set-AzureRmLoadBalancer
        Assert-AreEqual 2 @($lb.InboundNatPools).Count
        Assert-AreEqual $inboundNatPoolName2 $lb.InboundNatPools[1].Name
        Assert-AreEqual 3363 $lb.InboundNatPools[1].FrontendPortRangeStart
        Assert-AreEqual 3364 $lb.InboundNatPools[1].FrontendPortRangeEnd
        Assert-AreEqual 3373 $lb.InboundNatPools[1].BackendPort
        Assert-AreEqual Tcp $lb.InboundNatPools[1].Protocol

        $inboundNatPoolConfig = Get-AzureRmLoadBalancer -Name $lbName -ResourceGroupName $rgname | Get-AzureRmLoadBalancerInboundNatPoolConfig -Name $inboundNatPoolName2
        $inboundNatPoolConfigList = Get-AzureRmLoadBalancer -Name $lbName -ResourceGroupName $rgname | Get-AzureRmLoadBalancerInboundNatPoolConfig
        Assert-AreEqual 2 @($inboundNatPoolConfigList).Count
        Assert-AreEqual $inboundNatPoolName $inboundNatPoolConfigList[0].Name
        Assert-AreEqual $inboundNatPoolName2 $inboundNatPoolConfigList[1].Name
        Assert-AreEqual $inboundNatPoolConfig.Name $inboundNatPoolConfigList[1].Name

        $lb =  Get-AzureRmLoadBalancer -Name $lbName -ResourceGroupName $rgname | Remove-AzureRmLoadBalancerInboundNatPoolConfig -Name $inboundNatPoolName2 | Set-AzureRmLoadBalancer
        Assert-AreEqual 1 @($lb.InboundNatPools).Count
        Assert-AreEqual $inboundNatPoolName $lb.InboundNatPools[0].Name

        # Delete LB
        $deleteLb = Remove-AzureRmLoadBalancer -Name $lbName -ResourceGroupName $rgname -PassThru -Force
        Assert-AreEqual true $deleteLb
        
        $list = Get-AzureRmLoadBalancer -ResourceGroupName $rgname
        Assert-AreEqual 0 @($list).Count
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Tests creating a Multi vip public Load balancer.
#>
function Test-LoadBalancerMultiVip-Public
{
    # Setup
    $rgname = Get-ResourceGroupName
    $publicIp1Name = Get-ResourceName
	$publicIp2Name = Get-ResourceName
	$publicIp3Name = Get-ResourceName
	$publicIp4Name = Get-ResourceName
    $lbName = Get-ResourceName
    $frontend1Name = Get-ResourceName
	$frontend2Name = Get-ResourceName
	$frontend3Name = Get-ResourceName
	$frontend4Name = Get-ResourceName
    $backendAddressPoolName = Get-ResourceName
    $probeName = Get-ResourceName
    $inboundNatRuleName = Get-ResourceName
    $lbruleName = Get-ResourceName
    $rglocation = Get-ProviderLocation ResourceManagement
    $resourceTypeParent = "Microsoft.Network/loadBalancers"
    $location = Get-ProviderLocation $resourceTypeParent
    
    try 
    {
        # Create the resource group
        $resourceGroup = New-AzureRmResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval" } 

        # Create the publicips
        $publicip1 = New-AzureRmPublicIpAddress -ResourceGroupName $rgname -name $publicIp1Name -location $location -AllocationMethod Dynamic
		$publicip2 = New-AzureRmPublicIpAddress -ResourceGroupName $rgname -name $publicIp2Name -location $location -AllocationMethod Dynamic
		$publicip3 = New-AzureRmPublicIpAddress -ResourceGroupName $rgname -name $publicIp3Name -location $location -AllocationMethod Dynamic
		$publicip4 = New-AzureRmPublicIpAddress -ResourceGroupName $rgname -name $publicIp4Name -location $location -AllocationMethod Dynamic

        # Create LoadBalancer
        $frontend1 = New-AzureRmLoadBalancerFrontendIpConfig -Name $frontend1Name -PublicIpAddress $publicip1
		$frontend2 = New-AzureRmLoadBalancerFrontendIpConfig -Name $frontend2Name -PublicIpAddressId $publicip2.Id

        $backendAddressPool = New-AzureRmLoadBalancerBackendAddressPoolConfig -Name $backendAddressPoolName
        $probe = New-AzureRmLoadBalancerProbeConfig -Name $probeName -RequestPath healthcheck.aspx -Protocol http -Port 80 -IntervalInSeconds 15 -ProbeCount 2
        $inboundNatRule = New-AzureRmLoadBalancerInboundNatRuleConfig -Name $inboundNatRuleName -FrontendIPConfiguration $frontend1 -Protocol Tcp -FrontendPort 3389 -BackendPort 3389 -IdleTimeoutInMinutes 15 -EnableFloatingIP
        $lbrule = New-AzureRmLoadBalancerRuleConfig -Name $lbruleName -FrontendIPConfiguration $frontend2 -BackendAddressPool $backendAddressPool -Probe $probe -Protocol Tcp -FrontendPort 80 -BackendPort 80 -IdleTimeoutInMinutes 15 -EnableFloatingIP -LoadDistribution SourceIP
        $lb = New-AzureRmLoadBalancer -Name $lbName -ResourceGroupName $rgname -Location $location -FrontendIpConfiguration $frontend1,$frontend2  -BackendAddressPool $backendAddressPool -Probe $probe -InboundNatRule $inboundNatRule -LoadBalancingRule $lbrule
        
        # Verification
        Assert-AreEqual $rgname $lb.ResourceGroupName
        Assert-AreEqual $lbName $lb.Name
        Assert-NotNull $lb.Location
        Assert-AreEqual "Succeeded" $lb.ProvisioningState
        Assert-NotNull $lb.ResourceGuid
        Assert-AreEqual 2 @($lb.FrontendIPConfigurations).Count
        
        Assert-AreEqual $frontend1Name $lb.FrontendIPConfigurations[0].Name
        Assert-AreEqual $publicip1.Id $lb.FrontendIPConfigurations[0].PublicIpAddress.Id
		Assert-Null $lb.FrontendIPConfigurations[0].Subnet
		
		Assert-AreEqual $frontend2Name $lb.FrontendIPConfigurations[1].Name
        Assert-AreEqual $publicip2.Id $lb.FrontendIPConfigurations[1].PublicIpAddress.Id
		Assert-Null $lb.FrontendIPConfigurations[1].Subnet
		
        Assert-AreEqual $backendAddressPoolName $lb.BackendAddressPools[0].Name
		
        Assert-AreEqual $probeName $lb.Probes[0].Name
        Assert-NotNull $lb.Probes[0].RequestPath
		
        Assert-AreEqual $inboundNatRuleName $lb.InboundNatRules[0].Name
        Assert-AreEqual $lb.FrontendIPConfigurations[0].Id $lb.InboundNatRules[0].FrontendIPConfiguration.Id
		
        Assert-AreEqual $lbruleName $lb.LoadBalancingRules[0].Name
        Assert-AreEqual $lb.FrontendIPConfigurations[1].Id $lb.LoadBalancingRules[0].FrontendIPConfiguration.Id
        Assert-AreEqual $lb.BackendAddressPools[0].Id $lb.LoadBalancingRules[0].BackendAddressPool.Id

		# Verify public ip reference
		$publicip1 = Get-AzureRmPublicIpAddress -ResourceGroupName $rgname -name $publicIp1Name
        Assert-AreEqual $lb.FrontendIPConfigurations[0].Id $publicip1.IpConfiguration.Id

		$publicip2 = Get-AzureRmPublicIpAddress -ResourceGroupName $rgname -name $publicIp2Name
        Assert-AreEqual $lb.FrontendIPConfigurations[1].Id $publicip2.IpConfiguration.Id

		# Add a new frontendip config
		$lb = Get-AzureRmLoadBalancer -Name $lbName -ResourceGroupName $rgname | Add-AzureRmLoadBalancerFrontendIpConfig -Name $frontend3Name -PublicIpAddress $publicip3 | Set-AzureRmLoadBalancer
		Assert-AreEqual 3 @($lb.FrontendIPConfigurations).Count

		Assert-AreEqual $frontend3Name $lb.FrontendIPConfigurations[2].Name
        Assert-AreEqual $publicip3.Id $lb.FrontendIPConfigurations[2].PublicIpAddress.Id
		Assert-Null $lb.FrontendIPConfigurations[2].Subnet
		
		$publicip3 = Get-AzureRmPublicIpAddress -ResourceGroupName $rgname -name $publicIp3Name
        Assert-AreEqual $lb.FrontendIPConfigurations[2].Id $publicip3.IpConfiguration.Id

		# set a new frontendip config
		$lb = Get-AzureRmLoadBalancer -Name $lbName -ResourceGroupName $rgname | Set-AzureRmLoadBalancerFrontendIpConfig -Name $frontend3Name -PublicIpAddress $publicip4 | Set-AzureRmLoadBalancer

		Assert-AreEqual 3 @($lb.FrontendIPConfigurations).Count

		Assert-AreEqual $frontend3Name $lb.FrontendIPConfigurations[2].Name
        Assert-AreEqual $publicip4.Id $lb.FrontendIPConfigurations[2].PublicIpAddress.Id
		Assert-Null $lb.FrontendIPConfigurations[2].Subnet

		$publicip3 = Get-AzureRmPublicIpAddress -ResourceGroupName $rgname -name $publicIp3Name
        Assert-Null $publicip3.IpConfiguration

		$publicip4 = Get-AzureRmPublicIpAddress -ResourceGroupName $rgname -name $publicIp4Name
        Assert-AreEqual $lb.FrontendIPConfigurations[2].Id $publicip4.IpConfiguration.Id

		# Get a frontendip config
		$frontendip = Get-AzureRmLoadBalancer -Name $lbName -ResourceGroupName $rgname | Get-AzureRmLoadBalancerFrontendIpConfig -Name $frontend3Name

		Assert-AreEqual $frontend3Name $frontendip.Name
        Assert-AreEqual $publicip4.Id $frontendip.PublicIpAddress.Id
		Assert-Null $frontendip.Subnet

		# list all frontendip configs
		$frontendips = Get-AzureRmLoadBalancer -Name $lbName -ResourceGroupName $rgname | Get-AzureRmLoadBalancerFrontendIpConfig

		Assert-AreEqual 3 @($frontendips).Count

		# Remove a frontendip config
		$lb = Get-AzureRmLoadBalancer -Name $lbName -ResourceGroupName $rgname | Remove-AzureRmLoadBalancerFrontendIpConfig -Name $frontend3Name | Set-AzureRmLoadBalancer
		Assert-AreEqual 2 @($lb.FrontendIPConfigurations).Count

		Assert-AreEqual $frontend1Name $lb.FrontendIPConfigurations[0].Name
        Assert-AreEqual $publicip1.Id $lb.FrontendIPConfigurations[0].PublicIpAddress.Id
		Assert-Null $lb.FrontendIPConfigurations[0].Subnet
		
		Assert-AreEqual $frontend2Name $lb.FrontendIPConfigurations[1].Name
        Assert-AreEqual $publicip2.Id $lb.FrontendIPConfigurations[1].PublicIpAddress.Id
		Assert-Null $lb.FrontendIPConfigurations[1].Subnet

        # Delete
        $deleteLb = Remove-AzureRmLoadBalancer -Name $lbName -ResourceGroupName $rgname -PassThru -Force
        Assert-AreEqual true $deleteLb
        
		$list = Get-AzureRmLoadBalancer -ResourceGroupName $rgname
        Assert-AreEqual 0 @($list).Count

		# Verify public ip reference
		$publicip1 = Get-AzureRmPublicIpAddress -ResourceGroupName $rgname -name $publicIp1Name
        Assert-Null $publicip1.IpConfiguration

		$publicip2 = Get-AzureRmPublicIpAddress -ResourceGroupName $rgname -name $publicIp2Name
        Assert-Null $publicip2.IpConfiguration
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Tests creating a Multi vip internal Load balancer.
#>
function Test-LoadBalancerMultiVip-Internal
{
	# Setup
    $rgname = Get-ResourceGroupName
    $subnet1Name = Get-ResourceName
	$subnet2Name = Get-ResourceName
	$vnetName = Get-ResourceName
    $lbName = Get-ResourceName
    $frontend1Name = Get-ResourceName
	$frontend2Name = Get-ResourceName
	$frontend3Name = Get-ResourceName
	$frontend4Name = Get-ResourceName
    $backendAddressPoolName = Get-ResourceName
    $probeName = Get-ResourceName
    $inboundNatRuleName = Get-ResourceName
    $lbruleName = Get-ResourceName
    $rglocation = Get-ProviderLocation ResourceManagement
    $resourceTypeParent = "Microsoft.Network/loadBalancers"
    $location = Get-ProviderLocation $resourceTypeParent

    try 
    {
        # Create the resource group
        $resourceGroup = New-AzureRmResourceGroup -Name $rgname -Location $rglocation

        # Create the Virtual Network
        $subnet1 = New-AzureRmVirtualNetworkSubnetConfig -Name $subnet1Name -AddressPrefix 10.0.0.0/24
		$subnet2 = New-AzureRmVirtualNetworkSubnetConfig -Name $subnet2Name -AddressPrefix 10.0.1.0/24
        $vnet = New-AzureRmvirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnet1,$subnet2

        # Create LoadBalancer
        $frontend1 = New-AzureRmLoadBalancerFrontendIpConfig -Name $frontend1Name -Subnet $vnet.Subnets[0]
		$frontend2 = New-AzureRmLoadBalancerFrontendIpConfig -Name $frontend2Name -SubnetId $vnet.Subnets[1].Id

        $backendAddressPool = New-AzureRmLoadBalancerBackendAddressPoolConfig -Name $backendAddressPoolName
        $probe = New-AzureRmLoadBalancerProbeConfig -Name $probeName -RequestPath healthcheck.aspx -Protocol http -Port 80 -IntervalInSeconds 15 -ProbeCount 2
        $inboundNatRule = New-AzureRmLoadBalancerInboundNatRuleConfig -Name $inboundNatRuleName -FrontendIPConfiguration $frontend1 -Protocol Tcp -FrontendPort 3389 -BackendPort 3389 -IdleTimeoutInMinutes 15 -EnableFloatingIP
        $lbrule = New-AzureRmLoadBalancerRuleConfig -Name $lbruleName -FrontendIPConfiguration $frontend2 -BackendAddressPool $backendAddressPool -Probe $probe -Protocol Tcp -FrontendPort 80 -BackendPort 80 -IdleTimeoutInMinutes 15 -EnableFloatingIP -LoadDistribution SourceIP
        $lb = New-AzureRmLoadBalancer -Name $lbName -ResourceGroupName $rgname -Location $location -FrontendIpConfiguration $frontend1,$frontend2  -BackendAddressPool $backendAddressPool -Probe $probe -InboundNatRule $inboundNatRule -LoadBalancingRule $lbrule
        
        # Verification
        Assert-AreEqual $rgname $lb.ResourceGroupName
        Assert-AreEqual $lbName $lb.Name
        Assert-NotNull $lb.Location
        Assert-AreEqual "Succeeded" $lb.ProvisioningState
        Assert-NotNull $lb.ResourceGuid
        Assert-AreEqual 2 @($lb.FrontendIPConfigurations).Count
        
        Assert-AreEqual $frontend1Name $lb.FrontendIPConfigurations[0].Name
        Assert-AreEqual $vnet.Subnets[0].Id $lb.FrontendIPConfigurations[0].Subnet.Id
		Assert-Null $lb.FrontendIPConfigurations[0].PublicIpAddress
		
		Assert-AreEqual $frontend2Name $lb.FrontendIPConfigurations[1].Name
		Assert-AreEqual $vnet.Subnets[1].Id $lb.FrontendIPConfigurations[1].Subnet.Id
		Assert-Null $lb.FrontendIPConfigurations[1].PublicIpAddress
				
        Assert-AreEqual $backendAddressPoolName $lb.BackendAddressPools[0].Name
		
        Assert-AreEqual $probeName $lb.Probes[0].Name
        Assert-NotNull $lb.Probes[0].RequestPath
		
        Assert-AreEqual $inboundNatRuleName $lb.InboundNatRules[0].Name
        Assert-AreEqual $lb.FrontendIPConfigurations[0].Id $lb.InboundNatRules[0].FrontendIPConfiguration.Id
		
        Assert-AreEqual $lbruleName $lb.LoadBalancingRules[0].Name
        Assert-AreEqual $lb.FrontendIPConfigurations[1].Id $lb.LoadBalancingRules[0].FrontendIPConfiguration.Id
        Assert-AreEqual $lb.BackendAddressPools[0].Id $lb.LoadBalancingRules[0].BackendAddressPool.Id
		
		# Verify subnet reference
		$vnet = Get-AzureRmvirtualNetwork -Name $vnetName -ResourceGroupName $rgname
		Assert-AreEqual 1 @($vnet.Subnets[0].IpConfigurations).Count
        Assert-AreEqual $lb.FrontendIPConfigurations[0].Id $vnet.Subnets[0].IpConfigurations[0].Id
		Assert-AreEqual 1 @($vnet.Subnets[1].IpConfigurations).Count
		Assert-AreEqual $lb.FrontendIPConfigurations[1].Id $vnet.Subnets[1].IpConfigurations[0].Id

		# Add a new frontendip config
		$lb = Get-AzureRmLoadBalancer -Name $lbName -ResourceGroupName $rgname | Add-AzureRmLoadBalancerFrontendIpConfig -Name $frontend3Name -Subnet $vnet.Subnets[1] | Set-AzureRmLoadBalancer
		Assert-AreEqual 3 @($lb.FrontendIPConfigurations).Count
		
		Assert-AreEqual $frontend3Name $lb.FrontendIPConfigurations[2].Name
		Assert-AreEqual $vnet.Subnets[1].Id $lb.FrontendIPConfigurations[2].Subnet.Id
		Assert-Null $lb.FrontendIPConfigurations[2].PublicIpAddress

		# Verify subnet reference
		$vnet = Get-AzureRmvirtualNetwork -Name $vnetName -ResourceGroupName $rgname
		Assert-AreEqual 1 @($vnet.Subnets[0].IpConfigurations).Count
        Assert-AreEqual $lb.FrontendIPConfigurations[0].Id $vnet.Subnets[0].IpConfigurations[0].Id
		Assert-AreEqual 2 @($vnet.Subnets[1].IpConfigurations).Count
		Assert-AreEqual $lb.FrontendIPConfigurations[1].Id $vnet.Subnets[1].IpConfigurations[0].Id
		Assert-AreEqual $lb.FrontendIPConfigurations[2].Id $vnet.Subnets[1].IpConfigurations[1].Id

		# set a new frontendip config
		$lb = Get-AzureRmLoadBalancer -Name $lbName -ResourceGroupName $rgname | Set-AzureRmLoadBalancerFrontendIpConfig -Name $frontend3Name -SubnetId $vnet.Subnets[0].Id | Set-AzureRmLoadBalancer
		
		Assert-AreEqual 3 @($lb.FrontendIPConfigurations).Count
		
		Assert-AreEqual $frontend3Name $lb.FrontendIPConfigurations[2].Name
		Assert-AreEqual $vnet.Subnets[0].Id $lb.FrontendIPConfigurations[2].Subnet.Id
		Assert-Null $lb.FrontendIPConfigurations[2].PublicIpAddress
		
		# Verify subnet reference
		$vnet = Get-AzureRmvirtualNetwork -Name $vnetName -ResourceGroupName $rgname
		Assert-AreEqual 2 @($vnet.Subnets[0].IpConfigurations).Count
        Assert-AreEqual $lb.FrontendIPConfigurations[0].Id $vnet.Subnets[0].IpConfigurations[0].Id
		Assert-AreEqual $lb.FrontendIPConfigurations[2].Id $vnet.Subnets[0].IpConfigurations[1].Id
		Assert-AreEqual 1 @($vnet.Subnets[1].IpConfigurations).Count
		Assert-AreEqual $lb.FrontendIPConfigurations[1].Id $vnet.Subnets[1].IpConfigurations[0].Id
		
		# Get a frontendip config
		$frontendip = Get-AzureRmLoadBalancer -Name $lbName -ResourceGroupName $rgname | Get-AzureRmLoadBalancerFrontendIpConfig -Name $frontend3Name
		
		Assert-AreEqual $frontend3Name $frontendip.Name
		Assert-AreEqual $vnet.Subnets[0].Id $frontendip.Subnet.Id
		Assert-Null $frontendip.PublicIpAddress
		
		# list all frontendip configs
		$frontendips = Get-AzureRmLoadBalancer -Name $lbName -ResourceGroupName $rgname | Get-AzureRmLoadBalancerFrontendIpConfig
		
		Assert-AreEqual 3 @($frontendips).Count
		
		# Remove a frontendip config
		$lb = Get-AzureRmLoadBalancer -Name $lbName -ResourceGroupName $rgname | Remove-AzureRmLoadBalancerFrontendIpConfig -Name $frontend3Name | Set-AzureRmLoadBalancer
		Assert-AreEqual 2 @($lb.FrontendIPConfigurations).Count
		
		Assert-AreEqual $frontend1Name $lb.FrontendIPConfigurations[0].Name
        Assert-AreEqual $vnet.Subnets[0].Id $lb.FrontendIPConfigurations[0].Subnet.Id
		Assert-Null $lb.FrontendIPConfigurations[0].PublicIpAddress
		
		Assert-AreEqual $frontend2Name $lb.FrontendIPConfigurations[1].Name
		Assert-AreEqual $vnet.Subnets[1].Id $lb.FrontendIPConfigurations[1].Subnet.Id
		Assert-Null $lb.FrontendIPConfigurations[1].PublicIpAddress

        # Delete
        $deleteLb = Remove-AzureRmLoadBalancer -Name $lbName -ResourceGroupName $rgname -PassThru -Force
        Assert-AreEqual true $deleteLb
        
		$list = Get-AzureRmLoadBalancer -ResourceGroupName $rgname
        Assert-AreEqual 0 @($list).Count

		# Verify subnet references
		$vnet = Get-AzureRmvirtualNetwork -Name $vnetName -ResourceGroupName $rgname
		Assert-AreEqual 0 @($vnet.Subnets[0].IpConfigurations).Count
		Assert-AreEqual 0 @($vnet.Subnets[1].IpConfigurations).Count

    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Tests creating a public Load balancer and set using object assignments
#>
function Test-SetLoadBalancerObjectAssignment
{
    # Setup
    $rgname = Get-ResourceGroupName
    $vnetName = Get-ResourceName
    $subnetName = Get-ResourceName
    $publicIpName = Get-ResourceName
    $domainNameLabel = Get-ResourceName
    $lbName = Get-ResourceName
    $frontendName = Get-ResourceName
    $backendAddressPoolName = Get-ResourceName
    $probeName = Get-ResourceName
    $inboundNatRuleName = Get-ResourceName
    $lbruleName = Get-ResourceName
    $rglocation = Get-ProviderLocation ResourceManagement
    $resourceTypeParent = "Microsoft.Network/loadBalancers"
    $location = Get-ProviderLocation $resourceTypeParent
    
    try 
    {
        # Create the resource group
        $resourceGroup = New-AzureRmResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval" } 
        
        # Create the publicip
        $publicip = New-AzureRmPublicIpAddress -ResourceGroupName $rgname -name $publicIpName -location $location -AllocationMethod Dynamic -DomainNameLabel $domainNameLabel

        # Create LoadBalancer
        $frontend = New-AzureRmLoadBalancerFrontendIpConfig -Name $frontendName -PublicIpAddress $publicip
        $backendAddressPool = New-AzureRmLoadBalancerBackendAddressPoolConfig -Name $backendAddressPoolName
        $probe = New-AzureRmLoadBalancerProbeConfig -Name $probeName -RequestPath healthcheck.aspx -Protocol http -Port 80 -IntervalInSeconds 15 -ProbeCount 2
        $inboundNatRule = New-AzureRmLoadBalancerInboundNatRuleConfig -Name $inboundNatRuleName -FrontendIPConfiguration $frontend -Protocol Tcp -FrontendPort 3389 -BackendPort 3389 -IdleTimeoutInMinutes 15 -EnableFloatingIP
        $lbrule = New-AzureRmLoadBalancerRuleConfig -Name $lbruleName -FrontendIPConfiguration $frontend -BackendAddressPool $backendAddressPool -Protocol Tcp -FrontendPort 80 -BackendPort 80 -IdleTimeoutInMinutes 15 -EnableFloatingIP -LoadDistribution SourceIP
        $lb = New-AzureRmLoadBalancer -Name $lbName -ResourceGroupName $rgname -Location $location -FrontendIpConfiguration $frontend -BackendAddressPool $backendAddressPool -Probe $probe -InboundNatRule $inboundNatRule -LoadBalancingRule $lbrule
  
        # Verification
        Assert-AreEqual $rgname $lb.ResourceGroupName
        Assert-AreEqual $lbName $lb.Name
        Assert-NotNull $lb.Location
        Assert-AreEqual "Succeeded" $lb.ProvisioningState
        Assert-NotNull $lb.ResourceGuid
        Assert-AreEqual 1 @($lb.FrontendIPConfigurations).Count
        
        Assert-AreEqual $frontendName $lb.FrontendIPConfigurations[0].Name
        Assert-AreEqual $publicip.Id $lb.FrontendIPConfigurations[0].PublicIpAddress.Id
        Assert-Null $lb.FrontendIPConfigurations[0].PrivateIpAddress

        Assert-AreEqual $backendAddressPoolName $lb.BackendAddressPools[0].Name

        Assert-AreEqual $probeName $lb.Probes[0].Name
        Assert-AreEqual $probe.RequestPath $lb.Probes[0].RequestPath

        Assert-AreEqual $inboundNatRuleName $lb.InboundNatRules[0].Name
        Assert-AreEqual $lb.FrontendIPConfigurations[0].Id $lb.InboundNatRules[0].FrontendIPConfiguration.Id

        Assert-AreEqual $lbruleName $lb.LoadBalancingRules[0].Name
        Assert-AreEqual $lb.FrontendIPConfigurations[0].Id $lb.LoadBalancingRules[0].FrontendIPConfiguration.Id
        Assert-AreEqual $lb.BackendAddressPools[0].Id $lb.LoadBalancingRules[0].BackendAddressPool.Id

		# Assign Probe to the lb rule
		Assert-Null  $lb.LoadBalancingRules[0].Probe

		$lb.LoadBalancingRules[0].Probe = $lb.Probes[0]
		$lb = $lb | Set-AzureRmLoadBalancer

		Assert-NotNull $lb.LoadBalancingRules[0].Probe
		Assert-AreEqual $lb.LoadBalancingRules[0].Probe.Id $lb.Probes[0].Id

        # Delete
        $deleteLb = Remove-AzureRmLoadBalancer -Name $lbName -ResourceGroupName $rgname -PassThru -Force
        Assert-AreEqual true $deleteLb
        
        $list = Get-AzureRmLoadBalancer -ResourceGroupName $rgname
        Assert-AreEqual 0 @($list).Count
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}