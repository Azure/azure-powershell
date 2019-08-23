$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzVMImagePublisher.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Get-AzVMImagePublisher' {
    It 'List' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
