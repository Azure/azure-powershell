$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzStorageBlobService.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Get-AzStorageBlobService' {
    It 'List' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
