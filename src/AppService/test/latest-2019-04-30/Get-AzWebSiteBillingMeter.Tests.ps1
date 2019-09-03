$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzWebSiteBillingMeter.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Get-AzWebSiteBillingMeter' {
    It 'List' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
