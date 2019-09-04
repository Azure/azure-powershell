$TestRecordingFile = Join-Path $PSScriptRoot 'Confirm-AzWebSiteConnectionConsentCode.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Confirm-AzWebSiteConnectionConsentCode' {
    It 'ConfirmExpanded' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Confirm' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'ConfirmViaIdentityExpanded' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'ConfirmViaIdentity' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
