$TestRecordingFile = Join-Path $PSScriptRoot 'Sync-AzWebAppRepositorySlot.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Sync-AzWebAppRepositorySlot' {
    It 'Sync' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'SyncViaIdentity' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
