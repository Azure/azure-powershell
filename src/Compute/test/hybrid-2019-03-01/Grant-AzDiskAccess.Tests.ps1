$TestRecordingFile = Join-Path $PSScriptRoot 'Grant-AzDiskAccess.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Grant-AzDiskAccess' {
    It 'GrantExpanded1' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'GrantViaIdentityExpanded1' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
