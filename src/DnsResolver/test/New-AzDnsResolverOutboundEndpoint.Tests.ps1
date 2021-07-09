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
    It 'Create outbound endpoint with a DNS resolver' {
        $outboundEndpoint = New-AzDnsResolverOutboundEndpoint -DnsResolverName $env.DnsResolverName0 -Name $env.OutboundEndpointName1 -ResourceGroupName $env.ResourceGroupName -SubscriptionId $env.SubscriptionId -SubnetId $env.SubnetId
        $outboundEndpoint | Should -BeSuccessfullyCreatedOutboundEndpoint
        $outboundEndpoint.SubnetId | Should -Be $env.SubnetId 
    }

    It 'Create outbound endpoint with non existent DNS resolver' {
        $nonExistantResolverName = RandomString -allChars $false -len 6
         {New-AzDnsResolverOutboundEndpoint -DnsResolverName $env.DnsResolverName0 -Name $env.OutboundEndpointName1 -ResourceGroupName $env.ResourceGroupName -SubscriptionId $env.SubscriptionId -SubnetId $env.SubnetId }| Should -Throw 'Unparseable resource ID'
    }

    It 'Create outbound endpoint IfNoneMatch wildcard, expect outbound endpoint created' {
        $tag = GetRandomHashtable -size 5
        $resolver = New-AzDnsResolverOutboundEndpoint -DnsResolverName $env.DnsResolverName0 -Name $env.OutboundEndpointName1 -ResourceGroupName $env.ResourceGroupName -SubscriptionId $env.SubscriptionId -SubnetId $env.SubnetId -Tag $tag -IfNoneMatch *
        $resolver.ProvisioningState | Should -Be $env.SuccessProvisioningState
    }
}
