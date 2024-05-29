---
external help file: Az.ManagedNetworkFabric-help.xml
Module Name: Az.ManagedNetworkFabric
online version: https://learn.microsoft.com/powershell/module/az.managednetworkfabric/invoke-aznetworkfabricinterfaceupdateadminstate
schema: 2.0.0
---

# Invoke-AzNetworkFabricInterfaceUpdateAdminState

## SYNOPSIS
Update the admin state of the Network Interface.

## SYNTAX

### UpdateExpanded (Default)
```
Invoke-AzNetworkFabricInterfaceUpdateAdminState -NetworkDeviceName <String> -NetworkInterfaceName <String>
 -ResourceGroupName <String> [-SubscriptionId <String>] [-ResourceId <String[]>] [-State <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### UpdateViaJsonString
```
Invoke-AzNetworkFabricInterfaceUpdateAdminState -NetworkDeviceName <String> -NetworkInterfaceName <String>
 -ResourceGroupName <String> [-SubscriptionId <String>] -JsonString <String> [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaJsonFilePath
```
Invoke-AzNetworkFabricInterfaceUpdateAdminState -NetworkDeviceName <String> -NetworkInterfaceName <String>
 -ResourceGroupName <String> [-SubscriptionId <String>] -JsonFilePath <String> [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaIdentityNetworkDeviceExpanded
```
Invoke-AzNetworkFabricInterfaceUpdateAdminState -NetworkInterfaceName <String>
 -NetworkDeviceInputObject <IManagedNetworkFabricIdentity> [-ResourceId <String[]>] [-State <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### UpdateViaIdentityNetworkDevice
```
Invoke-AzNetworkFabricInterfaceUpdateAdminState -NetworkInterfaceName <String>
 -NetworkDeviceInputObject <IManagedNetworkFabricIdentity> -Body <IUpdateAdministrativeState>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Invoke-AzNetworkFabricInterfaceUpdateAdminState -InputObject <IManagedNetworkFabricIdentity>
 [-ResourceId <String[]>] [-State <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Update the admin state of the Network Interface.

## EXAMPLES

### Example 1: Update the admin state of the Network Interface
```powershell
$state="Enable"
Invoke-AzNetworkFabricInterfaceUpdateAdminState -NetworkDeviceName $deviceName -NetworkInterfaceName $name -ResourceGroupName $resourceGroupName -State $state
```

This command update the admin state of the Network Interface

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
Update administrative state on list of resources.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ManagedNetworkFabric.Models.IUpdateAdministrativeState
Parameter Sets: UpdateViaIdentityNetworkDevice
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

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ManagedNetworkFabric.Models.IManagedNetworkFabricIdentity
Parameter Sets: UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Update operation

```yaml
Type: System.String
Parameter Sets: UpdateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Update operation

```yaml
Type: System.String
Parameter Sets: UpdateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NetworkDeviceInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ManagedNetworkFabric.Models.IManagedNetworkFabricIdentity
Parameter Sets: UpdateViaIdentityNetworkDeviceExpanded, UpdateViaIdentityNetworkDevice
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -NetworkDeviceName
Name of the Network Device.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaJsonString, UpdateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NetworkInterfaceName
Name of the Network Interface.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaJsonString, UpdateViaJsonFilePath, UpdateViaIdentityNetworkDeviceExpanded, UpdateViaIdentityNetworkDevice
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
Parameter Sets: UpdateExpanded, UpdateViaJsonString, UpdateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceId
Network Fabrics or Network Rack resource Id.

```yaml
Type: System.String[]
Parameter Sets: UpdateExpanded, UpdateViaIdentityNetworkDeviceExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -State
Administrative state.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityNetworkDeviceExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
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
Parameter Sets: UpdateExpanded, UpdateViaJsonString, UpdateViaJsonFilePath
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

### Microsoft.Azure.PowerShell.Cmdlets.ManagedNetworkFabric.Models.IManagedNetworkFabricIdentity

### Microsoft.Azure.PowerShell.Cmdlets.ManagedNetworkFabric.Models.IUpdateAdministrativeState

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ManagedNetworkFabric.Models.ICommonPostActionResponseForStateUpdate

## NOTES

## RELATED LINKS
