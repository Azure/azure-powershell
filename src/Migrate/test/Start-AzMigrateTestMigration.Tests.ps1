$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Start-AzMigrateTestMigration.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Start-AzMigrateTestMigration' {
    It 'ByNameVMwareCbt' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'ByIDVMwareCbt' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'ByInputObjectVMwareCbt' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
