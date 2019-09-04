$TestRecordingFile = Join-Path 'C:\B\azure-powershell\src\Billing\test' 'Get-AzBillingPeriod.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Get-AzBillingPeriod' {
    It 'ListByEndDate' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
