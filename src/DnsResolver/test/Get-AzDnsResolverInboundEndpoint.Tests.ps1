."$PSScriptRoot\testDataGenerator.ps1"
."$PSScriptRoot\virtualNetworkClient.ps1"
."$PSScriptRoot\inboundEndpointAssertions.ps1"
."$PSScriptRoot\stringExtensions.ps1"

Add-AssertionOperator -Name 'BeSuccessfullyCreatedInboundEndpoint' -Test $Function:BeSuccessfullyCreatedInboundEndpoint

$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzDnsResolverInboundEndpoint.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Get-AzDnsResolverInboundEndpoint' {
    It 'Get single inbound endpoint by name, expect inbound endpoint by name retrieved' {
        $inboundEndpointName = $env.InboundEndpointNamePrefixForGet0
        $inboundEndpoint =  Get-AzDnsResolverInboundEndpoint -DnsResolverName $env.DnsResolverNameForInboundEndpointGet -Name $inboundEndpointName -ResourceGroupName $env.ResourceGroupName
        $inboundEndpoint | Should -BeSuccessfullyCreatedInboundEndpoint
    }

    It 'Get single inbound endpoint that does not exist by name, expect failure' {
        $inboundEndpointName = (RandomString -allChars $false -len 10)
        {Get-AzDnsResolverInboundEndpoint -DnsResolverName $env.DnsResolverNameForInboundEndpointGet -Name $inboundEndpointName -ResourceGroupName $env.ResourceGroupName} | Should -Throw "not found"
    }

    It 'List Inbound Endpoints under a DNS Resolver name, expected exact number of inbound endpoints retrieved' {
        $dnsResolverName = $env.DnsResolverNameForInboundEndpointGet
        $inboundEndpoints =  Get-AzDnsResolverInboundEndpoint -DnsResolverName $dnsResolverName -ResourceGroupName $env.ResourceGroupName
        $inboundEndpoints.Count | Should -Be $env.NumberOfInboundEndpointForGet
    }
}
