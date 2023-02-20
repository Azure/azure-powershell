Invoke-LiveTestScenario -Name "Network interface CRUD with public IP address" -Description "Test CRUD for network interface with public IP address" -ScenarioScript `
{
    param ($rg)

    $rgName = $rg.ResourceGroupName
    $location = "westus"
    $vnetName = New-LiveTestResourceName
    $subnetName = New-LiveTestResourceName
    $publicIpName = New-LiveTestResourceName
    $domainNameLabel = New-LiveTestResourceName
    $nicName = New-LiveTestResourceName

    $subnet = New-AzVirtualNetworkSubnetConfig -Name $subnetName -AddressPrefix 10.0.1.0/24
    $vnet = New-AzVirtualNetwork -ResourceGroupName $rgName -Name $vnetName -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnet
    $publicIp = New-AzPublicIpAddress -ResourceGroupName $rgName -Name $publicIpName -Location $location -AllocationMethod Dynamic -DomainNameLabel $domainNameLabel

    $expectedNic = New-AzNetworkInterface -ResourceGroupName $rgName -Name $nicName -Location $location -Subnet $vnet.Subnets[0] -PublicIpAddress $publicIp
    $actualNic = Get-AzNetworkInterface -ResourceGroupName $rgName -Name $nicName

    Assert-AreEqual $expectedNic.ResourceGroupName $actualNic.ResourceGroupName
    Assert-AreEqual $expectedNic.Name $actualNic.Name
    Assert-AreEqual $expectedNic.Location $actualNic.Location
    Assert-NotNull $expectedNic.ResourceGuid
    Assert-AreEqual "Succeeded" $expectedNic.ProvisioningState
    Assert-AreEqual $expectedNic.IpConfigurations[0].Name $actualNic.IpConfigurations[0].Name
    Assert-AreEqual $expectedNic.IpConfigurations[0].PublicIpAddress.Id $actualNic.IpConfigurations[0].PublicIpAddress.Id
    Assert-AreEqual $expectedNic.IpConfigurations[0].Subnet.Id $actualNic.IpConfigurations[0].Subnet.Id
    Assert-NotNull $expectedNic.IpConfigurations[0].PrivateIpAddress
    Assert-AreEqual "Dynamic" $expectedNic.IpConfigurations[0].PrivateIpAllocationMethod

    $actualNicByResourceId = Get-AzNetworkInterface -ResourceId $actualNic.Id

    Assert-AreEqual $expectedNic.ResourceGroupName $actualNicByResourceId.ResourceGroupName
    Assert-AreEqual $expectedNic.Name $actualNicByResourceId.Name
    Assert-AreEqual $expectedNic.Location $actualNicByResourceId.Location
    Assert-NotNull $actualNicByResourceId.ResourceGuid
    Assert-AreEqual "Succeeded" $actualNicByResourceId.ProvisioningState
    Assert-AreEqual $expectedNic.IpConfigurations[0].Name $actualNicByResourceId.IpConfigurations[0].Name
    Assert-AreEqual $expectedNic.IpConfigurations[0].PublicIpAddress.Id $actualNicByResourceId.IpConfigurations[0].PublicIpAddress.Id
    Assert-AreEqual $expectedNic.IpConfigurations[0].Subnet.Id $actualNicByResourceId.IpConfigurations[0].Subnet.Id
    Assert-NotNull $actualNicByResourceId.IpConfigurations[0].PrivateIpAddress
    Assert-AreEqual "Dynamic" $actualNicByResourceId.IpConfigurations[0].PrivateIpAllocationMethod

    $actualPublicIp = Get-AzPublicIpAddress -ResourceGroupName $rgName -Name $publicIpName
    Assert-AreEqual $expectedNic.IpConfigurations[0].PublicIpAddress.Id $actualPublicIp.Id
    Assert-AreEqual $expectedNic.IpConfigurations[0].Id $actualPublicIp.IpConfiguration.Id

    $actualVnet = Get-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgName
    Assert-AreEqual $expectedNic.IpConfigurations[0].Subnet.Id $actualVnet.Subnets[0].Id
    Assert-AreEqual $expectedNic.IpConfigurations[0].Id $actualVnet.Subnets[0].IpConfigurations[0].Id

    $nicList = Get-AzNetworkInterface -ResourceGroupName $rgName
    Assert-AreEqual 1 @($nicList).Count
    Assert-AreEqual $nicList[0].ResourceGroupName $actualNic.ResourceGroupName
    Assert-AreEqual $nicList[0].Name $actualNic.Name
    Assert-AreEqual $nicList[0].Location $actualNic.Location
    Assert-AreEqual "Succeeded" $nicList[0].ProvisioningState
    Assert-AreEqual $actualNic.Etag $nicList[0].Etag

    $deleteResult = Remove-AzNetworkInterface -ResourceGroupName $rgName -Name $nicName -PassThru -Force
    Assert-AreEqual true $deleteResult

    $nicList = Get-AzNetworkInterface -ResourceGroupName $rgName
    Assert-AreEqual 0 @($nicList).Count
}

Invoke-LiveTestScenario -Name "Network interface CRUD without public IP address" -Description "Test CRUD for network interface without public IP address" -ScenarioScript `
{
    param ($rg)

    $rgName = $rg.ResourceGroupName
    $location = "westus"
    $vnetName = New-LiveTestResourceName
    $subnetName = New-LiveTestResourceName
    $nicName = New-LiveTestResourceName

    $subnet = New-AzVirtualNetworkSubnetConfig -Name $subnetName -AddressPrefix 10.0.1.0/24
    $vnet = New-AzVirtualNetwork -ResourceGroupName $rgName -Name $vnetName -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnet

    $expectedNic = New-AzNetworkInterface -ResourceGroupName $rgName -Name $nicName -Location $location -Subnet $vnet.Subnets[0]
    $actualNic = Get-AzNetworkInterface -ResourceGroupName $rgName -Name $nicName

    Assert-AreEqual $expectedNic.ResourceGroupName $actualNic.ResourceGroupName
    Assert-AreEqual $expectedNic.Name $actualNic.Name
    Assert-AreEqual $expectedNic.Location $actualNic.Location
    Assert-AreEqual "Succeeded" $expectedNic.ProvisioningState
    Assert-AreEqual $expectedNic.IpConfigurations[0].Name $actualNic.IpConfigurations[0].Name
    Assert-Null $expectedNic.IpConfigurations[0].PublicIpAddress.Id
    Assert-AreEqual $expectedNic.IpConfigurations[0].Subnet.Id $actualNic.IpConfigurations[0].Subnet.Id

    $actuaVnet = Get-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgName
    Assert-AreEqual $expectedNic.IpConfigurations[0].Subnet.Id $actuaVnet.Subnets[0].Id
    Assert-AreEqual $expectedNic.IpConfigurations[0].Id $actuaVnet.Subnets[0].IpConfigurations[0].Id

    $nicList = Get-AzNetworkInterface -ResourceGroupName $rgName
    Assert-AreEqual 1 @($nicList).Count
    Assert-AreEqual $nicList[0].ResourceGroupName $actualNic.ResourceGroupName
    Assert-AreEqual $nicList[0].Name $actualNic.Name
    Assert-AreEqual $nicList[0].Location $actualNic.Location
    Assert-AreEqual "Succeeded" $nicList[0].ProvisioningState
    Assert-AreEqual $expectedNic.Etag $nicList[0].Etag

    # Delete NetworkInterface
    $deleteResult = Remove-AzNetworkInterface -ResourceGroupName $rgname -name $nicName -PassThru -Force
    Assert-AreEqual true $deleteResult

    $nicList = Get-AzNetworkInterface -ResourceGroupName $rgName
    Assert-AreEqual 0 @($nicList).Count
}

Invoke-LiveTestScenario -Name "Network interface CRUD with IP configuration" -Description "Test CRUD for network interface with IP configuration" -ScenarioScript `
{
    param ($rg)

    $rgName = $rg.ResourceGroupName
    $location = "westus"
    $vnetName = New-LiveTestResourceName
    $subnetName = New-LiveTestResourceName
    $publicIpName = New-LiveTestResourceName
    $domainNameLabel = New-LiveTestResourceName
    $ipconfig1Name = New-LiveTestResourceName
    $ipconfig2Name = New-LiveTestResourceName
    $nicName = New-LiveTestResourceName

    $subnet = New-AzVirtualNetworkSubnetConfig -Name $subnetName -AddressPrefix 10.0.1.0/24
    $vnet = New-AzVirtualNetwork -ResourceGroupName $rgName -Name $vnetName -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnet

    $publicIp = New-AzPublicIpAddress -ResourceGroupName $rgname -name $publicIpName -Location $location -AllocationMethod Dynamic -DomainNameLabel $domainNameLabel
    $ipconfig1 = New-AzNetworkInterfaceIpConfig -Name $ipconfig1Name -Subnet $vnet.Subnets[0] -PublicIpAddress $publicip
    $ipconfig2 = New-AzNetworkInterfaceIpConfig -Name $ipconfig2Name -PrivateIpAddressVersion IPv6

    $nic = New-AzNetworkInterface -ResourceGroupName $rgName -Name $nicName -Location $location -IpConfiguration $ipconfig1,$ipconfig2 -Tag @{ testtag = "testval" }

    Assert-AreEqual $rgName $nic.ResourceGroupName
    Assert-AreEqual $nicName $nic.Name
    Assert-NotNull $nic.ResourceGuid
    Assert-AreEqual "Succeeded" $nic.ProvisioningState
    Assert-AreEqual $nic.IpConfigurations[0].Name $nic.IpConfigurations[0].Name
    Assert-AreEqual $nic.IpConfigurations[0].PublicIpAddress.Id $nic.IpConfigurations[0].PublicIpAddress.Id
    Assert-AreEqual $nic.IpConfigurations[0].Subnet.Id $nic.IpConfigurations[0].Subnet.Id
    Assert-NotNull $nic.IpConfigurations[0].PrivateIpAddress
    Assert-AreEqual "Dynamic" $nic.IpConfigurations[0].PrivateIpAllocationMethod

    $publicIp = Get-AzPublicIpAddress -ResourceGroupName $rgName -Name $publicIpName
    Assert-AreEqual $nic.IpConfigurations[0].PublicIpAddress.Id $publicIp.Id
    Assert-AreEqual $nic.IpConfigurations[0].Id $publicIp.IpConfiguration.Id

    $vnet = Get-AzVirtualNetwork -ResourceGroupName $rgName -Name $vnetName
    Assert-AreEqual $nic.IpConfigurations[0].Subnet.Id $vnet.Subnets[0].Id
    Assert-AreEqual $nic.IpConfigurations[0].Id $vnet.Subnets[0].IpConfigurations[0].Id

    Assert-AreEqual 2 @($nic.IpConfigurations).Count

    Assert-AreEqual $ipconfig1Name $nic.IpConfigurations[0].Name
    Assert-AreEqual $publicIp.Id $nic.IpConfigurations[0].PublicIpAddress.Id
    Assert-AreEqual $vnet.Subnets[0].Id $nic.IpConfigurations[0].Subnet.Id
    Assert-NotNull $nic.IpConfigurations[0].PrivateIpAddress
    Assert-AreEqual "Dynamic" $nic.IpConfigurations[0].PrivateIpAllocationMethod
    Assert-AreEqual $nic.IpConfigurations[0].PrivateIpAddressVersion IPv4

    Assert-AreEqual $ipconfig2Name $nic.IpConfigurations[1].Name
    Assert-Null $nic.IpConfigurations[1].PublicIpAddress
    Assert-Null $nic.IpConfigurations[1].Subnet
    Assert-AreEqual $nic.IpConfigurations[1].PrivateIpAddressVersion IPv6

    $deleteResult = Remove-AzNetworkInterface -ResourceGroupName $rgName -Name $nicName -PassThru -Force
    Assert-AreEqual true $deleteResult

    $list = Get-AzNetworkInterface -ResourceGroupName $rgname
    Assert-AreEqual 0 @($list).Count
}

Invoke-LiveTestScenario -Name "Network interface CRUD with accelerated networking" -Description "Test CRUD for network interface with accelerated networking" -ScenarioScript `
{
    param ($rg)

    $rgName = $rg.ResourceGroupName
    $location = "westus"
    $vnetName = New-LiveTestResourceName
    $subnetName = New-LiveTestResourceName
    $publicIpName = New-LiveTestResourceName
    $domainNameLabel = New-LiveTestResourceName
    $nicName = New-LiveTestResourceName

    $subnet = New-AzVirtualNetworkSubnetConfig -Name $subnetName -AddressPrefix 10.0.1.0/24
    $vnet = New-AzVirtualNetwork -ResourceGroupName $rgName -Name $vnetName -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnet

    $publicIp = New-AzPublicIpAddress -ResourceGroupName $rgName -Name $publicIpName -Location $location -AllocationMethod Dynamic -DomainNameLabel $domainNameLabel

    $expectedNic = New-AzNetworkInterface -ResourceGroupName $rgName -Name $nicName -Location $location -Subnet $vnet.Subnets[0] -PublicIpAddress $publicip -EnableAcceleratedNetworking
    $actualNic = Get-AzNetworkInterface -ResourceGroupName $rgName -Name $nicName

    Assert-AreEqual $expectedNic.ResourceGroupName $actualNic.ResourceGroupName
    Assert-AreEqual $expectedNic.Name $actualNic.Name
    Assert-AreEqual $expectedNic.Location $actualNic.Location
    Assert-NotNull $expectedNic.ResourceGuid
    Assert-AreEqual "Succeeded" $expectedNic.ProvisioningState
    Assert-AreEqual $expectedNic.IpConfigurations[0].Name $actualNic.IpConfigurations[0].Name
    Assert-AreEqual $expectedNic.IpConfigurations[0].PublicIpAddress.Id $actualNic.IpConfigurations[0].PublicIpAddress.Id
    Assert-AreEqual $expectedNic.IpConfigurations[0].Subnet.Id $actualNic.IpConfigurations[0].Subnet.Id
    Assert-NotNull $expectedNic.IpConfigurations[0].PrivateIpAddress
    Assert-AreEqual $expectedNic.EnableAcceleratedNetworking $true
    Assert-AreEqual "Dynamic" $expectedNic.IpConfigurations[0].PrivateIpAllocationMethod

    $publicIp = Get-AzPublicIpAddress -ResourceGroupName $rgname -name $publicIpName
    Assert-AreEqual $expectedNic.IpConfigurations[0].PublicIpAddress.Id $publicIp.Id
    Assert-AreEqual $expectedNic.IpConfigurations[0].Id $publicIp.IpConfiguration.Id

    $vnet = Get-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname
    Assert-AreEqual $expectedNic.IpConfigurations[0].Subnet.Id $vnet.Subnets[0].Id
    Assert-AreEqual $expectedNic.IpConfigurations[0].Id $vnet.Subnets[0].IpConfigurations[0].Id

    $nicList = Get-AzNetworkInterface -ResourceGroupName $rgname
    Assert-AreEqual 1 @($nicList).Count
    Assert-AreEqual $nicList[0].ResourceGroupName $actualNic.ResourceGroupName
    Assert-AreEqual $nicList[0].Name $actualNic.Name
    Assert-AreEqual $nicList[0].Location $actualNic.Location
    Assert-AreEqual "Succeeded" $nicList[0].ProvisioningState
    Assert-AreEqual $actualNic.Etag $nicList[0].Etag

    $nicList = Get-AzNetworkInterface -ResourceGroupName "*" -Name "*"
    Assert-True { $nicList.Count -ge 0 }

    $nicList = Get-AzNetworkInterface -Name "*"
    Assert-True { $nicList.Count -ge 0 }

    $nicList = Get-AzNetworkInterface -ResourceGroupName "*"
    Assert-True { $nicList.Count -ge 0 }

    # Delete NetworkInterface
    $deleteResult = Remove-AzNetworkInterface -ResourceGroupName $rgName -Name $nicName -PassThru -Force
    Assert-AreEqual true $deleteResult

    $nicList = Get-AzNetworkInterface -ResourceGroupName $rgname
    Assert-AreEqual 0 @($nicList).Count
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
    $lb = New-AzLoadBalancer -Name $lbName -ResourceGroupName $rgName -Location $location -FrontendIpConfiguration $lbIpCfg -BackendAddressPool $lbPoolCfg -Sku Standard

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
