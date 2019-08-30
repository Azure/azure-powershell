$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzVnetAvailableEndpointService.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Get-AzVnetAvailableEndpointService' {
    It 'List' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
