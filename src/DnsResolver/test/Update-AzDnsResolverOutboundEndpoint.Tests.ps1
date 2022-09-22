."$PSScriptRoot\testDataGenerator.ps1"
."$PSScriptRoot\virtualNetworkClient.ps1"
."$PSScriptRoot\outboundEndpointAssertions.ps1"
."$PSScriptRoot\Constants.ps1"

Add-AssertionOperator -Name 'BeSuccessfullyCreatedOutboundEndpoint' -Test $Function:BeSuccessfullyCreatedOutboundEndpoint

$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzDnsResolverOutboundEndpoint.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Update-AzDnsResolverOutboundEndpoint' {
    It 'Update outbound endpoint by adding tag, expect outbound endpoint updated' {
        # ARRANGE
        $dnsResolverName = "psdnsresolvername50";
        $outboundEndpointName =  "psinboundendpointname50";
        $virtualNetworkName = "psvirtualnetworkname50";
        $virtualNetworkId = "/subscriptions/$SUBSCRIPTION_ID/resourceGroups/$RESOURCE_GROUP_NAME/providers/Microsoft.Network/virtualNetworks/$virtualNetworkName"
        $subnetId = $virtualNetworkId + "/subnets" + $SUBNET_NAME;
        
        if ($TestMode -eq "Record")
        {
            $virtualNetwork = CreateVirtualNetwork -SubscriptionId $SUBSCRIPTION_ID -ResourceGroupName $RESOURCE_GROUP_NAME -VirtualNetworkName $virtualNetworkName;
            $subnet = CreateSubnet -SubscriptionId $SUBSCRIPTION_ID -ResourceGroupName $RESOURCE_GROUP_NAME -VirtualNetworkName $virtualNetworkName;
        }

        New-AzDnsResolver -Name $dnsResolverName -ResourceGroupName $RESOURCE_GROUP_NAME -VirtualNetworkId $virtualNetworkId -Location $LOCATION
        
        New-AzDnsResolverOutboundEndpoint -DnsResolverName $dnsResolverName -Name $outboundEndpointName -ResourceGroupName $RESOURCE_GROUP_NAME -SubnetId $subnetId -Location $LOCATION

        $tag  = GetRandomHashtable -size 5

        # ACT
        $updatedOutboundEndpoint = Update-AzDnsResolverOutboundEndpoint -Name $outboundEndpointName -DnsResolverName $dnsResolverName -ResourceGroupName $RESOURCE_GROUP_NAME -Tag $tag

        # ASSERT
        $updatedOutboundEndpoint | Should -BeSuccessfullyCreatedOutboundEndpoint
        $updatedOutboundEndpoint.Tag.Count | Should -Be $tag.Count
    }
}