### Example 1: Update blob backup instance vaulted policy and containers list
```powershell
$instance = Search-AzDataProtectionBackupInstanceInAzGraph -Subscription $subscriptionId -ResourceGroup $resourceGroupName -Vault $vaultName -DatasourceType AzureBlob
$updatePolicy = Get-AzDataProtectionBackupPolicy -SubscriptionId $subscriptionId -VaultName $vaultName -ResourceGroupName $resourceGroupName| Where-Object { $_.name -eq "vaulted-policy" }
$backedUpContainers = $instance.Property.PolicyInfo.PolicyParameter.BackupDatasourceParametersList[0].ContainersList
$updateBI = Update-AzDataProtectionBackupInstance -ResourceGroupName $resourceGroupName -VaultName $vaultName -BackupInstanceName $instance.Name -SubscriptionId $subscriptionId -PolicyId $updatePolicy.Id -VaultedBackupContainer $backedUpContainers[0,2,4]
$updateBI.Property.PolicyInfo.PolicyId
$updateBI.Property.PolicyInfo.PolicyParameter.BackupDatasourceParametersList[0].ContainersList
```

```output
/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/rgName/providers/Microsoft.DataProtection/backupVaults/vaultName/backupPolicies/vaulted-policy
updatedContainer1
updatedContainer2
updatedContainer3
```

First command fetch the backup instance which needs to be updated.
Second command gets the backup policy with name vaulted-policy which need to be updated in Backup Instance.
Third command fetches the list of vaulted containers which are currently backed up in the backup vault.
Fourth command update the backup instance with new policy and new list of container (which is currently a subset of the existing backed up containers).
Fifth and sixth command shows the updated policy and containers list in the backu instance.
