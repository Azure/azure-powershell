$TestRecordingFile = Join-Path $PSScriptRoot 'New-AzDiagnosticSetting.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'New-AzDiagnosticSetting' {
    It 'CreateExpanded' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
