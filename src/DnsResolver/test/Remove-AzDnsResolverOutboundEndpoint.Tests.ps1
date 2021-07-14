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
    It 'Delete an existing outbound endpoint by name, expect outbound endpoint deleted' -skip {
        $dnsResolverName = $env.DnsResolverName61
        $virtualNetworkId = $env.VirtualNetworkId61
        $outboundEndpointName = "outbound"
        $virtualNetworkName = ExtractArmResourceName -ResourceId $virtualNetworkId
        $subnetName = "subnetNameForRemove" + (RandomString -allChars $false -len 6)
        $subnetid = (CreateSubnet -SubscriptionId  $env.SubscriptionId -ResourceGroupName $env.ResourceGroupName -VirtualNetworkName $virtualNetworkName -SubnetName $subnetName).id
        New-AzDnsResolverOutboundEndpoint -DnsResolverName $dnsResolverName -Name $outboundEndpointName -ResourceGroupName $env.ResourceGroupName -SubscriptionId $env.SubscriptionId -SubnetId $subnetid
        Remove-AzDnsResolverOutboundEndpoint -DnsResolverName $dnsResolverName -Name $outboundEndpointName -ResourceGroupName $env.ResourceGroupName
        {Get-AzDnsResolverOutboundEndpoint -DnsResolverName $dnsResolverName -Name $outboundEndpointName -ResourceGroupName $env.ResourceGroupName} | Should -Throw 'not found'
    }

    It 'Delete an existing outbound endpoint via identity, expect outbound endpoint deleted' -skip {
        $dnsResolverName = $env.DnsResolverName61
        $virtualNetworkId = $env.VirtualNetworkId61
        $outboundEndpointName = "outbound"
        $virtualNetworkName = ExtractArmResourceName -ResourceId $virtualNetworkId
        $subnetName = "subnetNameForRemove" + (RandomString -allChars $false -len 6)
        $subnetid = (CreateSubnet -SubscriptionId  $env.SubscriptionId -ResourceGroupName $env.ResourceGroupName -VirtualNetworkName $virtualNetworkName -SubnetName $subnetName).id
        New-AzDnsResolverOutboundEndpoint -DnsResolverName $dnsResolverName -Name $outboundEndpointName -ResourceGroupName $env.ResourceGroupName -SubscriptionId $env.SubscriptionId -SubnetId $subnetid
        $resolverObject = (Get-AzDnsResolverOutboundEndpoint -DnsResolverName $dnsResolverName -Name $outboundEndpointName -ResourceGroupName $env.ResourceGroupName)
        Remove-AzDnsResolverOutboundEndpoint  -InputObject $resolverObject
        {Get-AzDnsResolverOutboundEndpoint -DnsResolverName $dnsResolverName -Name $outboundEndpointName -ResourceGroupName $env.ResourceGroupName} | Should -Throw 'not found'
    }

    It 'Delete an existing outbound endpoint by name and IfMatch success, expect outbound endpoint deleted' -skip {
        $dnsResolverName = $env.DnsResolverName61
        $virtualNetworkId = $env.VirtualNetworkId61
        $outboundEndpointName = "outbound"
        $virtualNetworkName = ExtractArmResourceName -ResourceId $virtualNetworkId
        $subnetName = "subnetNameForRemove" + (RandomString -allChars $false -len 6)
        $subnetid = (CreateSubnet -SubscriptionId  $env.SubscriptionId -ResourceGroupName $env.ResourceGroupName -VirtualNetworkName $virtualNetworkName -SubnetName $subnetName).id
        $endpoint = New-AzDnsResolverOutboundEndpoint -DnsResolverName $dnsResolverName -Name $outboundEndpointName -ResourceGroupName $env.ResourceGroupName -SubscriptionId $env.SubscriptionId -SubnetId $subnetid
        Remove-AzDnsResolverOutboundEndpoint -DnsResolverName $dnsResolverName -Name $outboundEndpointName -ResourceGroupName $env.ResourceGroupName -IfMatch $endpoint.Etag
        {Get-AzDnsResolverOutboundEndpoint -DnsResolverName $dnsResolverName -Name $outboundEndpointName -ResourceGroupName $env.ResourceGroupName} | Should -Throw 'not found'
    }

    It 'Delete an existing outbound endpoint by name and IfMatch wildcard success, expect outbound endpoint deleted' -skip {
        $dnsResolverName = $env.DnsResolverName61
        $virtualNetworkId = $env.VirtualNetworkId61
        $outboundEndpointName = "outbound"
        $virtualNetworkName = ExtractArmResourceName -ResourceId $virtualNetworkId
        $subnetName = "subnetNameForRemove" + (RandomString -allChars $false -len 6)
        $subnetid = (CreateSubnet -SubscriptionId  $env.SubscriptionId -ResourceGroupName $env.ResourceGroupName -VirtualNetworkName $virtualNetworkName -SubnetName $subnetName).id
        New-AzDnsResolverOutboundEndpoint -DnsResolverName $dnsResolverName -Name $outboundEndpointName -ResourceGroupName $env.ResourceGroupName -SubscriptionId $env.SubscriptionId -SubnetId $subnetid
        Remove-AzDnsResolverOutboundEndpoint -DnsResolverName $dnsResolverName -Name $outboundEndpointName -ResourceGroupName $env.ResourceGroupName -IfMatch *
        {Get-AzDnsResolverOutboundEndpoint -DnsResolverName $dnsResolverName -Name $outboundEndpointName -ResourceGroupName $env.ResourceGroupName} | Should -Throw 'not found'
    }

    It 'Delete an existing outbound endpoint by name and IfMatch failure, expect outbound endpoint not deleted' -skip {
        $dnsResolverName = $env.DnsResolverName61
        $virtualNetworkId = $env.VirtualNetworkId61
        $outboundEndpointName = "outbound"
        $virtualNetworkName = ExtractArmResourceName -ResourceId $virtualNetworkId
        $subnetName = "subnetNameForRemove" + (RandomString -allChars $false -len 6)
        $subnetid = (CreateSubnet -SubscriptionId  $env.SubscriptionId -ResourceGroupName $env.ResourceGroupName -VirtualNetworkName $virtualNetworkName -SubnetName $subnetName).id
        New-AzDnsResolverOutboundEndpoint -DnsResolverName $dnsResolverName -Name $outboundEndpointName -ResourceGroupName $env.ResourceGroupName -SubscriptionId $env.SubscriptionId -SubnetId $subnetid
        {Remove-AzDnsResolverOutboundEndpoint -DnsResolverName $dnsResolverName -Name $outboundEndpointName -ResourceGroupName $env.ResourceGroupName -IfMatch (RandomString -allChars $false -len 6)} | Should -Throw "is invalid"
        $resolver = Get-AzDnsResolverOutboundEndpoint -DnsResolverName $dnsResolverName -Name $outboundEndpointName -ResourceGroupName $env.ResourceGroupName
        $resolver| Should -BeSuccessfullyCreated
    }
}
