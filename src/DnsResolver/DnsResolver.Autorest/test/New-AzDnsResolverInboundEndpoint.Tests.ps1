$TestRecordingFile = Join-Path $PSScriptRoot 'New-AzDnsResolverInboundEndpoint.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) { $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File; $currentPath = Split-Path -Path $currentPath -Parent }
. ($mockingPath | Select-Object -First 1).FullName
Describe 'New-AzDnsResolverInboundEndpoint' {
    BeforeAll {
        $subscriptionId = '97db216c-169d-4ea9-9d98-114adba0aa20'; $location = 'westus2'
        $rgName = "ps-ie-new-25704"
        if ($TestMode -ne 'playback') {
            Select-AzSubscription -SubscriptionId $subscriptionId
            New-AzResourceGroup -Name $rgName -Location $location
            $vnet = New-AzVirtualNetwork -Name "vnet-ie-1" -ResourceGroupName $rgName -Location $location -AddressPrefix "10.0.0.0/16"
            $subnetConfig = Add-AzVirtualNetworkSubnetConfig -Name "snet-ie-1" -VirtualNetwork $vnet -AddressPrefix "10.0.1.0/24" -Delegation @((New-AzDelegation -Name "dnsResolvers" -ServiceName "Microsoft.Network/dnsResolvers"))
            $vnet | Set-AzVirtualNetwork | Out-Null
            $vnetId = "/subscriptions/$subscriptionId/resourceGroups/$rgName/providers/Microsoft.Network/virtualNetworks/vnet-ie-1"
            New-AzDnsResolver -Name "resolver-ie-1" -ResourceGroupName $rgName -VirtualNetworkId $vnetId -Location $location
        }
    }
    AfterAll {
        if ($TestMode -ne 'playback') { Remove-AzResourceGroup -Name $rgName -ErrorAction SilentlyContinue -AsJob | Out-Null }
    }
    It 'Create an inbound endpoint' {
        $subnetId = "/subscriptions/$subscriptionId/resourceGroups/$rgName/providers/Microsoft.Network/virtualNetworks/vnet-ie-1/subnets/snet-ie-1"
        $ipConfig = New-AzDnsResolverIPConfigurationObject -SubnetId $subnetId -PrivateIPAllocationMethod "Dynamic"
        $endpoint = New-AzDnsResolverInboundEndpoint -DnsResolverName "resolver-ie-1" -Name "ie-new-1" -ResourceGroupName $rgName -Location $location -IPConfiguration @($ipConfig)
        $endpoint.ProvisioningState | Should -Be "Succeeded"
        $endpoint.Name | Should -Be "ie-new-1"
    }
}

