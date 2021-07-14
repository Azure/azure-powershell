$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzDnsResolverDnsForwardingRuleset.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Remove-AzDnsResolverDnsForwardingRuleset' {
    It 'Delete an existing DNS forwarding ruleset by name, expect DNS forwarding ruleset deleted' -skip {
        $dnsResolverName = $env.DnsResolverName20
        $virtualNetworkId = $env.VirtualNetworkId20
        New-AzDnsResolver -Name $dnsResolverName -ResourceGroupName $env.ResourceGroupName -VirtualNetworkId $virtualNetworkId -Location $env.ResourceLocation
        $outboundEndpointName = "outbound"
        $virtualNetworkName = ExtractArmResourceName -ResourceId $virtualNetworkId
        $subnetName = "subnetNameForRemove" + (RandomString -allChars $false -len 6)
        $subnetid = (CreateSubnet -SubscriptionId  $env.SubscriptionId -ResourceGroupName $env.ResourceGroupName -VirtualNetworkName $virtualNetworkName -SubnetName $subnetName).id
        $outboundEndpoint = New-AzDnsResolverOutboundEndpoint -DnsResolverName $dnsResolverName -Name $outboundEndpointName -ResourceGroupName $env.ResourceGroupName -SubscriptionId $env.SubscriptionId -SubnetId $subnetid
        $dnsForwardingRulesetName = "forwardingRulesetForGet" + (RandomString -allChars $false -len 6)
        $ruleset = New-AzDnsResolverDnsForwardingRuleset -Name $dnsForwardingRulesetName -ResourceGroupName $env.ResourceGroupName -Location $env.ResourceLocation -DnsResolverOutboundEndpoint  @{id = $outboundEndpoint.Id;}

        Remove-AzDnsResolverDnsForwardingRuleset -Name $dnsForwardingRulesetName -ResourceGroupName $env.ResourceGroupName
        {Get-AzDnsResolverDnsForwardingRuleset -Name $dnsForwardingRulesetName -ResourceGroupName $env.ResourceGroupName} | Should -Throw 'not found'
    }

    It 'Delete an existing DNS forwarding ruleset via identity, expect DNS forwarding ruleset deleted' -skip {
        $dnsResolverName = $env.DnsResolverName21
        $virtualNetworkId = $env.VirtualNetworkId21
        New-AzDnsResolver -Name $dnsResolverName -ResourceGroupName $env.ResourceGroupName -VirtualNetworkId $virtualNetworkId -Location $env.ResourceLocation
        $outboundEndpointName = "outbound"
        $virtualNetworkName = ExtractArmResourceName -ResourceId $virtualNetworkId
        $subnetName = "subnetNameForRemove" + (RandomString -allChars $false -len 6)
        $subnetid = (CreateSubnet -SubscriptionId  $env.SubscriptionId -ResourceGroupName $env.ResourceGroupName -VirtualNetworkName $virtualNetworkName -SubnetName $subnetName).id
        $outboundEndpoint = New-AzDnsResolverOutboundEndpoint -DnsResolverName $dnsResolverName -Name $outboundEndpointName -ResourceGroupName $env.ResourceGroupName -SubscriptionId $env.SubscriptionId -SubnetId $subnetid
        $dnsForwardingRulesetName = "forwardingRulesetForGet" + (RandomString -allChars $false -len 6)
        $ruleset = New-AzDnsResolverDnsForwardingRuleset -Name $dnsForwardingRulesetName -ResourceGroupName $env.ResourceGroupName -Location $env.ResourceLocation -DnsResolverOutboundEndpoint  @{id = $outboundEndpoint.Id;}

        $resolverObject = (Get-AzDnsResolverDnsForwardingRuleset -Name $dnsForwardingRulesetName -ResourceGroupName $env.ResourceGroupName)
        Remove-AzDnsResolverDnsForwardingRuleset -InputObject $resolverObject
        {Get-AzDnsResolverDnsForwardingRuleset -Name $dnsForwardingRulesetName -ResourceGroupName $env.ResourceGroupName} | Should -Throw 'not found'
    }

    It 'Delete an existing DNS forwarding ruleset by name and IfMatch success, expect DNS forwarding ruleset deleted' -skip {
        $dnsResolverName = $env.DnsResolverName22
        $virtualNetworkId = $env.VirtualNetworkId22
        New-AzDnsResolver -Name $dnsResolverName -ResourceGroupName $env.ResourceGroupName -VirtualNetworkId $virtualNetworkId -Location $env.ResourceLocation
        $outboundEndpointName = "outbound"
        $virtualNetworkName = ExtractArmResourceName -ResourceId $virtualNetworkId
        $subnetName = "subnetNameForRemove" + (RandomString -allChars $false -len 6)
        $subnetid = (CreateSubnet -SubscriptionId  $env.SubscriptionId -ResourceGroupName $env.ResourceGroupName -VirtualNetworkName $virtualNetworkName -SubnetName $subnetName).id
        $outboundEndpoint = New-AzDnsResolverOutboundEndpoint -DnsResolverName $dnsResolverName -Name $outboundEndpointName -ResourceGroupName $env.ResourceGroupName -SubscriptionId $env.SubscriptionId -SubnetId $subnetid
        $dnsForwardingRulesetName = "forwardingRulesetForGet" + (RandomString -allChars $false -len 6)
        $ruleset = New-AzDnsResolverDnsForwardingRuleset -Name $dnsForwardingRulesetName -ResourceGroupName $env.ResourceGroupName -Location $env.ResourceLocation -DnsResolverOutboundEndpoint  @{id = $outboundEndpoint.Id;}

        Remove-AzDnsResolverDnsForwardingRuleset -Name $dnsForwardingRulesetName -ResourceGroupName $env.ResourceGroupName -IfMatch $endpoint.Etag
        {Get-AzDnsResolverDnsForwardingRuleset -Name $dnsForwardingRulesetName -ResourceGroupName $env.ResourceGroupName} | Should -Throw 'not found'
    }

    It 'Delete an existing DNS forwarding ruleset by name and IfMatch wildcard success, expect DNS forwarding ruleset deleted' -skip {
        $dnsResolverName = $env.DnsResolverName23
        $virtualNetworkId = $env.VirtualNetworkId23
        New-AzDnsResolver -Name $dnsResolverName -ResourceGroupName $env.ResourceGroupName -VirtualNetworkId $virtualNetworkId -Location $env.ResourceLocation
        $outboundEndpointName = "outbound"
        $virtualNetworkName = ExtractArmResourceName -ResourceId $virtualNetworkId
        $subnetName = "subnetNameForRemove" + (RandomString -allChars $false -len 6)
        $subnetid = (CreateSubnet -SubscriptionId  $env.SubscriptionId -ResourceGroupName $env.ResourceGroupName -VirtualNetworkName $virtualNetworkName -SubnetName $subnetName).id
        $outboundEndpoint = New-AzDnsResolverOutboundEndpoint -DnsResolverName $dnsResolverName -Name $outboundEndpointName -ResourceGroupName $env.ResourceGroupName -SubscriptionId $env.SubscriptionId -SubnetId $subnetid
        $dnsForwardingRulesetName = "forwardingRulesetForGet" + (RandomString -allChars $false -len 6)
        $ruleset = New-AzDnsResolverDnsForwardingRuleset -Name $dnsForwardingRulesetName -ResourceGroupName $env.ResourceGroupName -Location $env.ResourceLocation -DnsResolverOutboundEndpoint  @{id = $outboundEndpoint.Id;}

        Remove-AzDnsResolverDnsForwardingRuleset -Name $dnsForwardingRulesetName -ResourceGroupName $env.ResourceGroupName -IfMatch *
        {Get-AzDnsResolverDnsForwardingRuleset -Name $dnsForwardingRulesetName -ResourceGroupName $env.ResourceGroupName} | Should -Throw 'not found'
    }

    It 'Delete an existing DNS forwarding ruleset by name and IfMatch failure, expect DNS forwarding ruleset not deleted' -skip {
        $dnsResolverName = $env.DnsResolverName24
        $virtualNetworkId = $env.VirtualNetworkId24
        New-AzDnsResolver -Name $dnsResolverName -ResourceGroupName $env.ResourceGroupName -VirtualNetworkId $virtualNetworkId -Location $env.ResourceLocation
        $outboundEndpointName = "outbound"
        $virtualNetworkName = ExtractArmResourceName -ResourceId $virtualNetworkId
        $subnetName = "subnetNameForRemove" + (RandomString -allChars $false -len 6)
        $subnetid = (CreateSubnet -SubscriptionId  $env.SubscriptionId -ResourceGroupName $env.ResourceGroupName -VirtualNetworkName $virtualNetworkName -SubnetName $subnetName).id
        $outboundEndpoint = New-AzDnsResolverOutboundEndpoint -DnsResolverName $dnsResolverName -Name $outboundEndpointName -ResourceGroupName $env.ResourceGroupName -SubscriptionId $env.SubscriptionId -SubnetId $subnetid
        $dnsForwardingRulesetName = "forwardingRulesetForGet" + (RandomString -allChars $false -len 6)
        $ruleset = New-AzDnsResolverDnsForwardingRuleset -Name $dnsForwardingRulesetName -ResourceGroupName $env.ResourceGroupName -Location $env.ResourceLocation -DnsResolverOutboundEndpoint  @{id = $outboundEndpoint.Id;}

        {Remove-AzDnsResolverDnsForwardingRuleset -Name $dnsForwardingRulesetName -ResourceGroupName $env.ResourceGroupName -IfMatch (RandomString -allChars $false -len 6)} | Should -Throw "is invalid"
        $forwardingRuleset = Get-AzDnsResolverDnsForwardingRuleset -Name $dnsForwardingRulesetName -ResourceGroupName $env.ResourceGroupName
        $forwardingRuleset | Should -BeSuccessfullyCreated
    }
}
