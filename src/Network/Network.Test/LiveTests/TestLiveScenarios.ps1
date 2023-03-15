Invoke-LiveTestScenario -Name "Network interface CRUD with public IP address" -Description "Test CRUD for network interface with public IP address" -ScenarioScript `
{
    param ($rg)

    $rgName = $rg.ResourceGroupName
    $location = "westus"
    $vnetName = New-LiveTestResourceName
    $snetName = New-LiveTestResourceName
    $pipName = New-LiveTestResourceName
    $domainNameLabel = New-LiveTestResourceName
    $ipcfgName = New-LiveTestResourceName
    $nicName = New-LiveTestResourceName

    $snet = New-AzVirtualNetworkSubnetConfig -Name $snetName -AddressPrefix 10.0.1.0/24
    $vnet = New-AzVirtualNetwork -ResourceGroupName $rgName -Name $vnetName -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $snet
    $pip = New-AzPublicIpAddress -ResourceGroupName $rgName -Name $pipName -Location $location -AllocationMethod Dynamic -DomainNameLabel $domainNameLabel
    $ipcfg = New-AzNetworkInterfaceIpConfig -Name $ipcfgName -Subnet $vnet.Subnets[0] -PublicIpAddress $pip
    New-AzNetworkInterface -ResourceGroupName $rgName -Name $nicName -Location $location -IpConfiguration $ipcfg
    $actualNic = Get-AzNetworkInterface -ResourceGroupName $rgName -Name $nicName

    Assert-AreEqual $rgName $actualNic.ResourceGroupName
    Assert-AreEqual $nicName $actualNic.Name
    Assert-AreEqual "Succeeded" $actualNic.ProvisioningState

    $actualNic = Get-AzNetworkInterface -ResourceId $actualNic.Id
    Assert-AreEqual $rgName $actualNic.ResourceGroupName
    Assert-AreEqual $nicName $actualNic.Name
    Assert-AreEqual "Succeeded" $actualNic.ProvisioningState

    Assert-AreEqual 1 $actualNic.IpConfigurations.Count
    Assert-AreEqual $ipcfgName $actualNic.IpConfigurations[0].Name

    $actualPip = Get-AzPublicIpAddress -ResourceGroupName $rgName -Name $pipName
    Assert-AreEqual $rgName $actualPip.ResourceGroupName
    Assert-AreEqual $pipName $actualPip.Name
    Assert-AreEqual "Dynamic" $actualPip.PublicIpAllocationMethod
    Assert-AreEqual $actualPip.Id $actualNic.IpConfigurations[0].PublicIpAddress.Id

    $actualVnet = Get-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgName
    Assert-AreEqual $rgName $actualVnet.ResourceGroupName
    Assert-AreEqual $vnetName $actualVnet.Name
    Assert-AreEqual $actualVnet.Subnets[0].Id $actualNic.IpConfigurations[0].Subnet[0].Id

    Remove-AzNetworkInterface -ResourceGroupName $rgName -Name $nicName -Force
    $actual = Get-AzNetworkInterface -ResourceGroupName $rgName -Name $nicName -ErrorAction SilentlyContinue
    Assert-Null $actual
}

Invoke-LiveTestScenario -Name "Network interface CRUD without public IP address" -Description "Test CRUD for network interface without public IP address" -ScenarioScript `
{
    param ($rg)

    $rgName = $rg.ResourceGroupName
    $location = "eastus"
    $vnetName = New-LiveTestResourceName
    $snetName = New-LiveTestResourceName
    $nicName = New-LiveTestResourceName

    $snet = New-AzVirtualNetworkSubnetConfig -Name $snetName -AddressPrefix 10.0.1.0/24
    $vnet = New-AzVirtualNetwork -ResourceGroupName $rgName -Name $vnetName -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $snet

    New-AzNetworkInterface -ResourceGroupName $rgName -Name $nicName -Location $location -Subnet $vnet.Subnets[0]
    $actualNic = Get-AzNetworkInterface -ResourceGroupName $rgName -Name $nicName

    Assert-AreEqual $rgName $actualNic.ResourceGroupName
    Assert-AreEqual $nicName $actualNic.Name
    Assert-AreEqual "Succeeded" $actualNic.ProvisioningState

    Assert-AreEqual 1 $actualNic.IpConfigurations.Count
    Assert-Null $actualNic.IpConfigurations[0].PublicIpAddress.Id

    $actualVnet = Get-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgName
    Assert-AreEqual $rgName $actualVnet.ResourceGroupName
    Assert-AreEqual $vnetName $actualVnet.Name
    Assert-AreEqual $actualVnet.Subnets[0].Id $actualNic.IpConfigurations[0].Subnet[0].Id

    Remove-AzNetworkInterface -ResourceGroupName $rgName -Name $nicName -Force
    $actual = Get-AzNetworkInterface -ResourceGroupName $rgName -Name $nicName -ErrorAction SilentlyContinue
    Assert-Null $actual
}

Invoke-LiveTestScenario -Name "Network interface CRUD with IP configuration" -Description "Test CRUD for network interface with IP configuration" -ScenarioScript `
{
    param ($rg)

    $rgName = $rg.ResourceGroupName
    $location = "centralus"
    $vnetName = New-LiveTestResourceName
    $snetName = New-LiveTestResourceName
    $pipName = New-LiveTestResourceName
    $domainNameLabel = New-LiveTestResourceName
    $ipconfig1Name = New-LiveTestResourceName
    $ipconfig2Name = New-LiveTestResourceName
    $nicName = New-LiveTestResourceName

    $snet = New-AzVirtualNetworkSubnetConfig -Name $snetName -AddressPrefix 10.0.1.0/24
    $vnet = New-AzVirtualNetwork -ResourceGroupName $rgName -Name $vnetName -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $snet

    $pip = New-AzPublicIpAddress -ResourceGroupName $rgName -Name $pipName -Location $location -AllocationMethod Dynamic -DomainNameLabel $domainNameLabel
    $ipconfig1 = New-AzNetworkInterfaceIpConfig -Name $ipconfig1Name -Subnet $vnet.Subnets[0] -PublicIpAddress $pip
    $ipconfig2 = New-AzNetworkInterfaceIpConfig -Name $ipconfig2Name -PrivateIpAddressVersion IPv6

    New-AzNetworkInterface -ResourceGroupName $rgName -Name $nicName -Location $location -IpConfiguration $ipconfig1,$ipconfig2 -Tag @{ testtag = "testval" }

    $actualNic = Get-AzNetworkInterface -Name $nicName -ResourceGroupName $rgName
    Assert-AreEqual $rgName $actualNic.ResourceGroupName
    Assert-AreEqual $nicName $actualNic.Name
    Assert-AreEqual "Succeeded" $actualNic.ProvisioningState

    $actualPip = Get-AzPublicIpAddress -ResourceGroupName $rgName -Name $pipName
    Assert-AreEqual $rgName $actualPip.ResourceGroupName
    Assert-AreEqual $pipName $actualPip.Name
    Assert-AreEqual "Dynamic" $actualPip.PublicIpAllocationMethod
    Assert-AreEqual $actualPip.Id $actualNic.IpConfigurations[0].PublicIpAddress.Id

    $actualVnet = Get-AzVirtualNetwork -ResourceGroupName $rgName -Name $vnetName
    Assert-AreEqual $rgName $actualVnet.ResourceGroupName
    Assert-AreEqual $vnetName $actualVnet.Name
    Assert-AreEqual $actualVnet.Subnets[0].Id $actualNic.IpConfigurations[0].Subnet[0].Id

    Assert-AreEqual 2 $actualNic.IpConfigurations.Count

    Assert-AreEqual $ipconfig1Name $actualNic.IpConfigurations[0].Name
    Assert-AreEqual $pip.Id $actualNic.IpConfigurations[0].PublicIpAddress.Id
    Assert-AreEqual $actualVnet.Subnets[0].Id $actualNic.IpConfigurations[0].Subnet.Id
    Assert-AreEqual "Dynamic" $actualNic.IpConfigurations[0].PrivateIpAllocationMethod
    Assert-AreEqual IPv4 $actualNic.IpConfigurations[0].PrivateIpAddressVersion

    Assert-AreEqual $ipconfig2Name $actualNic.IpConfigurations[1].Name
    Assert-Null $actualNic.IpConfigurations[1].PublicIpAddress
    Assert-AreEqual IPv6 $actualNic.IpConfigurations[1].PrivateIpAddressVersion

    Remove-AzNetworkInterface -ResourceGroupName $rgName -Name $nicName -Force
    $actual = Get-AzNetworkInterface -ResourceGroupName $rgName -Name $nicName -ErrorAction SilentlyContinue
    Assert-Null $actual
}

Invoke-LiveTestScenario -Name "Network interface CRUD with accelerated networking" -Description "Test CRUD for network interface with accelerated networking" -ScenarioScript `
{
    param ($rg)

    $rgName = $rg.ResourceGroupName
    $location = "westus"
    $vnetName = New-LiveTestResourceName
    $snetName = New-LiveTestResourceName
    $pipName = New-LiveTestResourceName
    $domainNameLabel = New-LiveTestResourceName
    $ipcfgName = New-LiveTestResourceName
    $nicName = New-LiveTestResourceName

    $snet = New-AzVirtualNetworkSubnetConfig -Name $snetName -AddressPrefix 10.0.1.0/24
    $vnet = New-AzVirtualNetwork -ResourceGroupName $rgName -Name $vnetName -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $snet
    $pip = New-AzPublicIpAddress -ResourceGroupName $rgName -Name $pipName -Location $location -AllocationMethod Dynamic -DomainNameLabel $domainNameLabel
    $ipcfg = New-AzNetworkInterfaceIpConfig -Name $ipcfgName -Subnet $vnet.Subnets[0] -PublicIpAddress $pip
    New-AzNetworkInterface -ResourceGroupName $rgName -Name $nicName -Location $location -IpConfiguration $ipcfg -EnableAcceleratedNetworking

    $actualNic = Get-AzNetworkInterface -ResourceGroupName $rgName -Name $nicName
    Assert-AreEqual $rgName $actualNic.ResourceGroupName
    Assert-AreEqual $nicName $actualNic.Name
    Assert-AreEqual "Succeeded" $actualNic.ProvisioningState

    Assert-AreEqual 1 $actualNic.IpConfigurations.Count
    Assert-AreEqual $ipcfgName $actualNic.IpConfigurations[0].Name
    Assert-AreEqual $true $actualNic.EnableAcceleratedNetworking

    $actualPip = Get-AzPublicIpAddress -ResourceGroupName $rgname -name $pipName
    Assert-AreEqual $rgName $actualPip.ResourceGroupName
    Assert-AreEqual $pipName $actualPip.Name
    Assert-AreEqual "Dynamic" $actualPip.PublicIpAllocationMethod
    Assert-AreEqual $actualPip.Id $actualNic.IpConfigurations[0].PublicIpAddress.Id

    $actualVnet = Get-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgName
    Assert-AreEqual $rgName $actualVnet.ResourceGroupName
    Assert-AreEqual $vnetName $actualVnet.Name
    Assert-AreEqual $actualVnet.Subnets[0].Id $actualNic.IpConfigurations[0].Subnet[0].Id

    Remove-AzNetworkInterface -ResourceGroupName $rgName -Name $nicName -Force
    $actual = Get-AzNetworkInterface -ResourceGroupName $rgName -Name $nicName -ErrorAction SilentlyContinue
    Assert-Null $actual
}

Invoke-LiveTestScenario -Name "Network private link service" -Description "Test CRUD for network private link service" -ScenarioScript `
{
    param ($rg)

    $rgName = $rg.ResourceGroupName
    $location = "westus"
    $vnetName = New-LiveTestResourceName
    $feSnetName = New-LiveTestResourceName
    $beSnetName = New-LiveTestResourceName
    $oSnetName = New-LiveTestResourceName
    $lbIpCfgName = New-LiveTestResourceName
    $lbPoolCfgName = New-LiveTestResourceName
    $lbName = New-LiveTestResourceName
    $plsIpCfgName = New-LiveTestResourceName
    $plsName = New-LiveTestResourceName

    $feSubnet = New-AzVirtualNetworkSubnetConfig -Name $feSnetName -AddressPrefix 10.0.1.0/24
    $beSubnet = New-AzVirtualNetworkSubnetConfig -Name $beSnetName -AddressPrefix 10.0.2.0/24
    $oSubnet = New-AzVirtualNetworkSubnetConfig -Name $oSnetName -AddressPrefix 10.0.3.0/24 -PrivateLinkServiceNetworkPoliciesFlag Disabled
    $vnet = New-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgName -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $feSubnet,$beSubnet,$oSubnet

    $lbIpCfg = New-AzLoadBalancerFrontendIpConfig -Name $lbIpCfgName -PrivateIpAddress 10.0.1.5 -Subnet $vnet.Subnets[0]
    $lbPoolCfg = New-AzLoadBalancerBackendAddressPoolConfig -Name $lbPoolCfgName
    New-AzLoadBalancer -Name $lbName -ResourceGroupName $rgName -Location $location -FrontendIpConfiguration $lbIpCfg -BackendAddressPool $lbPoolCfg -Sku Standard

    $plsIpCfg = New-AzPrivateLinkServiceIpConfig -Name $plsIpCfgName -PrivateIpAddress 10.0.3.5 -Subnet $vnet.Subnets[2]

    $actualPls = New-AzPrivateLinkService -Name $plsName -ResourceGroupName $rgName -Location $location -LoadBalancerFrontendIpConfiguration $lbIpCfg -IpConfiguration $plsIpCfg

    Assert-AreEqual $actualPls.Name $plsName
    Assert-AreEqual $actualPls.ResourceGroupName $rgName
    Assert-AreEqual $actualPls.Location $location

    Remove-AzPrivateLinkService -Name $plsName -ResourceGroupName $rgName -Force
    $actualPls = Get-AzPrivateLinkService -Name $plsName -ResourceGroupName $rgName -ErrorAction SilentlyContinue
    Assert-Null $actualPls
}

Invoke-LiveTestScenario -Name "Create network load balancer" -Description "Test creating a network load balancer" -ScenarioScript `
{
    param ($rg)

    $rgName = $rg.ResourceGroupName
    $location = "westus"
    $publicIpName = New-LiveTestResourceName
    $feIpCfgName = New-LiveTestResourceName
    $bePoolCfgName = New-LiveTestResourceName
    $probeName = New-LiveTestResourceName
    $lbRuleName = New-LiveTestResourceName
    $lbName = New-LiveTestResourceName

    $publicIp = New-AzPublicIpAddress -ResourceGroupName $rgName -Name $publicIpName -Location $location -AllocationMethod Dynamic
    $feIpCfg = New-AzLoadBalancerFrontendIpConfig -Name $feIpCfgName -PublicIpAddress $publicIp
    $bePoolCfg = New-AzLoadBalancerBackendAddressPoolConfig -Name $bePoolCfgName
    $probe = New-AzLoadBalancerProbeConfig -Name $probeName -Protocol "Http" -Port 80 -RequestPath "healthcheck.aspx" -IntervalInSeconds 15 -ProbeCount 5 -ProbeThreshold 5
    $lbRule = New-AzLoadBalancerRuleConfig -Name $lbRuleName -FrontendIpConfiguration $feIpCfg -BackendAddressPool $bePoolCfg -Protocol "Tcp" -FrontendPort 80 -BackendPort 80 -IdleTimeoutInMinutes 5 -EnableFloatingIP -LoadDistribution "SourceIP"
    New-AzLoadBalancer -ResourceGroupName $rgName -Name $lbName -Location $location -FrontendIpConfiguration $feIpCfg -BackendAddressPool $bePoolCfg -Probe $probe -LoadBalancingRule $lbRule

    $actual = Get-AzLoadBalancer -ResourceGroupName $rgName -Name $lbName
    Assert-NotNull $actual
    Assert-AreEqual $rgName $actual.ResourceGroupName
    Assert-AreEqual $lbName $actual.Name
    Assert-AreEqual $location $actual.Location
    Assert-AreEqual "Succeeded" $actual.ProvisioningState

    Assert-AreEqual 1 $actual.Probes.Count
    Assert-AreEqual "Http" $actual.Probes[0].Protocol
    Assert-AreEqual 80 $actual.Probes[0].Port

    Assert-AreEqual 1 $actual.LoadBalancingRules.Count
    Assert-AreEqual "Tcp" $actual.LoadBalancingRules[0].Protocol
    Assert-AreEqual 80 $actual.LoadBalancingRules[0].FrontendPort
    Assert-AreEqual 80 $actual.LoadBalancingRules[0].BackendPort
}

Invoke-LiveTestScenario -Name "Update network load balancer" -Description "Test updating an existing network load balancer" -ScenarioScript `
{
    param ($rg)

    $rgName = $rg.ResourceGroupName
    $location = "eastus"
    $publicIpName = New-LiveTestResourceName
    $feIpCfgName = New-LiveTestResourceName
    $bePoolCfgName = New-LiveTestResourceName
    $probeName1 = New-LiveTestResourceName
    $probeName2 = New-LiveTestResourceName
    $lbRuleName = New-LiveTestResourceName
    $lbName = New-LiveTestResourceName
    $natRuleName = New-LiveTestResourceName

    $publicIp = New-AzPublicIpAddress -ResourceGroupName $rgName -Name $publicIpName -Location $location -AllocationMethod Dynamic
    $feIpCfg = New-AzLoadBalancerFrontendIpConfig -Name $feIpCfgName -PublicIpAddress $publicIp
    $bePoolCfg = New-AzLoadBalancerBackendAddressPoolConfig -Name $bePoolCfgName
    $probe = New-AzLoadBalancerProbeConfig -Name $probeName1 -Protocol "Http" -Port 80 -RequestPath "healthcheck80.aspx" -IntervalInSeconds 15 -ProbeCount 5 -ProbeThreshold 5
    $lbRule = New-AzLoadBalancerRuleConfig -Name $lbRuleName -FrontendIpConfiguration $feIpCfg -BackendAddressPool $bePoolCfg -Protocol "Tcp" -FrontendPort 80 -BackendPort 80 -IdleTimeoutInMinutes 5 -EnableFloatingIP -LoadDistribution "SourceIP"
    New-AzLoadBalancer -ResourceGroupName $rgName -Name $lbName -Location $location -FrontendIpConfiguration $feIpCfg -BackendAddressPool $bePoolCfg -Probe $probe -LoadBalancingRule $lbRule
    $lb = Get-AzLoadBalancer -ResourceGroupName $rgName -Name $lbName

    $lb | Add-AzLoadBalancerProbeConfig -Name $probeName2 -Protocol "Http" -Port 443 -RequestPath "healthcheck443.aspx" -IntervalInSeconds 10 -ProbeCount 3 -ProbeThreshold 3
    $lb | Add-AzLoadBalancerInboundNatRuleConfig -Name $natRuleName -FrontendIPConfiguration $lb.FrontendIpConfigurations[0] -Protocol "Tcp" -FrontendPort 3350 -BackendPort 3350 -EnableFloatingIP
    $lb | Set-AzLoadBalancerRuleConfig -Name $lbRuleName -FrontendIPConfiguration $lb.FrontendIpConfigurations[0] -Protocol "Tcp" -FrontendPort 8080 -BackendPort 8080
    $lb | Set-AzLoadBalancer

    $actual = Get-AzLoadBalancer -ResourceGroupName $rgName -Name $lbName
    Assert-NotNull $actual
    Assert-AreEqual $rgName $actual.ResourceGroupName
    Assert-AreEqual $lbName $actual.Name
    Assert-AreEqual $location $actual.Location
    Assert-AreEqual "Succeeded" $actual.ProvisioningState

    Assert-AreEqual 1 $actual.LoadBalancingRules.Count
    Assert-AreEqual "Tcp" $actual.LoadBalancingRules[0].Protocol
    Assert-AreEqual 8080 $actual.LoadBalancingRules[0].FrontendPort
    Assert-AreEqual 8080 $actual.LoadBalancingRules[0].BackendPort

    Assert-AreEqual 1 $actual.InboundNatRules.Count
    Assert-AreEqual "Tcp" $actual.InboundNatRules[0].Protocol
    Assert-AreEqual 3350 $actual.InboundNatRules[0].FrontendPort
    Assert-AreEqual 3350 $actual.InboundNatRules[0].BackendPort

    Assert-AreEqual 2 $actual.Probes.Count
}

Invoke-LiveTestScenario -Name "Remove network load balancer" -Description "Test removing a network load balancer" -ScenarioScript `
{
    param ($rg)

    $rgName = $rg.ResourceGroupName
    $location = "centralus"
    $publicIpName = New-LiveTestResourceName
    $feIpCfgName = New-LiveTestResourceName
    $bePoolCfgName = New-LiveTestResourceName
    $probeName = New-LiveTestResourceName
    $lbRuleName = New-LiveTestResourceName
    $lbName = New-LiveTestResourceName

    $publicIp = New-AzPublicIpAddress -ResourceGroupName $rgName -Name $publicIpName -Location $location -AllocationMethod Dynamic
    $feIpCfg = New-AzLoadBalancerFrontendIpConfig -Name $feIpCfgName -PublicIpAddress $publicIp
    $bePoolCfg = New-AzLoadBalancerBackendAddressPoolConfig -Name $bePoolCfgName
    $probe = New-AzLoadBalancerProbeConfig -Name $probeName -Protocol "Http" -Port 80 -RequestPath "healthcheck.aspx" -IntervalInSeconds 15 -ProbeCount 5 -ProbeThreshold 5
    $lbRule = New-AzLoadBalancerRuleConfig -Name $lbRuleName -FrontendIpConfiguration $feIpCfg -BackendAddressPool $bePoolCfg -Protocol "Tcp" -FrontendPort 80 -BackendPort 80 -IdleTimeoutInMinutes 5 -EnableFloatingIP -LoadDistribution "SourceIP"
    New-AzLoadBalancer -ResourceGroupName $rgName -Name $lbName -Location $location -FrontendIpConfiguration $feIpCfg -BackendAddressPool $bePoolCfg -Probe $probe -LoadBalancingRule $lbRule

    Remove-AzLoadBalancer -ResourceGroupName $rgName -Name $lbName -Force
    $actual = Get-AzLoadBalancer -ResourceGroupName $rgName -Name $lbName -ErrorAction SilentlyContinue
    Assert-Null $actual
}

Invoke-LiveTestScenario -Name "Create virtual network" -Description "Test creating a virtual network" -ScenarioScript `
{
    param ($rg)

    $rgName = $rg.ResourceGroupName
    $location = "westus"
    $feSnetName = New-LiveTestResourceName
    $beSnetName = New-LiveTestResourceName
    $vnetName = New-LiveTestResourceName

    $feSnet = New-AzVirtualNetworkSubnetConfig -Name $feSnetName -AddressPrefix "10.0.1.0/24"
    $beSnet = New-AzVirtualNetworkSubnetConfig -Name $beSnetName -AddressPrefix "10.0.2.0/24"
    New-AzVirtualNetwork -ResourceGroupName $rgName -Name $vnetName -Location $location -AddressPrefix "10.0.0.0/16" -Subnet $feSnet, $beSnet -DnsServer 10.0.1.10, 10.0.1.11

    $actual = Get-AzVirtualNetwork -ResourceGroupName $rgName -Name $vnetName
    Assert-NotNull $actual
    Assert-AreEqual $rgName $actual.ResourceGroupName
    Assert-AreEqual $vnetName $actual.Name
    Assert-AreEqual $location $actual.Location
    Assert-AreEqual "Succeeded" $actual.ProvisioningState
    Assert-AreEqual 1 $actual.AddressSpace.AddressPrefixes.Count
    Assert-AreEqual "10.0.0.0/16" $actual.AddressSpace.AddressPrefixes[0]
    Assert-AreEqual 2 $actual.Subnets.Count
}

Invoke-LiveTestScenario -Name "Update virtual network" -Description "Test updating an existing virtual network" -ScenarioScript `
{
    param ($rg)

    $rgName = $rg.ResourceGroupName
    $location = "eastus"
    $feSnetName = New-LiveTestResourceName
    $beSnetName = New-LiveTestResourceName
    $vnetName = New-LiveTestResourceName

    $feSnet = New-AzVirtualNetworkSubnetConfig -Name $feSnetName -AddressPrefix "10.0.1.0/24"
    New-AzVirtualNetwork -ResourceGroupName $rgName -Name $vnetName -Location $location -AddressPrefix "10.0.0.0/16" -Subnet $feSnet

    $vnet = Get-AzVirtualNetwork -ResourceGroupName $rgName -Name $vnetName
    Assert-NotNull $vnet
    Assert-AreEqual $rgName $vnet.ResourceGroupName
    Assert-AreEqual $vnetName $vnet.Name
    Assert-AreEqual $location $vnet.Location
    Assert-AreEqual "Succeeded" $vnet.ProvisioningState
    Assert-AreEqual 1 $vnet.Subnets.Count

    $vnet | Add-AzVirtualNetworkSubnetConfig -Name $beSnetName -AddressPrefix "10.0.2.0/24"
    $vnet | Remove-AzVirtualNetworkSubnetConfig -Name $feSnetName
    $vnet | Set-AzVirtualNetwork

    $actual = Get-AzVirtualNetwork -ResourceGroupName $rgName -Name $vnetName
    Assert-NotNull $actual
    Assert-AreEqual $rgName $actual.ResourceGroupName
    Assert-AreEqual $vnetName $actual.Name
    Assert-AreEqual $location $actual.Location
    Assert-AreEqual "Succeeded" $actual.ProvisioningState
    Assert-AreEqual 1 $actual.Subnets.Count
    Assert-AreEqual $beSnetName $actual.Subnets[0].Name
}

Invoke-LiveTestScenario -Name "Remove virtual network" -Description "Test removing a virtual network" -ScenarioScript `
{
    param ($rg)

    $rgName = $rg.ResourceGroupName
    $location = "centralus"
    $feSnetName = New-LiveTestResourceName
    $beSnetName = New-LiveTestResourceName
    $vnetName = New-LiveTestResourceName

    $feSnet = New-AzVirtualNetworkSubnetConfig -Name $feSnetName -AddressPrefix "10.0.1.0/24"
    $beSnet = New-AzVirtualNetworkSubnetConfig -Name $beSnetName -AddressPrefix "10.0.2.0/24"
    New-AzVirtualNetwork -ResourceGroupName $rgName -Name $vnetName -Location $location -AddressPrefix "10.0.0.0/16" -Subnet $feSnet, $beSnet
    Remove-AzVirtualNetwork -ResourceGroupName $rgName -Name $vnetName -Force

    $actual = Get-AzVirtualNetwork -ResourceGroupName $rgName -Name $vnetName -ErrorAction SilentlyContinue
    Assert-Null $actual
}

Invoke-LiveTestScenario -Name "Create private DNS zone group" -Description "Test creating a private DNS zone group" -ScenarioScript `
{
    param ($rg)

    $rgName = $rg.ResourceGroupName
    $location = "westus"
    $feSnetName = New-LiveTestResourceName
    $beSnetName = New-LiveTestResourceName
    $oSnetName = New-LiveTestResourceName
    $vnetName = New-LiveTestResourceName
    $feIpCfgName = New-LiveTestResourceName
    $bePoolCfgName = New-LiveTestResourceName
    $lbName = New-LiveTestResourceName
    $plsIpCfgName = New-LiveTestResourceName
    $plsName = New-LiveTestResourceName
    $plsConnName = New-LiveTestResourceName
    $peName = New-LiveTestResourceName

    $r5l = New-LiveTestRandomName -Option AllLetters -MaxLength 5
    $zoneName = "$r5l.private.contoso.com"
    $zoneCfgName = New-LiveTestResourceName
    $zoneGroupName = New-LiveTestResourceName

    $feSnet = New-AzVirtualNetworkSubnetConfig -Name $feSnetName -AddressPrefix "10.0.1.0/24" -PrivateEndpointNetworkPoliciesFlag Disabled -PrivateLinkServiceNetworkPoliciesFlag Disabled
    $beSnet = New-AzVirtualNetworkSubnetConfig -Name $beSnetName -AddressPrefix "10.0.2.0/24" -PrivateEndpointNetworkPoliciesFlag Disabled -PrivateLinkServiceNetworkPoliciesFlag Disabled
    $oSnet = New-AzVirtualNetworkSubnetConfig -Name $oSnetName -AddressPrefix "10.0.3.0/24" -PrivateEndpointNetworkPoliciesFlag Disabled -PrivateLinkServiceNetworkPoliciesFlag Disabled
    $vnet = New-AzVirtualNetwork -ResourceGroupName $rgName -Name $vnetName -Location $location -AddressPrefix "10.0.0.0/16" -Subnet $feSnet, $beSnet, $oSnet
    $feSnet = $vnet.Subnets | Where-Object Name -eq $feSnetName
    $oSnet = $vnet.Subnets | Where-Object Name -eq $oSnetName
    $feIpCfg = New-AzLoadBalancerFrontendIpConfig -Name $feIpCfgName -Subnet $feSnet -PrivateIpAddress "10.0.1.10"
    $bePoolCfg = New-AzLoadBalancerBackendAddressPoolConfig -Name $bePoolCfgName
    $lb = New-AzLoadBalancer -ResourceGroupName $rgName -Name $lbName -Location $location -FrontendIpConfiguration $feIpCfg -BackendAddressPool $bePoolCfg -Sku Standard
    $plsIpCfg = New-AzPrivateLinkServiceIpConfig -Name $plsIpCfgName -PrivateIpAddress "10.0.3.10" -Subnet $oSnet
    $feIpCfg = $lb | Get-AzLoadBalancerFrontendIpConfig
    $pls = New-AzPrivateLinkService -ResourceGroupName $rgName -Name $plsName -Location $location -IpConfiguration $plsIpCfg -LoadBalancerFrontendIpConfiguration $feIpCfg
    $plsConn = New-AzPrivateLinkServiceConnection -Name $plsConnName -PrivateLinkServiceId $pls.Id
    New-AzPrivateEndpoint -ResourceGroupName $rgName -Name $peName -Location $location -Subnet $feSnet -PrivateLinkServiceConnection $plsConn

    New-AzPrivateDnsZone -ResourceGroupName $rgName -Name $zoneName
    $zone = Get-AzPrivateDnsZone  -ResourceGroupName $rgName -Name $zoneName
    $zoneCfg = New-AzPrivateDnsZoneConfig -Name $zoneCfgName -PrivateDnsZoneId $zone.ResourceId
    New-AzPrivateDnsZoneGroup -ResourceGroupName $rgName -Name $zoneGroupName -PrivateEndpointName $peName -PrivateDnsZoneConfig $zoneCfg

    $actual = Get-AzPrivateDnsZoneGroup -ResourceGroupName $rgName -Name $zoneGroupName -PrivateEndpointName $peName
    Assert-NotNull $actual
    Assert-AreEqual $zoneGroupName $actual.Name
    Assert-AreEqual "Succeeded" $actual.ProvisioningState
    Assert-AreEqual 1 $actual.PrivateDnsZoneConfigs.Count
    Assert-AreEqual $zoneCfgName $actual.PrivateDnsZoneConfigs[0].Name
    Assert-AreEqual $zone.ResourceId $actual.PrivateDnsZoneConfigs[0].PrivateDnsZoneId
}

Invoke-LiveTestScenario -Name "Update private DNS zone group" -Description "Test updating an existing private DNS zone group with different zone config" -ScenarioScript `
{
    param ($rg)

    $rgName = $rg.ResourceGroupName
    $location = "eastus"
    $feSnetName = New-LiveTestResourceName
    $beSnetName = New-LiveTestResourceName
    $oSnetName = New-LiveTestResourceName
    $vnetName = New-LiveTestResourceName
    $feIpCfgName = New-LiveTestResourceName
    $bePoolCfgName = New-LiveTestResourceName
    $lbName = New-LiveTestResourceName
    $plsIpCfgName = New-LiveTestResourceName
    $plsName = New-LiveTestResourceName
    $plsConnName = New-LiveTestResourceName
    $peName = New-LiveTestResourceName

    $r5l1 = New-LiveTestRandomName -Option AllLetters -MaxLength 5
    $zoneName1 = "$r5l1.private.contoso.com"
    $zoneCfgName1 = New-LiveTestResourceName
    $zoneGroupName = New-LiveTestResourceName

    $feSnet = New-AzVirtualNetworkSubnetConfig -Name $feSnetName -AddressPrefix "10.0.1.0/24" -PrivateEndpointNetworkPoliciesFlag Disabled -PrivateLinkServiceNetworkPoliciesFlag Disabled
    $beSnet = New-AzVirtualNetworkSubnetConfig -Name $beSnetName -AddressPrefix "10.0.2.0/24" -PrivateEndpointNetworkPoliciesFlag Disabled -PrivateLinkServiceNetworkPoliciesFlag Disabled
    $oSnet = New-AzVirtualNetworkSubnetConfig -Name $oSnetName -AddressPrefix "10.0.3.0/24" -PrivateEndpointNetworkPoliciesFlag Disabled -PrivateLinkServiceNetworkPoliciesFlag Disabled
    $vnet = New-AzVirtualNetwork -ResourceGroupName $rgName -Name $vnetName -Location $location -AddressPrefix "10.0.0.0/16" -Subnet $feSnet, $beSnet, $oSnet
    $feSnet = $vnet.Subnets | Where-Object Name -eq $feSnetName
    $oSnet = $vnet.Subnets | Where-Object Name -eq $oSnetName
    $feIpCfg = New-AzLoadBalancerFrontendIpConfig -Name $feIpCfgName -Subnet $feSnet -PrivateIpAddress "10.0.1.10"
    $bePoolCfg = New-AzLoadBalancerBackendAddressPoolConfig -Name $bePoolCfgName
    $lb = New-AzLoadBalancer -ResourceGroupName $rgName -Name $lbName -Location $location -FrontendIpConfiguration $feIpCfg -BackendAddressPool $bePoolCfg -Sku Standard
    $plsIpCfg = New-AzPrivateLinkServiceIpConfig -Name $plsIpCfgName -PrivateIpAddress "10.0.3.10" -Subnet $oSnet
    $feIpCfg = $lb | Get-AzLoadBalancerFrontendIpConfig
    $pls = New-AzPrivateLinkService -ResourceGroupName $rgName -Name $plsName -Location $location -IpConfiguration $plsIpCfg -LoadBalancerFrontendIpConfiguration $feIpCfg
    $plsConn = New-AzPrivateLinkServiceConnection -Name $plsConnName -PrivateLinkServiceId $pls.Id
    New-AzPrivateEndpoint -ResourceGroupName $rgName -Name $peName -Location $location -Subnet $feSnet -PrivateLinkServiceConnection $plsConn

    $zone1 = New-AzPrivateDnsZone -ResourceGroupName $rgName -Name $zoneName1
    $zoneCfg1 = New-AzPrivateDnsZoneConfig -Name $zoneCfgName1 -PrivateDnsZoneId $zone1.ResourceId
    New-AzPrivateDnsZoneGroup -ResourceGroupName $rgName -Name $zoneGroupName -PrivateEndpointName $peName -PrivateDnsZoneConfig $zoneCfg1

    $r5l2 = New-LiveTestRandomName -Option AllLetters -MaxLength 5
    $zoneName2 = "$r5l2.private.contoso.com"
    $zoneCfgName2 = New-LiveTestResourceName

    $zone2 = New-AzPrivateDnsZone -ResourceGroupName $rgName -Name $zoneName2
    $zoneCfg2 = New-AzPrivateDnsZoneConfig -Name $zoneCfgName2 -PrivateDnsZoneId $zone2.ResourceId
    Set-AzPrivateDnsZoneGroup -ResourceGroupName $rgName -Name $zoneGroupName -PrivateEndpointName $peName -PrivateDnsZoneConfig $zoneCfg2

    $actual = Get-AzPrivateDnsZoneGroup -ResourceGroupName $rgName -Name $zoneGroupName -PrivateEndpointName $peName
    Assert-NotNull $actual
    Assert-AreEqual $zoneGroupName $actual.Name
    Assert-AreEqual "Succeeded" $actual.ProvisioningState
    Assert-AreEqual 1 $actual.PrivateDnsZoneConfigs.Count
    Assert-AreEqual $zoneCfgName2 $actual.PrivateDnsZoneConfigs[0].Name
    Assert-AreEqual $zone2.ResourceId $actual.PrivateDnsZoneConfigs[0].PrivateDnsZoneId
}

Invoke-LiveTestScenario -Name "Remove private DNS zone group" -Description "Test removing a private DNS zone group" -ScenarioScript `
{
    param ($rg)

    $rgName = $rg.ResourceGroupName
    $location = "eastus"
    $feSnetName = New-LiveTestResourceName
    $beSnetName = New-LiveTestResourceName
    $oSnetName = New-LiveTestResourceName
    $vnetName = New-LiveTestResourceName
    $feIpCfgName = New-LiveTestResourceName
    $bePoolCfgName = New-LiveTestResourceName
    $lbName = New-LiveTestResourceName
    $plsIpCfgName = New-LiveTestResourceName
    $plsName = New-LiveTestResourceName
    $plsConnName = New-LiveTestResourceName
    $peName = New-LiveTestResourceName

    $r5l = New-LiveTestRandomName -Option AllLetters -MaxLength 5
    $zoneName = "$r5l.private.contoso.com"
    $zoneCfgName = New-LiveTestResourceName
    $zoneGroupName = New-LiveTestResourceName

    $feSnet = New-AzVirtualNetworkSubnetConfig -Name $feSnetName -AddressPrefix "10.0.1.0/24" -PrivateEndpointNetworkPoliciesFlag Disabled -PrivateLinkServiceNetworkPoliciesFlag Disabled
    $beSnet = New-AzVirtualNetworkSubnetConfig -Name $beSnetName -AddressPrefix "10.0.2.0/24" -PrivateEndpointNetworkPoliciesFlag Disabled -PrivateLinkServiceNetworkPoliciesFlag Disabled
    $oSnet = New-AzVirtualNetworkSubnetConfig -Name $oSnetName -AddressPrefix "10.0.3.0/24" -PrivateEndpointNetworkPoliciesFlag Disabled -PrivateLinkServiceNetworkPoliciesFlag Disabled
    $vnet = New-AzVirtualNetwork -ResourceGroupName $rgName -Name $vnetName -Location $location -AddressPrefix "10.0.0.0/16" -Subnet $feSnet, $beSnet, $oSnet
    $feSnet = $vnet.Subnets | Where-Object Name -eq $feSnetName
    $oSnet = $vnet.Subnets | Where-Object Name -eq $oSnetName
    $feIpCfg = New-AzLoadBalancerFrontendIpConfig -Name $feIpCfgName -Subnet $feSnet -PrivateIpAddress "10.0.1.10"
    $bePoolCfg = New-AzLoadBalancerBackendAddressPoolConfig -Name $bePoolCfgName
    $lb = New-AzLoadBalancer -ResourceGroupName $rgName -Name $lbName -Location $location -FrontendIpConfiguration $feIpCfg -BackendAddressPool $bePoolCfg -Sku Standard
    $plsIpCfg = New-AzPrivateLinkServiceIpConfig -Name $plsIpCfgName -PrivateIpAddress "10.0.3.10" -Subnet $oSnet
    $feIpCfg = $lb | Get-AzLoadBalancerFrontendIpConfig
    $pls = New-AzPrivateLinkService -ResourceGroupName $rgName -Name $plsName -Location $location -IpConfiguration $plsIpCfg -LoadBalancerFrontendIpConfiguration $feIpCfg
    $plsConn = New-AzPrivateLinkServiceConnection -Name $plsConnName -PrivateLinkServiceId $pls.Id
    New-AzPrivateEndpoint -ResourceGroupName $rgName -Name $peName -Location $location -Subnet $feSnet -PrivateLinkServiceConnection $plsConn

    New-AzPrivateDnsZone -ResourceGroupName $rgName -Name $zoneName
    $zone = Get-AzPrivateDnsZone -ResourceGroupName $rgName -Name $zoneName
    $zoneCfg = New-AzPrivateDnsZoneConfig -Name $zoneCfgName -PrivateDnsZoneId $zone.ResourceId
    New-AzPrivateDnsZoneGroup -ResourceGroupName $rgName -Name $zoneGroupName -PrivateEndpointName $peName -PrivateDnsZoneConfig $zoneCfg

    Remove-AzPrivateDnsZoneGroup -ResourceGroupName $rgName -Name $zoneGroupName -PrivateEndpointName $peName -Force

    $actual = Get-AzPrivateDnsZoneGroup -ResourceGroupName $rgName -Name $zoneGroupName -PrivateEndpointName $peName -ErrorAction SilentlyContinue
    Assert-Null $actual
}
