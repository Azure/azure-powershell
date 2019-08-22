$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzApplicationPasswordCredentials.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Get-AzApplicationPasswordCredentials' {
    It 'List' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
