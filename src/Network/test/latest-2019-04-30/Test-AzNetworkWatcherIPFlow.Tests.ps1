$TestRecordingFile = Join-Path $PSScriptRoot 'Test-AzNetworkWatcherIPFlow.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Test-AzNetworkWatcherIPFlow' {
    It 'VerifyExpanded' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Verify' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'VerifyViaIdentityExpanded' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'VerifyViaIdentity' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
