### Example 1: Test the backup instance object for restore operation
```powershell
    $instances  = Get-AzDataProtectionBackupInstance -Subscription "subscription/xxxxx-xxxxx-xxx" -ResourceGroup "myrg" -Vault "Myvault" 
    $pointInTimeRange = Find-AzDataProtectionRestorableTimeRange -BackupInstanceName $instances[0].BackupInstanceName -ResourceGroupName "myrg" -SubscriptionId "subscription/xxxxx-xxxxx-xxx"" -VaultName "myvault" -SourceDataStoreType OperationalStore -StartTime (Get-Date).AddDays(-30).ToString("yyyy-MM-ddTHH:mm:ss.0000000Z") -EndTime (Get-Date).AddDays(0).ToString("yyyy-MM-ddTHH:mm:ss.0000000Z")
	$vault = Get-AzDataProtectionBackupVault -ResourceGroupName "myrg" -SubscriptionId "subscription/xxxxx-xxxxx-xxx" -VaultName "Myvault"
	$RestoreRequestObject = Initialize-AzDataProtectionRestoreRequest -DatasourceType AzureBlob -SourceDataStore OperationalStore -RestoreLocation $vault.Location -RestoreType OriginalLocation -BackupInstance $instances[0] -PointInTime (Get-Date -Date $pointInTimeRange.RestorableTimeRange.EndTime)

	Test-AzDataProtectionBackupInstanceRestore -InputObject $instances[0] -Parameter $RestoreRequestObject
``` 

The command tests the backup instance object for restore options


