$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzWebSiteSku.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Get-AzWebSiteSku' {
    It 'List' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
