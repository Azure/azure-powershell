$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzVnetGatewayVpnDeviceConfigurationScript.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Get-AzVnetGatewayVpnDeviceConfigurationScript' {
    It 'ScriptExpanded' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Script' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'ScriptViaIdentityExpanded' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'ScriptViaIdentity' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
