$TestRecordingFile = Join-Path $PSScriptRoot 'C:\B\azure-powershell\src\KeyVault\test' 'Remove-AzKeyVaultCertificate.Recording.json'

. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Remove-AzKeyVaultCertificate' {
    It 'Purge' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
