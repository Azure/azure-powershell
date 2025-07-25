$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Stop-AzDataMigrationToSqlManagedInstance.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Stop-AzDataMigrationToSqlManagedInstance' {
    It 'CancelExpanded' -skip {
        $filesharePassword = ConvertTo-SecureString $env.TestStopDatabaseMigrationMi.FileSharePassword -AsPlainText -Force
        $sourcePassword = ConvertTo-SecureString $env.TestStopDatabaseMigrationMi.SourceSqlConnectionPassword -AsPlainText -Force

        $instance = New-AzDataMigrationToSqlManagedInstance -ResourceGroupName $env.TestStopDatabaseMigrationMi.ResourceGroupName -ManagedInstanceName $env.TestStopDatabaseMigrationMi.ManagedInstanceName -TargetDbName $env.TestStopDatabaseMigrationMi.TargetDbName -Kind $env.TestStopDatabaseMigrationMi.Kind -Scope $env.TestStopDatabaseMigrationMi.Scope -MigrationService $env.TestStopDatabaseMigrationMi.MigrationService -StorageAccountResourceId $env.TestStopDatabaseMigrationMi.TargetLocationStorageAccountResourceId -StorageAccountKey $env.TestStopDatabaseMigrationMi.TargetLocationAccountKey -FileSharePath $env.TestStopDatabaseMigrationMi.FileSharePath  -FileShareUsername $env.TestStopDatabaseMigrationMi.FileShareUsername -FileSharePassword $filesharePassword -SourceSqlConnectionAuthentication $env.TestStopDatabaseMigrationMi.SourceSqlConnectionAuthentication -SourceSqlConnectionDataSource $env.TestStopDatabaseMigrationMi.SourceSqlConnectionDataSource -SourceSqlConnectionUserName $env.TestStopDatabaseMigrationMi.SourceSqlConnectionUsername -SourceSqlConnectionPassword $sourcePassword -SourceDatabaseName $env.TestStopDatabaseMigrationMi.SourceDatabaseName
        $details =  Get-AzDataMigrationToSqlManagedInstance -ManagedInstanceName $env.TestStopDatabaseMigrationMi.ManagedInstanceName -ResourceGroupName $env.TestStopDatabaseMigrationMi.ResourceGroupName -TargetDbName $env.TestStopDatabaseMigrationMi.TargetDbName
        Stop-AzDataMigrationToSqlManagedInstance -MigrationOperationId $details.MigrationOperationId -ManagedInstanceName $env.TestStopDatabaseMigrationMi.ManagedInstanceName -ResourceGroupName $env.TestStopDatabaseMigrationMi.ResourceGroupName -TargetDbName $env.TestStopDatabaseMigrationMi.TargetDbName
        $details =  Get-AzDataMigrationToSqlManagedInstance -ManagedInstanceName $env.TestStopDatabaseMigrationMi.ManagedInstanceName -ResourceGroupName $env.TestStopDatabaseMigrationMi.ResourceGroupName -TargetDbName $env.TestStopDatabaseMigrationMi.TargetDbName
        While($details.MigrationStatus -eq "Canceling")
        {
            $details =  Get-AzDataMigrationToSqlManagedInstance -ManagedInstanceName $env.TestStopDatabaseMigrationMi.ManagedInstanceName -ResourceGroupName $env.TestStopDatabaseMigrationMi.ResourceGroupName -TargetDbName $env.TestStopDatabaseMigrationMi.TargetDbName
            
        }
        $assert = ($details.MigrationStatus -eq "Canceled") 
        $assert | should be $true
    }
}
