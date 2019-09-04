$TestRecordingFile = Join-Path $PSScriptRoot 'Invoke-AzResendAppServiceCertificateOrderEmail.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Invoke-AzResendAppServiceCertificateOrderEmail' {
    It 'Resend' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'ResendViaIdentity' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
