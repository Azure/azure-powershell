$TestRecordingFile = Join-Path $PSScriptRoot 'Stop-AzWebAppWebSiteNetworkTraceSlot.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Stop-AzWebAppWebSiteNetworkTraceSlot' {
    It 'Stop' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'StopViaIdentity' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
