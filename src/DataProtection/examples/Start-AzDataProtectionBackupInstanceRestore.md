### Example 1: Trigger restore for a protected azure disk.
```powershell
PS C:\> $instance = Get-AzDataProtectionBackupInstance -SubscriptionId "xxxx-xxx-xxx" -ResourceGroupName "sarath-rg" -VaultName "sarath-vault"
PS C:\> $rp = Get-AzDataProtectionRecoveryPoint -SubscriptionId "xxx-xxx-xxx" -ResourceGroupName "sarath-rg" -VaultName "sarath-vault" -BackupInstanceName $instance.Name
PS C:\> $restoreRequest = Initialize-AzDataProtectionRestoreRequest -DatasourceType AzureDisk -SourceDataStore OperationalStore -RestoreLocation "westus"  -RestoreType AlternateLocation -TargetResourceId "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroup}/providers/Microsoft.Compute/disks/{DiskName}" -RecoveryPoint $rp[0].name
PS C:\> Start-AzDataProtectionBackupInstanceRestore -BackupInstanceName $instance.BackupInstanceName -ResourceGroupName sarath-rg -VaultName sarath-vault -SubscriptionId "xxx-xxx-xxx" -Parameter $restorerequest

```

### Example 2: Trigger restore as DB for protected AzureDatabaseForPostgreSQL using secret store.
```powershell
PS C:\> $instance = Get-AzDataProtectionBackupInstance -SubscriptionId "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx" -ResourceGroupName "resourceGroupName" -VaultName "vaultName"
PS C:\> $rp = Get-AzDataProtectionRecoveryPoint -SubscriptionId "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx" -ResourceGroupName "resourceGroupName" -VaultName "vaultName" -BackupInstanceName $instance.Name
PS C:\> $targetResourceId = "/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/resourceGroupName/providers/Microsoft.DBforPostgreSQL/servers/serverName/databases/targetDbName"
PS C:\> $secretURI = "https://oss-keyvault.vault.azure.net/secrets/oss-secret"
PS C:\> $restoreRequest = Initialize-AzDataProtectionRestoreRequest -DatasourceType AzureDatabaseForPostgreSQL -SourceDataStore VaultStore -RestoreLocation "westus" -RestoreType AlternateLocation -TargetResourceId $targetResourceId -RecoveryPoint $rp[0].Property.RecoveryPointId -SecretStoreURI $secretURI -SecretStoreType AzureKeyVault
PS C:\> $restoreJob = Start-AzDataProtectionBackupInstanceRestore -BackupInstanceName $instance.BackupInstanceName -ResourceGroupName resourceGroupName -VaultName vaultName -SubscriptionId "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx" -Parameter $restorerequest
PS C:\> $jobid = $restoreJob.JobId.Split("/")[-1]
PS C:\> $jobstatus = "InProgress"
PS C:\> while($jobstatus -ne "Completed")
{
    Start-Sleep -Seconds 10
    $currentjob = Get-AzDataProtectionJob -Id $jobid -SubscriptionId "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx" -ResourceGroupName "resourceGroupName" -VaultName "vaultName"
    $jobstatus = $currentjob.Status
}

```

The first, second commands fetch the instance and recovery point for the instance.
The third command initializes the $targetResourceId with the Id of target postgre database (targetDbName should be the new database name).
The fourth command initializes the secret URI.
The fifth, sixth command initializes and triggers the restore request for AzureDatabaseForPostgreSQL with secret store.
The seventh, eight, ninth  commands track the restore job to completion.

### Example 3: Trigger restore as Files for protected AzureDatabaseForPostgreSQL.
```powershell
PS C:\> $instance = Get-AzDataProtectionBackupInstance -SubscriptionId "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx" -ResourceGroupName "resourceGroupName" -VaultName "vaultName"
PS C:\> $rp = Get-AzDataProtectionRecoveryPoint -SubscriptionId "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx" -ResourceGroupName "resourceGroupName" -VaultName "vaultName" -BackupInstanceName $instance.Name
PS C:\> $targetContainerURI = ""https://targetStorageAccount.blob.core.windows.net/targetContainerName""
PS C:\> $fileNamePrefix = "restore_as_files_12345"
PS C:\> $restoreRequest = Initialize-AzDataProtectionRestoreRequest -DatasourceType AzureDatabaseForPostgreSQL -SourceDataStore VaultStore -RestoreLocation "westus" -RestoreType RestoreAsFiles -RecoveryPoint $rp[0].Property.RecoveryPointId -TargetContainerURI $targetContainerURI -FileNamePrefix $fileNamePrefix
PS C:\> $restoreJob = Start-AzDataProtectionBackupInstanceRestore -BackupInstanceName $instance.BackupInstanceName -ResourceGroupName resourceGroupName -VaultName vaultName -SubscriptionId "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx" -Parameter $restorerequest
PS C:\> $jobid = $restoreJob.JobId.Split("/")[-1]
PS C:\> $jobstatus = "InProgress"
PS C:\> while($jobstatus -ne "Completed")
{
    Start-Sleep -Seconds 10
    $currentjob = Get-AzDataProtectionJob -Id $jobid -SubscriptionId "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx" -ResourceGroupName "resourceGroupName" -VaultName "vaultName"
    $jobstatus = $currentjob.Status
}

```

The first, second commands fetch the instance and recovery point for the instance.
The third command initializes the $targetContainerURI with the Id of target storage account container.
The fourth command initializes the file name prefix for restore.
The fifth, sixth command initializes and triggers the restore request for AzureDatabaseForPostgreSQL with secret store.
The seventh, eight, ninth  commands track the restore job to completion.
