$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzDnsResolverOutboundEndpoint.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Remove-AzDnsResolverOutboundEndpoint' {
    It 'Delete an existing outbound endpoint by name, expect outbound endpoint deleted'  -skip{
        $dnsResolverName = $env.DnsResolverName0
        $outboundEndpointName = "outbound"
        New-AzDnsResolverOutboundEndpoint -DnsResolverName $dnsResolverName -Name $outboundEndpointName -ResourceGroupName $env.ResourceGroupName -SubscriptionId $env.SubscriptionId -SubnetId $env.SubnetId
        Remove-AzDnsResolverOutboundEndpoint -DnsResolverName $dnsResolverName -Name $outboundEndpointName -ResourceGroupName $env.ResourceGroupName
        {Get-AzDnsResolverOutboundEndpoint -DnsResolverName $dnsResolverName -Name $outboundEndpointName -ResourceGroupName $env.ResourceGroupName} | Should -Throw 'not found'
    }

    It 'Delete an existing outbound endpoint via identity, expect outbound endpoint deleted'  -skip{
        $dnsResolverName = $env.DnsResolverName0
        $outboundEndpointName = "oubound"
        New-AzDnsResolverOutboundEndpoint -DnsResolverName $dnsResolverName -Name $outboundEndpointName -ResourceGroupName $env.ResourceGroupName -SubscriptionId $env.SubscriptionId -SubnetId $env.SubnetId
        $resolverObject = (Get-AzDnsResolverOutboundEndpoint -DnsResolverName $dnsResolverName -Name $outboundEndpointName -ResourceGroupName $env.ResourceGroupName)
        Remove-AzDnsResolverOutboundEndpoint  -InputObject $resolverObject
        {Get-AzDnsResolverOutboundEndpoint -DnsResolverName $dnsResolverName -Name $outboundEndpointName -ResourceGroupName $env.ResourceGroupName} | Should -Throw 'not found'
    }

    It 'Delete an existing outbound endpoint by name and IfMatch success, expect outbound endpoint deleted' -skip{
        $dnsResolverName = $env.DnsResolverName0
        $outboundEndpointName = "outbound"
        New-AzDnsResolverOutboundEndpoint -DnsResolverName $dnsResolverName -Name $outboundEndpointName -ResourceGroupName $env.ResourceGroupName -SubscriptionId $env.SubscriptionId -SubnetId $env.SubnetId
        Remove-AzDnsResolverOutboundEndpoint -DnsResolverName $dnsResolverName -Name $outboundEndpointName -ResourceGroupName $env.ResourceGroupName -IfMatch $resolver.Etag
        {Get-AzDnsResolverOutboundEndpoint -DnsResolverName $dnsResolverName -Name $outboundEndpointName -ResourceGroupName $env.ResourceGroupName} | Should -Throw 'not found'
    }

    It 'Delete an existing outbound endpoint by name and IfMatch wildcard success, expect outbound endpoint deleted'  -skip{
        $dnsResolverName = $env.DnsResolverName0
        $outboundEndpointName = "outbound"
        New-AzDnsResolverOutboundEndpoint -DnsResolverName $dnsResolverName -Name $outboundEndpointName -ResourceGroupName $env.ResourceGroupName -SubscriptionId $env.SubscriptionId -SubnetId $env.SubnetId
        Remove-AzDnsResolverOutboundEndpoint -DnsResolverName $dnsResolverName -Name $outboundEndpointName -ResourceGroupName $env.ResourceGroupName -IfMatch *
        {Get-AzDnsResolverOutboundEndpoint -DnsResolverName $dnsResolverName -Name $outboundEndpointName -ResourceGroupName $env.ResourceGroupName} | Should -Throw 'not found'
    }

    It 'Delete an existing outbound endpoint by name and IfMatch failure, expect outbound endpoint not deleted'  -skip{
        $dnsResolverName = $env.DnsResolverName0
        $outboundEndpointName = "outbound"
        New-AzDnsResolverOutboundEndpoint -DnsResolverName $dnsResolverName -Name $outboundEndpointName -ResourceGroupName $env.ResourceGroupName -SubscriptionId $env.SubscriptionId -SubnetId $env.SubnetId
        {Remove-AzDnsResolverOutboundEndpoint -DnsResolverName $dnsResolverName -Name $outboundEndpointName -ResourceGroupName $env.ResourceGroupName -IfMatch (RandomString -allChars $false -len 6)} | Should -Throw "is invalid"
        $resolver = Get-AzDnsResolverOutboundEndpoint -DnsResolverName $dnsResolverName -Name $outboundEndpointName -ResourceGroupName $env.ResourceGroupName
        $resolver| Should -BeSuccessfullyCreated
    }

}
