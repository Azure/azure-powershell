$TestRecordingFile = Join-Path 'C:\B\azure-powershell\src\Billing\test' 'Get-AzReservationDetail.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Get-AzReservationDetail' {
    It 'GetByDateRange' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
