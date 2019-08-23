$TestRecordingFile = Join-Path $PSScriptRoot 'Unprotect-AzKeyVaultKey.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Unprotect-AzKeyVaultKey' {
    It 'DecryptExpanded' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Decrypt' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'DecryptViaIdentityExpanded' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'DecryptViaIdentity' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
