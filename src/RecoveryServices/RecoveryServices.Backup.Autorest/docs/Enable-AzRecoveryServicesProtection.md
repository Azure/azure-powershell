---
external help file:
Module Name: Az.RecoveryServices
online version: https://docs.microsoft.com/powershell/module/az.recoveryservices/enable-azrecoveryservicesprotection
schema: 2.0.0
---

# Enable-AzRecoveryServicesProtection

## SYNOPSIS
Triggers the enable protection operation for the given item

## SYNTAX

```
Enable-AzRecoveryServicesProtection -DatasourceType <DatasourceTypes> -ResourceGroupName <String>
 -VaultName <String> [-ExcludeAllDataDisks] [-ExclusionDisksList <String[]>] [-InclusionDisksList <String[]>]
 [-Item <IProtectedItemResource>] [-PolicyId <String>] [-ResetExclusionSettings] [-VMName <String>]
 [<CommonParameters>]
```

## DESCRIPTION
Triggers the enable protection operation for the given item

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

## PARAMETERS

### -DatasourceType
Datasource Type

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Support.DatasourceTypes
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ExcludeAllDataDisks
Option to specify to backup OS disks only

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

### -ExclusionDisksList
List of Disk LUNs to be excluded in backup and the rest are automatically included.

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

### -InclusionDisksList
List of Disk LUNs to be included in backup and the rest are automatically excluded except OS disk.

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

### -Item
Specifies the item for which this cmdlet enables protection.
To obtain a BackupItem , use the Get-AzRecoveryServicesBackupItem cmdlet.
To construct, see NOTES section for ITEM properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.IProtectedItemResource
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PolicyId
Specifies protection policyId that this cmdlet associates with an item.
To obtain policyId use Get-AzRecoveryServicesBackupPolicy cmdlet, then extract Id from the obtained policy

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

### -ResetExclusionSettings
Specifies to reset disk exclusion setting associated with the item

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

### -ResourceGroupName
Specifies the name of the resource group of a virtual machine.

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

### -VaultName
The name of the recovery services vault.

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

### -VMName
Specifies the name of the Backup item.
Pass this parameter if it is first time protection

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

### Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.IProtectedItem

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`ITEM <IProtectedItemResource>`: Specifies the item for which this cmdlet enables protection. To obtain a BackupItem , use the Get-AzRecoveryServicesBackupItem cmdlet.
  - `[ETag <String>]`: Optional ETag.
  - `[Location <String>]`: Resource location.
  - `[Tag <IResourceTags>]`: Resource tags.
    - `[(Any) <String>]`: This indicates any property can be added to this object.
  - `[BackupSetName <String>]`: Name of the backup set the backup item belongs to
  - `[ContainerName <String>]`: Unique name of container
  - `[CreateMode <CreateMode?>]`: Create mode to indicate recovery of existing soft deleted data source or creation of new data source.
  - `[DeferredDeleteTimeInUtc <DateTime?>]`: Time for deferred deletion in UTC
  - `[DeferredDeleteTimeRemaining <String>]`: Time remaining before the DS marked for deferred delete is permanently deleted
  - `[IsArchiveEnabled <Boolean?>]`: Flag to identify whether datasource is protected in archive
  - `[IsDeferredDeleteScheduleUpcoming <Boolean?>]`: Flag to identify whether the deferred deleted DS is to be purged soon
  - `[IsRehydrate <Boolean?>]`: Flag to identify that deferred deleted DS is to be moved into Pause state
  - `[IsScheduledForDeferredDelete <Boolean?>]`: Flag to identify whether the DS is scheduled for deferred delete
  - `[LastRecoveryPoint <DateTime?>]`: Timestamp when the last (latest) backup copy was created for this backup item.
  - `[PolicyId <String>]`: ID of the backup policy with which this item is backed up.
  - `[PolicyName <String>]`: Name of the policy used for protection
  - `[ProtectedItemType <String>]`: backup item type.
  - `[ResourceGuardOperationRequest <String[]>]`: ResourceGuardOperationRequests on which LAC check will be performed
  - `[SoftDeleteRetentionPeriod <Int32?>]`: Soft delete retention period in days
  - `[SourceResourceId <String>]`: ARM ID of the resource to be backed up.

## RELATED LINKS

