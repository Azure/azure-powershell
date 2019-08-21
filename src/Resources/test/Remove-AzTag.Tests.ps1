$TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzTag.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Remove-AzTag' {
    It 'DeleteValue' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
