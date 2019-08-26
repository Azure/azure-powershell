$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzAppServicePublishingUser.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Get-AzAppServicePublishingUser' {
    It 'Get' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
