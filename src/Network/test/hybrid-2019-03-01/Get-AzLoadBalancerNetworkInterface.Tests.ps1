$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzLoadBalancerNetworkInterface.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Get-AzLoadBalancerNetworkInterface' {
    It 'List1' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
