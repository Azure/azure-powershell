---
external help file:
Module Name: Az.RecoveryServices
online version: https://learn.microsoft.com/powershell/module/az.recoveryservices/get-azrecoveryservicesbackupitem
schema: 2.0.0
---

# Get-AzRecoveryServicesBackupItem

## SYNOPSIS
Gets list of backup items protected with a recovery services vault

## SYNTAX

### GetItemsForVault (Default)
```
Get-AzRecoveryServicesBackupItem -DatasourceType <DatasourceTypes> -ResourceGroupName <String>
 -VaultName <String> [-DefaultProfile <PSObject>] [-DeleteState <String>] [-FriendlyName <String>]
 [-Name <String>] [-ProtectionState <String>] [-ProtectionStatus <String>] [-SubscriptionId <String[]>]
 [<CommonParameters>]
```

### GetItemsForContainer
```
Get-AzRecoveryServicesBackupItem -Container <IProtectionContainerResource> -DatasourceType <DatasourceTypes>
 -ResourceGroupName <String> -VaultName <String> [-DefaultProfile <PSObject>] [-DeleteState <String>]
 [-FriendlyName <String>] [-Name <String>] [-ProtectionState <String>] [-ProtectionStatus <String>]
 [-SubscriptionId <String[]>] [<CommonParameters>]
```

### GetItemsForpolicy
```
Get-AzRecoveryServicesBackupItem -Policy <IProtectionPolicyResource> -ResourceGroupName <String>
 -VaultName <String> [-DefaultProfile <PSObject>] [-DeleteState <String>] [-FriendlyName <String>]
 [-Name <String>] [-ProtectionState <String>] [-ProtectionStatus <String>] [-SubscriptionId <String[]>]
 [<CommonParameters>]
```

## DESCRIPTION
Gets list of backup items protected with a recovery services vault

## EXAMPLES

### Example 1: Get backup items protected by recovery services vault
```powershell
$items = Get-AzRecoveryServicesBackupItem -ResourceGroupName $resourceGroupName -VaultName $vaultName -SubscriptionId $subscriptionId -DatasourceType AzureVM
$items
```

```output
ETag Location Name
---- -------- ----
              VM;iaasvmcontainerv2;hiagarg;hiagavm1
              VM;iaasvmcontainerv2;hiagarg;hiagavm2
              VM;iaasvmcontainerv2;hiagarg;hiagavm
```

This command fetches the backup items protected by a recovery services vault for DatasourceType AzureVM.

### Example 2: Get backup items for a particular container
```powershell
$container = Get-AzRecoveryServicesBackupContainer -ResourceGroupName $resourceGroupName -VaultName $vaultName -SubscriptionId $subscriptionId -ContainerType AzureVMAppContainer -DatasourceType MSSQL | Where-Object { $_.Name -match $containerFriendlyName }
$items = Get-AzRecoveryServicesBackupItem -ResourceGroupName $resourceGroupName -VaultName $vaultName -SubscriptionId $subscriptionId -DatasourceType MSSQL -Container $container
$items[0] | fl
```

```output
BackupManagementType             : AzureWorkload
BackupSetName                    :
ContainerName                    : VMAppContainer;Compute;hiagarg;sql-pstest-vm1
CreateMode                       :
DeferredDeleteTimeInUtc          :
DeferredDeleteTimeRemaining      :
ETag                             :
Id                               : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/hiagarg/providers/Microsoft.RecoveryServices/vaults/hiagaVault/backupFabrics/Azure/protectionContainers/VMAppContainer;Compute;hiagarg;sql-pstest-vm1/protectedItems/SQLDataBase;MSSQLSERVER;model
IsArchiveEnabled                 : False
IsDeferredDeleteScheduleUpcoming :
IsRehydrate                      :
IsScheduledForDeferredDelete     :
LastRecoveryPoint                :
Location                         :
Name                             : SQLDataBase;MSSQLSERVER;model
PolicyId                         :
PolicyName                       :
Property                         : Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.AzureVMWorkloadSqlDatabaseProtectedItem
ProtectedItemType                : AzureVmWorkloadSQLDatabase
ResourceGuardOperationRequest    :
SoftDeleteRetentionPeriod        : 0
SourceResourceId                 : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/hiagarg/providers/Microsoft.Compute/virtualMachines/sql-pstest-vm1
Tag                              : Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.ResourceTags
Type                             : Microsoft.RecoveryServices/vaults/backupFabrics/protectionContainers/protectedItems
WorkloadType                     : SQLDataBase
```

The first command gets the backup container and second command fetches the backup items protected by a recovery services vault for DatasourceType MSSQL and belong to backup container $container.

### Example 3: Get backup items protected by a backup policy
```powershell
$policy =  Get-AzRecoveryServicesBackupProtectionPolicy -ResourceGroupName $resourceGroupName -VaultName $vaultName -PolicySubType "Standard" -DatasourceType MSSQL | Where-Object { $_.Name -match "HourlyLogBackup"  }
$items = Get-AzRecoveryServicesBackupItem -ResourceGroupName $resourceGroupName -VaultName $vaultName -SubscriptionId $subscriptionId -Policy $policy
$items
```

```output
ETag Location Name
---- -------- ----
              SQLDataBase;mssqlserver;msdb
              SQLDataBase;MSSQLSERVER;mig-db1
              SQLDataBase;mssqlserver;model
```

The first command gets the backup policy and second command fetches the backup items protected by a recovery services vault with the policy.

## PARAMETERS

### -Container
Specifies a container object from which this cmdlet gets backup items.
To obtain an ProtectionContainerResource, use the Get-AzRecoveryServicesBackupContainer cmdlet.
To construct, see NOTES section for CONTAINER properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.IProtectionContainerResource
Parameter Sets: GetItemsForContainer
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DatasourceType
Specifies the DatasourceType

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Support.DatasourceTypes
Parameter Sets: GetItemsForContainer, GetItemsForVault
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultProfile


```yaml
Type: System.Management.Automation.PSObject
Parameter Sets: (All)
Aliases: AzureRMContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DeleteState
Specifies the delete state of the item The acceptable values for this parameter are: 
 ToBeDeleted 
 NotDeleted

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

### -FriendlyName
FriendlyName of the backed up item

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

### -Name
Specifies the name of backup item.
For file share, specify the unique ID of protected file share.

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

### -Policy
Protection policy object
To construct, see NOTES section for POLICY properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.IProtectionPolicyResource
Parameter Sets: GetItemsForpolicy
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProtectionState
Specifies the state of protection.
The acceptable values for this parameter are: 
 IRPending.
Initial synchronization has not started and there is no recovery point yet.

 Protected.
Protection is ongoing.

 ProtectionError.
There is a protection error.

 ProtectionStopped.
Protection is disabled.

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

### -ProtectionStatus
Specifies the overall protection status of an item in the container.
The acceptable values for this parameter are: Healthy, Unhealthy

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

### -SubscriptionId
Subscription Id

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

### Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.IProtectedItemResource

## NOTES

## RELATED LINKS

