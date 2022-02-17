."$PSScriptRoot\forwardingRuleAssertions.ps1"

Add-AssertionOperator -Name 'BeSuccessfullyCreatedForwardingRule' -Test $Function:BeSuccessfullyCreatedForwardingRule

$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'New-AzDnsForwardingRulesetForwardingRule.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'New-AzDnsForwardingRulesetForwardingRule' {
     It 'Create new forwarding rule' {
        # ARRANGE
        $dnsResolverName = "psdnsresolvername39";
        $outboundEndpointName = "psoutboundendpointname39";
        $dnsForwardingRulesetName = "psdnsforwardingrulesetname39";
        $forwardingRuleName = "psdnsforwardingrulename39";
        $domainName = "psdomainName39.com."
        $virtualNetworkName = "psvirtualnetworkname39";

        if ($TestMode -eq "Record")
        {
            $virtualNetwork = CreateVirtualNetwork -SubscriptionId $SUBSCRIPTION_ID -ResourceGroupName $RESOURCE_GROUP_NAME -VirtualNetworkName $virtualNetworkName;
            $subnet = CreateSubnet -SubscriptionId $SUBSCRIPTION_ID -ResourceGroupName $RESOURCE_GROUP_NAME -VirtualNetworkName $virtualNetworkName;
        }

        New-AzDnsResolver -Name $dnsResolverName -ResourceGroupName $RESOURCE_GROUP_NAME -VirtualNetworkId $virtualNetwork.Id -Location $LOCATION
        $outboundEndpoint = New-AzDnsResolverOutboundEndpoint -DnsResolverName $dnsResolverName -Name $outboundEndpointName -ResourceGroupName $RESOURCE_GROUP_NAME -SubnetId $subnet.Id -Location $LOCATION
        $dnsForwardingRuleset = New-AzDnsForwardingRuleset -Name $dnsForwardingRulesetName -ResourceGroupName $RESOURCE_GROUP_NAME -Location $LOCATION -DnsResolverOutboundEndpoint  @{id = $outboundEndpoint.Id;}
        $targetDnsServer = New-AzDnsResolverTargetDnsServerObject -IPAddress 10.0.0.3

        # ACT
        $forwardingRule = New-AzDnsForwardingRulesetForwardingRule -Name $forwardingRuleName -DnsForwardingRulesetName $dnsForwardingRulesetName -DomainName $domainName -ResourceGroupName $RESOURCE_GROUP_NAME -TargetDnsServer $targetDnsServer

        # ASSERT
        $forwardingRule | Should -BeSuccessfullyCreatedForwardingRule
    }
}
