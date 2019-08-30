$TestRecordingFile = Join-Path $PSScriptRoot 'New-AzP2SVpnGatewayVpnProfile.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'New-AzP2SVpnGatewayVpnProfile' {
    It 'GenerateExpanded' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Generate' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'GenerateViaIdentityExpanded' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'GenerateViaIdentity' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
