$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'New-AzDataMigrationToSqlVM.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'New-AzDataMigrationToSqlVM' {
    It 'CreateExpanded' -skip {
        $filesharePassword = ConvertTo-SecureString $env.TestNewDatabaseMigrationVm.FileSharePassword -AsPlainText -Force
        $sourcePassword = ConvertTo-SecureString $env.TestNewDatabaseMigrationVm.SourceSqlConnectionPassword -AsPlainText -Force

        $instance = New-AzDataMigrationToSqlVM -ResourceGroupName $env.TestNewDatabaseMigrationVm.ResourceGroupName -SqlVirtualMachineName $env.TestNewDatabaseMigrationVm.SqlVirtualMachineName -TargetDbName $env.TestNewDatabaseMigrationVm.TargetDbName -Kind $env.TestNewDatabaseMigrationVm.Kind -Scope $env.TestNewDatabaseMigrationVm.Scope -MigrationService $env.TestNewDatabaseMigrationVm.MigrationService -StorageAccountResourceId $env.TestNewDatabaseMigrationVm.TargetLocationStorageAccountResourceId -StorageAccountKey $env.TestNewDatabaseMigrationVm.TargetLocationAccountKey -FileSharePath $env.TestNewDatabaseMigrationVm.FileSharePath  -FileShareUsername $env.TestNewDatabaseMigrationVm.FileShareUsername -FileSharePassword $filesharePassword -SourceSqlConnectionAuthentication $env.TestNewDatabaseMigrationVm.SourceSqlConnectionAuthentication -SourceSqlConnectionDataSource $env.TestNewDatabaseMigrationVm.SourceSqlConnectionDataSource -SourceSqlConnectionUserName $env.TestNewDatabaseMigrationVm.SourceSqlConnectionUsername -SourceSqlConnectionPassword $sourcePassword -SourceDatabaseName $env.TestNewDatabaseMigrationVm.SourceDatabaseName
        $assert = ($instance.Type -eq "Microsoft.DataMigration/databaseMigrations") -AND ($instance.Name -eq $env.TestNewDatabaseMigrationVm.TargetDbName) -AND ($instance.ProvisioningState -eq "Succeeded") -AND ($instance.Kind -eq "SqlVm")
        $assert | should be $true
    }
}
