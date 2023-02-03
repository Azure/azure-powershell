---
external help file:
Module Name: Az.DataProtection
online version: https://learn.microsoft.com/powershell/module/az.dataprotection/initialize-azdataprotectionbackupinstance
schema: 2.0.0
---

# Initialize-AzDataProtectionBackupInstance

## SYNOPSIS
Initializes Backup instance Request object for configuring backup

## SYNTAX

```
Initialize-AzDataProtectionBackupInstance -DatasourceLocation <String> -DatasourceType <DatasourceTypes>
 [-BackupConfiguration <KubernetesClusterBackupDatasourceParameters>] [-DatasourceId <String>]
 [-FriendlyName <String>] [-PolicyId <String>] [-SecretStoreType <SecretStoreTypes>]
 [-SecretStoreURI <String>] [-SnapshotResourceGroupId <String>] [<CommonParameters>]
```

## DESCRIPTION
Initializes Backup instance Request object for configuring backup

## EXAMPLES

### Example 1: Get Backup instance object for Azure Disk
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

The First command gets all the policies in a given vault.
The second command stores azure disk's resource id in $AzureDiskId
variable.
The third command returns a backup instance resource for Azure Disk.
The fourth command sets the snapshot resource group field.
This object can now be used to configure backup for the given disk.

## PARAMETERS

### -BackupConfiguration
Backup configuration for backup.
Use this parameter to configure protection for KubernetesService.
To construct, see NOTES section for BACKUPCONFIGURATION properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202301.KubernetesClusterBackupDatasourceParameters
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DatasourceId
ID of the datasource to be protected

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

### -DatasourceLocation
Location of the Datasource to be protected.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
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

### -FriendlyName
Friendly name for backup instance

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

### -PolicyId
Policy Id to be assiciated to Datasource

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

### -SecretStoreType
Secret store type for secret store authentication of data source.
This parameter is only supported for AzureDatabaseForPostgreSQL currently.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.SecretStoreTypes
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SecretStoreURI
Secret uri for secret store authentication of data source.
This parameter is only supported for AzureDatabaseForPostgreSQL currently.

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

### -SnapshotResourceGroupId
Sanpshot Resource Group

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

### Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202301.IBackupInstanceResource

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`BACKUPCONFIGURATION <KubernetesClusterBackupDatasourceParameters>`: Backup configuration for backup. Use this parameter to configure protection for KubernetesService.
  - `IncludeClusterScopeResource <Boolean>`: Gets or sets the include cluster resources property. This property if enabled will include cluster scope resources during restore.
  - `SnapshotVolume <Boolean>`: Gets or sets the volume snapshot property. This property if enabled will take volume snapshots during restore.
  - `ObjectType <String>`: Type of the specific object - used for deserializing
  - `[ExcludedNamespace <String[]>]`: Gets or sets the exclude namespaces property. This property sets the namespaces to be excluded during restore.
  - `[ExcludedResourceType <String[]>]`: Gets or sets the exclude resource types property. This property sets the resource types to be excluded during restore.
  - `[IncludedNamespace <String[]>]`: Gets or sets the include namespaces property. This property sets the namespaces to be included during restore.
  - `[IncludedResourceType <String[]>]`: Gets or sets the include resource types property. This property sets the resource types to be included during restore.
  - `[LabelSelector <String[]>]`: Gets or sets the LabelSelectors property. This property sets the resource with such label selectors to be included during restore.

## RELATED LINKS

