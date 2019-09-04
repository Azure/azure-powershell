$TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzADGroupMember.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Remove-AzADGroupMember' {
    It 'Remove' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'DeleteByMemberUpnAndGroupId' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'DeleteByMemberIdAndGroupId' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'DeleteByMemberIdAndGroupObject' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'DeleteByMemberIdAndGroupDisplayName' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'DeleteByMemberUpnAndGroupObject' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'DeleteByMemberUpnAndGroupDisplayName' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'RemoveViaIdentity' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
