$TestRecordingFile = Join-Path 'C:\zd\azure-powershell\src\Storage\test' 'Get-AzStorageBlob!V1.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Get-AzStorageBlob!V1' {
    It 'BlobName' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'BlobPrefix' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
