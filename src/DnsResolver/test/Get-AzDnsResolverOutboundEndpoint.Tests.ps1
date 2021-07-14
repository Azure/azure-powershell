."$PSScriptRoot\testDataGenerator.ps1"
."$PSScriptRoot\virtualNetworkClient.ps1"
."$PSScriptRoot\outboundEndpointAssertions.ps1"
."$PSScriptRoot\stringExtensions.ps1"

Add-AssertionOperator -Name 'BeSuccessfullyCreatedOutboundEndpoint' -Test $Function:BeSuccessfullyCreatedOutboundEndpoint

$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzDnsResolverOutboundEndpoint.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Get-AzDnsResolverOutboundEndpoint' -skip {
    It 'Get single outbound endpoint by name, expect outbound endpoint by name retrieved' {
        $outboundEndpointName = $env.OutboundEndpointNameForGet
        $outboundEndpoint =  Get-AzDnsResolverOutboundEndpoint -DnsResolverName $env.DnsResolverNameForOutboundEndpointGet -Name $outboundEndpointName -ResourceGroupName $env.ResourceGroupName
        $outboundEndpoint | Should -BeSuccessfullyCreatedOutboundEndpoint
    }

    It 'Get single outbound endpoint that does not exist by name, expect failure' -skip {
        $outboundEndpointName = (RandomString -allChars $false -len 10)
        {Get-AzDnsResolverOutboundEndpoint -DnsResolverName $env.DnsResolverNameForOutboundEndpointGet -Name $outboundEndpointName -ResourceGroupName $env.ResourceGroupName} | Should -Throw "not found"
    }

    It 'List outbound Endpoints under a DNS Resolver name, expected exact number of outbound endpoints retrieved' -skip {
        $dnsResolverName = $env.DnsResolverNameForOutboundEndpointGet
        $outboundEndpoints =  Get-AzDnsResolverOutboundEndpoint -DnsResolverName $dnsResolverName -ResourceGroupName $env.ResourceGroupName
        $outboundEndpoints.Count | Should -Be $env.NumberOfOutboundEndpointForGet
    }
}
