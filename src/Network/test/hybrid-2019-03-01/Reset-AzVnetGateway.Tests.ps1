$TestRecordingFile = Join-Path $PSScriptRoot 'Reset-AzVnetGateway.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Reset-AzVnetGateway' {
    It 'Reset1' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'ResetViaIdentity1' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
