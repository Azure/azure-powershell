$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzDnsResolverOutboundEndpoint.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) { $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File; $currentPath = Split-Path -Path $currentPath -Parent }
. ($mockingPath | Select-Object -First 1).FullName
Describe 'Get-AzDnsResolverOutboundEndpoint' {
    BeforeAll {
        $subscriptionId = '97db216c-169d-4ea9-9d98-114adba0aa20'; $location = 'westus2'
        $rgName = "ps-oe-get-15572"
        if ($TestMode -ne 'playback') {
            Select-AzSubscription -SubscriptionId $subscriptionId
            New-AzResourceGroup -Name $rgName -Location $location
            $vnet = New-AzVirtualNetwork -Name "vnet-oe-g" -ResourceGroupName $rgName -Location $location -AddressPrefix "10.0.0.0/16"
            Add-AzVirtualNetworkSubnetConfig -Name "snet-oe-g" -VirtualNetwork $vnet -AddressPrefix "10.0.2.0/24" -Delegation @((New-AzDelegation -Name "dnsResolvers" -ServiceName "Microsoft.Network/dnsResolvers")) | Out-Null
            $vnet | Set-AzVirtualNetwork | Out-Null
            $vnetId = "/subscriptions/$subscriptionId/resourceGroups/$rgName/providers/Microsoft.Network/virtualNetworks/vnet-oe-g"
            New-AzDnsResolver -Name "resolver-oe-g" -ResourceGroupName $rgName -VirtualNetworkId $vnetId -Location $location
            $subnetId = "/subscriptions/$subscriptionId/resourceGroups/$rgName/providers/Microsoft.Network/virtualNetworks/vnet-oe-g/subnets/snet-oe-g"
            New-AzDnsResolverOutboundEndpoint -DnsResolverName "resolver-oe-g" -Name "oe-get-1" -ResourceGroupName $rgName -Location $location -SubnetId $subnetId
        }
    }
    AfterAll { if ($TestMode -ne 'playback') { Remove-AzResourceGroup -Name $rgName -ErrorAction SilentlyContinue -AsJob | Out-Null } }
    It 'Get outbound endpoint by name' {
        $ep = Get-AzDnsResolverOutboundEndpoint -DnsResolverName "resolver-oe-g" -Name "oe-get-1" -ResourceGroupName $rgName
        $ep.ProvisioningState | Should -Be "Succeeded"
    }
    It 'List outbound endpoints' {
        $eps = Get-AzDnsResolverOutboundEndpoint -DnsResolverName "resolver-oe-g" -ResourceGroupName $rgName
        $eps.Count | Should -BeGreaterThan 0
    }
}

