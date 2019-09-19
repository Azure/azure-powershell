$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzAppServiceRecommendation.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Get-AzAppServiceRecommendation' {
    It 'List' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
