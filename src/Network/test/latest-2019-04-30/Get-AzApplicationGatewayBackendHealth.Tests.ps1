$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzApplicationGatewayBackendHealth.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Get-AzApplicationGatewayBackendHealth' {
    It 'Backend' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'DemandExpanded' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'DemandViaIdentityExpanded' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'BackendViaIdentity' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
