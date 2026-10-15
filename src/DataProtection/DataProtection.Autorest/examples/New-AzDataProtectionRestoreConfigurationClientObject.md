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

### Example 2: Create a RestoreConfiguration for restoring with AzureElasticSAN
```powershell
$restoreConfig = New-AzDataProtectionRestoreConfigurationClientObject -DatasourceType AzureElasticSAN -ResourceIdentifier @("source-vol1")
```

```output
ObjectType                         ResourceSelector
----------                         ----------------
GenericRestoreDatasourceCriteria   Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.ResourceListSelectionCriteria
```

This command creates a restore configuration client object for restoring an Azure Elastic SAN volume to an alternate volume group.
The service currently supports restoring exactly one volume per restore request, so ResourceIdentifier must contain a single source volume name.

### Example 3: Create a RestoreConfiguration for AzureElasticSAN with a target volume name override
```powershell
$restoreConfig = New-AzDataProtectionRestoreConfigurationClientObject -DatasourceType AzureElasticSAN -ResourceIdentifier @("source-vol1") -ResourceNameOverride @{"source-vol1" = "restored-vol1"}
```

```output
ObjectType                         ResourceSelector
----------                         ----------------
GenericRestoreDatasourceCriteria   Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.ResourceListSelectionCriteria
```

This command creates a restore configuration client object that restores the source volume into a renamed target volume using ResourceNameOverride.

### Example 4: Select Azure Cosmos DB databases and containers for item-level recovery
```powershell
$restoreConfig = New-AzDataProtectionRestoreConfigurationClientObject -DatasourceType AzureCosmosDB -ResourceIdentifier @('db1/col1','db1/col2','db2')
```

This command creates a restore configuration for Azure Cosmos DB item-level recovery (ILR). It selects containers `col1` and `col2` in database `db1`, and the whole database `db2`. Database-only and database/container selections can be mixed in one request. Pass this object to `Initialize-AzDataProtectionRestoreRequest` with `-SourceDataStore VaultStore -RestoreType AlternateLocation -ItemLevelRecovery -RestoreConfiguration $restoreConfig`.

Provide between 1 and 50 resource identifiers. Each identifier is a literal database name or a database/container name, not an Azure Resource Manager resource ID. Names are case-sensitive and their case is preserved; use the exact names from the backup. Exact duplicates, such as two `db1/col1` entries, and parent-child overlaps, such as `db1` together with `db1/col1`, are rejected.

These are literal names, not wildcard patterns or comma-separated lists. Punctuation allowed in Cosmos DB names, including braces, commas, and `*`, is not globally rejected or expanded. Quote each identifier as a separate string in the array; `/` separates the database and container names.

The target must be a pre-existing empty Azure Cosmos DB for NoSQL account different from the source account. Recovery uses `FailIfExists`; renaming with `-ResourceNameOverride` or `-RenameTo` is not supported for AzureCosmosDB.
