### Example 1: Test the backup instance 
```powershell
$vault = Get-AzDataProtectionBackupVault -ResourceGroupName "resourceGroupName" -VaultName "vaultName"
$diskBackupPolicy = Get-AzDataProtectionBackupPolicy -ResourceGroupName "resourceGroupName" -VaultName $vault.Name -Name "diskBackupPolicy"
$diskId = "/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourcegroups/rgName/providers/Microsoft.Compute/disks/test-disk" 
$snapshotRG = "/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/rgName"
$instance = Initialize-AzDataProtectionBackupInstance -SnapshotResourceGroupId $Snapshotrg -DatasourceType AzureDisk -DatasourceLocation $vault.Location -PolicyId $diskBackupPolicy[0].Id -DatasourceId $diskId 
Test-AzDataProtectionBackupInstanceReadiness -ResourceGroupName "resourceGroupName" -VaultName $vault.Name -BackupInstance  $instance[0].Property
```

The first command gets the backup vault. The second command gets the disk policy. Next we initialize $diskId and $snapshotRG variables with disk and snapshot ARM Ids. The fifth line runs the Initialize command to create a client side backup instance object. Finally we trigger the Test-AzDataProtectionBackupInstanceReadiness command to validate whether the backup instance is ready for configuring backup or not, the command will fail or pass accordingly. This command can be use to check whether the backup vault has all the necessary permissions to configure backup. 
