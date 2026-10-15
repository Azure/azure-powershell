---
external help file:
Module Name: Az.DataProtection
online version: https://learn.microsoft.com/powershell/module/az.dataprotection/new-azdataprotectionrestoreconfigurationclientobject
schema: 2.0.0
---

# New-AzDataProtectionRestoreConfigurationClientObject

## SYNOPSIS
Creates new restore configuration object

## SYNTAX

```
New-AzDataProtectionRestoreConfigurationClientObject -DatasourceType <DatasourceTypes>
 [-ConflictPolicy <String>] [-ExcludedNamespace <String[]>] [-ExcludedResourceType <String[]>]
 [-IncludeClusterScopeResource <Boolean?>] [-IncludedNamespace <String[]>] [-IncludedResourceType <String[]>]
 [-LabelSelector <String[]>] [-NamespaceMapping <KubernetesClusterRestoreCriteriaNamespaceMappings>]
 [-PersistentVolumeRestoreMode <String>] [-ResourceIdentifier <String[]>]
 [-ResourceModifierReference <NamespacedNameResource>] [-ResourceNameOverride <Hashtable>]
 [-RestoreHookReference <NamespacedNameResource[]>] [-StagingResourceGroupId <String>]
 [-StagingStorageAccountId <String>] [<CommonParameters>]
```

## DESCRIPTION
Creates new restore configuration object

## EXAMPLES

### Example 1: Create a RestoreConfiguration for restoring with AzureKubernetesService
```powershell
$restoreConfig = New-AzDataProtectionRestoreConfigurationClientObject -DatasourceType AzureKubernetesService -PersistentVolumeRestoreMode RestoreWithVolumeData -IncludeClusterScopeResource $true -NamespaceMapping  @{"sourcenamespace1"="targetnamespace1";"sourcenamespace2"="targetnamespace2"} -ExcludedNamespace "excludeNS1","excludeNS2" -RestoreHookReference @(@{name='restorehookname';namespace='default'},@{name='restorehookname1';namespace='hrweb'})
```

```output
ObjectType                       ConflictPolicy ExcludedNamespace        ExcludedResourceType IncludeClusterScopeResource IncludedNamespace IncludedResourceType LabelSelector PersistentVolumeRestoreMode
----------                       -------------- -----------------        -------------------- --------------------------- ----------------- -------------------- ------------- ---------------------------
KubernetesClusterRestoreCriteria Skip           {excludeNS1, excludeNS2}                      True                                                                             RestoreWithVolumeData
```

This command can be used to create a restore configuration client object used for Kubernetes cluster restore.
RestoreHookReferences is a list of references to RestoreHooks that should be executed during restore.

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

This command creates a restore configuration for Azure Cosmos DB item-level recovery (ILR).
It selects containers `col1` and `col2` in database `db1`, and the whole database `db2`.
Database-only and database/container selections can be mixed in one request.
Pass this object to `Initialize-AzDataProtectionRestoreRequest` with `-SourceDataStore VaultStore -RestoreType AlternateLocation -ItemLevelRecovery -RestoreConfiguration $restoreConfig`.

Provide between 1 and 50 resource identifiers.
Each identifier is a literal database name or a database/container name, not an Azure Resource Manager resource ID.
Names are case-sensitive and their case is preserved; use the exact names from the backup.
Exact duplicates, such as two `db1/col1` entries, and parent-child overlaps, such as `db1` together with `db1/col1`, are rejected.

These are literal names, not wildcard patterns or comma-separated lists.
Punctuation allowed in Cosmos DB names, including braces, commas, and `*`, is not globally rejected or expanded.
Quote each identifier as a separate string in the array; `/` separates the database and container names.

The target must be a pre-existing empty Azure Cosmos DB for NoSQL account different from the source account.
Recovery uses `FailIfExists`; renaming with `-ResourceNameOverride` or `-RenameTo` is not supported for AzureCosmosDB.

## PARAMETERS

### -ConflictPolicy
Conflict policy for restore.
Allowed values are Skip, Patch.
Default value is Skip

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DatasourceType
Datasource Type

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.DatasourceTypes
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ExcludedNamespace
List of namespaces to be excluded for restore

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ExcludedResourceType
List of resource types to be excluded for restore

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IncludeClusterScopeResource
Boolean parameter to decide whether cluster scope resources are included for restore.
By default this is taken as true.

```yaml
Type: System.Nullable`1[[System.Boolean, System.Private.CoreLib, Version=10.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e]]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IncludedNamespace
List of namespaces to be included for restore

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IncludedResourceType
List of resource types to be included for restore

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -LabelSelector
List of labels for internal filtering for restore

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NamespaceMapping
Namespaces mapping from source namespaces to target namespaces to resolve namespace naming conflicts in the target cluster.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.KubernetesClusterRestoreCriteriaNamespaceMappings
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PersistentVolumeRestoreMode
Restore mode for persistent volumes.
Allowed values are RestoreWithVolumeData, RestoreWithoutVolumeData.
Default value is RestoreWithVolumeData

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceIdentifier
Resources to restore.
For AzureCosmosDB, provide case-sensitive database or database/container names, with at most 50 entries and no duplicate or overlapping database/container selections.
For AzureElasticSAN, provide exactly one source volume name.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceModifierReference
Resource modifier reference to be executed during restore.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.NamespacedNameResource
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceNameOverride
Map of source volume name to target volume name to restore into.
Use this parameter for DatasourceType AzureElasticSAN.
Any source name not included will be restored with a default naming format.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RestoreHookReference
Hook reference to be executed during restore.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.NamespacedNameResource[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StagingResourceGroupId
Staging resource group Id for restore.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StagingStorageAccountId
Staging storage account Id for restore.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### System.Management.Automation.PSObject

## NOTES

## RELATED LINKS

