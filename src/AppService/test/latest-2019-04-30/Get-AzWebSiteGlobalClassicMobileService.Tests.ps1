$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzWebSiteGlobalClassicMobileService.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Get-AzWebSiteGlobalClassicMobileService' {
    It 'Get' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'GetViaIdentity' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
