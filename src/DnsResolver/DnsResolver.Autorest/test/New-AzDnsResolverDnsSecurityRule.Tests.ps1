$TestRecordingFile = Join-Path $PSScriptRoot 'New-AzDnsResolverDnsSecurityRule.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) { $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File; $currentPath = Split-Path -Path $currentPath -Parent }
. ($mockingPath | Select-Object -First 1).FullName

Describe 'New-AzDnsResolverDnsSecurityRule' {
    BeforeAll {
        $subscriptionId = '97db216c-169d-4ea9-9d98-114adba0aa20'; $location = 'westus2'
        $rgName = "ps-secrule-new2-24133"
        if ($TestMode -ne 'playback') {
            Select-AzSubscription -SubscriptionId $subscriptionId
            New-AzResourceGroup -Name $rgName -Location $location
            New-AzDnsResolverPolicy -Name "policy-secrule-12" -ResourceGroupName $rgName -Location $location
            New-AzDnsResolverDomainList -Name "domainlist-secrule-12" -ResourceGroupName $rgName -Location $location -Domain @("contoso.com.")
        }
    }
    AfterAll {
        if ($TestMode -ne 'playback') { Remove-AzResourceGroup -Name $rgName -ErrorAction SilentlyContinue -AsJob | Out-Null }
    }
    It 'Create a DNS security rule' {
        $dlId = "/subscriptions/$subscriptionId/resourceGroups/$rgName/providers/Microsoft.Network/dnsResolverDomainLists/domainlist-secrule-12"
        $rule = New-AzDnsResolverPolicyDnsSecurityRule -Name "secrule-new-12" -DnsResolverPolicyName "policy-secrule-12" -ResourceGroupName $rgName -Location $location -DnsSecurityRuleState "Enabled" -ActionType "Block" -Priority 100 -DnsResolverDomainList @(@{id = $dlId})
        $rule.ProvisioningState | Should -Be "Succeeded"
        $rule.Name | Should -Be "secrule-new-12"
    }
}
