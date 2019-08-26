$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzAppServiceEnvironmentMultiRoleMetricDefinition.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Get-AzAppServiceEnvironmentMultiRoleMetricDefinition' {
    It 'List' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
