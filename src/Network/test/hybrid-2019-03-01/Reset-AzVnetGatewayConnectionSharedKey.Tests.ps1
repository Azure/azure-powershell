$TestRecordingFile = Join-Path $PSScriptRoot 'Reset-AzVnetGatewayConnectionSharedKey.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Reset-AzVnetGatewayConnectionSharedKey' {
    It 'ResetExpanded1' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Reset1' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'ResetViaIdentityExpanded1' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'ResetViaIdentity1' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
