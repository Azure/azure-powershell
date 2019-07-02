. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Remove-AzADGroupMember' {
    It 'DeleteByMemberUpnAndGroupId' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'DeleteByMemberIdAndGroupDisplayName' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'DeleteByMemberUpnAndGroupDisplayName' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
