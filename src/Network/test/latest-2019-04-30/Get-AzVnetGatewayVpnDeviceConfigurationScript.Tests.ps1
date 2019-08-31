$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzVnetGatewayVpnDeviceConfigurationScript.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

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
