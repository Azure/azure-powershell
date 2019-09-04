$TestRecordingFile = Join-Path $PSScriptRoot 'Invoke-AzKeyVaultSignKey.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Invoke-AzKeyVaultSignKey' {
    It 'SignExpanded' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Sign' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'SignViaIdentityExpanded' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'SignViaIdentity' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
