$TestRecordingFile = Join-Path $PSScriptRoot 'Reset-AzWebAppSlotConfigurationSlot.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Reset-AzWebAppSlotConfigurationSlot' {
    It 'Reset' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'ResetViaIdentity' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
