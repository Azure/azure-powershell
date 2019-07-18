$TestRecordingFile = Join-Path $PSScriptRoot 'C:\B\azure-powershell\src\KeyVault\test' 'Remove-AzKeyVaultSecret.Recording.json'

. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Remove-AzKeyVaultSecret' {
    It 'Purge' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
