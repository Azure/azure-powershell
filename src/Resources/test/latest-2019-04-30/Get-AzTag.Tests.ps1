$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzTag.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Get-AzTag' {
    It 'List' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
