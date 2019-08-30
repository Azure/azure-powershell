$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzApplicationGatewayAvailableSslOption.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Get-AzApplicationGatewayAvailableSslOption' {
    It 'List' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
