$TestRecordingFile = Join-Path $PSScriptRoot 'New-AzVnetGatewayVpnClientPackage.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'New-AzVnetGatewayVpnClientPackage' {
    It 'GeneratevpnclientpackageExpanded1' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Generatevpnclientpackage1' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'GeneratevpnclientpackageViaIdentityExpanded1' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'GeneratevpnclientpackageViaIdentity1' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
