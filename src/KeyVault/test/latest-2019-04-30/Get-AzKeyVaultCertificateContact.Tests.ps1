$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzKeyVaultCertificateContact.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Get-AzKeyVaultCertificateContact' {
    It 'Get' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
