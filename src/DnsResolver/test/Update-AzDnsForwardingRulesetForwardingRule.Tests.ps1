."$PSScriptRoot\testDataGenerator.ps1"
."$PSScriptRoot\virtualNetworkClient.ps1"
."$PSScriptRoot\forwardingRuleAssertions.ps1"
."$PSScriptRoot\Constants.ps1"

Add-AssertionOperator -Name 'BeSuccessfullyCreatedForwardingRule' -Test $Function:BeSuccessfullyCreatedForwardingRule

$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzDnsForwardingRulesetForwardingRule.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Update-AzDnsForwardingRulesetForwardingRule' {
    It 'Update forwarding rule by adding tag, expect forwarding rule updated' {
          # ARRANGE
        $dnsResolverName = "psdnsresolvername57";
        $outboundEndpointName = "psoutboundendpointname57";
        $dnsForwardingRulesetName = "psdnsforwardingrulesetname57";
        $forwardingRuleName = "psdnsforwardingrulename57";
        $domainName = "psdomainName57.com."
        $virtualNetworkName = "psvirtualnetworkname57";
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

        $targetDnsServer = New-AzDnsResolverTargetDnsServerObject -IPAddress 10.0.0.3
        New-AzDnsForwardingRulesetForwardingRule -Name $forwardingRuleName -DnsForwardingRulesetName $dnsForwardingRulesetName -DomainName $domainName -ResourceGroupName $RESOURCE_GROUP_NAME -TargetDnsServer $targetDnsServer
        
        $tag  = GetRandomHashtable -size 5

        # ACT
        $updatedForwardingRule = Update-AzDnsForwardingRulesetForwardingRule -Name $forwardingRuleName -DnsForwardingRulesetName $dnsForwardingRulesetName -ResourceGroupName $RESOURCE_GROUP_NAME -Metadata $tag

        # ASSERT
        $updatedForwardingRule | Should -BeSuccessfullyCreatedForwardingRule
        $updatedForwardingRule.Metadata.count | Should -Be $tag.Count
    }
}