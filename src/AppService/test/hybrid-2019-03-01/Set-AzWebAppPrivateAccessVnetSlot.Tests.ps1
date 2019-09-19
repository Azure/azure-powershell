$TestRecordingFile = Join-Path $PSScriptRoot 'Set-AzWebAppPrivateAccessVnetSlot.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Set-AzWebAppPrivateAccessVnetSlot' {
    It 'PutExpanded' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Put' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
