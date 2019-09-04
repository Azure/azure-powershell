$TestRecordingFile = Join-Path $PSScriptRoot 'Restore-AzKeyVaultCertificate.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Restore-AzKeyVaultCertificate' {
    It 'RestoreExpanded' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Restore' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
