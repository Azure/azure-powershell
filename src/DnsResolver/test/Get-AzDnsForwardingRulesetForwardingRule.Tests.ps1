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
$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzDnsForwardingRulesetForwardingRule.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

function CreateForwardingRule([String]$ForwardingRuleName, [String]$DomainName, [String]$DnsForwardingRulesetName, [String]$OutboundEndpointName, [String]$DnsResolverName, [String]$VirtualNetworkName)
{
    if ($TestMode -eq "Record")
    {
        $virtualNetwork = CreateVirtualNetwork -SubscriptionId $SUBSCRIPTION_ID -ResourceGroupName $RESOURCE_GROUP_NAME -VirtualNetworkName $VirtualNetworkName;
        $subnet = CreateSubnet -SubscriptionId $SUBSCRIPTION_ID -ResourceGroupName $RESOURCE_GROUP_NAME -VirtualNetworkName $VirtualNetworkName;
    }

    New-AzDnsResolver -Name $DnsResolverName -ResourceGroupName $RESOURCE_GROUP_NAME -VirtualNetworkId $virtualNetworkId -Location $LOCATION

    $outboundEndpoint = New-AzDnsResolverOutboundEndpoint -Name $OutboundEndpointName -DnsResolverName $DnsResolverName -ResourceGroupName $RESOURCE_GROUP_NAME -SubnetId $subnetId -Location $LOCATION

    New-AzDnsForwardingRuleset -Name $DnsForwardingRulesetName -ResourceGroupName $RESOURCE_GROUP_NAME -Location $LOCATION -DnsResolverOutboundEndpoint  @{id = $outboundEndpoint.id;}
    
    $targetDnsServer = New-AzDnsResolverTargetDnsServerObject -IPAddress 10.0.0.3
    New-AzDnsForwardingRulesetForwardingRule -Name $ForwardingRuleName -DnsForwardingRulesetName $DnsForwardingRulesetName -DomainName $DomainName -ResourceGroupName $RESOURCE_GROUP_NAME -TargetDnsServer $targetDnsServer
}

Describe 'Get-AzDnsForwardingRulesetForwardingRule' {
    It 'Get single forwarding rule by name, expect forwarding rule retrieved' {
        # ARRANGE
        $dnsResolverName = "psdnsresolvername40";
        $outboundEndpointName = "psoutboundendpointname40";
        $dnsForwardingRulesetName = "psdnsforwardingrulesetname40";
        $forwardingRuleName = "psdnsforwardingrulename40";
        $domainName = "psdomainName40.com."
        $virtualNetworkName = "psvirtualnetworkname40";
        $virtualNetworkId = "/subscriptions/$SUBSCRIPTION_ID/resourceGroups/$RESOURCE_GROUP_NAME/providers/Microsoft.Network/virtualNetworks/$virtualNetworkName"
        $subnetId = $virtualNetworkId + "/subnets" + $SUBNET_NAME;
        
        CreateForwardingRule -ForwardingRuleName $forwardingRuleName -DomainName $domainName -DnsForwardingRulesetName $dnsForwardingRulesetName -OutboundEndpointName $outboundEndpointName -DnsResolverName $dnsResolverName -VirtualNetworkName $virtualNetworkName 

        # ACT
        $forwardingRule =  Get-AzDnsForwardingRulesetForwardingRule -Name $forwardingRuleName -DnsForwardingRulesetName $dnsForwardingRulesetName -ResourceGroupName $RESOURCE_GROUP_NAME

        # ASSERT
        $forwardingRule | Should -BeSuccessfullyCreatedForwardingRule
    }

    It 'List all forwarding rules under the DNS forwarding ruleset, expect all forwarding rules retrieved' {
        # ARRANGE
        $dnsResolverName = "psdnsresolvername41";
        $outboundEndpointName = "psoutboundendpointname41";
        $dnsForwardingRulesetName = "psdnsforwardingrulesetname41";
        $forwardingRuleName = "psdnsforwardingrulename41";
        $domainName = "psdomainName41.com."
        $virtualNetworkName = "psvirtualnetworkname41";
        $virtualNetworkId = "/subscriptions/$SUBSCRIPTION_ID/resourceGroups/$RESOURCE_GROUP_NAME/providers/Microsoft.Network/virtualNetworks/$virtualNetworkName"
        $subnetId = $virtualNetworkId + "/subnets" + $SUBNET_NAME;
        
        CreateForwardingRule -ForwardingRuleName $forwardingRuleName -DomainName $domainName -DnsForwardingRulesetName $dnsForwardingRulesetName -OutboundEndpointName $outboundEndpointName -DnsResolverName $dnsResolverName -VirtualNetworkName $virtualNetworkName 

        # ACT
        $forwardingRule =  Get-AzDnsForwardingRulesetForwardingRule -DnsForwardingRulesetName $dnsForwardingRulesetName -ResourceGroupName $RESOURCE_GROUP_NAME

        # ASSERT
        $forwardingRule.Count | Should -Be "1"
    }
}