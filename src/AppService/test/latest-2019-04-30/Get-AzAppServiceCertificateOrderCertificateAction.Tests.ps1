$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzAppServiceCertificateOrderCertificateAction.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Get-AzAppServiceCertificateOrderCertificateAction' {
    It 'Retrieve' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'RetrieveViaIdentity' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
