$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzWebAppDeploymentLog.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Get-AzWebAppDeploymentLog' {
    It 'List' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
