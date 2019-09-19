$TestRecordingFile = Join-Path $PSScriptRoot 'Revoke-AzStorageAccountUserDelegationKey.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Revoke-AzStorageAccountUserDelegationKey' {
    It 'Revoke' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'RevokeViaIdentity' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
