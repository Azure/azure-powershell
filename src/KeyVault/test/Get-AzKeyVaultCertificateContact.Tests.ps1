$TestRecordingFile = Join-Path 'C:\B\azure-powershell\src\KeyVault\test' 'Get-AzKeyVaultCertificateContact.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Get-AzKeyVaultCertificateContact' {
    It 'List' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
