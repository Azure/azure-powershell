$TestRecordingFile = Join-Path $PSScriptRoot 'C:\B\azure-powershell\src\KeyVault\test' 'Remove-AzKeyVaultStorageAccount.Recording.json'

. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Remove-AzKeyVaultStorageAccount' {
    It 'Purge' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
