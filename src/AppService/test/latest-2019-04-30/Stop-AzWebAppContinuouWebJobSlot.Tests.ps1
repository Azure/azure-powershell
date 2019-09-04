$TestRecordingFile = Join-Path $PSScriptRoot 'Stop-AzWebAppContinuouWebJobSlot.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Stop-AzWebAppContinuouWebJobSlot' {
    It 'Stop' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'StopViaIdentity' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
