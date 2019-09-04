$TestRecordingFile = Join-Path $PSScriptRoot 'Set-AzImage.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Set-AzImage' {
    It 'UpdateExpanded' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
