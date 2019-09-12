$TestRecordingFile = Join-Path $PSScriptRoot 'Set-AzStorageTableStoredAccessPolicy.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Set-AzStorageTableStoredAccessPolicy' {
    It '__AllParameterSets' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
