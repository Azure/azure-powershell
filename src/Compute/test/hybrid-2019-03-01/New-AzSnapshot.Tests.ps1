$TestRecordingFile = Join-Path $PSScriptRoot 'New-AzSnapshot.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'New-AzSnapshot' {
    It 'CreateExpanded1' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
