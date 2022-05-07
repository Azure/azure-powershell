$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Invoke-AzDataMigrationCutoverToSqlManagedInstance.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Invoke-AzDataMigrationCutoverToSqlManagedInstance' {
    It 'CutoverExpanded' -skip  {
        $filesharePassword = ConvertTo-SecureString $env.TestCutDatabaseMigrationMi.FileSharePassword -AsPlainText -Force
        $sourcePassword = ConvertTo-SecureString $env.TestCutDatabaseMigrationMi.SourceSqlConnectionPassword -AsPlainText -Force

        $instance =  New-AzDataMigrationToSqlManagedInstance -ResourceGroupName $env.TestCutDatabaseMigrationMi.ResourceGroupName -ManagedInstanceName $env.TestCutDatabaseMigrationMi.ManagedInstanceName -TargetDbName $env.TestCutDatabaseMigrationMi.TargetDbName -Kind $env.TestCutDatabaseMigrationMi.Kind -Scope $env.TestCutDatabaseMigrationMi.Scope -MigrationService $env.TestCutDatabaseMigrationMi.MigrationService -StorageAccountResourceId $env.TestCutDatabaseMigrationMi.TargetLocationStorageAccountResourceId -StorageAccountKey $env.TestCutDatabaseMigrationMi.TargetLocationAccountKey -FileSharePath $env.TestCutDatabaseMigrationMi.FileSharePath  -FileShareUsername $env.TestCutDatabaseMigrationMi.FileShareUsername -FileSharePassword $filesharePassword -SourceSqlConnectionAuthentication $env.TestCutDatabaseMigrationMi.SourceSqlConnectionAuthentication -SourceSqlConnectionDataSource $env.TestCutDatabaseMigrationMi.SourceSqlConnectionDataSource -SourceSqlConnectionUserName $env.TestCutDatabaseMigrationMi.SourceSqlConnectionUsername -SourceSqlConnectionPassword $sourcePassword -SourceDatabaseName $env.TestCutDatabaseMigrationMi.SourceDatabaseName       
        $details =  Get-AzDataMigrationToSqlManagedInstance -ManagedInstanceName $env.TestCutDatabaseMigrationMi.ManagedInstanceName -ResourceGroupName $env.TestCutDatabaseMigrationMi.ResourceGroupName -TargetDbName $env.TestCutDatabaseMigrationMi.TargetDbName
        while(-Not $details.MigrationStatusDetail.IsFullBackupRestored){
            $details =  Get-AzDataMigrationToSqlManagedInstance -ManagedInstanceName $env.TestCutDatabaseMigrationMi.ManagedInstanceName -ResourceGroupName $env.TestCutDatabaseMigrationMi.ResourceGroupName -TargetDbName $env.TestCutDatabaseMigrationMi.TargetDbName
        }
        Invoke-AzDataMigrationCutoverToSqlManagedInstance -ResourceGroupName $env.TestCutatabaseMigrationMi.ResourceGroupName -ManagedInstanceName $env.TestCutDatabaseMigrationMi.ManagedInstanceName -TargetDbName  $instance.Name -MigrationOperationId $details.MigrationOperationId
        $details =  Get-AzDataMigrationToSqlManagedInstance -ManagedInstanceName $env.TestCutDatabaseMigrationMi.ManagedInstanceName -ResourceGroupName $env.TestCutDatabaseMigrationMi.ResourceGroupName -TargetDbName $env.TestCutDatabaseMigrationMi.TargetDbName
        $assert = ($details.MigrationStatus -eq "Completing") -AND ($details.ProvisioningState -eq "Completing")
        $assert | should be $true
    }
}
