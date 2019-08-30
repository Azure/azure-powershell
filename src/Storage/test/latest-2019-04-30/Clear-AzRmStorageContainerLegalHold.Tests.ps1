$TestRecordingFile = Join-Path $PSScriptRoot 'Clear-AzRmStorageContainerLegalHold.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Clear-AzRmStorageContainerLegalHold' {
    It 'ClearExpanded' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Clear' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'ClearViaIdentityExpanded' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'ClearViaIdentity' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
