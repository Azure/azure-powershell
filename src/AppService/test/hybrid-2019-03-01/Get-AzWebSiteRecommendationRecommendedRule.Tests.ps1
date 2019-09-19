$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzWebSiteRecommendationRecommendedRule.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Get-AzWebSiteRecommendationRecommendedRule' {
    It 'List1' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
