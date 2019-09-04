$TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzOAuth2PermissionGrant.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Remove-AzOAuth2PermissionGrant' {
    It 'Delete' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'DeleteViaIdentity' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
