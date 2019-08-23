$TestRecordingFile = Join-Path $PSScriptRoot 'New-AzVmss.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'New-AzVmss' {
    It 'CreateExpanded1' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
