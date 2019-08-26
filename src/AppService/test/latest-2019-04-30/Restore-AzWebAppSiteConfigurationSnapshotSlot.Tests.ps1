$TestRecordingFile = Join-Path $PSScriptRoot 'Restore-AzWebAppSiteConfigurationSnapshotSlot.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Restore-AzWebAppSiteConfigurationSnapshotSlot' {
    It 'Recover' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'RecoverViaIdentity' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
