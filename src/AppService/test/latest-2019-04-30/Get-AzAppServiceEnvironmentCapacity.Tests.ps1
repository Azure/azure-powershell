$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzAppServiceEnvironmentCapacity.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Get-AzAppServiceEnvironmentCapacity' {
    It 'List' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
