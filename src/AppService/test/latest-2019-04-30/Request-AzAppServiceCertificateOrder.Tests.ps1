$TestRecordingFile = Join-Path $PSScriptRoot 'Request-AzAppServiceCertificateOrder.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Request-AzAppServiceCertificateOrder' {
    It 'RequestExpanded' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Request' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'RequestViaIdentityExpanded' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'RequestViaIdentity' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
