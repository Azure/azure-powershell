$TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzDnsResolverPolicy.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Remove-AzDnsResolverPolicy' {
    BeforeAll {
        $subscriptionId = '97db216c-169d-4ea9-9d98-114adba0aa20'
        $location = 'westus2'
        $rgName = "ps-policy-rm-27559"
        if ($TestMode -ne 'playback') {
            Select-AzSubscription -SubscriptionId $subscriptionId
            New-AzResourceGroup -Name $rgName -Location $location
            New-AzDnsResolverPolicy -Name "policy-rm-1" -ResourceGroupName $rgName -Location $location
        }
    }
    AfterAll {
        if ($TestMode -ne 'playback') {
            Remove-AzResourceGroup -Name $rgName -ErrorAction SilentlyContinue -AsJob | Out-Null
        }
    }
    It 'Delete a DNS resolver policy' {
        Remove-AzDnsResolverPolicy -Name "policy-rm-1" -ResourceGroupName $rgName
        { Get-AzDnsResolverPolicy -Name "policy-rm-1" -ResourceGroupName $rgName } | Should -Throw
    }
}
