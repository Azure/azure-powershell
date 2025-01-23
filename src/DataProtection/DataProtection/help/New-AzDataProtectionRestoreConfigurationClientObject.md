---
external help file: Az.DataProtection-help.xml
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
 [-ExcludedResourceType <String[]>] [-IncludedResourceType <String[]>] [-ExcludedNamespace <String[]>]
 [-IncludedNamespace <String[]>] [-LabelSelector <String[]>] [-IncludeClusterScopeResource <Boolean>]
 [-ConflictPolicy <String>] [-NamespaceMapping <KubernetesClusterRestoreCriteriaNamespaceMappings>]
 [-PersistentVolumeRestoreMode <String>] [-RestoreHookReference <NamespacedNameResource[]>]
 [-ResourceModifierReference <NamespacedNameResource>] [-StagingResourceGroupId <String>]
 [-StagingStorageAccountId <String>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
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
Accepted values: AzureDisk, AzureBlob, AzureDatabaseForPostgreSQL, AzureKubernetesService, AzureDatabaseForPGFlexServer, AzureDatabaseForMySQL

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
Type: System.Nullable`1[System.Boolean]
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
To construct, see NOTES section for NAMESPACEMAPPING properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20240401.KubernetesClusterRestoreCriteriaNamespaceMappings
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

### -ProgressAction
{{ Fill ProgressAction Description }}

```yaml
Type: System.Management.Automation.ActionPreference
Parameter Sets: (All)
Aliases: proga

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceModifierReference
Resource modifier reference to be executed during restore.
To construct, see NOTES section for RESOURCEMODIFIERREFERENCE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20240401.NamespacedNameResource
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
To construct, see NOTES section for RESTOREHOOKREFERENCE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20240401.NamespacedNameResource[]
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
