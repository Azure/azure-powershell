$TestRecordingFile = Join-Path $PSScriptRoot 'Invoke-AzRenewAppServiceCertificateOrder.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Invoke-AzRenewAppServiceCertificateOrder' {
    It 'RenewExpanded' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Renew' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'RenewViaIdentityExpanded' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'RenewViaIdentity' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
