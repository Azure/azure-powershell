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

    $job = Remove-AzNetworkInterface -ResourceGroupName $rgName -Name $nicName -PassThru -Force -AsJob
    $job | Wait-Job
    $deleteResult = $job | Receive-Job
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
