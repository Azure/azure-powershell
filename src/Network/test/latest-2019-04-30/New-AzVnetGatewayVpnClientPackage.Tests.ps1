$TestRecordingFile = Join-Path $PSScriptRoot 'New-AzVnetGatewayVpnClientPackage.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

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
