$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzDnsResolverPolicyDnsSecurityRule.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) { $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File; $currentPath = Split-Path -Path $currentPath -Parent }
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Get-AzDnsResolverPolicyDnsSecurityRule' {
    BeforeAll {
        $subscriptionId = '97db216c-169d-4ea9-9d98-114adba0aa20'; $location = 'westus2'
        $rgName = "ps-secrule-get-$(Get-Random -Max 99999)"
        if ($TestMode -ne 'playback') {
            Select-AzSubscription -SubscriptionId $subscriptionId
            New-AzResourceGroup -Name $rgName -Location $location
            New-AzDnsResolverPolicy -Name "policy-secrule-g" -ResourceGroupName $rgName -Location $location
            New-AzDnsResolverDomainList -Name "domainlist-secrule-g" -ResourceGroupName $rgName -Location $location -Domain @("contoso.com.")
            $dlId = "/subscriptions/$subscriptionId/resourceGroups/$rgName/providers/Microsoft.Network/dnsResolverDomainLists/domainlist-secrule-g"
            New-AzDnsResolverPolicyDnsSecurityRule -Name "secrule-get-1" -DnsResolverPolicyName "policy-secrule-g" -ResourceGroupName $rgName -Location $location -DnsSecurityRuleState "Enabled" -ActionType "Block" -Priority 100 -DnsResolverDomainList @(@{id = $dlId})
        }
    }
    AfterAll {
        if ($TestMode -ne 'playback') { Remove-AzResourceGroup -Name $rgName -ErrorAction SilentlyContinue -AsJob | Out-Null }
    }
    It 'Get a security rule by name' {
        $rule = Get-AzDnsResolverPolicyDnsSecurityRule -Name "secrule-get-1" -DnsResolverPolicyName "policy-secrule-g" -ResourceGroupName $rgName
        $rule.ProvisioningState | Should -Be "Succeeded"
    }
    It 'List security rules in policy' {
        $rules = Get-AzDnsResolverPolicyDnsSecurityRule -DnsResolverPolicyName "policy-secrule-g" -ResourceGroupName $rgName
        $rules.Count | Should -BeGreaterThan 0
    }
}
