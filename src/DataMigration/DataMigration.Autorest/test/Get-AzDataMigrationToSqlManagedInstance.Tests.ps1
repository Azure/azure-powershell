$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzDataMigrationToSqlManagedInstance.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Get-AzDataMigrationToSqlManagedInstance' {
    It 'Get' -skip {
        $instance = Get-AzDataMigrationToSqlManagedInstance -ManagedInstanceName $env.TestDatabaseMigrationMi.ManagedInstanceName -ResourceGroupName $env.TestDatabaseMigrationMi.ResourceGroupName -TargetDbName $env.TestDatabaseMigrationMi.TargetDbName
        $assert = ($instance.Name -eq $env.TestDatabaseMigrationMi.TargetDbName) -AND ($instance.Kind -eq 'SqlMi')
        $assert | Should be $true
    }

    It 'GetViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
