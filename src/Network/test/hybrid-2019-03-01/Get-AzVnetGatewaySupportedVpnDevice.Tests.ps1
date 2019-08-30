$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzVnetGatewaySupportedVpnDevice.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Get-AzVnetGatewaySupportedVpnDevice' {
    It 'Supported1' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'SupportedViaIdentity1' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
