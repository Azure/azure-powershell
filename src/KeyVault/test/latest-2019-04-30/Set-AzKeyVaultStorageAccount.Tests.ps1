$TestRecordingFile = Join-Path $PSScriptRoot 'Set-AzKeyVaultStorageAccount.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Set-AzKeyVaultStorageAccount' {
    It 'SetExpanded' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Set' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
