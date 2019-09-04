$TestRecordingFile = Join-Path $PSScriptRoot 'Test-AzWebSiteDomainAvailability.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Test-AzWebSiteDomainAvailability' {
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
