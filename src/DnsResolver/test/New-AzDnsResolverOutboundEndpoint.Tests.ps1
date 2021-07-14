."$PSScriptRoot\testDataGenerator.ps1"
."$PSScriptRoot\virtualNetworkClient.ps1"
."$PSScriptRoot\outboundEndpointAssertions.ps1"

Add-AssertionOperator -Name 'BeSuccessfullyCreatedOutboundEndpoint' -Test $Function:BeSuccessfullyCreatedOutboundEndpoint

$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'New-AzDnsResolverOutboundEndpoint.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'New-AzDnsResolverOutboundEndpoint' {
    It 'Create outbound endpoint with a DNS resolver' -skip {
        $dnsResolverName = $env.DnsResolverName37
        $virtualNetworkId = $env.VirtualNetworkId37
        $outboundEndpointName =  $env.OutboundEndpointNamePrefix + (RandomString -allChars $false -len 6)
        $subnetid = $env.SubnetId37
        $privateIp = RandomIp
        $ipConfiguration = New-AzDnsResolverIPConfigurationObject -PrivateIPAddress $privateIp -PrivateIPAllocationMethod Dynamic -SubnetId $subnetid 

        New-AzDnsResolver -Name $dnsResolverName -ResourceGroupName $env.ResourceGroupName -VirtualNetworkId $virtualNetworkId -Location $env.ResourceLocation
        $outboundEndpoint = New-AzDnsResolverOutboundEndpoint -DnsResolverName $dnsResolverName -Name $outboundEndpointName -ResourceGroupName $env.ResourceGroupName -SubscriptionId $env.SubscriptionId -SubnetId $subnetid
        $outboundEndpoint | Should -BeSuccessfullyCreatedOutboundEndpoint
    }

    It 'Create outbound endpoint with non existent DNS resolver' -skip{
        $nonExistantResolverName = RandomString -allChars $false -len 6
         {New-AzDnsResolverOutboundEndpoint -DnsResolverName $nonExistantResolverName -Name $env.OutboundEndpointName1 -ResourceGroupName $env.ResourceGroupName -SubscriptionId $env.SubscriptionId -SubnetId $env.SubnetId35 }| Should -Throw 'ParentResourceNotFound'
    }

    It 'Create outbound endpoint IfNoneMatch wildcard, expect outbound endpoint created' -skip {
        $metadata = GetRandomHashtable -size 5
        $dnsResolverName = $env.DnsResolverName36
        $virtualNetworkId = $env.VirtualNetworkId36
        $outboundEndpointName =  $env.OutboundEndpointNamePrefix + (RandomString -allChars $false -len 6)
        $subnetid = $env.SubnetId36
        $privateIp = RandomIp
        $ipConfiguration = New-AzDnsResolverIPConfigurationObject -PrivateIPAddress $privateIp -PrivateIPAllocationMethod Dynamic -SubnetId $subnetid 

        New-AzDnsResolver -Name $dnsResolverName -ResourceGroupName $env.ResourceGroupName -VirtualNetworkId $virtualNetworkId -Location $env.ResourceLocation
        $outboundEndpoint = New-AzDnsResolverOutboundEndpoint -DnsResolverName $dnsResolverName -Name $outboundEndpointName -ResourceGroupName $env.ResourceGroupName -SubscriptionId $env.SubscriptionId -SubnetId $subnetid -Metadata metadata
        $outboundEndpoint | Should -BeSuccessfullyCreatedOutboundEndpoint
    }
}
