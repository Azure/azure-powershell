$TestRecordingFile = Join-Path $PSScriptRoot 'Restart-AzWebApp.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Restart-AzWebApp' {
    It 'Restart' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'RestartSlot' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'RestartViaIdentity' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
