$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzNetworkInterfaceLoadBalancer.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Get-AzNetworkInterfaceLoadBalancer' {
    It 'List' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
