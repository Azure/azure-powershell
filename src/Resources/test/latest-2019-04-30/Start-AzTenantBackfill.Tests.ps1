$TestRecordingFile = Join-Path $PSScriptRoot 'Start-AzTenantBackfill.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Start-AzTenantBackfill' {
    It 'Start' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
