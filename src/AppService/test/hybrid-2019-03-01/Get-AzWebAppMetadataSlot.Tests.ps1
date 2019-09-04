$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzWebAppMetadataSlot.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Get-AzWebAppMetadataSlot' {
    It 'List' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
