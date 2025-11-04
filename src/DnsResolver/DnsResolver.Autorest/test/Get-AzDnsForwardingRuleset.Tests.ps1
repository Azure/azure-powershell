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
        $defaultSubnet = New-AzVirtualNetworkSubnetConfig -Name "default" -AddressPrefix "10.0.0.0/24"
        $vnet = New-AzVirtualNetwork -Name $virtualNetworkName -ResourceGroupName $RESOURCE_GROUP_NAME -Location $location -AddressPrefix "10.0.0.0/16" -Subnet $defaultSubnet -Force
    }

    New-AzDnsResolver -Name $DnsResolverName -ResourceGroupName $RESOURCE_GROUP_NAME -VirtualNetworkId $virtualNetworkId -Location $LOCATION

    $outboundEndpoint = New-AzDnsResolverOutboundEndpoint -Name $OutboundEndpointName -DnsResolverName $DnsResolverName -ResourceGroupName $RESOURCE_GROUP_NAME -SubnetId $subnetId -Location $LOCATION

    New-AzDnsForwardingRuleset -Name $DnsForwardingRulesetName -ResourceGroupName $RESOURCE_GROUP_NAME -Location $LOCATION -DnsResolverOutboundEndpoint  @{id = $outboundEndpoint.id;}
}

Describe 'Get-AzDnsForwardingRuleset' {
    It 'Get single DNS Forwarding Ruleset by name, expect DNS Forwarding Ruleset by name retrieved' {
        # ARRANGE
        $dnsResolverName = "psdnsresolvername282";
        $outboundEndpointName =  "psoutboundendpointname282";
        $dnsForwardingRulesetName = "psdnsforwardingrulesetname282"
        $virtualNetworkName = "psvirtualnetworkname282";
        $virtualNetworkId = "/subscriptions/$SUBSCRIPTION_ID/resourceGroups/$RESOURCE_GROUP_NAME/providers/Microsoft.Network/virtualNetworks/$virtualNetworkName"
        $subnetId = $virtualNetworkId + "/subnets/" + $SUBNET_NAME;

        CreateDnsForwardingRuleset -DnsForwardingRulesetName $dnsForwardingRulesetName -OutboundEndpointName $outboundEndpointName -DnsResolverName $dnsResolverName -VirtualNetworkName $virtualNetworkName 

        # ACT
        $dnsForwardingRuleset =  Get-AzDnsForwardingRuleset -Name $dnsForwardingRulesetName -ResourceGroupName $RESOURCE_GROUP_NAME

        # ASSERT
        $dnsForwardingRuleset | Should -BeSuccessfullyCreatedDnsForwardingRuleset

        # UNDO
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

    It 'List all DNS forwarding ruleset under the resouce group, expect all DNS forwarding rulesets retrieved' {
        # ARRANGE
        $dnsResolverName = "psdnsresolvername292";
        $outboundEndpointName =  "psoutboundendpointname292";
        $dnsForwardingRulesetName = "psdnsforwardingrulesetname292"
        $virtualNetworkName = "psvirtualnetworkname292";
        $virtualNetworkId = "/subscriptions/$SUBSCRIPTION_ID/resourceGroups/$RESOURCE_GROUP_NAME/providers/Microsoft.Network/virtualNetworks/$virtualNetworkName"
        $subnetId = $virtualNetworkId + "/subnets/" + $SUBNET_NAME;
        
        CreateDnsForwardingRuleset -DnsForwardingRulesetName $dnsForwardingRulesetName -OutboundEndpointName $outboundEndpointName -DnsResolverName $dnsResolverName -VirtualNetworkName $virtualNetworkName 

        # ACT
        $dnsForwardingRuleset =  Get-AzDnsForwardingRuleset -Name $dnsForwardingRulesetName -ResourceGroupName $RESOURCE_GROUP_NAME

        # ASSERT
        $dnsForwardingRuleset.Count | Should -Be "1"

        # UNDO
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
