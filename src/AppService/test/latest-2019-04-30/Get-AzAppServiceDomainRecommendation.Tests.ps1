$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzAppServiceDomainRecommendation.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Get-AzAppServiceDomainRecommendation' {
    It 'ListExpanded' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'List' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
