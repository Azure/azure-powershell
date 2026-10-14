# Self-contained test for Invoke-AzDnsResolverBulkDnsResolverDomainList
# SKIPPED: This test requires a Storage Account with SAS tokens for bulk upload/download.
# The PowerShell autorest v4 recording framework does not sanitize SAS tokens from recordings,
# so recorded tests would expose credentials. Run manually in live mode only.

$TestRecordingFile = Join-Path $PSScriptRoot 'Invoke-AzDnsResolverBulkDnsResolverDomainList.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) { $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File; $currentPath = Split-Path -Path $currentPath -Parent }
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Invoke-AzDnsResolverBulkDnsResolverDomainList' {
    It 'Bulk upload domains to a domain list from storage blob' -Skip {
        # Test requires live Storage Account + SAS token; cannot be recorded safely.
        # To run manually: .\test-module.ps1 -Live -TestName 'Invoke-AzDnsResolverBulkDnsResolverDomainList'
        $true | Should -Be $true
    }
}
