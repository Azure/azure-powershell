$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzAppServiceRecommendationRuleDetail.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Get-AzAppServiceRecommendationRuleDetail' {
    It 'Get1' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'GetViaIdentity1' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
