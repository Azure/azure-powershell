$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzDnsResolverPolicyVirtualNetworkLink.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) { $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File; $currentPath = Split-Path -Path $currentPath -Parent }
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Get-AzDnsResolverPolicyVirtualNetworkLink' {
    BeforeAll {
        $subscriptionId = '97db216c-169d-4ea9-9d98-114adba0aa20'; $location = 'westus2'
        $rgName = "ps-pvnl-get-$(Get-Random -Max 99999)"
        if ($TestMode -ne 'playback') {
            Select-AzSubscription -SubscriptionId $subscriptionId
            New-AzResourceGroup -Name $rgName -Location $location
            New-AzDnsResolverPolicy -Name "policy-pvnl-g" -ResourceGroupName $rgName -Location $location
            New-AzVirtualNetwork -Name "vnet-pvnl-g" -ResourceGroupName $rgName -Location $location -AddressPrefix "10.0.0.0/16"
            $vnetId = "/subscriptions/$subscriptionId/resourceGroups/$rgName/providers/Microsoft.Network/virtualNetworks/vnet-pvnl-g"
            New-AzDnsResolverPolicyVirtualNetworkLink -Name "pvnl-get-1" -DnsResolverPolicyName "policy-pvnl-g" -ResourceGroupName $rgName -Location $location -VirtualNetworkId $vnetId
        }
    }
    AfterAll {
        if ($TestMode -ne 'playback') { Remove-AzResourceGroup -Name $rgName -ErrorAction SilentlyContinue -AsJob | Out-Null }
    }
    It 'Get a policy VNet link by name' {
        $link = Get-AzDnsResolverPolicyVirtualNetworkLink -Name "pvnl-get-1" -DnsResolverPolicyName "policy-pvnl-g" -ResourceGroupName $rgName
        $link.ProvisioningState | Should -Be "Succeeded"
    }
    It 'List policy VNet links' {
        $links = Get-AzDnsResolverPolicyVirtualNetworkLink -DnsResolverPolicyName "policy-pvnl-g" -ResourceGroupName $rgName
        $links.Count | Should -BeGreaterThan 0
    }
}
