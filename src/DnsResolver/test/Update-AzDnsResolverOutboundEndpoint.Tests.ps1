."$PSScriptRoot\testDataGenerator.ps1"
."$PSScriptRoot\virtualNetworkClient.ps1"
."$PSScriptRoot\outboundEndpointAssertions.ps1"

Add-AssertionOperator -Name 'BeSuccessfullyCreatedOutboundEndpoint' -Test $Function:BeSuccessfullyCreatedOutboundEndpoint
Add-AssertionOperator -Name 'BeSameOutboundEndpointAsExpected' -Test $Function:BeSameOutboundEndpointAsExpected

$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)){
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzDnsResolverOutboundEndpoint.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath){
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Update-AzDnsResolverOutboundEndpoint'{
    It 'Update outbound endpoint with no change, expect outbound endpoint not changed' -skip{
        $dnsResolverName = $env.DnsResolverName22
        $virtualNetworkId = $env.VirtualNetworkId22
        $outboundEndpointName =  $env.OutboundEndpointNamePrefix + (RandomString -allChars $false -len 6)
        $subnetid = $env.SubnetId22
        $privateIp = RandomIp
        $ipConfiguration = New-AzDnsResolverIPConfigurationObject -PrivateIPAddress $privateIp -PrivateIPAllocationMethod Dynamic -SubnetId $subnetid 

        New-AzDnsResolver -Name $dnsResolverName -ResourceGroupName $env.ResourceGroupName -VirtualNetworkId $virtualNetworkId -Location $env.ResourceLocation
        $outboundEndpoint = New-AzDnsResolverOutboundEndpoint -DnsResolverName $dnsResolverName -Name $outboundEndpointName -ResourceGroupName $env.ResourceGroupName -SubscriptionId $env.SubscriptionId -SubnetId $subnetid
        $outboundEndpoint | Should -BeSuccessfullyCreatedOutboundEndpoint
        Update-AzDnsResolverOutboundEndpoint -DnsResolverName $dnsResolverName -Name $outboundEndpointName -ResourceGroupName $env.ResourceGroupName
        $retrievedOutboundEndpoint = Get-AzDnsResolverOutboundEndpoint -InputObject $outboundEndpoint
        $retrievedOutboundEndpoint | Should -BeSameOutboundEndpointAsExpected $outboundEndpoint
        $retrievedOutboundEndpoint.Metadata.Count | Should -Be 0
    }

    It 'Update outbound endpoint with new metaddata expect outbound endpoint updated' -skip {
        $dnsResolverName = $env.DnsResolverName23
        $virtualNetworkId = $env.VirtualNetworkId23
        $outboundEndpointName =  $env.OutboundEndpointNamePrefix + (RandomString -allChars $false -len 6)
        $subnetid = $env.SubnetId23
        $privateIp = RandomIp
        $ipConfiguration = New-AzDnsResolverIPConfigurationObject -PrivateIPAddress $privateIp -PrivateIPAllocationMethod Dynamic -SubnetId $subnetid 

        New-AzDnsResolver -Name $dnsResolverName -ResourceGroupName $env.ResourceGroupName -VirtualNetworkId $virtualNetworkId -Location $env.ResourceLocation
        $outboundEndpoint = New-AzDnsResolverOutboundEndpoint -DnsResolverName $dnsResolverName -Name $outboundEndpointName -ResourceGroupName $env.ResourceGroupName -SubscriptionId $env.SubscriptionId -SubnetId $subnetid
        $outboundEndpoint | Should -BeSuccessfullyCreatedOutboundEndpoint

        $metadata  = GetRandomHashtable -size 2
        Update-AzDnsResolverOutboundEndpoint -DnsResolverName $dnsResolverName -Name $outboundEndpointName -ResourceGroupName $env.ResourceGroupName -Metadata $metadata
        $retrievedOutboundEndpoint = Get-AzDnsResolverOutboundEndpoint -InputObject $outboundEndpoint
        $retrievedOutboundEndpoint | Should -BeSuccessfullyCreatedOutboundEndpoint
        $retrievedOutboundEndpoint.Metadata.Count | Should -Be 3
    }

    It 'Update outbound endpoint with new metadata via identity, expect outbound endpoint updated' -skip {
        $dnsResolverName = $env.DnsResolverName24
        $virtualNetworkId = $env.VirtualNetworkId24
        $outboundEndpointName =  $env.OutboundEndpointNamePrefix + (RandomString -allChars $false -len 6)
        $subnetid = $env.SubnetId24
        $privateIp = RandomIp
        $ipConfiguration = New-AzDnsResolverIPConfigurationObject -PrivateIPAddress $privateIp -PrivateIPAllocationMethod Dynamic -SubnetId $subnetid 

        New-AzDnsResolver -Name $dnsResolverName -ResourceGroupName $env.ResourceGroupName -VirtualNetworkId $virtualNetworkId -Location $env.ResourceLocation
        $outboundEndpoint = New-AzDnsResolverOutboundEndpoint -DnsResolverName $dnsResolverName -Name $outboundEndpointName -ResourceGroupName $env.ResourceGroupName -SubscriptionId $env.SubscriptionId -SubnetId $subnetid
        $outboundEndpoint | Should -BeSuccessfullyCreatedOutboundEndpoint
        $inputObject = (Get-AzDnsResolverOutboundEndpoint -DnsResolverName $dnsResolverName -Name $outboundEndpointName -ResourceGroupName $env.ResourceGroupName)
        $metadata  = GetRandomHashtable -size 2
        Update-AzDnsResolverOutboundEndpoint -InputObject $inputObject -Metadata $metadata

        $retrievedOutboundEndpoint = Get-AzDnsResolverOutboundEndpoint -InputObject $outboundEndpoint

        $retrievedOutboundEndpoint | Should -BeSameOutboundEndpointAsExpected $outboundEndpoint
        $retrievedOutboundEndpoint.Metadata.Count | Should -Be 3
    }

    It 'Update outbound endpoint with new metadata via identity and IfMatch matches, expect outbound endpoint updated' -skip {
        $dnsResolverName = $env.DnsResolverName25
        $virtualNetworkId = $env.VirtualNetworkId25
        $outboundEndpointName =  $env.OutboundEndpointNamePrefix + (RandomString -allChars $false -len 6)
        $subnetid = $env.SubnetId25
        $privateIp = RandomIp
        $ipConfiguration = New-AzDnsResolverIPConfigurationObject -PrivateIPAddress $privateIp -PrivateIPAllocationMethod Dynamic -SubnetId $subnetid 

        New-AzDnsResolver -Name $dnsResolverName -ResourceGroupName $env.ResourceGroupName -VirtualNetworkId $virtualNetworkId -Location $env.ResourceLocation
        $outboundEndpoint = New-AzDnsResolverOutboundEndpoint -DnsResolverName $dnsResolverName -Name $outboundEndpointName -ResourceGroupName $env.ResourceGroupName -SubscriptionId $env.SubscriptionId -SubnetId $subnetid
        $outboundEndpoint | Should -BeSuccessfullyCreatedOutboundEndpoint
        $inputObject = (Get-AzDnsResolverOutboundEndpoint -DnsResolverName $dnsResolverName -Name $outboundEndpointName -ResourceGroupName $env.ResourceGroupName)
        $newMetadata  = GetRandomHashtable -size 2
        Update-AzDnsResolverOutboundEndpoint -InputObject $inputObject -Metadata $newMetadata -IfMatch $inputObject.Etag

        $retrievedOutboundEndpoint = Get-AzDnsResolverOutboundEndpoint -InputObject $outboundEndpoint

        $retrievedOutboundEndpoint | Should -BeSameOutboundEndpointAsExpected $outboundEndpoint
        $retrievedOutboundEndpoint.Metadata.Count | Should -Be $newMetadata.Count
    }

    
    It 'Update outbound endpoint with new metadata via identity and IfMatch not match, expect outbound endpoint not updated' -skip {
        $dnsResolverName = $env.DnsResolverName26
        $virtualNetworkId = $env.VirtualNetworkId26
        $outboundEndpointName =  $env.OutboundEndpointNamePrefix + (RandomString -allChars $false -len 6)
        $subnetid = $env.SubnetId26
        $privateIp = RandomIp
        $ipConfiguration = New-AzDnsResolverIPConfigurationObject -PrivateIPAddress $privateIp -PrivateIPAllocationMethod Dynamic -SubnetId $subnetid 

        New-AzDnsResolver -Name $dnsResolverName -ResourceGroupName $env.ResourceGroupName -VirtualNetworkId $virtualNetworkId -Location $env.ResourceLocation
        $outboundEndpoint = New-AzDnsResolverOutboundEndpoint -DnsResolverName $dnsResolverName -Name $outboundEndpointName -ResourceGroupName $env.ResourceGroupName -SubscriptionId $env.SubscriptionId -SubnetId $subnetid
        $outboundEndpoint | Should -BeSuccessfullyCreatedOutboundEndpoint
        $inputObject = (Get-AzDnsResolverOutboundEndpoint -DnsResolverName $dnsResolverName -Name $outboundEndpointName -ResourceGroupName $env.ResourceGroupName)
        $newMetadata  = GetRandomHashtable -size 2
        $randomEtag = (RandomString -allChars $false -len 10)
        {Update-AzDnsResolverOutboundEndpoint -InputObject $inputObject -Metadata $newMetadata -IfMatch $randomEtag} | Should -Throw "is invalid"

        $retrievedOutboundEndpoint = Get-AzDnsResolverOutboundEndpoint -InputObject $outboundEndpoint

        $retrievedOutboundEndpoint | Should -BeSameOutboundEndpointAsExpected $outboundEndpoint
        $retrievedOutboundEndpoint.Metadata.Count | Should -Not -Be $newMetadata.Count
    }

}
