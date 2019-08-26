$TestRecordingFile = Join-Path $PSScriptRoot 'Invoke-AzAppServiceExecuteDiagnosticSiteDetectorSlot.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Invoke-AzAppServiceExecuteDiagnosticSiteDetectorSlot' {
    It 'Execute' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'ExecuteViaIdentity' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
