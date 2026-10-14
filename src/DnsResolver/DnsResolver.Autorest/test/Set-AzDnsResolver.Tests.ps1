$TestRecordingFile = Join-Path $PSScriptRoot 'Set-AzDnsResolver.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) { $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File; $currentPath = Split-Path -Path $currentPath -Parent }
. ($mockingPath | Select-Object -First 1).FullName
Describe 'Set-AzDnsResolver' {
    BeforeAll {
        $subscriptionId = '97db216c-169d-4ea9-9d98-114adba0aa20'; $location = 'westus2'
        $rgName = "ps-resolver-set-90896"
        if ($TestMode -ne 'playback') {
            Select-AzSubscription -SubscriptionId $subscriptionId
            New-AzResourceGroup -Name $rgName -Location $location
            New-AzVirtualNetwork -Name "vnet-set-1" -ResourceGroupName $rgName -Location $location -AddressPrefix "10.0.0.0/16"
            $vnetId = "/subscriptions/$subscriptionId/resourceGroups/$rgName/providers/Microsoft.Network/virtualNetworks/vnet-set-1"
            New-AzDnsResolver -Name "resolver-set-1" -ResourceGroupName $rgName -VirtualNetworkId $vnetId -Location $location
        }
    }
    AfterAll {
        if ($TestMode -ne 'playback') { Remove-AzResourceGroup -Name $rgName -ErrorAction SilentlyContinue -AsJob | Out-Null }
    }
    It 'Set resolver tags via Update' {
        $tag = @{ "set" = "true" }
        $resolver = Update-AzDnsResolver -Name "resolver-set-1" -ResourceGroupName $rgName -Tag $tag
        $resolver.ProvisioningState | Should -Be "Succeeded"
    }
}

