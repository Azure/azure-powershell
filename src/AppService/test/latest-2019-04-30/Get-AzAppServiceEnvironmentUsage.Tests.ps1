$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzAppServiceEnvironmentUsage.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Get-AzAppServiceEnvironmentUsage' {
    It 'List' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
