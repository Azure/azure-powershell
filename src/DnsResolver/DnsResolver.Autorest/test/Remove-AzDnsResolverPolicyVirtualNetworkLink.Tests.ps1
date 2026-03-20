$TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzDnsResolverPolicyVirtualNetworkLink.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) { $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File; $currentPath = Split-Path -Path $currentPath -Parent }
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Remove-AzDnsResolverPolicyVirtualNetworkLink' {
    BeforeAll {
        $subscriptionId = '97db216c-169d-4ea9-9d98-114adba0aa20'; $location = 'westus2'
        $rgName = "ps-pvnl-rm-$(Get-Random -Max 99999)"
        if ($TestMode -ne 'playback') {
            Select-AzSubscription -SubscriptionId $subscriptionId
            New-AzResourceGroup -Name $rgName -Location $location
            New-AzDnsResolverPolicy -Name "policy-pvnl-r" -ResourceGroupName $rgName -Location $location
            New-AzVirtualNetwork -Name "vnet-pvnl-r" -ResourceGroupName $rgName -Location $location -AddressPrefix "10.0.0.0/16"
            $vnetId = "/subscriptions/$subscriptionId/resourceGroups/$rgName/providers/Microsoft.Network/virtualNetworks/vnet-pvnl-r"
            New-AzDnsResolverPolicyVirtualNetworkLink -Name "pvnl-rm-1" -DnsResolverPolicyName "policy-pvnl-r" -ResourceGroupName $rgName -Location $location -VirtualNetworkId $vnetId
        }
    }
    AfterAll {
        if ($TestMode -ne 'playback') { Remove-AzResourceGroup -Name $rgName -ErrorAction SilentlyContinue -AsJob | Out-Null }
    }
    It 'Delete a policy VNet link' {
        Remove-AzDnsResolverPolicyVirtualNetworkLink -Name "pvnl-rm-1" -DnsResolverPolicyName "policy-pvnl-r" -ResourceGroupName $rgName
        { Get-AzDnsResolverPolicyVirtualNetworkLink -Name "pvnl-rm-1" -DnsResolverPolicyName "policy-pvnl-r" -ResourceGroupName $rgName } | Should -Throw
    }
}
