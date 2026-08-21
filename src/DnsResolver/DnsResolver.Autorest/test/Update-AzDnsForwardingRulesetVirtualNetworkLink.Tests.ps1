$TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzDnsForwardingRulesetVirtualNetworkLink.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) { $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File; $currentPath = Split-Path -Path $currentPath -Parent }
. ($mockingPath | Select-Object -First 1).FullName
Describe 'Update-AzDnsForwardingRulesetVirtualNetworkLink' {
    BeforeAll {
        $subscriptionId = '97db216c-169d-4ea9-9d98-114adba0aa20'; $location = 'westus2'
        $rgName = "ps-frs-vnl-update-99508"
        if ($TestMode -ne 'playback') {
            Select-AzSubscription -SubscriptionId $subscriptionId
            New-AzResourceGroup -Name $rgName -Location $location
            $vnet = New-AzVirtualNetwork -Name "vnet-frs" -ResourceGroupName $rgName -Location $location -AddressPrefix "10.0.0.0/16"
            Add-AzVirtualNetworkSubnetConfig -Name "snet-frs" -VirtualNetwork $vnet -AddressPrefix "10.0.2.0/24" -Delegation @((New-AzDelegation -Name "dnsResolvers" -ServiceName "Microsoft.Network/dnsResolvers")) | Out-Null
            $vnet | Set-AzVirtualNetwork | Out-Null
            $vnetId = "/subscriptions/$subscriptionId/resourceGroups/$rgName/providers/Microsoft.Network/virtualNetworks/vnet-frs"
            New-AzDnsResolver -Name "resolver-frs" -ResourceGroupName $rgName -VirtualNetworkId $vnetId -Location $location
            $subnetId = "/subscriptions/$subscriptionId/resourceGroups/$rgName/providers/Microsoft.Network/virtualNetworks/vnet-frs/subnets/snet-frs"
            New-AzDnsResolverOutboundEndpoint -DnsResolverName "resolver-frs" -Name "oe-frs" -ResourceGroupName $rgName -Location $location -SubnetId $subnetId
            $oeId = "/subscriptions/$subscriptionId/resourceGroups/$rgName/providers/Microsoft.Network/dnsResolvers/resolver-frs/outboundEndpoints/oe-frs"
            New-AzDnsForwardingRuleset -Name "frs-vnl" -ResourceGroupName $rgName -Location $location -DnsResolverOutboundEndpoint @(@{id = $oeId})
            New-AzDnsForwardingRulesetVirtualNetworkLink -DnsForwardingRulesetName "frs-vnl" -Name "vnl-update-1" -ResourceGroupName $rgName -VirtualNetworkId $vnetId
        }
    }
    AfterAll { if ($TestMode -ne 'playback') { Remove-AzResourceGroup -Name $rgName -ErrorAction SilentlyContinue -AsJob | Out-Null } }
    It 'Update VNet link metadata' {
        $link = Update-AzDnsForwardingRulesetVirtualNetworkLink -DnsForwardingRulesetName "frs-vnl" -Name "vnl-update-1" -ResourceGroupName $rgName -Metadata @{"key"="value"}
        $link.ProvisioningState | Should -Be "Succeeded"
    }
}

