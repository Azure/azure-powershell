$TestRecordingFile = Join-Path $PSScriptRoot 'Stop-AzWebApp.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Stop-AzWebApp' {
    It 'Stop' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'StopSlot' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'StopViaIdentity' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
