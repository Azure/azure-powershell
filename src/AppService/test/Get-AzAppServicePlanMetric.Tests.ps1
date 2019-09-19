$TestRecordingFile = Join-Path $PSScriptRoot 'C:\B\azure-powershell\src\AppService\test' 'Get-AzAppServicePlanMetric.Recording.json'

. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Get-AzAppServicePlanMetric' {
    It 'ListByFilter' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
