$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzWebAppSnapshot.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Get-AzWebAppSnapshot' {
    It 'List' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'ListSlot' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
