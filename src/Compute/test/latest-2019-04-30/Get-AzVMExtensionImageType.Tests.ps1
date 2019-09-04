$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzVMExtensionImageType.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Get-AzVMExtensionImageType' {
    It 'List' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
