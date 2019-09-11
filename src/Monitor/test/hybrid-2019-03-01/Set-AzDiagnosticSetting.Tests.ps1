$TestRecordingFile = Join-Path $PSScriptRoot 'Set-AzDiagnosticSetting.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Set-AzDiagnosticSetting' {
    It 'UpdateExpanded' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
