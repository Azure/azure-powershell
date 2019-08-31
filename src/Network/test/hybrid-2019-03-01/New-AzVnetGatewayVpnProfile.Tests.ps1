$TestRecordingFile = Join-Path $PSScriptRoot 'New-AzVnetGatewayVpnProfile.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

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
