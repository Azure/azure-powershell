$TestRecordingFile = Join-Path $PSScriptRoot 'Test-AzAppServiceCertificateOrderDomainOwnership.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Test-AzAppServiceCertificateOrderDomainOwnership' {
    It 'Verify' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'VerifyViaIdentity' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
