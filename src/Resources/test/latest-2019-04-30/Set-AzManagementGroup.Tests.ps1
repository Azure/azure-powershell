$TestRecordingFile = Join-Path $PSScriptRoot 'Set-AzManagementGroup.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Set-AzManagementGroup' {
    It 'UpdateExpanded' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Update' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
