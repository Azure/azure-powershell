$TestRecordingFile = Join-Path $PSScriptRoot 'New-AzOAuth2PermissionGrant.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'New-AzOAuth2PermissionGrant' {
    It 'CreateExpanded' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Create' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'CreateViaIdentityExpanded' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'CreateViaIdentity' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
