$TestRecordingFile = Join-Path 'C:\B\azure-powershell\src\Resources\test' 'New-AzRoleAssignment.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'New-AzRoleAssignment' {
    It 'CreateByScopeAndObjectId' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'CreateByScopeAndSPN' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'CreateByScopeAndSignInName' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'CreateById' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
