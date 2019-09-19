$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzAppServiceEnvironmentMetric.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Get-AzAppServiceEnvironmentMetric' {
    It 'List' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
