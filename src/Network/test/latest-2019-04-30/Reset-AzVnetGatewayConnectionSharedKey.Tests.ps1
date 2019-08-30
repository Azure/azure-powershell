$TestRecordingFile = Join-Path $PSScriptRoot 'Reset-AzVnetGatewayConnectionSharedKey.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Reset-AzVnetGatewayConnectionSharedKey' {
    It 'ResetExpanded' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Reset' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'ResetViaIdentityExpanded' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'ResetViaIdentity' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
