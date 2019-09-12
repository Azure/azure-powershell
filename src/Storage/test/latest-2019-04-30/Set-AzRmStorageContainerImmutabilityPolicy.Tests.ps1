$TestRecordingFile = Join-Path $PSScriptRoot 'Set-AzRmStorageContainerImmutabilityPolicy.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Set-AzRmStorageContainerImmutabilityPolicy' {
    It 'Update' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'UpdateExpanded' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
