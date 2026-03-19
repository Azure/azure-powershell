$TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzDnsResolverDomainList.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Remove-AzDnsResolverDomainList' {
    BeforeAll {
        $subscriptionId = '97db216c-169d-4ea9-9d98-114adba0aa20'
        $location = 'westus2'
        $rgName = "ps-domainlist-rm-$(Get-Random -Max 99999)"
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
    It 'Delete a domain list' {
        if ($TestMode -ne 'playback') {
            New-AzDnsResolverDomainList -Name "domainlist-rm-1" -ResourceGroupName $rgName -Location $location -Domain @("contoso.com.")
        }
        Remove-AzDnsResolverDomainList -Name "domainlist-rm-1" -ResourceGroupName $rgName
        { Get-AzDnsResolverDomainList -Name "domainlist-rm-1" -ResourceGroupName $rgName } | Should -Throw
    }
}
