$TestRecordingFile = Join-Path $PSScriptRoot 'Revoke-AzSnapshotAccess.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Revoke-AzSnapshotAccess' {
    It 'Revoke' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'RevokeViaIdentity' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
