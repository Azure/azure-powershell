### Example 1: Validate for modify backup instance operation
```powershell
$backupInstanceResource = Get-AzDataProtectionBackupInstance -ResourceGroupName $resourceGroupName -VaultName $vaultName -SubscriptionId $subscriptionId | Where-Object { $_.Name -match $backupInstanceName }
$backupInstanceResource.Property.PolicyInfo.PolicyId = $newPolicyARMId

Test-AzDataProtectionBackupInstanceUpdate -Name $backupInstanceResource.Name -ResourceGroupName $ResourceGroupName -VaultName $VaultName -SubscriptionId $SubscriptionId -BackupInstance $backupInstanceResource.Property
```

```output
ObjectType               JobId
----------               -----
OperationJobExtendedInfo
```

First command gets the backup instance resource and updates the policy id. Second command validates whether the update operation will be successful or not. If the output is coming as OperationJobExtendedInfo, then the update operation will be successful and can be continued with Update-AzDataProtectionBackupInstance cmdlet.
