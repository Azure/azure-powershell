."$PSScriptRoot\testDataGenerator.ps1"
."$PSScriptRoot\virtualNetworkClient.ps1"
."$PSScriptRoot\virtualNetworkLinkAssertions.ps1"
."$PSScriptRoot\Constants.ps1"

Add-AssertionOperator -Name 'BeSuccessfullyCreatedVirtualNetworkLink' -Test $Function:BeSuccessfullyCreatedVirtualNetworkLink

$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzDnsForwardingRulesetVirtualNetworkLink.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

function CreateVirtualNetworkLink([String]$VirtualNetworkLinkName, [String]$DnsForwardingRulesetName, [String]$OutboundEndpointName, [String]$DnsResolverName, [String]$VirtualNetworkName)
{
    if ($TestMode -eq "Record")
    {
        $defaultSubnet = New-AzVirtualNetworkSubnetConfig -Name "default" -AddressPrefix "10.0.0.0/24"
        $vnet = New-AzVirtualNetwork -Name $virtualNetworkName -ResourceGroupName $RESOURCE_GROUP_NAME -Location $location -AddressPrefix "10.0.0.0/16" -Subnet $defaultSubnet -Force
    }

    New-AzDnsResolver -Name $DnsResolverName -ResourceGroupName $RESOURCE_GROUP_NAME -VirtualNetworkId $virtualNetworkId -Location $LOCATION

    $outboundEndpoint = New-AzDnsResolverOutboundEndpoint -Name $OutboundEndpointName -DnsResolverName $DnsResolverName -ResourceGroupName $RESOURCE_GROUP_NAME -SubnetId $subnetId -Location $LOCATION

    New-AzDnsForwardingRuleset -Name $DnsForwardingRulesetName -ResourceGroupName $RESOURCE_GROUP_NAME -Location $LOCATION -DnsResolverOutboundEndpoint  @{id = $outboundEndpoint.id;}
    
    New-AzDnsForwardingRulesetVirtualNetworkLink -Name $virtualNetworkLinkName -DnsForwardingRulesetName $dnsForwardingRulesetName -ResourceGroupName $RESOURCE_GROUP_NAME -VirtualNetworkId $virtualNetworkId
}

Describe 'Get-AzDnsForwardingRulesetVirtualNetworkLink' {
    It 'Get single virtual network link by name, expect virtual network link retrieved' {
        # ARRANGE
        $dnsResolverName = "psdnsresolvername45";
        $outboundEndpointName = "psoutboundendpointname45";
        $dnsForwardingRulesetName = "psdnsforwardingrulesetname45";
        $virtualNetworkLinkName = "psdnsvirtualnetworklinkname45";
        $virtualNetworkName = "psvirtualnetworkname45";
        $virtualNetworkId = "/subscriptions/$SUBSCRIPTION_ID/resourceGroups/$RESOURCE_GROUP_NAME/providers/Microsoft.Network/virtualNetworks/$virtualNetworkName"
        $subnetId = $virtualNetworkId + "/subnets/" + $SUBNET_NAME;
        
        CreateVirtualNetworkLink -VirtualNetworkLinkName $virtualNetworkLinkName -DnsForwardingRulesetName $dnsForwardingRulesetName -OutboundEndpointName $outboundEndpointName -DnsResolverName $dnsResolverName -VirtualNetworkName $virtualNetworkName 

        # ACT
        $virtualNetworkLink =  Get-AzDnsForwardingRulesetVirtualNetworkLink -Name $virtualNetworkLinkName -DnsForwardingRulesetName $dnsForwardingRulesetName -ResourceGroupName $RESOURCE_GROUP_NAME

        # ASSERT
        $virtualNetworkLink | Should -BeSuccessfullyCreatedVirtualNetworkLink

        # UNDO
        Start-Sleep -Seconds 5
        Remove-AzDnsForwardingRulesetVirtualNetworkLink -DnsForwardingRulesetName $dnsForwardingRulesetName -Name $virtualNetworkLinkName -ResourceGroupName $RESOURCE_GROUP_NAME
        Start-Sleep -Seconds 5
        Remove-AzDnsForwardingRuleset -Name $dnsForwardingRulesetName -ResourceGroupName $RESOURCE_GROUP_NAME
        Start-Sleep -Seconds 5
        Remove-AzDnsResolverOutboundEndpoint -DnsResolverName $dnsResolverName -Name $outboundEndpointName -ResourceGroupName $RESOURCE_GROUP_NAME
        Start-Sleep -Seconds 5
        Remove-AzDnsResolver -Name $dnsResolverName -ResourceGroupName $RESOURCE_GROUP_NAME
        Start-Sleep -Seconds 5
        Remove-AzVirtualNetwork -Name $virtualNetworkName -ResourceGroupName $RESOURCE_GROUP_NAME -Force
    }

    It 'List all virtual network links under the DNS forwarding ruleset, expect all virtual network links retrieved' {
        # ARRANGE
        $dnsResolverName = "psdnsresolvername46";
        $outboundEndpointName = "psoutboundendpointname46";
        $dnsForwardingRulesetName = "psdnsforwardingrulesetname46";
        $virtualNetworkLinkName = "psdnsvirtualnetworklinkname46";
        $virtualNetworkName = "psvirtualnetworkname46";
        $virtualNetworkId = "/subscriptions/$SUBSCRIPTION_ID/resourceGroups/$RESOURCE_GROUP_NAME/providers/Microsoft.Network/virtualNetworks/$virtualNetworkName"
        $subnetId = $virtualNetworkId + "/subnets/" + $SUBNET_NAME;
        
        CreateVirtualNetworkLink -VirtualNetworkLinkName $virtualNetworkLinkName -DnsForwardingRulesetName $dnsForwardingRulesetName -OutboundEndpointName $outboundEndpointName -DnsResolverName $dnsResolverName -VirtualNetworkName $virtualNetworkName 

        # ACT
        $virtualNetworkLink =  Get-AzDnsForwardingRulesetVirtualNetworkLink -DnsForwardingRulesetName $dnsForwardingRulesetName -ResourceGroupName $RESOURCE_GROUP_NAME

        # ASSERT
        $virtualNetworkLink.Count | Should -Be "1"

        # UNDO
        Start-Sleep -Seconds 5
        Remove-AzDnsForwardingRulesetVirtualNetworkLink -DnsForwardingRulesetName $dnsForwardingRulesetName -Name $virtualNetworkLinkName -ResourceGroupName $RESOURCE_GROUP_NAME
        Start-Sleep -Seconds 5
        Remove-AzDnsForwardingRuleset -Name $dnsForwardingRulesetName -ResourceGroupName $RESOURCE_GROUP_NAME
        Start-Sleep -Seconds 5
        Remove-AzDnsResolverOutboundEndpoint -DnsResolverName $dnsResolverName -Name $outboundEndpointName -ResourceGroupName $RESOURCE_GROUP_NAME
        Start-Sleep -Seconds 5
        Remove-AzDnsResolver -Name $dnsResolverName -ResourceGroupName $RESOURCE_GROUP_NAME
        Start-Sleep -Seconds 5
        Remove-AzVirtualNetwork -Name $virtualNetworkName -ResourceGroupName $RESOURCE_GROUP_NAME -Force
    }
}