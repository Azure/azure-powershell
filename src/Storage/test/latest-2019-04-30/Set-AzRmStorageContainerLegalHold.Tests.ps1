$TestRecordingFile = Join-Path $PSScriptRoot 'Set-AzRmStorageContainerLegalHold.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Set-AzRmStorageContainerLegalHold' {
    It 'SetExpanded' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Set' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
