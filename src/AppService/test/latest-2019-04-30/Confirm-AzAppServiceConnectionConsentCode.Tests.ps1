$TestRecordingFile = Join-Path $PSScriptRoot 'Confirm-AzAppServiceConnectionConsentCode.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Confirm-AzAppServiceConnectionConsentCode' {
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
