$TestRecordingFile = Join-Path $PSScriptRoot 'Disable-AzActivityLogAlert.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Disable-AzActivityLogAlert' {
    It 'Disable' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'DisableViaIdentity' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
