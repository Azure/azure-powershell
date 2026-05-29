$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzDnsResolverDomainList.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Get-AzDnsResolverDomainList' {
    BeforeAll {
        $subscriptionId = '97db216c-169d-4ea9-9d98-114adba0aa20'
        $location = 'westus2'
        $rgName = "ps-domainlist-get-87395"
        if ($TestMode -ne 'playback') {
            Select-AzSubscription -SubscriptionId $subscriptionId
            New-AzResourceGroup -Name $rgName -Location $location
            New-AzDnsResolverDomainList -Name "domainlist-get-1" -ResourceGroupName $rgName -Location $location -Domain @("contoso.com.")
        }
    }
    AfterAll {
        if ($TestMode -ne 'playback') {
            Remove-AzResourceGroup -Name $rgName -ErrorAction SilentlyContinue -AsJob | Out-Null
        }
    }
    It 'Get a DNS resolver domain list by name' {
        $dl = Get-AzDnsResolverDomainList -Name "domainlist-get-1" -ResourceGroupName $rgName
        $dl.ProvisioningState | Should -Be "Succeeded"
        $dl.Name | Should -Be "domainlist-get-1"
    }
    It 'List domain lists in resource group' {
        $dls = Get-AzDnsResolverDomainList -ResourceGroupName $rgName
        $dls.Count | Should -BeGreaterThan 0
    }
}
