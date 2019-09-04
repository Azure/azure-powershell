$TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzRoleAssignment.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Remove-AzRoleAssignment' {
    It 'Delete1' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Delete2' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Delete3' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'DeleteViaIdentity3' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'DeleteViaIdentity2' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'DeleteViaIdentity1' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
