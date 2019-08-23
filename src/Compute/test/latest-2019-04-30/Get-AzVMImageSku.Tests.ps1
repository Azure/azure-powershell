$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzVMImageSku.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Get-AzVMImageSku' {
    It 'List' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
