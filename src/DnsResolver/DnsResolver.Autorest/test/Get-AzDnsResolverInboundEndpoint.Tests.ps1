$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzDnsResolverInboundEndpoint.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) { $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File; $currentPath = Split-Path -Path $currentPath -Parent }
. ($mockingPath | Select-Object -First 1).FullName
Describe 'Get-AzDnsResolverInboundEndpoint' {
    BeforeAll {
        $subscriptionId = '97db216c-169d-4ea9-9d98-114adba0aa20'; $location = 'westus2'
        $rgName = "ps-ie-get-$(Get-Random -Max 99999)"
        if ($TestMode -ne 'playback') {
            Select-AzSubscription -SubscriptionId $subscriptionId
            New-AzResourceGroup -Name $rgName -Location $location
            $vnet = New-AzVirtualNetwork -Name "vnet-ie-g" -ResourceGroupName $rgName -Location $location -AddressPrefix "10.0.0.0/16"
            Add-AzVirtualNetworkSubnetConfig -Name "snet-ie-g" -VirtualNetwork $vnet -AddressPrefix "10.0.1.0/24" -Delegation @((New-AzDelegation -Name "dnsResolvers" -ServiceName "Microsoft.Network/dnsResolvers")) | Out-Null
            $vnet | Set-AzVirtualNetwork | Out-Null
            $vnetId = "/subscriptions/$subscriptionId/resourceGroups/$rgName/providers/Microsoft.Network/virtualNetworks/vnet-ie-g"
            New-AzDnsResolver -Name "resolver-ie-g" -ResourceGroupName $rgName -VirtualNetworkId $vnetId -Location $location
            $subnetId = "/subscriptions/$subscriptionId/resourceGroups/$rgName/providers/Microsoft.Network/virtualNetworks/vnet-ie-g/subnets/snet-ie-g"
            $ipConfig = New-AzDnsResolverIPConfigurationObject -SubnetId $subnetId -PrivateIPAllocationMethod "Dynamic"
            New-AzDnsResolverInboundEndpoint -DnsResolverName "resolver-ie-g" -Name "ie-get-1" -ResourceGroupName $rgName -Location $location -IPConfiguration @($ipConfig)
        }
    }
    AfterAll {
        if ($TestMode -ne 'playback') { Remove-AzResourceGroup -Name $rgName -ErrorAction SilentlyContinue -AsJob | Out-Null }
    }
    It 'Get inbound endpoint by name' {
        $ep = Get-AzDnsResolverInboundEndpoint -DnsResolverName "resolver-ie-g" -Name "ie-get-1" -ResourceGroupName $rgName
        $ep.ProvisioningState | Should -Be "Succeeded"
    }
    It 'List inbound endpoints' {
        $eps = Get-AzDnsResolverInboundEndpoint -DnsResolverName "resolver-ie-g" -ResourceGroupName $rgName
        $eps.Count | Should -BeGreaterThan 0
    }
}

