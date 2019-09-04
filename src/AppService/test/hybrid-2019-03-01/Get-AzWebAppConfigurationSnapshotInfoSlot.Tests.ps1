$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzWebAppConfigurationSnapshotInfoSlot.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Get-AzWebAppConfigurationSnapshotInfoSlot' {
    It 'List' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
