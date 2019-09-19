$TestRecordingFile = Join-Path $PSScriptRoot 'Set-AzWebSiteGlobalSubscriptionPublishingCredentials.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Set-AzWebSiteGlobalSubscriptionPublishingCredentials' {
    It 'UpdateExpanded' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Update' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
