$TestRecordingFile = Join-Path 'C:\zd\azure-powershell\src\Storage\test' 'Start-AzStorageBlobIncrementalCopy!V2.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Start-AzStorageBlobIncrementalCopy!V2' {
    It 'ContainerInstance' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'BlobInstance' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'BlobInstanceToBlobInstance' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'ContainerName' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'UriPipeline' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
