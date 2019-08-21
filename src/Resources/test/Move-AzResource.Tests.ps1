$TestRecordingFile = Join-Path $PSScriptRoot 'Move-AzResource.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Move-AzResource' {
    It 'MoveByComponents' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
