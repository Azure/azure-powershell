$TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzDnsResolverPolicy.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Update-AzDnsResolverPolicy' {
    BeforeAll {
        $subscriptionId = '97db216c-169d-4ea9-9d98-114adba0aa20'
        $location = 'westus2'
        $rgName = "ps-policy-upd-14649"
        if ($TestMode -ne 'playback') {
            Select-AzSubscription -SubscriptionId $subscriptionId
            New-AzResourceGroup -Name $rgName -Location $location
            New-AzDnsResolverPolicy -Name "policy-upd-1" -ResourceGroupName $rgName -Location $location
        }
    }
    AfterAll {
        if ($TestMode -ne 'playback') {
            Remove-AzResourceGroup -Name $rgName -ErrorAction SilentlyContinue -AsJob | Out-Null
        }
    }
    It 'Update DNS resolver policy tags' {
        $tag = @{ "updated" = "true" }
        $policy = Update-AzDnsResolverPolicy -Name "policy-upd-1" -ResourceGroupName $rgName -Tag $tag
        $policy.ProvisioningState | Should -Be "Succeeded"
        $policy.Tag.Count | Should -Be 1
    }
}
