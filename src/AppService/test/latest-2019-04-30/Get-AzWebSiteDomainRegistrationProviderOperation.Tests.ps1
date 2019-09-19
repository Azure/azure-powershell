$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzWebSiteDomainRegistrationProviderOperation.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Get-AzWebSiteDomainRegistrationProviderOperation' {
    It 'List' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
