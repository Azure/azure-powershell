### Example 1: Create a BackupConfiguration for configuring protection with AzureKubernetesService
```powershell
$backupConfig = New-AzDataProtectionBackupConfigurationClientObject -SnapshotVolume $true -IncludeClusterScopeResource $true -DatasourceType AzureKubernetesService -LabelSelector "key=val","foo=bar" -ExcludedNamespace "excludeNS1","excludeNS2" -BackupHookReference @(@{name='bkphookname';namespace='default'},@{name='bkphookname1';namespace='hrweb'})
```

```output
ObjectType                                  ExcludedNamespace        ExcludedResourceType IncludeClusterScopeResource IncludedNamespace IncludedResourceType LabelSelector      SnapshotVolume
----------                                  -----------------        -------------------- --------------------------- ----------------- -------------------- -------------      --------------
KubernetesClusterBackupDatasourceParameters {excludeNS1, excludeNS2}                      True                                                               {key=val, foo=bar} True
```

This command can be used to create a backup configuration client object used for configuring backup for a Kubernetes cluster. BackupHookReferences is a list of references to BackupHooks that should be executed before and after the backup is executed.

### Example 2: Create a BackupConfiguration to select specific containers for configuring vaulted backups for AzureBlob. 
```powershell
$storageAccount = Get-AzStorageAccount -ResourceGroupName $resourceGroupName -Name $storageAccountName 
$containers=Get-AzStorageContainer -Context $storageAccount.Context        
$backupConfig = New-AzDataProtectionBackupConfigurationClientObject -DatasourceType AzureBlob -VaultedBackupContainer $containers.Name[1,3,4]
```

```output
ObjectType                     ContainersList
----------                     --------------
BlobBackupDatasourceParameters {conabb, conwxy, conzzz}
```

This command can be used to create a backup configuration client object used for configuring backup for vaulted Blob backup containers.

### Example 3: Create a BackupConfiguration for enabling auto-protection for AzureBlob.
```powershell
$backupConfig = New-AzDataProtectionBackupConfigurationClientObject -DatasourceType AzureBlob -AutoProtection
```

```output
ObjectType                                          AutoProtectionSettingEnabled AutoProtectionSettingObjectType
----------                                          --------------------------- ------------------------------
BlobBackupDatasourceParametersForAutoProtection      True                        BlobBackupRuleBasedAutoProtectionSettings
```

This command creates a backup configuration client object with auto-protection enabled for Azure Blob. When auto-protection is enabled, new containers will be automatically protected without requiring manual configuration.

### Example 4: Create a BackupConfiguration for enabling auto-protection for AzureDataLakeStorage with exclusion rules.
```powershell
$rule = [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20260301.BlobBackupAutoProtectionRule]::new()
$rule.ObjectType = "BlobBackupAutoProtectionRule"
$rule.Pattern = "logs-"
$backupConfig = New-AzDataProtectionBackupConfigurationClientObject -DatasourceType AzureDataLakeStorage -AutoProtection -AutoProtectionExclusionRule @($rule)
```

```output
ObjectType                                              AutoProtectionSettingEnabled AutoProtectionSettingObjectType
----------                                              --------------------------- ------------------------------
AdlsBlobBackupDatasourceParametersForAutoProtection      True                        BlobBackupRuleBasedAutoProtectionSettings
```

This command creates a backup configuration client object with auto-protection enabled for Azure Data Lake Storage. The exclusion rule excludes containers whose names match the prefix "logs-" from auto-protection.
