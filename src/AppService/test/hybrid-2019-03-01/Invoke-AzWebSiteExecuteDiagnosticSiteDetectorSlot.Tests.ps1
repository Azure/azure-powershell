$TestRecordingFile = Join-Path $PSScriptRoot 'Invoke-AzWebSiteExecuteDiagnosticSiteDetectorSlot.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Invoke-AzWebSiteExecuteDiagnosticSiteDetectorSlot' {
    It 'Execute' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'ExecuteViaIdentity' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
