$TestRecordingFile = Join-Path 'C:\B\azure-powershell\src\KeyVault\test' 'Remove-AzKeyVaultCertificateContact.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Remove-AzKeyVaultCertificateContact' {
    It 'DeleteContact' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'DeleteAllContacts' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
