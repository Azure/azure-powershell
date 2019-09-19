$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzAppServiceDomainRegistrationProviderOperation.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Get-AzAppServiceDomainRegistrationProviderOperation' {
    It 'List' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
