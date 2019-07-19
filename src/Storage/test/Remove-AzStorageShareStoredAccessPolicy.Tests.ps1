$TestRecordingFile = Join-Path 'C:\zd\azure-powershell\src\Storage\test' 'Remove-AzStorageShareStoredAccessPolicy.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Remove-AzStorageShareStoredAccessPolicy' {
    It 'ShareName' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
