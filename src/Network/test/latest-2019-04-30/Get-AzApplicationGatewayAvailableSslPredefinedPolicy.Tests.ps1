$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzApplicationGatewayAvailableSslPredefinedPolicy.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Get-AzApplicationGatewayAvailableSslPredefinedPolicy' {
    It 'List' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
