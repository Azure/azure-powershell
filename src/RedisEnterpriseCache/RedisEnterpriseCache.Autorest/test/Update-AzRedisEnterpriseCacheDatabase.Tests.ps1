$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzRedisEnterpriseCacheDatabase.Recording.json'

Describe 'Update-AzRedisEnterpriseCacheDatabase' {
    It 'Uses read-modify-write via PUT for database updates' {
        $customCmdletPath = Join-Path $PSScriptRoot '..\custom\Update-AzRedisEnterpriseCacheDatabase.ps1'
        $customCmdlet = Get-Content -Path $customCmdletPath -Raw

        $customCmdlet | Should -Match 'Get-AzRedisEnterpriseCacheDatabase'
        $customCmdlet | Should -Match 'New-AzRedisEnterpriseCacheDatabase'
        $customCmdlet | Should -Not -Match 'internal\\Update-AzRedisEnterpriseCacheDatabase'
    }

    It 'UpdateExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'UpdateViaIdentityExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
