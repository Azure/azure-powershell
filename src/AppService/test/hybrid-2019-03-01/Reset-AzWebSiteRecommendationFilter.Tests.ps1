$TestRecordingFile = Join-Path $PSScriptRoot 'Reset-AzWebSiteRecommendationFilter.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Reset-AzWebSiteRecommendationFilter' {
    It 'Reset' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Reset2' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'ResetViaIdentity2' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'ResetViaIdentity' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
