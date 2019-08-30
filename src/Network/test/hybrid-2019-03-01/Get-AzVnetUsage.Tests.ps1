$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzVnetUsage.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Get-AzVnetUsage' {
    It 'List1' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
