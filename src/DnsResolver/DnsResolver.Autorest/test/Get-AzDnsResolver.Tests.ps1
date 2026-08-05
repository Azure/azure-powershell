# Self-contained test for Get-AzDnsResolver

$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzDnsResolver.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Get-AzDnsResolver' {
    BeforeAll {
        $subscriptionId = '97db216c-169d-4ea9-9d98-114adba0aa20'
        $location = 'westus2'
        $rgName = "ps-dnsresolver-get-49150"

        if ($TestMode -ne 'playback') {
            Select-AzSubscription -SubscriptionId $subscriptionId
            New-AzResourceGroup -Name $rgName -Location $location
            New-AzVirtualNetwork -Name "vnet-get-1" -ResourceGroupName $rgName -Location $location -AddressPrefix "10.0.0.0/16"
            $vnetId = "/subscriptions/$subscriptionId/resourceGroups/$rgName/providers/Microsoft.Network/virtualNetworks/vnet-get-1"
            New-AzDnsResolver -Name "resolver-get-1" -ResourceGroupName $rgName -VirtualNetworkId $vnetId -Location $location
        }
    }

    AfterAll {
        if ($TestMode -ne 'playback') {
            Remove-AzResourceGroup -Name $rgName -ErrorAction SilentlyContinue -AsJob | Out-Null
        }
    }

    It 'Get single DNS resolver by name' {
        $resolver = Get-AzDnsResolver -DnsResolverName "resolver-get-1" -ResourceGroupName $rgName
        $resolver.ProvisioningState | Should -Be "Succeeded"
        $resolver.Name | Should -Be "resolver-get-1"
    }

    It 'List DNS resolvers in a resource group' {
        $resolvers = Get-AzDnsResolver -ResourceGroupName $rgName
        $resolvers.Count | Should -BeGreaterThan 0
    }
}
