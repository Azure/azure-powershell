$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzAppServicePremierAddOnOffer.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Get-AzAppServicePremierAddOnOffer' {
    It 'List' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
