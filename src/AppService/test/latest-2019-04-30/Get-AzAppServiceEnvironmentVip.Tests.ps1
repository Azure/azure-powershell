$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzAppServiceEnvironmentVip.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Get-AzAppServiceEnvironmentVip' {
    It 'List' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
