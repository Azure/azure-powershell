$TestRecordingFile = Join-Path $PSScriptRoot 'C:\B\azure-powershell\src\KeyVault\test' 'Remove-AzKeyVaultKey.Recording.json'

. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Remove-AzKeyVaultKey' {
    It 'Purge' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
