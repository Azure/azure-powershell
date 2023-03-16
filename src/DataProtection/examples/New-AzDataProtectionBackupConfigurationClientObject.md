### Example 1: Create a BackupConfiguration for configuring protection with AzureKubernetesService
```powershell
$backupConfig = New-AzDataProtectionBackupConfigurationClientObject -SnapshotVolume $true -IncludeClusterScopeResource $true -DatasourceType AzureKubernetesService -LabelSelector "key=val","foo=bar" -ExcludedNamespace "excludeNS1","excludeNS2"
```

```output
ObjectType                                  ExcludedNamespace        ExcludedResourceType IncludeClusterScopeResource IncludedNamespace IncludedResourceType LabelSelector      SnapshotVolume
----------                                  -----------------        -------------------- --------------------------- ----------------- -------------------- -------------      --------------
KubernetesClusterBackupDatasourceParameters {excludeNS1, excludeNS2}                      True                                                               {key=val, foo=bar} True
```

This command can be used to create a backup configuration client object used for configuring backup for a Kubernetes cluster

