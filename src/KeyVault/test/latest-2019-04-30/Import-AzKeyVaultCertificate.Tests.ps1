$TestRecordingFile = Join-Path $PSScriptRoot 'Import-AzKeyVaultCertificate.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Import-AzKeyVaultCertificate' {
    It 'ImportExpanded' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Import' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'ImportViaIdentityExpanded' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'ImportViaIdentity' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
