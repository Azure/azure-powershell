$TestRecordingFile = Join-Path $PSScriptRoot 'New-AzKeyVaultStorageAccountKey.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'New-AzKeyVaultStorageAccountKey' {
    It 'RegenerateExpanded' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Regenerate' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'RegenerateViaIdentityExpanded' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'RegenerateViaIdentity' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
