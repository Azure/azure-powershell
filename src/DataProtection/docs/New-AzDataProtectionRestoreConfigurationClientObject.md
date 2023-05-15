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
 [-PersistentVolumeRestoreMode <String>] [<CommonParameters>]
```

## DESCRIPTION
Creates new restore configuration object

## EXAMPLES

### Example 1: Create a RestoreConfiguration for restoring with AzureKubernetesService
```powershell
$restoreConfig = New-AzDataProtectionRestoreConfigurationClientObject -DatasourceType AzureKubernetesService -PersistentVolumeRestoreMode RestoreWithVolumeData -IncludeClusterScopeResource $true -NamespaceMapping  @{"sourcenamespace1"="targetnamespace1";"sourcenamespace2"="targetnamespace2"} -ExcludedNamespace "excludeNS1","excludeNS2"
```

```output
ObjectType                       ConflictPolicy ExcludedNamespace        ExcludedResourceType IncludeClusterScopeResource IncludedNamespace IncludedResourceType LabelSelector PersistentVolumeRestoreMode
----------                       -------------- -----------------        -------------------- --------------------------- ----------------- -------------------- ------------- ---------------------------
KubernetesClusterRestoreCriteria Skip           {excludeNS1, excludeNS2}                      True                                                                             RestoreWithVolumeData
```

This command can be used to create a restore configuration client object used for Kubernetes cluster restore

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
Type: System.Nullable`1[[System.Boolean, System.Private.CoreLib, Version=7.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e]]
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
Type: Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202301.KubernetesClusterRestoreCriteriaNamespaceMappings
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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### System.Management.Automation.PSObject

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


NAMESPACEMAPPING <KubernetesClusterRestoreCriteriaNamespaceMappings>: Namespaces mapping from source namespaces to target namespaces to resolve namespace naming conflicts in the target cluster.
  - `[(Any) <String>]`: This indicates any property can be added to this object.

## RELATED LINKS

