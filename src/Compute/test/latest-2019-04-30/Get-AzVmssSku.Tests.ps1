$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzVmssSku.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Get-AzVmssSku' {
    It 'List' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
