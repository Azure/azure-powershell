$TestRecordingFile = Join-Path 'C:\B\azure-powershell\src\Billing\test' 'Get-AzMarketplace.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Get-AzMarketplace' {
    It 'ListExpandedFilter' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
