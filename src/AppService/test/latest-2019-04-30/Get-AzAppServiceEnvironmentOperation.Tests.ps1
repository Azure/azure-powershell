$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzAppServiceEnvironmentOperation.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Get-AzAppServiceEnvironmentOperation' {
    It 'List' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
