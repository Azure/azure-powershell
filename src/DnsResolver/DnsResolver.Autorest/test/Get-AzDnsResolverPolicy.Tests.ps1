$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzDnsResolverPolicy.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Get-AzDnsResolverPolicy' {
    BeforeAll {
        $subscriptionId = '97db216c-169d-4ea9-9d98-114adba0aa20'
        $location = 'westus2'
        $rgName = "ps-policy-get-45432"
        if ($TestMode -ne 'playback') {
            Select-AzSubscription -SubscriptionId $subscriptionId
            New-AzResourceGroup -Name $rgName -Location $location
            New-AzDnsResolverPolicy -Name "policy-get-1" -ResourceGroupName $rgName -Location $location
        }
    }
    AfterAll {
        if ($TestMode -ne 'playback') {
            Remove-AzResourceGroup -Name $rgName -ErrorAction SilentlyContinue -AsJob | Out-Null
        }
    }
    It 'Get a DNS resolver policy by name' {
        $policy = Get-AzDnsResolverPolicy -Name "policy-get-1" -ResourceGroupName $rgName
        $policy.ProvisioningState | Should -Be "Succeeded"
        $policy.Name | Should -Be "policy-get-1"
    }
    It 'List DNS resolver policies in resource group' {
        $policies = Get-AzDnsResolverPolicy -ResourceGroupName $rgName
        $policies.Count | Should -BeGreaterThan 0
    }
}
