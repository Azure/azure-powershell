$TestRecordingFile = Join-Path 'C:\zd\azure-powershell\src\Storage\test' 'New-AzStorageTable!V1.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'New-AzStorageTable!V1' {
    It '__AllParameterSets' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
