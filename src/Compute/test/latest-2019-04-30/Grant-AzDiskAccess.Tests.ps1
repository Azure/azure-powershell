$TestRecordingFile = Join-Path $PSScriptRoot 'Grant-AzDiskAccess.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Grant-AzDiskAccess' {
    It 'GrantExpanded' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'GrantViaIdentityExpanded' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
