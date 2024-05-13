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
Tests create, update, delete and read for LoadBalancerBackendPool operations
#>
function Test-LoadBalancerBackendPoolCRUD
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
    $rglocation = Get-ProviderLocation ResourceManagement
    $resourceTypeParent = "Microsoft.Network/loadBalancers"
    $location = Get-ProviderLocation $resourceTypeParent
    $backendAddressConfigName = "TestVNetRef"
    $testIpAddress = "10.0.0.5"

    try
    {
         # Create the resource group
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval"} 

        # Create the Virtual Network
        $subnet = New-AzVirtualNetworkSubnetConfig -Name $subnetName -AddressPrefix 10.0.1.0/24
        $vnet = New-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnet

        # Create Standard Azure load balancer
        New-AzLoadBalancer -Name $lbName -ResourceGroupName $rgname -Location $location -SKU Standard

        # Create load balancer backend pool
        $backendPoolInitial = New-AzLoadBalancerBackendAddressPool -ResourceGroupName $rgname -LoadBalancerName $lbName -Name $backendAddressPoolName


        $ip1 = New-AzLoadBalancerBackendAddressConfig -IpAddress $testIpAddress -Name $backendAddressConfigName -VirtualNetworkId $vnet.Id

        # Add Ip to pool address list
        $backendPoolInitial.LoadBalancerBackendAddresses.Add($ip1)

        $backendPoolSet1 = Set-AzLoadBalancerBackendAddressPool -InputObject $backendPoolInitial
       
        Assert-NotNull  $backendPoolSet1

        Assert-AreEqual $backendAddressPoolName $backendPoolSet1.Name
        Assert-AreEqual $backendPoolInitial.Id $backendPoolSet1.Id
        Assert-AreEqual "Succeeded" $backendPoolSet1.ProvisioningState
     
        $lisOfBackendAddresses = $backendPoolSet1.LoadBalancerBackendAddresses
        Assert-True { @($lisOfBackendAddresses).Count -eq 1 }

        Assert-AreEqual $lisOfBackendAddresses[0].Name $backendAddressConfigName
        Assert-AreEqual $lisOfBackendAddresses[0].IpAddress $testIpAddress

        #remove IpAddress from list
        $backendPoolSet1.LoadBalancerBackendAddresses.Remove($backendPoolSet1.LoadBalancerBackendAddresses[0])
        $backendPoolSet2 = $backendPoolSet1 | Set-AzLoadBalancerBackendAddressPool

        Assert-NotNull  $backendPoolSet2
        
        $listOfBackendAddresses2 = $backendPoolSet2.LoadBalancerBackendAddresses
        Assert-True { @($listOfBackendAddresses2).Count -eq 0 }
    }
    finally {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Tests 
#>
function Test-LoadBalancerBackendPoolCreate
{

    # Setup
    $rgname = Get-ResourceGroupName
    $vnetName = Get-ResourceName
    $subnetName = Get-ResourceName
    $publicIpName = Get-ResourceName
    $lbName = Get-ResourceName
    $frontendName = Get-ResourceName
    $backendAddressPoolName = Get-ResourceName
    $rglocation = Get-ProviderLocation ResourceManagement
    $resourceTypeParent = "Microsoft.Network/loadBalancers"
    $location = Get-ProviderLocation $resourceTypeParent
    $backendAddressConfigName = "TestVNetRef"
    $testIpAddress1 = "10.0.0.5"
    $testIpAddress2 = "10.0.1.6"
    $testIpAddress3 = "10.0.0.7"
    $adminState = "Up"

    $backendAddressConfigName1 = Get-ResourceName
    $backendAddressConfigName2 = Get-ResourceName
    $backendAddressConfigName3 = Get-ResourceName

    $backendPool1 = Get-ResourceName
    $backendPool2 = Get-ResourceName
    $backendPool3 = Get-ResourceName
    $backendPool4 = Get-ResourceName

    try
    {
        # Create the resource group
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval"} 

        # Create the Virtual Network
        $subnet = New-AzVirtualNetworkSubnetConfig -Name $subnetName -AddressPrefix 10.0.1.0/24
        $vnet = New-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnet

        # Create Standard Azure load balancer
        $lb = New-AzLoadBalancer -Name $lbName -ResourceGroupName $rgname -Location $location -SKU Standard

        $ip1 = New-AzLoadBalancerBackendAddressConfig -IpAddress $testIpAddress1 -Name $backendAddressConfigName1 -VirtualNetworkId $vnet.Id -AdminState $adminState
        $ip2 = New-AzLoadBalancerBackendAddressConfig -IpAddress $testIpAddress2 -Name $backendAddressConfigName2 -SubnetId $vnet.Subnets[0].Id 
        $ip3 = New-AzLoadBalancerBackendAddressConfig -IpAddress $testIpAddress3 -Name $backendAddressConfigName3 -VirtualNetworkId $vnet.Id

        $ips = @($ip1, $ip2)

        ## create by passing loadbalancer without Ips
        $create1 = $lb | New-AzLoadBalancerBackendAddressPool -Name $backendPool1

        Assert-NotNull $create1

        ## create by passing loadbalancer with ips
        $create2 = $lb | New-AzLoadBalancerBackendAddressPool -Name $backendPool2 -LoadBalancerBackendAddress $ips

        Assert-NotNull $create2
        Assert-True { @($create2.LoadBalancerBackendAddresses).Count -eq 2}
        Assert-True { $create2.LoadBalancerBackendAddresses[0].AdminState -eq "Up"}

        ## create by Name without ip's
        $create3 = New-AzLoadBalancerBackendAddressPool -ResourceGroupName $rgname -LoadBalancerName $lbName -Name $backendPool3

        Assert-NotNull $create3

        ## create by Name with ip's
        $create4 = New-AzLoadBalancerBackendAddressPool -ResourceGroupName $rgname -LoadBalancerName $lbName -Name $backendPool4 -LoadBalancerBackendAddress $ips

        Assert-NotNull $create4
        Assert-True { @($create4.LoadBalancerBackendAddresses).Count -eq 2}
    }
    finally {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Tests 
#>
function Test-GlobalLoadBalancerBackendPoolCreate
{

    # Setup
    $rgname = Get-ResourceGroupName
    $rglocation = Get-ProviderLocation ResourceManagement

    $vnetName = Get-ResourceName
    $location = Get-ProviderLocation "Microsoft.Network/loadBalancers"

    $publicIpName = Get-ResourceName
    $domainNameLabel = Get-ResourceName

    $frontendName = Get-ResourceName
    $backendAddressPoolName = Get-ResourceName
    $probeName = Get-ResourceName
    $inboundNatRuleName = Get-ResourceName
    $lbruleName = Get-ResourceName
    $lbName = Get-ResourceName
    
    $globalrgname = Get-ResourceName
    $globalvnet = Get-ResourceName
    $globallbname = Get-ResourceName
    $globalsubnetname = Get-ResourceName

    $globalbackendPool = Get-ResourceName
    $globalbackendAddressConfigName = Get-ResourceName

    try
    {
        # Create the regional resource group
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval"}        

        # Create the publicip
        $publicip = New-AzPublicIpAddress -ResourceGroupName $rgname -name $publicIpName -location $location -AllocationMethod Static -DomainNameLabel $domainNameLabel -SKU Standard

        # Create regional loadbalancer
        $frontend = New-AzLoadBalancerFrontendIpConfig -Name $frontendName -PublicIpAddress $publicip
        $backendAddressPool = New-AzLoadBalancerBackendAddressPoolConfig -Name $backendAddressPoolName
        $probe = New-AzLoadBalancerProbeConfig -Name $probeName -RequestPath healthcheck.aspx -Protocol http -Port 80 -IntervalInSeconds 15 -ProbeCount 2
        $inboundNatRule = New-AzLoadBalancerInboundNatRuleConfig -Name $inboundNatRuleName -FrontendIPConfiguration $frontend -Protocol Tcp -FrontendPort 3389 -BackendPort 3389 -IdleTimeoutInMinutes 15 -EnableFloatingIP
        $lbrule = New-AzLoadBalancerRuleConfig -Name $lbruleName -FrontendIPConfiguration $frontend -BackendAddressPool $backendAddressPool -Probe $probe -Protocol Tcp -FrontendPort 80 -BackendPort 80 -IdleTimeoutInMinutes 15 -EnableFloatingIP -LoadDistribution SourceIP
        $job = New-AzLoadBalancer -Name $lbName -ResourceGroupName $rgname -Location $location -FrontendIpConfiguration $frontend -BackendAddressPool $backendAddressPool -Probe $probe -InboundNatRule $inboundNatRule -LoadBalancingRule $lbrule -AsJob -SKU Standard
        $job | Wait-Job
		$actualLb = $job | Receive-Job

        # Create the global resource group
        $resourceGroup = New-AzResourceGroup -Name $globalrgname -Location $rglocation -Tags @{ testtag = "testval"} 
 
        # Create global loadbalancer 
        $glb = New-AzLoadBalancer -Name $globallbname -ResourceGroupName $globalrgname -Location $location -SKU Standard -Tier Global

        $regionalbackendaddress = New-AzLoadBalancerBackendAddressConfig -LoadBalancerFrontendIPConfigurationId $frontend.Id -Name $globalbackendAddressConfigName
        $create = $glb | New-AzLoadBalancerBackendAddressPool -Name $globalbackendPool -LoadBalancerBackendAddress $regionalbackendaddress 

        Assert-NotNull $create
        Assert-True { @($create.LoadBalancerBackendAddresses).Count -eq 1}
    }
    finally {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}
 
<#
.SYNOPSIS
Tests Remove-AzLoadBalancerBackendAddressPool
#>
function Test-LoadBalancerBackendPoolDelete
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
    $rglocation = Get-ProviderLocation ResourceManagement
    $resourceTypeParent = "Microsoft.Network/loadBalancers"
    $location = Get-ProviderLocation $resourceTypeParent
    $backendAddressConfigName = Get-ResourceName
    $backendPoolName1 = Get-ResourceName
    $backendPoolName2 = Get-ResourceName
    $backendPoolName3 = Get-ResourceName
   
   try
    {
         # Create the resource group
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval"} 

        # Create Standard Azure load balancer
        $lb = New-AzLoadBalancer -Name $lbName -ResourceGroupName $rgname -Location $location -SKU Standard

        $b1 = $lb | New-AzLoadBalancerBackendAddressPool -Name $backendPoolName1
        $b2 = $lb | New-AzLoadBalancerBackendAddressPool -Name $backendPoolName2
        $b3 = $lb | New-AzLoadBalancerBackendAddressPool -Name $backendPoolName3

        Assert-NotNull $b1
        Assert-NotNull $b2
        Assert-NotNull $b3

        ##test passing lb object via pipeline
        $lb | Remove-AzLoadBalancerBackendAddressPool -Name $backendPoolName1

        ##test passing input object
        $b2 | Remove-AzLoadBalancerBackendAddressPool

        ##test passing resourceId
        Remove-AzLoadBalancerBackendAddressPool -ResourceId $b3.Id

        ## confirm removed
        $r1 = $lb | Get-AzLoadBalancerBackendAddressPool -Name $backendPoolName1 -ErrorAction SilentlyContinue
        $r2 = $lb | Get-AzLoadBalancerBackendAddressPool -Name $backendPoolName2 -ErrorAction SilentlyContinue
        $r3 = $lb | Get-AzLoadBalancerBackendAddressPool -Name $backendPoolName3 -ErrorAction SilentlyContinue

        Assert-Null $r1
        Assert-Null $r2
        Assert-Null $r3
    }
    finally {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Tests Set-AzLoadBalancerBackendAddressPool
#>
function Test-LoadBalancerBackendPoolUpdate
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
    $rglocation = Get-ProviderLocation ResourceManagement
    $resourceTypeParent = "Microsoft.Network/loadBalancers"
    $location = Get-ProviderLocation $resourceTypeParent

    $testIpAddress1 = "10.0.0.5"
    $testIpAddress2 = "10.0.0.6"

    $backendAddressConfigName1 = Get-ResourceName
    $backendAddressConfigName2 = Get-ResourceName

    $backendPool1 = Get-ResourceName

    try
    {
         # Create the resource group
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval"} 

        # Create the Virtual Network
        $subnet = New-AzVirtualNetworkSubnetConfig -Name $subnetName -AddressPrefix 10.0.1.0/24
        $vnet = New-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnet

        # Create Standard Azure load balancer
        $lb = New-AzLoadBalancer -Name $lbName -ResourceGroupName $rgname -Location $location -SKU Standard

        $ip1 = New-AzLoadBalancerBackendAddressConfig -IpAddress $testIpAddress1 -Name $backendAddressConfigName1 -VirtualNetworkId $vnet.Id
        $ip2 = New-AzLoadBalancerBackendAddressConfig -IpAddress $testIpAddress2 -Name $backendAddressConfigName2 -VirtualNetworkId $vnet.Id 

        $ips = @($ip1, $ip2)
       
        $unmodified = $lb | New-AzLoadBalancerBackendAddressPool -Name $backendPool1

        Assert-NotNull $unmodified

        #Set by name and modified input object
        $unmodified.LoadBalancerBackendAddresses.Add($ip1)

        $modified1 = Set-AzLoadBalancerBackendAddressPool -InputObject $unmodified
        
        Assert-NotNull $modified1
        Assert-True { @($modified1.LoadBalancerBackendAddresses).Count -eq 1}

        #Set by specific backend from piped loadbalancer and add two IP's
        $modified2 = $lb | Set-AzLoadBalancerBackendAddressPool -LoadBalancerBackendAddress $ips -Name $backendPool1

        Assert-NotNull $modified2
        Assert-True { @($modified2.LoadBalancerBackendAddresses).Count -eq 2}

        #set by ResourceId
        $modified3 = Set-AzLoadBalancerBackendAddressPool -ResourceId $unmodified.Id -LoadBalancerBackendAddress $unmodified.LoadBalancerBackendAddresses

        Assert-NotNull $modified3
        Assert-True { @($modified3.LoadBalancerBackendAddresses).Count -eq 1}
    }
    finally {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Tests Set-LoadBalancerBackendPoolCRUDWithAddTunnelInterface
#>
function Test-LoadBalancerBackendPoolCRUDWithAddTunnelInterface
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

        # Set backendPool change port
        $getBackendPoolByName = $expectedLb | Get-AzLoadBalancerBackendAddressPool -Name $backendAddressPoolName

        $modified1 = Set-AzLoadBalancerBackendAddressPool -InputObject $getBackendPoolByName -TunnelInterface $tunnelInterface1, $tunnelInterface2
    }
    finally {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Tests Get-AzLoadBalancerBackendAddressPool
#>
function Test-LoadBalancerBackendPoolRead
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
    $rglocation = Get-ProviderLocation ResourceManagement
    $resourceTypeParent = "Microsoft.Network/loadBalancers"
    $location = Get-ProviderLocation $resourceTypeParent
    $backendPool1 = Get-ResourceName
    $backendPool2 = Get-ResourceName
    $backendPool3 = Get-ResourceName

    try
    {
         # Create the resource group
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval"} 

        # Create Standard Azure load balancer
        $lb = New-AzLoadBalancer -Name $lbName -ResourceGroupName $rgname -Location $location -SKU Standard

        $lb | New-AzLoadBalancerBackendAddressPool -Name $backendPool1
        $lb | New-AzLoadBalancerBackendAddressPool -Name $backendPool2
        $lb | New-AzLoadBalancerBackendAddressPool -Name $backendPool3
        
        #Get all backends under loadbalancer
        $getAllBackendPools = $lb | Get-AzLoadBalancerBackendAddressPool

        Assert-NotNull $getAllBackendPools
        Assert-True { @($getAllBackendPools).Count -eq 3 }

        #Get specific backend from loadbalancer
        $getBackendPoolByName = $lb | Get-AzLoadBalancerBackendAddressPool -Name $backendPool1

        Assert-NotNull $getBackendPoolByName

        #Get specific backend from loadbalancer
        $getBackendPoolByRgAndName = Get-AzLoadBalancerBackendAddressPool -ResourceGroupName $rgname -LoadBalancerName $lbName -Name $backendPool1

        Assert-NotNull $getBackendPoolByRgAndName

        #Get a backend by resource Id
        $getBackendPoolByResourceId = Get-AzLoadBalancerBackendAddressPool -ResourceId $getBackendPoolByRgAndName.Id
        Assert-NotNull $getBackendPoolByResourceId
    }
    finally {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}


<#
.SYNOPSIS
Tests New-AzLoadBalancerBackendAddressConfig
#>
function Test-LoadBalancerBackendAddressConfig
{

    # Setup
    $rgname = Get-ResourceGroupName
    $vnetName = Get-ResourceName
    $lbName = Get-ResourceName
    $subnetName = Get-ResourceName

    $rglocation = Get-ProviderLocation ResourceManagement
    $resourceTypeParent = "Microsoft.Network/loadBalancers"
    $location = Get-ProviderLocation $resourceTypeParent

    $validIpAddress = "10.0.0.5"
    $invalidIpAddress2 = "xxxxx"

    $adminState = "Up"

    $backendAddressConfigName1 = Get-ResourceName
    $backendAddressConfigName2 = Get-ResourceName

    try
    {
         # Create the resource group
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval"} 

        # Create the Virtual Network
        $subnet = New-AzVirtualNetworkSubnetConfig -Name $subnetName -AddressPrefix 10.0.1.0/24
        $virtualNetwork = New-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnet

        $ipconfig1 = New-AzLoadBalancerBackendAddressConfig -IpAddress $validIpAddress -Name $backendAddressConfigName1 -VirtualNetworkId $virtualNetwork.Id -AdminState $adminState

        Assert-AreEqual $ipconfig1.Name $backendAddressConfigName1
        Assert-AreEqual $ipconfig1.IpAddress $validIpAddress
        Assert-AreEqual $ipconfig1.VirtualNetwork.Id $virtualNetwork.Id
        Assert-AreEqual $ipconfig1.AdminState $adminState

        $ipconfig2 = New-AzLoadBalancerBackendAddressConfig -IpAddress $validIpAddress -Name $backendAddressConfigName1 -SubnetId virtualNetwork.Subnets[0].Id

        Assert-AreEqual $ipconfig2.Name $backendAddressConfigName1
        Assert-AreEqual $ipconfig2.IpAddress $validIpAddress
        Assert-AreEqual $ipconfig2.Subnet.Id  virtualNetwork.Subnets[0].Id

        Assert-ThrowsLike { New-AzLoadBalancerBackendAddressConfig -IpAddress $invalidIpAddress2 -Name $backendAddressConfigName1 -VirtualNetworkId $virtualNetwork.Id} "*Invalid IPAddress*"

    }
    finally {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Tests
#>
function Test-IPBasedBackendPoolQueryInboundNatRulePortMapping
{

    # Setup
    $rgname = Get-ResourceGroupName
    $rglocation = "eastus2euap"

    $subnetName = Get-ResourceName
    $vnetName = Get-ResourceName
    $location = "eastus2euap"

    $publicIpName = Get-ResourceName
    $domainNameLabel = Get-ResourceName

    $frontendName = Get-ResourceName
    $backendAddressPoolName = Get-ResourceName
    $inboundNatRuleV2Name = Get-ResourceName
    $lbName = Get-ResourceName

    $testIpAddress1 = "10.0.0.5"
    $testIpAddress2 = "10.0.0.6"

    $backendAddressConfigName1 = Get-ResourceName
    $backendAddressConfigName2 = Get-ResourceName

    try
    {
        # Create the regional resource group
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval"}

        # Create the Virtual Network
        $subnet = New-AzVirtualNetworkSubnetConfig -Name $subnetName -AddressPrefix 10.0.1.0/24
        $vnet = New-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnet

        # Create the publicip
        $publicip = New-AzPublicIpAddress -ResourceGroupName $rgname -name $publicIpName -location $location -AllocationMethod Static -DomainNameLabel $domainNameLabel -SKU Standard

        # Create regional loadbalancer
        $frontend = New-AzLoadBalancerFrontendIpConfig -Name $frontendName -PublicIpAddress $publicip
        $backendAddressPool = New-AzLoadBalancerBackendAddressPoolConfig -Name $backendAddressPoolName
        $lb = New-AzLoadBalancer -Name $lbName -ResourceGroupName $rgname -Location $location -FrontendIpConfiguration $frontend -SKU Standard -BackendAddressPool $backendAddressPool
        $lb = Get-AzLoadBalancer -Name $lbName -ResourceGroupName $rgname

        $ip1 = New-AzLoadBalancerBackendAddressConfig -IpAddress $testIpAddress1 -Name $backendAddressConfigName1 -VirtualNetworkId $vnet.Id
        $ip2 = New-AzLoadBalancerBackendAddressConfig -IpAddress $testIpAddress2 -Name $backendAddressConfigName2 -VirtualNetworkId $vnet.Id
        $ips = @($ip1, $ip2)
        $lb | Set-AzLoadBalancerBackendAddressPool -LoadBalancerBackendAddress $ips -Name $backendAddressPoolName
        $lb = Get-AzLoadBalancer -Name $lbName -ResourceGroupName $rgname
        $lb | Add-AzLoadBalancerInboundNatRuleConfig -Name $inboundNatRuleV2Name -FrontendIPConfiguration $frontend -Protocol Tcp -BackendPort 3390 -IdleTimeoutInMinutes 15 -EnableFloatingIP -FrontendPortRangeStart 3390 -FrontendPortRangeEnd 4001 -BackendAddressPool $lb.BackendAddressPools[0]
        $lb | Set-AzLoadBalancer

        # Query port mapping
        $portMapping1 = Get-AzLoadBalancerBackendAddressInboundNatRulePortMapping -ResourceGroupName $rgname -LoadBalancerName $lbName -Name $backendAddressPoolName -IpAddress $testIpAddress1
        Assert-AreEqual $portMapping1.inboundNatRuleName $lb.InboundNatRules[0].Name
        Assert-AreEqual $portMapping1.protocol "Tcp"
        Assert-AreEqual $portMapping1.frontendPort 3390
        Assert-AreEqual $portMapping1.BackendPort 3390

        $portMapping2 = Get-AzLoadBalancerBackendAddressInboundNatRulePortMapping -ResourceGroupName $rgname -LoadBalancerName $lbName -Name $backendAddressPoolName -IpAddress $testIpAddress2
        Assert-AreEqual $portMapping2.inboundNatRuleName $lb.InboundNatRules[0].Name
        Assert-AreEqual $portMapping2.protocol "Tcp"
        Assert-AreEqual $portMapping2.frontendPort 3391
        Assert-AreEqual $portMapping2.BackendPort 3390
    }
    finally {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Tests
#>
function Test-NICBasedBackendPoolQueryInboundNatRulePortMapping
{

    # Setup
    $rgname = Get-ResourceGroupName
    $rglocation = "eastus2euap"

    $vnetName = Get-ResourceName
    $subnetName = Get-ResourceName
    $location = "eastus2euap"

    $publicIpName = Get-ResourceName
    $domainNameLabel = Get-ResourceName

    $frontendName = Get-ResourceName
    $backendAddressPoolName = Get-ResourceName
    $inboundNatRuleV2Name = Get-ResourceName
    $lbName = Get-ResourceName

    $nicname1 = Get-ResourceName
    $nicname2 = Get-ResourceName
    $ipconfigname1 = Get-ResourceName
    $ipconfigname2 = Get-ResourceName

    try
    {
        # Create the regional resource group
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval"}

        # Create the Virtual Network
        $subnet = New-AzVirtualNetworkSubnetConfig -Name $subnetName -AddressPrefix 10.0.1.0/24
        $vnet = New-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnet

        # Create the publicip
        $publicip = New-AzPublicIpAddress -ResourceGroupName $rgname -name $publicIpName -location $location -AllocationMethod Static -DomainNameLabel $domainNameLabel -SKU Standard

        # Create regional loadbalancer
        $frontend = New-AzLoadBalancerFrontendIpConfig -Name $frontendName -PublicIpAddress $publicip
        $backendAddressPool = New-AzLoadBalancerBackendAddressPoolConfig -Name $backendAddressPoolName
        $lb = New-AzLoadBalancer -Name $lbName -ResourceGroupName $rgname -Location $location -FrontendIpConfiguration $frontend -SKU Standard -BackendAddressPool $backendAddressPool
        $lb = Get-AzLoadBalancer -Name $lbName -ResourceGroupName $rgname

        # Create 2 network interfaces and accociate to loadbalancer
        $nic1 = New-AzNetworkInterface -Name $nicname1 -ResourceGroupName $rgname -Location $location -Subnet $vnet.Subnets[0] -IpConfigurationName $ipconfigname1
        $nic2 = New-AzNetworkInterface -Name $nicname2 -ResourceGroupName $rgname -Location $location -Subnet $vnet.Subnets[0] -IpConfigurationName $ipconfigname2
        $nic1.IpConfigurations[0].LoadBalancerBackendAddressPools.Add($lb.BackendAddressPools[0]);
        $nic2.IpConfigurations[0].LoadBalancerBackendAddressPools.Add($lb.BackendAddressPools[0]);
        $nic1 = $nic1 | Set-AzNetworkInterface
        $nic2 = $nic2 | Set-AzNetworkInterface

        # Create InboundNatRuleV2
        $lb = Get-AzLoadBalancer -Name $lbName -ResourceGroupName $rgname
        $lb | Add-AzLoadBalancerInboundNatRuleConfig -Name $inboundNatRuleV2Name -FrontendIPConfiguration $frontend -Protocol Tcp -BackendPort 3390 -IdleTimeoutInMinutes 15 -EnableFloatingIP -FrontendPortRangeStart 3390 -FrontendPortRangeEnd 4001 -BackendAddressPool $lb.BackendAddressPools[0]
        $lb | Set-AzLoadBalancer

        # Query port mapping
        $portMapping1 = Get-AzLoadBalancerBackendAddressInboundNatRulePortMapping -ResourceGroupName $rgname -LoadBalancerName $lbName -Name $backendAddressPoolName -NetworkInterfaceIpConfigurationId $nic1.IpConfigurations[0].Id
        Assert-AreEqual $portMapping1.inboundNatRuleName $inboundNatRuleV2Name
        Assert-AreEqual $portMapping1.protocol "Tcp"
        Assert-AreEqual $portMapping1.frontendPort 3390
        Assert-AreEqual $portMapping1.BackendPort 3390

        $portMapping2 = Get-AzLoadBalancerBackendAddressInboundNatRulePortMapping -ResourceGroupName $rgname -LoadBalancerName $lbName -Name $backendAddressPoolName -NetworkInterfaceIpConfigurationId $nic2.IpConfigurations[0].Id
        Assert-AreEqual $portMapping2.inboundNatRuleName $inboundNatRuleV2Name
        Assert-AreEqual $portMapping2.protocol "Tcp"
        Assert-AreEqual $portMapping2.frontendPort 3391
        Assert-AreEqual $portMapping2.BackendPort 3390
    }
    finally {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Tests 
#>
function Test-ManagedIpBasedLoadBalancerBackendPoolCreate
{

    # Setup
    $rgname = Get-ResourceGroupName
    $vnetName = Get-ResourceName
    $subnetName = Get-ResourceName
    $publicIpName = Get-ResourceName
    $lbName = Get-ResourceName
    $frontendName = Get-ResourceName
    $backendAddressPoolName = Get-ResourceName
    $rglocation = Get-ProviderLocation ResourceManagement
    $resourceTypeParent = "Microsoft.Network/loadBalancers"
    $location = Get-ProviderLocation $resourceTypeParent
    $backendAddressConfigName = "TestVNetRef"

    $backendPool1 = Get-ResourceName
    $backendPool2 = Get-ResourceName
   
    try
    {
        # Create the resource group
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval"} 

        # Create the Virtual Network
        $subnet = New-AzVirtualNetworkSubnetConfig -Name $subnetName -AddressPrefix 10.0.1.0/24
        $vnet = New-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnet

        # Create Standard Azure load balancer
        $lb = New-AzLoadBalancer -Name $lbName -ResourceGroupName $rgname -Location $location -SKU Standard

        ## create by passing loadbalancer without Ips
        $create1 = $lb | New-AzLoadBalancerBackendAddressPool -Name $backendPool1 -SyncMode "Automatic" -VirtualNetworkId $vnet.Id

        Assert-NotNull $create1
        Assert-True { $create1.SyncMode -eq "Automatic"}
        Assert-AreEqual $create1.VirtualNetwork.Id $vnet.Id

        ## create by Name without ip's
        $create2 = New-AzLoadBalancerBackendAddressPool -ResourceGroupName $rgname -LoadBalancerName $lbName -Name $backendPool2 -SyncMode "Automatic" -VirtualNetworkId $vnet.Id

        Assert-NotNull $create2
        Assert-True { $create2.SyncMode -eq "Automatic"}
        Assert-AreEqual $create2.VirtualNetwork.Id $vnet.Id
    }
    finally {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Tests Set-AzLoadBalancerBackendAddressPool
#>
function Test-ManagedIpBasedLoadBalancerBackendPoolUpdate
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
    $rglocation = Get-ProviderLocation ResourceManagement
    $resourceTypeParent = "Microsoft.Network/loadBalancers"
    $location = Get-ProviderLocation $resourceTypeParent

    $testIpAddress1 = "10.0.0.5"
    $testIpAddress2 = "10.0.0.6"

    $backendAddressConfigName1 = Get-ResourceName
    $backendAddressConfigName2 = Get-ResourceName

    $backendPool1 = Get-ResourceName

    try
    {
         # Create the resource group
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval"} 

        # Create pip
        $publicip = New-AzPublicIpAddress -ResourceGroupName $rgname -name $publicIpName -location $location -AllocationMethod Static -DomainNameLabel $domainNameLabel -SKU Standard

        # Create fip
        $frontend = New-AzLoadBalancerFrontendIpConfig -Name $frontendName -PublicIpAddress $publicip

        # Create the Virtual Network
        $subnet = New-AzVirtualNetworkSubnetConfig -Name $subnetName -AddressPrefix 10.0.1.0/24
        $vnet = New-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnet

        # Create Standard Azure load balancer
        $lb = New-AzLoadBalancer -Name $lbName -ResourceGroupName $rgname -Location $location -SKU Standard -FrontendIPConfiguration $frontend
       
        $unmodified = $lb | New-AzLoadBalancerBackendAddressPool -Name $backendPool1 -SyncMode "Automatic" -VirtualNetworkId $vnet.Id
        Assert-NotNull $unmodified
        Assert-True { $unmodified.SyncMode -eq "Automatic"}
        Assert-AreEqual $unmodified.VirtualNetwork.Id $vnet.Id

        $lb = Get-AzLoadBalancer -Name $lbName -ResourceGroupName $rgname
        Assert-True { $lb.BackendAddressPools[0].SyncMode -eq "Automatic"}
        Assert-AreEqual $lb.BackendAddressPools[0].VirtualNetwork.Id $vnet.Id

        $pool = Get-AzLoadBalancerBackendAddressPool -ResourceGroupName $rgname -LoadBalancerName $lbName -Name $backendPool1
        Assert-True { $pool.SyncMode -eq "Automatic"}
        Assert-AreEqual $pool.VirtualNetwork.Id $vnet.Id

        $lb2 = Set-AzLoadBalancer -LoadBalancer $lb
        Assert-NotNull $lb2
        Assert-True { $lb2.BackendAddressPools[0].SyncMode -eq "Automatic"}
        Assert-AreEqual $lb2.BackendAddressPools[0].VirtualNetwork.Id $vnet.Id

        $pool2 = Set-AzLoadBalancerBackendAddressPool -InputObject $pool
        Assert-True { $pool2.SyncMode -eq "Automatic"}
        Assert-AreEqual $pool2.VirtualNetwork.Id $vnet.Id
    }
    finally {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}