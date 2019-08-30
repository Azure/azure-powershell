$TestRecordingFile = Join-Path $PSScriptRoot 'Set-AzVnetSubnetNetworkPolicy.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Set-AzVnetSubnetNetworkPolicy' {
    It 'PrepareExpanded' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Prepare' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
