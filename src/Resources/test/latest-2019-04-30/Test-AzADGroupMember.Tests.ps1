$TestRecordingFile = Join-Path $PSScriptRoot 'Test-AzADGroupMember.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Test-AzADGroupMember' {
    It 'IsExpanded' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Is' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'IsViaIdentityExpanded' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'IsViaIdentity' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
