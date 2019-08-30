$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzBgpServiceCommunity.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Get-AzBgpServiceCommunity' {
    It 'List' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
