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
        $dnsResolverName = $env.DnsResolverName61
        $virtualNetworkId = $env.VirtualNetworkId61
        $inboundEndpointName =  $env.InboundEndpointNamePrefix + (RandomString -allChars $false -len 6)
        $subnetid = $env.SubnetId61
        $privateIp = RandomIp
        $ipConfiguration = New-AzDnsResolverIPConfigurationObject -PrivateIPAddress $privateIp -PrivateIPAllocationMethod Dynamic -SubnetId $subnetid 

         New-AzDnsResolver -Name $dnsResolverName -ResourceGroupName $env.ResourceGroupName -VirtualNetworkId $virtualNetworkId -Location $env.ResourceLocation
         New-AzDnsResolverInboundEndpoint -DnsResolverName $dnsResolverName -Name $inboundEndpointName -ResourceGroupName $env.ResourceGroupName -IPConfiguration $ipConfiguration

         Remove-AzDnsResolverInboundEndpoint  -DnsResolverName $dnsResolverName -Name $inboundEndpointName -ResourceGroupName $env.ResourceGroupName
         {Get-AzDnsResolverInboundEndpoint  -DnsResolverName $dnsResolverName -Name $inboundEndpointName -ResourceGroupName $env.ResourceGroupName } | Should -Throw "not found"
    }

    It 'Delete an Inbound Endpoint via identity, expected Inbound Endpoint deleted' {
        $dnsResolverName = $env.DnsResolverName62
        $virtualNetworkId = $env.VirtualNetworkId62
        $inboundEndpointName =  $env.InboundEndpointNamePrefix + (RandomString -allChars $false -len 6)
        $subnetid = $env.SubnetId62
        $privateIp = RandomIp
        $ipConfiguration = New-AzDnsResolverIPConfigurationObject -PrivateIPAddress $privateIp -PrivateIPAllocationMethod Dynamic -SubnetId $subnetid 
         New-AzDnsResolver -Name $dnsResolverName -ResourceGroupName $env.ResourceGroupName -VirtualNetworkId $virtualNetworkId -Location $env.ResourceLocation
         New-AzDnsResolverInboundEndpoint -DnsResolverName $dnsResolverName -Name $inboundEndpointName -ResourceGroupName $env.ResourceGroupName -IPConfiguration $ipConfiguration
         $inputObject = Get-AzDnsResolverInboundEndpoint  -DnsResolverName $dnsResolverName -Name $inboundEndpointName -ResourceGroupName $env.ResourceGroupName

         Remove-AzDnsResolverInboundEndpoint -InputObject $inputObject
         {Get-AzDnsResolverInboundEndpoint  -DnsResolverName $dnsResolverName -Name $inboundEndpointName -ResourceGroupName $env.ResourceGroupName } | Should -Throw "not found"
    }

    It 'Delete an Inbound Endpoint that does not exist by name, expected failure' {
        $dnsResolverName = $env.DnsResolverName63
        $virtualNetworkId = $env.VirtualNetworkId63
        $inboundEndpointName =  $env.InboundEndpointNamePrefix + (RandomString -allChars $false -len 6)
         New-AzDnsResolver -Name $dnsResolverName -ResourceGroupName $env.ResourceGroupName -VirtualNetworkId $virtualNetworkId -Location $env.ResourceLocation

         Remove-AzDnsResolverInboundEndpoint  -DnsResolverName $dnsResolverName -Name $inboundEndpointName -ResourceGroupName $env.ResourceGroupName
    }
}
