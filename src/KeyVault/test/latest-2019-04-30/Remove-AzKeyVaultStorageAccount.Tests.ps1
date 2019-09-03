$TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzKeyVaultStorageAccount.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Remove-AzKeyVaultStorageAccount' {
    It 'Delete' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'DeleteViaIdentity' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Purge' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
