# Self-contained test for Update-AzDnsResolver

$TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzDnsResolver.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Update-AzDnsResolver' {
    BeforeAll {
        $subscriptionId = '97db216c-169d-4ea9-9d98-114adba0aa20'
        $location = 'westus2'
        $rgName = "ps-dnsresolver-upd-$(Get-Random -Max 99999)"

        if ($TestMode -ne 'playback') {
            Select-AzSubscription -SubscriptionId $subscriptionId
            New-AzResourceGroup -Name $rgName -Location $location
            New-AzVirtualNetwork -Name "vnet-upd-1" -ResourceGroupName $rgName -Location $location -AddressPrefix "10.0.0.0/16"
            $vnetId = "/subscriptions/$subscriptionId/resourceGroups/$rgName/providers/Microsoft.Network/virtualNetworks/vnet-upd-1"
            New-AzDnsResolver -Name "resolver-upd-1" -ResourceGroupName $rgName -VirtualNetworkId $vnetId -Location $location
        }
    }

    AfterAll {
        if ($TestMode -ne 'playback') {
            Remove-AzResourceGroup -Name $rgName -ErrorAction SilentlyContinue -AsJob | Out-Null
        }
    }

    It 'Update DNS resolver tags' {
        $tag = @{ "updated" = "true"; "env" = "test" }
        $resolver = Update-AzDnsResolver -Name "resolver-upd-1" -ResourceGroupName $rgName -Tag $tag
        $resolver.ProvisioningState | Should -Be "Succeeded"
        $resolver.Tag.Count | Should -Be 2
    }
}
