$TestRecordingFile = Join-Path $PSScriptRoot 'New-AzDnsResolverOutboundEndpoint.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) { $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File; $currentPath = Split-Path -Path $currentPath -Parent }
. ($mockingPath | Select-Object -First 1).FullName
Describe 'New-AzDnsResolverOutboundEndpoint' {
    BeforeAll {
        $subscriptionId = '97db216c-169d-4ea9-9d98-114adba0aa20'; $location = 'westus2'
        $rgName = "ps-oe-new-54398"
        if ($TestMode -ne 'playback') {
            Select-AzSubscription -SubscriptionId $subscriptionId
            New-AzResourceGroup -Name $rgName -Location $location
            $vnet = New-AzVirtualNetwork -Name "vnet-oe-n" -ResourceGroupName $rgName -Location $location -AddressPrefix "10.0.0.0/16"
            Add-AzVirtualNetworkSubnetConfig -Name "snet-oe-n" -VirtualNetwork $vnet -AddressPrefix "10.0.2.0/24" -Delegation @((New-AzDelegation -Name "dnsResolvers" -ServiceName "Microsoft.Network/dnsResolvers")) | Out-Null
            $vnet | Set-AzVirtualNetwork | Out-Null
            $vnetId = "/subscriptions/$subscriptionId/resourceGroups/$rgName/providers/Microsoft.Network/virtualNetworks/vnet-oe-n"
            New-AzDnsResolver -Name "resolver-oe-n" -ResourceGroupName $rgName -VirtualNetworkId $vnetId -Location $location
        }
    }
    AfterAll { if ($TestMode -ne 'playback') { Remove-AzResourceGroup -Name $rgName -ErrorAction SilentlyContinue -AsJob | Out-Null } }
    It 'Create an outbound endpoint' {
        $subnetId = "/subscriptions/$subscriptionId/resourceGroups/$rgName/providers/Microsoft.Network/virtualNetworks/vnet-oe-n/subnets/snet-oe-n"
        $ep = New-AzDnsResolverOutboundEndpoint -DnsResolverName "resolver-oe-n" -Name "oe-new-1" -ResourceGroupName $rgName -Location $location -SubnetId $subnetId
        $ep.ProvisioningState | Should -Be "Succeeded"
    }
}

