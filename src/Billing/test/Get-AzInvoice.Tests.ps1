$TestRecordingFile = Join-Path 'C:\B\azure-powershell\src\Billing\test' 'Get-AzInvoice.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Get-AzInvoice' {
    It 'GetLatest' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
