$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzStorageUsage.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Get-AzStorageUsage' {
    It 'List2' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
