$TestRecordingFile = Join-Path $PSScriptRoot 'Test-AzWebAppCustomHostname.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Test-AzWebAppCustomHostname' {
    It 'Analyze' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'AnalyzeViaIdentity' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
