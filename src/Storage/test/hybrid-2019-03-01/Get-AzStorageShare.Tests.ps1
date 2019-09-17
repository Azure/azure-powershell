$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzStorageShare.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Get-AzStorageShare' {
    It 'MatchingPrefix' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Specific' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
