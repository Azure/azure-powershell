$TestRecordingFile = Join-Path $PSScriptRoot 'Enable-AzActivityLogAlert.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Enable-AzActivityLogAlert' {
    It 'Enable' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'EnableViaIdentity' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
