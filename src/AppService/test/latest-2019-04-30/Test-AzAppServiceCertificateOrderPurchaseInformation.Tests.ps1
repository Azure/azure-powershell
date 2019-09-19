$TestRecordingFile = Join-Path $PSScriptRoot 'Test-AzAppServiceCertificateOrderPurchaseInformation.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Test-AzAppServiceCertificateOrderPurchaseInformation' {
    It 'ValidateExpanded' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Validate' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'ValidateViaIdentityExpanded' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'ValidateViaIdentity' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
