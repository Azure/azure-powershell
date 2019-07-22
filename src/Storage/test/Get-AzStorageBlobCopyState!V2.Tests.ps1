$TestRecordingFile = Join-Path 'C:\zd\azure-powershell\src\Storage\test' 'Get-AzStorageBlobCopyState!V2.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Get-AzStorageBlobCopyState!V2' {
    It 'NamePipeline' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'BlobPipeline' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'ContainerPipeline' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
