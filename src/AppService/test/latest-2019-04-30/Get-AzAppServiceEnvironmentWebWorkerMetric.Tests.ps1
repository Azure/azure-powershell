$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzAppServiceEnvironmentWebWorkerMetric.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Get-AzAppServiceEnvironmentWebWorkerMetric' {
    It 'List' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
