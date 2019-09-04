$TestRecordingFile = Join-Path $PSScriptRoot 'Sync-AzWebAppFunctionTrigger.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Sync-AzWebAppFunctionTrigger' {
    It 'Sync' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'SyncViaIdentity' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
