$TestRecordingFile = Join-Path $PSScriptRoot 'Test-AzStorageAccountNameAvailability.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Test-AzStorageAccountNameAvailability' {
    It 'CheckExpanded1' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Check1' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'CheckViaIdentityExpanded1' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'CheckViaIdentity1' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
