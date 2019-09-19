$TestRecordingFile = Join-Path $PSScriptRoot 'Test-AzWebAppCustomHostnameSlot.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Test-AzWebAppCustomHostnameSlot' {
    It 'Analyze' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'AnalyzeViaIdentity' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
