---
external help file:
Module Name: Az.StorageSync
online version: https://docs.microsoft.com/en-us/powershell/module/az.storagesync/start-azstoragesynccloudendpointchangedetection
schema: 2.0.0
---

# Start-AzStorageSyncCloudEndpointChangeDetection

## SYNOPSIS
Triggers detection of changes performed on Azure File share connected to the specified Azure File Sync Cloud Endpoint.

## SYNTAX

### TriggerExpanded (Default)
```
Start-AzStorageSyncCloudEndpointChangeDetection -CloudEndpointName <String> -ResourceGroupName <String>
 -StorageSyncServiceName <String> -SyncGroupName <String> [-SubscriptionId <String>]
 [-ChangeDetectionMode <ChangeDetectionMode>] [-DirectoryPath <String>] [-Path <String[]>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Trigger
```
Start-AzStorageSyncCloudEndpointChangeDetection -CloudEndpointName <String> -ResourceGroupName <String>
 -StorageSyncServiceName <String> -SyncGroupName <String> -Parameter <ITriggerChangeDetectionParameters>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### TriggerViaIdentity
```
Start-AzStorageSyncCloudEndpointChangeDetection -InputObject <IStorageSyncIdentity>
 -Parameter <ITriggerChangeDetectionParameters> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### TriggerViaIdentityExpanded
```
Start-AzStorageSyncCloudEndpointChangeDetection -InputObject <IStorageSyncIdentity>
 [-ChangeDetectionMode <ChangeDetectionMode>] [-DirectoryPath <String>] [-Path <String[]>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Triggers detection of changes performed on Azure File share connected to the specified Azure File Sync Cloud Endpoint.

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

### -ChangeDetectionMode
Change Detection Mode.
Applies to a directory specified in directoryPath parameter.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.StorageSync.Support.ChangeDetectionMode
Parameter Sets: TriggerExpanded, TriggerViaIdentityExpanded
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
Parameter Sets: Trigger, TriggerExpanded
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

### -DirectoryPath
Relative path to a directory Azure File share for which change detection is to be performed.

```yaml
Type: System.String
Parameter Sets: TriggerExpanded, TriggerViaIdentityExpanded
Aliases:

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
Parameter Sets: TriggerViaIdentity, TriggerViaIdentityExpanded
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
The parameters used when calling trigger change detection action on cloud endpoint.
To construct, see NOTES section for PARAMETER properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.StorageSync.Models.Api20200901.ITriggerChangeDetectionParameters
Parameter Sets: Trigger, TriggerViaIdentity
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

### -Path
Array of relative paths on the Azure File share to be included in the change detection.
Can be files and directories.

```yaml
Type: System.String[]
Parameter Sets: TriggerExpanded, TriggerViaIdentityExpanded
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
Parameter Sets: Trigger, TriggerExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StorageSyncServiceName
Name of Storage Sync Service resource.

```yaml
Type: System.String
Parameter Sets: Trigger, TriggerExpanded
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
Parameter Sets: Trigger, TriggerExpanded
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
Parameter Sets: Trigger, TriggerExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.StorageSync.Models.Api20200901.ITriggerChangeDetectionParameters

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

PARAMETER <ITriggerChangeDetectionParameters>: The parameters used when calling trigger change detection action on cloud endpoint.
  - `[ChangeDetectionMode <ChangeDetectionMode?>]`: Change Detection Mode. Applies to a directory specified in directoryPath parameter.
  - `[DirectoryPath <String>]`: Relative path to a directory Azure File share for which change detection is to be performed.
  - `[Path <String[]>]`: Array of relative paths on the Azure File share to be included in the change detection. Can be files and directories.

## RELATED LINKS

