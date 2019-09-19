$TestRecordingFile = Join-Path $PSScriptRoot 'Merge-AzKeyVaultCertificate.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Merge-AzKeyVaultCertificate' {
    It 'MergeExpanded' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Merge' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'MergeViaIdentityExpanded' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'MergeViaIdentity' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
