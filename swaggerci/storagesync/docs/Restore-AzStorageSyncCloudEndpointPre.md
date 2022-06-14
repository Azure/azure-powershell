---
external help file:
Module Name: Az.StorageSync
online version: https://docs.microsoft.com/en-us/powershell/module/az.storagesync/restore-azstoragesynccloudendpointpre
schema: 2.0.0
---

# Restore-AzStorageSyncCloudEndpointPre

## SYNOPSIS
Pre Restore a given CloudEndpoint.

## SYNTAX

### RestoreExpanded (Default)
```
Restore-AzStorageSyncCloudEndpointPre -CloudEndpointName <String> -ResourceGroupName <String>
 -StorageSyncServiceName <String> -SyncGroupName <String> [-SubscriptionId <String>]
 [-AzureFileShareUri <String>] [-BackupMetadataPropertyBag <String>] [-Partition <String>]
 [-PauseWaitForSyncDrainTimePeriodInSecond <Int32>] [-ReplicaGroup <String>] [-RequestId <String>]
 [-RestoreFileSpec <IRestoreFileSpec[]>] [-SourceAzureFileShareUri <String>] [-Status <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Restore
```
Restore-AzStorageSyncCloudEndpointPre -CloudEndpointName <String> -ResourceGroupName <String>
 -StorageSyncServiceName <String> -SyncGroupName <String> -Parameter <IPreRestoreRequest>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### RestoreViaIdentity
```
Restore-AzStorageSyncCloudEndpointPre -InputObject <IStorageSyncIdentity> -Parameter <IPreRestoreRequest>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### RestoreViaIdentityExpanded
```
Restore-AzStorageSyncCloudEndpointPre -InputObject <IStorageSyncIdentity> [-AzureFileShareUri <String>]
 [-BackupMetadataPropertyBag <String>] [-Partition <String>]
 [-PauseWaitForSyncDrainTimePeriodInSecond <Int32>] [-ReplicaGroup <String>] [-RequestId <String>]
 [-RestoreFileSpec <IRestoreFileSpec[]>] [-SourceAzureFileShareUri <String>] [-Status <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Pre Restore a given CloudEndpoint.

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

### -AsJob
Run the command as a job

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

### -AzureFileShareUri
Pre Restore Azure file share uri.

```yaml
Type: System.String
Parameter Sets: RestoreExpanded, RestoreViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -BackupMetadataPropertyBag
Pre Restore backup metadata property bag.

```yaml
Type: System.String
Parameter Sets: RestoreExpanded, RestoreViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CloudEndpointName
Name of Cloud Endpoint object.

```yaml
Type: System.String
Parameter Sets: Restore, RestoreExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

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

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.StorageSync.Models.IStorageSyncIdentity
Parameter Sets: RestoreViaIdentity, RestoreViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -NoWait
Run the command asynchronously

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

### -Parameter
Pre Restore request object.
To construct, see NOTES section for PARAMETER properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.StorageSync.Models.Api20200901.IPreRestoreRequest
Parameter Sets: Restore, RestoreViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Partition
Pre Restore partition.

```yaml
Type: System.String
Parameter Sets: RestoreExpanded, RestoreViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
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

### -PauseWaitForSyncDrainTimePeriodInSecond
Pre Restore pause wait for sync drain time period in seconds.

```yaml
Type: System.Int32
Parameter Sets: RestoreExpanded, RestoreViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ReplicaGroup
Pre Restore replica group.

```yaml
Type: System.String
Parameter Sets: RestoreExpanded, RestoreViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RequestId
Pre Restore request id.

```yaml
Type: System.String
Parameter Sets: RestoreExpanded, RestoreViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: Restore, RestoreExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RestoreFileSpec
Pre Restore restore file spec array.
To construct, see NOTES section for RESTOREFILESPEC properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.StorageSync.Models.Api20200901.IRestoreFileSpec[]
Parameter Sets: RestoreExpanded, RestoreViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SourceAzureFileShareUri
Pre Restore Azure source azure file share uri.

```yaml
Type: System.String
Parameter Sets: RestoreExpanded, RestoreViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Status
Pre Restore Azure status.

```yaml
Type: System.String
Parameter Sets: RestoreExpanded, RestoreViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StorageSyncServiceName
Name of Storage Sync Service resource.

```yaml
Type: System.String
Parameter Sets: Restore, RestoreExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String
Parameter Sets: Restore, RestoreExpanded
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -SyncGroupName
Name of Sync Group resource.

```yaml
Type: System.String
Parameter Sets: Restore, RestoreExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.StorageSync.Models.Api20200901.IPreRestoreRequest

### Microsoft.Azure.PowerShell.Cmdlets.StorageSync.Models.IStorageSyncIdentity

## OUTPUTS

### System.Boolean

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


INPUTOBJECT <IStorageSyncIdentity>: Identity Parameter
  - `[CloudEndpointName <String>]`: Name of Cloud Endpoint object.
  - `[Id <String>]`: Resource identity path
  - `[LocationName <String>]`: The desired region for the name check.
  - `[OperationId <String>]`: operation Id
  - `[PrivateEndpointConnectionName <String>]`: The name of the private endpoint connection associated with the Azure resource
  - `[ResourceGroupName <String>]`: The name of the resource group. The name is case insensitive.
  - `[ServerEndpointName <String>]`: Name of Server Endpoint object.
  - `[ServerId <String>]`: GUID identifying the on-premises server.
  - `[StorageSyncServiceName <String>]`: Name of Storage Sync Service resource.
  - `[SubscriptionId <String>]`: The ID of the target subscription.
  - `[SyncGroupName <String>]`: Name of Sync Group resource.
  - `[WorkflowId <String>]`: workflow Id

PARAMETER <IPreRestoreRequest>: Pre Restore request object.
  - `[AzureFileShareUri <String>]`: Pre Restore Azure file share uri.
  - `[BackupMetadataPropertyBag <String>]`: Pre Restore backup metadata property bag.
  - `[Partition <String>]`: Pre Restore partition.
  - `[PauseWaitForSyncDrainTimePeriodInSecond <Int32?>]`: Pre Restore pause wait for sync drain time period in seconds.
  - `[ReplicaGroup <String>]`: Pre Restore replica group.
  - `[RequestId <String>]`: Pre Restore request id.
  - `[RestoreFileSpec <IRestoreFileSpec[]>]`: Pre Restore restore file spec array.
    - `[Isdir <Boolean?>]`: Restore file spec isdir
    - `[Path <String>]`: Restore file spec path
  - `[SourceAzureFileShareUri <String>]`: Pre Restore Azure source azure file share uri.
  - `[Status <String>]`: Pre Restore Azure status.

RESTOREFILESPEC <IRestoreFileSpec[]>: Pre Restore restore file spec array.
  - `[Isdir <Boolean?>]`: Restore file spec isdir
  - `[Path <String>]`: Restore file spec path

## RELATED LINKS

