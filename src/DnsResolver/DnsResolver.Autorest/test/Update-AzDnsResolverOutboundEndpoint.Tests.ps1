$TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzDnsResolverOutboundEndpoint.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) { $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File; $currentPath = Split-Path -Path $currentPath -Parent }
. ($mockingPath | Select-Object -First 1).FullName
Describe 'Update-AzDnsResolverOutboundEndpoint' {
    BeforeAll {
        $subscriptionId = '97db216c-169d-4ea9-9d98-114adba0aa20'; $location = 'westus2'
        $rgName = "ps-oe-upd-$(Get-Random -Max 99999)"
        if ($TestMode -ne 'playback') {
            Select-AzSubscription -SubscriptionId $subscriptionId
            New-AzResourceGroup -Name $rgName -Location $location
            $vnet = New-AzVirtualNetwork -Name "vnet-oe-u" -ResourceGroupName $rgName -Location $location -AddressPrefix "10.0.0.0/16"
            Add-AzVirtualNetworkSubnetConfig -Name "snet-oe-u" -VirtualNetwork $vnet -AddressPrefix "10.0.2.0/24" -Delegation @((New-AzDelegation -Name "dnsResolvers" -ServiceName "Microsoft.Network/dnsResolvers")) | Out-Null
            $vnet | Set-AzVirtualNetwork | Out-Null
            $vnetId = "/subscriptions/$subscriptionId/resourceGroups/$rgName/providers/Microsoft.Network/virtualNetworks/vnet-oe-u"
            New-AzDnsResolver -Name "resolver-oe-u" -ResourceGroupName $rgName -VirtualNetworkId $vnetId -Location $location
            $subnetId = "/subscriptions/$subscriptionId/resourceGroups/$rgName/providers/Microsoft.Network/virtualNetworks/vnet-oe-u/subnets/snet-oe-u"
            New-AzDnsResolverOutboundEndpoint -DnsResolverName "resolver-oe-u" -Name "oe-upd-1" -ResourceGroupName $rgName -Location $location -SubnetId $subnetId
        }
    }
    AfterAll { if ($TestMode -ne 'playback') { Remove-AzResourceGroup -Name $rgName -ErrorAction SilentlyContinue -AsJob | Out-Null } }
    It 'Update outbound endpoint tags' {
        $tag = @{ "updated" = "true" }
        $ep = Update-AzDnsResolverOutboundEndpoint -DnsResolverName "resolver-oe-u" -Name "oe-upd-1" -ResourceGroupName $rgName -Tag $tag
        $ep.ProvisioningState | Should -Be "Succeeded"
        $ep.Tag.Count | Should -Be 1
    }
}

