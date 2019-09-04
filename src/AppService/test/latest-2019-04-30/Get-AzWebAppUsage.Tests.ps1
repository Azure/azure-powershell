$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzWebAppUsage.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Get-AzWebAppUsage' {
    It 'List' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
