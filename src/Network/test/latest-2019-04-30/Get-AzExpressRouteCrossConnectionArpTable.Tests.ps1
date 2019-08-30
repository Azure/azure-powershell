$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzExpressRouteCrossConnectionArpTable.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Get-AzExpressRouteCrossConnectionArpTable' {
    It 'List' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
