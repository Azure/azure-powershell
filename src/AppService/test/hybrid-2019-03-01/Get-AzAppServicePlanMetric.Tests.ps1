$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzAppServicePlanMetric.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Get-AzAppServicePlanMetric' {
    It 'List' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
