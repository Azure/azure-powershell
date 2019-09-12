$TestRecordingFile = Join-Path 'C:\B\azure-powershell\src\Billing\test' 'Get-AzReservationSummary.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Get-AzReservationSummary' {
    It 'GetByDateRange' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
