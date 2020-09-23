$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzMigrateJob.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Get-AzMigrateJob' {
    It 'ListByName' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'GetByName' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'GetByID' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'GetByInputObject' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'GetByInputObjectMigrationItem' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'ListById' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
