$TestRecordingFile = Join-Path $PSScriptRoot 'C:\B\azure-powershell\src\KeyVault\test' 'Get-AzKeyVaultSecret.Recording.json'

. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Get-AzKeyVaultSecret' {
    It 'GetDeleted1' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'GetDeleted' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'ListAllVersions' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
