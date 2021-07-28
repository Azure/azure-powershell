$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'New-AzConfluentMarketplaceAgreement.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'New-AzConfluentMarketplaceAgreement' {
    # New-AzConfluentMarketplaceAgreeemt has  be removed, because it cand be replace by Set-AzMarketplaceTerms (Az.MarketplaceOrdering).
    It 'CreateExpanded' -skip {
        { New-AzConfluentMarketplaceAgreement -Accepted } | Should -Not -Throw
    }
}
