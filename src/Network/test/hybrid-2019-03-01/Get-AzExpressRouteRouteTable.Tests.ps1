$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzExpressRouteRouteTable.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Get-AzExpressRouteRouteTable' {
    It 'CircuitListCircuit' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
