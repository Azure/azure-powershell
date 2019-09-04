$TestRecordingFile = Join-Path 'C:\B\azure-powershell\src\KeyVault\test' 'Undo-AzKeyVaultRemoval.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Undo-AzKeyVaultRemoval' {
    It 'Undo' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
