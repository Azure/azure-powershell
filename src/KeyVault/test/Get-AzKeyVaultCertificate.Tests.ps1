$TestRecordingFile = Join-Path $PSScriptRoot 'C:\B\azure-powershell\src\KeyVault\test' 'Get-AzKeyVaultCertificate.Recording.json'

. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Get-AzKeyVaultCertificate' {
    It 'ListAllVersions' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
