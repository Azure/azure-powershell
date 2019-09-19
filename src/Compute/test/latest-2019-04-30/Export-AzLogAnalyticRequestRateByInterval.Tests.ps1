$TestRecordingFile = Join-Path $PSScriptRoot 'Export-AzLogAnalyticRequestRateByInterval.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Export-AzLogAnalyticRequestRateByInterval' {
    It 'ExportExpanded1' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'ExportViaIdentityExpanded1' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
