$TestRecordingFile = Join-Path 'C:\zd\azure-powershell\src\Storage\test' 'Disable-AzStorageStaticWebsite!V2.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Disable-AzStorageStaticWebsite!V2' {
    It '__AllParameterSets' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
