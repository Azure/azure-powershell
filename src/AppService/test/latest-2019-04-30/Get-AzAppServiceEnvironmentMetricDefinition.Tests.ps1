$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzAppServiceEnvironmentMetricDefinition.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Get-AzAppServiceEnvironmentMetricDefinition' {
    It 'List' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
