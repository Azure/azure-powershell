."$PSScriptRoot\testDataGenerator.ps1"
."$PSScriptRoot\virtualNetworkClient.ps1"
."$PSScriptRoot\inboundEndpointAssertions.ps1"
."$PSScriptRoot\Constants.ps1"

Add-AssertionOperator -Name 'BeSuccessfullyCreatedInboundEndpoint' -Test $Function:BeSuccessfullyCreatedInboundEndpoint

$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzDnsResolverInboundEndpoint.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Update-AzDnsResolverInboundEndpoint' {
    It 'Update inbound endpoint by adding tag, expect inbound endpoint updated' {
        # ARRANGE
        $dnsResolverName = "psdnsresolvername48";
        $inboundEndpointName =  "psinboundendpointname48";
        $virtualNetworkName = "psvirtualnetworkname48";
        $virtualNetworkId = "/subscriptions/$SUBSCRIPTION_ID/resourceGroups/$RESOURCE_GROUP_NAME/providers/Microsoft.Network/virtualNetworks/$virtualNetworkName"
        $subnetId = $virtualNetworkId + "/subnets" + $SUBNET_NAME;
        
        if ($TestMode -eq "Record")
        {
            $virtualNetwork = CreateVirtualNetwork -SubscriptionId $SUBSCRIPTION_ID -ResourceGroupName $RESOURCE_GROUP_NAME -VirtualNetworkName $virtualNetworkName;
            $subnet = CreateSubnet -SubscriptionId $SUBSCRIPTION_ID -ResourceGroupName $RESOURCE_GROUP_NAME -VirtualNetworkName $virtualNetworkName;
        }

        New-AzDnsResolver -Name $dnsResolverName -ResourceGroupName $RESOURCE_GROUP_NAME -VirtualNetworkId $virtualNetworkId -Location $LOCATION
        
        $ipConfiguration = New-AzDnsResolverIPConfigurationObject -PrivateIPAllocationMethod Dynamic -SubnetId $subnetId 
        New-AzDnsResolverInboundEndpoint -DnsResolverName $dnsResolverName -Name $inboundEndpointName -ResourceGroupName $RESOURCE_GROUP_NAME -IPConfiguration $ipConfiguration -Location $LOCATION

        $tag  = GetRandomHashtable -size 5

        # ACT
        $updatedInboundEndpoint = Update-AzDnsResolverInboundEndpoint -Name $inboundEndpointName -DnsResolverName $dnsResolverName -ResourceGroupName $RESOURCE_GROUP_NAME -Tag $tag

        # ASSERT
        $updatedInboundEndpoint | Should -BeSuccessfullyCreatedInboundEndpoint
        $updatedInboundEndpoint.Tag.Count | Should -Be $tag.Count
    }
}