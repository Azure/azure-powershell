$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzWebAppPerfMonCounter.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Get-AzWebAppPerfMonCounter' {
    It 'List' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
