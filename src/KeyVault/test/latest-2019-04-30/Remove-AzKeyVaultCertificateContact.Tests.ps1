$TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzKeyVaultCertificateContact.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Remove-AzKeyVaultCertificateContact' {
    It 'Delete' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
