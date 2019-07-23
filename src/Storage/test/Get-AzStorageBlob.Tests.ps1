$TestRecordingFile = Join-Path 'C:\zd\azure-powershell\src\Storage\test' 'Get-AzStorageBlob.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Get-AzStorageBlob' {
    It 'BlobName' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'BlobPrefix' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
