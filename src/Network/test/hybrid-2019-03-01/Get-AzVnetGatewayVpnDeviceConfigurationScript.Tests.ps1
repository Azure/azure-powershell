$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzVnetGatewayVpnDeviceConfigurationScript.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Get-AzVnetGatewayVpnDeviceConfigurationScript' {
    It 'ScriptExpanded1' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Script1' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'ScriptViaIdentityExpanded1' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'ScriptViaIdentity1' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
