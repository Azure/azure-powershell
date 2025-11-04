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
        $virtualNetworkId = "/subscriptions/$SUBSCRIPTION_ID/resourceGroups/$RESOURCE_GROUP_NAME/providers/Microsoft.Network/virtualNetworks/$virtualNetworkName"
        $subnetId = $virtualNetworkId + "/subnets/" + $SUBNET_NAME;

        if ($TestMode -eq "Record")
        {
            $defaultSubnet = New-AzVirtualNetworkSubnetConfig -Name "default" -AddressPrefix "10.0.0.0/24"
            $vnet = New-AzVirtualNetwork -Name $virtualNetworkName -ResourceGroupName $RESOURCE_GROUP_NAME -Location $location -AddressPrefix "10.0.0.0/16" -Subnet $defaultSubnet -Force
        }

        New-AzDnsResolver -Name $dnsResolverName -ResourceGroupName $RESOURCE_GROUP_NAME -VirtualNetworkId $virtualNetworkId -Location $LOCATION
        $outboundEndpoint = New-AzDnsResolverOutboundEndpoint -DnsResolverName $dnsResolverName -Name $outboundEndpointName -ResourceGroupName $RESOURCE_GROUP_NAME -SubnetId $subnetId -Location $LOCATION
        $dnsForwardingRuleset = New-AzDnsForwardingRuleset -Name $dnsForwardingRulesetName -ResourceGroupName $RESOURCE_GROUP_NAME -Location $LOCATION -DnsResolverOutboundEndpoint  @{id = $outboundEndpoint.Id;}
        $targetDnsServer = New-AzDnsResolverTargetDnsServerObject -IPAddress 10.0.0.3

        # ACT
        $forwardingRule = New-AzDnsForwardingRulesetForwardingRule -Name $forwardingRuleName -DnsForwardingRulesetName $dnsForwardingRulesetName -DomainName $domainName -ResourceGroupName $RESOURCE_GROUP_NAME -TargetDnsServer $targetDnsServer

        # ASSERT
        $forwardingRule | Should -BeSuccessfullyCreatedForwardingRule

        # UNDO
        Start-Sleep -Seconds 5
        Remove-AzDnsForwardingRulesetForwardingRule -Name $forwardingRuleName -DnsForwardingRulesetName $dnsForwardingRulesetName -ResourceGroupName $RESOURCE_GROUP_NAME
        Start-Sleep -Seconds 5
        Remove-AzDnsForwardingRuleset -Name $dnsForwardingRulesetName -ResourceGroupName $RESOURCE_GROUP_NAME
        Start-Sleep -Seconds 5
        Remove-AzDnsResolverOutboundEndpoint -DnsResolverName $dnsResolverName -Name $outboundEndpointName -ResourceGroupName $RESOURCE_GROUP_NAME
        Start-Sleep -Seconds 5
        Remove-AzDnsResolver -Name $dnsResolverName -ResourceGroupName $RESOURCE_GROUP_NAME
        Start-Sleep -Seconds 5
        if ($TestMode -eq "Record")
        {
            Remove-AzVirtualNetwork -Name $virtualNetworkName -ResourceGroupName $RESOURCE_GROUP_NAME -Force
        }
    }
}
