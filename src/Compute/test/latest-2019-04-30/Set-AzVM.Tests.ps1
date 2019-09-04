$TestRecordingFile = Join-Path $PSScriptRoot 'Set-AzVM.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Set-AzVM' {
    It 'UpdateExpanded1' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
