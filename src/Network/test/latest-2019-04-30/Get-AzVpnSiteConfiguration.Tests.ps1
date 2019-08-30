$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzVpnSiteConfiguration.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Get-AzVpnSiteConfiguration' {
    It 'DownloadExpanded' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Download' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'DownloadViaIdentityExpanded' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'DownloadViaIdentity' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
