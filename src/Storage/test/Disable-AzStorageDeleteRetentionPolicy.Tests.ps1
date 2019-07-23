$TestRecordingFile = Join-Path 'C:\zd\azure-powershell\src\Storage\test' 'Disable-AzStorageDeleteRetentionPolicy.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Disable-AzStorageDeleteRetentionPolicy' {
    It '__AllParameterSets' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
