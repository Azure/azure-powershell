$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzAppServiceEnvironmentMultiRoleUsage.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Get-AzAppServiceEnvironmentMultiRoleUsage' {
    It 'List' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
