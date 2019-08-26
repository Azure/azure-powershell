$TestRecordingFile = Join-Path $PSScriptRoot 'Set-AzAppServiceGlobalSubscriptionPublishingCredentials.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Set-AzAppServiceGlobalSubscriptionPublishingCredentials' {
    It 'UpdateExpanded' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Update' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
