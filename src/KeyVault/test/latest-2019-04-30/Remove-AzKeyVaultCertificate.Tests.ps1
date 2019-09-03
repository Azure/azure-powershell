$TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzKeyVaultCertificate.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Remove-AzKeyVaultCertificate' {
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
