$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzAppServiceEnvironmentWebWorkerMetricDefinition.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Get-AzAppServiceEnvironmentWebWorkerMetricDefinition' {
    It 'List' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
