$TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzDnsResolverDomainList.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Update-AzDnsResolverDomainList' {
    BeforeAll {
        $subscriptionId = '97db216c-169d-4ea9-9d98-114adba0aa20'
        $location = 'westus2'
        $rgName = "ps-domainlist-upd-8632"
        if ($TestMode -ne 'playback') {
            Select-AzSubscription -SubscriptionId $subscriptionId
            New-AzResourceGroup -Name $rgName -Location $location
            New-AzDnsResolverDomainList -Name "domainlist-upd-1" -ResourceGroupName $rgName -Location $location -Domain @("contoso.com.")
        }
    }
    AfterAll {
        if ($TestMode -ne 'playback') {
            Remove-AzResourceGroup -Name $rgName -ErrorAction SilentlyContinue -AsJob | Out-Null
        }
    }
    It 'Update domain list tags' {
        $tag = @{ "updated" = "true" }
        $dl = Update-AzDnsResolverDomainList -Name "domainlist-upd-1" -ResourceGroupName $rgName -Tag $tag
        $dl.ProvisioningState | Should -Be "Succeeded"
        $dl.Tag.Count | Should -Be 1
    }
}
