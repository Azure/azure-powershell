."$PSScriptRoot\testDataGenerator.ps1"
."$PSScriptRoot\virtualNetworkClient.ps1"
."$PSScriptRoot\dnsForwardingRulesetAssertions.ps1"
."$PSScriptRoot\Constants.ps1"

$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzDnsForwardingRuleset.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Remove-AzDnsForwardingRuleset' {
    It 'Delete a DNS forwarding ruleset, expect DNS forwarding ruleset deleted' {
        # ARRANGE
        $dnsResolverName = "psdnsresolvername30";
        $outboundEndpointName =  "psoutboundendpointname30";
        $dnsForwardingRulesetName = "psdnsforwardingrulesetname30"
        $virtualNetworkName = "psvirtualnetworkname30";
        
        if ($TestMode -eq "Record")
        {
            $virtualNetwork = CreateVirtualNetwork -SubscriptionId $SUBSCRIPTION_ID -ResourceGroupName $RESOURCE_GROUP_NAME -VirtualNetworkName $virtualNetworkName;
            $subnet = CreateSubnet -SubscriptionId $SUBSCRIPTION_ID -ResourceGroupName $RESOURCE_GROUP_NAME -VirtualNetworkName $virtualNetworkName;
        }

        New-AzDnsResolver -Name $dnsResolverName -ResourceGroupName $RESOURCE_GROUP_NAME -VirtualNetworkId $virtualNetwork.Id -Location $LOCATION
        $ipConfiguration = New-AzDnsResolverIPConfigurationObject -PrivateIPAllocationMethod Dynamic -SubnetId $subnet.id 

        $outboundEndpoint = New-AzDnsResolverOutboundEndpoint -Name $outboundEndpointName -DnsResolverName $dnsResolverName -ResourceGroupName $RESOURCE_GROUP_NAME -SubscriptionId $SUBSCRIPTION_ID -SubnetId $subnet.id -Location $LOCATION

        $dnsForwardingRuleset = New-AzDnsForwardingRuleset -Name $dnsForwardingRulesetName -ResourceGroupName $RESOURCE_GROUP_NAME -Location $LOCATION -DnsResolverOutboundEndpoint  @{id = $outboundEndpoint.id;}

        # ACT
        Remove-AzDnsForwardingRuleset -Name $dnsForwardingRulesetName -ResourceGroupName $RESOURCE_GROUP_NAME

        # ASSERT
        {Get-AzDnsForwardingRuleset -Name $dnsForwardingRulesetName -ResourceGroupName $RESOURCE_GROUP_NAME } | Should -Throw "not found"
    }
}
