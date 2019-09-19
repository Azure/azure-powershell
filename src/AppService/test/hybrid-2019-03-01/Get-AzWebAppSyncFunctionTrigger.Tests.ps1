$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzWebAppSyncFunctionTrigger.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Get-AzWebAppSyncFunctionTrigger' {
    It 'List' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
