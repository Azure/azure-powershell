."$PSScriptRoot\testDataGenerator.ps1"
."$PSScriptRoot\virtualNetworkClient.ps1"
."$PSScriptRoot\forwardingRulesetAssertions.ps1"
."$PSScriptRoot\stringExtensions.ps1"

Add-AssertionOperator -Name 'BeSuccessfullyCreatedDnsForwardingRuleset' -Test $Function:BeSuccessfullyCreated

$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzDnsResolverDnsForwardingRuleset.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Get-AzDnsResolverDnsForwardingRuleset' {
    It 'Get single DNS forwarding ruleset by name, expect DNS forwarding ruleset by name retrieved' -skip {
        $dnsForwardingRulesetName = $env.ForwardingRulesetForGet0
        $dnsForwardingRuleset =  Get-AzDnsResolverDnsForwardingRuleset -Name $dnsForwardingRulesetName -ResourceGroupName $env.ResourceGroupName
        $dnsForwardingRuleset | Should -BeSuccessfullyCreatedDnsForwardingRuleset
    }

    It 'Get single DNS forwarding ruleset that does not exist by name, expect failure' -skip {
        $dnsForwardingRulesetName = (RandomString -allChars $false -len 10)
        {Get-AzDnsResolverDnsForwardingRuleset -Name dnsForwardingRuleset -ResourceGroupName $env.ResourceGroupName} | Should -Throw "not found"
    }

    It 'List DNS forwarding rulesets under a subscription, expected exact number of DNS forwarding rulesets retrieved' -skip {
        $dnsForwardingRuleset =  Get-AzDnsResolverDnsForwardingRuleset -SubscriptionId  $env.SubscriptionId
        $dnsForwardingRuleset.Count | Should -gt 1
    }

    It 'List DNS forwarding rulesets under a resource group, expected exact number of DNS forwarding rulesets retrieved' -skip {
        $dnsForwardingRuleset =  Get-AzDnsResolverDnsForwardingRuleset -ResourceGroupName $env.ResourceGroupName
        $dnsForwardingRuleset.Count | Should -Be $env.NumberOfResources
    }
}
