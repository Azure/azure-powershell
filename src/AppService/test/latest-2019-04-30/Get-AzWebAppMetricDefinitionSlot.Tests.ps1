$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzWebAppMetricDefinitionSlot.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Get-AzWebAppMetricDefinitionSlot' {
    It 'List' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
