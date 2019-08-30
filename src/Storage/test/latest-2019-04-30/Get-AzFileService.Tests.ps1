$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzFileService.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Get-AzFileService' {
    It 'List' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
