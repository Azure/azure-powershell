$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzMetricNamespace.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Get-AzMetricNamespace' {
    It 'List' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
