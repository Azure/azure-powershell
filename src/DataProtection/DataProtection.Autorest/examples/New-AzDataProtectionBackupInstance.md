### Example 1: Configure backup of an azure disk in a backup vault.
```powershell
$sub = "xxxx-xxx-xx"
$DiskId = "/subscriptions/{subscription}/resourceGroups/{resourcegroup}/providers/Microsoft.Compute/disks/{diskname}"
$policy = Get-AzDataProtectionBackupPolicy -SubscriptionId $sub -ResourceGroupName sarath-rg -VaultName sarath-vault -Name "MyPolicy"
$instance = Initialize-AzDataProtectionBackupInstance -DatasourceType AzureDisk -DatasourceLocation $vault.Location -PolicyId $policy.Id -DatasourceId $DiskId 
$instance.Property.PolicyInfo.PolicyParameter.DataStoreParametersList[0].ResourceGroupId = "/subscriptions/{subscription}/resourceGroups/{resourceGroup}"
New-AzDataProtectionBackupInstance -SubscriptionId $sub -ResourceGroupName sarath-rg -VaultName sarath-vault -BackupInstance $instance
```

```output
Name                                                       Type                                                  BackupInstanceName
----                                                       ----                                                  ------------------
sarathdisk-sarathdisk-3df6ac08-9496-4839-8fb5-8b78e594f166 Microsoft.DataProtection/backupVaults/backupInstances sarathdisk-sarathdisk-3df6ac08-9496-4839-8fb5-8b78e594f166
```

The third command gets the policy with which disk will be backed up.
The fourth command initializes the backup instance request. The last command configures backup of the given azure disk in the backup vault.

### Example 2: Configure protection for AzureDatabaseForPostgreSQL database in a backup vault (using secret store authentication).
```powershell
$sub = "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx"
$dataSourceId = "/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/ResourceGroupName/providers/Microsoft.DBforPostgreSQL/servers/OssServerName/databases/DBName"
$secretURI = "https://oss-keyvault.vault.azure.net/secrets/oss-secret"
$vault = Get-AzDataProtectionBackupVault -SubscriptionId $sub -ResourceGroupName "ResourceGroupName"  -VaultName  $vaultName
$policy = Get-AzDataProtectionBackupPolicy -SubscriptionId $sub -ResourceGroupName "ResourceGroupName" -VaultName "vaultName" -Name "MyPolicy"
$instance = Initialize-AzDataProtectionBackupInstance -DatasourceType AzureDatabaseForPostgreSQL -DatasourceLocation $vault.Location -PolicyId $policy.Id -DatasourceId $dataSourceId -SecretStoreURI $secretURI -SecretStoreType AzureKeyVault
New-AzDataProtectionBackupInstance -SubscriptionId $sub -ResourceGroupName "ResourceGroupName" -VaultName "vaultName" -BackupInstance $instance
```

```output
Name                                                                Type                                                  BackupInstanceName
----                                                                ----                                                  ------------------
xyz-postgresql-wus-empdb10-xxxxxxxx-xxxx-xxxx-a3ba-be75108d8b21 Microsoft.DataProtection/backupVaults/backupInstances xyz-postgresql-wus-empdb10-xxxxxxxx-xxxx-xxxx-a3ba-be75108d8b21
```

The third command initializes the secretURI for secret store authentication. 
The fifth command gets the policy with which database will be protected.
The sixth command initializes the backup instance request object.
The last command configures backup of the given $dataSourceId in the backup vault.

### Example 3: Configure protection for AzureKubernetesService cluster in a backup vault
```powershell
$policy = Get-AzDataProtectionBackupPolicy -SubscriptionId "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx" -VaultName "vaultName" -ResourceGroupName "resourceGroupName" | where {$_.Name -eq "policyName"}
$sourceClusterId = "/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/resourceGroupName/providers/Microsoft.ContainerService/managedClusters/aks-cluster"
$snapshotResourceGroupId = "/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/resourceGroupName"
$backupConfig = New-AzDataProtectionBackupConfigurationClientObject -SnapshotVolume $true -IncludeClusterScopeResource $true -DatasourceType AzureKubernetesService -LabelSelector "x=y","foo=bar" 
$backupInstance = Initialize-AzDataProtectionBackupInstance -DatasourceType AzureKubernetesService  -DatasourceLocation "eastus" -PolicyId $policy.Id -DatasourceId $sourceClusterId -SnapshotResourceGroupId $snapshotResourceGroupId -FriendlyName "aks-cluster-friendlyName" -BackupConfiguration $backupConfig
Set-AzDataProtectionMSIPermission -BackupInstance $backupInstance -VaultResourceGroup "resourceGroupName" -VaultName "vaultName" -PermissionsScope "ResourceGroup"
$tag= @{"Owner"="BIOwnerName";"Foo"="Bar";"A"="B"}
$biCreate = New-AzDataProtectionBackupInstance -ResourceGroupName "ResourceGroupName" -VaultName "vaultName" -BackupInstance $backupInstance -SubscriptionId $sub -Tag $tag
$biCreate
```

```output
Name                                                                       BackupInstanceName
----                                                                       ------------------
aks-cluster-aks-cluster-117bd668-4t5h-4f3a-947c-ea71304cb4d7 aks-cluster-aks-cluster-117bd668-4t5h-4f3a-947c-ea71304cb4d7
```

The First command gets the AzureKubernetesService policy in a given vault. The second, third command initializes the AKS cluster and snapshot resource group Id.
The fourth command backup configuration object needed for AzureKubernetesService. The fifth command initializes the client object for backup instance.
The sixth command assigns the necessary permissions for configure backup. 
The sevnth and eight command initializes custom tags and configure backup finally by creating a backup instance.

### Example 4: Configure protection for AzureBlob with vault policy
```powershell
$vault = Get-AzDataProtectionBackupVault -SubscriptionId "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx" -ResourceGroupName "resourceGroupName" -VaultName "vaultName"
$pol = Get-AzDataProtectionBackupPolicy -SubscriptionId "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx" -VaultName "vaultName" -ResourceGroupName "resourceGroupName" | Where { $_.Name -match "vaultedPolicyName" }              
$backupConfig = New-AzDataProtectionBackupConfigurationClientObject -DatasourceType AzureBlob -IncludeAllContainer -StorageAccountResourceGroupName "resourceGroupName" -StorageAccountName "storageAcountName"
$backupInstanceClientObject = Initialize-AzDataProtectionBackupInstance -DatasourceType AzureBlob -DatasourceLocation $vault.Location -PolicyId $pol[0].Id -DatasourceId "storageAccId" -BackupConfiguration $backupConfig
Set-AzDataProtectionMSIPermission -VaultResourceGroup "resourceGroupName" -VaultName "vaultName" -BackupInstance $backupInstanceClientObject -PermissionsScope ResourceGroup
$operationResponse = Test-AzDataProtectionBackupInstanceReadiness -ResourceGroupName "resourceGroupName" -VaultName "vaultName" -SubscriptionId "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx" -BackupInstance $backupInstanceClientObject.Property -NoWait
$operationId = $operationResponse.Target.Split("/")[-1].Split("?")[0]
While((Get-AzDataProtectionOperationStatus -OperationId $operationId -Location $vault.Location -SubscriptionId "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx").Status -eq "Inprogress"){
    Start-Sleep -Seconds 10
}
$backupnstanceCreate = New-AzDataProtectionBackupInstance -ResourceGroupName "resourceGroupName" -VaultName "vaultName" -SubscriptionId "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx" -BackupInstance $backupInstanceClientObject
```

```output
Name                                                                 BackupInstanceName
----                                                                 ------------------
blobeuspstestsa-blobeuspstestsa-64f7399a-b024-4d61-8f16-c424c5fd2564 blobeuspstestsa-blobeuspstestsa-64f7399a-b024-4d61-8f16-c424c5fd2564
```

The first command gets the backup vault. The second command get the vaultedPolicy.
The third command defines a BackupConfiguration object so as to include all containers for vaulted backup. Check examples for New-AzDataProtectionBackupConfigurationClientObject cmdlet to see how to select specific containers for backup.
Th fourth command initializes the backup instance.
The fifth command assigns the necessary permissions for configure backup.
The sixth command validates if the backup instance object is valid for configure protection (validate backup). This command runs in async way using parameter -NoWait.
Next we fetch the operation in a while loop until it succeeds.
The last command is used to configure protection for the backup instance.
