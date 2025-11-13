if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzDnsResolverInboundEndpoint'))
{
    $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
    if (-Not (Test-Path -Path $loadEnvPath)) {
        $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
    }
    . ($loadEnvPath)
    $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzDnsResolverInboundEndpoint.Recording.json'
    $currentPath = $PSScriptRoot
    while(-not $mockingPath) {
        $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
        $currentPath = Split-Path -Path $currentPath -Parent
    }
    . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzDnsResolverInboundEndpoint' {
    It 'Delete an Inbound Endpoint by name, expected Inbound Endpoint deleted' {
         # ARRANGE
        $dnsResolverName = "psdnsresolvername19";
        $inboundEndpointName =  "psinboundendpointname19";
        $virtualNetworkName = "psvirtualnetworkname19";
        $virtualNetworkId = "/subscriptions/$SUBSCRIPTION_ID/resourceGroups/$RESOURCE_GROUP_NAME/providers/Microsoft.Network/virtualNetworks/$virtualNetworkName"
        $subnetId = $virtualNetworkId + "/subnets/" + $SUBNET_NAME;
        
        if ($TestMode -eq "Record")
        {
            $defaultSubnet = New-AzVirtualNetworkSubnetConfig -Name "default" -AddressPrefix "10.0.0.0/24"
            $vnet = New-AzVirtualNetwork -Name $virtualNetworkName -ResourceGroupName $RESOURCE_GROUP_NAME -Location $location -AddressPrefix "10.0.0.0/16" -Subnet $defaultSubnet -Force
        }

        New-AzDnsResolver -Name $dnsResolverName -ResourceGroupName $RESOURCE_GROUP_NAME -VirtualNetworkId $virtualNetworkId -Location $LOCATION
        $ipConfiguration = New-AzDnsResolverIPConfigurationObject -PrivateIPAllocationMethod Dynamic -SubnetId $subnetId 

        # ACT
        Remove-AzDnsResolverInboundEndpoint  -DnsResolverName $dnsResolverName -Name $inboundEndpointName -ResourceGroupName $RESOURCE_GROUP_NAME

        # ASSERT 
        {Get-AzDnsResolverInboundEndpoint  -DnsResolverName $dnsResolverName -Name $inboundEndpointName -ResourceGroupName $RESOURCE_GROUP_NAME } | Should -Throw

        # UNDO
        Start-Sleep -Seconds 5
        Remove-AzDnsResolver -Name $dnsResolverName -ResourceGroupName $RESOURCE_GROUP_NAME
        Start-Sleep -Seconds 5
        if ($TestMode -eq "Record")
        {
            Remove-AzVirtualNetwork -Name $virtualNetworkName -ResourceGroupName $RESOURCE_GROUP_NAME -Force
        }
    }
}
