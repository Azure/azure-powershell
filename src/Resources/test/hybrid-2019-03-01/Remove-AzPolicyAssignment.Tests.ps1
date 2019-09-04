$TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzPolicyAssignment.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Remove-AzPolicyAssignment' {
    It 'Delete2' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'DeleteViaIdentity2' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
