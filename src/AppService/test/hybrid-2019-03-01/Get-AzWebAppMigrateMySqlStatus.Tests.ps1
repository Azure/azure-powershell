$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzWebAppMigrateMySqlStatus.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Get-AzWebAppMigrateMySqlStatus' {
    It 'Get' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'GetViaIdentity' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
