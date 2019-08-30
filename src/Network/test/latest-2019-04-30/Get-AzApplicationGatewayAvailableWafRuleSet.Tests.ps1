$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzApplicationGatewayAvailableWafRuleSet.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Get-AzApplicationGatewayAvailableWafRuleSet' {
    It 'List' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
