$TestRecordingFile = Join-Path $PSScriptRoot 'Test-AzAppServiceGlobalHostingEnvironment.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Test-AzAppServiceGlobalHostingEnvironment' {
    It 'Is' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'IsViaIdentity' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
