$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzEventCategory.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Get-AzEventCategory' {
    It 'List' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
