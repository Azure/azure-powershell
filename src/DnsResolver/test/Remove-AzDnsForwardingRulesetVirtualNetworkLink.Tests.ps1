$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzDnsForwardingRulesetVirtualNetworkLink.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Remove-AzDnsForwardingRulesetVirtualNetworkLink' {
     It 'Delete a virtual network link, expect virtual network link deleted' {
        # ARRANGE
        $dnsResolverName = "psdnsresolvername44";
        $outboundEndpointName = "psoutboundendpointname44";
        $dnsForwardingRulesetName = "psdnsforwardingrulesetname44";
        $virtualNetworkLinkName = "psvirtualnetworklinkname44";
        $virtualNetworkName = "psvirtualnetworkname44";
        $virtualNetworkId = "/subscriptions/$SUBSCRIPTION_ID/resourceGroups/$RESOURCE_GROUP_NAME/providers/Microsoft.Network/virtualNetworks/$virtualNetworkName"
        $subnetId = $virtualNetworkId + "/subnets" + $SUBNET_NAME;

        if ($TestMode -eq "Record")
        {
            $virtualNetwork = CreateVirtualNetwork -SubscriptionId $SUBSCRIPTION_ID -ResourceGroupName $RESOURCE_GROUP_NAME -VirtualNetworkName $virtualNetworkName;
            $subnet = CreateSubnet -SubscriptionId $SUBSCRIPTION_ID -ResourceGroupName $RESOURCE_GROUP_NAME -VirtualNetworkName $virtualNetworkName;
        }

        New-AzDnsResolver -Name $dnsResolverName -ResourceGroupName $RESOURCE_GROUP_NAME -VirtualNetworkId $virtualNetworkId -Location $LOCATION
        $outboundEndpoint = New-AzDnsResolverOutboundEndpoint -DnsResolverName $dnsResolverName -Name $outboundEndpointName -ResourceGroupName $RESOURCE_GROUP_NAME -SubnetId $subnetId -Location $LOCATION
        $dnsForwardingRuleset = New-AzDnsForwardingRuleset -Name $dnsForwardingRulesetName -ResourceGroupName $RESOURCE_GROUP_NAME -Location $LOCATION -DnsResolverOutboundEndpoint  @{id = $outboundEndpoint.Id;}
        New-AzDnsForwardingRulesetVirtualNetworkLink -DnsForwardingRulesetName $dnsForwardingRulesetName -Name $virtualNetworkLinkName -ResourceGroupName $RESOURCE_GROUP_NAME -VirtualNetworkId $virtualNetworkId

        # ACT
        Remove-AzDnsForwardingRulesetVirtualNetworkLink -DnsForwardingRulesetName $dnsForwardingRulesetName -Name $virtualNetworkLinkName -ResourceGroupName $RESOURCE_GROUP_NAME

        # ASSERT
        {Get-AzDnsForwardingRulesetVirtualNetworkLink -Name $virtualNetworkLinkName -DnsForwardingRulesetName $dnsForwardingRulesetName -ResourceGroupName $RESOURCE_GROUP_NAME } | Should -Throw
    }
}
