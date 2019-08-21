$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzADUser.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Get-AzADUser' {
    It 'GetByFilter' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
