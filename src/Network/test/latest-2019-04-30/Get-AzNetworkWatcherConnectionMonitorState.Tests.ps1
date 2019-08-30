$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzNetworkWatcherConnectionMonitorState.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Get-AzNetworkWatcherConnectionMonitorState' {
    It 'Query' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'QueryViaIdentity' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
