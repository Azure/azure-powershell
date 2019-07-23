$TestRecordingFile = Join-Path 'C:\Code\azps-generation\src\Network\test' 'Get-AzApplicationGatewayBackendHealth.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Get-AzApplicationGatewayBackendHealth' {
    It 'DemandExpanded' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Demand' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'DemandViaIdentityExpanded' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'DemandViaIdentity' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
