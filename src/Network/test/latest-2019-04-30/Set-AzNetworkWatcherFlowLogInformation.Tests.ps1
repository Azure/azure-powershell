$TestRecordingFile = Join-Path $PSScriptRoot 'Set-AzNetworkWatcherFlowLogInformation.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Set-AzNetworkWatcherFlowLogInformation' {
    It 'SetExpanded' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Set' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
