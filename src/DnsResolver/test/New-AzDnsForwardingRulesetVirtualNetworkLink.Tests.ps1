."$PSScriptRoot\virtualNetworkLinkAssertions.ps1"

Add-AssertionOperator -Name 'BeSuccessfullyCreatedVirtualNetworkLink' -Test $Function:BeSuccessfullyCreatedVirtualNetworkLink

$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'New-AzDnsForwardingRulesetVirtualNetworkLink.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'New-AzDnsForwardingRulesetVirtualNetworkLink' {
     It 'Create new virtual network link' {
        # ARRANGE
        $dnsResolverName = "psdnsresolvername43";
        $outboundEndpointName = "psoutboundendpointname43";
        $dnsForwardingRulesetName = "psdnsforwardingrulesetname43";
        $virtualNetworkLinkName = "psvirtualnetworklinkname43";
        $virtualNetworkName = "psvirtualnetworkname43";
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

        # ACT
        $virtualNetworkLink = New-AzDnsForwardingRulesetVirtualNetworkLink -DnsForwardingRulesetName $dnsForwardingRulesetName -Name $virtualNetworkLinkName -ResourceGroupName $RESOURCE_GROUP_NAME -VirtualNetworkId $virtualNetworkId

        # ASSERT
        $virtualNetworkLink | Should -BeSuccessfullyCreatedVirtualNetworkLink
    }
}
