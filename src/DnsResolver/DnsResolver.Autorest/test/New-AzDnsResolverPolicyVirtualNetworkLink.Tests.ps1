$TestRecordingFile = Join-Path $PSScriptRoot 'New-AzDnsResolverPolicyVirtualNetworkLink.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) { $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File; $currentPath = Split-Path -Path $currentPath -Parent }
. ($mockingPath | Select-Object -First 1).FullName

Describe 'New-AzDnsResolverPolicyVirtualNetworkLink' {
    BeforeAll {
        $subscriptionId = '97db216c-169d-4ea9-9d98-114adba0aa20'; $location = 'westus2'
        $rgName = "ps-pvnl-new-$(Get-Random -Max 99999)"
        if ($TestMode -ne 'playback') {
            Select-AzSubscription -SubscriptionId $subscriptionId
            New-AzResourceGroup -Name $rgName -Location $location
            New-AzDnsResolverPolicy -Name "policy-pvnl-1" -ResourceGroupName $rgName -Location $location
            New-AzVirtualNetwork -Name "vnet-pvnl-1" -ResourceGroupName $rgName -Location $location -AddressPrefix "10.0.0.0/16"
        }
    }
    AfterAll {
        if ($TestMode -ne 'playback') { Remove-AzResourceGroup -Name $rgName -ErrorAction SilentlyContinue -AsJob | Out-Null }
    }
    It 'Create a policy virtual network link' {
        $vnetId = "/subscriptions/$subscriptionId/resourceGroups/$rgName/providers/Microsoft.Network/virtualNetworks/vnet-pvnl-1"
        $link = New-AzDnsResolverPolicyVirtualNetworkLink -Name "pvnl-new-1" -DnsResolverPolicyName "policy-pvnl-1" -ResourceGroupName $rgName -Location $location -VirtualNetworkId $vnetId
        $link.ProvisioningState | Should -Be "Succeeded"
    }
}
