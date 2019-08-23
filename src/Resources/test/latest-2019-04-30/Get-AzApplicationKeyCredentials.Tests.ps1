$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzApplicationKeyCredentials.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Get-AzApplicationKeyCredentials' {
    It 'List' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
