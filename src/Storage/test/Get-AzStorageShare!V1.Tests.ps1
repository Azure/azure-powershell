$TestRecordingFile = Join-Path 'C:\zd\azure-powershell\src\Storage\test' 'Get-AzStorageShare!V1.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Get-AzStorageShare!V1' {
    It 'MatchingPrefix' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Specific' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
