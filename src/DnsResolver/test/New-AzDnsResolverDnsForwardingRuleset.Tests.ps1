."$PSScriptRoot\testDataGenerator.ps1"
."$PSScriptRoot\virtualNetworkClient.ps1"
."$PSScriptRoot\dnsResolverAssertions.ps1"

Add-AssertionOperator -Name 'BeSuccessfullyCreated' -Test $Function:BeSuccessfullyCreated

$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'New-AzDnsResolverDnsForwardingRuleset.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'New-AzDnsResolverDnsForwardingRuleset ' {
    It 'Create DNS forwarding ruleset with new outbound endpoint' {
        $dnsResolverName = $env.DnsResolverName37
        $virtualNetworkId = $env.VirtualNetworkId37
        $outboundEndpointName =  $env.OutboundEndpointNamePrefix + (RandomString -allChars $false -len 6)
        $subnetid = $env.SubnetId37
        $privateIp = RandomIp
        $ipConfiguration = New-AzDnsResolverIPConfigurationObject -PrivateIPAddress $privateIp -PrivateIPAllocationMethod Dynamic -SubnetId $subnetid 

        New-AzDnsResolver -Name $dnsResolverName -ResourceGroupName $env.ResourceGroupName -VirtualNetworkId $virtualNetworkId -Location $env.ResourceLocation
        $outboundEndpoint = New-AzDnsResolverOutboundEndpoint -DnsResolverName $dnsResolverName -Name $outboundEndpointName -ResourceGroupName $env.ResourceGroupName -SubscriptionId $env.SubscriptionId -SubnetId $subnetid
        $dnsForwardingRulesetName = "forwardingRulesetForGet" + (RandomString -allChars $false -len 6)
        $ruleset = New-AzDnsResolverDnsForwardingRuleset -Name $dnsForwardingRulesetName -ResourceGroupName $env.ResourceGroupName -Location $env.ResourceLocation -DnsResolverOutboundEndpoint  @{id = $outboundEndpoint.Id;}

        $ruleset | Should -BeSuccessfullyCreated
    }

    It 'Create DNS forwarding ruleset with a malformed outbound endpoint id' {
        $dnsForwardingRulesetName = "forwardingRulesetForGet" + (RandomString -allChars $false -len 6)
        $malformedOutboundId = "/subscriptions/0e5a46b1-de0b-4ec3-a5d7-dda908b4e076/powershelldnsresolvertestrglocaltest/providers/Microsoft.Network/virtualNetworks/psvirtualnetworkname1dkijv7"
        {$ruleset = New-AzDnsResolverDnsForwardingRuleset -Name $dnsForwardingRulesetName -ResourceGroupName $env.ResourceGroupName -Location $env.ResourceLocation -DnsResolverOutboundEndpoint  @{id = $malformedOutboundId;} }| Should -Throw 'BadRequest'
    }

    It 'Create DNS forwarding ruleset with tags, expect DNS forwarding ruleset created'  {
        $tag = GetRandomHashtable -size 2
        $dnsResolverName = $env.DnsResolverName38
        $virtualNetworkId = $env.VirtualNetworkId38
        $outboundEndpointName =  $env.OutboundEndpointNamePrefix + (RandomString -allChars $false -len 6)
        $subnetid = $env.SubnetId38
        $privateIp = RandomIp
        $ipConfiguration = New-AzDnsResolverIPConfigurationObject -PrivateIPAddress $privateIp -PrivateIPAllocationMethod Dynamic -SubnetId $subnetid 

        New-AzDnsResolver -Name $dnsResolverName -ResourceGroupName $env.ResourceGroupName -VirtualNetworkId $virtualNetworkId -Location $env.ResourceLocation
        $outboundEndpoint = New-AzDnsResolverOutboundEndpoint -DnsResolverName $dnsResolverName -Name $outboundEndpointName -ResourceGroupName $env.ResourceGroupName -SubscriptionId $env.SubscriptionId -SubnetId $subnetid
        $dnsForwardingRulesetName = "forwardingRulesetForGet" + (RandomString -allChars $false -len 6)
        $ruleset = New-AzDnsResolverDnsForwardingRuleset -Name $dnsForwardingRulesetName -ResourceGroupName $env.ResourceGroupName -Location $env.ResourceLocation -DnsResolverOutboundEndpoint  @{id = $outboundEndpoint.Id;} -Tag $tag

        $ruleset | Should -BeSuccessfullyCreated
        $ruleset.Tag.Count | Should -Be $tag.Count
    }

    It 'Create DNS forwarding ruleset with a non-existant outbound endpoint' {
        $dnsForwardingRulesetName = "forwardingRulesetForGet" + (RandomString -allChars $false -len 6)
        $nonExistantOutboundEndpoint = "/subscriptions/ea40042d-63d8-4d02-9261-fb31450e6c67/resourceGroups/powershelldnsresolvertestrgbfi2yc/providers/Microsoft.Network/dnsResolvers/psdnsresolvername61w7mof8/outboundEndpoints/outboundEndpointmeForGetwihgmz"
        {New-AzDnsResolverDnsForwardingRuleset -Name $dnsForwardingRulesetName -ResourceGroupName $env.ResourceGroupName -Location $env.ResourceLocation -DnsResolverOutboundEndpoint  @{id = $nonExistantOutboundEndpoint;} }| Should -Throw 'Outbound endpoint was not found for DNS forwarding ruleset provisioning.'
    }
}