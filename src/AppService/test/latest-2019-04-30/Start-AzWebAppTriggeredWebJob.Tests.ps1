$TestRecordingFile = Join-Path $PSScriptRoot 'Start-AzWebAppTriggeredWebJob.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Start-AzWebAppTriggeredWebJob' {
    It 'Run' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'RunViaIdentity' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
