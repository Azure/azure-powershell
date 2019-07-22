$TestRecordingFile = Join-Path 'C:\zd\azure-powershell\src\Storage\test' 'Start-AzStorageBlobCopy!V2.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Start-AzStorageBlobCopy!V2' {
    It 'ContainerName' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'BlobInstance' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'BlobInstanceToBlobInstance' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'ContainerInstance' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'ShareName' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'ShareInstance' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'DirInstance' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'FileInstance' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'FileInstanceToBlobInstance' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'UriPipeline' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
