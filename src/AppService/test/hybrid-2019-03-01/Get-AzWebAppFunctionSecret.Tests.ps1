$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzWebAppFunctionSecret.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Get-AzWebAppFunctionSecret' {
    It 'List' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
