$TestRecordingFile = Join-Path $PSScriptRoot 'Close-AzStorageFileHandle.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Close-AzStorageFileHandle' {
    It 'ShareNameCloseAll' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'ShareNameCloseSingle' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'FileCloseAll' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'DirectoryCloseAll' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'ShareCloseAll' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'ShareCloseSingle' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
