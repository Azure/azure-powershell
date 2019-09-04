$TestRecordingFile = Join-Path $PSScriptRoot 'Undo-AzKeyVaultStorageSasDefinitionRemoval.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Undo-AzKeyVaultStorageSasDefinitionRemoval' {
    It 'Recover' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'RecoverViaIdentity' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
