$TestRecordingFile = Join-Path $PSScriptRoot 'New-AzStorageBlobSASToken.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'New-AzStorageBlobSASToken' {
    It 'BlobNameWithPermission' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'BlobNameWithPolicy' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'BlobPipelineWithPermission' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'BlobPipelineWithPolicy' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
