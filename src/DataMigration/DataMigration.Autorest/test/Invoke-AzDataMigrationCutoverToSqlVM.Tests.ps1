$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Invoke-AzDataMigrationCutoverToSqlVM.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Invoke-AzDataMigrationCutoverToSqlVM' {
    It 'CutoverExpanded'  -skip{
        $filesharePassword = ConvertTo-SecureString $env.TestCutDatabaseMigrationVm.FileSharePassword -AsPlainText -Force
        $sourcePassword = ConvertTo-SecureString $env.TestCutDatabaseMigrationVm.SourceSqlConnectionPassword -AsPlainText -Force

        $instance =  New-AzDataMigrationToSqlVM -ResourceGroupName $env.TestCutDatabaseMigrationVm.ResourceGroupName -SqlVirtualMachineName $env.TestCutDatabaseMigrationVm.SqlVirtualMachineName -TargetDbName $env.TestCutDatabaseMigrationVm.TargetDbName -Kind $env.TestCutDatabaseMigrationVm.Kind -Scope $env.TestCutDatabaseMigrationVm.Scope -MigrationService $env.TestCutDatabaseMigrationVm.MigrationService -StorageAccountResourceId $env.TestCutDatabaseMigrationVm.TargetLocationStorageAccountResourceId -StorageAccountKey $env.TestCutDatabaseMigrationVm.TargetLocationAccountKey -FileSharePath $env.TestCutDatabaseMigrationVm.FileSharePath  -FileShareUsername $env.TestCutDatabaseMigrationVm.FileShareUsername -FileSharePassword $filesharePassword -SourceSqlConnectionAuthentication $env.TestCutDatabaseMigrationVm.SourceSqlConnectionAuthentication -SourceSqlConnectionDataSource $env.TestCutDatabaseMigrationVm.SourceSqlConnectionDataSource -SourceSqlConnectionUserName $env.TestCutDatabaseMigrationVm.SourceSqlConnectionUsername -SourceSqlConnectionPassword $sourcePassword -SourceDatabaseName $env.TestCutDatabaseMigrationVm.SourceDatabaseName       
        $details =  Get-AzDataMigrationToSqlVM -SqlVirtualMachineName $env.TestCutDatabaseMigrationVm.SqlVirtualMachineName -ResourceGroupName $env.TestCutDatabaseMigrationVm.ResourceGroupName -TargetDbName $env.TestCutDatabaseMigrationVm.TargetDbName
        while(-Not $details.MigrationStatusDetail.IsFullBackupRestored){
            $details =  Get-AzDataMigrationToSqlVM -SqlVirtualMachineName $env.TestCutDatabaseMigrationVm.SqlVirtualMachineName -ResourceGroupName $env.TestCutDatabaseMigrationVm.ResourceGroupName -TargetDbName $env.TestCutDatabaseMigrationVm.TargetDbName
        }
        Invoke-AzDataMigrationCutoverToSqlVM -ResourceGroupName $env.TestCutatabaseMigrationVm.ResourceGroupName -ManagedInstanceName $env.TestCutDatabaseMigrationVm.ManagedInstanceName -TargetDbName  $instance.Name -MigrationOperationId $details.MigrationOperationId
        $details = Get-AzDataMigrationToSqlVM -ManagedInstanceName $env.TestCutDatabaseMigrationVm.ManagedInstanceName -ResourceGroupName $env.TestCutDatabaseMigrationVm.ResourceGroupName -TargetDbName $env.TestCutDatabaseMigrationVm.TargetDbName
        $assert = ($details.MigrationStatus -eq "Completing") -AND ($details.ProvisioningState -eq "Completing")
        $assert | should be $true
    }
}
