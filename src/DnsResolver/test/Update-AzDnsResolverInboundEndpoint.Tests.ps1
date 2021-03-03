."$PSScriptRoot\testDataGenerator.ps1"
."$PSScriptRoot\virtualNetworkClient.ps1"
."$PSScriptRoot\dnsResolverAssertions.ps1"

Add-AssertionOperator -Name 'BeSuccessfullyCreated' -Test $Function:BeSuccessfullyCreated
Add-AssertionOperator -Name 'BeSameInboundEndpointAsExpected' -Test $Function:BeSameInboundEndpointAsExpected
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
    It 'Update inbound endpoint with no change, expect inbound endpoint not changed' {
        $dnsResolverName = $env.DnsResolverName46
        $virtualNetworkId = $env.VirtualNetworkId46
        $inboundEndpointName =  $env.InboundEndpointNamePrefix + (RandomString -allChars $false -len 6)
        $subnetid = $env.SubnetId46
        $privateIp = RandomIp

        $ipConfiguration = New-AzDnsResolverIPConfigurationObject -PrivateIPAddress $privateIp -PrivateIPAllocationMethod Dynamic -SubnetId $subnetid 
        New-AzDnsResolver -Name $dnsResolverName -ResourceGroupName $env.ResourceGroupName -VirtualNetworkId $virtualNetworkId -Location $env.ResourceLocation
        $inboundEndpoint = New-AzDnsResolverInboundEndpoint -DnsResolverName $dnsResolverName -Name $inboundEndpointName -ResourceGroupName $env.ResourceGroupName -IPConfiguration $ipConfiguration

        Update-AzDnsResolverInboundEndpoint -DnsResolverName $dnsResolverName -Name $inboundEndpointName -ResourceGroupName $env.ResourceGroupName
        $retrievedInboundEndpoint = Get-AzDnsResolverInboundEndpoint -InputObject $inboundEndpoint
        $retrievedInboundEndpoint | Should -BeSameInboundEndpointAsExpected inboundEndpoint
        $retrievedInboundEndpoint.Metadata.Count | Should -Be 0
    }

    It 'Update inbound endpoint with new metaddata expect inbound endpoint updated' {
        $dnsResolverName = $env.DnsResolverName47
        $virtualNetworkId = $env.VirtualNetworkId47
        $inboundEndpointName =  $env.InboundEndpointNamePrefix + (RandomString -allChars $false -len 6)
        $subnetid = $env.SubnetId46
        $privateIp = RandomIp

        $ipConfiguration = New-AzDnsResolverIPConfigurationObject -PrivateIPAddress $privateIp -PrivateIPAllocationMethod Dynamic -SubnetId $subnetid 
        New-AzDnsResolver -Name $dnsResolverName -ResourceGroupName $env.ResourceGroupName -VirtualNetworkId $virtualNetworkId -Location $env.ResourceLocation
        $inboundEndpoint = New-AzDnsResolverInboundEndpoint -DnsResolverName $dnsResolverName -Name $inboundEndpointName -ResourceGroupName $env.ResourceGroupName -IPConfiguration $ipConfiguration

        Update-AzDnsResolverInboundEndpoint -DnsResolverName $dnsResolverName -Name $inboundEndpointName -ResourceGroupName $env.ResourceGroupName
        $retrievedInboundEndpoint = Get-AzDnsResolverInboundEndpoint -InputObject $inboundEndpoint
        $retrievedInboundEndpoint | Should -BeSuccessfullyCreatedInboundEndpoint
        $retrievedInboundEndpoint.Metadata.Count | Should -Be 0
    }

    It 'Update inbound endpoint with new metadata via identity, expect inbound endpoint updated' -skip {
        $dnsResolverName = $env.DnsResolverName48
        $virtualNetworkId = $env.VirtualNetworkId48
        $inboundEndpointName =  $env.InboundEndpointNamePrefix + (RandomString -allChars $false -len 6)
        $subnetid = $env.SubnetId46
        $privateIp = RandomIp

        $ipConfiguration = New-AzDnsResolverIPConfigurationObject -PrivateIPAddress $privateIp -PrivateIPAllocationMethod Dynamic -SubnetId $subnetid 
        New-AzDnsResolver -Name $dnsResolverName -ResourceGroupName $env.ResourceGroupName -VirtualNetworkId $virtualNetworkId -Location $env.ResourceLocation
        $inboundEndpoint = New-AzDnsResolverInboundEndpoint -DnsResolverName $dnsResolverName -Name $inboundEndpointName -ResourceGroupName $env.ResourceGroupName -IPConfiguration $ipConfiguration
        $inputObject = (Get-AzDnsResolverInboundEndpoint -DnsResolverName $dnsResolverName -Name $inboundEndpointName -ResourceGroupName $env.ResourceGroupName)
        $metadata  = GetRandomHashtable -size 2
        Update-AzDnsResolverInboundEndpoint -InputObject $inputObject -Metadaat $metadata

        $retrievedInboundEndpoint = Get-AzDnsResolverInboundEndpoint -InputObject $inboundEndpoint

        $retrievedInboundEndpoint | Should -BeSameInboundEndpointAsExpected inboundEndpoint
        $retrievedInboundEndpoint.Metadata.Count | Should -Be metadata.Count
    }

    It 'Update inbound endpoint with new metadata via identity and IfMatch matches, expect inbound endpoint updated' {
        $dnsResolverName = $env.DnsResolverName49
        $virtualNetworkId = $env.VirtualNetworkId49
        $inboundEndpointName =  $env.InboundEndpointNamePrefix + (RandomString -allChars $false -len 6)
        $subnetid = $env.SubnetId46
        $privateIp = RandomIp

        $ipConfiguration = New-AzDnsResolverIPConfigurationObject -PrivateIPAddress $privateIp -PrivateIPAllocationMethod Dynamic -SubnetId $subnetid 
        $metadata  = GetRandomHashtable -size 6
        New-AzDnsResolver -Name $dnsResolverName -ResourceGroupName $env.ResourceGroupName -VirtualNetworkId $virtualNetworkId -Location $env.ResourceLocation -Metadata $metadata
        $inboundEndpoint = New-AzDnsResolverInboundEndpoint -DnsResolverName $dnsResolverName -Name $inboundEndpointName -ResourceGroupName $env.ResourceGroupName -IPConfiguration $ipConfiguration
        $inputObject = (Get-AzDnsResolverInboundEndpoint -DnsResolverName $dnsResolverName -Name $inboundEndpointName -ResourceGroupName $env.ResourceGroupName)
        $newMetadata  = GetRandomHashtable -size 2
        Update-AzDnsResolverInboundEndpoint -InputObject $inputObject -Metadata $newMetadata -IfMatch inputObject.Etag

        $retrievedInboundEndpoint = Get-AzDnsResolverInboundEndpoint -InputObject $inboundEndpoint

        $retrievedInboundEndpoint | Should -BeSameInboundEndpointAsExpected inboundEndpoint
        $retrievedInboundEndpoint.Metadata.Count | Should -Be newMetadata.Count
    }

    
    It 'Update inbound endpoint with new metadata via identity and IfMatch not match, expect inbound endpoint not updated' {
        $dnsResolverName = $env.DnsResolverName50
        $virtualNetworkId = $env.VirtualNetworkId50
        $inboundEndpointName =  $env.InboundEndpointNamePrefix + (RandomString -allChars $false -len 6)
        $subnetid = $env.SubnetId46
        $privateIp = RandomIp

        $ipConfiguration = New-AzDnsResolverIPConfigurationObject -PrivateIPAddress $privateIp -PrivateIPAllocationMethod Dynamic -SubnetId $subnetid 
        $metadata  = GetRandomHashtable -size 6
        New-AzDnsResolver -Name $dnsResolverName -ResourceGroupName $env.ResourceGroupName -VirtualNetworkId $virtualNetworkId -Location $env.ResourceLocation -Metadata $metadata
        $inboundEndpoint = New-AzDnsResolverInboundEndpoint -DnsResolverName $dnsResolverName -Name $inboundEndpointName -ResourceGroupName $env.ResourceGroupName -IPConfiguration $ipConfiguration
        $inputObject = (Get-AzDnsResolverInboundEndpoint -DnsResolverName $dnsResolverName -Name $inboundEndpointName -ResourceGroupName $env.ResourceGroupName)
        $newMetadata  = GetRandomHashtable -size 2
        $ranomEtag = (RandomString -allChars $false -len 10)
        Update-AzDnsResolverInboundEndpoint -InputObject $inputObject -Metadata $newMetadata -IfMatch $ranomEtag

        $retrievedInboundEndpoint = Get-AzDnsResolverInboundEndpoint -InputObject $inboundEndpoint

        $retrievedInboundEndpoint | Should -BeSameInboundEndpointAsExpected inboundEndpoint
        $retrievedInboundEndpoint.Metadata.Count | Should -Not -Be newMetadata.Count
    }

}
