$TestRecordingFile = Join-Path 'C:\zd\azure-powershell\src\Storage\test' 'New-AzStorageShare.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'New-AzStorageShare' {
    It 'ShareName' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
