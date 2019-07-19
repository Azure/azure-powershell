$TestRecordingFile = Join-Path 'C:\zd\azure-powershell\src\Storage\test' 'Enable-AzStorageStaticWebsite!V2.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Enable-AzStorageStaticWebsite!V2' {
    It '__AllParameterSets' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
