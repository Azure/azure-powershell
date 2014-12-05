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
Tests creating new simple Load balancer.
#>
function Test-LoadBalancerCRUD
{
    # Setup
    $rgname = Get-ResourceGroupName
    $vnetName = Get-ResourceName
    $subnetName = Get-ResourceName
    $publicIpName = Get-ResourceName
    $nicName = Get-ResourceName
    $domainNameLabel = Get-ResourceName
    $lbName = Get-ResourceName
    $frontendName = Get-ResourceName
    $backendAddressPoolName = Get-ResourceName
    $probeName = Get-ResourceName
    $inboundNatRuleName = Get-ResourceName
    $lbruleName = Get-ResourceName
    $rglocation = Get-ProviderLocation ResourceManagement
    $resourceTypeParent = "Microsoft.Network/virtualNetworks"
    $location = Get-ProviderLocation $resourceTypeParent
    
    try 
    {
        # Create the resource group
        $resourceGroup = New-AzureResourceGroup -Name $rgname -Location $rglocation -Tags @{Name = "testtag"; Value = "testval"} 
        
        # Create the Virtual Network
        $subnet = New-AzureVirtualNetworkSubnetConfig -Name $subnetName -AddressPrefix 10.0.1.0/24
        $vnet = New-AzurevirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnet
        
        # Create the publicip
        $publicip = New-AzurePublicIpAddress -ResourceGroupName $rgname -name $publicIpName -location $location -AllocationMethod Dynamic -DomainNameLabel $domainNameLabel

        # Create NetworkInterface
        $nic = New-AzureNetworkInterface -Name $nicName -ResourceGroupName $rgname -Location $location -AllocationMethod dynamic -Subnet $vnet.Properties.Subnets[0] -PublicIpAddress $publicip

        $frontend = New-AzureLoadBalancerFrontendIpConfig -Name $frontendName -AllocationMethod Dynamic -Subnet $vnet.Properties.Subnets[0]
        $backendAddressPool = New-AzureLoadBalancerBackendAddressPoolConfig -Name $backendAddressPoolName -BackendIpConfiguration $nic.Properties.IpConfigurations[0]
        $probe = New-AzureLoadBalancerProbeConfig -Name $probeName -RequestPath healthcheck.aspx -Protocol http -Port 80 -IntervalInSeconds 15 -ProbeCount 2
        $inboundNatRule = New-AzureLoadBalancerInboundNatRuleConfig -Name $inboundNatRuleName -FrontendIPConfiguration $frontend -BackendIpConfiguration $nic.Properties.IpConfigurations[0] -Protocol Tcp -FrontendPort 3389 -BackendPort 3389 -IdleTimeoutInSeconds 15 -EnableFloatingIP
        $lbrule = New-AzureLoadBalancerRuleConfig -Name $lbruleName -FrontendIPConfiguration $frontend -BackendAddressPool $backendAddressPool -Probe $probe -Protocol Tcp -FrontendPort 80 -BackendPort 80 -IdleTimeoutInSeconds 15 -EnableFloatingIP
        $actualLb = New-AzureLoadBalancer -Name $lbName -ResourceGroupName $rgname -Location $location -FrontendIpConfiguration $frontend -BackendAddressPool $backendAddressPool -Probe $probe -InboundNatRule $inboundNatRule -LoadBalancingRule $lbrule
        
        $expectedLb = Get-AzureLoadBalancer -Name $lbName -ResourceGroupName $rgname

        # Verification
        Assert-AreEqual $expectedLb.ResourceGroupName $actualLb.ResourceGroupName	
        Assert-AreEqual $expectedLb.Name $actualLb.Name	
        Assert-AreEqual $expectedLb.Location $actualLb.Location
        Assert-AreEqual "Succeeded" $expectedLb.Properties.ProvisioningState
        Assert-AreEqual 1 @($expectedLb.Properties.FrontendIPConfigurations).Count
        
        Assert-AreEqual $frontendName $expectedLb.Properties.FrontendIPConfigurations[0].Name
        Assert-AreEqual $vnet.Properties.Subnets[0].Id $expectedLb.Properties.FrontendIPConfigurations[0].Properties.Subnet.Id

        Assert-AreEqual $backendAddressPoolName $expectedLb.Properties.BackendAddressPools[0].Name
        Assert-AreEqual $nic.Properties.IpConfigurations[0].Id $expectedLb.Properties.BackendAddressPools[0].Properties.BackendIpConfigurations.Id

        Assert-AreEqual $probeName $expectedLb.Properties.Probes[0].Name
        Assert-AreEqual $probe.RequestPath $expectedLb.Properties.Probes[0].RequestPath

        Assert-AreEqual $inboundNatRuleName $expectedLb.Properties.InboundNatRules[0].Name
        Assert-AreEqual $expectedLb.Properties.FrontendIPConfigurations[0].Id $expectedLb.Properties.InboundNatRules[0].Properties.FrontendIPConfigurations[0].Id
        Assert-AreEqual $nic.Properties.IpConfigurations[0].Id $expectedLb.Properties.InboundNatRules[0].Properties.BackendIpConfiguration.Id

        Assert-AreEqual $lbruleName $expectedLb.Properties.LoadBalancingRules[0].Name
        Assert-AreEqual $expectedLb.Properties.FrontendIPConfigurations[0].Id $expectedLb.Properties.LoadBalancingRules[0].Properties.FrontendIPConfigurations[0].Id
        Assert-AreEqual $expectedLb.Properties.BackendAddressPools[0].Id $expectedLb.Properties.LoadBalancingRules[0].Properties.BackendAddressPool.Id

        # List
        $list = Get-AzureLoadBalancer -ResourceGroupName $rgname
        Assert-AreEqual 1 @($list).Count
        Assert-AreEqual $expectedLb.Etag $list[0].Etag
        Assert-AreEqual $expectedLb.Properties.FrontendIPConfigurations[0].Etag $list[0].Properties.FrontendIPConfigurations[0].Etag
        Assert-AreEqual $expectedLb.Properties.BackendAddressPools[0].Etag $list[0].Properties.BackendAddressPools[0].Etag
        Assert-AreEqual $expectedLb.Properties.InboundNatRules[0].Etag $list[0].Properties.InboundNatRules[0].Etag
        Assert-AreEqual $expectedLb.Properties.BackendAddressPools[0].Etag $list[0].Properties.BackendAddressPools[0].Etag

        # Delete
        $deleteLb = Remove-AzureLoadBalancer -Name $lbName -ResourceGroupName $rgname -PassThru -Force
        Assert-AreEqual true $deleteLb
        
        $list = Get-AzureLoadBalancer -ResourceGroupName $rgname
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
Tests creating new simple Load balancer using resource ids
#>
function Test-LoadBalancerCRUDUsingId
{
    # Setup
    $rgname = Get-ResourceGroupName
    $vnetName = Get-ResourceName
    $subnetName = Get-ResourceName
    $publicIpName = Get-ResourceName
    $nicName = Get-ResourceName
    $domainNameLabel = Get-ResourceName
    $lbName = Get-ResourceName
    $frontendName = Get-ResourceName
    $backendAddressPoolName = Get-ResourceName
    $probeName = Get-ResourceName
    $inboundNatRuleName = Get-ResourceName
    $lbruleName = Get-ResourceName
    $rglocation = Get-ProviderLocation ResourceManagement
    $resourceTypeParent = "Microsoft.Network/virtualNetworks"
    $location = Get-ProviderLocation $resourceTypeParent
    
    try 
    {
        # Create the resource group
        $resourceGroup = New-AzureResourceGroup -Name $rgname -Location $rglocation -Tags @{Name = "testtag"; Value = "testval"} 
        
        # Create the Virtual Network
        $subnet = New-AzureVirtualNetworkSubnetConfig -Name $subnetName -AddressPrefix 10.0.1.0/24
        $vnet = New-AzurevirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnet
        
        # Create the publicip
        $publicip = New-AzurePublicIpAddress -ResourceGroupName $rgname -name $publicIpName -location $location -AllocationMethod Dynamic -DomainNameLabel $domainNameLabel

        # Create NetworkInterface
        $nic = New-AzureNetworkInterface -Name $nicName -ResourceGroupName $rgname -Location $location -AllocationMethod dynamic -SubnetId $vnet.Properties.Subnets[0].Id -PublicIpAddressId $publicip.Id

        $frontend = New-AzureLoadBalancerFrontendIpConfig -Name $frontendName -AllocationMethod Dynamic -SubnetId $vnet.Properties.Subnets[0].Id
        $backendAddressPool = New-AzureLoadBalancerBackendAddressPoolConfig -Name $backendAddressPoolName -BackendIpConfigurationId $nic.Properties.IpConfigurations[0].Id
        $probe = New-AzureLoadBalancerProbeConfig -Name $probeName -RequestPath healthcheck.aspx -Protocol http -Port 80 -IntervalInSeconds 15 -ProbeCount 2
        $inboundNatRule = New-AzureLoadBalancerInboundNatRuleConfig -Name $inboundNatRuleName -FrontendIPConfigurationId $frontend.Id -BackendIpConfigurationId $nic.Properties.IpConfigurations[0].Id -Protocol Tcp -FrontendPort 3389 -BackendPort 3389 -IdleTimeoutInSeconds 15 -EnableFloatingIP
        $lbrule = New-AzureLoadBalancerRuleConfig -Name $lbruleName -FrontendIPConfigurationId $frontend.Id -BackendAddressPoolId $backendAddressPool.Id -ProbeId $probe.Id -Protocol Tcp -FrontendPort 80 -BackendPort 80 -IdleTimeoutInSeconds 15 -EnableFloatingIP
        $actualLb = New-AzureLoadBalancer -Name $lbName -ResourceGroupName $rgname -Location $location -FrontendIpConfiguration $frontend -BackendAddressPool $backendAddressPool -Probe $probe -InboundNatRule $inboundNatRule -LoadBalancingRule $lbrule
        
        $expectedLb = Get-AzureLoadBalancer -Name $lbName -ResourceGroupName $rgname
        
        # Verification
        Assert-AreEqual $expectedLb.ResourceGroupName $actualLb.ResourceGroupName	
        Assert-AreEqual $expectedLb.Name $actualLb.Name	
        Assert-AreEqual $expectedLb.Location $actualLb.Location
        Assert-AreEqual "Succeeded" $expectedLb.Properties.ProvisioningState
        Assert-AreEqual 1 @($expectedLb.Properties.FrontendIPConfigurations).Count
        
        Assert-AreEqual $frontendName $expectedLb.Properties.FrontendIPConfigurations[0].Name
        Assert-AreEqual $vnet.Properties.Subnets[0].Id $expectedLb.Properties.FrontendIPConfigurations[0].Properties.Subnet.Id
        
        Assert-AreEqual $backendAddressPoolName $expectedLb.Properties.BackendAddressPools[0].Name
        Assert-AreEqual $nic.Properties.IpConfigurations[0].Id $expectedLb.Properties.BackendAddressPools[0].Properties.BackendIpConfigurations.Id
        
        Assert-AreEqual $probeName $expectedLb.Properties.Probes[0].Name
        Assert-AreEqual $probe.RequestPath $expectedLb.Properties.Probes[0].RequestPath
        
        Assert-AreEqual $inboundNatRuleName $expectedLb.Properties.InboundNatRules[0].Name
        Assert-AreEqual $expectedLb.Properties.FrontendIPConfigurations[0].Id $expectedLb.Properties.InboundNatRules[0].Properties.FrontendIPConfigurations[0].Id
        Assert-AreEqual $nic.Properties.IpConfigurations[0].Id $expectedLb.Properties.InboundNatRules[0].Properties.BackendIpConfiguration.Id
        
        Assert-AreEqual $lbruleName $expectedLb.Properties.LoadBalancingRules[0].Name
        Assert-AreEqual $expectedLb.Properties.FrontendIPConfigurations[0].Id $expectedLb.Properties.LoadBalancingRules[0].Properties.FrontendIPConfigurations[0].Id
        Assert-AreEqual $expectedLb.Properties.BackendAddressPools[0].Id $expectedLb.Properties.LoadBalancingRules[0].Properties.BackendAddressPool.Id
        
        # List
        $list = Get-AzureLoadBalancer -ResourceGroupName $rgname
        Assert-AreEqual 1 @($list).Count
        Assert-AreEqual $expectedLb.Etag $list[0].Etag
        Assert-AreEqual $expectedLb.Properties.FrontendIPConfigurations[0].Etag $list[0].Properties.FrontendIPConfigurations[0].Etag
        Assert-AreEqual $expectedLb.Properties.BackendAddressPools[0].Etag $list[0].Properties.BackendAddressPools[0].Etag
        Assert-AreEqual $expectedLb.Properties.InboundNatRules[0].Etag $list[0].Properties.InboundNatRules[0].Etag
        Assert-AreEqual $expectedLb.Properties.BackendAddressPools[0].Etag $list[0].Properties.BackendAddressPools[0].Etag
        
        # Delete
        $deleteLb = Remove-AzureLoadBalancer -Name $lbName -ResourceGroupName $rgname -PassThru -Force
        Assert-AreEqual true $deleteLb
        
        $list = Get-AzureLoadBalancer -ResourceGroupName $rgname
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
    $nicName = Get-ResourceName
    $domainNameLabel = Get-ResourceName
    $lbName = Get-ResourceName
    $frontendName = Get-ResourceName
    $backendAddressPoolName = Get-ResourceName
    $probeName = Get-ResourceName
    $inboundNatRuleName = Get-ResourceName
    $lbruleName = Get-ResourceName
    $rglocation = Get-ProviderLocation ResourceManagement
    $resourceTypeParent = "Microsoft.Network/virtualNetworks"
    $location = Get-ProviderLocation $resourceTypeParent
    
    try 
    {
        # Create the resource group
        $resourceGroup = New-AzureResourceGroup -Name $rgname -Location $rglocation -Tags @{Name = "testtag"; Value = "testval"} 
        
        # Create the Virtual Network
        $subnet = New-AzureVirtualNetworkSubnetConfig -Name $subnetName -AddressPrefix 10.0.1.0/24
        $vnet = New-AzurevirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnet
        
        # Create the publicip
        $publicip = New-AzurePublicIpAddress -ResourceGroupName $rgname -name $publicIpName -location $location -AllocationMethod Dynamic -DomainNameLabel $domainNameLabel

        # Create NetworkInterface
        $nic = New-AzureNetworkInterface -Name $nicName -ResourceGroupName $rgname -Location $location -AllocationMethod dynamic -SubnetId $vnet.Properties.Subnets[0].Id -PublicIpAddressId $publicip.Id

        $frontend = New-AzureLoadBalancerFrontendIpConfig -Name $frontendName -AllocationMethod Dynamic -SubnetId $vnet.Properties.Subnets[0].Id
        $backendAddressPool = New-AzureLoadBalancerBackendAddressPoolConfig -Name $backendAddressPoolName -BackendIpConfigurationId $nic.Properties.IpConfigurations[0].Id
        $probe = New-AzureLoadBalancerProbeConfig -Name $probeName -RequestPath healthcheck.aspx -Protocol http -Port 80 -IntervalInSeconds 15 -ProbeCount 2
        $inboundNatRule = New-AzureLoadBalancerInboundNatRuleConfig -Name $inboundNatRuleName -FrontendIPConfigurationId $frontend.Id -BackendIpConfigurationId $nic.Properties.IpConfigurations[0].Id -Protocol Tcp -FrontendPort 3389 -BackendPort 3389 -IdleTimeoutInSeconds 15 -EnableFloatingIP
        $lbrule = New-AzureLoadBalancerRuleConfig -Name $lbruleName -FrontendIPConfigurationId $frontend.Id -BackendAddressPoolId $backendAddressPool.Id -ProbeId $probe.Id -Protocol Tcp -FrontendPort 80 -BackendPort 80 -IdleTimeoutInSeconds 15 -EnableFloatingIP
        New-AzureLoadBalancer -Name $lbName -ResourceGroupName $rgname -Location $location -FrontendIpConfiguration $frontend -BackendAddressPool $backendAddressPool -Probe $probe -InboundNatRule $inboundNatRule -LoadBalancingRule $lbrule
        
        $lb = Get-AzureLoadBalancer -Name $lbName -ResourceGroupName $rgname
        
        # Test FrontendConfig cmdlets
        $frontendName2 = Get-ResourceName
        $lb | Add-AzureLoadBalancerFrontendIpConfig -Name $frontendName2 -AllocationMethod Dynamic -Subnet $vnet.Properties.Subnets[0]

        Assert-AreEqual 2 @($lb.Properties.FrontendIPConfigurations).Count
        Assert-AreEqual $frontendName2 $lb.Properties.FrontendIPConfigurations[1].Name
        Assert-AreEqual "Dynamic" $lb.Properties.FrontendIPConfigurations[1].Properties.PrivateIPAllocationMethod
        Assert-AreEqual $vnet.Properties.Subnets[0].Id $lb.Properties.FrontendIPConfigurations[1].Properties.Subnet.Id

        $lb | Set-AzureLoadBalancerFrontendIpConfig -Name $frontendName2 -AllocationMethod Static -Subnet $vnet.Properties.Subnets[0]
        Assert-AreEqual 2 @($lb.Properties.FrontendIPConfigurations).Count
        Assert-AreEqual $frontendName2 $lb.Properties.FrontendIPConfigurations[1].Name
        Assert-AreEqual "Static" $lb.Properties.FrontendIPConfigurations[1].Properties.PrivateIPAllocationMethod
        Assert-AreEqual $vnet.Properties.Subnets[0].Id $lb.Properties.FrontendIPConfigurations[1].Properties.Subnet.Id

        $frontendIpconfig = $lb | Get-AzureLoadBalancerFrontendIpConfig -Name $frontendName2
        $frontendIpconfigList = $lb | Get-AzureLoadBalancerFrontendIpConfig
        Assert-AreEqual 2 @($frontendIpconfigList).Count
        Assert-AreEqual $frontendName $frontendIpconfigList[0].Name
        Assert-AreEqual $frontendName2 $frontendIpconfigList[1].Name
        Assert-AreEqual $frontendIpconfig.Name $frontendIpconfigList[1].Name

        $lb | Remove-AzureLoadBalancerFrontendIpConfig -Name $frontendName2
        Assert-AreEqual 1 @($lb.Properties.FrontendIPConfigurations).Count
        Assert-AreEqual $frontendName $lb.Properties.FrontendIPConfigurations[0].Name

        # Test BackendAddressPool cmdlets
        $backendAddressPoolName2 = Get-ResourceName
        $lb | Add-AzureLoadBalancerBackendAddressPoolConfig -Name $backendAddressPoolName2 -BackendIpConfigurationId $nic.Properties.IpConfigurations[0].Id

        Assert-AreEqual 2 @($lb.Properties.BackendAddressPools).Count
        Assert-AreEqual $backendAddressPoolName2 $lb.Properties.BackendAddressPools[1].Name
        Assert-AreEqual $nic.Properties.IpConfigurations[0].Id $lb.Properties.BackendAddressPools[1].Properties.BackendIpConfigurations[0].Id

        $lb | Set-AzureLoadBalancerBackendAddressPoolConfig -Name $backendAddressPoolName2 -BackendIpConfigurationId "newId"
        Assert-AreEqual 2 @($lb.Properties.BackendAddressPools).Count
        Assert-AreEqual $backendAddressPoolName2 $lb.Properties.BackendAddressPools[1].Name
        Assert-AreEqual "newId" $lb.Properties.BackendAddressPools[1].Properties.BackendIpConfigurations[0].Id

        $backendAddressPoolConfig = $lb | Get-AzureLoadBalancerBackendAddressPoolConfig -Name $backendAddressPoolName2
        $backendAddressPoolConfigList = $lb | Get-AzureLoadBalancerBackendAddressPoolConfig
        Assert-AreEqual 2 @($backendAddressPoolconfigList).Count
        Assert-AreEqual $backendAddressPoolName $backendAddressPoolConfigList[0].Name
        Assert-AreEqual $backendAddressPoolName2 $backendAddressPoolConfigList[1].Name
        Assert-AreEqual $backendAddressPoolConfig.Name $backendAddressPoolConfigList[1].Name

        $lb | Remove-AzureLoadBalancerBackendAddressPoolConfig -Name $backendAddressPoolName2
        Assert-AreEqual 1 @($lb.Properties.BackendAddressPools).Count
        Assert-AreEqual $backendAddressPoolName $lb.Properties.BackendAddressPools[0].Name

        # Test Probe cmdlets
        $probeName2 = Get-ResourceName
        $lb | Add-AzureLoadBalancerProbeConfig -Name $probeName2 -RequestPath healthcheck2.aspx -Protocol http -Port 81 -IntervalInSeconds 16 -ProbeCount 3

        Assert-AreEqual 2 @($lb.Properties.Probes).Count
        Assert-AreEqual $probeName2 $lb.Properties.Probes[1].Name
        Assert-AreEqual "healthcheck2.aspx" $lb.Properties.Probes[1].Properties.RequestPath
        Assert-AreEqual 81 $lb.Properties.Probes[1].Properties.Port

        $lb | Set-AzureLoadBalancerProbeConfig -Name $probeName2 -RequestPath healthcheck2.aspx -Protocol http -Port 85 -IntervalInSeconds 16 -ProbeCount 3
        Assert-AreEqual 2 @($lb.Properties.Probes).Count
        Assert-AreEqual $probeName2 $lb.Properties.Probes[1].Name
        Assert-AreEqual "healthcheck2.aspx" $lb.Properties.Probes[1].Properties.RequestPath
        Assert-AreEqual 85 $lb.Properties.Probes[1].Properties.Port

        $probeConfig = $lb | Get-AzureLoadBalancerProbeConfig -Name $probeName2
        $probeConfigList = $lb | Get-AzureLoadBalancerProbeConfig
        Assert-AreEqual 2 @($probeConfigList).Count
        Assert-AreEqual $probeName $probeConfigList[0].Name
        Assert-AreEqual $probeName2 $probeConfigList[1].Name
        Assert-AreEqual $probeConfig.Name $probeConfigList[1].Name

        $lb | Remove-AzureLoadBalancerProbeConfig -Name $probeName2
        Assert-AreEqual 1 @($lb.Properties.Probes).Count
        Assert-AreEqual $probeName $lb.Properties.Probes[0].Name

        # Test InboundNatRule cmdlets
        $inboundNatRuleName2 = Get-ResourceName
        $lb | Add-AzureLoadBalancerInboundNatRuleConfig -Name $inboundNatRuleName2 -FrontendIPConfigurationId $lb.Properties.FrontendIPConfigurations[0].Id -BackendIpConfigurationId $nic.Properties.IpConfigurations[0].Id -Protocol Tcp -FrontendPort 3350 -BackendPort 3350 -IdleTimeoutInSeconds 17 -EnableFloatingIP
        
        Assert-AreEqual 2 @($lb.Properties.InboundNatRules).Count
        Assert-AreEqual $inboundNatRuleName2 $lb.Properties.InboundNatRules[1].Name
        Assert-AreEqual 3350 $lb.Properties.InboundNatRules[1].Properties.FrontendPort
        Assert-AreEqual 3350 $lb.Properties.InboundNatRules[1].Properties.BackendPort
        Assert-AreEqual true $lb.Properties.InboundNatRules[1].Properties.EnableFloatingIP

        $lb | Set-AzureLoadBalancerInboundNatRuleConfig -Name $inboundNatRuleName2 -FrontendIPConfigurationId $lb.Properties.FrontendIPConfigurations[0].Id-BackendIpConfigurationId $nic.Properties.IpConfigurations[0].Id -Protocol Tcp -FrontendPort 3352 -BackendPort 3351 -IdleTimeoutInSeconds 17
        Assert-AreEqual 2 @($lb.Properties.InboundNatRules).Count
        Assert-AreEqual $inboundNatRuleName2 $lb.Properties.InboundNatRules[1].Name
        Assert-AreEqual 3352 $lb.Properties.InboundNatRules[1].Properties.FrontendPort
        Assert-AreEqual 3351 $lb.Properties.InboundNatRules[1].Properties.BackendPort
        Assert-AreEqual false $lb.Properties.InboundNatRules[1].Properties.EnableFloatingIP

        $inboundNatRuleConfig = $lb | Get-AzureLoadBalancerInboundNatRuleConfig -Name $inboundNatRuleName2
        $inboundNatRuleConfigList = $lb | Get-AzureLoadBalancerInboundNatRuleConfig
        Assert-AreEqual 2 @($inboundNatRuleConfigList).Count
        Assert-AreEqual $inboundNatRuleName $inboundNatRuleConfigList[0].Name
        Assert-AreEqual $inboundNatRuleName2 $inboundNatRuleConfigList[1].Name
        Assert-AreEqual $inboundNatRuleConfig.Name $inboundNatRuleConfigList[1].Name

        $lb | Remove-AzureLoadBalancerInboundNatRuleConfig -Name $inboundNatRuleName2
        Assert-AreEqual 1 @($lb.Properties.InboundNatRules).Count
        Assert-AreEqual $inboundNatRuleName $lb.Properties.InboundNatRules[0].Name

        # Test LoadBalancingRule Cmdlets
        $lbruleName2 = Get-ResourceName
        $lb | Add-AzureLoadBalancerRuleConfig -Name $lbruleName2 -FrontendIPConfigurationId $lb.Properties.FrontendIPConfigurations[0].Id -BackendAddressPoolId $lb.Properties.BackendAddressPools[0].Id -ProbeId $lb.Properties.Probes[0].Id -Protocol Tcp -FrontendPort 80 -BackendPort 80 -IdleTimeoutInSeconds 15 -EnableFloatingIP
        
        Assert-AreEqual 2 @($lb.Properties.LoadBalancingRules).Count
        Assert-AreEqual $lbruleName2 $lb.Properties.LoadBalancingRules[1].Name
        Assert-AreEqual 80 $lb.Properties.LoadBalancingRules[1].Properties.FrontendPort
        Assert-AreEqual 80 $lb.Properties.LoadBalancingRules[1].Properties.BackendPort
        Assert-AreEqual true $lb.Properties.LoadBalancingRules[1].Properties.EnableFloatingIP

        $lb | Set-AzureLoadBalancerRuleConfig -Name $lbruleName2 -FrontendIPConfigurationId $lb.Properties.FrontendIPConfigurations[0].Id -BackendAddressPoolId $lb.Properties.BackendAddressPools[0].Id -ProbeId $lb.Properties.Probes[0].Id -Protocol Tcp -FrontendPort 82 -BackendPort 81 -IdleTimeoutInSeconds 17
        Assert-AreEqual 2 @($lb.Properties.LoadBalancingRules).Count
        Assert-AreEqual $lbruleName2 $lb.Properties.LoadBalancingRules[1].Name
        Assert-AreEqual 82 $lb.Properties.LoadBalancingRules[1].Properties.FrontendPort
        Assert-AreEqual 81 $lb.Properties.LoadBalancingRules[1].Properties.BackendPort
        Assert-AreEqual false $lb.Properties.LoadBalancingRules[1].Properties.EnableFloatingIP

        $lbruleConfig = $lb | Get-AzureLoadBalancerRuleConfig -Name $lbruleName2
        $lbruleConfigList = $lb | Get-AzureLoadBalancerRuleConfig
        Assert-AreEqual 2 @($inboundNatRuleConfigList).Count
        Assert-AreEqual $lbruleName $lbruleConfigList[0].Name
        Assert-AreEqual $lbruleName2 $lbruleConfigList[1].Name
        Assert-AreEqual $lbruleConfig.Name $lbruleConfigList[1].Name

        $lb | Remove-AzureLoadBalancerRuleConfig -Name $lbruleName2
        Assert-AreEqual 1 @($lb.Properties.LoadBalancingRules).Count
        Assert-AreEqual $lbruleName $lb.Properties.LoadBalancingRules[0].Name
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Tests creating ad editing a simple Load balancer 
#>
function Test-LoadBalancerSet
{
    # Setup
    $rgname = Get-ResourceGroupName
    $vnetName = Get-ResourceName
    $subnetName = Get-ResourceName
    $publicIpName = Get-ResourceName
    $nicName = Get-ResourceName
    $domainNameLabel = Get-ResourceName
    $lbName = Get-ResourceName
    $frontendName = Get-ResourceName
    $backendAddressPoolName = Get-ResourceName
    $probeName = Get-ResourceName
    $inboundNatRuleName = Get-ResourceName
    $lbruleName = Get-ResourceName
    $rglocation = Get-ProviderLocation ResourceManagement
    $resourceTypeParent = "Microsoft.Network/virtualNetworks"
    $location = Get-ProviderLocation $resourceTypeParent
    
    try 
    {
        # Create the resource group
        $resourceGroup = New-AzureResourceGroup -Name $rgname -Location $rglocation -Tags @{Name = "testtag"; Value = "testval"} 
        
        # Create the Virtual Network
        $subnet = New-AzureVirtualNetworkSubnetConfig -Name $subnetName -AddressPrefix 10.0.1.0/24
        $vnet = New-AzurevirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnet
        
        # Create the publicip
        $publicip = New-AzurePublicIpAddress -ResourceGroupName $rgname -name $publicIpName -location $location -AllocationMethod Dynamic -DomainNameLabel $domainNameLabel

        # Create NetworkInterface
        $nic = New-AzureNetworkInterface -Name $nicName -ResourceGroupName $rgname -Location $location -AllocationMethod dynamic -SubnetId $vnet.Properties.Subnets[0].Id -PublicIpAddressId $publicip.Id

        $frontend = New-AzureLoadBalancerFrontendIpConfig -Name $frontendName -AllocationMethod Dynamic -SubnetId $vnet.Properties.Subnets[0].Id
        $backendAddressPool = New-AzureLoadBalancerBackendAddressPoolConfig -Name $backendAddressPoolName -BackendIpConfigurationId $nic.Properties.IpConfigurations[0].Id
        $probe = New-AzureLoadBalancerProbeConfig -Name $probeName -RequestPath healthcheck.aspx -Protocol http -Port 80 -IntervalInSeconds 15 -ProbeCount 2
        $inboundNatRule = New-AzureLoadBalancerInboundNatRuleConfig -Name $inboundNatRuleName -FrontendIPConfigurationId $frontend.Id -BackendIpConfigurationId $nic.Properties.IpConfigurations[0].Id -Protocol Tcp -FrontendPort 3389 -BackendPort 3389 -IdleTimeoutInSeconds 15 -EnableFloatingIP
        $lbrule = New-AzureLoadBalancerRuleConfig -Name $lbruleName -FrontendIPConfigurationId $frontend.Id -BackendAddressPoolId $backendAddressPool.Id -ProbeId $probe.Id -Protocol Tcp -FrontendPort 80 -BackendPort 80 -IdleTimeoutInSeconds 15 -EnableFloatingIP
        New-AzureLoadBalancer -Name $lbName -ResourceGroupName $rgname -Location $location -FrontendIpConfiguration $frontend -BackendAddressPool $backendAddressPool -Probe $probe -InboundNatRule $inboundNatRule -LoadBalancingRule $lbrule
        
        $lb = Get-AzureLoadBalancer -Name $lbName -ResourceGroupName $rgname
    
        # Test Probe cmdlets
        $probeName2 = Get-ResourceName
        $lb | Add-AzureLoadBalancerProbeConfig -Name $probeName2 -RequestPath healthcheck2.aspx -Protocol http -Port 81 -IntervalInSeconds 16 -ProbeCount 3

        Assert-AreEqual 2 @($lb.Properties.Probes).Count
        Assert-AreEqual $probeName2 $lb.Properties.Probes[1].Name
        Assert-AreEqual "healthcheck2.aspx" $lb.Properties.Probes[1].Properties.RequestPath
        Assert-AreEqual 81 $lb.Properties.Probes[1].Properties.Port

        $lb = $lb | Set-AzureLoadBalancer
        Assert-AreEqual 2 @($lb.Properties.Probes).Count
        Assert-AreEqual $probeName2 $lb.Properties.Probes[1].Name
        Assert-AreEqual "healthcheck2.aspx" $lb.Properties.Probes[1].Properties.RequestPath
        Assert-AreEqual 81 $lb.Properties.Probes[1].Properties.Port    
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

