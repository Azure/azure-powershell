<#
.SYNOPSIS
Tests creating a Load balancer with NIC references
#>
function Test-LBWithMultiIpConfigNICCRUD
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
	$ipconfig1Name = Get-ResourceName
	$ipconfig2Name = Get-ResourceName
	$ipconfig3Name = Get-ResourceName
    
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

		
        # Create 3 network interfaces each with 2 ipconfig and accociate to loadbalancer
        $nic1 = New-AzureRmNetworkInterface -Name $nicname1 -ResourceGroupName $rgname -Location $location -Subnet $vnet.Subnets[0]
		$nic1 = Get-AzureRmNetworkInterface -Name $nicName1 -ResourceGroupName $rgname | Add-AzureRmNetworkInterfaceIpConfig -Name $ipconfig1Name -PrivateIpAddressVersion ipv4 -Subnet $vnet.Subnets[0] | Set-AzureRmNetworkInterface

        $nic2 = New-AzureRmNetworkInterface -Name $nicname2 -ResourceGroupName $rgname -Location $location -Subnet $vnet.Subnets[0]
		$nic2 = Get-AzureRmNetworkInterface -Name $nicName2 -ResourceGroupName $rgname | Add-AzureRmNetworkInterfaceIpConfig -Name $ipconfig2Name -PrivateIpAddressVersion ipv4 -Subnet $vnet.Subnets[0] | Set-AzureRmNetworkInterface

        $nic3 = New-AzureRmNetworkInterface -Name $nicname3 -ResourceGroupName $rgname -Location $location -Subnet $vnet.Subnets[0]
		$nic3 = Get-AzureRmNetworkInterface -Name $nicName3 -ResourceGroupName $rgname | Add-AzureRmNetworkInterfaceIpConfig -Name $ipconfig3Name -PrivateIpAddressVersion ipv4 -Subnet $vnet.Subnets[0] | Set-AzureRmNetworkInterface

        # Associate the nic to the load balancer
        $nic1.IpConfigurations[0].LoadBalancerBackendAddressPools.Add($lb.BackendAddressPools[0]);
		$nic1.IpConfigurations[1].LoadBalancerBackendAddressPools.Add($lb.BackendAddressPools[0]);
        $nic1.IpConfigurations[0].LoadBalancerInboundNatRules.Add($lb.InboundNatRules[0]);
		$nic2.IpConfigurations[0].LoadBalancerBackendAddressPools.Add($lb.BackendAddressPools[0]);
        $nic3.IpConfigurations[0].LoadBalancerInboundNatRules.Add($lb.InboundNatRules[1]);
		$nic3.IpConfigurations[1].LoadBalancerBackendAddressPools.Add($lb.BackendAddressPools[0]);
		
        # set the nics
        $nic1 = $nic1 | Set-AzureRmNetworkInterface
        $nic2 = $nic2 | Set-AzureRmNetworkInterface
        $nic3 = $nic3 | Set-AzureRmNetworkInterface

        # Verify the Load balancer references
        $lb = Get-AzureRmLoadBalancer -Name $lbName -ResourceGroupName $rgname

        Assert-AreEqual $nic1.IpConfigurations[0].Id $lb.InboundNatRules[0].BackendIPConfiguration.Id		
        Assert-AreEqual $nic3.IpConfigurations[0].Id $lb.InboundNatRules[1].BackendIPConfiguration.Id
        Assert-AreEqual 4 @($lb.BackendAddressPools[0].BackendIpConfigurations).Count

        # Delete
        $deleteLb = Remove-AzureRmLoadBalancer -Name $lbName -ResourceGroupName $rgname -PassThru -Force
        Assert-AreEqual true $deleteLb
        
        $list = Get-AzureRmLoadBalancer -ResourceGroupName $rgname
        Assert-AreEqual 0 @($list).Count

		# Delete NetworkInterface1
        $delete = Remove-AzureRmNetworkInterface -ResourceGroupName $rgname -name $nicName1 -PassThru -Force
        Assert-AreEqual true $delete

		#Delete NetworkInterface2
		$delete = Remove-AzureRmNetworkInterface -ResourceGroupName $rgname -name $nicName2 -PassThru -Force
        Assert-AreEqual true $delete

		#Delete NetworkInterface3
		$delete = Remove-AzureRmNetworkInterface -ResourceGroupName $rgname -name $nicName3 -PassThru -Force
        Assert-AreEqual true $delete
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}


<#
.SYNOPSIS
Tests creating a NIC with Loadbalancer references with muultiple ip config
#>
function Test-AddNICToLBWithMultiIpConfig
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
    $rglocation = Get-ProviderLocation ResourceManagement
    $resourceTypeParent = "Microsoft.Network/loadBalancers"
    $location = Get-ProviderLocation $resourceTypeParent

	#create 2 more ipconfigs
	$ipconfig1Name = Get-ResourceName
	$ipconfig2Name = Get-ResourceName
    
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

        # Create network interfaces with 3 ips and accociate to loadbalancer
        $nic1 = New-AzureRmNetworkInterface -Name $nicname1 -ResourceGroupName $rgname -Location $location -Subnet $vnet.Subnets[0] -LoadBalancerBackendAddressPool $lb.BackendAddressPools[0] -LoadBalancerInboundNatRule $lb.InboundNatRules[0] | Add-AzureRmNetworkInterfaceIpConfig -Name $ipconfig1Name -PrivateIpAddressVersion ipv4 -Subnet $vnet.Subnets[0] | Add-AzureRmNetworkInterfaceIpConfig -Name $ipconfig2Name -PrivateIpAddressVersion ipv4 -Subnet $vnet.Subnets[0] | Set-AzureRmNetworkInterface
        
        #verify nic configs
		Assert-AreEqual 3 @($nic1.IpConfigurations).Count
		Assert-AreEqual true $nic1.IpConfigurations[0].Primary
		
		# Delete NetworkInterface
        $delete = Remove-AzureRmNetworkInterface -ResourceGroupName $rgname -name $nicname1 -PassThru -Force
        Assert-AreEqual true $delete
        
        $list = Get-AzureRmNetworkInterface -ResourceGroupName $rgname
        Assert-AreEqual 0 @($list).Count

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
Tests creating public ips on secondary ipconfig for a nic
#>

function Test-LBWithMultiIpConfigMultiNIC
{
    # Setup
    $rgname = Get-ResourceGroupName
    $vnetName = Get-ResourceName
    $subnetName = Get-ResourceName
    $publicIp1Name = Get-ResourceName
	$publicIp2Name = Get-ResourceName
    $nicName = Get-ResourceName
	$ipconfig1Name = Get-ResourceName
	$ipconfig2Name = Get-ResourceName
    $domainNameLabel1 = Get-ResourceName
	$domainNameLabel2 = Get-ResourceName
    $rglocation = Get-ProviderLocation ResourceManagement
    $resourceTypeParent = "Microsoft.Network/networkInterfaces"
    $location = Get-ProviderLocation $resourceTypeParent
    
    try 
    {
        # Create the resource group
        $resourceGroup = New-AzureRmResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval" } 
        
        # Create the Virtual Network
        $subnet = New-AzureRmVirtualNetworkSubnetConfig -Name $subnetName -AddressPrefix 10.0.1.0/24
        $vnet = New-AzureRmvirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnet
        
        # Create the publicips
        $publicip1 = New-AzureRmPublicIpAddress -ResourceGroupName $rgname -name $publicIp1Name -location $location -AllocationMethod Dynamic -DomainNameLabel $domainNameLabel
		$publicip2 = New-AzureRmPublicIpAddress -ResourceGroupName $rgname -name $publicIp2Name -location $location -AllocationMethod Dynamic -DomainNameLabel $domainNameLabel

		# Create the ipconfiguration
		$ipconfig1 = New-AzureRmNetworkInterfaceIpConfig -Name $ipconfig1Name -Subnet $vnet.Subnets[0] -PublicIpAddress $publicip1 -Primary
		$ipconfig2 = New-AzureRmNetworkInterfaceIpConfig -Name $ipconfig2Name -PublicIpAddress $publicip2 -Subnet $vnet.Subnets[0]

        # Create NetworkInterface
        $nic = New-AzureRmNetworkInterface -Name $nicName -ResourceGroupName $rgname -Location $location -IpConfiguration $ipconfig1,$ipconfig2 -Tag @{ testtag = "testval" }

        Assert-AreEqual $rgname $nic.ResourceGroupName	
        Assert-AreEqual $nicName $nic.Name	
        Assert-NotNull $nic.ResourceGuid
        Assert-AreEqual "Succeeded" $nic.ProvisioningState
        Assert-AreEqual $nic.IpConfigurations[0].Name $nic.IpConfigurations[0].Name
        Assert-AreEqual $nic.IpConfigurations[0].PublicIpAddress.Id $nic.IpConfigurations[0].PublicIpAddress.Id
        Assert-AreEqual $nic.IpConfigurations[0].Subnet.Id $nic.IpConfigurations[0].Subnet.Id
        Assert-NotNull $nic.IpConfigurations[0].PrivateIpAddress
        Assert-AreEqual "Dynamic" $nic.IpConfigurations[0].PrivateIpAllocationMethod
		        
        # Check publicIp address reference
        $publicip1 = Get-AzureRmPublicIpAddress -ResourceGroupName $rgname -name $publicIp1Name
		$publicip2 = Get-AzureRmPublicIpAddress -ResourceGroupName $rgname -name $publicIp2Name
        Assert-AreEqual $nic.IpConfigurations[0].PublicIpAddress.Id $publicip1.Id
		Assert-AreEqual $nic.IpConfigurations[1].PublicIpAddress.Id $publicip2.Id
        Assert-AreEqual $nic.IpConfigurations[0].Id $publicip1.IpConfiguration.Id
		 Assert-AreEqual $nic.IpConfigurations[1].Id $publicip2.IpConfiguration.Id

        # Check Subnet address reference
        $vnet = Get-AzureRmvirtualNetwork -Name $vnetName -ResourceGroupName $rgname
        Assert-AreEqual $nic.IpConfigurations[0].Subnet.Id $vnet.Subnets[0].Id
        Assert-AreEqual $nic.IpConfigurations[0].Id $vnet.Subnets[0].IpConfigurations[0].Id
		Assert-AreEqual $nic.IpConfigurations[1].Subnet.Id $vnet.Subnets[0].Id
        Assert-AreEqual $nic.IpConfigurations[1].Id $vnet.Subnets[0].IpConfigurations[0].Id


		# Verify ipconfigs
		Assert-AreEqual 2 @($nic.IpConfigurations).Count

		Assert-AreEqual $ipconfig1Name $nic.IpConfigurations[0].Name
        Assert-AreEqual $publicip1.Id $nic.IpConfigurations[0].PublicIpAddress.Id
        Assert-AreEqual $vnet.Subnets[0].Id $nic.IpConfigurations[0].Subnet.Id
        Assert-NotNull $nic.IpConfigurations[0].PrivateIpAddress
        Assert-AreEqual "Dynamic" $nic.IpConfigurations[0].PrivateIpAllocationMethod
		Assert-AreEqual $nic.IpConfigurations[0].PrivateIpAddressVersion IPv4
		Assert-AreEqual $nic.IpConfigurations[1].PrivateIpAddressVersion IPv4

		Assert-AreEqual $ipconfig2Name $nic.IpConfigurations[1].Name
        Assert-Null $nic.IpConfigurations[1].PublicIpAddress
        Assert-Null $nic.IpConfigurations[1].Subnet
        Assert-AreEqual $nic.IpConfigurations[1].PrivateIpAddressVersion IPv6

        # Delete NetworkInterface
        $delete = Remove-AzureRmNetworkInterface -ResourceGroupName $rgname -name $nicName -PassThru -Force
        Assert-AreEqual true $delete
        
        $list = Get-AzureRmNetworkInterface -ResourceGroupName $rgname
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
Tests creating new simple public networkinterface with multiCA.
#>
function Test-MultiIpConfigCRUD
{
    # Setup
    $rgname = Get-ResourceGroupName
    $vnetName = Get-ResourceName
    $subnetName = Get-ResourceName
    $publicIpName = Get-ResourceName
    $nicName = Get-ResourceName
    $domainNameLabel = Get-ResourceName
    $rglocation = Get-ProviderLocation ResourceManagement
    $resourceTypeParent = "Microsoft.Network/networkInterfaces"
    $location = Get-ProviderLocation $resourceTypeParent
	$ipconfig1Name = Get-ResourceName
	$ipconfig2Name = Get-ResourceName
    $ipconfig3Name = Get-ResourceName

    try 
    {
        # Create the resource group
        $resourceGroup = New-AzureRmResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval" } 
        
        # Create the Virtual Network
        $subnet = New-AzureRmVirtualNetworkSubnetConfig -Name $subnetName -AddressPrefix 10.0.1.0/24
        $vnet = New-AzureRmvirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnet
        
        # Create the publicip
        $publicip = New-AzureRmPublicIpAddress -ResourceGroupName $rgname -name $publicIpName -location $location -AllocationMethod Dynamic -DomainNameLabel $domainNameLabel

		# create the ipconfig with primary true
		
		# Create the ipconfiguration
		$ipconfig1 = New-AzureRmNetworkInterfaceIpConfig -Name $ipconfig1Name -Subnet $vnet.Subnets[0] -PublicIpAddress $publicip -Primary
		$ipconfig2 = New-AzureRmNetworkInterfaceIpConfig -Name $ipconfig2Name -PrivateIpAddressVersion IPv4 -Subnet $vnet.Subnets[0]

        # Create NetworkInterface
        $actualNic = New-AzureRmNetworkInterface -Name $nicName -ResourceGroupName $rgname -Location $location -IpConfiguration $ipconfig1,$ipconfig2 -Tag @{ testtag = "testval" }
        $expectedNic = Get-AzureRmNetworkInterface -Name $nicName -ResourceGroupName $rgname
			
		Assert-AreEqual 2 @($expectedNic.IpConfigurations).Count

        Assert-AreEqual $expectedNic.ResourceGroupName $actualNic.ResourceGroupName	
        Assert-AreEqual $expectedNic.Name $actualNic.Name	
        Assert-AreEqual $expectedNic.Location $actualNic.Location
        Assert-NotNull $expectedNic.ResourceGuid
        Assert-AreEqual "Succeeded" $expectedNic.ProvisioningState

		# primary CA
        Assert-AreEqual $expectedNic.IpConfigurations[0].Name $actualNic.IpConfigurations[0].Name
        Assert-AreEqual $expectedNic.IpConfigurations[0].PublicIpAddress.Id $actualNic.IpConfigurations[0].PublicIpAddress.Id
        Assert-AreEqual $expectedNic.IpConfigurations[0].Subnet.Id $actualNic.IpConfigurations[0].Subnet.Id
		Assert-AreEqual $expectedNic.IpConfigurations[0].Primary $True
        Assert-NotNull $expectedNic.IpConfigurations[0].PrivateIpAddress
		Assert-AreEqual "Dynamic" $expectedNic.IpConfigurations[0].PrivateIpAllocationMethod


		# secondary  CA

		Assert-AreEqual $expectedNic.IpConfigurations[1].Name $actualNic.IpConfigurations[1].Name
        Assert-AreEqual $expectedNic.IpConfigurations[1].PublicIpAddress.Id $actualNic.IpConfigurations[1].PublicIpAddress.Id
        Assert-AreEqual $expectedNic.IpConfigurations[1].Subnet.Id $actualNic.IpConfigurations[1].Subnet.Id
		Assert-AreEqual $expectedNic.IpConfigurations[1].Primary $False
		Assert-NotNull $expectedNic.IpConfigurations[1].PrivateIpAddress
		Assert-AreEqual "Dynamic" $expectedNic.IpConfigurations[1].PrivateIpAllocationMethod
                
        # Check publicIp address reference
        $publicip = Get-AzureRmPublicIpAddress -ResourceGroupName $rgname -name $publicIpName
        Assert-AreEqual $expectedNic.IpConfigurations[0].PublicIpAddress.Id $publicip.Id
        Assert-AreEqual $expectedNic.IpConfigurations[0].Id $publicip.IpConfiguration.Id

        # Check Subnet address reference
        $vnet = Get-AzureRmvirtualNetwork -Name $vnetName -ResourceGroupName $rgname
        Assert-AreEqual $expectedNic.IpConfigurations[0].Subnet.Id $vnet.Subnets[0].Id
		Assert-AreEqual $expectedNic.IpConfigurations[1].Subnet.Id $vnet.Subnets[0].Id
        Assert-AreEqual $expectedNic.IpConfigurations[0].Id $vnet.Subnets[0].IpConfigurations[0].Id		

        # list
        $list = Get-AzureRmNetworkInterface -ResourceGroupName $rgname
        Assert-AreEqual 1 @($list).Count
        Assert-AreEqual $list[0].ResourceGroupName $actualNic.ResourceGroupName	
        Assert-AreEqual $list[0].Name $actualNic.Name	
        Assert-AreEqual $list[0].Location $actualNic.Location
        Assert-AreEqual "Succeeded" $list[0].ProvisioningState
        Assert-AreEqual $actualNic.Etag $list[0].Etag


		# edit primary for nic to take a different IP
		$nicAfterAdd = Get-AzureRmNetworkInterface -Name $nicName -ResourceGroupName $rgname | Add-AzureRmNetworkInterfaceIpConfig -Name $ipconfig3Name -PrivateIpAddressVersion IPv4 -Subnet $vnet.Subnets[0]| Set-AzureRmNetworkInterface 
		Assert-AreEqual 3 @($nicAfterAdd.IpConfigurations).Count

		$nicAfterAdd = Get-AzureRmNetworkInterface -Name $nicName -ResourceGroupName $rgname | Remove-AzureRmNetworkInterfaceIpConfig -Name $ipconfig2Name | Set-AzureRmNetworkInterface 
		Assert-AreEqual 2 @($nicAfterAdd.IpConfigurations).Count

		# edit primary for nic to take a different IP
		$nicLatest = Get-AzureRmNetworkInterface -Name $nicName -ResourceGroupName $rgname | Set-AzureRmNetworkInterfaceIpConfig -Name $ipconfig1Name -PrivateIpAddressVersion IPv4 -Subnet $vnet.Subnets[0] -PrivateIpAddress 10.0.1.43 -Primary | Set-AzureRmNetworkInterface 
		Assert-AreEqual $nicLatest.IpConfigurations[0].Id $expectedNic.IpConfigurations[0].Id
		Assert-AreEqual $nicLatest.IpConfigurations[0].PrivateIpAddress "10.0.1.43"
		Assert-AreEqual 2 @($nicAfterAdd.IpConfigurations).Count

		# edit primary for nic to take a different IP
		$nicLatest = Get-AzureRmNetworkInterface -Name $nicName -ResourceGroupName $rgname | Set-AzureRmNetworkInterfaceIpConfig -Name $ipconfig1Name -PrivateIpAddressVersion IPv4 -Subnet $vnet.Subnets[0] -PrivateIpAddress 10.0.1.43 -Primary | Set-AzureRmNetworkInterface

        # Delete NetworkInterface
        $delete = Remove-AzureRmNetworkInterface -ResourceGroupName $rgname -name $nicName -PassThru -Force
        Assert-AreEqual true $delete
        
        $list = Get-AzureRmNetworkInterface -ResourceGroupName $rgname
        Assert-AreEqual 0 @($list).Count
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}
