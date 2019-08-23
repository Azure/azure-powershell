$TestRecordingFile = Join-Path $PSScriptRoot 'Invoke-AzKeyVaultUnwrapKey.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Invoke-AzKeyVaultUnwrapKey' {
    It 'UnwrapExpanded' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Unwrap' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'UnwrapViaIdentityExpanded' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'UnwrapViaIdentity' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
