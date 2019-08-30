$TestRecordingFile = Join-Path $PSScriptRoot 'Lock-AzRmStorageContainerImmutabilityPolicy.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Lock-AzRmStorageContainerImmutabilityPolicy' {
    It 'Lock' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'LockViaIdentity' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
