$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzWebSitePublishingUser.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Get-AzWebSitePublishingUser' {
    It 'Get' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
