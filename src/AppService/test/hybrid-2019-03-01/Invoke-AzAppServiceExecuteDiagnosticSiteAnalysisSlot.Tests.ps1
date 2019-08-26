$TestRecordingFile = Join-Path $PSScriptRoot 'Invoke-AzAppServiceExecuteDiagnosticSiteAnalysisSlot.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Invoke-AzAppServiceExecuteDiagnosticSiteAnalysisSlot' {
    It 'Execute' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'ExecuteViaIdentity' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
