$TestRecordingFile = Join-Path $PSScriptRoot 'Invoke-AzWebSiteExecuteDiagnosticSiteAnalysis.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Invoke-AzWebSiteExecuteDiagnosticSiteAnalysis' {
    It 'Execute' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'ExecuteViaIdentity' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
