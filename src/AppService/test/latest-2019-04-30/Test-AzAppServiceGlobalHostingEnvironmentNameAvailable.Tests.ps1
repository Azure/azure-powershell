$TestRecordingFile = Join-Path $PSScriptRoot 'Test-AzAppServiceGlobalHostingEnvironmentNameAvailable.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Test-AzAppServiceGlobalHostingEnvironmentNameAvailable' {
    It 'Is' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'IsViaIdentity' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
