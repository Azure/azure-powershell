$TestRecordingFile = Join-Path $PSScriptRoot 'Protect-AzKeyVaultKey.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Protect-AzKeyVaultKey' {
    It 'EncryptExpanded' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Encrypt' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'EncryptViaIdentityExpanded' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'EncryptViaIdentity' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
