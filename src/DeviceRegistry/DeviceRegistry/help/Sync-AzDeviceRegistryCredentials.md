---
external help file: Az.DeviceRegistry-help.xml
Module Name: Az.DeviceRegistry
online version: https://learn.microsoft.com/powershell/module/az.deviceregistry/sync-azdeviceregistrycredentials
schema: 2.0.0
---

# Sync-AzDeviceRegistryCredentials

## SYNOPSIS
A long-running resource action.

## SYNTAX

### Synchronize (Default)
```
Sync-AzDeviceRegistryCredentials -NamespaceName <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

### SynchronizeViaIdentity
```
Sync-AzDeviceRegistryCredentials -InputObject <IDeviceRegistryIdentity> [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-PassThru] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
A long-running resource action.

## EXAMPLES

### Example 1: Sync credentials to connected services
```powershell
Sync-AzDeviceRegistryCredentials -NamespaceName my-namespace -ResourceGroupName my-resource-group
```

```output
Status    : Succeeded
Message   : Credentials successfully synchronized to IoT Hub and DPS
Timestamp : 12/2/2024 11:40:15 AM
```

Synchronizes the namespace credentials with connected IoT Hub and Device Provisioning Service (DPS) instances.
This operation ensures that the credential certificates are propagated to all connected services for device authentication.

### Example 2: Sync credentials with verbose output
```powershell
Sync-AzDeviceRegistryCredentials -NamespaceName my-namespace -ResourceGroupName my-resource-group -Verbose
```

```output
VERBOSE: Initiating credential synchronization...
VERBOSE: Syncing to IoT Hub: my-hub.azure-devices.net
VERBOSE: Syncing to DPS: my-dps.azure-devices-provisioning.net
VERBOSE: Synchronization completed successfully
Status    : Succeeded
Message   : Credentials successfully synchronized to IoT Hub and DPS
Timestamp : 12/2/2024 11:42:33 AM
```

Synchronizes credentials with verbose logging to track the synchronization process across connected services.

### Example 3: Sync credentials using pipeline input
```powershell
Get-AzDeviceRegistryCredentials -NamespaceName my-namespace -ResourceGroupName my-resource-group | Sync-AzDeviceRegistryCredentials
```

```output
Status    : Succeeded
Message   : Credentials successfully synchronized to IoT Hub and DPS
Timestamp : 12/2/2024 11:45:08 AM
```

Retrieves credentials and pipes them to the sync operation, synchronizing the credentials to all connected IoT services.

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

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DeviceRegistry.Models.IDeviceRegistryIdentity
Parameter Sets: SynchronizeViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -NamespaceName
The name of the namespace.

```yaml
Type: System.String
Parameter Sets: Synchronize
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
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

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: Synchronize
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.
The value must be an UUID.

```yaml
Type: System.String
Parameter Sets: Synchronize
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
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

### Microsoft.Azure.PowerShell.Cmdlets.DeviceRegistry.Models.IDeviceRegistryIdentity

## OUTPUTS

### System.Boolean

## NOTES

## RELATED LINKS
