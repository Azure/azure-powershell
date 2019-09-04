$TestRecordingFile = Join-Path $PSScriptRoot 'Revoke-AzDiskAccess.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Revoke-AzDiskAccess' {
    It 'Revoke1' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'RevokeViaIdentity1' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
