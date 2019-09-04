$TestRecordingFile = Join-Path $PSScriptRoot 'Set-AzWebSitePublishingUser.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Set-AzWebSitePublishingUser' {
    It 'UpdateExpanded1' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Update1' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
