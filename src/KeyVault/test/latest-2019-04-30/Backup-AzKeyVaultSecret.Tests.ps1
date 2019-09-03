$TestRecordingFile = Join-Path $PSScriptRoot 'Backup-AzKeyVaultSecret.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Backup-AzKeyVaultSecret' {
    It 'Backup' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'BackupViaIdentity' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
