$TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzWebSiteClassicMobileServiceClassicMobileService.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Remove-AzWebSiteClassicMobileServiceClassicMobileService' {
    It 'Delete' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'DeleteViaIdentity' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
