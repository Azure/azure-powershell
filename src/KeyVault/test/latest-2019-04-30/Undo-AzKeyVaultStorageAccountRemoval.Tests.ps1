$TestRecordingFile = Join-Path $PSScriptRoot 'Undo-AzKeyVaultStorageAccountRemoval.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Undo-AzKeyVaultStorageAccountRemoval' {
    It 'Recover' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'RecoverViaIdentity' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
