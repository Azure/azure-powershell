$TestRecordingFile = Join-Path $PSScriptRoot 'New-AzStorageTableStoredAccessPolicy.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'New-AzStorageTableStoredAccessPolicy' {
    It '__AllParameterSets' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
