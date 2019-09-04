$TestRecordingFile = Join-Path $PSScriptRoot 'New-AzP2SVpnGatewayVpnProfile.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

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
