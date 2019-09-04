$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzKeyVaultSecret.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Get-AzKeyVaultSecret' {
    It 'Get1' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'GetViaIdentity' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Get' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'ListVersions' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'GetDeleted' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'GetDeleted1' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
