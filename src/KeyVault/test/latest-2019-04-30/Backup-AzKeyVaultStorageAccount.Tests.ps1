$TestRecordingFile = Join-Path $PSScriptRoot 'Backup-AzKeyVaultStorageAccount.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Backup-AzKeyVaultStorageAccount' {
    It 'Backup' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'BackupViaIdentity' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
