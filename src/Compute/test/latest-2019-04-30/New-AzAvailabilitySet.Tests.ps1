$TestRecordingFile = Join-Path $PSScriptRoot 'New-AzAvailabilitySet.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'New-AzAvailabilitySet' {
    It 'CreateExpanded' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
