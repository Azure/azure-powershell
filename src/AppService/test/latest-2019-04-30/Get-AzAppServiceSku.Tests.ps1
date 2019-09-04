$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzAppServiceSku.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Get-AzAppServiceSku' {
    It 'List' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
