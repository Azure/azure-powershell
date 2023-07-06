---
external help file:
Module Name: Az.RecoveryServices
online version: https://docs.microsoft.com/powershell/module/az.recoveryservices/disable-azrecoveryservicesprotection
schema: 2.0.0
---

# Disable-AzRecoveryServicesProtection

## SYNOPSIS
Triggers the disable protection operation for the given item

## SYNTAX

```
Disable-AzRecoveryServicesProtection -DatasourceType <DatasourceTypes> -Item <IProtectedItemResource>
 -ResourceGroupName <String> -VaultName <String> [-NoWait] [-RemoveRecoveryPoints]
 [-RetainRecoveryPointsAsPerPolicy] [-RetainRecoveryPointsForever] [<CommonParameters>]
```

## DESCRIPTION
Triggers the disable protection operation for the given item

## EXAMPLES

### Example 1: RemoveRecoveryPoints - AzureVM
```powershell
$item=Get-AzRecoveryServicesBackupProtectedItem -ResourceGroupName arohijain-rg -VaultName arohijain-backupvault -SubscriptionId "38304e13-357e-405e-9e9a-220351dcce8c" -Filter "backupManagementType eq 'AzureIaasVM' and WorkloadType -eq 'AzureVM'" | Where-Object { $_.Property.FriendlyName -match "arohijain-vm"}
Disable-AzRecoveryServicesProtection -DatasourceType AzureVM -ResourceGroupName arohijain-rg -VaultName arohijain-backupvault -Item $item -RemoveRecoveryPoints -NoWait
```

```output


```

The first command fetches the protected item for which protection needs to be disabled.
The second command disables the protection on the fetched item with NoWait.

### Example 2: RetainRecoveryPointsForever - AzureVM
```powershell
$item=Get-AzRecoveryServicesBackupProtectedItem -ResourceGroupName arohijain-rg -VaultName arohijain-backupvault -SubscriptionId "38304e13-357e-405e-9e9a-220351dcce8c" -Filter "backupManagementType eq 'AzureIaasVM' and WorkloadType -eq 'AzureVM'" | Where-Object { $_.Property.FriendlyName -match "arohijain-vm"}
Disable-AzRecoveryServicesProtection -DatasourceType AzureVM -ResourceGroupName arohijain-rg -VaultName arohijain-backupvault -Item $item -RetainRecoveryPointsForever
```

The first command fetches the protected item for which protection needs to be disabled.
The second command disables the protection on the fetched item.

### Example 3: RetainRecoveryPointsAsPerPolicy - AzureVM
```powershell
$item=Get-AzRecoveryServicesBackupProtectedItem -ResourceGroupName arohijain-rg -VaultName arohijain-backupvault -SubscriptionId "38304e13-357e-405e-9e9a-220351dcce8c" -Filter "backupManagementType eq 'AzureIaasVM' and WorkloadType -eq 'AzureVM'" | Where-Object { $_.Property.FriendlyName -match "arohijain-vm"}
Disable-AzRecoveryServicesProtection -DatasourceType AzureVM -ResourceGroupName arohijain-rg -VaultName arohijain-backupvault -Item $item -RetainRecoveryPointsAsPerPolicy
```

The first command fetches the protected item for which protection needs to be disabled.
The second command disables the protection on the fetched item.

### Example 4: RemoveRecoveryPoints - MSSQL
```powershell
$item = Get-AzRecoveryServicesBackupProtectedItem -ResourceGroupName hiagarg -VaultName hiagaVault -SubscriptionId "38304e13-357e-405e-9e9a-220351dcce8c" -Filter "backupManagementType eq 'AzureWorkload' and WorkloadType -eq 'MSSQL'" | Where-Object { $_.Name -match "SQLDataBase;MSSQLSERVER;model_restored_5_31_2023_1254"}
Disable-AzRecoveryServicesProtection -DatasourceType MSSQL -ResourceGroupName hiagarg -VaultName hiagaVault -Item $item -RemoveRecoveryPoints
```

```output


```

The first command fetches the protected item for which protection needs to be disabled.
The second command disables the protection on the fetched item.

### Example 5: RetainRecoveryPointsForever - MSSQL
```powershell
$item = Get-AzRecoveryServicesBackupProtectedItem -ResourceGroupName hiagarg -VaultName hiagaVault -SubscriptionId "38304e13-357e-405e-9e9a-220351dcce8c" -Filter "backupManagementType eq 'AzureWorkload' and WorkloadType -eq 'MSSQL'" | Where-Object { $_.Name -match "SQLDataBase;MSSQLSERVER;model_restored_5_31_2023_1254"}
Disable-AzRecoveryServicesProtection -DatasourceType MSSQL -ResourceGroupName hiagarg -VaultName hiagaVault -Item $item -RetainRecoveryPointsForever 
```

The first command fetches the protected item for which protection needs to be disabled.
The second command disables the protection on the fetched item.

### Example 6: RetainRecoveryPointsAsPerPolicy - MSSQL
```powershell
$item = Get-AzRecoveryServicesBackupProtectedItem -ResourceGroupName hiagarg -VaultName hiagaVault -SubscriptionId "38304e13-357e-405e-9e9a-220351dcce8c" -Filter "backupManagementType eq 'AzureWorkload' and WorkloadType -eq 'MSSQL'" | Where-Object { $_.Name -match "SQLDataBase;MSSQLSERVER;model_restored_5_31_2023_1254"}
Disable-AzRecoveryServicesProtection -DatasourceType MSSQL -ResourceGroupName hiagarg -VaultName hiagaVault -Item $item -RetainRecoveryPointsAsPerPolicy
```

The first command fetches the protected item for which protection needs to be disabled.
The second command disables the protection on the fetched item.

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

### -Item
Specifies the Backup item for which this cmdlet disables protection.
To obtain a BackupItem , use the Get-AzRecoveryServicesBackupItem cmdlet.
To construct, see NOTES section for ITEM properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.IProtectedItemResource
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NoWait


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

### -RemoveRecoveryPoints
Switch parameter to indicate that this cmdlet disables protection and deletes existing recovery points

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
The name of the resource group where the recovery services vault is present.

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

### -RetainRecoveryPointsAsPerPolicy
Switch parameter to indicate that this cmdlet disables protection and retains recovery points as per policy

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

### -RetainRecoveryPointsForever
Switch parameter to indicate that this cmdlet disables protection and retains recovery points forever

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### System.Management.Automation.PSObject

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`ITEM <IProtectedItemResource>`: Specifies the Backup item for which this cmdlet disables protection. To obtain a BackupItem , use the Get-AzRecoveryServicesBackupItem cmdlet.
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

