$TestRecordingFile = Join-Path $PSScriptRoot 'Set-AzAppServicePublishingUser.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Set-AzAppServicePublishingUser' {
    It 'UpdateExpanded1' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Update1' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
