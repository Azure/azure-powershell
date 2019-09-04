$TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzVmssInstance.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Remove-AzVmssInstance' {
    It 'DeleteExpanded' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'DeleteViaIdentityExpanded' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
