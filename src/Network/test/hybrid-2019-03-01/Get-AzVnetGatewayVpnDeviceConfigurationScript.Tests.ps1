$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzVnetGatewayVpnDeviceConfigurationScript.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

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
