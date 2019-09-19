$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzAppServiceBillingMeter.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Get-AzAppServiceBillingMeter' {
    It 'List' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
