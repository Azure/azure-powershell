$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzWebAppSyncFunctionTriggerSlot.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Get-AzWebAppSyncFunctionTriggerSlot' {
    It 'List' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
