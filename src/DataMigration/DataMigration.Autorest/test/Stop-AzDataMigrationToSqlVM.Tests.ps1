$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Stop-AzDataMigrationToSqlVM.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Stop-AzDataMigrationToSqlVM' {
    It 'CancelExpanded' -skip {
        $filesharePassword = ConvertTo-SecureString $env.TestStopDatabaseMigrationVm.FileSharePassword -AsPlainText -Force
        $sourcePassword = ConvertTo-SecureString $env.TestStopDatabaseMigrationVm.SourceSqlConnectionPassword -AsPlainText -Force

        $instance = New-AzDataMigrationToSqlVM -ResourceGroupName $env.TestStopDatabaseMigrationVm.ResourceGroupName -SqlVirtualMachineName $env.TestStopDatabaseMigrationVm.SqlVirtualMachineName -TargetDbName $env.TestStopDatabaseMigrationVm.TargetDbName -Kind $env.TestStopDatabaseMigrationVm.Kind -Scope $env.TestStopDatabaseMigrationVm.Scope -MigrationService $env.TestStopDatabaseMigrationVm.MigrationService -StorageAccountResourceId $env.TestStopDatabaseMigrationVm.TargetLocationStorageAccountResourceId -StorageAccountKey $env.TestStopDatabaseMigrationVm.TargetLocationAccountKey -FileSharePath $env.TestStopDatabaseMigrationVm.FileSharePath  -FileShareUsername $env.TestStopDatabaseMigrationVm.FileShareUsername -FileSharePassword $filesharePassword -SourceSqlConnectionAuthentication $env.TestStopDatabaseMigrationVm.SourceSqlConnectionAuthentication -SourceSqlConnectionDataSource $env.TestStopDatabaseMigrationVm.SourceSqlConnectionDataSource -SourceSqlConnectionUserName $env.TestStopDatabaseMigrationVm.SourceSqlConnectionUsername -SourceSqlConnectionPassword $sourcePassword -SourceDatabaseName $env.TestStopDatabaseMigrationVm.SourceDatabaseName
        $details =  Get-AzDataMigrationToSqlVM  -SqlVirtualMachineName $env.TestStopDatabaseMigrationVm.SqlVirtualMachineName -ResourceGroupName $env.TestStopDatabaseMigrationVm.ResourceGroupName -TargetDbName $env.TestStopDatabaseMigrationVm.TargetDbName
        Stop-AzDataMigrationToSqlVM -MigrationOperationId $details.MigrationOperationId -SqlVirtualMachineName $env.TestStopDatabaseMigrationVm.SqlVirtualMachineName -ResourceGroupName $env.TestStopDatabaseMigrationVm.ResourceGroupName -TargetDbName $env.TestStopDatabaseMigrationVm.TargetDbName
        $details =  Get-AzDataMigrationToSqlVM  -SqlVirtualMachineName $env.TestStopDatabaseMigrationVm.SqlVirtualMachineName -ResourceGroupName $env.TestStopDatabaseMigrationVm.ResourceGroupName -TargetDbName $env.TestStopDatabaseMigrationVm.TargetDbName
        While($details.MigrationStatus -eq "Canceling")
        {
            $details =  Get-AzDataMigrationToSqlVM  -SqlVirtualMachineName $env.TestStopDatabaseMigrationVm.SqlVirtualMachineName -ResourceGroupName $env.TestStopDatabaseMigrationVm.ResourceGroupName -TargetDbName $env.TestStopDatabaseMigrationVm.TargetDbName
            
        }
        $assert = ($details.MigrationStatus -eq "Canceled") 
        $assert | should be $true
    }
}
