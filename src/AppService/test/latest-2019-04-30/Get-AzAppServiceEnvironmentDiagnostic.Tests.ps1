$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzAppServiceEnvironmentDiagnostic.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Get-AzAppServiceEnvironmentDiagnostic' {
    It 'List' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
