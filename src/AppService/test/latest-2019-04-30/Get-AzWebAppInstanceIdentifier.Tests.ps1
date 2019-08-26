$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzWebAppInstanceIdentifier.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Get-AzWebAppInstanceIdentifier' {
    It 'List' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
