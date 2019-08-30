$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzExpressRouteRouteTable.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Get-AzExpressRouteRouteTable' {
    It 'CircuitList1Circuit' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'CircuitList3Circuit' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'CircuitList2Circuit' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'CrossConnectionListCrossConnection' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
