$TestRecordingFile = Join-Path $PSScriptRoot 'Test-AzAppServiceNameAvailability.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Test-AzAppServiceNameAvailability' {
    It 'CheckExpanded' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Check' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'CheckViaIdentityExpanded' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'CheckViaIdentity' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
