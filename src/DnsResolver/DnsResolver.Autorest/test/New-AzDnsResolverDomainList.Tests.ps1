$TestRecordingFile = Join-Path $PSScriptRoot 'New-AzDnsResolverDomainList.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'New-AzDnsResolverDomainList' {
    BeforeAll {
        $subscriptionId = '97db216c-169d-4ea9-9d98-114adba0aa20'
        $location = 'westus2'
        $rgName = "ps-domainlist-new-$(Get-Random -Max 99999)"
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
    It 'Create a DNS resolver domain list' {
        $domainList = New-AzDnsResolverDomainList -Name "domainlist-new-1" -ResourceGroupName $rgName -Location $location -Domain @("contoso.com.", "example.com.")
        $domainList.ProvisioningState | Should -Be "Succeeded"
        $domainList.Name | Should -Be "domainlist-new-1"
    }
}
