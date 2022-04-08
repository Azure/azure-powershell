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

Describe 'Remove-AzDnsResolverInboundEndpoint' {
    It 'Delete an Inbound Endpoint by name, expected Inbound Endpoint deleted' {
         # ARRANGE
        $dnsResolverName = "psdnsresolvername19";
        $inboundEndpointName =  "psinboundendpointname19";
        $virtualNetworkName = "psvirtualnetworkname19";
        
        if ($TestMode -eq "Record")
        {
            $virtualNetwork = CreateVirtualNetwork -SubscriptionId $SUBSCRIPTION_ID -ResourceGroupName $RESOURCE_GROUP_NAME -VirtualNetworkName $virtualNetworkName;
            $subnet = CreateSubnet -SubscriptionId $SUBSCRIPTION_ID -ResourceGroupName $RESOURCE_GROUP_NAME -VirtualNetworkName $virtualNetworkName;
        }

        New-AzDnsResolver -Name $dnsResolverName -ResourceGroupName $RESOURCE_GROUP_NAME -VirtualNetworkId $virtualNetwork.Id -Location $LOCATION
        $ipConfiguration = New-AzDnsResolverIPConfigurationObject -PrivateIPAllocationMethod Dynamic -SubnetId $subnet.id 

        # ACT
        Remove-AzDnsResolverInboundEndpoint  -DnsResolverName $dnsResolverName -Name $inboundEndpointName -ResourceGroupName $RESOURCE_GROUP_NAME

        # ASSERT 
        {Get-AzDnsResolverInboundEndpoint  -DnsResolverName $dnsResolverName -Name $inboundEndpointName -ResourceGroupName $RESOURCE_GROUP_NAME } | Should -Throw "not found"
    }
}
