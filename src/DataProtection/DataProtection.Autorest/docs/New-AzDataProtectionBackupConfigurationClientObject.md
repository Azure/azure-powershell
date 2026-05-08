---
external help file:
Module Name: Az.DataProtection
online version: https://learn.microsoft.com/powershell/module/az.dataprotection/new-azdataprotectionbackupconfigurationclientobject
schema: 2.0.0
---

# New-AzDataProtectionBackupConfigurationClientObject

## SYNOPSIS
Creates new backup configuration object

## SYNTAX

```
New-AzDataProtectionBackupConfigurationClientObject -DatasourceType <DatasourceTypes> [-AutoProtection]
 [-AutoProtectionExclusionRule <IBlobBackupAutoProtectionRule[]>]
 [-BackupHookReference <NamespacedNameResource[]>] [-ExcludedNamespace <String[]>]
 [-ExcludedResourceType <String[]>] [-IncludeAllContainer] [-IncludeClusterScopeResource <Boolean?>]
 [-IncludedNamespace <String[]>] [-IncludedResourceType <String[]>] [-LabelSelector <String[]>]
 [-SnapshotVolume <Boolean?>] [-StorageAccountName <String>] [-StorageAccountResourceGroupName <String>]
 [-VaultedBackupContainer <String[]>] [<CommonParameters>]
```

## DESCRIPTION
Creates new backup configuration object

## EXAMPLES

### Example 1: Create a BackupConfiguration for configuring protection with AzureKubernetesService
```powershell
$backupConfig = New-AzDataProtectionBackupConfigurationClientObject -SnapshotVolume $true -IncludeClusterScopeResource $true -DatasourceType AzureKubernetesService -LabelSelector "key=val","foo=bar" -ExcludedNamespace "excludeNS1","excludeNS2" -BackupHookReference @(@{name='bkphookname';namespace='default'},@{name='bkphookname1';namespace='hrweb'})
```

```output
ObjectType                                  ExcludedNamespace        ExcludedResourceType IncludeClusterScopeResource IncludedNamespace IncludedResourceType LabelSelector      SnapshotVolume
----------                                  -----------------        -------------------- --------------------------- ----------------- -------------------- -------------      --------------
KubernetesClusterBackupDatasourceParameters {excludeNS1, excludeNS2}                      True                                                               {key=val, foo=bar} True
```

This command can be used to create a backup configuration client object used for configuring backup for a Kubernetes cluster.
BackupHookReferences is a list of references to BackupHooks that should be executed before and after the backup is executed.

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

This command creates a backup configuration client object with auto-protection enabled for Azure Blob.
When auto-protection is enabled, new containers will be automatically protected without requiring manual configuration.

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

This command creates a backup configuration client object with auto-protection enabled for Azure Data Lake Storage.
The exclusion rule excludes containers whose names match the prefix "logs-" from auto-protection.

## PARAMETERS

### -AutoProtection
Switch parameter to enable auto-protection.
When enabled, new containers matching the rules will be automatically protected.
Use this parameter for DatasourceType AzureBlob or AzureDataLakeStorage.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AutoProtectionExclusionRule
List of auto-protection exclusion rules.
Each rule is a BlobBackupAutoProtectionRule object specifying container name prefix patterns to exclude.
Use this parameter along with -AutoProtection.
To construct, see NOTES section for AUTOPROTECTIONEXCLUSIONRULE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20260301.IBlobBackupAutoProtectionRule[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -BackupHookReference
Hook reference to be executed during backup.
To construct, see NOTES section for BACKUPHOOKREFERENCE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20260301.NamespacedNameResource[]
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
List of namespaces to be excluded from backup

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
List of resource types to be excluded from backup

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

### -IncludeAllContainer
Switch parameter to include all containers to be backed up inside the VaultStore.
Use this parameter for DatasourceType AzureBlob.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IncludeClusterScopeResource
Boolean parameter to decide whether cluster scope resources are included for backup.
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
List of namespaces to be included for backup

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
List of resource types to be included for backup

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
List of labels for internal filtering for backup

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

### -SnapshotVolume
Boolean parameter to decide whether snapshot volumes are included for backup.
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

### -StorageAccountName
Storage account where the Datasource is present.
Use this parameter for DatasourceType AzureBlob.

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

### -StorageAccountResourceGroupName
Storage account resource group name where the Datasource is present.
Use this parameter for DatasourceType AzureBlob.

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

### -VaultedBackupContainer
List of containers to be backed up inside the VaultStore.
Use this parameter for DatasourceType AzureBlob.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### System.Management.Automation.PSObject

## NOTES

## RELATED LINKS

