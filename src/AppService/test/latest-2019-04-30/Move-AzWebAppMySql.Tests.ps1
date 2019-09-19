$TestRecordingFile = Join-Path $PSScriptRoot 'Move-AzWebAppMySql.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Move-AzWebAppMySql' {
    It 'MigrateExpanded' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Migrate' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'MigrateViaIdentityExpanded' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'MigrateViaIdentity' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
