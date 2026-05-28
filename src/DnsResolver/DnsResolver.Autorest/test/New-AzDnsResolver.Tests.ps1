# Self-contained test for New-AzDnsResolver
# Each test creates and cleans up its own resources

$TestRecordingFile = Join-Path $PSScriptRoot 'New-AzDnsResolver.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'New-AzDnsResolver' {
    BeforeAll {
        $subscriptionId = '97db216c-169d-4ea9-9d98-114adba0aa20'
        $location = 'westus2'
        $rgName = "ps-dnsresolver-new-24348"

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

    It 'Create DNS resolver with a new virtual network' {
        # ARRANGE
        $resolverName = "resolver-new-1"
        $vnetName = "vnet-new-1"

        if ($TestMode -ne 'playback') {
            New-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgName -Location $location -AddressPrefix "10.0.0.0/16"
        }
        $virtualNetworkId = "/subscriptions/$subscriptionId/resourceGroups/$rgName/providers/Microsoft.Network/virtualNetworks/$vnetName"

        # ACT
        $resolver = New-AzDnsResolver -Name $resolverName -ResourceGroupName $rgName -VirtualNetworkId $virtualNetworkId -Location $location

        # ASSERT
        $resolver.ProvisioningState | Should -Be "Succeeded"
        $resolver.Name | Should -Be $resolverName
        $resolver.VirtualNetworkId | Should -Be $virtualNetworkId
    }

    It 'Create DNS resolver with tags' {
        # ARRANGE
        $resolverName = "resolver-new-2"
        $vnetName = "vnet-new-2"
        $tag = @{ "env" = "test"; "component" = "dnsresolver" }

        if ($TestMode -ne 'playback') {
            New-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgName -Location $location -AddressPrefix "10.1.0.0/16"
        }
        $virtualNetworkId = "/subscriptions/$subscriptionId/resourceGroups/$rgName/providers/Microsoft.Network/virtualNetworks/$vnetName"

        # ACT
        $resolver = New-AzDnsResolver -Name $resolverName -ResourceGroupName $rgName -VirtualNetworkId $virtualNetworkId -Location $location -Tag $tag

        # ASSERT
        $resolver.ProvisioningState | Should -Be "Succeeded"
        $resolver.VirtualNetworkId | Should -Be $virtualNetworkId
        $resolver.Tag.Count | Should -Be $tag.Count
    }

    It 'Create DNS resolver with a malformed virtual network ARM ID should throw' {
        # ARRANGE
        $resolverName = "resolver-new-3"
        $malformedId = "/subscriptions/$subscriptionId/INVALID/providers/Microsoft.Network/virtualNetworks/fakevnet"

        # ACT, ASSERT
        { New-AzDnsResolver -Name $resolverName -ResourceGroupName $rgName -VirtualNetworkId $malformedId -Location $location } | Should -Throw
    }

    It 'Create DNS resolver with a non-existent virtual network should throw' {
        # ARRANGE
        $resolverName = "resolver-new-4"
        $nonExistentVnetId = "/subscriptions/$subscriptionId/resourceGroups/$rgName/providers/Microsoft.Network/virtualNetworks/vnet-does-not-exist"

        # ACT, ASSERT
        { New-AzDnsResolver -Name $resolverName -ResourceGroupName $rgName -VirtualNetworkId $nonExistentVnetId -Location $location } | Should -Throw
    }

    It 'Update DNS resolver with new tags via create (upsert)' {
        # ARRANGE
        $resolverName = "resolver-new-5"
        $vnetName = "vnet-new-5"

        if ($TestMode -ne 'playback') {
            New-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgName -Location $location -AddressPrefix "10.2.0.0/16"
        }
        $virtualNetworkId = "/subscriptions/$subscriptionId/resourceGroups/$rgName/providers/Microsoft.Network/virtualNetworks/$vnetName"

        # Create initial resolver
        New-AzDnsResolver -Name $resolverName -ResourceGroupName $rgName -VirtualNetworkId $virtualNetworkId -Location $location

        # ACT - upsert with tags
        $tag = @{ "updated" = "true" }
        $resolver = New-AzDnsResolver -Name $resolverName -ResourceGroupName $rgName -VirtualNetworkId $virtualNetworkId -Location $location -Tag $tag

        # ASSERT
        $resolver.ProvisioningState | Should -Be "Succeeded"
        $resolver.Tag.Count | Should -Be $tag.Count
    }
}
