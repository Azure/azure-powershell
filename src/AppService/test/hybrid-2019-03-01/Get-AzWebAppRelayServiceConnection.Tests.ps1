$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzWebAppRelayServiceConnection.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Get-AzWebAppRelayServiceConnection' {
    It 'List' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Get' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'GetViaIdentity' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
