$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzAppServiceEnvironmentMultiRolePoolInstanceMetricDefinition.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Get-AzAppServiceEnvironmentMultiRolePoolInstanceMetricDefinition' {
    It 'List' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
