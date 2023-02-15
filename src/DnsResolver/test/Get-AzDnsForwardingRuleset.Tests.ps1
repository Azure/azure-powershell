."$PSScriptRoot\testDataGenerator.ps1"
."$PSScriptRoot\virtualNetworkClient.ps1"
."$PSScriptRoot\dnsForwardingRulesetAssertions.ps1"
."$PSScriptRoot\Constants.ps1"

Add-AssertionOperator -Name 'BeSuccessfullyCreatedDnsForwardingRuleset' -Test $Function:BeSuccessfullyCreatedDnsForwardingRuleset

$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzDnsForwardingRuleset.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

function CreateDnsForwardingRuleset([String]$DnsForwardingRulesetName, [String]$OutboundEndpointName, [String]$DnsResolverName, [String]$VirtualNetworkName)
{
    if ($TestMode -eq "Record")
    {
        $virtualNetwork = CreateVirtualNetwork -SubscriptionId $SUBSCRIPTION_ID -ResourceGroupName $RESOURCE_GROUP_NAME -VirtualNetworkName $VirtualNetworkName;
        $subnet = CreateSubnet -SubscriptionId $SUBSCRIPTION_ID -ResourceGroupName $RESOURCE_GROUP_NAME -VirtualNetworkName $VirtualNetworkName;
    }

    New-AzDnsResolver -Name $DnsResolverName -ResourceGroupName $RESOURCE_GROUP_NAME -VirtualNetworkId $virtualNetworkId -Location $LOCATION

    $outboundEndpoint = New-AzDnsResolverOutboundEndpoint -Name $OutboundEndpointName -DnsResolverName $DnsResolverName -ResourceGroupName $RESOURCE_GROUP_NAME -SubnetId $subnetId -Location $LOCATION

    New-AzDnsForwardingRuleset -Name $DnsForwardingRulesetName -ResourceGroupName $RESOURCE_GROUP_NAME -Location $LOCATION -DnsResolverOutboundEndpoint  @{id = $outboundEndpoint.id;}
}

Describe 'Get-AzDnsForwardingRuleset' {
    It 'Get single DNS Forwarding Ruleset by name, expect DNS Forwarding Ruleset by name retrieved' {
        # ARRANGE
        $dnsResolverName = "psdnsresolvername28";
        $outboundEndpointName =  "psoutboundendpointname28";
        $dnsForwardingRulesetName = "psdnsforwardingrulesetname28"
        $virtualNetworkName = "psvirtualnetworkname28";
        $virtualNetworkId = "/subscriptions/$SUBSCRIPTION_ID/resourceGroups/$RESOURCE_GROUP_NAME/providers/Microsoft.Network/virtualNetworks/$virtualNetworkName"
        $subnetId = $virtualNetworkId + "/subnets" + $SUBNET_NAME;

        CreateDnsForwardingRuleset -DnsForwardingRulesetName $dnsForwardingRulesetName -OutboundEndpointName $outboundEndpointName -DnsResolverName $dnsResolverName -VirtualNetworkName $virtualNetworkName 

        # ACT
        $dnsForwardingRuleset =  Get-AzDnsForwardingRuleset -Name $dnsForwardingRulesetName -ResourceGroupName $RESOURCE_GROUP_NAME

        # ASSERT
        $dnsForwardingRuleset | Should -BeSuccessfullyCreatedDnsForwardingRuleset
    }

    It 'List all DNS forwarding ruleset under the resouce group, expect all DNS forwarding rulesets retrieved' {
        # ARRANGE
        $dnsResolverName = "psdnsresolvername29";
        $outboundEndpointName =  "psoutboundendpointname29";
        $dnsForwardingRulesetName = "psdnsforwardingrulesetname29"
        $virtualNetworkName = "psvirtualnetworkname29";
        $virtualNetworkId = "/subscriptions/$SUBSCRIPTION_ID/resourceGroups/$RESOURCE_GROUP_NAME/providers/Microsoft.Network/virtualNetworks/$virtualNetworkName"
        $subnetId = $virtualNetworkId + "/subnets" + $SUBNET_NAME;
        
        CreateDnsForwardingRuleset -DnsForwardingRulesetName $dnsForwardingRulesetName -OutboundEndpointName $outboundEndpointName -DnsResolverName $dnsResolverName -VirtualNetworkName $virtualNetworkName 

        # ACT
        $dnsForwardingRuleset =  Get-AzDnsForwardingRuleset -Name $dnsForwardingRulesetName -ResourceGroupName $RESOURCE_GROUP_NAME

        # ASSERT
        $dnsForwardingRuleset.Count | Should -Be "1"
    }
}
