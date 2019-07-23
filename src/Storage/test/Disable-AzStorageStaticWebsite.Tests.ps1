$TestRecordingFile = Join-Path 'C:\zd\azure-powershell\src\Storage\test' 'Disable-AzStorageStaticWebsite.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Disable-AzStorageStaticWebsite' {
    It '__AllParameterSets' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
