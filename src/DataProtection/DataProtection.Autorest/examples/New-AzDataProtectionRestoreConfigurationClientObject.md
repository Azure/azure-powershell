### Example 1: Create a RestoreConfiguration for restoring with AzureKubernetesService
```powershell
$restoreConfig = New-AzDataProtectionRestoreConfigurationClientObject -DatasourceType AzureKubernetesService -PersistentVolumeRestoreMode RestoreWithVolumeData -IncludeClusterScopeResource $true -NamespaceMapping  @{"sourcenamespace1"="targetnamespace1";"sourcenamespace2"="targetnamespace2"} -ExcludedNamespace "excludeNS1","excludeNS2" -RestoreHookReference @(@{name='restorehookname';namespace='default'},@{name='restorehookname1';namespace='hrweb'})
```

```output
ObjectType                       ConflictPolicy ExcludedNamespace        ExcludedResourceType IncludeClusterScopeResource IncludedNamespace IncludedResourceType LabelSelector PersistentVolumeRestoreMode
----------                       -------------- -----------------        -------------------- --------------------------- ----------------- -------------------- ------------- ---------------------------
KubernetesClusterRestoreCriteria Skip           {excludeNS1, excludeNS2}                      True                                                                             RestoreWithVolumeData
```

This command can be used to create a restore configuration client object used for Kubernetes cluster restore. RestoreHookReferences is a list of references to RestoreHooks that should be executed during restore.

### Example 2: Create a RestoreConfiguration for item level restore with AzureCosmosDB
```powershell
$restoreConfig = New-AzDataProtectionRestoreConfigurationClientObject -DatasourceType AzureCosmosDB -ResourceIdentifier @("db1/col1", "db1/col2", "db2")
```

This command creates a restore configuration client object for Azure Cosmos DB item level restore.
ResourceIdentifier lists database names or database/container names; this example selects containers col1 and col2 in database db1, and the whole database db2.
Pass this object to Initialize-AzDataProtectionRestoreRequest using the RestoreConfiguration parameter along with ItemLevelRecovery.
