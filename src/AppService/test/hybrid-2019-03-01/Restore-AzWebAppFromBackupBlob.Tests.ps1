$TestRecordingFile = Join-Path $PSScriptRoot 'Restore-AzWebAppFromBackupBlob.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Restore-AzWebAppFromBackupBlob' {
    It 'RestoreExpanded' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Restore' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'RestoreViaIdentityExpanded' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'RestoreViaIdentity' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
