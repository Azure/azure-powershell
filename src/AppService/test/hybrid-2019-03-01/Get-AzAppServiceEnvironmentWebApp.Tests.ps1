$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzAppServiceEnvironmentWebApp.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Get-AzAppServiceEnvironmentWebApp' {
    It 'List' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
