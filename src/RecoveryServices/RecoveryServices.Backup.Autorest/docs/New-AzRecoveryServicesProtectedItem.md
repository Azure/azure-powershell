---
external help file:
Module Name: Az.RecoveryServices
online version: https://docs.microsoft.com/powershell/module/az.recoveryservices/new-azrecoveryservicesprotecteditem
schema: 2.0.0
---

# New-AzRecoveryServicesProtectedItem

## SYNOPSIS
Enables backup of an item or to modifies the backup policy information of an already backed up item.
This is an\r\nasynchronous operation.
To know the status of the operation, call the GetItemOperationResult API.

## SYNTAX

### CreateExpanded (Default)
```
New-AzRecoveryServicesProtectedItem -ContainerName <String> -FabricName <String> -Name <String>
 -ResourceGroupName <String> -VaultName <String> [-SubscriptionId <String>] [-BackupSetName <String>]
 [-CreateMode <CreateMode>] [-DeferredDeleteTimeInUtc <DateTime>] [-DeferredDeleteTimeRemaining <String>]
 [-ETag <String>] [-IsArchiveEnabled] [-IsDeferredDeleteScheduleUpcoming] [-IsRehydrate]
 [-IsScheduledForDeferredDelete] [-LastRecoveryPoint <DateTime>] [-Location <String>] [-PolicyId <String>]
 [-PolicyName <String>] [-PropertiesContainerName <String>] [-ProtectedItemType <String>]
 [-ResourceGuardOperationRequest <String[]>] [-SoftDeleteRetentionPeriod <Int32>] [-SourceResourceId <String>]
 [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Create
```
New-AzRecoveryServicesProtectedItem -ContainerName <String> -FabricName <String> -Name <String>
 -ResourceGroupName <String> -VaultName <String> -Parameter <IProtectedItemResource>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaIdentity
```
New-AzRecoveryServicesProtectedItem -InputObject <IRecoveryServicesIdentity>
 -Parameter <IProtectedItemResource> [-DefaultProfile <PSObject>] [-PassThru] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### CreateViaIdentityExpanded
```
New-AzRecoveryServicesProtectedItem -InputObject <IRecoveryServicesIdentity> [-ContainerName <String>]
 [-BackupSetName <String>] [-CreateMode <CreateMode>] [-DeferredDeleteTimeInUtc <DateTime>]
 [-DeferredDeleteTimeRemaining <String>] [-ETag <String>] [-IsArchiveEnabled]
 [-IsDeferredDeleteScheduleUpcoming] [-IsRehydrate] [-IsScheduledForDeferredDelete]
 [-LastRecoveryPoint <DateTime>] [-Location <String>] [-PolicyId <String>] [-PolicyName <String>]
 [-ProtectedItemType <String>] [-ResourceGuardOperationRequest <String[]>]
 [-SoftDeleteRetentionPeriod <Int32>] [-SourceResourceId <String>] [-Tag <Hashtable>]
 [-DefaultProfile <PSObject>] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Enables backup of an item or to modifies the backup policy information of an already backed up item.
This is an\r\nasynchronous operation.
To know the status of the operation, call the GetItemOperationResult API.

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

### -BackupSetName
Name of the backup set the backup item belongs to

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ContainerName
Container name associated with the backup item.

```yaml
Type: System.String
Parameter Sets: Create, CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CreateMode
Create mode to indicate recovery of existing soft deleted data source or creation of new data source.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Support.CreateMode
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultProfile
The DefaultProfile parameter is not functional.
Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.

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

### -DeferredDeleteTimeInUtc
Time for deferred deletion in UTC

```yaml
Type: System.DateTime
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DeferredDeleteTimeRemaining
Time remaining before the DS marked for deferred delete is permanently deleted

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ETag
Optional ETag.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FabricName
Fabric name associated with the backup item.

```yaml
Type: System.String
Parameter Sets: Create, CreateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.IRecoveryServicesIdentity
Parameter Sets: CreateViaIdentity, CreateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -IsArchiveEnabled
Flag to identify whether datasource is protected in archive

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IsDeferredDeleteScheduleUpcoming
Flag to identify whether the deferred deleted DS is to be purged soon

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IsRehydrate
Flag to identify that deferred deleted DS is to be moved into Pause state

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IsScheduledForDeferredDelete
Flag to identify whether the DS is scheduled for deferred delete

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -LastRecoveryPoint
Timestamp when the last (latest) backup copy was created for this backup item.

```yaml
Type: System.DateTime
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Location
Resource location.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Item name to be backed up.

```yaml
Type: System.String
Parameter Sets: Create, CreateExpanded
Aliases: ProtectedItemName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Parameter
Base class for backup items.
To construct, see NOTES section for PARAMETER properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.IProtectedItemResource
Parameter Sets: Create, CreateViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -PassThru
Returns true when the command succeeds

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

### -PolicyId
ID of the backup policy with which this item is backed up.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PolicyName
Name of the policy used for protection

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PropertiesContainerName
Unique name of container

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProtectedItemType
backup item type.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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
Parameter Sets: Create, CreateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGuardOperationRequest
ResourceGuardOperationRequests on which LAC check will be performed

```yaml
Type: System.String[]
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SoftDeleteRetentionPeriod
Soft delete retention period in days

```yaml
Type: System.Int32
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SourceResourceId
ARM ID of the resource to be backed up.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The subscription Id.

```yaml
Type: System.String
Parameter Sets: Create, CreateExpanded
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
Resource tags.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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
Parameter Sets: Create, CreateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WhatIf
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.IProtectedItemResource

### Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.IRecoveryServicesIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.IProtectedItemResource

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`INPUTOBJECT <IRecoveryServicesIdentity>`: Identity Parameter
  - `[AzureRegion <String>]`: Azure region to hit Api
  - `[BackupEngineName <String>]`: Name of the backup management server.
  - `[ContainerName <String>]`: 
  - `[FabricName <String>]`: Fabric name associated with the backed up item.
  - `[Id <String>]`: Resource identity path
  - `[IntentObjectName <String>]`: Backed up item name whose details are to be fetched.
  - `[JobName <String>]`: Name of the job whose details are to be fetched.
  - `[OperationId <String>]`: Operation id
  - `[PolicyName <String>]`: Backup policy information to be fetched.
  - `[PrivateEndpointConnectionName <String>]`: The name of the private endpoint connection.
  - `[ProtectedItemName <String>]`: 
  - `[RecoveryPointId <String>]`: 
  - `[ResourceGroupName <String>]`: The name of the resource group where the recovery services vault is present.
  - `[ResourceGuardProxyName <String>]`: 
  - `[SubscriptionId <String>]`: The subscription Id.
  - `[VaultName <String>]`: The name of the recovery services vault.

`PARAMETER <IProtectedItemResource>`: Base class for backup items.
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

