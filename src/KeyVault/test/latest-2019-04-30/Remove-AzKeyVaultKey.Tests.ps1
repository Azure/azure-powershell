$TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzKeyVaultKey.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Remove-AzKeyVaultKey' {
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
