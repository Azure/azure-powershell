$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzWebAppMetadata.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Get-AzWebAppMetadata' {
    It 'List' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
