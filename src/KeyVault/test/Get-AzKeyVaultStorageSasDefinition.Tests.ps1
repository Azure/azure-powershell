$TestRecordingFile = Join-Path $PSScriptRoot 'C:\B\azure-powershell\src\KeyVault\test' 'Get-AzKeyVaultStorageSasDefinition.Recording.json'

. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Get-AzKeyVaultStorageSasDefinition' {
    It 'Get' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'GetDeleted1' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'GetDeleted' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
