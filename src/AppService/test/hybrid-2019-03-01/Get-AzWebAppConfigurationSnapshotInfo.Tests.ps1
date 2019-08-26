$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzWebAppConfigurationSnapshotInfo.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Get-AzWebAppConfigurationSnapshotInfo' {
    It 'List' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
