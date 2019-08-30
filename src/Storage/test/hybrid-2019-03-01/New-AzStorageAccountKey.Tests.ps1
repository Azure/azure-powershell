$TestRecordingFile = Join-Path $PSScriptRoot 'New-AzStorageAccountKey.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'New-AzStorageAccountKey' {
    It 'RegenerateExpanded1' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Regenerate1' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'RegenerateViaIdentityExpanded1' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'RegenerateViaIdentity1' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
