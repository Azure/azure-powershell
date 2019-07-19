$TestRecordingFile = Join-Path 'C:\zd\azure-powershell\src\Storage\test' 'New-AzStorageShare!V2.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'New-AzStorageShare!V2' {
    It 'ShareName' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
