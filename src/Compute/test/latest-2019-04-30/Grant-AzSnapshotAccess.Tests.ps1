$TestRecordingFile = Join-Path $PSScriptRoot 'Grant-AzSnapshotAccess.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Grant-AzSnapshotAccess' {
    It 'GrantExpanded' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'GrantViaIdentityExpanded' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
