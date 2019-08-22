$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzOAuth2PermissionGrant.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Get-AzOAuth2PermissionGrant' {
    It 'List' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
