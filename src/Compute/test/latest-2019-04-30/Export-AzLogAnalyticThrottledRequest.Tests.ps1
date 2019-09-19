$TestRecordingFile = Join-Path $PSScriptRoot 'Export-AzLogAnalyticThrottledRequest.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Export-AzLogAnalyticThrottledRequest' {
    It 'ExportExpanded1' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'ExportViaIdentityExpanded1' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
