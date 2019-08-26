$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzWebSiteRecommendationHistory.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Get-AzWebSiteRecommendationHistory' {
    It 'List1' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
