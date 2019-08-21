$TestRecordingFile = Join-Path $PSScriptRoot 'Add-AzADGroupMember.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Add-AzADGroupMember' {
    It 'AddMemberUpnToGroupId' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'AddMemberIdToGroupId' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'AddMemberUpnToGroupDisplayName' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'AddMemberIdToGroupDisplayName' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'AddMemberUpnToGroupObject' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'AddMemberIdToGroupObject' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
