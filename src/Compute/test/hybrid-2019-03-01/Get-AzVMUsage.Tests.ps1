$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzVMUsage.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Get-AzVMUsage' {
    It 'List' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
