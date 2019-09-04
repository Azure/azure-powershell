$TestRecordingFile = Join-Path $PSScriptRoot 'Set-AzAppServiceEnvironmentWorkerPool.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Set-AzAppServiceEnvironmentWorkerPool' {
    It 'UpdateExpanded' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Update' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
