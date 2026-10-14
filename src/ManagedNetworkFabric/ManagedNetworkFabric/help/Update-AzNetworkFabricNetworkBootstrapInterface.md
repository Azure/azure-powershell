---
external help file: Az.ManagedNetworkFabric-help.xml
Module Name: Az.ManagedNetworkFabric
online version: https://learn.microsoft.com/powershell/module/az.managednetworkfabric/update-aznetworkfabricnetworkbootstrapinterface
schema: 2.0.0
---

# Update-AzNetworkFabricNetworkBootstrapInterface

## SYNOPSIS
Update certain properties of the Network Bootstrap Interface resource.

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzNetworkFabricNetworkBootstrapInterface -Name <String> -NetworkBootstrapDeviceName <String>
 -ResourceGroupName <String> [-SubscriptionId <String>] [-AdditionalDescription <String>]
 [-Annotation <String>] [-SerialNumber <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaJsonString
```
Update-AzNetworkFabricNetworkBootstrapInterface -Name <String> -NetworkBootstrapDeviceName <String>
 -ResourceGroupName <String> [-SubscriptionId <String>] -JsonString <String> [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaJsonFilePath
```
Update-AzNetworkFabricNetworkBootstrapInterface -Name <String> -NetworkBootstrapDeviceName <String>
 -ResourceGroupName <String> [-SubscriptionId <String>] -JsonFilePath <String> [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaIdentityNetworkBootstrapDeviceExpanded
```
Update-AzNetworkFabricNetworkBootstrapInterface -Name <String>
 -NetworkBootstrapDeviceInputObject <IManagedNetworkFabricIdentity> [-AdditionalDescription <String>]
 [-Annotation <String>] [-SerialNumber <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaIdentityNetworkBootstrapDevice
```
Update-AzNetworkFabricNetworkBootstrapInterface -Name <String>
 -NetworkBootstrapDeviceInputObject <IManagedNetworkFabricIdentity> -Body <INetworkBootstrapInterfacePatch>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzNetworkFabricNetworkBootstrapInterface -InputObject <IManagedNetworkFabricIdentity>
 [-AdditionalDescription <String>] [-Annotation <String>] [-SerialNumber <String>] [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Update certain properties of the Network Bootstrap Interface resource.

## EXAMPLES

### Example 1: Update the Network Bootstrap Interface
```powershell
Update-AzNetworkFabricNetworkBootstrapInterface -Name $name -NetworkBootstrapDeviceName $networkBootstrapDeviceName -ResourceGroupName $resourceGroupName
```

```output
Id Name
-- ----
/subscriptions/<identity>/resourceGroups/nfa-tool-ts-powershell-rg092123/providers/Microsoft.ManagedNetworkFabric/networkBootstrapDevices/example-device/networkBootstrapInterfaces/example-interface example-interface
```

This command updates the properties of the given Network Bootstrap Interface.

## PARAMETERS

### -AdditionalDescription
Additional description of the interface.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityNetworkBootstrapDeviceExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Annotation
Switch configuration description.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityNetworkBootstrapDeviceExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

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
The NetworkBootstrapInterfacePatch resource definition.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ManagedNetworkFabric.Models.INetworkBootstrapInterfacePatch
Parameter Sets: UpdateViaIdentityNetworkBootstrapDevice
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

### -Name
Name of the Network Bootstrap Interface.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaJsonString, UpdateViaJsonFilePath, UpdateViaIdentityNetworkBootstrapDeviceExpanded, UpdateViaIdentityNetworkBootstrapDevice
Aliases: NetworkBootstrapInterfaceName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NetworkBootstrapDeviceInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ManagedNetworkFabric.Models.IManagedNetworkFabricIdentity
Parameter Sets: UpdateViaIdentityNetworkBootstrapDeviceExpanded, UpdateViaIdentityNetworkBootstrapDevice
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -NetworkBootstrapDeviceName
Name of the Network Bootstrap Device.

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

### -SerialNumber
Serial number of the interface.
Format of serial Number - Make;Model;HardwareRevisionId;SerialNumber.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityNetworkBootstrapDeviceExpanded, UpdateViaIdentityExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.ManagedNetworkFabric.Models.INetworkBootstrapInterfacePatch

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ManagedNetworkFabric.Models.INetworkBootstrapInterface

## NOTES

## RELATED LINKS
