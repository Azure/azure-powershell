$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzAppServiceEnvironmentWorkerPoolSku.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Get-AzAppServiceEnvironmentWorkerPoolSku' {
    It 'List' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
