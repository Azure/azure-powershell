$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzADApplicationOwner.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Get-AzADApplicationOwner' {
    It 'List' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
