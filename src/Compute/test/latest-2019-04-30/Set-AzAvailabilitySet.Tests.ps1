$TestRecordingFile = Join-Path $PSScriptRoot 'Set-AzAvailabilitySet.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Set-AzAvailabilitySet' {
    It 'UpdateExpanded' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
