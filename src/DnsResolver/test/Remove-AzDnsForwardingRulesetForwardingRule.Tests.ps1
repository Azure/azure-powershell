."$PSScriptRoot\testDataGenerator.ps1"
."$PSScriptRoot\virtualNetworkClient.ps1"
."$PSScriptRoot\Constants.ps1"

$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzDnsForwardingRulesetForwardingRule.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Remove-AzDnsForwardingRulesetForwardingRule' {
    It 'Delete a forwarding rule, expect forwarding rule deleted' {
        # ARRANGE
        $dnsResolverName = "psdnsresolvername42";
        $outboundEndpointName =  "psoutboundendpointname42";
        $dnsForwardingRulesetName = "psdnsforwardingrulesetname42"
        $forwardingRuleName = "psdnsforwardingrulename42";
        $domainName = "psdomainName42.com."
        $virtualNetworkName = "psvirtualnetworkname42";
        $virtualNetworkId = "/subscriptions/$SUBSCRIPTION_ID/resourceGroups/$RESOURCE_GROUP_NAME/providers/Microsoft.Network/virtualNetworks/$virtualNetworkName"
        $subnetId = $virtualNetworkId + "/subnets" + $SUBNET_NAME;
        
        if ($TestMode -eq "Record")
        {
            $virtualNetwork = CreateVirtualNetwork -SubscriptionId $SUBSCRIPTION_ID -ResourceGroupName $RESOURCE_GROUP_NAME -VirtualNetworkName $virtualNetworkName;
            $subnet = CreateSubnet -SubscriptionId $SUBSCRIPTION_ID -ResourceGroupName $RESOURCE_GROUP_NAME -VirtualNetworkName $virtualNetworkName;
        }

        New-AzDnsResolver -Name $dnsResolverName -ResourceGroupName $RESOURCE_GROUP_NAME -VirtualNetworkId $virtualNetworkId -Location $LOCATION
        
        $outboundEndpoint = New-AzDnsResolverOutboundEndpoint -Name $outboundEndpointName -DnsResolverName $dnsResolverName -ResourceGroupName $RESOURCE_GROUP_NAME -SubscriptionId $SUBSCRIPTION_ID -SubnetId $subnetId -Location $LOCATION

        New-AzDnsForwardingRuleset -Name $dnsForwardingRulesetName -ResourceGroupName $RESOURCE_GROUP_NAME -Location $LOCATION -DnsResolverOutboundEndpoint  @{id = $outboundEndpoint.id;}

        $targetDnsServer = New-AzDnsResolverTargetDnsServerObject -IPAddress 10.0.0.3
        New-AzDnsForwardingRulesetForwardingRule -Name $forwardingRuleName -DnsForwardingRulesetName $dnsForwardingRulesetName -DomainName $domainName -ResourceGroupName $RESOURCE_GROUP_NAME -TargetDnsServer $targetDnsServer
        
        # ACT
        Remove-AzDnsForwardingRulesetForwardingRule -Name $forwardingRuleName -DnsForwardingRulesetName $dnsForwardingRulesetName -ResourceGroupName $RESOURCE_GROUP_NAME

        # ASSERT
        {Get-AzDnsForwardingRulesetForwardingRule -Name $forwardingRuleName -DnsForwardingRulesetName $dnsForwardingRulesetName -ResourceGroupName $RESOURCE_GROUP_NAME } | Should -Throw
    }
}