$TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzManagementGroupSubscription.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Remove-AzManagementGroupSubscription' {
    It 'Delete' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'DeleteViaIdentity' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
