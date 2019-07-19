$TestRecordingFile = Join-Path 'C:\zd\azure-powershell\src\Storage\test' 'Stop-AzStorageFileCopy!V2.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Stop-AzStorageFileCopy!V2' {
    It 'ShareName' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'File' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
