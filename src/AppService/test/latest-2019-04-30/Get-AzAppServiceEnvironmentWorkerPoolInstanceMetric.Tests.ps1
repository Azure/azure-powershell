$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzAppServiceEnvironmentWorkerPoolInstanceMetric.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Get-AzAppServiceEnvironmentWorkerPoolInstanceMetric' {
    It 'List' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
