$TestRecordingFile = Join-Path $PSScriptRoot 'Test-AzAppService.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Test-AzAppService' {
    It 'ValidateExpanded1' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Validate1' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'ValidateViaIdentityExpanded1' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'ValidateViaIdentity1' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
