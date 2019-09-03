$TestRecordingFile = Join-Path $PSScriptRoot 'Backup-AzKeyVaultKey.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Backup-AzKeyVaultKey' {
    It 'Backup' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'BackupViaIdentity' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
