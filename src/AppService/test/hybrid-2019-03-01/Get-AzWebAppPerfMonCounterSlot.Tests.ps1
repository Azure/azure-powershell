$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzWebAppPerfMonCounterSlot.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Get-AzWebAppPerfMonCounterSlot' {
    It 'List' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
