."$PSScriptRoot\testDataGenerator.ps1"
."$PSScriptRoot\virtualNetworkClient.ps1"
."$PSScriptRoot\inboundEndpointAssertions.ps1"

Add-AssertionOperator -Name 'BeSuccessfullyCreated' -Test $Function:BeSuccessfullyCreated
Add-AssertionOperator -Name 'BeSameAsExpected' -Test $Function:BeSameAsExpected
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
    It 'Get single inbound endpoint by name, expect inbound endpoint by name retrieved' -skip {
        $dnsResolverName = $env.DnsResolverName50
        $virtualNetworkId = $env.VirtualNetworkId50
        $inboundEndpointName =  $env.InboundEndpointName50
        $subnetid = $env.SubnetId50
        $privateIp = RandomIp
        $ipConfiguration = New-AzDnsResolverIPConfigurationObject -PrivateIPAddress $privateIp -PrivateIPAllocationMethod Dynamic -SubnetId $subnetid 

        New-AzDnsResolver -Name $dnsResolverName -ResourceGroupName $env.ResourceGroupName -VirtualNetworkId $virtualNetworkId -Location $env.ResourceLocation
        New-AzDnsResolverInboundEndpoint -DnsResolverName $dnsResolverName -Name $inboundEndpointName -ResourceGroupName $env.ResourceGroupName -IPConfiguration $ipConfiguration
        $retrievedInboundEndpoint | Should -BeSuccessfullyCreatedInboundEndpoint
    }

    It 'List' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Get' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'GetViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
