$TestRecordingFile = Join-Path $PSScriptRoot 'Test-AzAppServiceMove.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Test-AzAppServiceMove' {
    It 'ValidateExpanded' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Validate' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'ValidateViaIdentityExpanded' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'ValidateViaIdentity' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
