---
external help file:
Module Name: Az.DeviceRegistry
online version: https://learn.microsoft.com/powershell/module/az.deviceregistry/revoke-azdeviceregistrynamespacedevice
schema: 2.0.0
---

# Revoke-AzDeviceRegistryNamespaceDevice

## SYNOPSIS
A long-running resource action.

## SYNTAX

### RevokeExpanded (Default)
```
Revoke-AzDeviceRegistryNamespaceDevice -DeviceName <String> -NamespaceName <String>
 -ResourceGroupName <String> [-SubscriptionId <String>] [-Disable] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Revoke
```
Revoke-AzDeviceRegistryNamespaceDevice -DeviceName <String> -NamespaceName <String>
 -ResourceGroupName <String> -Body <IDeviceCredentialsRevokeRequest> [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### RevokeViaIdentity
```
Revoke-AzDeviceRegistryNamespaceDevice -InputObject <IDeviceRegistryIdentity>
 -Body <IDeviceCredentialsRevokeRequest> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### RevokeViaIdentityExpanded
```
Revoke-AzDeviceRegistryNamespaceDevice -InputObject <IDeviceRegistryIdentity> [-Disable]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### RevokeViaIdentityNamespace
```
Revoke-AzDeviceRegistryNamespaceDevice -DeviceName <String> -NamespaceInputObject <IDeviceRegistryIdentity>
 -Body <IDeviceCredentialsRevokeRequest> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### RevokeViaIdentityNamespaceExpanded
```
Revoke-AzDeviceRegistryNamespaceDevice -DeviceName <String> -NamespaceInputObject <IDeviceRegistryIdentity>
 [-Disable] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### RevokeViaJsonFilePath
```
Revoke-AzDeviceRegistryNamespaceDevice -DeviceName <String> -NamespaceName <String>
 -ResourceGroupName <String> -JsonFilePath <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### RevokeViaJsonString
```
Revoke-AzDeviceRegistryNamespaceDevice -DeviceName <String> -NamespaceName <String>
 -ResourceGroupName <String> -JsonString <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
A long-running resource action.

## EXAMPLES

### Example 1: Revoke a namespace device
```powershell
Revoke-AzDeviceRegistryNamespaceDevice -ResourceGroupName "my-resource-group" -NamespaceName "my-namespace" -DeviceName "my-device"
```

Revokes the credentials for the specified device in the Device Registry namespace.
This is a long-running operation.

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

### -Body
Request payload for revoking device credentials.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DeviceRegistry.Models.IDeviceCredentialsRevokeRequest
Parameter Sets: Revoke, RevokeViaIdentity, RevokeViaIdentityNamespace
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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

### -DeviceName
The name of the device.

```yaml
Type: System.String
Parameter Sets: Revoke, RevokeExpanded, RevokeViaIdentityNamespace, RevokeViaIdentityNamespaceExpanded, RevokeViaJsonFilePath, RevokeViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Disable
Indicates whether to disable the device(s) after revoking credentials.
Prevents new credentials to be issued.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: RevokeExpanded, RevokeViaIdentityExpanded, RevokeViaIdentityNamespaceExpanded
Aliases:

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
Parameter Sets: RevokeViaIdentity, RevokeViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Revoke operation

```yaml
Type: System.String
Parameter Sets: RevokeViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Revoke operation

```yaml
Type: System.String
Parameter Sets: RevokeViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NamespaceInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DeviceRegistry.Models.IDeviceRegistryIdentity
Parameter Sets: RevokeViaIdentityNamespace, RevokeViaIdentityNamespaceExpanded
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
Parameter Sets: Revoke, RevokeExpanded, RevokeViaJsonFilePath, RevokeViaJsonString
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

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: Revoke, RevokeExpanded, RevokeViaJsonFilePath, RevokeViaJsonString
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
Parameter Sets: Revoke, RevokeExpanded, RevokeViaJsonFilePath, RevokeViaJsonString
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

### Microsoft.Azure.PowerShell.Cmdlets.DeviceRegistry.Models.IDeviceCredentialsRevokeRequest

### Microsoft.Azure.PowerShell.Cmdlets.DeviceRegistry.Models.IDeviceRegistryIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DeviceRegistry.Models.IDeviceCredentialsRevokeResponse

## NOTES

## RELATED LINKS

