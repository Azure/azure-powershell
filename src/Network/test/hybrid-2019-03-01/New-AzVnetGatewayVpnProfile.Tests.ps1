$TestRecordingFile = Join-Path $PSScriptRoot 'New-AzVnetGatewayVpnProfile.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'New-AzVnetGatewayVpnProfile' {
    It 'GenerateExpanded1' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Generate1' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'GenerateViaIdentityExpanded1' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'GenerateViaIdentity1' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
