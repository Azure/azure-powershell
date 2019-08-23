$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzClassicAdministrator.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Get-AzClassicAdministrator' {
    It 'List' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
