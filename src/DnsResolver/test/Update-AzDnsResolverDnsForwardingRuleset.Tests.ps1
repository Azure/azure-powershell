."$PSScriptRoot\testDataGenerator.ps1"
."$PSScriptRoot\virtualNetworkClient.ps1"
."$PSScriptRoot\forwardingRulesetAssertions.ps1"

Add-AssertionOperator -Name 'BeSuccessfullyCreatedDnsForwardingRuleset' -Test $Function:BeSuccessfullyCreated
Add-AssertionOperator -Name 'BeSameForwardingRulesetAsExpected' -Test $Function:BeSameAsExpected

$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)){
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzDnsResolverDnsForwardingRuleset.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath){
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Update-AzDnsResolverDnsForwardingRuleset'{
    It 'Update DNS forwarding ruleset with no change, expect DNS forwarding ruleset not changed' {
        $dnsResolverName = $env.DnsResolverName22
        $virtualNetworkId = $env.VirtualNetworkId22
        $outboundEndpointName =  $env.OutboundEndpointNamePrefix + (RandomString -allChars $false -len 6)
        $subnetid = $env.SubnetId22
        $privateIp = RandomIp
        $ipConfiguration = New-AzDnsResolverIPConfigurationObject -PrivateIPAddress $privateIp -PrivateIPAllocationMethod Dynamic -SubnetId $subnetid 

        New-AzDnsResolver -Name $dnsResolverName -ResourceGroupName $env.ResourceGroupName -VirtualNetworkId $virtualNetworkId -Location $env.ResourceLocation
        $outboundEndpoint = New-AzDnsResolverOutboundEndpoint -DnsResolverName $dnsResolverName -Name $outboundEndpointName -ResourceGroupName $env.ResourceGroupName -SubscriptionId $env.SubscriptionId -SubnetId $subnetid
        $dnsForwardingRulesetName = "forwardingRulesetForGet" + (RandomString -allChars $false -len 6)
        $ruleset = New-AzDnsResolverDnsForwardingRuleset -Name $dnsForwardingRulesetName -ResourceGroupName $env.ResourceGroupName -Location $env.ResourceLocation -DnsResolverOutboundEndpoint  @{id = $outboundEndpoint.Id;}
        $ruleset | Should -BeSuccessfullyCreatedDnsForwardingRuleset

        Update-AzDnsResolverDnsForwardingRuleset -Name $dnsForwardingRulesetName -ResourceGroupName $env.ResourceGroupName -SubscriptionId $env.SubscriptionId
        $retrievedDnsForwardingRuleset = Get-AzDnsResolverDnsForwardingRuleset -InputObject $ruleset
        $retrievedDnsForwardingRuleset | Should -BeSameForwardingRulesetAsExpected $inputObject
        $retrievedDnsForwardingRuleset.Metadata.Count | Should -Be 0
    }

    It 'Update DNS forwarding ruleset with new metaddata expect DNS forwarding ruleset updated' {
        $dnsResolverName = $env.DnsResolverName23
        $virtualNetworkId = $env.VirtualNetworkId23
        $outboundEndpointName =  $env.OutboundEndpointNamePrefix + (RandomString -allChars $false -len 6)
        $subnetid = $env.SubnetId23
        $privateIp = RandomIp
        $ipConfiguration = New-AzDnsResolverIPConfigurationObject -PrivateIPAddress $privateIp -PrivateIPAllocationMethod Dynamic -SubnetId $subnetid 

        New-AzDnsResolver -Name $dnsResolverName -ResourceGroupName $env.ResourceGroupName -VirtualNetworkId $virtualNetworkId -Location $env.ResourceLocation
        $outboundEndpoint = New-AzDnsResolverOutboundEndpoint -DnsResolverName $dnsResolverName -Name $outboundEndpointName -ResourceGroupName $env.ResourceGroupName -SubscriptionId $env.SubscriptionId -SubnetId $subnetid
        $dnsForwardingRulesetName = "forwardingRulesetForGet" + (RandomString -allChars $false -len 6)
        $ruleset = New-AzDnsResolverDnsForwardingRuleset -Name $dnsForwardingRulesetName -ResourceGroupName $env.ResourceGroupName -Location $env.ResourceLocation -DnsResolverOutboundEndpoint  @{id = $outboundEndpoint.Id;}
        $ruleset | Should -BeSuccessfullyCreatedDnsForwardingRuleset

        $metadata  = GetRandomHashtable -size 2
        Update-AzDnsResolverDnsForwardingRuleset -Name $dnsForwardingRulesetName -ResourceGroupName $env.ResourceGroupName -Tag $metadata -SubscriptionId $env.SubscriptionId
        $retrievedDnsForwardingRuleset = Get-AzDnsResolverDnsForwardingRuleset -InputObject $ruleset
        $retrievedDnsForwardingRuleset | Should -BeSameForwardingRulesetAsExpected $inputObject
        $retrievedDnsForwardingRuleset.Metadata.Count | Should -Be 3
    }

    It 'Update DNS forwarding ruleset with new metadata via identity, expect DNS forwarding ruleset updated' {
        $dnsResolverName = $env.DnsResolverName24
        $virtualNetworkId = $env.VirtualNetworkId24
        $outboundEndpointName =  $env.OutboundEndpointNamePrefix + (RandomString -allChars $false -len 6)
        $subnetid = $env.SubnetId24
        $privateIp = RandomIp
        $ipConfiguration = New-AzDnsResolverIPConfigurationObject -PrivateIPAddress $privateIp -PrivateIPAllocationMethod Dynamic -SubnetId $subnetid 

        New-AzDnsResolver -Name $dnsResolverName -ResourceGroupName $env.ResourceGroupName -VirtualNetworkId $virtualNetworkId -Location $env.ResourceLocation
        $outboundEndpoint = New-AzDnsResolverOutboundEndpoint -DnsResolverName $dnsResolverName -Name $outboundEndpointName -ResourceGroupName $env.ResourceGroupName -SubscriptionId $env.SubscriptionId -SubnetId $subnetid
        $dnsForwardingRulesetName = "forwardingRulesetForGet" + (RandomString -allChars $false -len 6)
        $ruleset = New-AzDnsResolverDnsForwardingRuleset -Name $dnsForwardingRulesetName -ResourceGroupName $env.ResourceGroupName -Location $env.ResourceLocation -DnsResolverOutboundEndpoint  @{id = $outboundEndpoint.Id;}
        $ruleset | Should -BeSuccessfullyCreatedDnsForwardingRuleset

        $inputObject = (Get-AzDnsResolverDnsForwardingRuleset -Name $dnsForwardingRulesetName -ResourceGroupName $env.ResourceGroupName)
        $metadata  = GetRandomHashtable -size 2
        Update-AzDnsResolverDnsForwardingRuleset -InputObject $inputObject -Tag $metadata -SubscriptionId $env.SubscriptionId
        $retrievedDnsForwardingRuleset = Get-AzDnsResolverDnsForwardingRuleset -InputObject $inputObject
        $retrievedDnsForwardingRuleset | Should -BeSameForwardingRulesetAsExpected $inputObject
        $retrievedDnsForwardingRuleset.Metadata.Count | Should -Be 3
    }

    It 'Update DNS forwarding ruleset with new metadata via identity and IfMatch matches, expect DNS forwarding ruleset updated' {
        $dnsResolverName = $env.DnsResolverName25
        $virtualNetworkId = $env.VirtualNetworkId25
        $outboundEndpointName =  $env.OutboundEndpointNamePrefix + (RandomString -allChars $false -len 6)
        $subnetid = $env.SubnetId25
        $privateIp = RandomIp
        $ipConfiguration = New-AzDnsResolverIPConfigurationObject -PrivateIPAddress $privateIp -PrivateIPAllocationMethod Dynamic -SubnetId $subnetid 

        New-AzDnsResolver -Name $dnsResolverName -ResourceGroupName $env.ResourceGroupName -VirtualNetworkId $virtualNetworkId -Location $env.ResourceLocation
        $outboundEndpoint = New-AzDnsResolverOutboundEndpoint -DnsResolverName $dnsResolverName -Name $outboundEndpointName -ResourceGroupName $env.ResourceGroupName -SubscriptionId $env.SubscriptionId -SubnetId $subnetid
        $dnsForwardingRulesetName = "forwardingRulesetForGet" + (RandomString -allChars $false -len 6)
        $ruleset = New-AzDnsResolverDnsForwardingRuleset -Name $dnsForwardingRulesetName -ResourceGroupName $env.ResourceGroupName -Location $env.ResourceLocation -DnsResolverOutboundEndpoint  @{id = $outboundEndpoint.Id;}
        $ruleset | Should -BeSuccessfullyCreatedDnsForwardingRuleset

        $inputObject = (Get-AzDnsResolverDnsForwardingRuleset -Name $dnsForwardingRulesetName -ResourceGroupName $env.ResourceGroupName)
        $metadata  = GetRandomHashtable -size 2
        Update-AzDnsResolverDnsForwardingRuleset -InputObject $inputObject -Tag $metadata -IfMatch $ruleset.Etag -SubscriptionId $env.SubscriptionId
        $retrievedDnsForwardingRuleset = Get-AzDnsResolverDnsForwardingRuleset -InputObject $inputObject
        $retrievedDnsForwardingRuleset | Should -BeSameForwardingRulesetAsExpected $inputObject
        $retrievedDnsForwardingRuleset.Metadata.Count | Should -Be 3
    }

    
    It 'Update DNS forwarding ruleset with new metadata via identity and IfMatch not match, expect DNS forwarding ruleset not updated' {
        $dnsResolverName = $env.DnsResolverName26
        $virtualNetworkId = $env.VirtualNetworkId26
        $outboundEndpointName =  $env.OutboundEndpointNamePrefix + (RandomString -allChars $false -len 6)
        $subnetid = $env.SubnetId26
        $privateIp = RandomIp
        $ipConfiguration = New-AzDnsResolverIPConfigurationObject -PrivateIPAddress $privateIp -PrivateIPAllocationMethod Dynamic -SubnetId $subnetid 

        New-AzDnsResolver -Name $dnsResolverName -ResourceGroupName $env.ResourceGroupName -VirtualNetworkId $virtualNetworkId -Location $env.ResourceLocation
        $outboundEndpoint = New-AzDnsResolverOutboundEndpoint -DnsResolverName $dnsResolverName -Name $outboundEndpointName -ResourceGroupName $env.ResourceGroupName -SubscriptionId $env.SubscriptionId -SubnetId $subnetid
        $dnsForwardingRulesetName = "forwardingRulesetForGet" + (RandomString -allChars $false -len 6)
        $ruleset = New-AzDnsResolverDnsForwardingRuleset -Name $dnsForwardingRulesetName -ResourceGroupName $env.ResourceGroupName -Location $env.ResourceLocation -DnsResolverOutboundEndpoint  @{id = $outboundEndpoint.Id;}
        $ruleset | Should -BeSuccessfullyCreatedDnsForwardingRuleset

        $inputObject = (Get-AzDnsResolverDnsForwardingRuleset -Name $dnsForwardingRulesetName -ResourceGroupName $env.ResourceGroupName)
        $metadata  = GetRandomHashtable -size 2
        Update-AzDnsResolverDnsForwardingRuleset -InputObject $inputObject -Tag $metadata -IfMatch $ruleset.Etag -SubscriptionId $env.SubscriptionId
        $retrievedDnsForwardingRuleset = Get-AzDnsResolverDnsForwardingRuleset -InputObject $inputObject
        $retrievedDnsForwardingRuleset | Should -BeSameForwardingRulesetAsExpected $inputObject
        $retrievedDnsForwardingRuleset.Metadata.Count | Should -Be 3
    }
}
