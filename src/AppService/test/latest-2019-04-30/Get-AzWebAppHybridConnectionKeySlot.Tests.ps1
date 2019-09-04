$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzWebAppHybridConnectionKeySlot.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Get-AzWebAppHybridConnectionKeySlot' {
    It 'List' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
