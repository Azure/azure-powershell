$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzVMImageOffer.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Get-AzVMImageOffer' {
    It 'List' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
