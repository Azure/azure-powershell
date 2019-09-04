$TestRecordingFile = Join-Path $PSScriptRoot 'New-AzVMExtension.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'New-AzVMExtension' {
    It 'CreateExpanded' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
