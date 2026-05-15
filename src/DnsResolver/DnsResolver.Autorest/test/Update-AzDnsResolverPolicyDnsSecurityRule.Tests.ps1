$TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzDnsResolverPolicyDnsSecurityRule.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) { $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File; $currentPath = Split-Path -Path $currentPath -Parent }
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Update-AzDnsResolverPolicyDnsSecurityRule' {
    BeforeAll {
        $subscriptionId = '97db216c-169d-4ea9-9d98-114adba0aa20'; $location = 'westus2'
        $rgName = "ps-secrule-upd-76480"
        if ($TestMode -ne 'playback') {
            Select-AzSubscription -SubscriptionId $subscriptionId
            New-AzResourceGroup -Name $rgName -Location $location
            New-AzDnsResolverPolicy -Name "policy-secrule-u" -ResourceGroupName $rgName -Location $location
            New-AzDnsResolverDomainList -Name "domainlist-secrule-u" -ResourceGroupName $rgName -Location $location -Domain @("contoso.com.")
            $dlId = "/subscriptions/$subscriptionId/resourceGroups/$rgName/providers/Microsoft.Network/dnsResolverDomainLists/domainlist-secrule-u"
            New-AzDnsResolverPolicyDnsSecurityRule -Name "secrule-upd-1" -DnsResolverPolicyName "policy-secrule-u" -ResourceGroupName $rgName -Location $location -DnsSecurityRuleState "Enabled" -ActionType "Block" -Priority 100 -DnsResolverDomainList @(@{id = $dlId})
        }
    }
    AfterAll {
        if ($TestMode -ne 'playback') { Remove-AzResourceGroup -Name $rgName -ErrorAction SilentlyContinue -AsJob | Out-Null }
    }
    It 'Update security rule tags' {
        $tag = @{ "updated" = "true" }
        $rule = Update-AzDnsResolverPolicyDnsSecurityRule -Name "secrule-upd-1" -DnsResolverPolicyName "policy-secrule-u" -ResourceGroupName $rgName -Tag $tag
        $rule.ProvisioningState | Should -Be "Succeeded"
        $rule.Tag.Count | Should -Be 1
    }
}
