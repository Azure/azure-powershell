$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzVnetGatewaySupportedVpnDevice.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Get-AzVnetGatewaySupportedVpnDevice' {
    It 'Supported' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'SupportedViaIdentity' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
