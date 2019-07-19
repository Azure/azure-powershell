$TestRecordingFile = Join-Path 'C:\zd\azure-powershell\src\Storage\test' 'Enable-AzStorageDeleteRetentionPolicy!V2.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Enable-AzStorageDeleteRetentionPolicy!V2' {
    It '__AllParameterSets' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
