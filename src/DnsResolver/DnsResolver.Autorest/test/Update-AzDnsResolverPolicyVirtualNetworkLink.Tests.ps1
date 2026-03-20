$TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzDnsResolverPolicyVirtualNetworkLink.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) { $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File; $currentPath = Split-Path -Path $currentPath -Parent }
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Update-AzDnsResolverPolicyVirtualNetworkLink' {
    BeforeAll {
        $subscriptionId = '97db216c-169d-4ea9-9d98-114adba0aa20'; $location = 'westus2'
        $rgName = "ps-pvnl-upd-$(Get-Random -Max 99999)"
        if ($TestMode -ne 'playback') {
            Select-AzSubscription -SubscriptionId $subscriptionId
            New-AzResourceGroup -Name $rgName -Location $location
            New-AzDnsResolverPolicy -Name "policy-pvnl-u" -ResourceGroupName $rgName -Location $location
            New-AzVirtualNetwork -Name "vnet-pvnl-u" -ResourceGroupName $rgName -Location $location -AddressPrefix "10.0.0.0/16"
            $vnetId = "/subscriptions/$subscriptionId/resourceGroups/$rgName/providers/Microsoft.Network/virtualNetworks/vnet-pvnl-u"
            New-AzDnsResolverPolicyVirtualNetworkLink -Name "pvnl-upd-1" -DnsResolverPolicyName "policy-pvnl-u" -ResourceGroupName $rgName -Location $location -VirtualNetworkId $vnetId
        }
    }
    AfterAll {
        if ($TestMode -ne 'playback') { Remove-AzResourceGroup -Name $rgName -ErrorAction SilentlyContinue -AsJob | Out-Null }
    }
    It 'Update policy VNet link tags' {
        $tag = @{ "updated" = "true" }
        $link = Update-AzDnsResolverPolicyVirtualNetworkLink -Name "pvnl-upd-1" -DnsResolverPolicyName "policy-pvnl-u" -ResourceGroupName $rgName -Tag $tag
        $link.ProvisioningState | Should -Be "Succeeded"
        $link.Tag.Count | Should -Be 1
    }
}
