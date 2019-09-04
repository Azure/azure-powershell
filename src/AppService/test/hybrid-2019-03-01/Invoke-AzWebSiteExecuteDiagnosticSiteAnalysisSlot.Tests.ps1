$TestRecordingFile = Join-Path $PSScriptRoot 'Invoke-AzWebSiteExecuteDiagnosticSiteAnalysisSlot.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Invoke-AzWebSiteExecuteDiagnosticSiteAnalysisSlot' {
    It 'Execute' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'ExecuteViaIdentity' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
