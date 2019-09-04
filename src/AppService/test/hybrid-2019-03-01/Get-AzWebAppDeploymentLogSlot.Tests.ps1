$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzWebAppDeploymentLogSlot.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Get-AzWebAppDeploymentLogSlot' {
    It 'List' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
