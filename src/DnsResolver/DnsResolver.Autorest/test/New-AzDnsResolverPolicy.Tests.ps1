$TestRecordingFile = Join-Path $PSScriptRoot 'New-AzDnsResolverPolicy.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'New-AzDnsResolverPolicy' {
    BeforeAll {
        $subscriptionId = '97db216c-169d-4ea9-9d98-114adba0aa20'
        $location = 'westus2'
        $rgName = "ps-policy-new-98765"
        if ($TestMode -ne 'playback') {
            Select-AzSubscription -SubscriptionId $subscriptionId
            New-AzResourceGroup -Name $rgName -Location $location
        }
    }
    AfterAll {
        if ($TestMode -ne 'playback') {
            Remove-AzResourceGroup -Name $rgName -ErrorAction SilentlyContinue -AsJob | Out-Null
        }
    }
    It 'Create a DNS resolver policy' {
        $policy = New-AzDnsResolverPolicy -Name "policy-new-1" -ResourceGroupName $rgName -Location $location
        $policy.ProvisioningState | Should -Be "Succeeded"
        $policy.Name | Should -Be "policy-new-1"
    }
    It 'Create a DNS resolver policy with tags' {
        $tag = @{ "env" = "test" }
        $policy = New-AzDnsResolverPolicy -Name "policy-new-2" -ResourceGroupName $rgName -Location $location -Tag $tag
        $policy.ProvisioningState | Should -Be "Succeeded"
        $policy.Tag.Count | Should -Be 1
    }
}
