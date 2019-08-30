$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzExpressRouteCrossConnectionRouteTableSummary.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Get-AzExpressRouteCrossConnectionRouteTableSummary' {
    It 'List' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
