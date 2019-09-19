$TestRecordingFile = Join-Path $PSScriptRoot 'Test-AzWebAppCloneableSlot.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Test-AzWebAppCloneableSlot' {
    It 'Is' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'IsViaIdentity' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
