$TestRecordingFile = Join-Path 'C:\zd\azure-powershell\src\Storage\test' 'Start-AzStorageFileCopy!V1.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Start-AzStorageFileCopy!V1' {
    It 'ContainerName' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'ContainerInstance' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'BlobInstanceFilePath' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'BlobInstanceFileInstance' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'ShareName' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'ShareInstance' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'FileInstanceToFilePath' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'FileInstanceToFileInstance' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'UriToFilePath' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'UriToFileInstance' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
