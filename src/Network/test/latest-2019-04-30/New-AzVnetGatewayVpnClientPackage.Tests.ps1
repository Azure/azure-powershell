$TestRecordingFile = Join-Path $PSScriptRoot 'New-AzVnetGatewayVpnClientPackage.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'New-AzVnetGatewayVpnClientPackage' {
    It 'GeneratevpnclientpackageExpanded' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Generatevpnclientpackage' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'GeneratevpnclientpackageViaIdentityExpanded' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'GeneratevpnclientpackageViaIdentity' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
