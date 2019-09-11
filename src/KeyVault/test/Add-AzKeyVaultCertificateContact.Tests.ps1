$TestRecordingFile = Join-Path 'C:\B\azure-powershell\src\KeyVault\test' 'Add-AzKeyVaultCertificateContact.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Add-AzKeyVaultCertificateContact' {
    It 'Add' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
