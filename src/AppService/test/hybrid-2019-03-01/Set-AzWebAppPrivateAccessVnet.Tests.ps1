$TestRecordingFile = Join-Path $PSScriptRoot 'Set-AzWebAppPrivateAccessVnet.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Set-AzWebAppPrivateAccessVnet' {
    It 'PutExpanded' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Put' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
