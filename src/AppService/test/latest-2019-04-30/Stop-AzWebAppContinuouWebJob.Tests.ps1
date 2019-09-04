$TestRecordingFile = Join-Path $PSScriptRoot 'Stop-AzWebAppContinuouWebJob.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Stop-AzWebAppContinuouWebJob' {
    It 'Stop' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'StopViaIdentity' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
