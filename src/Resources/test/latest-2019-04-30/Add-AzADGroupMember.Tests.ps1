$TestRecordingFile = Join-Path $PSScriptRoot 'Add-AzADGroupMember.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Add-AzADGroupMember' {
    It 'AddExpanded' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'AddMemberIdToGroupId' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'AddMemberUpnToGroupId' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Add' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'AddMemberIdToGroupObject' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'AddMemberUpnToGroupObject' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'AddMemberIdToGroupDisplayName' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'AddMemberUpnToGroupDisplayName' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'AddViaIdentityExpanded' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'AddViaIdentity' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
