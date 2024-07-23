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
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval"} 

        # Create the Virtual Network
        $subnet = New-AzVirtualNetworkSubnetConfig -Name $subnetName -AddressPrefix 10.0.1.0/24
        $vnet = New-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnet

        # Create the publicip
        $publicip = New-AzPublicIpAddress -ResourceGroupName $rgname -name $publicIpName -location $location -AllocationMethod Dynamic -DomainNameLabel $domainNameLabel

        # Create LoadBalancer
        $frontend = New-AzLoadBalancerFrontendIpConfig -Name $frontendName -PublicIpAddress $publicip
        $backendAddressPool = New-AzLoadBalancerBackendAddressPoolConfig -Name $backendAddressPoolName
        $probe = New-AzLoadBalancerProbeConfig -Name $probeName -RequestPath healthcheck.aspx -Protocol http -Port 80 -IntervalInSeconds 15 -ProbeCount 2 -ProbeThreshold 2
        $inboundNatRule = New-AzLoadBalancerInboundNatRuleConfig -Name $inboundNatRuleName -FrontendIPConfiguration $frontend -Protocol Tcp -FrontendPort 3389 -BackendPort 3389 -IdleTimeoutInMinutes 15 -EnableFloatingIP
        $lbrule = New-AzLoadBalancerRuleConfig -Name $lbruleName -FrontendIPConfiguration $frontend -BackendAddressPool $backendAddressPool -Probe $probe -Protocol Tcp -FrontendPort 80 -BackendPort 80 -IdleTimeoutInMinutes 15 -EnableFloatingIP -LoadDistribution SourceIP
        $job = New-AzLoadBalancer -Name $lbName -ResourceGroupName $rgname -Location $location -FrontendIpConfiguration $frontend -BackendAddressPool $backendAddressPool -Probe $probe -InboundNatRule $inboundNatRule -LoadBalancingRule $lbrule -AsJob
        $job | Wait-Job
		$actualLb = $job | Receive-Job

        $expectedLb = Get-AzLoadBalancer -Name $lbName -ResourceGroupName $rgname

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
        Assert-AreEqual $probe.ProbeCount $expectedLb.Probes[0].ProbeCount
        Assert-AreEqual $probe.ProbeThreshold $expectedLb.Probes[0].ProbeThreshold

        Assert-AreEqual $inboundNatRuleName $expectedLb.InboundNatRules[0].Name
        Assert-AreEqual $expectedLb.FrontendIPConfigurations[0].Id $expectedLb.InboundNatRules[0].FrontendIPConfiguration.Id

        Assert-AreEqual $lbruleName $expectedLb.LoadBalancingRules[0].Name
        Assert-AreEqual $expectedLb.FrontendIPConfigurations[0].Id $expectedLb.LoadBalancingRules[0].FrontendIPConfiguration.Id
        Assert-AreEqual $expectedLb.BackendAddressPools[0].Id $expectedLb.LoadBalancingRules[0].BackendAddressPool.Id

        # List
        $list = Get-AzLoadBalancer -ResourceGroupName $rgname
        Assert-AreEqual 1 @($list).Count
        Assert-AreEqual $expectedLb.Etag $list[0].Etag
        Assert-AreEqual $expectedLb.FrontendIPConfigurations[0].Etag $list[0].FrontendIPConfigurations[0].Etag
        Assert-AreEqual $expectedLb.BackendAddressPools[0].Etag $list[0].BackendAddressPools[0].Etag
        Assert-AreEqual $expectedLb.InboundNatRules[0].Etag $list[0].InboundNatRules[0].Etag
        Assert-AreEqual $expectedLb.Probes[0].Etag $list[0].Probes[0].Etag
        Assert-AreEqual $expectedLb.LoadBalancingRules[0].Etag $list[0].LoadBalancingRules[0].Etag

        $list = Get-AzLoadBalancer -ResourceGroupName "*"
        Assert-True { @($list).Count -ge 0 }

        $list = Get-AzLoadBalancer -Name "*"
        Assert-True { @($list).Count -ge 0 }

        $list = Get-AzLoadBalancer -ResourceGroupName "*" -Name "*"
        Assert-True { @($list).Count -ge 0 }

        # Delete
        $job = Remove-AzLoadBalancer -Name $lbName -ResourceGroupName $rgname -PassThru -Force -AsJob
		$job | Wait-Job
		$deleteLb = $job | Receive-Job
        Assert-AreEqual true $deleteLb

        $list = Get-AzLoadBalancer -ResourceGroupName $rgname
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
Tests creating a public Load balancer with EnableTcpReset for inbound nat rule and lb rule.
#>
function Test-LoadBalancerCRUD-PublicTcpReset
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
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval"} 

        # Create the Virtual Network
        $subnet = New-AzVirtualNetworkSubnetConfig -Name $subnetName -AddressPrefix 10.0.1.0/24
        $vnet = New-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnet

        # Create the publicip
        $publicip = New-AzPublicIpAddress -ResourceGroupName $rgname -name $publicIpName -location $location -AllocationMethod Static -DomainNameLabel $domainNameLabel -Sku Standard

        # Create LoadBalancer
        $frontend = New-AzLoadBalancerFrontendIpConfig -Name $frontendName -PublicIpAddress $publicip
        $backendAddressPool = New-AzLoadBalancerBackendAddressPoolConfig -Name $backendAddressPoolName
        $probe = New-AzLoadBalancerProbeConfig -Name $probeName -RequestPath healthcheck.aspx -Protocol https -Port 80 -IntervalInSeconds 15 -ProbeCount 2 -ProbeThreshold 2
        $inboundNatRule = New-AzLoadBalancerInboundNatRuleConfig -Name $inboundNatRuleName -FrontendIPConfiguration $frontend -Protocol Tcp -FrontendPort 3389 -BackendPort 3389 -IdleTimeoutInMinutes 15 -EnableFloatingIP -EnableTcpReset
        $lbrule = New-AzLoadBalancerRuleConfig -Name $lbruleName -FrontendIPConfiguration $frontend -BackendAddressPool $backendAddressPool -Probe $probe -Protocol Tcp -FrontendPort 80 -BackendPort 80 -IdleTimeoutInMinutes 15 -EnableFloatingIP -EnableTcpReset -LoadDistribution SourceIP -DisableOutboundSNAT
        $actualLb = New-AzLoadBalancer -Name $lbName -ResourceGroupName $rgname -Location $location -FrontendIpConfiguration $frontend -BackendAddressPool $backendAddressPool -Probe $probe -InboundNatRule $inboundNatRule -LoadBalancingRule $lbrule -Sku Standard

        $expectedLb = Get-AzLoadBalancer -Name $lbName -ResourceGroupName $rgname

        # Verification
        Assert-AreEqual $expectedLb.ResourceGroupName $actualLb.ResourceGroupName
        Assert-AreEqual $expectedLb.Name $actualLb.Name
        Assert-AreEqual $expectedLb.Location $actualLb.Location
        Assert-AreEqualObjectProperties $expectedLb.Sku $actualLb.Sku
        Assert-AreEqual "Succeeded" $expectedLb.ProvisioningState
        Assert-NotNull $expectedLb.ResourceGuid
        Assert-AreEqual 1 @($expectedLb.FrontendIPConfigurations).Count

        Assert-AreEqual $frontendName $expectedLb.FrontendIPConfigurations[0].Name
        Assert-AreEqual $publicip.Id $expectedLb.FrontendIPConfigurations[0].PublicIpAddress.Id
        Assert-Null $expectedLb.FrontendIPConfigurations[0].PrivateIpAddress

        Assert-AreEqual $backendAddressPoolName $expectedLb.BackendAddressPools[0].Name

        Assert-AreEqual $probeName $expectedLb.Probes[0].Name
        Assert-AreEqual $probe.RequestPath $expectedLb.Probes[0].RequestPath
        Assert-AreEqual "https" $expectedLb.Probes[0].Protocol
        Assert-AreEqual $probe.ProbeThreshold $expectedLb.Probes[0].ProbeThreshold

        Assert-AreEqual $inboundNatRuleName $expectedLb.InboundNatRules[0].Name
        Assert-AreEqual true $expectedLb.InboundNatRules[0].EnableTcpReset
        Assert-AreEqual $expectedLb.FrontendIPConfigurations[0].Id $expectedLb.InboundNatRules[0].FrontendIPConfiguration.Id

        Assert-AreEqual $lbruleName $expectedLb.LoadBalancingRules[0].Name
        Assert-AreEqual $expectedLb.FrontendIPConfigurations[0].Id $expectedLb.LoadBalancingRules[0].FrontendIPConfiguration.Id
        Assert-AreEqual $expectedLb.BackendAddressPools[0].Id $expectedLb.LoadBalancingRules[0].BackendAddressPool.Id
        Assert-AreEqual true $expectedLb.LoadBalancingRules[0].EnableTcpReset

        # List
        $list = Get-AzLoadBalancer -ResourceGroupName $rgname
        Assert-AreEqual 1 @($list).Count
        Assert-AreEqual $expectedLb.Etag $list[0].Etag
        Assert-AreEqualObjectProperties $expectedLb.Sku $list[0].Sku
        Assert-AreEqual $expectedLb.FrontendIPConfigurations[0].Etag $list[0].FrontendIPConfigurations[0].Etag
        Assert-AreEqual $expectedLb.BackendAddressPools[0].Etag $list[0].BackendAddressPools[0].Etag
        Assert-AreEqual $expectedLb.InboundNatRules[0].Etag $list[0].InboundNatRules[0].Etag
        Assert-AreEqual $expectedLb.Probes[0].Etag $list[0].Probes[0].Etag
        Assert-AreEqual $expectedLb.LoadBalancingRules[0].Etag $list[0].LoadBalancingRules[0].Etag

        # Delete
        $deleteLb = Remove-AzLoadBalancer -Name $lbName -ResourceGroupName $rgname -PassThru -Force
        Assert-AreEqual true $deleteLb

        $list = Get-AzLoadBalancer -ResourceGroupName $rgname
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
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval"} 
        
        # Create the Virtual Network
        $subnet = New-AzVirtualNetworkSubnetConfig -Name $subnetName -AddressPrefix 10.0.1.0/24
        $vnet = New-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnet
        
        # Create the publicip
        $publicip = New-AzPublicIpAddress -ResourceGroupName $rgname -name $publicIpName -location $location -AllocationMethod Dynamic -DomainNameLabel $domainNameLabel

        # Create LoadBalancer
        $frontend = New-AzLoadBalancerFrontendIpConfig -Name $frontendName -Subnet $vnet.Subnets[0]
        $backendAddressPool = New-AzLoadBalancerBackendAddressPoolConfig -Name $backendAddressPoolName
        $probe = New-AzLoadBalancerProbeConfig -Name $probeName -RequestPath healthcheck.aspx -Protocol http -Port 80 -IntervalInSeconds 15 -ProbeCount 2 
        $inboundNatRule = New-AzLoadBalancerInboundNatRuleConfig -Name $inboundNatRuleName -FrontendIPConfiguration $frontend -Protocol Tcp -FrontendPort 3389 -BackendPort 3389 -IdleTimeoutInMinutes 15 -EnableFloatingIP
        $lbrule = New-AzLoadBalancerRuleConfig -Name $lbruleName -FrontendIPConfiguration $frontend -BackendAddressPool $backendAddressPool -Probe $probe -Protocol Tcp -FrontendPort 80 -BackendPort 80 -IdleTimeoutInMinutes 15 -EnableFloatingIP -LoadDistribution SourceIP
        $actualLb = New-AzLoadBalancer -Name $lbName -ResourceGroupName $rgname -Location $location -FrontendIpConfiguration $frontend -BackendAddressPool $backendAddressPool -Probe $probe -InboundNatRule $inboundNatRule -LoadBalancingRule $lbrule
        
        $expectedLb = Get-AzLoadBalancer -Name $lbName -ResourceGroupName $rgname

        # Verification
        Assert-AreEqual $expectedLb.ResourceGroupName $actualLb.ResourceGroupName
        Assert-AreEqual $expectedLb.Name $actualLb.Name
        Assert-AreEqual $expectedLb.Location $actualLb.Location
        Assert-AreEqual "Succeeded" $expectedLb.ProvisioningState
        Assert-AreEqual 1 @($expectedLb.FrontendIPConfigurations).Count
        
        Assert-AreEqual $frontendName $expectedLb.FrontendIPConfigurations[0].Name
        Assert-AreEqual $vnet.Subnets[0].Id $expectedLb.FrontendIPConfigurations[0].Subnet.Id
        Assert-NotNull $expectedLb.FrontendIPConfigurations[0].PrivateIpAddress
        Assert-AreEqual "IPv4" $expectedLb.FrontendIPConfigurations[0].PrivateIpAddressVersion

        Assert-AreEqual $backendAddressPoolName $expectedLb.BackendAddressPools[0].Name

        Assert-AreEqual $probeName $expectedLb.Probes[0].Name
        Assert-AreEqual $probe.RequestPath $expectedLb.Probes[0].RequestPath

        Assert-AreEqual $inboundNatRuleName $expectedLb.InboundNatRules[0].Name
        Assert-AreEqual $expectedLb.FrontendIPConfigurations[0].Id $expectedLb.InboundNatRules[0].FrontendIPConfiguration.Id

        Assert-AreEqual $lbruleName $expectedLb.LoadBalancingRules[0].Name
        Assert-AreEqual $expectedLb.FrontendIPConfigurations[0].Id $expectedLb.LoadBalancingRules[0].FrontendIPConfiguration.Id
        Assert-AreEqual $expectedLb.BackendAddressPools[0].Id $expectedLb.LoadBalancingRules[0].BackendAddressPool.Id

        # List
        $list = Get-AzLoadBalancer -ResourceGroupName $rgname
        Assert-AreEqual 1 @($list).Count
        Assert-AreEqual $expectedLb.Etag $list[0].Etag
        Assert-AreEqual $expectedLb.FrontendIPConfigurations[0].Etag $list[0].FrontendIPConfigurations[0].Etag
        Assert-AreEqual $expectedLb.BackendAddressPools[0].Etag $list[0].BackendAddressPools[0].Etag
        Assert-AreEqual $expectedLb.InboundNatRules[0].Etag $list[0].InboundNatRules[0].Etag
        Assert-AreEqual $expectedLb.Probes[0].Etag $list[0].Probes[0].Etag
        Assert-AreEqual $expectedLb.LoadBalancingRules[0].Etag $list[0].LoadBalancingRules[0].Etag

        # Delete
        $deleteLb = Remove-AzLoadBalancer -Name $lbName -ResourceGroupName $rgname -PassThru -Force
        Assert-AreEqual true $deleteLb
        
        $list = Get-AzLoadBalancer -ResourceGroupName $rgname
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
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval"} 
        
        # Create the Virtual Network
        $subnet = New-AzVirtualNetworkSubnetConfig -Name $subnetName -AddressPrefix 10.0.1.0/24
        $vnet = New-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnet
        
        # Create the publicip
        $publicip = New-AzPublicIpAddress -ResourceGroupName $rgname -name $publicIpName -location $location -AllocationMethod Dynamic -DomainNameLabel $domainNameLabel

        # Create LoadBalancer
        $frontend = New-AzLoadBalancerFrontendIpConfig -Name $frontendName -Subnet $vnet.Subnets[0] -PrivateIpAddress "10.0.1.5" -PrivateIpAddressVersion "IPv4"
        $backendAddressPool = New-AzLoadBalancerBackendAddressPoolConfig -Name $backendAddressPoolName
        $probe = New-AzLoadBalancerProbeConfig -Name $probeName -RequestPath healthcheck.aspx -Protocol http -Port 80 -IntervalInSeconds 15 -ProbeCount 2
        $inboundNatRule = New-AzLoadBalancerInboundNatRuleConfig -Name $inboundNatRuleName -FrontendIPConfiguration $frontend -Protocol Tcp -FrontendPort 3389 -BackendPort 3389 -IdleTimeoutInMinutes 15 -EnableFloatingIP
        $lbrule = New-AzLoadBalancerRuleConfig -Name $lbruleName -FrontendIPConfiguration $frontend -BackendAddressPool $backendAddressPool -Probe $probe -Protocol Tcp -FrontendPort 80 -BackendPort 80 -IdleTimeoutInMinutes 15 -EnableFloatingIP -LoadDistribution SourceIP
        $actualLb = New-AzLoadBalancer -Name $lbName -ResourceGroupName $rgname -Location $location -FrontendIpConfiguration $frontend -BackendAddressPool $backendAddressPool -Probe $probe -InboundNatRule $inboundNatRule -LoadBalancingRule $lbrule
        
        $expectedLb = Get-AzLoadBalancer -Name $lbName -ResourceGroupName $rgname

        # Verification
        Assert-AreEqual $expectedLb.ResourceGroupName $actualLb.ResourceGroupName
        Assert-AreEqual $expectedLb.Name $actualLb.Name
        Assert-AreEqual $expectedLb.Location $actualLb.Location
        Assert-AreEqual "Succeeded" $expectedLb.ProvisioningState
        Assert-AreEqual 1 @($expectedLb.FrontendIPConfigurations).Count
        
        Assert-AreEqual $frontendName $expectedLb.FrontendIPConfigurations[0].Name
        Assert-AreEqual $vnet.Subnets[0].Id $expectedLb.FrontendIPConfigurations[0].Subnet.Id
        Assert-AreEqual "10.0.1.5" $expectedLb.FrontendIPConfigurations[0].PrivateIpAddress
        Assert-AreEqual "IPv4" $expectedLb.FrontendIPConfigurations[0].PrivateIpAddressVersion

        Assert-AreEqual $backendAddressPoolName $expectedLb.BackendAddressPools[0].Name

        Assert-AreEqual $probeName $expectedLb.Probes[0].Name
        Assert-AreEqual $probe.RequestPath $expectedLb.Probes[0].RequestPath

        Assert-AreEqual $inboundNatRuleName $expectedLb.InboundNatRules[0].Name
        Assert-AreEqual $expectedLb.FrontendIPConfigurations[0].Id $expectedLb.InboundNatRules[0].FrontendIPConfiguration.Id

        Assert-AreEqual $lbruleName $expectedLb.LoadBalancingRules[0].Name
        Assert-AreEqual $expectedLb.FrontendIPConfigurations[0].Id $expectedLb.LoadBalancingRules[0].FrontendIPConfiguration.Id
        Assert-AreEqual $expectedLb.BackendAddressPools[0].Id $expectedLb.LoadBalancingRules[0].BackendAddressPool.Id

        # List
        $list = Get-AzLoadBalancer -ResourceGroupName $rgname
        Assert-AreEqual 1 @($list).Count
        Assert-AreEqual $expectedLb.Etag $list[0].Etag
        Assert-AreEqual $expectedLb.FrontendIPConfigurations[0].Etag $list[0].FrontendIPConfigurations[0].Etag
        Assert-AreEqual $expectedLb.BackendAddressPools[0].Etag $list[0].BackendAddressPools[0].Etag
        Assert-AreEqual $expectedLb.InboundNatRules[0].Etag $list[0].InboundNatRules[0].Etag
        Assert-AreEqual $expectedLb.Probes[0].Etag $list[0].Probes[0].Etag
        Assert-AreEqual $expectedLb.LoadBalancingRules[0].Etag $list[0].LoadBalancingRules[0].Etag

        # Delete
        $deleteLb = Remove-AzLoadBalancer -Name $lbName -ResourceGroupName $rgname -PassThru -Force
        Assert-AreEqual true $deleteLb
        
        $list = Get-AzLoadBalancer -ResourceGroupName $rgname
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
Test creating a higly available internal Load balancer with basic sku.
#>
function Test-LoadBalancerCRUD-InternalHighlyAvailableBasicSku
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
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval"} 
        
        # Create the Virtual Network
        $subnet = New-AzVirtualNetworkSubnetConfig -Name $subnetName -AddressPrefix 10.0.1.0/24
        $vnet = New-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnet
        
        # Create the publicip
        $publicip = New-AzPublicIpAddress -ResourceGroupName $rgname -name $publicIpName -location $location -AllocationMethod Dynamic -DomainNameLabel $domainNameLabel

        # Create LoadBalancer
        $frontend = New-AzLoadBalancerFrontendIpConfig -Name $frontendName -Subnet $vnet.Subnets[0]
        $backendAddressPool = New-AzLoadBalancerBackendAddressPoolConfig -Name $backendAddressPoolName
        $probe = New-AzLoadBalancerProbeConfig -Name $probeName -RequestPath healthcheck.aspx -Protocol http -Port 80 -IntervalInSeconds 15 -ProbeCount 2
        $lbrule = New-AzLoadBalancerRuleConfig -Name $lbruleName -FrontendIPConfiguration $frontend -BackendAddressPool $backendAddressPool -Probe $probe -Protocol All -FrontendPort 0 -BackendPort 0 -IdleTimeoutInMinutes 15 -EnableFloatingIP -LoadDistribution SourceIP
        $actualLb = New-AzLoadBalancer -Name $lbName -ResourceGroupName $rgname -Location $location -FrontendIpConfiguration $frontend -BackendAddressPool $backendAddressPool -Probe $probe -LoadBalancingRule $lbrule -Sku Basic
        
        $expectedLb = Get-AzLoadBalancer -Name $lbName -ResourceGroupName $rgname

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

        Assert-AreEqual $lbruleName $expectedLb.LoadBalancingRules[0].Name
        Assert-AreEqual $expectedLb.FrontendIPConfigurations[0].Id $expectedLb.LoadBalancingRules[0].FrontendIPConfiguration.Id
        Assert-AreEqual $expectedLb.BackendAddressPools[0].Id $expectedLb.LoadBalancingRules[0].BackendAddressPool.Id
		Assert-AreEqual 0 $expectedLb.LoadBalancingRules[0].FrontendPort
		Assert-AreEqual 0 $expectedLb.LoadBalancingRules[0].BackendPort
		Assert-AreEqual All $expectedLb.LoadBalancingRules[0].Protocol

        # Delete
        $deleteLb = Remove-AzLoadBalancer -Name $lbName -ResourceGroupName $rgname -PassThru -Force
        Assert-AreEqual true $deleteLb
        
        $list = Get-AzLoadBalancer -ResourceGroupName $rgname
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
Tests creating a higly available internal Load balancer with standard sku.
#>
function Test-LoadBalancerCRUD-InternalHighlyAvailableStandardSku
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
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval"} 
        
        # Create the Virtual Network
        $subnet = New-AzVirtualNetworkSubnetConfig -Name $subnetName -AddressPrefix 10.0.1.0/24
        $vnet = New-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnet
        
        # Create the publicip
        $publicip = New-AzPublicIpAddress -ResourceGroupName $rgname -name $publicIpName -location $location -AllocationMethod Dynamic -DomainNameLabel $domainNameLabel

        # Create LoadBalancer
        $frontend = New-AzLoadBalancerFrontendIpConfig -Name $frontendName -Subnet $vnet.Subnets[0]
        $backendAddressPool = New-AzLoadBalancerBackendAddressPoolConfig -Name $backendAddressPoolName
        $probe = New-AzLoadBalancerProbeConfig -Name $probeName -RequestPath healthcheck.aspx -Protocol http -Port 80 -IntervalInSeconds 15 -ProbeCount 2 
        $lbrule = New-AzLoadBalancerRuleConfig -Name $lbruleName -FrontendIPConfiguration $frontend -BackendAddressPool $backendAddressPool -Probe $probe -Protocol All -FrontendPort 0 -BackendPort 0 -IdleTimeoutInMinutes 15 -EnableFloatingIP -LoadDistribution SourceIP
        $actualLb = New-AzLoadBalancer -Name $lbName -ResourceGroupName $rgname -Location $location -FrontendIpConfiguration $frontend -BackendAddressPool $backendAddressPool -Probe $probe -LoadBalancingRule $lbrule -Sku Standard
        
        $expectedLb = Get-AzLoadBalancer -Name $lbName -ResourceGroupName $rgname

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

        Assert-AreEqual $lbruleName $expectedLb.LoadBalancingRules[0].Name
        Assert-AreEqual $expectedLb.FrontendIPConfigurations[0].Id $expectedLb.LoadBalancingRules[0].FrontendIPConfiguration.Id
        Assert-AreEqual $expectedLb.BackendAddressPools[0].Id $expectedLb.LoadBalancingRules[0].BackendAddressPool.Id
		Assert-AreEqual 0 $expectedLb.LoadBalancingRules[0].FrontendPort
		Assert-AreEqual 0 $expectedLb.LoadBalancingRules[0].BackendPort
		Assert-AreEqual All $expectedLb.LoadBalancingRules[0].Protocol

        # Delete
        $deleteLb = Remove-AzLoadBalancer -Name $lbName -ResourceGroupName $rgname -PassThru -Force
        Assert-AreEqual true $deleteLb
        
        $list = Get-AzLoadBalancer -ResourceGroupName $rgname
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
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval"} 
        
        # Create the Virtual Network
        $subnet = New-AzVirtualNetworkSubnetConfig -Name $subnetName -AddressPrefix 10.0.1.0/24
        $vnet = New-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnet
        
        # Create the publicip
        $publicip = New-AzPublicIpAddress -ResourceGroupName $rgname -name $publicIpName -location $location -AllocationMethod Dynamic -DomainNameLabel $domainNameLabel

        # Create LoadBalancer
        $frontend = New-AzLoadBalancerFrontendIpConfig -Name $frontendName -PublicIpAddress $publicip
        $backendAddressPool = New-AzLoadBalancerBackendAddressPoolConfig -Name $backendAddressPoolName
        $probe = New-AzLoadBalancerProbeConfig -Name $probeName -RequestPath healthcheck.aspx -Protocol http -Port 80 -IntervalInSeconds 15 -ProbeCount 2
        $lbrule = New-AzLoadBalancerRuleConfig -Name $lbruleName -FrontendIPConfiguration $frontend -BackendAddressPool $backendAddressPool -Probe $probe -Protocol Tcp -FrontendPort 80 -BackendPort 80 -IdleTimeoutInMinutes 15 -EnableFloatingIP -LoadDistribution SourceIP
        $actualLb = New-AzLoadBalancer -Name $lbName -ResourceGroupName $rgname -Location $location -FrontendIpConfiguration $frontend -BackendAddressPool $backendAddressPool -Probe $probe -LoadBalancingRule $lbrule
        
        $expectedLb = Get-AzLoadBalancer -Name $lbName -ResourceGroupName $rgname

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
        $list = Get-AzLoadBalancer -ResourceGroupName $rgname
        Assert-AreEqual 1 @($list).Count
        Assert-AreEqual $expectedLb.Etag $list[0].Etag
        Assert-AreEqual $expectedLb.FrontendIPConfigurations[0].Etag $list[0].FrontendIPConfigurations[0].Etag
        Assert-AreEqual $expectedLb.BackendAddressPools[0].Etag $list[0].BackendAddressPools[0].Etag
        Assert-AreEqual $expectedLb.Probes[0].Etag $list[0].Probes[0].Etag
        Assert-AreEqual $expectedLb.LoadBalancingRules[0].Etag $list[0].LoadBalancingRules[0].Etag

        # Delete
        $deleteLb = Remove-AzLoadBalancer -Name $lbName -ResourceGroupName $rgname -PassThru -Force
        Assert-AreEqual true $deleteLb
        
        $list = Get-AzLoadBalancer -ResourceGroupName $rgname
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
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval"} 
        
        # Create the Virtual Network
        $subnet = New-AzVirtualNetworkSubnetConfig -Name $subnetName -AddressPrefix 10.0.1.0/24
        $vnet = New-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnet
        
        # Create the publicip
        $publicip = New-AzPublicIpAddress -ResourceGroupName $rgname -name $publicIpName -location $location -AllocationMethod Dynamic -DomainNameLabel $domainNameLabel

        $frontend = New-AzLoadBalancerFrontendIpConfig -Name $frontendName -SubnetId $vnet.Subnets[0].Id
        $backendAddressPool = New-AzLoadBalancerBackendAddressPoolConfig -Name $backendAddressPoolName
        $probe = New-AzLoadBalancerProbeConfig -Name $probeName -RequestPath healthcheck.aspx -Protocol http -Port 80 -IntervalInSeconds 15 -ProbeCount 2
        $inboundNatRule = New-AzLoadBalancerInboundNatRuleConfig -Name $inboundNatRuleName -FrontendIPConfigurationId $frontend.Id -Protocol Tcp -FrontendPort 3389 -BackendPort 3389 -IdleTimeoutInMinutes 15 -EnableFloatingIP
        $lbrule = New-AzLoadBalancerRuleConfig -Name $lbruleName -FrontendIPConfigurationId $frontend.Id -BackendAddressPoolId $backendAddressPool.Id -ProbeId $probe.Id -Protocol Tcp -FrontendPort 80 -BackendPort 80 -IdleTimeoutInMinutes 15 -EnableFloatingIP
        $actualLb = New-AzLoadBalancer -Name $lbName -ResourceGroupName $rgname -Location $location -FrontendIpConfiguration $frontend -BackendAddressPool $backendAddressPool -Probe $probe -InboundNatRule $inboundNatRule -LoadBalancingRule $lbrule
        
        $expectedLb = Get-AzLoadBalancer -Name $lbName -ResourceGroupName $rgname
        
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
        $list = Get-AzLoadBalancer -ResourceGroupName $rgname
        Assert-AreEqual 1 @($list).Count
        Assert-AreEqual $expectedLb.Etag $list[0].Etag
        Assert-AreEqual $expectedLb.FrontendIPConfigurations[0].Etag $list[0].FrontendIPConfigurations[0].Etag
        Assert-AreEqual $expectedLb.BackendAddressPools[0].Etag $list[0].BackendAddressPools[0].Etag
        Assert-AreEqual $expectedLb.InboundNatRules[0].Etag $list[0].InboundNatRules[0].Etag
        Assert-AreEqual $expectedLb.Probes[0].Etag $list[0].Probes[0].Etag
        Assert-AreEqual $expectedLb.LoadBalancingRules[0].Etag $list[0].LoadBalancingRules[0].Etag
        
        # Delete
        $deleteLb = Remove-AzLoadBalancer -Name $lbName -ResourceGroupName $rgname -PassThru -Force
        Assert-AreEqual true $deleteLb
        
        $list = Get-AzLoadBalancer -ResourceGroupName $rgname
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
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval"} 
        
        # Create the Virtual Network
        $subnet = New-AzVirtualNetworkSubnetConfig -Name $subnetName -AddressPrefix 10.0.1.0/24
        $vnet = New-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnet
        
        # Create the publicip
        $publicip = New-AzPublicIpAddress -ResourceGroupName $rgname -name $publicIpName -location $location -AllocationMethod Dynamic -DomainNameLabel $domainNameLabel

        $frontend = New-AzLoadBalancerFrontendIpConfig -Name $frontendName -PublicIpAddressId $publicip.Id
        $backendAddressPool = New-AzLoadBalancerBackendAddressPoolConfig -Name $backendAddressPoolName
        $probe = New-AzLoadBalancerProbeConfig -Name $probeName -RequestPath healthcheck.aspx -Protocol http -Port 80 -IntervalInSeconds 15 -ProbeCount 2
        $inboundNatRule = New-AzLoadBalancerInboundNatRuleConfig -Name $inboundNatRuleName -FrontendIPConfigurationId $frontend.Id -Protocol Tcp -FrontendPort 3389 -BackendPort 3389 -IdleTimeoutInMinutes 15 -EnableFloatingIP
        $lbrule = New-AzLoadBalancerRuleConfig -Name $lbruleName -FrontendIPConfigurationId $frontend.Id -BackendAddressPoolId $backendAddressPool.Id -ProbeId $probe.Id -Protocol Tcp -FrontendPort 80 -BackendPort 80 -IdleTimeoutInMinutes 15 -EnableFloatingIP
        $actualLb = New-AzLoadBalancer -Name $lbName -ResourceGroupName $rgname -Location $location -FrontendIpConfiguration $frontend -BackendAddressPool $backendAddressPool -Probe $probe -InboundNatRule $inboundNatRule -LoadBalancingRule $lbrule
        
        $expectedLb = Get-AzLoadBalancer -Name $lbName -ResourceGroupName $rgname
        
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
        $list = Get-AzLoadBalancer -ResourceGroupName $rgname
        Assert-AreEqual 1 @($list).Count
        Assert-AreEqual $expectedLb.Etag $list[0].Etag
        Assert-AreEqual $expectedLb.FrontendIPConfigurations[0].Etag $list[0].FrontendIPConfigurations[0].Etag
        Assert-AreEqual $expectedLb.BackendAddressPools[0].Etag $list[0].BackendAddressPools[0].Etag
        Assert-AreEqual $expectedLb.InboundNatRules[0].Etag $list[0].InboundNatRules[0].Etag
        Assert-AreEqual $expectedLb.Probes[0].Etag $list[0].Probes[0].Etag
        Assert-AreEqual $expectedLb.LoadBalancingRules[0].Etag $list[0].LoadBalancingRules[0].Etag
        
        # Delete
        $deleteLb = Remove-AzLoadBalancer -Name $lbName -ResourceGroupName $rgname -PassThru -Force
        Assert-AreEqual true $deleteLb
        
        $list = Get-AzLoadBalancer -ResourceGroupName $rgname
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
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval"} 
        
        # Create the Virtual Network
        $subnet = New-AzVirtualNetworkSubnetConfig -Name $subnetName -AddressPrefix 10.0.1.0/24
        $vnet = New-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnet
        
        # Create the publicip
        $publicip = New-AzPublicIpAddress -ResourceGroupName $rgname -name $publicIpName -location $location -AllocationMethod Dynamic -DomainNameLabel $domainNameLabel

        # Create LoadBalancer
        $frontend = New-AzLoadBalancerFrontendIpConfig -Name $frontendName -PublicIpAddress $publicip
        $backendAddressPool = New-AzLoadBalancerBackendAddressPoolConfig -Name $backendAddressPoolName
        $probe = New-AzLoadBalancerProbeConfig -Name $probeName -RequestPath healthcheck.aspx -Protocol http -Port 80 -IntervalInSeconds 15 -ProbeCount 2
        $inboundNatRule = New-AzLoadBalancerInboundNatRuleConfig -Name $inboundNatRuleName -FrontendIPConfiguration $frontend -Protocol Tcp -FrontendPort 3389 -BackendPort 3389 -IdleTimeoutInMinutes 15 -EnableFloatingIP
        $actualLb = New-AzLoadBalancer -Name $lbName -ResourceGroupName $rgname -Location $location -FrontendIpConfiguration $frontend -BackendAddressPool $backendAddressPool -Probe $probe -InboundNatRule $inboundNatRule
        
        $expectedLb = Get-AzLoadBalancer -Name $lbName -ResourceGroupName $rgname

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
        $list = Get-AzLoadBalancer -ResourceGroupName $rgname
        Assert-AreEqual 1 @($list).Count
        Assert-AreEqual $expectedLb.Etag $list[0].Etag
        Assert-AreEqual $expectedLb.FrontendIPConfigurations[0].Etag $list[0].FrontendIPConfigurations[0].Etag
        Assert-AreEqual $expectedLb.BackendAddressPools[0].Etag $list[0].BackendAddressPools[0].Etag
        Assert-AreEqual $expectedLb.InboundNatRules[0].Etag $list[0].InboundNatRules[0].Etag
        Assert-AreEqual $expectedLb.Probes[0].Etag $list[0].Probes[0].Etag
        
        # Delete
        $deleteLb = Remove-AzLoadBalancer -Name $lbName -ResourceGroupName $rgname -PassThru -Force
        Assert-AreEqual true $deleteLb
        
        $list = Get-AzLoadBalancer -ResourceGroupName $rgname
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
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval"} 
        
        # Create the Virtual Network
        $subnet = New-AzVirtualNetworkSubnetConfig -Name $subnetName -AddressPrefix 10.0.1.0/24
        $vnet = New-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnet
        
        # Create the publicip
        $publicip = New-AzPublicIpAddress -ResourceGroupName $rgname -name $publicIpName -location $location -AllocationMethod Dynamic -DomainNameLabel $domainNameLabel

        $frontend = New-AzLoadBalancerFrontendIpConfig -Name $frontendName -SubnetId $vnet.Subnets[0].Id
        $backendAddressPool = New-AzLoadBalancerBackendAddressPoolConfig -Name $backendAddressPoolName
        $probe = New-AzLoadBalancerProbeConfig -Name $probeName -RequestPath healthcheck.aspx -Protocol http -Port 80 -IntervalInSeconds 15 -ProbeCount 2 -ProbeThreshold 2
        $inboundNatRule = New-AzLoadBalancerInboundNatRuleConfig -Name $inboundNatRuleName -FrontendIPConfigurationId $frontend.Id -Protocol Tcp -FrontendPort 3389 -BackendPort 3389 -IdleTimeoutInMinutes 15 -EnableFloatingIP
        $lbrule = New-AzLoadBalancerRuleConfig -Name $lbruleName -FrontendIPConfigurationId $frontend.Id -BackendAddressPoolId $backendAddressPool.Id -ProbeId $probe.Id -Protocol Tcp -FrontendPort 80 -BackendPort 80 -IdleTimeoutInMinutes 15 -EnableFloatingIP
        New-AzLoadBalancer -Name $lbName -ResourceGroupName $rgname -Location $location -FrontendIpConfiguration $frontend -BackendAddressPool $backendAddressPool -Probe $probe -InboundNatRule $inboundNatRule -LoadBalancingRule $lbrule
        
        $lb = Get-AzLoadBalancer -Name $lbName -ResourceGroupName $rgname
        
        # Test FrontendConfig cmdlets
        $frontendName2 = Get-ResourceName
        $lb = $lb | Add-AzLoadBalancerFrontendIpConfig -Name $frontendName2 -Subnet $vnet.Subnets[0]

        Assert-AreEqual 2 @($lb.FrontendIPConfigurations).Count
        Assert-AreEqual $frontendName2 $lb.FrontendIPConfigurations[1].Name
        Assert-AreEqual "Dynamic" $lb.FrontendIPConfigurations[1].PrivateIPAllocationMethod
        Assert-AreEqual $vnet.Subnets[0].Id $lb.FrontendIPConfigurations[1].Subnet.Id

        $lb = $lb | Set-AzLoadBalancerFrontendIpConfig -Name $frontendName2 -Subnet $vnet.Subnets[0] -PrivateIpAddress "10.0.1.5"
        Assert-AreEqual 2 @($lb.FrontendIPConfigurations).Count
        Assert-AreEqual $frontendName2 $lb.FrontendIPConfigurations[1].Name
        Assert-AreEqual "Static" $lb.FrontendIPConfigurations[1].PrivateIPAllocationMethod
        Assert-AreEqual $vnet.Subnets[0].Id $lb.FrontendIPConfigurations[1].Subnet.Id
        Assert-AreEqual "10.0.1.5" $lb.FrontendIPConfigurations[1].PrivateIpAddress

        $frontendIpconfig = $lb | Get-AzLoadBalancerFrontendIpConfig -Name $frontendName2
        $frontendIpconfigList = $lb | Get-AzLoadBalancerFrontendIpConfig
        Assert-AreEqual 2 @($frontendIpconfigList).Count
        Assert-AreEqual $frontendName $frontendIpconfigList[0].Name
        Assert-AreEqual $frontendName2 $frontendIpconfigList[1].Name
        Assert-AreEqual $frontendIpconfig.Name $frontendIpconfigList[1].Name

        $lb = $lb | Remove-AzLoadBalancerFrontendIpConfig -Name $frontendName2
        Assert-AreEqual 1 @($lb.FrontendIPConfigurations).Count
        Assert-AreEqual $frontendName $lb.FrontendIPConfigurations[0].Name

        # Test BackendAddressPool cmdlets
        $backendAddressPoolName2 = Get-ResourceName
        $job =  Get-AzLoadBalancer -Name $lbName -ResourceGroupName $rgname | Add-AzLoadBalancerBackendAddressPoolConfig -Name $backendAddressPoolName2 | Set-AzLoadBalancer -AsJob
		$job | Wait-Job
		$lb = $job | Receive-Job

        Assert-AreEqual 2 @($lb.BackendAddressPools).Count
        Assert-AreEqual $backendAddressPoolName2 $lb.BackendAddressPools[1].Name

        $backendAddressPoolConfig = Get-AzLoadBalancer -Name $lbName -ResourceGroupName $rgname| Get-AzLoadBalancerBackendAddressPoolConfig -Name $backendAddressPoolName2
        $backendAddressPoolConfigList = Get-AzLoadBalancer -Name $lbName -ResourceGroupName $rgname | Get-AzLoadBalancerBackendAddressPoolConfig
        Assert-AreEqual 2 @($backendAddressPoolconfigList).Count
        Assert-AreEqual $backendAddressPoolName $backendAddressPoolConfigList[0].Name
        Assert-AreEqual $backendAddressPoolName2 $backendAddressPoolConfigList[1].Name
        Assert-AreEqual $backendAddressPoolConfig.Name $backendAddressPoolConfigList[1].Name

        $lb =  Get-AzLoadBalancer -Name $lbName -ResourceGroupName $rgname | Remove-AzLoadBalancerBackendAddressPoolConfig -Name $backendAddressPoolName2 | Set-AzLoadBalancer
        Assert-AreEqual 1 @($lb.BackendAddressPools).Count
        Assert-AreEqual $backendAddressPoolName $lb.BackendAddressPools[0].Name

        # Test Probe cmdlets
        $probeName2 = Get-ResourceName
        $lb =  Get-AzLoadBalancer -Name $lbName -ResourceGroupName $rgname | Add-AzLoadBalancerProbeConfig -Name $probeName2 -RequestPath healthcheck2.aspx -Protocol http -Port 81 -IntervalInSeconds 16 -ProbeCount 3 -ProbeThreshold 3 | Set-AzLoadBalancer

        Assert-AreEqual 2 @($lb.Probes).Count
        Assert-AreEqual $probeName2 $lb.Probes[1].Name
        Assert-AreEqual 3 $lb.Probes[1].ProbeThreshold
        Assert-AreEqual "healthcheck2.aspx" $lb.Probes[1].RequestPath
        Assert-AreEqual 81 $lb.Probes[1].Port

        $lb =  Get-AzLoadBalancer -Name $lbName -ResourceGroupName $rgname | Set-AzLoadBalancerProbeConfig -Name $probeName2 -RequestPath healthcheck2.aspx -Protocol http -Port 85 -IntervalInSeconds 16 -ProbeCount 3 -ProbeThreshold 3 | Set-AzLoadBalancer
        Assert-AreEqual 2 @($lb.Probes).Count
        Assert-AreEqual $probeName2 $lb.Probes[1].Name
        Assert-AreEqual "healthcheck2.aspx" $lb.Probes[1].RequestPath
        Assert-AreEqual 85 $lb.Probes[1].Port

        $probeConfig = Get-AzLoadBalancer -Name $lbName -ResourceGroupName $rgname | Get-AzLoadBalancerProbeConfig -Name $probeName2
        $probeConfigList = Get-AzLoadBalancer -Name $lbName -ResourceGroupName $rgname | Get-AzLoadBalancerProbeConfig
        Assert-AreEqual 2 @($probeConfigList).Count
        Assert-AreEqual $probeName $probeConfigList[0].Name
        Assert-AreEqual $probeName2 $probeConfigList[1].Name
        Assert-AreEqual $probeConfig.Name $probeConfigList[1].Name

        $lb =  Get-AzLoadBalancer -Name $lbName -ResourceGroupName $rgname | Remove-AzLoadBalancerProbeConfig -Name $probeName2 | Set-AzLoadBalancer
        Assert-AreEqual 1 @($lb.Probes).Count
        Assert-AreEqual $probeName $lb.Probes[0].Name

        # Test InboundNatRule cmdlets
        $inboundNatRuleName2 = Get-ResourceName
        $lb = Get-AzLoadBalancer -Name $lbName -ResourceGroupName $rgname | Add-AzLoadBalancerInboundNatRuleConfig -Name $inboundNatRuleName2 -FrontendIPConfigurationId $lb.FrontendIPConfigurations[0].Id -Protocol Tcp -FrontendPort 3350 -BackendPort 3350 -IdleTimeoutInMinutes 17 -EnableFloatingIP | Set-AzLoadBalancer
        
        Assert-AreEqual 2 @($lb.InboundNatRules).Count
        Assert-AreEqual $inboundNatRuleName2 $lb.InboundNatRules[1].Name
        Assert-AreEqual 3350 $lb.InboundNatRules[1].FrontendPort
        Assert-AreEqual 3350 $lb.InboundNatRules[1].BackendPort
        Assert-AreEqual true $lb.InboundNatRules[1].EnableFloatingIP

        $lb = Get-AzLoadBalancer -Name $lbName -ResourceGroupName $rgname | Set-AzLoadBalancerInboundNatRuleConfig -Name $inboundNatRuleName2 -FrontendIPConfigurationId $lb.FrontendIPConfigurations[0].Id -Protocol Tcp -FrontendPort 3352 -BackendPort 3351 -IdleTimeoutInMinutes 17 | Set-AzLoadBalancer
        Assert-AreEqual 2 @($lb.InboundNatRules).Count
        Assert-AreEqual $inboundNatRuleName2 $lb.InboundNatRules[1].Name
        Assert-AreEqual 3352 $lb.InboundNatRules[1].FrontendPort
        Assert-AreEqual 3351 $lb.InboundNatRules[1].BackendPort
        Assert-AreEqual false $lb.InboundNatRules[1].EnableFloatingIP

        $inboundNatRuleConfig = Get-AzLoadBalancer -Name $lbName -ResourceGroupName $rgname | Get-AzLoadBalancerInboundNatRuleConfig -Name $inboundNatRuleName2
        $inboundNatRuleConfigList = Get-AzLoadBalancer -Name $lbName -ResourceGroupName $rgname | Get-AzLoadBalancerInboundNatRuleConfig
        Assert-AreEqual 2 @($inboundNatRuleConfigList).Count
        Assert-AreEqual $inboundNatRuleName $inboundNatRuleConfigList[0].Name
        Assert-AreEqual $inboundNatRuleName2 $inboundNatRuleConfigList[1].Name
        Assert-AreEqual $inboundNatRuleConfig.Name $inboundNatRuleConfigList[1].Name

        $lb =  Get-AzLoadBalancer -Name $lbName -ResourceGroupName $rgname | Remove-AzLoadBalancerInboundNatRuleConfig -Name $inboundNatRuleName2 | Set-AzLoadBalancer
        Assert-AreEqual 1 @($lb.InboundNatRules).Count
        Assert-AreEqual $inboundNatRuleName $lb.InboundNatRules[0].Name

        # Test LoadBalancingRule Cmdlets
        $lbruleName2 = Get-ResourceName
        $lb = Get-AzLoadBalancer -Name $lbName -ResourceGroupName $rgname | Add-AzLoadBalancerRuleConfig -Name $lbruleName2 -FrontendIPConfigurationId $lb.FrontendIPConfigurations[0].Id -BackendAddressPoolId $lb.BackendAddressPools[0].Id -ProbeId $lb.Probes[0].Id -Protocol Tcp -FrontendPort 82 -BackendPort 83 -IdleTimeoutInMinutes 15 -LoadDistribution SourceIP| Set-AzLoadBalancer
        
        Assert-AreEqual 2 @($lb.LoadBalancingRules).Count
        Assert-AreEqual $lbruleName2 $lb.LoadBalancingRules[1].Name
        Assert-AreEqual 82 $lb.LoadBalancingRules[1].FrontendPort
        Assert-AreEqual 83 $lb.LoadBalancingRules[1].BackendPort
        Assert-AreEqual false $lb.LoadBalancingRules[1].EnableFloatingIP
        Assert-AreEqual "SourceIP" $lb.LoadBalancingRules[1].LoadDistribution

        $lb = Get-AzLoadBalancer -Name $lbName -ResourceGroupName $rgname | Set-AzLoadBalancerRuleConfig -Name $lbruleName2 -FrontendIPConfigurationId $lb.FrontendIPConfigurations[0].Id -BackendAddressPoolId $lb.BackendAddressPools[0].Id -ProbeId $lb.Probes[0].Id -Protocol Tcp -FrontendPort 84 -BackendPort 84 -IdleTimeoutInMinutes 17 -EnableFloatingIP | Set-AzLoadBalancer
        Assert-AreEqual 2 @($lb.LoadBalancingRules).Count
        Assert-AreEqual $lbruleName2 $lb.LoadBalancingRules[1].Name
        Assert-AreEqual 84 $lb.LoadBalancingRules[1].FrontendPort
        Assert-AreEqual 84 $lb.LoadBalancingRules[1].BackendPort
        Assert-AreEqual true $lb.LoadBalancingRules[1].EnableFloatingIP
        Assert-AreEqual "Default" $lb.LoadBalancingRules[1].LoadDistribution

        $lbruleConfig = Get-AzLoadBalancer -Name $lbName -ResourceGroupName $rgname | Get-AzLoadBalancerRuleConfig -Name $lbruleName2
        $lbruleConfigList = Get-AzLoadBalancer -Name $lbName -ResourceGroupName $rgname | Get-AzLoadBalancerRuleConfig
        Assert-AreEqual 2 @($inboundNatRuleConfigList).Count
        Assert-AreEqual $lbruleName $lbruleConfigList[0].Name
        Assert-AreEqual $lbruleName2 $lbruleConfigList[1].Name
        Assert-AreEqual $lbruleConfig.Name $lbruleConfigList[1].Name

        $lb = Get-AzLoadBalancer -Name $lbName -ResourceGroupName $rgname | Remove-AzLoadBalancerRuleConfig -Name $lbruleName2 | Set-AzLoadBalancer
        Assert-AreEqual 1 @($lb.LoadBalancingRules).Count
        Assert-AreEqual $lbruleName $lb.LoadBalancingRules[0].Name

        # Delete
        $deleteLb = $lb | Remove-AzLoadBalancer -PassThru -Force
        Assert-AreEqual true $deleteLb
        
        $list = Get-AzLoadBalancer -ResourceGroupName $rgname
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
Tests for load balancer probes
#>
function Test-LoadBalancerProbes_ProbeThresholdParameter
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
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval"} 
        
        # Create the Virtual Network
        $subnet = New-AzVirtualNetworkSubnetConfig -Name $subnetName -AddressPrefix 10.0.1.0/24
        $vnet = New-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnet
        
        # Create the publicip
        $publicip = New-AzPublicIpAddress -ResourceGroupName $rgname -name $publicIpName -location $location -AllocationMethod Dynamic -DomainNameLabel $domainNameLabel

        $frontend = New-AzLoadBalancerFrontendIpConfig -Name $frontendName -SubnetId $vnet.Subnets[0].Id
        $backendAddressPool = New-AzLoadBalancerBackendAddressPoolConfig -Name $backendAddressPoolName
        $probe = New-AzLoadBalancerProbeConfig -Name $probeName -RequestPath healthcheck.aspx -Protocol http -Port 80 -IntervalInSeconds 15 -ProbeCount 2
        $inboundNatRule = New-AzLoadBalancerInboundNatRuleConfig -Name $inboundNatRuleName -FrontendIPConfigurationId $frontend.Id -Protocol Tcp -FrontendPort 3389 -BackendPort 3389 -IdleTimeoutInMinutes 15 -EnableFloatingIP
        $lbrule = New-AzLoadBalancerRuleConfig -Name $lbruleName -FrontendIPConfigurationId $frontend.Id -BackendAddressPoolId $backendAddressPool.Id -ProbeId $probe.Id -Protocol Tcp -FrontendPort 80 -BackendPort 80 -IdleTimeoutInMinutes 15 -EnableFloatingIP
        New-AzLoadBalancer -Name $lbName -ResourceGroupName $rgname -Location $location -FrontendIpConfiguration $frontend -BackendAddressPool $backendAddressPool -Probe $probe -InboundNatRule $inboundNatRule -LoadBalancingRule $lbrule
        
        $lb = Get-AzLoadBalancer -Name $lbName -ResourceGroupName $rgname
        
        # Test LbProbe Cmdlet
        Assert-AreEqual '1' $lb.Probes[0].ProbeThreshold

        # Test Probe cmdlets
        $probeName2 = Get-ResourceName
        $lb =  Get-AzLoadBalancer -Name $lbName -ResourceGroupName $rgname | Add-AzLoadBalancerProbeConfig -Name $probeName2 -RequestPath healthcheck2.aspx -Protocol http -Port 81 -IntervalInSeconds 16 -ProbeCount 3 -ProbeThreshold $null | Set-AzLoadBalancer

        Assert-AreEqual 2 @($lb.Probes).Count
        Assert-AreEqual $probeName2 $lb.Probes[1].Name
        Assert-AreEqual 1 $lb.Probes[1].ProbeThreshold
        Assert-AreEqual "healthcheck2.aspx" $lb.Probes[1].RequestPath
        Assert-AreEqual 81 $lb.Probes[1].Port

        $lb =  Get-AzLoadBalancer -Name $lbName -ResourceGroupName $rgname | Set-AzLoadBalancerProbeConfig -Name $probeName2 -RequestPath healthcheck2.aspx -Protocol http -Port 85 -IntervalInSeconds 16 -ProbeCount 3 | Set-AzLoadBalancer
        Assert-AreEqual 2 @($lb.Probes).Count
        Assert-AreEqual $probeName2 $lb.Probes[1].Name
        Assert-AreEqual "healthcheck2.aspx" $lb.Probes[1].RequestPath
        Assert-AreEqual 85 $lb.Probes[1].Port
        Assert-AreEqual 1 $lb.Probes[1].ProbeThreshold

        $probeConfig = Get-AzLoadBalancer -Name $lbName -ResourceGroupName $rgname | Get-AzLoadBalancerProbeConfig -Name $probeName2
        $probeConfigList = Get-AzLoadBalancer -Name $lbName -ResourceGroupName $rgname | Get-AzLoadBalancerProbeConfig
        Assert-AreEqual 2 @($probeConfigList).Count
        Assert-AreEqual $probeName $probeConfigList[0].Name
        Assert-AreEqual $probeName2 $probeConfigList[1].Name
        Assert-AreEqual $probeConfig.Name $probeConfigList[1].Name

        $lb =  Get-AzLoadBalancer -Name $lbName -ResourceGroupName $rgname | Remove-AzLoadBalancerProbeConfig -Name $probeName2 | Set-AzLoadBalancer
        Assert-AreEqual 1 @($lb.Probes).Count
        Assert-AreEqual $probeName $lb.Probes[0].Name

        # Delete
        $deleteLb = $lb | Remove-AzLoadBalancer -PassThru -Force
        Assert-AreEqual true $deleteLb
        
        $list = Get-AzLoadBalancer -ResourceGroupName $rgname
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
Tests for load balancer probes
#>
function Test-LoadBalancerProbes_NoHealthyBackendsBehaviorParameter
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
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval"} 
        
        # Create the publicip
        $publicip = New-AzPublicIpAddress -ResourceGroupName $rgname -name $publicIpName -location $location -AllocationMethod Static -DomainNameLabel $domainNameLabel

        $frontend = New-AzLoadBalancerFrontendIpConfig -Name $frontendName -PublicIpAddress $publicip
        $backendAddressPool = New-AzLoadBalancerBackendAddressPoolConfig -Name $backendAddressPoolName
        $probe = New-AzLoadBalancerProbeConfig -Name $probeName -Protocol Tcp -Port 80 -IntervalInSeconds 15 -ProbeCount 2 -NoHealthyBackendsBehavior "AllProbedUp"
        $inboundNatRule = New-AzLoadBalancerInboundNatRuleConfig -Name $inboundNatRuleName -FrontendIPConfigurationId $frontend.Id -Protocol Tcp -FrontendPort 3389 -BackendPort 3389 -IdleTimeoutInMinutes 15 -EnableFloatingIP
        $lbrule = New-AzLoadBalancerRuleConfig -Name $lbruleName -FrontendIPConfigurationId $frontend.Id -BackendAddressPoolId $backendAddressPool.Id -ProbeId $probe.Id -Protocol Tcp -FrontendPort 80 -BackendPort 80 -IdleTimeoutInMinutes 15 -EnableFloatingIP
        New-AzLoadBalancer -Name $lbName -ResourceGroupName $rgname -Location $location -FrontendIpConfiguration $frontend -BackendAddressPool $backendAddressPool -Probe $probe -InboundNatRule $inboundNatRule -LoadBalancingRule $lbrule -Tier Regional
        
        $lb = Get-AzLoadBalancer -Name $lbName -ResourceGroupName $rgname
        
        # Test LbProbe Cmdlet
        Assert-AreEqual '1' $lb.Probes[0].ProbeThreshold
        Assert-AreEqual "AllProbedUp" $lb.Probes[0].NoHealthyBackendsBehavior

        # Test Probe cmdlets
        $probeName2 = Get-ResourceName
        $lb =  Get-AzLoadBalancer -Name $lbName -ResourceGroupName $rgname | Add-AzLoadBalancerProbeConfig -Name $probeName2 -RequestPath healthcheck2.aspx -Protocol http -Port 81 -IntervalInSeconds 16 -ProbeCount 3 -ProbeThreshold $null -NoHealthyBackendsBehavior "AllProbedDown" | Set-AzLoadBalancer

        Assert-AreEqual 2 @($lb.Probes).Count
        Assert-AreEqual $probeName2 $lb.Probes[1].Name
        Assert-AreEqual 1 $lb.Probes[1].ProbeThreshold
        Assert-AreEqual "healthcheck2.aspx" $lb.Probes[1].RequestPath
        Assert-AreEqual 81 $lb.Probes[1].Port
        Assert-AreEqual "AllProbedDown" $lb.Probes[1].NoHealthyBackendsBehavior

        $lb =  Get-AzLoadBalancer -Name $lbName -ResourceGroupName $rgname | Set-AzLoadBalancerProbeConfig -Name $probeName2 -RequestPath healthcheck2.aspx -Protocol http -Port 85 -IntervalInSeconds 16 -ProbeCount 3 -NoHealthyBackendsBehavior "AllProbedUp" | Set-AzLoadBalancer
        Assert-AreEqual 2 @($lb.Probes).Count
        Assert-AreEqual $probeName2 $lb.Probes[1].Name
        Assert-AreEqual "healthcheck2.aspx" $lb.Probes[1].RequestPath
        Assert-AreEqual 85 $lb.Probes[1].Port
        Assert-AreEqual 1 $lb.Probes[1].ProbeThreshold
        Assert-AreEqual "AllProbedUp" $lb.Probes[1].NoHealthyBackendsBehavior

        $probeConfig = Get-AzLoadBalancer -Name $lbName -ResourceGroupName $rgname | Get-AzLoadBalancerProbeConfig -Name $probeName2
        $probeConfigList = Get-AzLoadBalancer -Name $lbName -ResourceGroupName $rgname | Get-AzLoadBalancerProbeConfig
        Assert-AreEqual 2 @($probeConfigList).Count
        Assert-AreEqual $probeName $probeConfigList[0].Name
        Assert-AreEqual $probeName2 $probeConfigList[1].Name
        Assert-AreEqual $probeConfig.Name $probeConfigList[1].Name
        Assert-AreEqual "AllProbedUp" $lb.Probes[1].NoHealthyBackendsBehavior

        $lb =  Get-AzLoadBalancer -Name $lbName -ResourceGroupName $rgname | Remove-AzLoadBalancerProbeConfig -Name $probeName2 | Set-AzLoadBalancer
        Assert-AreEqual 1 @($lb.Probes).Count
        Assert-AreEqual $probeName $lb.Probes[0].Name
        Assert-AreEqual "AllProbedUp" $lb.Probes[0].NoHealthyBackendsBehavior

        # Delete
        $deleteLb = $lb | Remove-AzLoadBalancer -PassThru -Force
        Assert-AreEqual true $deleteLb
        
        $list = Get-AzLoadBalancer -ResourceGroupName $rgname
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
Tests creating new simple Load balancer and edit InboundNatRuleV2 using config cmdlets
#>
function Test-LoadBalancerInboundNatRuleV2
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
    $inboundNatRuleV2Name = Get-ResourceName
    $lbruleName = Get-ResourceName
    $rglocation = Get-ProviderLocation ResourceManagement
    $resourceTypeParent = "Microsoft.Network/loadBalancers"
    $location = Get-ProviderLocation $resourceTypeParent

    try
    {
        # Create the resource group
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval"} 

        # Create the Virtual Network
        $subnet = New-AzVirtualNetworkSubnetConfig -Name $subnetName -AddressPrefix 10.0.1.0/24
        $vnet = New-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnet

        # Create the publicip
        $publicip = New-AzPublicIpAddress -ResourceGroupName $rgname -name $publicIpName -location $location -AllocationMethod Static -Sku Standard -DomainNameLabel $domainNameLabel

        $frontend = New-AzLoadBalancerFrontendIpConfig -Name $frontendName -PublicIpAddress $publicip
        $backendAddressPool = New-AzLoadBalancerBackendAddressPoolConfig -Name $backendAddressPoolName
        $probe = New-AzLoadBalancerProbeConfig -Name $probeName -RequestPath healthcheck.aspx -Protocol http -Port 80 -IntervalInSeconds 15 -ProbeCount 2
        $inboundNatRuleV2 = New-AzLoadBalancerInboundNatRuleConfig -Name $inboundNatRuleV2Name -FrontendIPConfigurationId $frontend.Id -Protocol Tcp -BackendPort 3390 -IdleTimeoutInMinutes 15 -EnableFloatingIP -FrontendPortRangeStart 3390 -FrontendPortRangeEnd 4001 -BackendAddressPoolId $backendAddressPool.Id
        $lbrule = New-AzLoadBalancerRuleConfig -Name $lbruleName -FrontendIPConfigurationId $frontend.Id -BackendAddressPoolId $backendAddressPool.Id -ProbeId $probe.Id -Protocol Tcp -FrontendPort 80 -BackendPort 80 -IdleTimeoutInMinutes 15 -EnableFloatingIP
        New-AzLoadBalancer -Name $lbName -ResourceGroupName $rgname -Sku Standard -Location $location -FrontendIpConfiguration $frontend -BackendAddressPool $backendAddressPool -Probe $probe -InboundNatRule $inboundNatRuleV2 -LoadBalancingRule $lbrule

        $lb = Get-AzLoadBalancer -Name $lbName -ResourceGroupName $rgname
        Assert-AreEqual 1 @($lb.InboundNatRules).Count
        Assert-AreEqual $inboundNatRuleV2Name $lb.InboundNatRules[0].Name
        Assert-AreEqual 3390 $lb.InboundNatRules[0].FrontendPortRangeStart
        Assert-AreEqual 4001 $lb.InboundNatRules[0].FrontendPortRangeEnd
        Assert-AreEqual 3390 $lb.InboundNatRules[0].BackendPort

        # Test InboundNatRuleV2 cmdlets
        $inboundNatRuleV2Name2 = Get-ResourceName
        $lb = Get-AzLoadBalancer -Name $lbName -ResourceGroupName $rgname | Add-AzLoadBalancerInboundNatRuleConfig -Name $inboundNatRuleV2Name2 -FrontendIPConfigurationId $lb.FrontendIPConfigurations[0].Id -BackendAddressPoolId $lb.BackendAddressPools[0].Id -Protocol Tcp -FrontendPortRangeStart 3370 -FrontendPortRangeEnd 3385 -BackendPort 3370 -IdleTimeoutInMinutes 17 -EnableFloatingIP | Set-AzLoadBalancer

        Assert-AreEqual 2 @($lb.InboundNatRules).Count
        Assert-AreEqual $inboundNatRuleV2Name2 $lb.InboundNatRules[1].Name
        Assert-AreEqual 3370 $lb.InboundNatRules[1].FrontendPortRangeStart
        Assert-AreEqual 3385 $lb.InboundNatRules[1].FrontendPortRangeEnd
        Assert-AreEqual 3370 $lb.InboundNatRules[1].BackendPort
        Assert-AreEqual true $lb.InboundNatRules[1].EnableFloatingIP

        $lb = Get-AzLoadBalancer -Name $lbName -ResourceGroupName $rgname | Set-AzLoadBalancerInboundNatRuleConfig -Name $inboundNatRuleV2Name2 -FrontendIPConfigurationId $lb.FrontendIPConfigurations[0].Id -BackendAddressPoolId $lb.BackendAddressPools[0].Id-Protocol Tcp -FrontendPortRangeStart 3365 -FrontendPortRangeEnd 3385 -BackendPort 3371 -IdleTimeoutInMinutes 17 | Set-AzLoadBalancer
        Assert-AreEqual 2 @($lb.InboundNatRules).Count
        Assert-AreEqual $inboundNatRuleV2Name2 $lb.InboundNatRules[1].Name
        Assert-AreEqual 3365 $lb.InboundNatRules[1].FrontendPortRangeStart
        Assert-AreEqual 3385 $lb.InboundNatRules[1].FrontendPortRangeEnd
        Assert-AreEqual 3371 $lb.InboundNatRules[1].BackendPort
        Assert-AreEqual false $lb.InboundNatRules[1].EnableFloatingIP

        $inboundNatRuleV2Config = Get-AzLoadBalancer -Name $lbName -ResourceGroupName $rgname | Get-AzLoadBalancerInboundNatRuleConfig -Name $inboundNatRuleV2Name2
        $inboundNatRuleConfigList = Get-AzLoadBalancer -Name $lbName -ResourceGroupName $rgname | Get-AzLoadBalancerInboundNatRuleConfig
        Assert-AreEqual 2 @($inboundNatRuleConfigList).Count
        Assert-AreEqual $inboundNatRuleV2Name $inboundNatRuleConfigList[0].Name
        Assert-AreEqual $inboundNatRuleV2Name2 $inboundNatRuleConfigList[1].Name
        Assert-AreEqual $inboundNatRuleV2Config.Name $inboundNatRuleConfigList[1].Name

        $lb =  Get-AzLoadBalancer -Name $lbName -ResourceGroupName $rgname | Remove-AzLoadBalancerInboundNatRuleConfig -Name $inboundNatRuleV2Name2 | Set-AzLoadBalancer
        Assert-AreEqual 1 @($lb.InboundNatRules).Count
        Assert-AreEqual $inboundNatRuleV2Name $lb.InboundNatRules[0].Name
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Tests creating new simple Load balancer and edit InboundNatRuleV2 using config cmdlets
#>
function Test-LoadBalancerInboundNatRuleV2-InternalLB
{
    # Setup
    $rgname = Get-ResourceGroupName
    $vnetName = Get-ResourceName
    $subnetName = Get-ResourceName
    $domainNameLabel = Get-ResourceName
    $lbName = Get-ResourceName
    $frontendName = Get-ResourceName
    $backendAddressPoolName = Get-ResourceName
    $probeName = Get-ResourceName
    $inboundNatRuleV2Name = Get-ResourceName
    $lbruleName = Get-ResourceName
    $rglocation = Get-ProviderLocation ResourceManagement
    $resourceTypeParent = "Microsoft.Network/loadBalancers"
    $location = Get-ProviderLocation $resourceTypeParent

    try
    {
        # Create the resource group
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval"} 

        # Create the Virtual Network
        $subnet = New-AzVirtualNetworkSubnetConfig -Name $subnetName -AddressPrefix 10.0.1.0/24
        $vnet = New-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnet

        $frontend = New-AzLoadBalancerFrontendIpConfig -Name $frontendName -SubnetId $vnet.Subnets[0].Id
        $backendAddressPool = New-AzLoadBalancerBackendAddressPoolConfig -Name $backendAddressPoolName
        $probe = New-AzLoadBalancerProbeConfig -Name $probeName -RequestPath healthcheck.aspx -Protocol http -Port 80 -IntervalInSeconds 15 -ProbeCount 2
        $inboundNatRuleV2 = New-AzLoadBalancerInboundNatRuleConfig -Name $inboundNatRuleV2Name -FrontendIPConfigurationId $frontend.Id -Protocol Tcp -BackendPort 3390 -IdleTimeoutInMinutes 15 -EnableFloatingIP -FrontendPortRangeStart 3390 -FrontendPortRangeEnd 4001 -BackendAddressPoolId $backendAddressPool.Id
        $lbrule = New-AzLoadBalancerRuleConfig -Name $lbruleName -FrontendIPConfigurationId $frontend.Id -BackendAddressPoolId $backendAddressPool.Id -ProbeId $probe.Id -Protocol Tcp -FrontendPort 80 -BackendPort 80 -IdleTimeoutInMinutes 15 -EnableFloatingIP
        New-AzLoadBalancer -Name $lbName -ResourceGroupName $rgname -Sku Standard -Location $location -FrontendIpConfiguration $frontend -BackendAddressPool $backendAddressPool -Probe $probe -InboundNatRule $inboundNatRuleV2 -LoadBalancingRule $lbrule

        $lb = Get-AzLoadBalancer -Name $lbName -ResourceGroupName $rgname
        Assert-AreEqual 1 @($lb.InboundNatRules).Count
        Assert-AreEqual $inboundNatRuleV2Name $lb.InboundNatRules[0].Name
        Assert-AreEqual 3390 $lb.InboundNatRules[0].FrontendPortRangeStart
        Assert-AreEqual 4001 $lb.InboundNatRules[0].FrontendPortRangeEnd
        Assert-AreEqual 3390 $lb.InboundNatRules[0].BackendPort

        # Test InboundNatRuleV2 cmdlets
        $inboundNatRuleV2Name2 = Get-ResourceName
        $lb = Get-AzLoadBalancer -Name $lbName -ResourceGroupName $rgname | Add-AzLoadBalancerInboundNatRuleConfig -Name $inboundNatRuleV2Name2 -FrontendIPConfigurationId $lb.FrontendIPConfigurations[0].Id -BackendAddressPoolId $lb.BackendAddressPools[0].Id -Protocol Tcp -FrontendPortRangeStart 3370 -FrontendPortRangeEnd 3385 -BackendPort 3370 -IdleTimeoutInMinutes 17 -EnableFloatingIP | Set-AzLoadBalancer

        Assert-AreEqual 2 @($lb.InboundNatRules).Count
        Assert-AreEqual $inboundNatRuleV2Name2 $lb.InboundNatRules[1].Name
        Assert-AreEqual 3370 $lb.InboundNatRules[1].FrontendPortRangeStart
        Assert-AreEqual 3385 $lb.InboundNatRules[1].FrontendPortRangeEnd
        Assert-AreEqual 3370 $lb.InboundNatRules[1].BackendPort
        Assert-AreEqual true $lb.InboundNatRules[1].EnableFloatingIP

        $lb = Get-AzLoadBalancer -Name $lbName -ResourceGroupName $rgname | Set-AzLoadBalancerInboundNatRuleConfig -Name $inboundNatRuleV2Name2 -FrontendIPConfigurationId $lb.FrontendIPConfigurations[0].Id -BackendAddressPoolId $lb.BackendAddressPools[0].Id-Protocol Tcp -FrontendPortRangeStart 3365 -FrontendPortRangeEnd 3385 -BackendPort 3371 -IdleTimeoutInMinutes 17 | Set-AzLoadBalancer
        Assert-AreEqual 2 @($lb.InboundNatRules).Count
        Assert-AreEqual $inboundNatRuleV2Name2 $lb.InboundNatRules[1].Name
        Assert-AreEqual 3365 $lb.InboundNatRules[1].FrontendPortRangeStart
        Assert-AreEqual 3385 $lb.InboundNatRules[1].FrontendPortRangeEnd
        Assert-AreEqual 3371 $lb.InboundNatRules[1].BackendPort
        Assert-AreEqual false $lb.InboundNatRules[1].EnableFloatingIP

        $inboundNatRuleV2Config = Get-AzLoadBalancer -Name $lbName -ResourceGroupName $rgname | Get-AzLoadBalancerInboundNatRuleConfig -Name $inboundNatRuleV2Name2
        $inboundNatRuleConfigList = Get-AzLoadBalancer -Name $lbName -ResourceGroupName $rgname | Get-AzLoadBalancerInboundNatRuleConfig
        Assert-AreEqual 2 @($inboundNatRuleConfigList).Count
        Assert-AreEqual $inboundNatRuleV2Name $inboundNatRuleConfigList[0].Name
        Assert-AreEqual $inboundNatRuleV2Name2 $inboundNatRuleConfigList[1].Name
        Assert-AreEqual $inboundNatRuleV2Config.Name $inboundNatRuleConfigList[1].Name

        $lb =  Get-AzLoadBalancer -Name $lbName -ResourceGroupName $rgname | Remove-AzLoadBalancerInboundNatRuleConfig -Name $inboundNatRuleV2Name2 | Set-AzLoadBalancer
        Assert-AreEqual 1 @($lb.InboundNatRules).Count
        Assert-AreEqual $inboundNatRuleV2Name $lb.InboundNatRules[0].Name
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
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval"} 
        
        # Create the Virtual Network
        $subnet = New-AzVirtualNetworkSubnetConfig -Name $subnetName -AddressPrefix 10.0.1.0/24
        $vnet = New-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnet
        
        # Create the publicip
        $publicip = New-AzPublicIpAddress -ResourceGroupName $rgname -name $publicIpName -location $location -AllocationMethod Dynamic -DomainNameLabel $domainNameLabel

        $frontend = New-AzLoadBalancerFrontendIpConfig -Name $frontendName -SubnetId $vnet.Subnets[0].Id
        $backendAddressPool = New-AzLoadBalancerBackendAddressPoolConfig -Name $backendAddressPoolName
        $probe = New-AzLoadBalancerProbeConfig -Name $probeName -RequestPath healthcheck.aspx -Protocol http -Port 80 -IntervalInSeconds 15 -ProbeCount 2 -ProbeThreshold 2
        $inboundNatRule = New-AzLoadBalancerInboundNatRuleConfig -Name $inboundNatRuleName -FrontendIPConfigurationId $frontend.Id -Protocol Tcp -FrontendPort 3389 -BackendPort 3389 -IdleTimeoutInMinutes 15 -EnableFloatingIP
        $lbrule = New-AzLoadBalancerRuleConfig -Name $lbruleName -FrontendIPConfigurationId $frontend.Id -BackendAddressPoolId $backendAddressPool.Id -ProbeId $probe.Id -Protocol Tcp -FrontendPort 80 -BackendPort 80 -IdleTimeoutInMinutes 15 -EnableFloatingIP
        New-AzLoadBalancer -Name $lbName -ResourceGroupName $rgname -Location $location -FrontendIpConfiguration $frontend -BackendAddressPool $backendAddressPool -Probe $probe -InboundNatRule $inboundNatRule -LoadBalancingRule $lbrule
        
        $lb = Get-AzLoadBalancer -Name $lbName -ResourceGroupName $rgname
    
        # Test Probe cmdlets
        $probeName2 = Get-ResourceName
        $lb = Get-AzLoadBalancer -Name $lbName -ResourceGroupName $rgname | Add-AzLoadBalancerProbeConfig -Name $probeName2 -RequestPath healthcheck2.aspx -Protocol http -Port 81 -IntervalInSeconds 16 -ProbeCount 3 -ProbeThreshold 3 | Set-AzLoadBalancer

        Assert-AreEqual 2 @($lb.Probes).Count
        Assert-AreEqual $probeName2 $lb.Probes[1].Name
        Assert-AreEqual "healthcheck2.aspx" $lb.Probes[1].RequestPath
        Assert-AreEqual 81 $lb.Probes[1].Port
        Assert-AreEqual 3 $lb.Probes[1].ProbeThreshold

        $lb = Get-AzLoadBalancer -Name $lbName -ResourceGroupName $rgname | Set-AzLoadBalancer
        Assert-AreEqual 2 @($lb.Probes).Count
        Assert-AreEqual $probeName2 $lb.Probes[1].Name
        Assert-AreEqual "healthcheck2.aspx" $lb.Probes[1].RequestPath
        Assert-AreEqual 81 $lb.Probes[1].Port

        # Delete
        $deleteLb = $lb | Remove-AzLoadBalancer -PassThru -Force
        Assert-AreEqual true $deleteLb
        
        $list = Get-AzLoadBalancer -ResourceGroupName $rgname
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
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval"} 
        
        # Create empty load balancer
        New-AzLoadBalancer -Name $lbName -ResourceGroupName $rgname -Location $location

        $lb = Get-AzLoadBalancer -Name $lbName -ResourceGroupName $rgname
        Assert-AreEqual $lbName $lb.Name
        Assert-AreEqual 0 @($lb.FrontendIpConfigurations).Count
        Assert-AreEqual 0 @($lb.BackendAddressPools).Count
        Assert-AreEqual 0 @($lb.Probes).Count
        Assert-AreEqual 0 @($lb.InboundNatRules).Count
        Assert-AreEqual 0 @($lb.LoadBalancingRules).Count

        # Delete
        $deleteLb = $lb | Remove-AzLoadBalancer -PassThru -Force
        Assert-AreEqual true $deleteLb
        
        $list = Get-AzLoadBalancer -ResourceGroupName $rgname
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
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval" } 
        
        # Create the Virtual Network
        $subnet = New-AzVirtualNetworkSubnetConfig -Name $subnetName -AddressPrefix 10.0.1.0/24
        $vnet = New-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnet
        
        # Create the publicip
        $publicip = New-AzPublicIpAddress -ResourceGroupName $rgname -name $publicIpName -location $location -AllocationMethod Dynamic

        # Create LoadBalancer
        $frontend = New-AzLoadBalancerFrontendIpConfig -Name $frontendName -PublicIpAddress $publicip
        $backendAddressPool = New-AzLoadBalancerBackendAddressPoolConfig -Name $backendAddressPoolName
        $probe = New-AzLoadBalancerProbeConfig -Name $probeName -RequestPath healthcheck.aspx -Protocol http -Port 80 -IntervalInSeconds 15 -ProbeCount 2
        $inboundNatRule1 = New-AzLoadBalancerInboundNatRuleConfig -Name $inboundNatRuleName1 -FrontendIPConfiguration $frontend -Protocol Tcp -FrontendPort 3389 -BackendPort 3389 -IdleTimeoutInMinutes 15 -EnableFloatingIP
        $inboundNatRule2 = New-AzLoadBalancerInboundNatRuleConfig -Name $inboundNatRuleName2 -FrontendIPConfiguration $frontend -Protocol Tcp -FrontendPort 3391 -BackendPort 3392
        $lbrule = New-AzLoadBalancerRuleConfig -Name $lbruleName -FrontendIPConfiguration $frontend -BackendAddressPool $backendAddressPool -Probe $probe -Protocol Tcp -FrontendPort 80 -BackendPort 80 -IdleTimeoutInMinutes 15 -EnableFloatingIP -LoadDistribution SourceIP
        $lb = New-AzLoadBalancer -Name $lbName -ResourceGroupName $rgname -Location $location -FrontendIpConfiguration $frontend -BackendAddressPool $backendAddressPool -Probe $probe -InboundNatRule $inboundNatRule1,$inboundNatRule2 -LoadBalancingRule $lbrule
        
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
        $nic1 = New-AzNetworkInterface -Name $nicname1 -ResourceGroupName $rgname -Location $location -Subnet $vnet.Subnets[0]
        $nic2 = New-AzNetworkInterface -Name $nicname2 -ResourceGroupName $rgname -Location $location -Subnet $vnet.Subnets[0]
        $nic3 = New-AzNetworkInterface -Name $nicname3 -ResourceGroupName $rgname -Location $location -Subnet $vnet.Subnets[0]

        # Associate the nic to the load balancer
        $nic1.IpConfigurations[0].LoadBalancerBackendAddressPools.Add($lb.BackendAddressPools[0]);
        $nic1.IpConfigurations[0].LoadBalancerInboundNatRules.Add($lb.InboundNatRules[0]);
        $nic2.IpConfigurations[0].LoadBalancerBackendAddressPools.Add($lb.BackendAddressPools[0]);
        $nic3.IpConfigurations[0].LoadBalancerInboundNatRules.Add($lb.InboundNatRules[1]);

        # set the nics
        $nic1 = $nic1 | Set-AzNetworkInterface
        $nic2 = $nic2 | Set-AzNetworkInterface
        $nic3 = $nic3 | Set-AzNetworkInterface

        # Verify the Load balancer references
        $lb = Get-AzLoadBalancer -Name $lbName -ResourceGroupName $rgname

        Assert-AreEqual $nic1.IpConfigurations[0].Id $lb.InboundNatRules[0].BackendIPConfiguration.Id
        Assert-AreEqual $nic3.IpConfigurations[0].Id $lb.InboundNatRules[1].BackendIPConfiguration.Id
        Assert-AreEqual 2 @($lb.BackendAddressPools[0].BackendIpConfigurations).Count

        # Delete
        $deleteLb = Remove-AzLoadBalancer -Name $lbName -ResourceGroupName $rgname -PassThru -Force
        Assert-AreEqual true $deleteLb
        
        $list = Get-AzLoadBalancer -ResourceGroupName $rgname
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
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval" } 
        
        # Create the Virtual Network
        $subnet = New-AzVirtualNetworkSubnetConfig -Name $subnetName -AddressPrefix 10.0.1.0/24
        $vnet = New-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnet
        
        # Create the publicip
        $publicip = New-AzPublicIpAddress -ResourceGroupName $rgname -name $publicIpName -location $location -AllocationMethod Dynamic

        # Create LoadBalancer
        $frontend = New-AzLoadBalancerFrontendIpConfig -Name $frontendName -PublicIpAddress $publicip
        $backendAddressPool = New-AzLoadBalancerBackendAddressPoolConfig -Name $backendAddressPoolName
        $probe = New-AzLoadBalancerProbeConfig -Name $probeName -RequestPath healthcheck.aspx -Protocol http -Port 80 -IntervalInSeconds 15 -ProbeCount 2
        $inboundNatRule1 = New-AzLoadBalancerInboundNatRuleConfig -Name $inboundNatRuleName1 -FrontendIPConfiguration $frontend -Protocol Tcp -FrontendPort 3389 -BackendPort 3389 -IdleTimeoutInMinutes 15 -EnableFloatingIP
        $inboundNatRule2 = New-AzLoadBalancerInboundNatRuleConfig -Name $inboundNatRuleName2 -FrontendIPConfiguration $frontend -Protocol Tcp -FrontendPort 3391 -BackendPort 3392
        $lbrule = New-AzLoadBalancerRuleConfig -Name $lbruleName -FrontendIPConfiguration $frontend -BackendAddressPool $backendAddressPool -Probe $probe -Protocol Tcp -FrontendPort 80 -BackendPort 80 -IdleTimeoutInMinutes 15 -EnableFloatingIP -LoadDistribution SourceIP
        $lb = New-AzLoadBalancer -Name $lbName -ResourceGroupName $rgname -Location $location -FrontendIpConfiguration $frontend -BackendAddressPool $backendAddressPool -Probe $probe -InboundNatRule $inboundNatRule1,$inboundNatRule2 -LoadBalancingRule $lbrule
        
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
        $nic1 = New-AzNetworkInterface -Name $nicname1 -ResourceGroupName $rgname -Location $location -Subnet $vnet.Subnets[0] -LoadBalancerBackendAddressPool $lb.BackendAddressPools[0] -LoadBalancerInboundNatRule $lb.InboundNatRules[0]
        $nic2 = New-AzNetworkInterface -Name $nicname2 -ResourceGroupName $rgname -Location $location -SubnetId $vnet.Subnets[0].Id -LoadBalancerBackendAddressPoolId $lb.BackendAddressPools[0].Id
        $nic3 = New-AzNetworkInterface -Name $nicname3 -ResourceGroupName $rgname -Location $location -SubnetId $vnet.Subnets[0].Id -LoadBalancerInboundNatRuleId $lb.InboundNatRules[1].Id

        # set the nics
        $nic1 = $nic1 | Set-AzNetworkInterface
        $nic2 = $nic2 | Set-AzNetworkInterface
        $nic3 = $nic3 | Set-AzNetworkInterface

        # Verify the Load balancer references
        $lb = Get-AzLoadBalancer -Name $lbName -ResourceGroupName $rgname

        Assert-AreEqual $nic1.IpConfigurations[0].Id $lb.InboundNatRules[0].BackendIPConfiguration.Id
        Assert-AreEqual $nic3.IpConfigurations[0].Id $lb.InboundNatRules[1].BackendIPConfiguration.Id
        Assert-AreEqual 2 @($lb.BackendAddressPools[0].BackendIpConfigurations).Count

        # Delete
        $deleteLb = Remove-AzLoadBalancer -Name $lbName -ResourceGroupName $rgname -PassThru -Force
        Assert-AreEqual true $deleteLb
        
        $list = Get-AzLoadBalancer -ResourceGroupName $rgname
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
    $rglocation = Get-ProviderLocation ResourceManagement "West US"
    $location = Get-ProviderLocation "Microsoft.Network/loadBalancers" "West US"
    
    try 
    {
        # Create the resource group
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval" } 
        
        # Create the Virtual Network
        $subnet = New-AzVirtualNetworkSubnetConfig -Name $subnetName -AddressPrefix 10.0.1.0/24
        $vnet = New-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnet
        
        # Create the publicip
        $publicip = New-AzPublicIpAddress -ResourceGroupName $rgname -name $publicIpName -location $location -AllocationMethod Dynamic -DomainNameLabel $domainNameLabel

        $frontend = New-AzLoadBalancerFrontendIpConfig -Name $frontendName -SubnetId $vnet.Subnets[0].Id
        New-AzLoadBalancer -Name $lbName -ResourceGroupName $rgname -Location $location -FrontendIpConfiguration $frontend 
        
        $lb = Get-AzLoadBalancer -Name $lbName -ResourceGroupName $rgname

        # Test InboundNatPool cmdlets
        $inboundNatPoolName = Get-ResourceName
        $lb = Get-AzLoadBalancer -Name $lbName -ResourceGroupName $rgname 
        $lb = $lb | Add-AzLoadBalancerInboundNatPoolConfig -Name $inboundNatPoolName -FrontendIPConfigurationId $lb.FrontendIPConfigurations[0].Id -Protocol Tcp -FrontendPortRangeStart 3360 -FrontendPortRangeEnd 3362 -BackendPort 3370 | Set-AzLoadBalancer

        Assert-AreEqual 1 @($lb.InboundNatPools).Count
        Assert-AreEqual $inboundNatPoolName $lb.InboundNatPools[0].Name
        Assert-AreEqual 3360 $lb.InboundNatPools[0].FrontendPortRangeStart
        Assert-AreEqual 3362 $lb.InboundNatPools[0].FrontendPortRangeEnd
        Assert-AreEqual 3370 $lb.InboundNatPools[0].BackendPort
        Assert-AreEqual Tcp $lb.InboundNatPools[0].Protocol

        $inboundNatPoolName2 = Get-ResourceName
        $lb = Get-AzLoadBalancer -Name $lbName -ResourceGroupName $rgname | Add-AzLoadBalancerInboundNatPoolConfig -Name $inboundNatPoolName2 -FrontendIPConfigurationId $lb.FrontendIPConfigurations[0].Id -Protocol Udp -FrontendPortRangeStart 3366 -FrontendPortRangeEnd 3368 -BackendPort 3376 | Set-AzLoadBalancer
        
        Assert-AreEqual 2 @($lb.InboundNatPools).Count
        Assert-AreEqual $inboundNatPoolName2 $lb.InboundNatPools[1].Name
        Assert-AreEqual 3366 $lb.InboundNatPools[1].FrontendPortRangeStart
        Assert-AreEqual 3368 $lb.InboundNatPools[1].FrontendPortRangeEnd
        Assert-AreEqual 3376 $lb.InboundNatPools[1].BackendPort
        Assert-AreEqual Udp $lb.InboundNatPools[1].Protocol

        $lb = Get-AzLoadBalancer -Name $lbName -ResourceGroupName $rgname | Set-AzLoadBalancerInboundNatPoolConfig -Name $inboundNatPoolName2 -FrontendIPConfigurationId $lb.FrontendIPConfigurations[0].Id -Protocol Tcp -FrontendPortRangeStart 3363 -FrontendPortRangeEnd 3364 -BackendPort 3373 | Set-AzLoadBalancer
        Assert-AreEqual 2 @($lb.InboundNatPools).Count
        Assert-AreEqual $inboundNatPoolName2 $lb.InboundNatPools[1].Name
        Assert-AreEqual 3363 $lb.InboundNatPools[1].FrontendPortRangeStart
        Assert-AreEqual 3364 $lb.InboundNatPools[1].FrontendPortRangeEnd
        Assert-AreEqual 3373 $lb.InboundNatPools[1].BackendPort
        Assert-AreEqual Tcp $lb.InboundNatPools[1].Protocol


        $inboundNatPoolConfig = Get-AzLoadBalancer -Name $lbName -ResourceGroupName $rgname | Get-AzLoadBalancerInboundNatPoolConfig -Name $inboundNatPoolName2
        $inboundNatPoolConfigList = Get-AzLoadBalancer -Name $lbName -ResourceGroupName $rgname | Get-AzLoadBalancerInboundNatPoolConfig
        Assert-AreEqual 2 @($inboundNatPoolConfigList).Count
        Assert-AreEqual $inboundNatPoolName $inboundNatPoolConfigList[0].Name
        Assert-AreEqual $inboundNatPoolName2 $inboundNatPoolConfigList[1].Name
        Assert-AreEqual $inboundNatPoolConfig.Name $inboundNatPoolConfigList[1].Name

        $lb =  Get-AzLoadBalancer -Name $lbName -ResourceGroupName $rgname | Remove-AzLoadBalancerInboundNatPoolConfig -Name $inboundNatPoolName2 | Set-AzLoadBalancer
        Assert-AreEqual 1 @($lb.InboundNatPools).Count
        Assert-AreEqual $inboundNatPoolName $lb.InboundNatPools[0].Name

        # Delete
        $deleteLb = $lb | Remove-AzLoadBalancer -PassThru -Force
        Assert-AreEqual true $deleteLb
        
        $list = Get-AzLoadBalancer -ResourceGroupName $rgname
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
    $rglocation = Get-ProviderLocation ResourceManagement "West US"
    $location = Get-ProviderLocation "Microsoft.Network/loadBalancers" "West US"
    
    try 
    {
        # Create the resource group
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval" } 
        
        # Create the publicip
        $publicip = New-AzPublicIpAddress -ResourceGroupName $rgname -name $publicIpName -location $location -AllocationMethod Dynamic -DomainNameLabel $domainNameLabel

        # Create LoadBalancer with one Inbound NAT Pool
        $frontend = New-AzLoadBalancerFrontendIpConfig -Name $frontendName -PublicIpAddress $publicip
        $inboundNatPool = New-AzLoadBalancerInboundNatPoolConfig -Name $inboundNatPoolName -FrontendIPConfigurationId $frontend.Id -Protocol Tcp -FrontendPortRangeStart 3360 -FrontendPortRangeEnd 3362 -BackendPort 3370 
        $actualLb = New-AzLoadBalancer -Name $lbName -ResourceGroupName $rgname -Location $location -FrontendIpConfiguration $frontend -InboundNatPool $inboundNatPool
        
        $expectedLb = Get-AzLoadBalancer -Name $lbName -ResourceGroupName $rgname

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
        $lb = Get-AzLoadBalancer -Name $lbName -ResourceGroupName $rgname 
        $lb = Add-AzLoadBalancerInboundNatPoolConfig -LoadBalancer $lb -Name $inboundNatPoolName2 -FrontendIPConfiguration $lb.FrontendIPConfigurations[0] -Protocol Udp -FrontendPortRangeStart 3366 -FrontendPortRangeEnd 3368 -BackendPort 3376 | Set-AzLoadBalancer
        
        Assert-AreEqual 2 @($lb.InboundNatPools).Count
        Assert-AreEqual $inboundNatPoolName2 $lb.InboundNatPools[1].Name
        Assert-AreEqual 3366 $lb.InboundNatPools[1].FrontendPortRangeStart
        Assert-AreEqual 3368 $lb.InboundNatPools[1].FrontendPortRangeEnd
        Assert-AreEqual 3376 $lb.InboundNatPools[1].BackendPort
        Assert-AreEqual Udp $lb.InboundNatPools[1].Protocol

        $lb = Get-AzLoadBalancer -Name $lbName -ResourceGroupName $rgname | Set-AzLoadBalancerInboundNatPoolConfig -Name $inboundNatPoolName2 -FrontendIPConfigurationId $lb.FrontendIPConfigurations[0].Id -Protocol Tcp -FrontendPortRangeStart 3363 -FrontendPortRangeEnd 3364 -BackendPort 3373 | Set-AzLoadBalancer
        Assert-AreEqual 2 @($lb.InboundNatPools).Count
        Assert-AreEqual $inboundNatPoolName2 $lb.InboundNatPools[1].Name
        Assert-AreEqual 3363 $lb.InboundNatPools[1].FrontendPortRangeStart
        Assert-AreEqual 3364 $lb.InboundNatPools[1].FrontendPortRangeEnd
        Assert-AreEqual 3373 $lb.InboundNatPools[1].BackendPort
        Assert-AreEqual Tcp $lb.InboundNatPools[1].Protocol

        $inboundNatPoolConfig = Get-AzLoadBalancer -Name $lbName -ResourceGroupName $rgname | Get-AzLoadBalancerInboundNatPoolConfig -Name $inboundNatPoolName2
        $inboundNatPoolConfigList = Get-AzLoadBalancer -Name $lbName -ResourceGroupName $rgname | Get-AzLoadBalancerInboundNatPoolConfig
        Assert-AreEqual 2 @($inboundNatPoolConfigList).Count
        Assert-AreEqual $inboundNatPoolName $inboundNatPoolConfigList[0].Name
        Assert-AreEqual $inboundNatPoolName2 $inboundNatPoolConfigList[1].Name
        Assert-AreEqual $inboundNatPoolConfig.Name $inboundNatPoolConfigList[1].Name

        $lb =  Get-AzLoadBalancer -Name $lbName -ResourceGroupName $rgname | Remove-AzLoadBalancerInboundNatPoolConfig -Name $inboundNatPoolName2 | Set-AzLoadBalancer
        Assert-AreEqual 1 @($lb.InboundNatPools).Count
        Assert-AreEqual $inboundNatPoolName $lb.InboundNatPools[0].Name

        # Delete LB
        $deleteLb = Remove-AzLoadBalancer -Name $lbName -ResourceGroupName $rgname -PassThru -Force
        Assert-AreEqual true $deleteLb
        
        $list = Get-AzLoadBalancer -ResourceGroupName $rgname
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
	$pip1Name = Get-ResourceName
	$pip2Name = Get-ResourceName
	$pip3Name = Get-ResourceName
    $lbName = Get-ResourceName
    $lb2Name = Get-ResourceName
    $frontend1Name = Get-ResourceName
	$frontend2Name = Get-ResourceName
	$frontend3Name = Get-ResourceName
	$frontend4Name = Get-ResourceName
	$pipFrontend1Name = Get-ResourceName
	$pipFrontend2Name = Get-ResourceName
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
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval" } 

        # Create the publicips
        $publicip1 = New-AzPublicIpAddress -ResourceGroupName $rgname -name $publicIp1Name -location $location -AllocationMethod Dynamic
		$publicip2 = New-AzPublicIpAddress -ResourceGroupName $rgname -name $publicIp2Name -location $location -AllocationMethod Dynamic
		$publicip3 = New-AzPublicIpAddress -ResourceGroupName $rgname -name $publicIp3Name -location $location -AllocationMethod Dynamic
		$publicip4 = New-AzPublicIpAddress -ResourceGroupName $rgname -name $publicIp4Name -location $location -AllocationMethod Dynamic

        # Create the public ip prefixes 
        $pip1 = New-AzPublicIpPrefix -ResourceGroupName $rgname -name $pip1Name -location $location -Sku Standard -PrefixLength 30 -IpAddressVersion IPv4 -IpTag $ipTag 
        $pip2 = New-AzPublicIpPrefix -ResourceGroupName $rgname -name $pip2Name -location $location -Sku Standard -PrefixLength 30 -IpAddressVersion IPv4 -IpTag $ipTag 
        $pip3 = New-AzPublicIpPrefix -ResourceGroupName $rgname -name $pip3Name -location $location -Sku Standard -PrefixLength 30 -IpAddressVersion IPv4 -IpTag $ipTag 

        # Create LoadBalancer
        $frontend1 = New-AzLoadBalancerFrontendIpConfig -Name $frontend1Name -PublicIpAddress $publicip1
		$frontend2 = New-AzLoadBalancerFrontendIpConfig -Name $frontend2Name -PublicIpAddressId $publicip2.Id

        $backendAddressPool = New-AzLoadBalancerBackendAddressPoolConfig -Name $backendAddressPoolName
        $probe = New-AzLoadBalancerProbeConfig -Name $probeName -RequestPath healthcheck.aspx -Protocol http -Port 80 -IntervalInSeconds 15 -ProbeCount 2
        $inboundNatRule = New-AzLoadBalancerInboundNatRuleConfig -Name $inboundNatRuleName -FrontendIPConfiguration $frontend1 -Protocol Tcp -FrontendPort 3389 -BackendPort 3389 -IdleTimeoutInMinutes 15 -EnableFloatingIP
        $lbrule = New-AzLoadBalancerRuleConfig -Name $lbruleName -FrontendIPConfiguration $frontend2 -BackendAddressPool $backendAddressPool -Probe $probe -Protocol Tcp -FrontendPort 80 -BackendPort 80 -IdleTimeoutInMinutes 15 -EnableFloatingIP -LoadDistribution SourceIP
        $lb = New-AzLoadBalancer -Name $lbName -ResourceGroupName $rgname -Location $location -FrontendIpConfiguration $frontend1,$frontend2 -BackendAddressPool $backendAddressPool -Probe $probe -InboundNatRule $inboundNatRule -LoadBalancingRule $lbrule
        
        # Create standard load balancer
        $pipfrontend1 = New-AzLoadBalancerFrontendIpConfig -Name $pipFrontend1Name -PublicIpAddressPrefix $pip1

        $lb2 = New-AzLoadBalancer -Name $lb2Name -ResourceGroupName $rgname -Location $location -FrontendIpConfiguration $pipfrontend1 -Sku Standard
        
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
		$publicip1 = Get-AzPublicIpAddress -ResourceGroupName $rgname -name $publicIp1Name
        Assert-AreEqual $lb.FrontendIPConfigurations[0].Id $publicip1.IpConfiguration.Id

		$publicip2 = Get-AzPublicIpAddress -ResourceGroupName $rgname -name $publicIp2Name
        Assert-AreEqual $lb.FrontendIPConfigurations[1].Id $publicip2.IpConfiguration.Id

		# Add a new frontendip config
		$lb = Get-AzLoadBalancer -Name $lbName -ResourceGroupName $rgname | Add-AzLoadBalancerFrontendIpConfig -Name $frontend3Name -PublicIpAddress $publicip3 | Set-AzLoadBalancer
		Assert-AreEqual 3 @($lb.FrontendIPConfigurations).Count

		Assert-AreEqual $frontend3Name $lb.FrontendIPConfigurations[2].Name
        Assert-AreEqual $publicip3.Id $lb.FrontendIPConfigurations[2].PublicIpAddress.Id
		Assert-Null $lb.FrontendIPConfigurations[2].Subnet
		
		$publicip3 = Get-AzPublicIpAddress -ResourceGroupName $rgname -name $publicIp3Name
        Assert-AreEqual $lb.FrontendIPConfigurations[2].Id $publicip3.IpConfiguration.Id

		# Set a new frontendip config
		$lb = Get-AzLoadBalancer -Name $lbName -ResourceGroupName $rgname | Set-AzLoadBalancerFrontendIpConfig -Name $frontend3Name -PublicIpAddress $publicip4 | Set-AzLoadBalancer
		Assert-AreEqual 3 @($lb.FrontendIPConfigurations).Count

		Assert-AreEqual $frontend3Name $lb.FrontendIPConfigurations[2].Name
        Assert-AreEqual $publicip4.Id $lb.FrontendIPConfigurations[2].PublicIpAddress.Id
		Assert-Null $lb.FrontendIPConfigurations[2].Subnet

		$publicip3 = Get-AzPublicIpAddress -ResourceGroupName $rgname -name $publicIp3Name
        Assert-Null $publicip3.IpConfiguration

		$publicip4 = Get-AzPublicIpAddress -ResourceGroupName $rgname -name $publicIp4Name
        Assert-AreEqual $lb.FrontendIPConfigurations[2].Id $publicip4.IpConfiguration.Id

		# Get a frontendip config
		$frontendip = Get-AzLoadBalancer -Name $lbName -ResourceGroupName $rgname | Get-AzLoadBalancerFrontendIpConfig -Name $frontend3Name

		Assert-AreEqual $frontend3Name $frontendip.Name
        Assert-AreEqual $publicip4.Id $frontendip.PublicIpAddress.Id
		Assert-Null $frontendip.Subnet

		# list all frontendip configs
		$frontendips = Get-AzLoadBalancer -Name $lbName -ResourceGroupName $rgname | Get-AzLoadBalancerFrontendIpConfig

		Assert-AreEqual 3 @($frontendips).Count

		# Remove a frontendip config
		$lb = Get-AzLoadBalancer -Name $lbName -ResourceGroupName $rgname | Remove-AzLoadBalancerFrontendIpConfig -Name $frontend3Name | Set-AzLoadBalancer
		Assert-AreEqual 2 @($lb.FrontendIPConfigurations).Count

		Assert-AreEqual $frontend1Name $lb.FrontendIPConfigurations[0].Name
        Assert-AreEqual $publicip1.Id $lb.FrontendIPConfigurations[0].PublicIpAddress.Id
		Assert-Null $lb.FrontendIPConfigurations[0].Subnet
		
		Assert-AreEqual $frontend2Name $lb.FrontendIPConfigurations[1].Name
        Assert-AreEqual $publicip2.Id $lb.FrontendIPConfigurations[1].PublicIpAddress.Id
		Assert-Null $lb.FrontendIPConfigurations[1].Subnet

        # Delete
        $deleteLb = Remove-AzLoadBalancer -Name $lbName -ResourceGroupName $rgname -PassThru -Force
        Assert-AreEqual true $deleteLb
        
		$list = Get-AzLoadBalancer -ResourceGroupName $rgname
        Assert-AreEqual 1 @($list).Count

		# Verify public ip reference
		$publicip1 = Get-AzPublicIpAddress -ResourceGroupName $rgname -name $publicIp1Name
        Assert-Null $publicip1.IpConfiguration

		$publicip2 = Get-AzPublicIpAddress -ResourceGroupName $rgname -name $publicIp2Name
        Assert-Null $publicip2.IpConfiguration
        
        # Add a new frontendip config
		$lb2 = Get-AzLoadBalancer -Name $lb2Name -ResourceGroupName $rgname | Add-AzLoadBalancerFrontendIpConfig -Name $pipFrontend2Name -PublicIpAddressPrefix $pip2 | Set-AzLoadBalancer
		Assert-AreEqual 2 @($lb2.FrontendIPConfigurations).Count

		Assert-AreEqual $pipFrontend2Name $lb2.FrontendIPConfigurations[1].Name
        Assert-AreEqual $pip2.Id $lb2.FrontendIPConfigurations[1].PublicIPPrefix.Id
		Assert-Null $lb2.FrontendIPConfigurations[1].Subnet	

		# Set a new frontendip config
		$lb3 = Get-AzLoadBalancer -Name $lb2Name -ResourceGroupName $rgname
        $lb3 = Get-AzPublicIpPrefix -ResourceGroupName $rgname -name $pip3Name | Set-AzLoadBalancerFrontendIpConfig -LoadBalancer $lb3 -Name $pipFrontend2Name
        Set-AzLoadBalancer -LoadBalancer $lb3
        Assert-AreEqual 2 @($lb3.FrontendIPConfigurations).Count
        
		Assert-AreEqual $pipFrontend2Name $lb3.FrontendIPConfigurations[1].Name
        Assert-AreEqual $pip3.Id $lb3.FrontendIPConfigurations[1].PublicIPPrefix.Id
		Assert-Null $lb3.FrontendIPConfigurations[1].Subnet

        # Delete
        $deleteLb = Remove-AzLoadBalancer -Name $lb2Name -ResourceGroupName $rgname -PassThru -Force
        Assert-AreEqual true $deleteLb
        
		$list = Get-AzLoadBalancer -ResourceGroupName $rgname
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
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $rglocation

        # Create the Virtual Network
        $subnet1 = New-AzVirtualNetworkSubnetConfig -Name $subnet1Name -AddressPrefix 10.0.0.0/24
		$subnet2 = New-AzVirtualNetworkSubnetConfig -Name $subnet2Name -AddressPrefix 10.0.1.0/24
        $vnet = New-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnet1,$subnet2

        # Create LoadBalancer
        $frontend1 = New-AzLoadBalancerFrontendIpConfig -Name $frontend1Name -Subnet $vnet.Subnets[0]
		$frontend2 = New-AzLoadBalancerFrontendIpConfig -Name $frontend2Name -SubnetId $vnet.Subnets[1].Id

        $backendAddressPool = New-AzLoadBalancerBackendAddressPoolConfig -Name $backendAddressPoolName
        $probe = New-AzLoadBalancerProbeConfig -Name $probeName -RequestPath healthcheck.aspx -Protocol http -Port 80 -IntervalInSeconds 15 -ProbeCount 2
        $inboundNatRule = New-AzLoadBalancerInboundNatRuleConfig -Name $inboundNatRuleName -FrontendIPConfiguration $frontend1 -Protocol Tcp -FrontendPort 3389 -BackendPort 3389 -IdleTimeoutInMinutes 15 -EnableFloatingIP
        $lbrule = New-AzLoadBalancerRuleConfig -Name $lbruleName -FrontendIPConfiguration $frontend2 -BackendAddressPool $backendAddressPool -Probe $probe -Protocol Tcp -FrontendPort 80 -BackendPort 80 -IdleTimeoutInMinutes 15 -EnableFloatingIP -LoadDistribution SourceIP
        $lb = New-AzLoadBalancer -Name $lbName -ResourceGroupName $rgname -Location $location -FrontendIpConfiguration $frontend1,$frontend2  -BackendAddressPool $backendAddressPool -Probe $probe -InboundNatRule $inboundNatRule -LoadBalancingRule $lbrule
        
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
		$vnet = Get-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname
		Assert-AreEqual 1 @($vnet.Subnets[0].IpConfigurations).Count
        Assert-AreEqual $lb.FrontendIPConfigurations[0].Id $vnet.Subnets[0].IpConfigurations[0].Id
		Assert-AreEqual 1 @($vnet.Subnets[1].IpConfigurations).Count
		Assert-AreEqual $lb.FrontendIPConfigurations[1].Id $vnet.Subnets[1].IpConfigurations[0].Id

		# Add a new frontendip config
		$lb = Get-AzLoadBalancer -Name $lbName -ResourceGroupName $rgname | Add-AzLoadBalancerFrontendIpConfig -Name $frontend3Name -Subnet $vnet.Subnets[1] | Set-AzLoadBalancer
		Assert-AreEqual 3 @($lb.FrontendIPConfigurations).Count
		
		Assert-AreEqual $frontend3Name $lb.FrontendIPConfigurations[2].Name
		Assert-AreEqual $vnet.Subnets[1].Id $lb.FrontendIPConfigurations[2].Subnet.Id
		Assert-Null $lb.FrontendIPConfigurations[2].PublicIpAddress

		# Verify subnet reference
		$vnet = Get-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname
		Assert-AreEqual 1 @($vnet.Subnets[0].IpConfigurations).Count
        Assert-AreEqual $lb.FrontendIPConfigurations[0].Id $vnet.Subnets[0].IpConfigurations[0].Id
		Assert-AreEqual 2 @($vnet.Subnets[1].IpConfigurations).Count
		Assert-AreEqual $lb.FrontendIPConfigurations[1].Id $vnet.Subnets[1].IpConfigurations[0].Id
		Assert-AreEqual $lb.FrontendIPConfigurations[2].Id $vnet.Subnets[1].IpConfigurations[1].Id

		# set a new frontendip config
		$lb = Get-AzLoadBalancer -Name $lbName -ResourceGroupName $rgname | Set-AzLoadBalancerFrontendIpConfig -Name $frontend3Name -SubnetId $vnet.Subnets[0].Id | Set-AzLoadBalancer
		
		Assert-AreEqual 3 @($lb.FrontendIPConfigurations).Count
		
		Assert-AreEqual $frontend3Name $lb.FrontendIPConfigurations[2].Name
		Assert-AreEqual $vnet.Subnets[0].Id $lb.FrontendIPConfigurations[2].Subnet.Id
		Assert-Null $lb.FrontendIPConfigurations[2].PublicIpAddress
		
		# Verify subnet reference
		$vnet = Get-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname
		Assert-AreEqual 2 @($vnet.Subnets[0].IpConfigurations).Count
        Assert-AreEqual $lb.FrontendIPConfigurations[0].Id $vnet.Subnets[0].IpConfigurations[0].Id
		Assert-AreEqual $lb.FrontendIPConfigurations[2].Id $vnet.Subnets[0].IpConfigurations[1].Id
		Assert-AreEqual 1 @($vnet.Subnets[1].IpConfigurations).Count
		Assert-AreEqual $lb.FrontendIPConfigurations[1].Id $vnet.Subnets[1].IpConfigurations[0].Id
		
		# Get a frontendip config
		$frontendip = Get-AzLoadBalancer -Name $lbName -ResourceGroupName $rgname | Get-AzLoadBalancerFrontendIpConfig -Name $frontend3Name
		
		Assert-AreEqual $frontend3Name $frontendip.Name
		Assert-AreEqual $vnet.Subnets[0].Id $frontendip.Subnet.Id
		Assert-Null $frontendip.PublicIpAddress
		
		# list all frontendip configs
		$frontendips = Get-AzLoadBalancer -Name $lbName -ResourceGroupName $rgname | Get-AzLoadBalancerFrontendIpConfig
		
		Assert-AreEqual 3 @($frontendips).Count
		
		# Remove a frontendip config
		$lb = Get-AzLoadBalancer -Name $lbName -ResourceGroupName $rgname | Remove-AzLoadBalancerFrontendIpConfig -Name $frontend3Name | Set-AzLoadBalancer
		Assert-AreEqual 2 @($lb.FrontendIPConfigurations).Count
		
		Assert-AreEqual $frontend1Name $lb.FrontendIPConfigurations[0].Name
        Assert-AreEqual $vnet.Subnets[0].Id $lb.FrontendIPConfigurations[0].Subnet.Id
		Assert-Null $lb.FrontendIPConfigurations[0].PublicIpAddress
		
		Assert-AreEqual $frontend2Name $lb.FrontendIPConfigurations[1].Name
		Assert-AreEqual $vnet.Subnets[1].Id $lb.FrontendIPConfigurations[1].Subnet.Id
		Assert-Null $lb.FrontendIPConfigurations[1].PublicIpAddress

        # Delete
        $deleteLb = Remove-AzLoadBalancer -Name $lbName -ResourceGroupName $rgname -PassThru -Force
        Assert-AreEqual true $deleteLb
        
		$list = Get-AzLoadBalancer -ResourceGroupName $rgname
        Assert-AreEqual 0 @($list).Count

		# Verify subnet references
		$vnet = Get-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname
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
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval" } 
        
        # Create the publicip
        $publicip = New-AzPublicIpAddress -ResourceGroupName $rgname -name $publicIpName -location $location -AllocationMethod Dynamic -DomainNameLabel $domainNameLabel

        # Create LoadBalancer
        $frontend = New-AzLoadBalancerFrontendIpConfig -Name $frontendName -PublicIpAddress $publicip
        $backendAddressPool = New-AzLoadBalancerBackendAddressPoolConfig -Name $backendAddressPoolName
        $probe = New-AzLoadBalancerProbeConfig -Name $probeName -RequestPath healthcheck.aspx -Protocol http -Port 80 -IntervalInSeconds 15 -ProbeCount 2
        $inboundNatRule = New-AzLoadBalancerInboundNatRuleConfig -Name $inboundNatRuleName -FrontendIPConfiguration $frontend -Protocol Tcp -FrontendPort 3389 -BackendPort 3389 -IdleTimeoutInMinutes 15 -EnableFloatingIP
        $lbrule = New-AzLoadBalancerRuleConfig -Name $lbruleName -FrontendIPConfiguration $frontend -BackendAddressPool $backendAddressPool -Protocol Tcp -FrontendPort 80 -BackendPort 80 -IdleTimeoutInMinutes 15 -EnableFloatingIP -LoadDistribution SourceIP
        $lb = New-AzLoadBalancer -Name $lbName -ResourceGroupName $rgname -Location $location -FrontendIpConfiguration $frontend -BackendAddressPool $backendAddressPool -Probe $probe -InboundNatRule $inboundNatRule -LoadBalancingRule $lbrule
  
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
		$lb = $lb | Set-AzLoadBalancer

		Assert-NotNull $lb.LoadBalancingRules[0].Probe
		Assert-AreEqual $lb.LoadBalancingRules[0].Probe.Id $lb.Probes[0].Id

        # Delete
        $deleteLb = Remove-AzLoadBalancer -Name $lbName -ResourceGroupName $rgname -PassThru -Force
        Assert-AreEqual true $deleteLb
        
        $list = Get-AzLoadBalancer -ResourceGroupName $rgname
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
Tests creating a public Load balancer with basic sku.
#>
function Test-LoadBalancerCRUD-PublicBasicSku
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
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval"} 
        
        # Create the Virtual Network
        $subnet = New-AzVirtualNetworkSubnetConfig -Name $subnetName -AddressPrefix 10.0.1.0/24
        $vnet = New-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnet
        
        # Create the publicip
        $publicip = New-AzPublicIpAddress -ResourceGroupName $rgname -name $publicIpName -location $location -AllocationMethod Dynamic -DomainNameLabel $domainNameLabel

        # Create LoadBalancer
        $frontend = New-AzLoadBalancerFrontendIpConfig -Name $frontendName -PublicIpAddress $publicip
        $backendAddressPool = New-AzLoadBalancerBackendAddressPoolConfig -Name $backendAddressPoolName
        $probe = New-AzLoadBalancerProbeConfig -Name $probeName -RequestPath healthcheck.aspx -Protocol http -Port 80 -IntervalInSeconds 15 -ProbeCount 2
        $inboundNatRule = New-AzLoadBalancerInboundNatRuleConfig -Name $inboundNatRuleName -FrontendIPConfiguration $frontend -Protocol Tcp -FrontendPort 3389 -BackendPort 3389 -IdleTimeoutInMinutes 15 -EnableFloatingIP
        $lbrule = New-AzLoadBalancerRuleConfig -Name $lbruleName -FrontendIPConfiguration $frontend -BackendAddressPool $backendAddressPool -Probe $probe -Protocol Tcp -FrontendPort 80 -BackendPort 80 -IdleTimeoutInMinutes 15 -EnableFloatingIP -LoadDistribution SourceIP
        $actualLb = New-AzLoadBalancer -Name $lbName -ResourceGroupName $rgname -Location $location -FrontendIpConfiguration $frontend -BackendAddressPool $backendAddressPool -Probe $probe -InboundNatRule $inboundNatRule -LoadBalancingRule $lbrule 
        
        $expectedLb = Get-AzLoadBalancer -Name $lbName -ResourceGroupName $rgname

        # Verification
        Assert-AreEqual $expectedLb.ResourceGroupName $actualLb.ResourceGroupName
        Assert-AreEqual $expectedLb.Name $actualLb.Name
        Assert-AreEqual $expectedLb.Location $actualLb.Location
        Assert-AreEqualObjectProperties $expectedLb.Sku $actualLb.Sku
        Assert-AreEqualObjectProperties "Basic" $actualLb.Sku.Name
        Assert-AreEqualObjectProperties "Regional" $actualLb.Sku.Tier
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
        $list = Get-AzLoadBalancer -ResourceGroupName $rgname
        Assert-AreEqual 1 @($list).Count
        Assert-AreEqual $expectedLb.Etag $list[0].Etag
        Assert-AreEqualObjectProperties $expectedLb.Sku $list[0].Sku
        Assert-AreEqual $expectedLb.FrontendIPConfigurations[0].Etag $list[0].FrontendIPConfigurations[0].Etag
        Assert-AreEqual $expectedLb.BackendAddressPools[0].Etag $list[0].BackendAddressPools[0].Etag
        Assert-AreEqual $expectedLb.InboundNatRules[0].Etag $list[0].InboundNatRules[0].Etag
        Assert-AreEqual $expectedLb.Probes[0].Etag $list[0].Probes[0].Etag
        Assert-AreEqual $expectedLb.LoadBalancingRules[0].Etag $list[0].LoadBalancingRules[0].Etag

        # Delete
        $deleteLb = Remove-AzLoadBalancer -Name $lbName -ResourceGroupName $rgname -PassThru -Force
        Assert-AreEqual true $deleteLb
        
        $list = Get-AzLoadBalancer -ResourceGroupName $rgname
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
Tests creating an internal Load balancer with basic sku.
#>
function Test-LoadBalancerCRUD-InternalBasicSku
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
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval"} 
        
        # Create the Virtual Network
        $subnet = New-AzVirtualNetworkSubnetConfig -Name $subnetName -AddressPrefix 10.0.1.0/24
        $vnet = New-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnet
        
        # Create the publicip
        $publicip = New-AzPublicIpAddress -ResourceGroupName $rgname -name $publicIpName -location $location -AllocationMethod Dynamic -DomainNameLabel $domainNameLabel

        # Create LoadBalancer
        $frontend = New-AzLoadBalancerFrontendIpConfig -Name $frontendName -Subnet $vnet.Subnets[0]
        $backendAddressPool = New-AzLoadBalancerBackendAddressPoolConfig -Name $backendAddressPoolName
        $probe = New-AzLoadBalancerProbeConfig -Name $probeName -RequestPath healthcheck.aspx -Protocol http -Port 80 -IntervalInSeconds 15 -ProbeCount 2
        $inboundNatRule = New-AzLoadBalancerInboundNatRuleConfig -Name $inboundNatRuleName -FrontendIPConfiguration $frontend -Protocol Tcp -FrontendPort 3389 -BackendPort 3389 -IdleTimeoutInMinutes 15 -EnableFloatingIP
        $lbrule = New-AzLoadBalancerRuleConfig -Name $lbruleName -FrontendIPConfiguration $frontend -BackendAddressPool $backendAddressPool -Probe $probe -Protocol Tcp -FrontendPort 80 -BackendPort 80 -IdleTimeoutInMinutes 15 -EnableFloatingIP -LoadDistribution SourceIP
        $actualLb = New-AzLoadBalancer -Name $lbName -ResourceGroupName $rgname -Location $location -FrontendIpConfiguration $frontend -BackendAddressPool $backendAddressPool -Probe $probe -InboundNatRule $inboundNatRule -LoadBalancingRule $lbrule -Sku Basic
        
        $expectedLb = Get-AzLoadBalancer -Name $lbName -ResourceGroupName $rgname

        # Verification
        Assert-AreEqual $expectedLb.ResourceGroupName $actualLb.ResourceGroupName
        Assert-AreEqual $expectedLb.Name $actualLb.Name
        Assert-AreEqual $expectedLb.Location $actualLb.Location
        Assert-AreEqualObjectProperties $expectedLb.Sku $actualLb.Sku
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
        $list = Get-AzLoadBalancer -ResourceGroupName $rgname
        Assert-AreEqual 1 @($list).Count
        Assert-AreEqual $expectedLb.Etag $list[0].Etag
        Assert-AreEqualObjectProperties $expectedLb.Sku $list[0].Sku
        Assert-AreEqual $expectedLb.FrontendIPConfigurations[0].Etag $list[0].FrontendIPConfigurations[0].Etag
        Assert-AreEqual $expectedLb.BackendAddressPools[0].Etag $list[0].BackendAddressPools[0].Etag
        Assert-AreEqual $expectedLb.InboundNatRules[0].Etag $list[0].InboundNatRules[0].Etag
        Assert-AreEqual $expectedLb.Probes[0].Etag $list[0].Probes[0].Etag
        Assert-AreEqual $expectedLb.LoadBalancingRules[0].Etag $list[0].LoadBalancingRules[0].Etag

        # Delete
        $deleteLb = Remove-AzLoadBalancer -Name $lbName -ResourceGroupName $rgname -PassThru -Force
        Assert-AreEqual true $deleteLb
        
        $list = Get-AzLoadBalancer -ResourceGroupName $rgname
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
Tests Gateway LoadBalancer Provider with one pool.
#>
function Test-GatewayLoadBalancer-ProviderOnePool
{
    # Setup
    $rgname = Get-ResourceGroupName
    $vnetName = Get-ResourceName
    $subnetName = Get-ResourceName
    $lbName = Get-ResourceName
    $frontendName = Get-ResourceName
    $backendAddressPoolName = Get-ResourceName
    $probeName = Get-ResourceName
    $lbruleName = Get-ResourceName
    $rglocation = "eastus2euap"
    $resourceTypeParent = "Microsoft.Network/loadBalancers"
    $location = "eastus2euap"

    try 
    {
        # Create the resource group
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval"} 

        # Create the Virtual Network
        $subnet = New-AzVirtualNetworkSubnetConfig -Name $subnetName -AddressPrefix 172.20.0.0/24
        $vnet = New-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 172.20.0.0/16 -Subnet $subnet

        # Create LoadBalancer
        $frontend = New-AzLoadBalancerFrontendIpConfig -Name $frontendName -Subnet $vnet.Subnets[0]
        $tunnelInterface1 = New-AzLoadBalancerBackendAddressPoolTunnelInterfaceConfig -Protocol Vxlan -Type Internal -Port 2000 -Identifier 800
        $tunnelInterface2 = New-AzLoadBalancerBackendAddressPoolTunnelInterfaceConfig -Protocol Vxlan -Type External -Port 2001 -Identifier 801
        $backendAddressPool = New-AzLoadBalancerBackendAddressPoolConfig -Name $backendAddressPoolName -TunnelInterface $tunnelInterface1, $tunnelInterface2
        $probe = New-AzLoadBalancerProbeConfig -Name $probeName -RequestPath healthcheck.aspx -Protocol http -Port 80 -IntervalInSeconds 15 -ProbeCount 2
        $lbrule = New-AzLoadBalancerRuleConfig -Name $lbruleName -FrontendIPConfiguration $frontend -BackendAddressPool $backendAddressPool -Probe $probe -Protocol All -FrontendPort 0 -BackendPort 0 -LoadDistribution SourceIP -DisableOutboundSNAT
        $actualLb = New-AzLoadBalancer -Name $lbName -ResourceGroupName $rgname -Location $location -FrontendIpConfiguration $frontend -BackendAddressPool $backendAddressPool -Probe $probe -LoadBalancingRule $lbrule -Sku Gateway

        $expectedLb = Get-AzLoadBalancer -Name $lbName -ResourceGroupName $rgname

        # Verification
        Assert-AreEqual $expectedLb.ResourceGroupName $actualLb.ResourceGroupName
        Assert-AreEqual $expectedLb.Name $actualLb.Name
        Assert-AreEqual $expectedLb.Location $actualLb.Location
        Assert-AreEqualObjectProperties $expectedLb.Sku $actualLb.Sku
        Assert-AreEqual "Succeeded" $expectedLb.ProvisioningState
        Assert-AreEqual 1 @($expectedLb.FrontendIPConfigurations).Count

        Assert-AreEqual $frontendName $expectedLb.FrontendIPConfigurations[0].Name
        Assert-AreEqual $vnet.Subnets[0].Id $expectedLb.FrontendIPConfigurations[0].Subnet.Id
        Assert-NotNull $expectedLb.FrontendIPConfigurations[0].PrivateIpAddress

        Assert-AreEqual $backendAddressPoolName $expectedLb.BackendAddressPools[0].Name

        Assert-AreEqual 1 @($expectedLb.BackendAddressPools).Count
        Assert-AreEqual 2 @($expectedLb.BackendAddressPools[0].TunnelInterfaces).Count

        Assert-AreEqual $tunnelInterface1.Protocol $expectedLb.BackendAddressPools[0].TunnelInterfaces[0].Protocol
        Assert-AreEqual $tunnelInterface1.Type $expectedLb.BackendAddressPools[0].TunnelInterfaces[0].Type
        Assert-AreEqual $tunnelInterface1.Port $expectedLb.BackendAddressPools[0].TunnelInterfaces[0].Port
        Assert-AreEqual $tunnelInterface1.Identifier $expectedLb.BackendAddressPools[0].TunnelInterfaces[0].Identifier

        Assert-AreEqual $tunnelInterface2.Protocol $expectedLb.BackendAddressPools[0].TunnelInterfaces[1].Protocol
        Assert-AreEqual $tunnelInterface2.Type $expectedLb.BackendAddressPools[0].TunnelInterfaces[1].Type
        Assert-AreEqual $tunnelInterface2.Port $expectedLb.BackendAddressPools[0].TunnelInterfaces[1].Port
        Assert-AreEqual $tunnelInterface2.Identifier $expectedLb.BackendAddressPools[0].TunnelInterfaces[1].Identifier
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Tests Gateway LoadBalancer Provider with two pools.
#>
function Test-GatewayLoadBalancer-ProviderTwoPool
{
    # Setup
    $rgname = Get-ResourceGroupName
    $vnetName = Get-ResourceName
    $subnetName = Get-ResourceName
    $lbName = Get-ResourceName
    $frontendName = Get-ResourceName
    $backendAddressPoolName1 = Get-ResourceName
    $backendAddressPoolName2 = Get-ResourceName
    $probeName = Get-ResourceName
    $lbruleName = Get-ResourceName
    $rglocation = "eastus2euap"
    $resourceTypeParent = "Microsoft.Network/loadBalancers"
    $location = "eastus2euap"

    try 
    {
        # Create the resource group
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval"} 

        # Create the Virtual Network
        $subnet = New-AzVirtualNetworkSubnetConfig -Name $subnetName -AddressPrefix 172.20.0.0/24
        $vnet = New-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 172.20.0.0/16 -Subnet $subnet

        # Create LoadBalancer
        $frontend = New-AzLoadBalancerFrontendIpConfig -Name $frontendName -Subnet $vnet.Subnets[0]
        $tunnelInterface1 = New-AzLoadBalancerBackendAddressPoolTunnelInterfaceConfig  -Protocol Vxlan -Type Internal -Port 2000 -Identifier 800
        $tunnelInterface2 = New-AzLoadBalancerBackendAddressPoolTunnelInterfaceConfig  -Protocol Vxlan -Type External -Port 2001 -Identifier 801
        $backendAddressPool1 = New-AzLoadBalancerBackendAddressPoolConfig -Name $backendAddressPoolName1 -TunnelInterface $tunnelInterface1
        $backendAddressPool2 = New-AzLoadBalancerBackendAddressPoolConfig -Name $backendAddressPoolName2 -TunnelInterface $tunnelInterface2
        $probe = New-AzLoadBalancerProbeConfig -Name $probeName -RequestPath healthcheck.aspx -Protocol http -Port 80 -IntervalInSeconds 15 -ProbeCount 2
        $lbrule = New-AzLoadBalancerRuleConfig -Name $lbruleName -FrontendIPConfiguration $frontend -BackendAddressPool $backendAddressPool1,$backendAddressPool2 -Probe $probe -Protocol All -FrontendPort 0 -BackendPort 0 -LoadDistribution SourceIP -DisableOutboundSNAT

        $actualLb = New-AzLoadBalancer -Name $lbName -ResourceGroupName $rgname -Location $location -FrontendIpConfiguration $frontend -Probe $probe -LoadBalancingRule $lbrule -Sku Gateway -BackendAddressPool $backendAddressPool1,$backendAddressPool2

        $expectedLb = Get-AzLoadBalancer -Name $lbName -ResourceGroupName $rgname

        # Verification
        Assert-AreEqual $expectedLb.ResourceGroupName $actualLb.ResourceGroupName
        Assert-AreEqual $expectedLb.Name $actualLb.Name
        Assert-AreEqual $expectedLb.Location $actualLb.Location
        Assert-AreEqualObjectProperties $expectedLb.Sku $actualLb.Sku
        Assert-AreEqual "Succeeded" $expectedLb.ProvisioningState
        Assert-AreEqual 1 @($expectedLb.FrontendIPConfigurations).Count

        Assert-AreEqual $frontendName $expectedLb.FrontendIPConfigurations[0].Name
        Assert-AreEqual $vnet.Subnets[0].Id $expectedLb.FrontendIPConfigurations[0].Subnet.Id
        Assert-NotNull $expectedLb.FrontendIPConfigurations[0].PrivateIpAddress

        Assert-AreEqual 2 @($expectedLb.BackendAddressPools).Count
        Assert-AreEqual 1 @($expectedLb.BackendAddressPools[0].TunnelInterfaces).Count
        Assert-AreEqual $tunnelInterface1.Protocol $expectedLb.BackendAddressPools[0].TunnelInterfaces[0].Protocol
        Assert-AreEqual $tunnelInterface1.Type $expectedLb.BackendAddressPools[0].TunnelInterfaces[0].Type
        Assert-AreEqual $tunnelInterface1.Port $expectedLb.BackendAddressPools[0].TunnelInterfaces[0].Port
        Assert-AreEqual $tunnelInterface1.Identifier $expectedLb.BackendAddressPools[0].TunnelInterfaces[0].Identifier

        Assert-AreEqual 1 @($expectedLb.BackendAddressPools[1].TunnelInterfaces).Count
        Assert-AreEqual $tunnelInterface2.Protocol $expectedLb.BackendAddressPools[1].TunnelInterfaces[0].Protocol
        Assert-AreEqual $tunnelInterface2.Type $expectedLb.BackendAddressPools[1].TunnelInterfaces[0].Type
        Assert-AreEqual $tunnelInterface2.Port $expectedLb.BackendAddressPools[1].TunnelInterfaces[0].Port
        Assert-AreEqual $tunnelInterface2.Identifier $expectedLb.BackendAddressPools[1].TunnelInterfaces[0].Identifier
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Tests Gateway LoadBalancer Consumer ref Provider.
#>
function Test-GatewayLoadBalancer-ConsumerLb
{
    # Setup Provider
    $rgname = Get-ResourceGroupName
    $vnetProviderName = Get-ResourceName
    $subnetProviderName = Get-ResourceName
    $lbProviderName = Get-ResourceName
    $frontendProviderName = Get-ResourceName

    # Setup Provider
    $pipConusmerName = Get-ResourceName
    $subnetConsumerName = Get-ResourceName
    $lbConsumerName = Get-ResourceName
    $frontendConsumerName = Get-ResourceName
    $domainNameLabel = Get-ResourceName

    $rglocation = "eastus2euap"
    $resourceTypeParent = "Microsoft.Network/loadBalancers"
    $location = "eastus2euap"

    try 
    {
        # Create resource group
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval"} 

        # Create Provider Virtual Network
        $subnet = New-AzVirtualNetworkSubnetConfig -Name $subnetProviderName -AddressPrefix 10.0.1.0/24
        $vnet = New-AzVirtualNetwork -Name $vnetProviderName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnet

        # Create Provider LoadBalancer
        $frontendProvider = New-AzLoadBalancerFrontendIpConfig -Name $frontendProviderName -Subnet $vnet.Subnets[0]
        $lbProvider = New-AzLoadBalancer -Name $lbProviderName -ResourceGroupName $rgname -Location $location -FrontendIpConfiguration $frontendProvider -Sku Gateway

        # Create Consumer publicip
        $publicipConsumer = New-AzPublicIpAddress -ResourceGroupName $rgname -Name $pipConusmerName -location $location -AllocationMethod Static -DomainNameLabel $domainNameLabel -Sku Standard

        # Create Consumer LoadBalancer
        $lbConsumer = New-AzLoadBalancer -Name $lbConsumerName -ResourceGroupName $rgname -Location $location -Sku Standard
        Add-AzLoadBalancerFrontendIpConfig -PublicIpAddress $publicipConsumer -GatewayLoadBalancerId $frontendProvider.Id -LoadBalancer $lbConsumer -Name $frontendConsumerName
        $lbConsumer = Set-AzLoadBalancer -LoadBalancer $lbConsumer

        $expectedLbConsumer = Get-AzLoadBalancer -Name $lbConsumerName -ResourceGroupName $rgname

        # Verification
        Assert-NotNull $expectedLbConsumer.frontendIpConfigurations
        Assert-NotNull $expectedLbConsumer.frontendIpConfigurations[0]
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Tests creating a public Load balancer with standard sku.
#>
function Test-LoadBalancerCRUD-PublicStandardSku
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
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval"} 
        
        # Create the Virtual Network
        $subnet = New-AzVirtualNetworkSubnetConfig -Name $subnetName -AddressPrefix 10.0.1.0/24
        $vnet = New-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnet
        
        # Create the publicip
        $publicip = New-AzPublicIpAddress -ResourceGroupName $rgname -name $publicIpName -location $location -AllocationMethod Static -DomainNameLabel $domainNameLabel -Sku Standard

        # Create LoadBalancer
        $frontend = New-AzLoadBalancerFrontendIpConfig -Name $frontendName -PublicIpAddress $publicip
        $backendAddressPool = New-AzLoadBalancerBackendAddressPoolConfig -Name $backendAddressPoolName
        $probe = New-AzLoadBalancerProbeConfig -Name $probeName -RequestPath healthcheck.aspx -Protocol http -Port 80 -IntervalInSeconds 15 -ProbeCount 2 -ProbeThreshold 2
        $inboundNatRule = New-AzLoadBalancerInboundNatRuleConfig -Name $inboundNatRuleName -FrontendIPConfiguration $frontend -Protocol Tcp -FrontendPort 3389 -BackendPort 3389 -IdleTimeoutInMinutes 15 -EnableFloatingIP
        $lbrule = New-AzLoadBalancerRuleConfig -Name $lbruleName -FrontendIPConfiguration $frontend -BackendAddressPool $backendAddressPool -Probe $probe -Protocol Tcp -FrontendPort 80 -BackendPort 80 -IdleTimeoutInMinutes 15 -EnableFloatingIP -LoadDistribution SourceIP -DisableOutboundSNAT
        $actualLb = New-AzLoadBalancer -Name $lbName -ResourceGroupName $rgname -Location $location -FrontendIpConfiguration $frontend -BackendAddressPool $backendAddressPool -Probe $probe -InboundNatRule $inboundNatRule -LoadBalancingRule $lbrule -Sku Standard
        
        $expectedLb = Get-AzLoadBalancer -Name $lbName -ResourceGroupName $rgname

        # Verification
        Assert-AreEqual $expectedLb.ResourceGroupName $actualLb.ResourceGroupName
        Assert-AreEqual $expectedLb.Name $actualLb.Name
        Assert-AreEqual $expectedLb.Location $actualLb.Location
        Assert-AreEqualObjectProperties $expectedLb.Sku $actualLb.Sku
        Assert-AreEqual "Succeeded" $expectedLb.ProvisioningState
        Assert-NotNull $expectedLb.ResourceGuid
        Assert-AreEqual 1 @($expectedLb.FrontendIPConfigurations).Count

        Assert-AreEqual $frontendName $expectedLb.FrontendIPConfigurations[0].Name
        Assert-AreEqual $publicip.Id $expectedLb.FrontendIPConfigurations[0].PublicIpAddress.Id
        Assert-Null $expectedLb.FrontendIPConfigurations[0].PrivateIpAddress

        Assert-AreEqual $backendAddressPoolName $expectedLb.BackendAddressPools[0].Name

        Assert-AreEqual $probeName $expectedLb.Probes[0].Name
        Assert-AreEqual $probe.RequestPath $expectedLb.Probes[0].RequestPath
         Assert-AreEqual $probe.ProbeThreshold $expectedLb.Probes[0].ProbeThreshold

        Assert-AreEqual $inboundNatRuleName $expectedLb.InboundNatRules[0].Name
        Assert-AreEqual $expectedLb.FrontendIPConfigurations[0].Id $expectedLb.InboundNatRules[0].FrontendIPConfiguration.Id

        Assert-AreEqual $lbruleName $expectedLb.LoadBalancingRules[0].Name
        Assert-AreEqual $expectedLb.FrontendIPConfigurations[0].Id $expectedLb.LoadBalancingRules[0].FrontendIPConfiguration.Id
        Assert-AreEqual $expectedLb.BackendAddressPools[0].Id $expectedLb.LoadBalancingRules[0].BackendAddressPool.Id

        # List
        $list = Get-AzLoadBalancer -ResourceGroupName $rgname
        Assert-AreEqual 1 @($list).Count
        Assert-AreEqual $expectedLb.Etag $list[0].Etag
        Assert-AreEqualObjectProperties $expectedLb.Sku $list[0].Sku
        Assert-AreEqual $expectedLb.FrontendIPConfigurations[0].Etag $list[0].FrontendIPConfigurations[0].Etag
        Assert-AreEqual $expectedLb.BackendAddressPools[0].Etag $list[0].BackendAddressPools[0].Etag
        Assert-AreEqual $expectedLb.InboundNatRules[0].Etag $list[0].InboundNatRules[0].Etag
        Assert-AreEqual $expectedLb.Probes[0].Etag $list[0].Probes[0].Etag
        Assert-AreEqual $expectedLb.LoadBalancingRules[0].Etag $list[0].LoadBalancingRules[0].Etag

        # Delete
        $deleteLb = Remove-AzLoadBalancer -Name $lbName -ResourceGroupName $rgname -PassThru -Force
        Assert-AreEqual true $deleteLb
        
        $list = Get-AzLoadBalancer -ResourceGroupName $rgname
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
Tests creating a public Load balancer with standard sku as default.
#>
function Test-LoadBalancerCRUD-PublicStandardSkuDefault
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
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval"} 
        
        # Create the Virtual Network
        $subnet = New-AzVirtualNetworkSubnetConfig -Name $subnetName -AddressPrefix 10.0.1.0/24
        $vnet = New-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnet
        
        # Create the publicip
        $publicip = New-AzPublicIpAddress -ResourceGroupName $rgname -name $publicIpName -location $location -AllocationMethod Static -DomainNameLabel $domainNameLabel -Sku Standard

        # Create LoadBalancer
        $frontend = New-AzLoadBalancerFrontendIpConfig -Name $frontendName -PublicIpAddress $publicip
        $backendAddressPool = New-AzLoadBalancerBackendAddressPoolConfig -Name $backendAddressPoolName
        $probe = New-AzLoadBalancerProbeConfig -Name $probeName -RequestPath healthcheck.aspx -Protocol http -Port 80 -IntervalInSeconds 15 -ProbeCount 2 -ProbeThreshold 2
        $inboundNatRule = New-AzLoadBalancerInboundNatRuleConfig -Name $inboundNatRuleName -FrontendIPConfiguration $frontend -Protocol Tcp -FrontendPort 3389 -BackendPort 3389 -IdleTimeoutInMinutes 15 -EnableFloatingIP
        $lbrule = New-AzLoadBalancerRuleConfig -Name $lbruleName -FrontendIPConfiguration $frontend -BackendAddressPool $backendAddressPool -Probe $probe -Protocol Tcp -FrontendPort 80 -BackendPort 80 -IdleTimeoutInMinutes 15 -EnableFloatingIP -LoadDistribution SourceIP -DisableOutboundSNAT
        $actualLb = New-AzLoadBalancer -Name $lbName -ResourceGroupName $rgname -Location $location -FrontendIpConfiguration $frontend -BackendAddressPool $backendAddressPool -Probe $probe -InboundNatRule $inboundNatRule -LoadBalancingRule $lbrule
        
        $expectedLb = Get-AzLoadBalancer -Name $lbName -ResourceGroupName $rgname

        # Verification
        Assert-AreEqual $expectedLb.ResourceGroupName $actualLb.ResourceGroupName
        Assert-AreEqual $expectedLb.Name $actualLb.Name
        Assert-AreEqual $expectedLb.Location $actualLb.Location
        Assert-AreEqualObjectProperties $expectedLb.Sku $actualLb.Sku
        Assert-AreEqual "Succeeded" $expectedLb.ProvisioningState
        Assert-NotNull $expectedLb.ResourceGuid
        Assert-AreEqual 1 @($expectedLb.FrontendIPConfigurations).Count

        Assert-AreEqual $frontendName $expectedLb.FrontendIPConfigurations[0].Name
        Assert-AreEqual $publicip.Id $expectedLb.FrontendIPConfigurations[0].PublicIpAddress.Id
        Assert-Null $expectedLb.FrontendIPConfigurations[0].PrivateIpAddress

        Assert-AreEqual $backendAddressPoolName $expectedLb.BackendAddressPools[0].Name

        Assert-AreEqual $probeName $expectedLb.Probes[0].Name
        Assert-AreEqual $probe.RequestPath $expectedLb.Probes[0].RequestPath
         Assert-AreEqual $probe.ProbeThreshold $expectedLb.Probes[0].ProbeThreshold

        Assert-AreEqual $inboundNatRuleName $expectedLb.InboundNatRules[0].Name
        Assert-AreEqual $expectedLb.FrontendIPConfigurations[0].Id $expectedLb.InboundNatRules[0].FrontendIPConfiguration.Id

        Assert-AreEqual $lbruleName $expectedLb.LoadBalancingRules[0].Name
        Assert-AreEqual $expectedLb.FrontendIPConfigurations[0].Id $expectedLb.LoadBalancingRules[0].FrontendIPConfiguration.Id
        Assert-AreEqual $expectedLb.BackendAddressPools[0].Id $expectedLb.LoadBalancingRules[0].BackendAddressPool.Id

        # List
        $list = Get-AzLoadBalancer -ResourceGroupName $rgname
        Assert-AreEqual 1 @($list).Count
        Assert-AreEqual $expectedLb.Etag $list[0].Etag
        Assert-AreEqualObjectProperties $expectedLb.Sku $list[0].Sku
        Assert-AreEqual $expectedLb.FrontendIPConfigurations[0].Etag $list[0].FrontendIPConfigurations[0].Etag
        Assert-AreEqual $expectedLb.BackendAddressPools[0].Etag $list[0].BackendAddressPools[0].Etag
        Assert-AreEqual $expectedLb.InboundNatRules[0].Etag $list[0].InboundNatRules[0].Etag
        Assert-AreEqual $expectedLb.Probes[0].Etag $list[0].Probes[0].Etag
        Assert-AreEqual $expectedLb.LoadBalancingRules[0].Etag $list[0].LoadBalancingRules[0].Etag

        # Delete
        $deleteLb = Remove-AzLoadBalancer -Name $lbName -ResourceGroupName $rgname -PassThru -Force
        Assert-AreEqual true $deleteLb
        
        $list = Get-AzLoadBalancer -ResourceGroupName $rgname
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
Tests creating a public Load balancer with standard sku with ip prefix.
#>
function Test-LoadBalancerCRUD-PublicStandardSkuIpPrefix
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
    $inboundNatRuleName = Get-ResourceName
    $lbruleName = Get-ResourceName
    $rglocation = Get-ProviderLocation ResourceManagement
    $resourceTypeParent = "Microsoft.Network/loadBalancers"
    $location = Get-ProviderLocation $resourceTypeParent

    try
    {
        # Create the resource group
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval"} 
        
        # Create the Virtual Network
        $subnet = New-AzVirtualNetworkSubnetConfig -Name $subnetName -AddressPrefix 10.0.1.0/24
        $vnet = New-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnet
        
        # Create the publicip prefix 
        $publicipprefix = New-AzPublicIpPrefix -ResourceGroupName $rgname -name $publicIpName -location $location -Sku Standard -PrefixLength 28

        # Create LoadBalancer
        $frontend = New-AzLoadBalancerFrontendIpConfig -Name $frontendName -PublicIpAddressPrefix $publicipprefix
        $backendAddressPool = New-AzLoadBalancerBackendAddressPoolConfig -Name $backendAddressPoolName
        $probe = New-AzLoadBalancerProbeConfig -Name $probeName -RequestPath healthcheck.aspx -Protocol http -Port 80 -IntervalInSeconds 15 -ProbeCount 2
        $actualLb = New-AzLoadBalancer -Name $lbName -ResourceGroupName $rgname -Location $location -FrontendIpConfiguration $frontend -BackendAddressPool $backendAddressPool -Probe $probe -Sku Standard
        
        $expectedLb = Get-AzLoadBalancer -Name $lbName -ResourceGroupName $rgname

        # Verification
        Assert-AreEqual $expectedLb.ResourceGroupName $actualLb.ResourceGroupName
        Assert-AreEqual $expectedLb.Name $actualLb.Name
        Assert-AreEqual $expectedLb.Location $actualLb.Location
        Assert-AreEqualObjectProperties $expectedLb.Sku $actualLb.Sku
        Assert-AreEqual "Succeeded" $expectedLb.ProvisioningState
        Assert-NotNull $expectedLb.ResourceGuid
        Assert-AreEqual 1 @($expectedLb.FrontendIPConfigurations).Count

        Assert-AreEqual $frontendName $expectedLb.FrontendIPConfigurations[0].Name
        Assert-AreEqual $publicipprefix.Id $expectedLb.FrontendIPConfigurations[0].PublicIPPrefix.Id
        Assert-Null $expectedLb.FrontendIPConfigurations[0].PrivateIpAddress

        Assert-AreEqual $backendAddressPoolName $expectedLb.BackendAddressPools[0].Name

        Assert-AreEqual $probeName $expectedLb.Probes[0].Name
        Assert-AreEqual $probe.RequestPath $expectedLb.Probes[0].RequestPath

        # List
        $list = Get-AzLoadBalancer -ResourceGroupName $rgname
        Assert-AreEqual 1 @($list).Count
        Assert-AreEqual $expectedLb.Etag $list[0].Etag
        Assert-AreEqualObjectProperties $expectedLb.Sku $list[0].Sku
        Assert-AreEqual $expectedLb.FrontendIPConfigurations[0].Etag $list[0].FrontendIPConfigurations[0].Etag
        Assert-AreEqual $expectedLb.BackendAddressPools[0].Etag $list[0].BackendAddressPools[0].Etag
        Assert-AreEqual $expectedLb.Probes[0].Etag $list[0].Probes[0].Etag

        # Delete
        $deleteLb = Remove-AzLoadBalancer -Name $lbName -ResourceGroupName $rgname -PassThru -Force
        Assert-AreEqual true $deleteLb
        
        $list = Get-AzLoadBalancer -ResourceGroupName $rgname
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
Tests creating a public Load balancer with standard sku and global tier.
#>
function Test-LoadBalancerCRUD-PublicStandardSkuGlobalTier
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
    $lbruleName = Get-ResourceName
    $inboundNatRuleName = Get-ResourceName
    $outboundRuleName = Get-ResourceName
    $rglocation = Get-ProviderLocation ResourceManagement
    $resourceTypeParent = "Microsoft.Network/loadBalancers"
    $gviplocation = "eastus2euap"

    try
    {
        # Create the resource group
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval"} 

        # Create the Virtual Network
        $subnet = New-AzVirtualNetworkSubnetConfig -Name $subnetName -AddressPrefix 10.0.1.0/24
        $vnet = New-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $gviplocation -AddressPrefix 10.0.0.0/16 -Subnet $subnet

        # Create the publicip
        $publicip = New-AzPublicIpAddress -ResourceGroupName $rgname -name $publicIpName -Location $gviplocation  -AllocationMethod Static -DomainNameLabel $domainNameLabel -Sku Standard -Tier Global

        # Create LoadBalancer
        $frontend = New-AzLoadBalancerFrontendIpConfig -Name $frontendName -PublicIpAddress $publicip
        $backendAddressPool = New-AzLoadBalancerBackendAddressPoolConfig -Name $backendAddressPoolName
        $lbrule = New-AzLoadBalancerRuleConfig -Name $lbruleName -FrontendIPConfiguration $frontend -BackendAddressPool $backendAddressPool -Protocol Tcp -FrontendPort 80 -BackendPort 80 -EnableFloatingIP -LoadDistribution SourceIP -DisableOutboundSNAT
        $actualLb = New-AzLoadBalancer -Name $lbName -ResourceGroupName $rgname -Location $gviplocation -FrontendIpConfiguration $frontend -BackendAddressPool $backendAddressPool -LoadBalancingRule $lbrule -Sku Standard -Tier Global

        $expectedLb = Get-AzLoadBalancer -Name $lbName -ResourceGroupName $rgname
        
        # Verification
        Assert-AreEqual $expectedLb.ResourceGroupName $actualLb.ResourceGroupName
        Assert-AreEqual $expectedLb.Name $actualLb.Name
        Assert-AreEqual $expectedLb.Location $actualLb.Location
        Assert-AreEqualObjectProperties $expectedLb.Sku $actualLb.Sku
        Assert-AreEqual "Succeeded" $expectedLb.ProvisioningState
        Assert-NotNull $expectedLb.ResourceGuid
        Assert-AreEqual 1 @($expectedLb.FrontendIPConfigurations).Count

        Assert-AreEqual $frontendName $expectedLb.FrontendIPConfigurations[0].Name
        Assert-AreEqual $publicip.Id $expectedLb.FrontendIPConfigurations[0].PublicIpAddress.Id
        Assert-Null $expectedLb.FrontendIPConfigurations[0].PrivateIpAddress

        Assert-AreEqual $backendAddressPoolName $expectedLb.BackendAddressPools[0].Name

        Assert-AreEqual $lbruleName $expectedLb.LoadBalancingRules[0].Name
        Assert-AreEqual $expectedLb.FrontendIPConfigurations[0].Id $expectedLb.LoadBalancingRules[0].FrontendIPConfiguration.Id
        Assert-AreEqual $expectedLb.BackendAddressPools[0].Id $expectedLb.LoadBalancingRules[0].BackendAddressPool.Id

        # List
        $list = Get-AzLoadBalancer -ResourceGroupName $rgname
        Assert-AreEqual 1 @($list).Count
        Assert-AreEqual $expectedLb.Etag $list[0].Etag
        Assert-AreEqualObjectProperties $expectedLb.Sku $list[0].Sku
        Assert-AreEqual $expectedLb.FrontendIPConfigurations[0].Etag $list[0].FrontendIPConfigurations[0].Etag
        Assert-AreEqual $expectedLb.BackendAddressPools[0].Etag $list[0].BackendAddressPools[0].Etag
        Assert-AreEqual $expectedLb.LoadBalancingRules[0].Etag $list[0].LoadBalancingRules[0].Etag

        # Creating or setting global loadbalancer with probe should fail
        $probe = New-AzLoadBalancerProbeConfig -Name $probeName -RequestPath healthcheck.aspx -Protocol http -Port 80 -IntervalInSeconds 15 -ProbeCount 2
        Assert-ThrowsContains { New-AzLoadBalancer -Name $lbName -ResourceGroupName $rgname -Location $gviplocation -FrontendIpConfiguration $frontend -BackendAddressPool $backendAddressPool -Probe $probe -LoadBalancingRule $lbrule -Sku Standard -Tier Global } "User defined probes are not supported on global load balancers."
        
        $modifyLb = Get-AzLoadBalancer -Name $lbName -ResourceGroupName $rgname
        Add-AzLoadBalancerProbeConfig -Loadbalancer $modifyLb -Name $probeName -Protocol http -Port 80 -IntervalInSeconds 15 -ProbeCount 2
        Assert-ThrowsContains { Set-AzLoadBalancer -LoadBalancer $modifyLb } "User defined probes are not supported on global load balancers."

        # Creating or setting global loadbalancer with tcp reset should fail
        $lbrule = New-AzLoadBalancerRuleConfig -Name $lbruleName -FrontendIPConfiguration $frontend -BackendAddressPool $backendAddressPool -Protocol Tcp -FrontendPort 80 -BackendPort 80 -EnableFloatingIP -LoadDistribution SourceIP -DisableOutboundSNAT -EnableTcpReset
        Assert-ThrowsContains { New-AzLoadBalancer -Name $lbName -ResourceGroupName $rgname -Location $gviplocation -FrontendIpConfiguration $frontend -BackendAddressPool $backendAddressPool -LoadBalancingRule $lbrule -Sku Standard -Tier Global } "TCP reset is not supported on global load balancers."
        
        $modifyLb = Get-AzLoadBalancer -Name $lbName -ResourceGroupName $rgname
        $lbRuleName += "_1"
        Add-AzLoadBalancerRuleConfig -Loadbalancer $modifyLb -Name $lbruleName -FrontendIPConfiguration $frontend -BackendAddressPool $backendAddressPool -Protocol Tcp -FrontendPort 80 -BackendPort 80 -EnableFloatingIP -LoadDistribution SourceIP -DisableOutboundSNAT -EnableTcpReset
        Assert-ThrowsContains { Set-AzLoadBalancer -Loadbalancer $modifyLb } "TCP reset is not supported on global load balancers."

        # Creating or setting global loadbalancer with idle timeout should fail
        $lbrule = New-AzLoadBalancerRuleConfig -Name $lbruleName -FrontendIPConfiguration $frontend -BackendAddressPool $backendAddressPool -Protocol Tcp -FrontendPort 80 -BackendPort 80 -EnableFloatingIP -LoadDistribution SourceIP -DisableOutboundSNAT -IdleTimeoutInMinutes 15
        Assert-ThrowsContains { New-AzLoadBalancer -Name $lbName -ResourceGroupName $rgname -Location $gviplocation -FrontendIpConfiguration $frontend -BackendAddressPool $backendAddressPool -LoadBalancingRule $lbrule -Sku Standard -Tier Global } "Idle timeout is not supported on global load balancers."

        $modifyLb = Get-AzLoadBalancer -Name $lbName -ResourceGroupName $rgname
        Add-AzLoadBalancerRuleConfig -Loadbalancer $modifyLb -Name $lbruleName -FrontendIPConfiguration $frontend -BackendAddressPool $backendAddressPool -Protocol Tcp -FrontendPort 80 -BackendPort 80 -EnableFloatingIP -LoadDistribution SourceIP -DisableOutboundSNAT -IdleTimeoutInMinutes 15
        Assert-ThrowsContains { Set-AzLoadBalancer -Loadbalancer $modifyLb } "Idle timeout is not supported on global load balancers."

        # Creating or setting global loadbalancer with an inbound nat rule should fail
        $inboundNatRule = New-AzLoadBalancerInboundNatRuleConfig -Name $inboundNatRuleName -FrontendIPConfiguration $frontend -Protocol Tcp -FrontendPort 3389 -BackendPort 3389 -IdleTimeoutInMinutes 15 -EnableFloatingIP
        Assert-ThrowsContains { New-AzLoadBalancer -Name $lbName -ResourceGroupName $rgname -Location $gviplocation -FrontendIpConfiguration $frontend -BackendAddressPool $backendAddressPool -LoadBalancingRule $lbrule -InboundNatRule $inboundNatRule -Sku Standard -Tier Global } "Only load balancing rules are supported on global load balancers."

        $modifyLb = Get-AzLoadBalancer -Name $lbName -ResourceGroupName $rgname
        Add-AzLoadBalancerInboundNatRuleConfig -Loadbalancer $modifyLb -Name $inboundNatRuleName -FrontendIPConfiguration $frontend -Protocol Tcp -FrontendPort 3389 -BackendPort 3389 -IdleTimeoutInMinutes 15 -EnableFloatingIP
        Assert-ThrowsContains { Set-AzLoadBalancer -Loadbalancer $modifyLb } "Only load balancing rules are supported on global load balancers."

        # Creating or setting global loadbalancer with an outbound rule should fail
        $outboundRule = New-AzLoadBalancerOutboundRuleConfig -Name $outboundRuleName -FrontendIPConfiguration $frontend -BackendAddressPool $backendAddressPool -Protocol Tcp
        Assert-ThrowsContains { New-AzLoadBalancer -Name $lbName -ResourceGroupName $rgname -Location $gviplocation -FrontendIpConfiguration $frontend -BackendAddressPool $backendAddressPool -LoadBalancingRule $lbrule -OutboundRule $outboundRule -Sku Standard -Tier Global } "Only load balancing rules are supported on global load balancers."

        $modifyLb = Get-AzLoadBalancer -Name $lbName -ResourceGroupName $rgname
        Add-AzLoadBalancerOutboundRuleConfig -Loadbalancer $modifyLb -Name $outboundRuleName -FrontendIPConfiguration $frontend -BackendAddressPool $backendAddressPool -Protocol Tcp
        Assert-ThrowsContains { Set-AzLoadBalancer -Loadbalancer $modifyLb } "Only load balancing rules are supported on global load balancers."

        # Delete
        $deleteLb = Remove-AzLoadBalancer -Name $lbName -ResourceGroupName $rgname -PassThru -Force
        Assert-AreEqual true $deleteLb

        $list = Get-AzLoadBalancer -ResourceGroupName $rgname
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
Tests creating an internal Load balancer with standard sku.
#>
function Test-LoadBalancerCRUD-InternalStandardSku
{
    # Setup
    $rgname = Get-ResourceGroupName
    $vnetName = Get-ResourceName
    $subnetName = Get-ResourceName
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
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval"} 
        
        # Create the Virtual Network
        $subnet = New-AzVirtualNetworkSubnetConfig -Name $subnetName -AddressPrefix 10.0.1.0/24
        $vnet = New-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnet

        # Create LoadBalancer
        $frontend = New-AzLoadBalancerFrontendIpConfig -Name $frontendName -Subnet $vnet.Subnets[0]
        $backendAddressPool = New-AzLoadBalancerBackendAddressPoolConfig -Name $backendAddressPoolName
        $probe = New-AzLoadBalancerProbeConfig -Name $probeName -RequestPath healthcheck.aspx -Protocol http -Port 80 -IntervalInSeconds 15 -ProbeCount 2
        $inboundNatRule = New-AzLoadBalancerInboundNatRuleConfig -Name $inboundNatRuleName -FrontendIPConfiguration $frontend -Protocol Tcp -FrontendPort 3389 -BackendPort 3389 -IdleTimeoutInMinutes 15 -EnableFloatingIP
        $lbrule = New-AzLoadBalancerRuleConfig -Name $lbruleName -FrontendIPConfiguration $frontend -BackendAddressPool $backendAddressPool -Probe $probe -Protocol Tcp -FrontendPort 80 -BackendPort 80 -IdleTimeoutInMinutes 15 -EnableFloatingIP -LoadDistribution SourceIP -DisableOutboundSNAT
        $actualLb = New-AzLoadBalancer -Name $lbName -ResourceGroupName $rgname -Location $location -FrontendIpConfiguration $frontend -BackendAddressPool $backendAddressPool -Probe $probe -InboundNatRule $inboundNatRule -LoadBalancingRule $lbrule -Sku Standard

        $expectedLb = Get-AzLoadBalancer -Name $lbName -ResourceGroupName $rgname

        # Verification
        Assert-AreEqual $expectedLb.ResourceGroupName $actualLb.ResourceGroupName
        Assert-AreEqual $expectedLb.Name $actualLb.Name
        Assert-AreEqual $expectedLb.Location $actualLb.Location
        Assert-AreEqualObjectProperties $expectedLb.Sku $actualLb.Sku
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
        Assert-AreEqual true $expectedlb.LoadBalancingRules[0].DisableOutboundSNAT
        Assert-AreEqual true $actualLb.LoadBalancingRules[0].DisableOutboundSNAT

        # List
        $list = Get-AzLoadBalancer -ResourceGroupName $rgname
        Assert-AreEqual 1 @($list).Count
        Assert-AreEqual $expectedLb.Etag $list[0].Etag
        Assert-AreEqualObjectProperties $expectedLb.Sku $list[0].Sku
        Assert-AreEqual $expectedLb.FrontendIPConfigurations[0].Etag $list[0].FrontendIPConfigurations[0].Etag
        Assert-AreEqual $expectedLb.BackendAddressPools[0].Etag $list[0].BackendAddressPools[0].Etag
        Assert-AreEqual $expectedLb.InboundNatRules[0].Etag $list[0].InboundNatRules[0].Etag
        Assert-AreEqual $expectedLb.Probes[0].Etag $list[0].Probes[0].Etag
        Assert-AreEqual $expectedLb.LoadBalancingRules[0].Etag $list[0].LoadBalancingRules[0].Etag
        Assert-AreEqual $expectedlb.LoadBalancingRules[0].DisableOutboundSNAT $actualLb.LoadBalancingRules[0].DisableOutboundSNAT

        # Delete
        $deleteLb = Remove-AzLoadBalancer -Name $lbName -ResourceGroupName $rgname -PassThru -Force
        Assert-AreEqual true $deleteLb
        
        $list = Get-AzLoadBalancer -ResourceGroupName $rgname
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
Tests creating an internal Load balancer with standard sku as default.
#>
function Test-LoadBalancerCRUD-InternalStandardSkuDefault
{
    # Setup
    $rgname = Get-ResourceGroupName
    $vnetName = Get-ResourceName
    $subnetName = Get-ResourceName
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
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval"} 
        
        # Create the Virtual Network
        $subnet = New-AzVirtualNetworkSubnetConfig -Name $subnetName -AddressPrefix 10.0.1.0/24
        $vnet = New-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnet

        # Create LoadBalancer
        $frontend = New-AzLoadBalancerFrontendIpConfig -Name $frontendName -Subnet $vnet.Subnets[0]
        $backendAddressPool = New-AzLoadBalancerBackendAddressPoolConfig -Name $backendAddressPoolName
        $probe = New-AzLoadBalancerProbeConfig -Name $probeName -RequestPath healthcheck.aspx -Protocol http -Port 80 -IntervalInSeconds 15 -ProbeCount 2
        $inboundNatRule = New-AzLoadBalancerInboundNatRuleConfig -Name $inboundNatRuleName -FrontendIPConfiguration $frontend -Protocol Tcp -FrontendPort 3389 -BackendPort 3389 -IdleTimeoutInMinutes 15 -EnableFloatingIP
        $lbrule = New-AzLoadBalancerRuleConfig -Name $lbruleName -FrontendIPConfiguration $frontend -BackendAddressPool $backendAddressPool -Probe $probe -Protocol Tcp -FrontendPort 80 -BackendPort 80 -IdleTimeoutInMinutes 15 -EnableFloatingIP -LoadDistribution SourceIP -DisableOutboundSNAT
        $actualLb = New-AzLoadBalancer -Name $lbName -ResourceGroupName $rgname -Location $location -FrontendIpConfiguration $frontend -BackendAddressPool $backendAddressPool -Probe $probe -InboundNatRule $inboundNatRule -LoadBalancingRule $lbrule

        $expectedLb = Get-AzLoadBalancer -Name $lbName -ResourceGroupName $rgname

        # Verification
        Assert-AreEqual $expectedLb.ResourceGroupName $actualLb.ResourceGroupName
        Assert-AreEqual $expectedLb.Name $actualLb.Name
        Assert-AreEqual $expectedLb.Location $actualLb.Location
        Assert-AreEqualObjectProperties $expectedLb.Sku $actualLb.Sku
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
        Assert-AreEqual true $expectedlb.LoadBalancingRules[0].DisableOutboundSNAT
        Assert-AreEqual true $actualLb.LoadBalancingRules[0].DisableOutboundSNAT

        # List
        $list = Get-AzLoadBalancer -ResourceGroupName $rgname
        Assert-AreEqual 1 @($list).Count
        Assert-AreEqual $expectedLb.Etag $list[0].Etag
        Assert-AreEqualObjectProperties $expectedLb.Sku $list[0].Sku
        Assert-AreEqual $expectedLb.FrontendIPConfigurations[0].Etag $list[0].FrontendIPConfigurations[0].Etag
        Assert-AreEqual $expectedLb.BackendAddressPools[0].Etag $list[0].BackendAddressPools[0].Etag
        Assert-AreEqual $expectedLb.InboundNatRules[0].Etag $list[0].InboundNatRules[0].Etag
        Assert-AreEqual $expectedLb.Probes[0].Etag $list[0].Probes[0].Etag
        Assert-AreEqual $expectedLb.LoadBalancingRules[0].Etag $list[0].LoadBalancingRules[0].Etag
        Assert-AreEqual $expectedlb.LoadBalancingRules[0].DisableOutboundSNAT $actualLb.LoadBalancingRules[0].DisableOutboundSNAT

        # Delete
        $deleteLb = Remove-AzLoadBalancer -Name $lbName -ResourceGroupName $rgname -PassThru -Force
        Assert-AreEqual true $deleteLb
        
        $list = Get-AzLoadBalancer -ResourceGroupName $rgname
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
Tests creating new simple loadBalancer.
#>
function Test-LoadBalancerZones
{
    # Setup
    $rgname = Get-ResourceGroupName
    $rname = Get-ResourceName
    $subnetName = Get-ResourceName
    $vnetName = Get-ResourceName
    $frontendName = Get-ResourceName
    $zones = "1";
    $rglocation = Get-ProviderLocation ResourceManagement
    $location = Get-ProviderLocation "Microsoft.Network/loadBalancers" "Central US"

    try
     {
      # Create the resource group
      $resourceGroup = New-AzResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval" }
      $subnet = New-AzVirtualNetworkSubnetConfig -Name $subnetName -AddressPrefix 10.0.1.0/24
      $vnet = New-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/8 -Subnet $subnet
      $subnet = Get-AzVirtualNetworkSubnetConfig -Name $subnetName -VirtualNetwork $vnet
      $frontend = New-AzLoadBalancerFrontendIpConfig -Name $frontendName -Subnet $subnet -Zone $zones

      # Create loadBalancer
      $actual = New-AzLoadBalancer -ResourceGroupName $rgname -name $rname -location $location -frontendIpConfiguration $frontend -Sku Standard
      $expected = Get-AzLoadBalancer -ResourceGroupName $rgname -name $rname
      Assert-AreEqual $expected.ResourceGroupName $actual.ResourceGroupName
      Assert-AreEqual $expected.Name $actual.Name
      Assert-AreEqual $expected.Location $actual.Location
      Assert-NotNull $expected.ResourceGuid
      Assert-AreEqual "Succeeded" $expected.ProvisioningState
      Assert-NotNull $expected.frontendIpConfigurations
      Assert-NotNull $expected.frontendIpConfigurations[0]
      Assert-NotNull $expected.frontendIpConfigurations[0].zones
      Assert-AreEqual $zones $expected.frontendIpConfigurations[0].zones[0]
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Tests adding subresources after creating an empty Load balancer 
#>
function Test-CreateSubresourcesOnEmptyLoadBalancer
{
    # Setup
    $rgname = Get-ResourceGroupName
    $lbName = Get-ResourceName
    $location = Get-ProviderLocation "Microsoft.Network/loadBalancers"
    # Subresource's names
    $poolName = Get-ResourceName
    $ipConfigName = Get-ResourceName
    $natPoolName = Get-ResourceName
    $natRuleName = Get-ResourceName
    $probeName = Get-ResourceName
    $ruleName = Get-ResourceName
    # Dependencies' name
    $subnetName = Get-ResourceName
    $vnetName = Get-ResourceName
    
    try 
    {
        # Create the resource group
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $location

        # Dependencies
        $subnet = New-AzVirtualNetworkSubnetConfig -Name $subnetName -AddressPrefix 10.0.1.0/24
        $vnet = New-AzVirtualNetwork -ResourceGroupName $rgname -Location $location -Name $vnetName -Subnet $subnet -AddressPrefix 10.0.0.0/8
        $subnet = Get-AzVirtualNetworkSubnetConfig -Name $subnetName -VirtualNetwork $vnet

        # Create empty load balancer
        New-AzLoadBalancer -Name $lbName -ResourceGroupName $rgname -Location $location

        $lb = Get-AzLoadBalancer -Name $lbName -ResourceGroupName $rgname
        Assert-AreEqual $lbName $lb.Name
        Assert-AreEqual 0 @($lb.FrontendIpConfigurations).Count
        Assert-AreEqual 0 @($lb.BackendAddressPools).Count
        Assert-AreEqual 0 @($lb.Probes).Count
        Assert-AreEqual 0 @($lb.LoadBalancingRules).Count
        Assert-AreEqual 0 @($lb.InboundNatRules).Count
        Assert-AreEqual 0 @($lb.InboundNatPools).Count
        Assert-AreEqual 0 @($lb.OutboundRules).Count

        # Add subresources on empty load balancer
        $lb = Add-AzLoadBalancerFrontendIpConfig -Name $ipConfigName -LoadBalancer $lb -Subnet $subnet
        $ipConfig = $lb.FrontendIpConfigurations[0]
        Assert-NotNull $ipConfig

        $lb = Add-AzLoadBalancerBackendAddressPoolConfig -Name $poolName -LoadBalancer $lb
        $lb = Add-AzLoadBalancerProbeConfig -Name $probeName -LoadBalancer $lb -Port 2000 -IntervalInSeconds 60 -ProbeCount 3 -Protocol Tcp
        $lb = Add-AzLoadBalancerRuleConfig -Name $ruleName -LoadBalancer $lb -FrontendIPConfigurationId $lb.FrontendIPConfigurations[0].Id -BackendAddressPoolId $lb.BackendAddressPools[0].Id -ProbeId $lb.Probes[0].Id -Protocol Tcp -FrontendPort 82 -BackendPort 83 -IdleTimeoutInMinutes 15 -LoadDistribution SourceIP
        $lb = Add-AzLoadBalancerInboundNatRuleConfig -Name $natRuleName -LoadBalancer $lb -FrontendIpConfiguration $ipConfig -FrontendPort 128 -BackendPort 256

        # Update load balancer
        $lb = Set-AzLoadBalancer -LoadBalancer $lb

        $lb = Get-AzLoadBalancer -Name $lbName -ResourceGroupName $rgname
        Assert-AreEqual 1 @($lb.FrontendIpConfigurations).Count
        Assert-AreEqual 1 @($lb.BackendAddressPools).Count
        Assert-AreEqual 1 @($lb.Probes).Count
        Assert-AreEqual 1 @($lb.LoadBalancingRules).Count
        Assert-AreEqual 1 @($lb.InboundNatRules).Count

        # Swap NatRule for NatPool
        $lb = Remove-AzLoadBalancerInboundNatRuleConfig -LoadBalancer $lb -Name $natRuleName
        $lb = Add-AzLoadBalancerInboundNatPoolConfig -Name $natPoolName -LoadBalancer $lb -FrontendIpConfiguration $ipConfig -Protocol Tcp -FrontendPortRangeStart 444 -FrontendPortRangeEnd 445 -BackendPort 8080
        
        $lb = Set-AzLoadBalancer -LoadBalancer $lb
        $lb = Get-AzLoadBalancer -Name $lbName -ResourceGroupName $rgname
        Assert-AreEqual 0 @($lb.InboundNatRules).Count
        Assert-AreEqual 1 @($lb.InboundNatPools).Count

        # Remove all child resources except IpConfig
        $lb = Remove-AzLoadBalancerBackendAddressPoolConfig -LoadBalancer $lb -Name $poolName
        $lb = Remove-AzLoadBalancerProbeConfig -LoadBalancer $lb -Name $probeName
        $lb = Remove-AzLoadBalancerRuleConfig -LoadBalancer $lb -Name $ruleName
        $lb = Remove-AzLoadBalancerInboundNatPoolConfig -LoadBalancer $lb -Name $natPoolName

        $lb = Set-AzLoadBalancer -LoadBalancer $lb
        $lb = Get-AzLoadBalancer -Name $lbName -ResourceGroupName $rgname
        Assert-AreEqual 1 @($lb.FrontendIpConfigurations).Count
        Assert-AreEqual 0 @($lb.BackendAddressPools).Count
        Assert-AreEqual 0 @($lb.Probes).Count
        Assert-AreEqual 0 @($lb.LoadBalancingRules).Count
        Assert-AreEqual 0 @($lb.InboundNatRules).Count
        Assert-AreEqual 0 @($lb.InboundNatPools).Count
        Assert-AreEqual 0 @($lb.OutboundRules).Count

        # Test error handling for LoadBalancerFrontendIpConfig
        $lb = Remove-AzLoadBalancerFrontendIpConfig -LoadBalancer $lb -Name $ipConfigName
        # Additional call to test handling of already deleted subresource
        $lb = Remove-AzLoadBalancerFrontendIpConfig -LoadBalancer $lb -Name $ipConfigName
        # Removing all frontend IP configs should fail
        Assert-ThrowsContains { Set-AzLoadBalancer -LoadBalancer $lb } "Deleting all frontendIPConfigs"

        # Delete
        $deleteLb = $lb | Remove-AzLoadBalancer -PassThru -Force
        Assert-AreEqual true $deleteLb

        $list = Get-AzLoadBalancer | Where-Object { $_.ResourceGroupName -eq $rgname }
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
Test creating a load balancer in an edge zone. Subscriptions need to be explicitly whitelisted for access to edge zones.
#>
function Test-LoadBalancerInEdgeZone
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
    $rglocation = "westus"
    $location = "westus"
    $edgeZone = "microsoftlosangeles1"

    try
    {
        # Create the resource group
        New-AzResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval"}

        # Create the Virtual Network
        $subnet = New-AzVirtualNetworkSubnetConfig -Name $subnetName -AddressPrefix 10.0.1.0/24
        New-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnet -EdgeZone $edgeZone

        # Create the publicip
        $publicip = New-AzPublicIpAddress -ResourceGroupName $rgname -name $publicIpName -location $location -AllocationMethod Dynamic -DomainNameLabel $domainNameLabel -EdgeZone $edgeZone

        # Create LoadBalancer
        $frontend = New-AzLoadBalancerFrontendIpConfig -Name $frontendName -PublicIpAddress $publicip
        $backendAddressPool = New-AzLoadBalancerBackendAddressPoolConfig -Name $backendAddressPoolName
        $probe = New-AzLoadBalancerProbeConfig -Name $probeName -RequestPath healthcheck.aspx -Protocol http -Port 80 -IntervalInSeconds 15 -ProbeCount 2
        $inboundNatRule = New-AzLoadBalancerInboundNatRuleConfig -Name $inboundNatRuleName -FrontendIPConfiguration $frontend -Protocol Tcp -FrontendPort 3389 -BackendPort 3389 -IdleTimeoutInMinutes 15 -EnableFloatingIP
        $lbrule = New-AzLoadBalancerRuleConfig -Name $lbruleName -FrontendIPConfiguration $frontend -BackendAddressPool $backendAddressPool -Probe $probe -Protocol Tcp -FrontendPort 80 -BackendPort 80 -IdleTimeoutInMinutes 15 -EnableFloatingIP -LoadDistribution SourceIP
        New-AzLoadBalancer -Name $lbName -ResourceGroupName $rgname -Location $location -FrontendIpConfiguration $frontend -BackendAddressPool $backendAddressPool -Probe $probe -InboundNatRule $inboundNatRule -LoadBalancingRule $lbrule -EdgeZone $edgeZone

        $loadBalancer = Get-AzLoadBalancer -Name $lbName -ResourceGroupName $rgname
        Assert-AreEqual $loadBalancer.ExtendedLocation.Name $edgeZone
        Assert-AreEqual $loadBalancer.ExtendedLocation.Type "EdgeZone"
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