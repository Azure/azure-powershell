."$PSScriptRoot\testDataGenerator.ps1"
."$PSScriptRoot\virtualNetworkClient.ps1"
."$PSScriptRoot\inboundEndpointAssertions.ps1"

Add-AssertionOperator -Name 'BeSuccessfullyCreatedInboundEndpoint' -Test $Function:BeSuccessfullyCreatedInboundEndpoint

$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'New-AzDnsResolverInboundEndpoint.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'New-AzDnsResolverInboundEndpoint' {
    It 'Create new inbound endpoint with ip configurations only, expect inbound endpoint created' -skip {
        $dnsResolverName = $env.DnsResolverName37
        $virtualNetworkId = $env.VirtualNetworkId37
        $inboundEndpointName =  $env.InboundEndpointNamePrefix + (RandomString -allChars $false -len 6)
        $subnetid = $env.SubnetId37
        $privateIp = RandomIp
        $ipConfiguration = New-AzDnsResolverIPConfigurationObject -PrivateIPAddress $privateIp -PrivateIPAllocationMethod Dynamic -SubnetId $subnetid 

         New-AzDnsResolver -Name $dnsResolverName -ResourceGroupName $env.ResourceGroupName -VirtualNetworkId $virtualNetworkId -Location $env.ResourceLocation
         $inboundEndpoint = New-AzDnsResolverInboundEndpoint -DnsResolverName $dnsResolverName -Name $inboundEndpointName -ResourceGroupName $env.ResourceGroupName -IPConfiguration $ipConfiguration
         $inboundEndpoint | Should -BeSuccessfullyCreatedInboundEndpoint
    }

    It 'Create an inbound endpoint under an invalid DNS resolver, expect failure' -skip{
        $dnsResolverName = $env.DnsResolverName38
        $inboundEndpointName =  $env.InboundEndpointName38
        $subnetid = $env.SubnetId38
        $privateIp = RandomIp
        $ipConfiguration = New-AzDnsResolverIPConfigurationObject -PrivateIPAddress $privateIp -PrivateIPAllocationMethod Dynamic -SubnetId $subnetid 

        {New-AzDnsResolverInboundEndpoint -DnsResolverName $dnsResolverName -Name $inboundEndpointName -ResourceGroupName $env.ResourceGroupName -IPConfiguration $ipConfiguration} | Should -Throw "Can not perform requested operation on nested resource"

    }

    It 'Create new inbound endpoint with ip configurations and metadata, expect inbound endpoint created'-skip{
        $dnsResolverName = $env.DnsResolverName39
        $virtualNetworkId = $env.VirtualNetworkId39
        $inboundEndpointName =  $env.InboundEndpointNamePrefix + (RandomString -allChars $false -len 6)
        $subnetid = $env.SubnetId39
        $privateIp = RandomIp
        $ipConfiguration = New-AzDnsResolverIPConfigurationObject -PrivateIPAddress $privateIp -PrivateIPAllocationMethod Dynamic -SubnetId $subnetid 
        $metadata = GetRandomHashtable -size 5

         New-AzDnsResolver -Name $dnsResolverName -ResourceGroupName $env.ResourceGroupName -VirtualNetworkId $virtualNetworkId -Location $env.ResourceLocation
         $inboundEndpoint = New-AzDnsResolverInboundEndpoint -DnsResolverName $dnsResolverName -Name $inboundEndpointName -ResourceGroupName $env.ResourceGroupName -IPConfiguration $ipConfiguration -Metadata $metadata
         $inboundEndpoint | Should -BeSuccessfullyCreatedInboundEndpoint
         $inboundEndpoint.Metadata.Count | Should -Be $metadata.Count
    }

    It 'Create new inbound endpoint with ip configurations and metadata, expect inbound endpoint not created and not found exception thrown' -skip{
        $dnsResolverName = $env.DnsResolverName40
        $inboundEndpointName =  $env.InboundEndpointNamePrefix + (RandomString -allChars $false -len 6)
        $subnetid = $env.SubnetId40
        $privateIp = RandomIp
        $ipConfiguration = New-AzDnsResolverIPConfigurationObject -PrivateIPAddress $privateIp -PrivateIPAllocationMethod Dynamic -SubnetId $subnetid 

        {New-AzDnsResolverInboundEndpoint -DnsResolverName $dnsResolverName -Name $inboundEndpointName -ResourceGroupName $env.ResourceGroupName -IPConfiguration $ipConfiguration} | Should -Throw "not found"
    }

    It 'Update an existng inbound endpoint with new metadata, expect inbound endpoint updated' -skip{
        $dnsResolverName = $env.DnsResolverName41
        $virtualNetworkId = $env.VirtualNetworkId41
        $inboundEndpointName =  $env.InboundEndpointNamePrefix + (RandomString -allChars $false -len 6)
        $subnetid = $env.SubnetId41
        $privateIp = RandomIp
        $ipConfiguration = New-AzDnsResolverIPConfigurationObject -PrivateIPAddress $privateIp -PrivateIPAllocationMethod Dynamic -SubnetId $subnetid 

        New-AzDnsResolver -Name $dnsResolverName -ResourceGroupName $env.ResourceGroupName -VirtualNetworkId $virtualNetworkId -Location $env.ResourceLocation
        New-AzDnsResolverInboundEndpoint -DnsResolverName $dnsResolverName -Name $inboundEndpointName -ResourceGroupName $env.ResourceGroupName -IPConfiguration $ipConfiguration

        $metadata = GetRandomHashtable -size 5
        $updatedInboundEndpoint = New-AzDnsResolverInboundEndpoint -DnsResolverName $dnsResolverName -Name $inboundEndpointName -ResourceGroupName $env.ResourceGroupName -IPConfiguration $ipConfiguration -Metadata $metadata
        $updatedInboundEndpoint.Metadata.Count | Should -Be $metadata.Count
    }

    It 'Update an existng inbound endpoint with new metadata and IfNoneMatch wildcard success, expect inbound endpoint updated' -skip{
        $dnsResolverName = $env.DnsResolverName41
        $virtualNetworkId = $env.VirtualNetworkId41
        $inboundEndpointName =  $env.InboundEndpointNamePrefix + (RandomString -allChars $false -len 6)
        $subnetid = $env.SubnetId41
        $privateIp = RandomIp
        $ipConfiguration = New-AzDnsResolverIPConfigurationObject -PrivateIPAddress $privateIp -PrivateIPAllocationMethod Dynamic -SubnetId $subnetid 

        New-AzDnsResolver -Name $dnsResolverName -ResourceGroupName $env.ResourceGroupName -VirtualNetworkId $virtualNetworkId -Location $env.ResourceLocation
        New-AzDnsResolverInboundEndpoint -DnsResolverName $dnsResolverName -Name $inboundEndpointName -ResourceGroupName $env.ResourceGroupName -IPConfiguration $ipConfiguration

        $metadata = GetRandomHashtable -size 5
        $updatedInboundEndpoint = New-AzDnsResolverInboundEndpoint -DnsResolverName $dnsResolverName -Name $inboundEndpointName -ResourceGroupName $env.ResourceGroupName -IPConfiguration $ipConfiguration -Metadata $metadata -IfNoneMatch "*"
        $updatedInboundEndpoint.Metadata.Count | Should -Not -Be $metadata.Count
    }

    It 'Update an existng inbound endpoint with new metadata and IfMatch exact etag success, expect inbound endpoint updated' -skip{
        $dnsResolverName = $env.DnsResolverName41
        $virtualNetworkId = $env.VirtualNetworkId41
        $inboundEndpointName =  $env.InboundEndpointNamePrefix + (RandomString -allChars $false -len 6)
        $subnetid = $env.SubnetId41
        $privateIp = RandomIp
        $ipConfiguration = New-AzDnsResolverIPConfigurationObject -PrivateIPAddress $privateIp -PrivateIPAllocationMethod Dynamic -SubnetId $subnetid 

        New-AzDnsResolver -Name $dnsResolverName -ResourceGroupName $env.ResourceGroupName -VirtualNetworkId $virtualNetworkId -Location $env.ResourceLocation
        $inboundEndpoint = New-AzDnsResolverInboundEndpoint -DnsResolverName $dnsResolverName -Name $inboundEndpointName -ResourceGroupName $env.ResourceGroupName -IPConfiguration $ipConfiguration
        $metadata = GetRandomHashtable -size 5
        $updatedInboundEndpoint = New-AzDnsResolverInboundEndpoint -DnsResolverName $dnsResolverName -Name $inboundEndpointName -ResourceGroupName $env.ResourceGroupName -IPConfiguration $ipConfiguration -Metadata $metadata -IfMatch $inboundEndpoint.Etag
        $updatedInboundEndpoint.Metadata.Count | Should -Be $metadata.Count
    }

    It 'Update an existng inbound endpoint with new metadata and IfMatch failure, expect inbound endpoint not updated' -skip{
        $dnsResolverName = $env.DnsResolverName41
        $virtualNetworkId = $env.VirtualNetworkId41
        $inboundEndpointName =  $env.InboundEndpointNamePrefix + (RandomString -allChars $false -len 6)
        $subnetid = $env.SubnetId41
        $privateIp = RandomIp
        $ipConfiguration = New-AzDnsResolverIPConfigurationObject -PrivateIPAddress $privateIp -PrivateIPAllocationMethod Dynamic -SubnetId $subnetid 

        New-AzDnsResolver -Name $dnsResolverName -ResourceGroupName $env.ResourceGroupName -VirtualNetworkId $virtualNetworkId -Location $env.ResourceLocation
        $inboundEndpoint = New-AzDnsResolverInboundEndpoint -DnsResolverName $dnsResolverName -Name $inboundEndpointName -ResourceGroupName $env.ResourceGroupName -IPConfiguration $ipConfiguration

        $metadata = GetRandomHashtable -size 5
        $randomEtag =  RandomString -allChars $false -len 6
         {New-AzDnsResolverInboundEndpoint -DnsResolverName $dnsResolverName -Name $inboundEndpointName -ResourceGroupName $env.ResourceGroupName -IPConfiguration $ipConfiguration -Metadata $metadata -IfMatch $randomEtag} | Should -Throw "is invalid"
        $retrievedInboundEndpoint = Get-AzDnsResolverInboundEndpoint -InputObject $inboundEndpoint
         $retrievedInboundEndpoint.Metadata.Count | Should -Not -Be $metadata.Count
    }
}
