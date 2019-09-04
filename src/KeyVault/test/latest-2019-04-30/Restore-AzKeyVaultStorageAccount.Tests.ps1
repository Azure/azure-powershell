$TestRecordingFile = Join-Path $PSScriptRoot 'Restore-AzKeyVaultStorageAccount.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Restore-AzKeyVaultStorageAccount' {
    It 'RestoreExpanded' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Restore' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
