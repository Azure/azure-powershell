$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzVnetGatewayVpnClientIPsecPolicy.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Get-AzVnetGatewayVpnClientIPsecPolicy' {
    It 'Get' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'GetViaIdentity' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
