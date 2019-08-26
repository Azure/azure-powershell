$TestRecordingFile = Join-Path $PSScriptRoot 'Move-AzWebAppStorage.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Move-AzWebAppStorage' {
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
