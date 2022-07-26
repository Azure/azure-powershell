### Example 1: Get Backup instance object for Azure Disk
```powershell
$policy = Get-AzDataProtectionBackupPolicy -SubscriptionId "xxxx-xxx-xxx" -ResourceGroupName sarath-rg -VaultName sarath-vault
$AzureDiskId = "/subscriptions/{subscription}/resourceGroups/{resourceGroup}/providers/Microsoft.Compute/disks/{diskname}"
$instance = Initialize-AzDataProtectionBackupInstance -DatasourceType AzureDisk -DatasourceLocation westus -DatasourceId $AzureDiskId -PolicyId $policy[0].Id
$instance.Property.PolicyInfo.PolicyParameter.DataStoreParametersList[0].ResourceGroupId = "/subscriptions/{subscription}/resourceGroups/{snapshotResourceGroup}"
$instance
```

```output
Name Type BackupInstanceName
---- ---- ------------------
          sarath-disk3-sarath-disk3-af697a80-e2bc-49f1-af6c-22f6c4d68405
```

The First command gets all the policies in a given vault. The second command stores azure disk's resource id in $AzureDiskId
variable. The third command returns a backup instance resource for Azure Disk. The fourth command sets the snapshot resource group field.
This object can now be used to configure backup for the given disk.

