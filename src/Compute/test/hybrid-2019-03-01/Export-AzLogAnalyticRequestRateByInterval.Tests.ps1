$TestRecordingFile = Join-Path $PSScriptRoot 'Export-AzLogAnalyticRequestRateByInterval.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Export-AzLogAnalyticRequestRateByInterval' {
    It 'ExportExpanded' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'ExportViaIdentityExpanded' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
