$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzAppServiceCertificateOrderSiteSeal.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Get-AzAppServiceCertificateOrderSiteSeal' {
    It 'RetrieveExpanded' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Retrieve' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'RetrieveViaIdentityExpanded' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'RetrieveViaIdentity' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
