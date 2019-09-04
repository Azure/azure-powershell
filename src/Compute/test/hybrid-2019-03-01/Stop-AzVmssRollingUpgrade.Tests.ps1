$TestRecordingFile = Join-Path $PSScriptRoot 'Stop-AzVmssRollingUpgrade.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Stop-AzVmssRollingUpgrade' {
    It 'Cancel' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'CancelViaIdentity' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
