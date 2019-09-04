$TestRecordingFile = Join-Path $PSScriptRoot 'Undo-AzKeyVaultCertificateRemoval.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Undo-AzKeyVaultCertificateRemoval' {
    It 'Recover' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'RecoverViaIdentity' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
