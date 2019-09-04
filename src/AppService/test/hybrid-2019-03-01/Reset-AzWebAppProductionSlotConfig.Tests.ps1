$TestRecordingFile = Join-Path $PSScriptRoot 'Reset-AzWebAppProductionSlotConfig.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Reset-AzWebAppProductionSlotConfig' {
    It 'Reset' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'ResetViaIdentity' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
