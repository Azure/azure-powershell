$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzExpressRouteRouteTable.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

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
