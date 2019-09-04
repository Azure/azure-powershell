$TestRecordingFile = Join-Path $PSScriptRoot 'Invoke-AzTenantBackfillStatus.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Invoke-AzTenantBackfillStatus' {
    It 'Tenant' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
