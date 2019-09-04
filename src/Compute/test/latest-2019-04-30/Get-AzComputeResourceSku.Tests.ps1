$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzComputeResourceSku.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Get-AzComputeResourceSku' {
    It 'List' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
