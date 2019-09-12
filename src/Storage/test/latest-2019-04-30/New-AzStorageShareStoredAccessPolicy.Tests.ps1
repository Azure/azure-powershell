$TestRecordingFile = Join-Path $PSScriptRoot 'New-AzStorageShareStoredAccessPolicy.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'New-AzStorageShareStoredAccessPolicy' {
    It 'ShareName' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
