# Self-contained test for Remove-AzDnsResolver

$TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzDnsResolver.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Remove-AzDnsResolver' {
    BeforeAll {
        $subscriptionId = '97db216c-169d-4ea9-9d98-114adba0aa20'
        $location = 'westus2'
        $rgName = "ps-dnsresolver-rm-68978"

        if ($TestMode -ne 'playback') {
            Select-AzSubscription -SubscriptionId $subscriptionId
            New-AzResourceGroup -Name $rgName -Location $location
        }
    }

    AfterAll {
        if ($TestMode -ne 'playback') {
            Remove-AzResourceGroup -Name $rgName -ErrorAction SilentlyContinue -AsJob | Out-Null
        }
    }

    It 'Delete a DNS resolver' {
        $vnetName = "vnet-rm-1"
        if ($TestMode -ne 'playback') {
            New-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgName -Location $location -AddressPrefix "10.0.0.0/16"
        }
        $vnetId = "/subscriptions/$subscriptionId/resourceGroups/$rgName/providers/Microsoft.Network/virtualNetworks/$vnetName"

        New-AzDnsResolver -Name "resolver-rm-1" -ResourceGroupName $rgName -VirtualNetworkId $vnetId -Location $location
        Remove-AzDnsResolver -Name "resolver-rm-1" -ResourceGroupName $rgName

        { Get-AzDnsResolver -DnsResolverName "resolver-rm-1" -ResourceGroupName $rgName } | Should -Throw
    }
}
