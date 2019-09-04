$TestRecordingFile = Join-Path $PSScriptRoot 'Export-AzLogAnalyticThrottledRequest.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Export-AzLogAnalyticThrottledRequest' {
    It 'ExportExpanded' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'ExportViaIdentityExpanded' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
