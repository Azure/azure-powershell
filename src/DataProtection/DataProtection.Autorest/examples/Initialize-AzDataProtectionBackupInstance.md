### Example 1: Initialize Backup instance object for Azure Disk
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

### Example 2: Initialize Backup instance object for AzureKubernetesService
```powershell
$policy = Get-AzDataProtectionBackupPolicy -SubscriptionId "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx" -VaultName "vaultName" -ResourceGroupName "resourceGroupName" | where {$_.Name -eq "policyName"}
$sourceClusterId = "/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/resourceGroupName/providers/Microsoft.ContainerService/managedClusters/aks-cluster"
$snapshotResourceGroupId = "/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/resourceGroupName"
$backupConfig = New-AzDataProtectionBackupConfigurationClientObject -SnapshotVolume $true -IncludeClusterScopeResource $true -DatasourceType AzureKubernetesService -LabelSelector "x=y","foo=bar" 
$backupInstance = Initialize-AzDataProtectionBackupInstance -DatasourceType AzureKubernetesService  -DatasourceLocation "eastus" -PolicyId $policy.Id -DatasourceId $sourceClusterId -SnapshotResourceGroupId $snapshotResourceGroupId -FriendlyName "aks-cluster-friendlyName" -BackupConfiguration $backupConfig
$instance
```

```output
Name BackupInstanceName
---- ------------------
     aks-cluster-aks-cluster-ed68435e-069t-4b4a-9d84-d0c194800fc2
```

The First command gets the AzureKubernetesService policy in a given vault. The second, third command initializes the AKS cluster and snapshot resource group Id.
The fourth command backup configuration object needed for AzureKubernetesService. The fifth command initializes the client object for backup instance.
This object can now be used to configure backup using New-AzDataProtectionBackupInstance after all necessary permissions are assigned with Set-AzDataProtectionMSIPermission command.
