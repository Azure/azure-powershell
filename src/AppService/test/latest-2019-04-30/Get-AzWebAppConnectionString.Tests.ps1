$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzWebAppConnectionString.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Get-AzWebAppConnectionString' {
    It 'List' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
