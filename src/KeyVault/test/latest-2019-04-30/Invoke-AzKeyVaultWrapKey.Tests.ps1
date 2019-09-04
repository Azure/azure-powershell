$TestRecordingFile = Join-Path $PSScriptRoot 'Invoke-AzKeyVaultWrapKey.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Invoke-AzKeyVaultWrapKey' {
    It 'WrapExpanded' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Wrap' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'WrapViaIdentityExpanded' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'WrapViaIdentity' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
