$TestRecordingFile = Join-Path $PSScriptRoot 'Sync-AzWebAppRepository.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Sync-AzWebAppRepository' {
    It 'Sync' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'SyncViaIdentity' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
