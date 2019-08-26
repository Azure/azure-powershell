$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzWebSitePremierAddOnOffer.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Get-AzWebSitePremierAddOnOffer' {
    It 'List' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
