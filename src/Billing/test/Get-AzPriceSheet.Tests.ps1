$TestRecordingFile = Join-Path 'C:\B\azure-powershell\src\Billing\test' 'Get-AzPriceSheet.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Get-AzPriceSheet' {
    It 'GetExpandedMeterDetails' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
