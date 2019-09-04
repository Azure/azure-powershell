$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzWebAppUsageSlot.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Get-AzWebAppUsageSlot' {
    It 'List' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
