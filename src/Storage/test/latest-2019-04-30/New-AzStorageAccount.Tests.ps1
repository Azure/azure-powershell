$TestRecordingFile = Join-Path $PSScriptRoot 'New-AzStorageAccount.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'New-AzStorageAccount' {
    It 'CreateExpandedStorageEncryption' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'CreateExpandedKeyVaultEncryption' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
