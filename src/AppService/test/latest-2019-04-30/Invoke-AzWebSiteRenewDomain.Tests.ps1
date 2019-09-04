$TestRecordingFile = Join-Path $PSScriptRoot 'Invoke-AzWebSiteRenewDomain.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Invoke-AzWebSiteRenewDomain' {
    It 'Renew' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'RenewViaIdentity' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
