$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzAppServiceEnvironmentInboundNetworkDependencyEndpoint.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Get-AzAppServiceEnvironmentInboundNetworkDependencyEndpoint' {
    It 'Get' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'GetViaIdentity' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
