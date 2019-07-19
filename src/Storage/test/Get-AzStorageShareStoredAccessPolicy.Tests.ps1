$TestRecordingFile = Join-Path 'C:\zd\azure-powershell\src\Storage\test' 'Get-AzStorageShareStoredAccessPolicy.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Get-AzStorageShareStoredAccessPolicy' {
    It 'ShareName' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
