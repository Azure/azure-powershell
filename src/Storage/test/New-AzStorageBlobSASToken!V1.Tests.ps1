$TestRecordingFile = Join-Path 'C:\zd\azure-powershell\src\Storage\test' 'New-AzStorageBlobSASToken!V1.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'New-AzStorageBlobSASToken!V1' {
    It 'BlobNameWithPermission' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'BlobPipelineWithPolicy' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'BlobPipelineWithPermission' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'BlobNameWithPolicy' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
