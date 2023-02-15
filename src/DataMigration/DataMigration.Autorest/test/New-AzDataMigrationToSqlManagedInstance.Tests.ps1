$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'New-AzDataMigrationToSqlManagedInstance.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'New-AzDataMigrationToSqlManagedInstance' {
    It 'CreateExpanded' -skip  {
        $filesharePassword = ConvertTo-SecureString $env.TestNewDatabaseMigrationMi.FileSharePassword -AsPlainText -Force
        $sourcePassword = ConvertTo-SecureString $env.TestNewDatabaseMigrationMi.SourceSqlConnectionPassword -AsPlainText -Force

        $instance = New-AzDataMigrationToSqlManagedInstance -ResourceGroupName $env.TestNewDatabaseMigrationMi.ResourceGroupName -ManagedInstanceName $env.TestNewDatabaseMigrationMi.ManagedInstanceName -TargetDbName $env.TestNewDatabaseMigrationMi.TargetDbName -Kind $env.TestNewDatabaseMigrationMi.Kind -Scope $env.TestNewDatabaseMigrationMi.Scope -MigrationService $env.TestNewDatabaseMigrationMi.MigrationService -StorageAccountResourceId $env.TestNewDatabaseMigrationMi.TargetLocationStorageAccountResourceId -StorageAccountKey $env.TestNewDatabaseMigrationMi.TargetLocationAccountKey -FileSharePath $env.TestNewDatabaseMigrationMi.FileSharePath  -FileShareUsername $env.TestNewDatabaseMigrationMi.FileShareUsername -FileSharePassword $filesharePassword -SourceSqlConnectionAuthentication $env.TestNewDatabaseMigrationMi.SourceSqlConnectionAuthentication -SourceSqlConnectionDataSource $env.TestNewDatabaseMigrationMi.SourceSqlConnectionDataSource -SourceSqlConnectionUserName $env.TestNewDatabaseMigrationMi.SourceSqlConnectionUsername -SourceSqlConnectionPassword $sourcePassword -SourceDatabaseName $env.TestNewDatabaseMigrationMi.SourceDatabaseName
        $assert = ($instance.Type -eq "Microsoft.DataMigration/databaseMigrations") -AND ($instance.Name -eq $env.TestNewDatabaseMigrationMi.TargetDbName) -AND ($instance.ProvisioningState -eq "Succeeded") -AND ($instance.Kind -eq "SqlMi")
        $assert | should be $true
    }
}
