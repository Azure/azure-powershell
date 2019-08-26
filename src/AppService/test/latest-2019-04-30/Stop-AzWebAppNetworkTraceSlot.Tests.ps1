$TestRecordingFile = Join-Path $PSScriptRoot 'Stop-AzWebAppNetworkTraceSlot.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Stop-AzWebAppNetworkTraceSlot' {
    It 'Stop' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'StopViaIdentity' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
