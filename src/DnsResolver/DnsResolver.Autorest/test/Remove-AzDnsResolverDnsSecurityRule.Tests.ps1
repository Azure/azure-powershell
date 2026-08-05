$TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzDnsResolverDnsSecurityRule.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) { $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File; $currentPath = Split-Path -Path $currentPath -Parent }
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Remove-AzDnsResolverDnsSecurityRule' {
    BeforeAll {
        $subscriptionId = '97db216c-169d-4ea9-9d98-114adba0aa20'; $location = 'westus2'
        $rgName = "ps-secrule-rm2-13738"
        if ($TestMode -ne 'playback') {
            Select-AzSubscription -SubscriptionId $subscriptionId
            New-AzResourceGroup -Name $rgName -Location $location
            New-AzDnsResolverPolicy -Name "policy-secrule-r" -ResourceGroupName $rgName -Location $location
            New-AzDnsResolverDomainList -Name "domainlist-secrule-r" -ResourceGroupName $rgName -Location $location -Domain @("contoso.com.")
            $dlId = "/subscriptions/$subscriptionId/resourceGroups/$rgName/providers/Microsoft.Network/dnsResolverDomainLists/domainlist-secrule-r"
            New-AzDnsResolverPolicyDnsSecurityRule -Name "secrule-rm-1" -DnsResolverPolicyName "policy-secrule-r" -ResourceGroupName $rgName -Location $location -DnsSecurityRuleState "Enabled" -ActionType "Block" -Priority 100 -DnsResolverDomainList @(@{id = $dlId})
        }
    }
    AfterAll {
        if ($TestMode -ne 'playback') { Remove-AzResourceGroup -Name $rgName -ErrorAction SilentlyContinue -AsJob | Out-Null }
    }
    It 'Delete a security rule' {
        Remove-AzDnsResolverPolicyDnsSecurityRule -Name "secrule-rm-1" -DnsResolverPolicyName "policy-secrule-r" -ResourceGroupName $rgName
        { Get-AzDnsResolverPolicyDnsSecurityRule -Name "secrule-rm-1" -DnsResolverPolicyName "policy-secrule-r" -ResourceGroupName $rgName } | Should -Throw
    }
}
