$TestRecordingFile = Join-Path $PSScriptRoot 'Backup-AzWebApp.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Backup-AzWebApp' {
    It 'BackupExpanded' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'BackupSlot' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'BackupExpandedSlot' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Backup' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'BackupViaIdentityExpandedSlot' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'BackupViaIdentityExpanded' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'BackupViaIdentity' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
