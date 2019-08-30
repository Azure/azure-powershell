$TestRecordingFile = Join-Path $PSScriptRoot 'Set-AzVnetGatewayConnectionSharedKey.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Set-AzVnetGatewayConnectionSharedKey' {
    It 'SetExpanded1' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Set1' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
