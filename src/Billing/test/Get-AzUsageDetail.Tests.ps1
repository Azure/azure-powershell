$TestRecordingFile = Join-Path 'C:\B\azure-powershell\src\Billing\test' 'Get-AzUsageDetail.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Get-AzUsageDetail' {
    It 'ListExpandedFilter' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
