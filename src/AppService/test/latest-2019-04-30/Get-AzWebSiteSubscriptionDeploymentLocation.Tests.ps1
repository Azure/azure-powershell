$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzWebSiteSubscriptionDeploymentLocation.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Get-AzWebSiteSubscriptionDeploymentLocation' {
    It 'Get1' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'GetViaIdentity1' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
