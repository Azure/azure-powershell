$TestRecordingFile = Join-Path 'C:\zd\azure-powershell\src\Storage\test' 'Remove-AzStorageTable!V2.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Remove-AzStorageTable!V2' {
    It '__AllParameterSets' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
