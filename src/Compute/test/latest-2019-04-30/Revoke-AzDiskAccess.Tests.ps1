$TestRecordingFile = Join-Path $PSScriptRoot 'Revoke-AzDiskAccess.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Revoke-AzDiskAccess' {
    It 'Revoke' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'RevokeViaIdentity' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
