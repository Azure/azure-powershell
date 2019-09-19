$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzAppServiceRecommendationHistory.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Get-AzAppServiceRecommendationHistory' {
    It 'List1' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
