$TestRecordingFile = Join-Path $PSScriptRoot 'Start-AzWebAppTriggeredWebJobSlot.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Start-AzWebAppTriggeredWebJobSlot' {
    It 'Run' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'RunViaIdentity' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
